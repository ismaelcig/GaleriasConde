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
    /// Lógica de interacción para MsgControl.xaml
    /// </summary>
    public partial class MsgControl : UserControl
    {
        public MsgControl()
        {
            InitializeComponent();
        }
        public MsgControl(Message msg)
        {
            InitializeComponent();
            if (msg.Sender.nick == A_Login.user.nick)
            {
                lbluser.Content = (string)A_Login.dict["You"];
                lbluser.Foreground = Brushes.Chocolate;
                this.HorizontalAlignment = HorizontalAlignment.Right;
                border.CornerRadius = new CornerRadius(10, 10, 0, 10);
            }
            else
            {
                lbluser.Content = msg.Sender.nick;
                this.HorizontalAlignment = HorizontalAlignment.Left;
                border.CornerRadius = new CornerRadius(10, 10, 10, 0);
            }

            //Comprueba si el msg contiene:
            if (!string.IsNullOrEmpty(msg.text) && msg.adjunto == null)
            {//Sólo texto
                tbMsg.Text = msg.text;
            }
            else if (msg.adjunto != null && string.IsNullOrEmpty(msg.text))
            {//Sólo imagen
                tbMsg.Width = 0;
                tbMsg.Height = 0;
                img.Source = Converters.BytesToImg(msg.adjunto);
            }
            else if (!string.IsNullOrEmpty(msg.text) && msg.adjunto != null)
            {//Ambos, en este caso será una propuesta de venta para un admin, pero se podría implementar más adelante para usuarios
                tbMsg.Text = msg.text;
                img.Source = Converters.BytesToImg(msg.adjunto);
            }
        }
    }
}
