using Galeria.Model;
using Galeria.Other_Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Galeria.Windows
{
    /// <summary>
    /// Lógica de interacción para E_Sell.xaml
    /// </summary>
    public partial class E_Sell : Elysium.Controls.Window
    {

        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        System.Windows.Threading.DispatcherTimer dispatcherTimer1;
        byte[] arrayImg;
        Chat chat;
        public E_Sell()
        {
            InitializeComponent();

            this.Name = "E_Sell";
            A_Login.windows.Add(this);
            Resources.MergedDictionaries.Add(A_Login.dict);

            Loaders.LoadAuthors(comboBoxAut);
            comboBoxAut.SelectedValuePath = "realName";
            Loaders.LoadTypes(comboBoxType);
            comboBoxType.SelectedValuePath = "codType";
        }

        #region Effectos
        private void img_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                dispatcherTimer1.Stop();
            }
            catch (Exception ex)
            {//Da error la primera vez, porque todavía no se ha iniciado
                //Console.WriteLine("Error: " + ex.Message);
                //Console.WriteLine("Inner: " + ex.InnerException);
            }
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 3);
            dispatcherTimer.Start();
        }

        private void img_MouseLeave(object sender, MouseEventArgs e)
        {
            dispatcherTimer.Stop();
            dispatcherTimer1 = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer1.Tick += DispatcherTimer1_Tick;
            dispatcherTimer1.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer1.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (overImg.Opacity < 0.8)
            {
                overImg.Opacity = overImg.Opacity + 0.2;
            }
            else
            {
                dispatcherTimer.Stop();
            }
        }

        private void DispatcherTimer1_Tick(object sender, EventArgs e)
        {
            if (overImg.Opacity > 0)
            {
                overImg.Opacity = overImg.Opacity - 0.1;
            }
            else
            {
                dispatcherTimer.Stop();
            }
        }

        private void img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = (string)A_Login.dict["ofdFilterIco"];
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == true)
            {
                string[] split = ofd.FileName.Split('.');
                if (split.Last().Equals("gif"))//Sólo se admite este formato para que el byte[] no sea demasiado grande
                {
                    arrayImg = Converters.ReadImageFile(ofd.FileName);//Guarda la img seleccionada como array de Bytes
                    img.Source = Converters.BytesToImg(arrayImg);//La muestra en la interfaz
                }
                else
                {
                    MessageBox.Show((string)A_Login.dict["MngUP_Msg1"]);//Formato incorrecto
                }
            }
        }
        #endregion

        private void txtAut_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAut.Text))
            {
                comboBoxAut.IsEnabled = false;
            }
            else
            {
                comboBoxAut.IsEnabled = true;
            }
        }

        private void txtType_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtType.Text))
            {
                comboBoxType.IsEnabled = false;
            }
            else
            {
                comboBoxType.IsEnabled = true;
            }
        }

        //Envía propuesta
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtTitle.Text))//El resto puede quedar vacío si no se conoce
                {
                    #region msg
                    string msg = "Me gustaría vender una obra con los siguientes datos:" + Environment.NewLine;
                    msg += "Título: " + txtTitle.Text + Environment.NewLine;
                    msg += "Autor: ";
                    if (string.IsNullOrWhiteSpace(txtAut.Text) && comboBoxAut.SelectedIndex == -1)
                    {//No indica Autor
                        msg += "Desconocido";
                    }
                    else if (!string.IsNullOrWhiteSpace(txtAut.Text))
                    {
                        msg += txtAut.Text;
                    }
                    else
                    {
                        msg += comboBoxAut.SelectedValue;
                    }
                    msg += Environment.NewLine +
                        "Tipo: ";
                    if (string.IsNullOrWhiteSpace(txtType.Text) && comboBoxType.SelectedIndex == -1)
                    {//No indica Tipo
                        msg += "Desconocido";
                    }
                    else if (!string.IsNullOrWhiteSpace(txtType.Text))
                    {
                        msg += txtType.Text;
                    }
                    else
                    {
                        msg += comboBoxType.SelectedValue;
                    }
                    msg += Environment.NewLine +
                        "Comentario: " + txtinfo.Text;
                    #endregion
                    List<User> admins = A_Login.u.UsersRep.Get(c => c.Profile.ProfileID == 3);
                    Random r = new Random();
                    int adminIndex = r.Next(0, admins.Count);//Selecciona un admin aleatorio, e inicia un chat con el, si no lo hay ya; y le manda el mensaje
                    chat = new Chat(new List<User> { admins[adminIndex], A_Login.user });
                    //Message m = new Message()
                    if (!ChatExists())
                    {
                        chat.messages = new List<Message>();

                        Message m = new Message(chat, msg, arrayImg, A_Login.user);
                        chat.messages.Add(m);

                        A_Login.u.ChatsRep.Create(chat);//Crea el chat con el mensaje añadido
                    }
                    else
                    {//El chat ya existe
                        List<Chat> chatsUser = A_Login.u.ChatsRep.GetAll();
                        foreach (Chat item in chatsUser)
                        {//Recorre todos los chats para comprobar si existe ya uno con los usuarios seleccionados
                            int n = item.users.Count;//Nº de usuarios
                            foreach (User us in item.users)
                            {
                                if (chat.users.Contains(us))
                                    n--;
                                else
                                    break;
                            }
                            if (n == 0)
                            {//Cuando se cumpla esta condición, implica que item es el chat que busco
                                chat = item;
                            }
                        }
                        Message m = new Message(chat, msg, arrayImg, A_Login.user);
                        A_Login.u.MessagesRep.Create(m);

                        MessageBox.Show((string)A_Login.dict["S_Msg1"]);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("Sell", ex);
            }
        }

        bool ChatExists()
        {
            try
            {
                List<Chat> chatsUser = A_Login.u.ChatsRep.GetAll();
                foreach (Chat item in chatsUser)
                {//Recorre todos los chats para comprobar si existe ya uno con los usuarios seleccionados
                    int n = item.users.Count;//Nº de usuarios
                    foreach (User us in item.users)
                    {
                        if (chat.users.Contains(us))
                            n--;
                        else
                            break;
                    }
                    if (n == 0)
                    {//Cuando se cumpla esta condición, implica que existe ya un chat
                        return true;
                    }
                }
                return false;//Si llega hasta aquí, significa que no existe
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            C_Galeria.cg.overAllShadow.Visibility = Visibility.Hidden;
            C_Galeria.cg.Show();
        }
    }
}
