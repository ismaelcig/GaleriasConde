using Galeria.Model;
using Galeria.Other_Classes;
using Galeria.Windows;
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

namespace Galeria.User_Controls.Messages_Window
{
    /// <summary>
    /// Lógica de interacción para AddChat.xaml
    /// </summary>
    public partial class AddChat : UserControl
    {
        List<User> users;
        public AddChat()
        {
            InitializeComponent();
            users = new List<User>();
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {//Comprueba que no existe ya un chat con los miembros seleccionados
            users.Add(A_Login.user);
            if (!ChatExists())
            {
                Chat c = new Chat(users);
                //c.users = users;
                c.messages = new List<Message>();
                A_Login.u.ChatsRep.Create(c);
            }
            else
            {
                MessageBox.Show((string)A_Login.dict["MngAC_Msg2"]);//ya existe
            }
            users.Clear();
            UpdateList();
        }

        private void cancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            users.Clear();
            UpdateList();
        }

        private void addUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /*
             * ***Reglas:***
             * -> comprador y vendedor son cuentas del sistema, no se habla con ellas
             * -> con master no se puede contactar por mensajes
             * -> con uno mismo no se puede iniciar un chat
             * -> con quien queremos iniciar un chat tiene que existir
             * -> si ya existe un chat con los usuarios seleccionados, no se puede crear uno nuevo
             * 
             */
            string txt = textBox.Text;//Para facilitar las comprobaciones
            if (txt.ToUpper() != "COMPRADOR" &&
                txt.ToUpper() != "VENDEDOR" &&
                txt.ToLower() != "master" &&
                txt.ToLower() != A_Login.user.nick.ToLower() &&
                A_Login.u.UsersRep.Get(c => c.nick == txt).Count == 1)
            {//Añade al usuario a la lista
                users.Add(A_Login.u.UsersRep.Single(c => c.nick == txt));
                UpdateList();
                textBox.Text = "";
            }
            else
            {
                MessageBox.Show((string)A_Login.dict["MngAC_Msg1"]);//User incorrecto
            }
        }

        void UpdateList()
        {
            string s = "";
            //chatUsers.Content = "";
            foreach (User item in users)
            {
                if (s != "")
                {
                    s += ", ";
                }
                s += item.nick;
            }
            List<string> sda = Loaders.AdjustLblLenght(s, 34);
            s = sda[0];
            if (sda.Count > 1)
            {
                s += "...";
            }
            chatUsers.Content = s;
        }

        bool ChatExists()
        {
            try
            {
                List<Chat> chatsUser = A_Login.u.ChatsRep.GetAll();
                //chatsUser = A_Login.u.ChatsRep.Get(c => c.users.Contains(A_Login.user));
                foreach (Chat item in chatsUser)
                {//Recorre todos los chats para comprobar si existe ya uno con los usuarios seleccionados
                    int n = item.users.Count;//Nº de usuarios
                    foreach (User us in item.users)
                    {
                        if (users.Contains(us))
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

        private void textBox_KeyDown(object sender, KeyEventArgs e)//Pulsar Enter añade el usuario
        {
            if (e.Key == Key.Enter)
            {
                var grid = new Grid();

                int timestamp = new TimeSpan(DateTime.Now.Ticks).Milliseconds;
                const MouseButton mouseButton = MouseButton.Left;
                var mouseDownEvent =
                   new MouseButtonEventArgs(Mouse.PrimaryDevice, timestamp, mouseButton)
                   {
                       RoutedEvent = UIElement.MouseLeftButtonDownEvent,
                       Source = grid,
                   };
                addUser_MouseDown(sender, mouseDownEvent);
            }
        }
    }
}
