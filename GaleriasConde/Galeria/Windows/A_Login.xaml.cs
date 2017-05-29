using Galeria.DAL;
using Galeria.Dict;
using Galeria.Model;
using Galeria.User_Controls;
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
        public static Usuario user = new Usuario();
        public static A_Login mw;
        CargarDiccionarios cd = new CargarDiccionarios();
        public static ResourceDictionary dict = new ResourceDictionary();
        List<Usuario> l = new List<Usuario>();//Lista de usuarios que se carga en ListBox
        public static List<Window> windows = new List<Window>();//Lista de ventanas abiertas, para realizar el cambio de idioma en todas

        public A_Login()
        {
            try
            {
                InitializeComponent();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error InitializeComponent - \r\n  " + ex);
            }
            this.Name = "A_Login";
            mw = this;
            windows.Add(mw);
            GridPW.Visibility = Visibility.Hidden;
            txtUser.textBox.Focus();
            dict = cd.LanguageSelector(cd.GetLanguageDictionary());
            this.Resources.MergedDictionaries.Add(dict);
            LoadHints();
        }


        #region Buttons
        private void buttNext_Click(object sender, RoutedEventArgs e)
        {//Pasa al siguiente Grid si el usuario existe, else: pregunta si quiere entrar sin registrarse
            if (!string.IsNullOrWhiteSpace(txtUser.textBox.Text))
            {
                if (u.UsuariosRepository.Get(c => c.nick.ToString() == txtUser.textBox.Text).Count == 1)
                {//Comprueba que existe el usuario introducido

                    //Guardo el usuario que entra
                    user = u.UsuariosRepository.Single(c => c.nick.ToString() == txtUser.textBox.Text);

                    //Muestra Password Grid
                    GridPW.Visibility = Visibility.Visible;
                    pass.passBox.Focus();
                }
                else
                {
                    string msg = (string)dict["MW_Msg2"];//User no existe
                    var result = MessageBox.Show(msg, "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {//Entra sin usuario, con el nick que acaba de escribir, no tiene ningún permiso
                        user = new Usuario { nick = txtUser.textBox.Text };
                        C_Galeria gal = new C_Galeria();
                        windows.Add(gal);
                        gal.Show();
                    }
                    else
                    {
                        txtUser.textBox.Text = "";
                        txtUser.textBox.Focus();
                    }
                }
            }
            else
            {
                string msg = (string)dict["MW_Msg1"];//Campo vacío
                MessageBox.Show(msg);
            }
        }
        private void buttReg_Click(object sender, RoutedEventArgs e)
        {
            B_Registro reg = new B_Registro();
            //reg.comboBox.keyHint = "RGnacion";
            windows.Add(reg);
            reg.Show();
            Hide();
            mw.txtUser.textBox.Text = "";
            mw.pass.passBox.Password = "";
        }



        private void buttLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pass.passBox.Password))
            {//Comprueba que se ha introducido contraseña
                if (pass.passBox.Password == user.pass)
                {//Comprueba su contraseña
                    C_Galeria gal = new C_Galeria();
                    windows.Add(gal);
                    gal.Show();
                    txtUser.textBox.Text = "";
                    pass.passBox.Password = "";
                    GridPW.Visibility = Visibility.Hidden;
                    Hide();
                    mw.txtUser.textBox.Text = "";
                    mw.pass.passBox.Password = "";
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
            pass.passBox.Password = "";
            GridPW.Visibility = Visibility.Hidden;
            txtUser.textBox.Focus(); 
        }


        #endregion

        //Al emplear UserControls, no funcionan
        //private void textBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        buttNext_Click(sender, e);
        //    }
        //    else if (e.Key == Key.LeftAlt)
        //    {//cubre con los datos de mi user
        //        user = u.UsuariosRepository.Single(c => c.UsuarioID == 4);
        //        txtUser.textBox.Text = user.nick;
        //        pass.passBox.Password = user.pass;
        //    }
        //}

        //private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        buttLogin_Click(sender, e);
        //    }
        //}

        public void LoadHints()
        {
            txtUser.hintTB.Text = (string)dict["MWtxt"];
            pass.hintTB.Text = (string)dict["MWpass"];
        }
    }
}
