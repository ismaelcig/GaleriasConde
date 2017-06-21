using Galeria.Model;
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

namespace Galeria.User_Controls.Management_Windows
{
    /// <summary>
    /// Interaction logic for MngUsers.xaml
    /// </summary>
    public partial class MngUsers : UserControl
    {
        User obj = new User();
        public MngUsers()
        {
            InitializeComponent();
            if (A_Login.user.Profile.ProfileID >= 4)
            {
                ReloadData();
            }
        }

        //Prepara para modificar el Usuario seleccionado, o limpia los campos si se ha deseleccionado
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedIndex > -1)
            {
                obj = new User();
                obj = (User)dataGrid.SelectedItem;
                txtUser.Text = obj.nick;
                if (obj.Profile.ProfileID == 2)//Es un user normal
                {
                    checkBox.IsChecked = false;
                }
                else if (obj.Profile.ProfileID == 3 || obj.Profile.ProfileID == 4)//Es un admin o master
                {
                    checkBox.IsChecked = true;
                }

                checkBox.IsEnabled = true;
                buttMod.IsEnabled = true;
                buttDel.IsEnabled = true;
            }
            else
            {
                ReloadData();
            }
        }

        //Botón Modificar (Sólo la cuenta master puede modificar usuarios, pero como esta pestaña sólo la verá master, no hace falta comprobarlo)
        private void buttMod_Click(object sender, RoutedEventArgs e)
        {
            if (obj.nick != "master")
            {
                User u = A_Login.u.UsersRep.Single(c => c.UserID == obj.UserID);
                if (checkBox.IsChecked)
                {
                    u.Profile = A_Login.u.ProfilesRep.Single(c => c.ProfileID == 3);//Lo hace admin
                }
                else
                {
                    u.Profile = A_Login.u.ProfilesRep.Single(c => c.ProfileID == 2);//Lo hace usuario normal
                }
                A_Login.u.UsersRep.Update(u);

                ReloadData();
                dataGrid.SelectedIndex = 0;
                dataGrid.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show((string)A_Login.dict["MngU_Msg1"]);//No puede borrar permisos de master
            }
        }

        //Botón Eliminar (no se puede eliminar la cuenta master)
        private void buttDel_Click(object sender, RoutedEventArgs e)
        {if (obj.nick != "master")
            {
                A_Login.u.UsersRep.Delete(obj);
                ReloadData();
                try {dataGrid.SelectedIndex = 0;}
                catch (Exception)
                {}
                dataGrid.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show((string)A_Login.dict["MngU_Msg1"]);//No puede borrar la cuenta master
            }
        }


        public void ReloadData()
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = A_Login.u.UsersRep.GetAll();

            checkBox.IsEnabled = false;
            buttMod.IsEnabled = false;
            buttDel.IsEnabled = false;

            txtUser.Text = "";
            checkBox.IsChecked = false;
        }
    }
}
