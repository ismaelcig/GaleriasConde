using Galeria.DAL;
using Galeria.Dict;
using Galeria.Model;
using Galeria.Other_Classes;
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
    /// Interaction logic for A_Login.xaml
    /// </summary>
    public partial class A_Login : Elysium.Controls.Window
    {
        public static UnitOfWork u = new UnitOfWork();
        public static User user = new User();
        public static A_Login mw;
        CargarDiccionarios cd = new CargarDiccionarios();
        public static ResourceDictionary dict = new ResourceDictionary();
        List<User> l = new List<User>();//Lista de usuarios que se carga en ListBox
        public static List<Window> windows = new List<Window>();//Lista de ventanas abiertas, para realizar el cambio de idioma en todas

        public A_Login()
        {
            try
            {
                InitializeComponent();
                
            }
            catch (Exception ex)
            {
                ErrorLog.Log("A_Log1", ex);
            }
            this.Name = "A_Login";
            mw = this;
            windows.Add(mw);
            GridPW.Visibility = Visibility.Hidden;
            textBox.Focus();
            dict = cd.LanguageSelector(cd.GetLanguageDictionary());
            this.Resources.MergedDictionaries.Add(dict);
        }


        #region Buttons
        private void buttNext_Click(object sender, RoutedEventArgs e)
        {//Pasa al siguiente Grid si el usuario existe, else: pregunta si quiere entrar sin registrarse
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    if (u.UsersRep.Get(c => c.nick.ToString() == textBox.Text).Count == 1)
                    {//Comprueba que existe el usuario introducido

                        //Guardo el usuario que entra
                        user = u.UsersRep.Single(c => c.nick.ToString() == textBox.Text);

                        //Muestra Password Grid
                        GridPW.Visibility = Visibility.Visible;
                        passwordBox.Focus();
                    }
                    else
                    {
                        string msg = (string)dict["MW_Msg2"];//User no existe
                        var result = MessageBox.Show(msg, "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {//Entra sin usuario, con el nick que acaba de escribir, no tiene ningún permiso
                            user = new User { nick = textBox.Text, Profile = u.ProfilesRep.Single(c => c.codProfile == "Default") };
                            C_Galeria gal = new C_Galeria();
                            gal.Show();
                            Hide();
                        }
                        else
                        {
                            textBox.Text = "";
                            textBox.Focus();
                        }
                    }
                }
                else
                {
                    string msg = (string)dict["MW_Msg1"];//Campo vacío
                    MessageBox.Show(msg);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("A_Log2", ex);
            }
        }
        private void buttReg_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
            passwordBox.Password = "";
            try
            {
                B_Registro reg = new B_Registro();
                reg.Show();
                mw.Hide();
            }
            catch (Exception ex)
            {
                ErrorLog.Log("A_Log3", ex);
            }
        }



        private void buttLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(passwordBox.Password))
            {//Comprueba que se ha introducido contraseña
                if (passwordBox.Password == user.pass)
                {//Comprueba su contraseña
                    C_Galeria gal = new C_Galeria();
                    gal.Show();
                    textBox.Text = "";
                    passwordBox.Password = "";
                    GridPW.Visibility = Visibility.Hidden;
                    this.Hide();
                }
                else
                {
                    string msg = (string)dict["MW_Msg3"];//Pass incorrecta
                    MessageBox.Show(msg);
                }
            }
            else
            {
                string msg = (string)dict["MW_Msg4"];//Campo vacío pass
                MessageBox.Show(msg);
            }
        }



        private void buttBack_Click(object sender, RoutedEventArgs e)
        {
            passwordBox.Password = "";
            GridPW.Visibility = Visibility.Hidden;
            textBox.Focus(); 
        }
        #endregion


        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttNext_Click(sender, e);
            }
            else if (e.Key == Key.LeftAlt)
            {//cubre con los datos de mi user
                user = u.UsersRep.Single(c => c.UserID == 4);
                textBox.Text = user.nick;
                passwordBox.Password = user.pass;
            }
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttLogin_Click(sender, e);
            }
        }
    }
}
