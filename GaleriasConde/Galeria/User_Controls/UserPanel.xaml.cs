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

namespace Galeria.User_Controls
{
    /// <summary>
    /// Interaction logic for UserPanel.xaml
    /// </summary>
    public partial class UserPanel : UserControl
    {
        public UserPanel()
        {
            InitializeComponent();
            lblNick.Content = A_Login.user.nick;
            lblEmail.Content = A_Login.user.email;
            lblTlf.Content = A_Login.user.tlf;
            if (A_Login.user.Profile.codProfile == "Default")
            {
                buttEdit.Visibility = Visibility.Hidden;
            }
        }

        private void buttEdit_Click(object sender, RoutedEventArgs e)
        {//Abre ventana/Panel para modificar datos perfil

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
    }
}
