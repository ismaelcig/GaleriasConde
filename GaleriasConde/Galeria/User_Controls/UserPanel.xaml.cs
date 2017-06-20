using Galeria.Other_Classes;
using Galeria.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Galeria.User_Controls
{
    /// <summary>
    /// Interaction logic for UserPanel.xaml
    /// </summary>
    public partial class UserPanel : UserControl
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        System.Windows.Threading.DispatcherTimer dispatcherTimer1;
        
        public UserPanel()
        {
            InitializeComponent();
            lblNick.Content = A_Login.user.nick;
            lblEmail.Content = A_Login.user.email;
            lblTlf.Content = A_Login.user.tlf;
            imgBrush.ImageSource = Converters.BytesToImg(A_Login.user.picture);
            if (A_Login.user.Profile.codProfile == "Default")
            {
                buttEdit.Visibility = Visibility.Hidden;
            }
        }

        private void buttEdit_Click(object sender, RoutedEventArgs e)
        {//Abre ventana/Panel para modificar datos perfil
            D_UserOptions duo = new D_UserOptions();
            C_Galeria.cg.overAllShadow.Visibility = Visibility.Visible;
            duo.Show();
        }

        private void buttClose_Click(object sender, RoutedEventArgs e)
        {//Cierra el panel, y oculta el grid shadow
            C_Galeria.cg.show.Children.Clear();
            C_Galeria.cg.shadow.Visibility = Visibility.Hidden;
        }

        private void buttLogout_Click(object sender, RoutedEventArgs e)
        {
            C_Galeria.cg.LogOut();
        }

        #region Effectos
        private void Ellipse_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                dispatcherTimer1.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Inner: " + ex.InnerException);
            }
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 3);
            dispatcherTimer.Start();
        }

        private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            dispatcherTimer.Stop();
            dispatcherTimer1 = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer1.Tick += DispatcherTimer1_Tick;
            dispatcherTimer1.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer1.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (overImgBrush.Opacity < 0.8)
            {
                overImgBrush.Opacity = overImgBrush.Opacity + 0.2;
            }
            else
            {
                dispatcherTimer.Stop();
            }
        }

        private void DispatcherTimer1_Tick(object sender, EventArgs e)
        {
            if (overImgBrush.Opacity > 0)
            {
                overImgBrush.Opacity = overImgBrush.Opacity - 0.1;
            }
            else
            {
                dispatcherTimer.Stop();
            }
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = (string)A_Login.dict["ofdFilterIco"];
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == true)
            {
                string[] split = ofd.FileName.Split('.');
                if (split.Last().Equals("ico"))//Sólo se admite este formato para que el byte[] no sea demasiado grande
                {
                    A_Login.user.picture = Converters.ReadImageFile(ofd.FileName);//Guarda la img seleccionada como array de Bytes
                    //TODO: Borrar
                    //byte[] sad = Converters.ReadImageFile(ofd.FileName);
                    //Console.WriteLine("There we go: ");
                    //foreach (byte item in sad)
                    //{
                    //    Console.Write(item + ", ");
                    //}
                    //Console.WriteLine("");
                    //Console.WriteLine("End");
                    A_Login.u.UsersRep.Update(A_Login.user);
                    imgBrush.ImageSource = Converters.BytesToImg(A_Login.user.picture);//La muestra en la interfaz
                }
                else
                {
                    MessageBox.Show((string)A_Login.dict["MngUP_Msg1"]);//Formato incorrecto
                }
            }
        }
        #endregion
    }
}
