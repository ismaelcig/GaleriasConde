using Galeria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Interaction logic for B_Registro.xaml
    /// </summary>
    public partial class B_Registro : Elysium.Controls.Window//TODO: BorderBrush = Brushes.Red en todos los casos de error
    {
        public static B_Registro bregistro;
        User us = new User();

        public B_Registro()
        {
            InitializeComponent();
            bregistro = this;
            txt1Name.Focus();

            comboBox.DisplayMemberPath = "nombre";
            comboBox.SelectedValuePath = "NacionalidadID";
            comboBox.ItemsSource = A_Login.u.NationalitiesRep.GetAll();
            gridPass.Visibility = Visibility.Hidden;
        }


        /**************************************/
        //GRID BASE
        #region GridBase
        private void buttSig_Click(object sender, RoutedEventArgs e)
        {
            txt3Nick.BorderBrush = null;
            if (string.IsNullOrWhiteSpace(txt1Name.Text) && string.IsNullOrWhiteSpace(txt2Apell.Text) && string.IsNullOrWhiteSpace(txt3Nick.Text) && string.IsNullOrWhiteSpace(txt4Dir.Text) && string.IsNullOrWhiteSpace(txt5Email.Text) && string.IsNullOrWhiteSpace(txt6Tlf.Text) && comboBox.SelectedIndex != -1)
            {//Comprueba que se han rellenado los campos antes de proseguir
                //Creo un usuario con esos datos y lo valido
                #region CreaUser
                us.name = txt1Name.Text;
                us.surnames = txt2Apell.Text;
                us.nick = txt3Nick.Text;
                us.Nationality = (Nationality)comboBox.SelectedItem;
                //us.pass = passwordBox1.Password;
                us.address = txt4Dir.Text;
                us.email = txt5Email.Text;
                us.tlf = txt6Tlf.Text;
                #endregion
                if (A_Login.u.UsersRep.Get(c => c.nick == us.nick).Count > 0)
                {//Significa que ya hay un usuario con ese nick
                    MessageBox.Show((string)A_Login.dict["RG_Msg2"]);//Nick ya registrado
                    txt3Nick.Text = "";
                    txt3Nick.Focus();
                    txt3Nick.BorderBrush = Brushes.Red;
                }
                else if (validado(us))
                {
                    gridPass.Visibility = Visibility.Visible;
                    buttConfirmar.IsEnabled = false;
                }
            }
            else
            {
                MessageBox.Show((string)A_Login.dict["RG_Msg1"]);//Campos en blanco
            }
        }

        private void buttCancel_Click(object sender, RoutedEventArgs e)
        {
            Cerrar();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Cerrar();
        }
        #endregion

        //GRID CONTRASEÑA
        #region GridPass
        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {//A medida que el usuario teclea, le muestra si está cumpliendo los requisitos para la contraseña
            #region Checks
            //Mayúscula
            if (passwordBox1.Password.Any(c => char.IsUpper(c)))
            {check1.IsChecked = true;}
            else
            {check1.IsChecked = false;}
            //Minúscula
            if (passwordBox1.Password.Any(c => char.IsLower(c)))
            {check2.IsChecked = true;}
            else
            {check2.IsChecked = false;}
            //5 caracteres
            if (passwordBox1.Password.Length > 4)
            {check3.IsChecked = true;}
            else
            {check3.IsChecked = false;}
            //Número
            if (passwordBox1.Password.Any(c => char.IsNumber(c)))
            {check4.IsChecked = true;}
            else
            {check4.IsChecked = false;}
            //Coincidir
            if (passwordBox1.Password == passwordBox2.Password)
            {check5.IsChecked = true;}
            else
            {check5.IsChecked = false;}
            #endregion
            //Button
            if (check1.IsChecked && check2.IsChecked && check3.IsChecked && check4.IsChecked && check5.IsChecked)
            {// Si cumple todo, permite pulsar el botón
                buttConfirmar.IsEnabled = true;
            }
            else
            {
                buttConfirmar.IsEnabled = false;
            }
        }

        private void passwordBox1_KeyDown(object sender, KeyEventArgs e)
        {//Pulsar Enter = pulsar botón Confirmar
            if (e.Key == Key.Enter)
            {
                buttConfirmar_Click(sender, e);
            }
        }


        private void buttConfirmar_Click(object sender, RoutedEventArgs e)
        {//Se registra al usuario
            A_Login.u.UsersRep.Create(us);
            MessageBox.Show((string)A_Login.dict["RG_Msg3"]);
            Cerrar();
        }

        private void buttBack_Click(object sender, RoutedEventArgs e)
        {
            Atras();
        }
        void Atras()
        {//Devuelve a la pantalla para introducir los datos
            gridPass.Visibility = Visibility.Hidden;
            passwordBox1.Password = "";
            passwordBox2.Password = "";
        }
        #endregion

        //MÉTODO VALIDACIÓN
        private Boolean validado(Object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj, null, null);
            List<System.ComponentModel.DataAnnotations.ValidationResult> errors = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            Validator.TryValidateObject(obj, validationContext, errors, true);

            if (errors.Count() > 0)
            {
                string mensageErrores = string.Empty;
                foreach (var error in errors)
                {
                    error.MemberNames.First();

                    mensageErrores += error.ErrorMessage + Environment.NewLine;
                }
                MessageBox.Show(mensageErrores); return false;
            }
            else
            {
                return true;
            }
        }
        void Cerrar()
        {//Devuelve a la ventana de Login
            A_Login.windows.Remove(bregistro);//Elimino esta ventana de la lista de ventanas abiertas
            A_Login.mw.Show();
            Close();
            A_Login.mw.textBox.Focus();
        }


    }
}
