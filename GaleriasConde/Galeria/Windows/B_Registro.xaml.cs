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
        Usuario us = new Usuario();

        public B_Registro()
        {
            InitializeComponent();
            this.Name = "B_Registro";
            bregistro = this;
            Resources.MergedDictionaries.Add(A_Login.dict);

            LoadHints();
            txt1Name.Focus();

            comboBox.comboBox.DisplayMemberPath = "nombre";
            comboBox.comboBox.SelectedValuePath = "NacionalidadID";
            comboBox.comboBox.ItemsSource = A_Login.u.NacionalidadesRepository.GetAll();
            gridPass.Visibility = Visibility.Hidden;
        }


        /**************************************/
        //GRID BASE
        #region GridBase
        private void buttSig_Click(object sender, RoutedEventArgs e)
        {
            txt3Nick.textBox.BorderBrush = Brushes.Gray;
            if (!string.IsNullOrWhiteSpace(txt1Name.textBox.Text) && !string.IsNullOrWhiteSpace(txt2Apell.textBox.Text) && !string.IsNullOrWhiteSpace(txt3Nick.textBox.Text) && !string.IsNullOrWhiteSpace(txt4Email.textBox.Text) && !string.IsNullOrWhiteSpace(txt5Dir.textBox.Text) && !string.IsNullOrWhiteSpace(txt6Tlf.textBox.Text) && comboBox.comboBox.SelectedIndex != -1)
            {//Comprueba que se han rellenado los campos antes de proseguir
                //Creo un usuario con esos datos y lo valido
                #region CreaUser
                us.nombre = txt1Name.textBox.Text;
                us.apellidos = txt2Apell.textBox.Text;
                us.nick = txt3Nick.textBox.Text;
                us.Nacionalidad = (Nacionalidad)comboBox.comboBox.SelectedItem;
                //us.pass = passwordBox1.Password;
                us.direccion = txt5Dir.textBox.Text;
                us.email = txt4Email.textBox.Text;
                us.tlf = txt6Tlf.textBox.Text;
                #endregion
                if (A_Login.u.UsuariosRepository.Get(c => c.nick == us.nick).Count > 0)
                {//Significa que ya hay un usuario con ese nick
                    MessageBox.Show((string)A_Login.dict["RG_Msg2"]);//Nick ya registrado
                    txt3Nick.textBox.Text = "";
                    txt3Nick.textBox.Focus();
                    txt3Nick.textBox.BorderBrush = Brushes.Red;
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
                Console.WriteLine("1: " + txt1Name.textBox.Text);
                Console.WriteLine("2: " + txt2Apell.textBox.Text);
                Console.WriteLine("3: " + txt3Nick.textBox.Text);
                Console.WriteLine("4: " + txt4Email.textBox.Text);
                Console.WriteLine("5: " + txt5Dir.textBox.Text);
                Console.WriteLine("6: " + txt6Tlf.textBox.Text);
                Console.WriteLine("7: " + comboBox.comboBox.SelectedValue);
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
        private void passwordBox_HintPassBox_PassChanged(object sender, RoutedEventArgs e)
        {//A medida que el usuario teclea, le muestra si está cumpliendo los requisitos para la contraseña
            #region Checks
            //Mayúscula
            if (passwordBox1.passBox.Password.Any(c => char.IsUpper(c)))
            {check1.IsChecked = true;}
            else
            {check1.IsChecked = false;}
            //Minúscula
            if (passwordBox1.passBox.Password.Any(c => char.IsLower(c)))
            {check2.IsChecked = true;}
            else
            {check2.IsChecked = false;}
            //5 caracteres
            if (passwordBox1.passBox.Password.Length > 4)
            {check3.IsChecked = true;}
            else
            {check3.IsChecked = false;}
            //Número
            if (passwordBox1.passBox.Password.Any(c => char.IsNumber(c)))
            {check4.IsChecked = true;}
            else
            {check4.IsChecked = false;}
            //Coincidir
            if (passwordBox1.passBox.Password == passwordBox2.passBox.Password)
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
            A_Login.u.UsuariosRepository.Create(us);
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
            passwordBox1.passBox.Password = "";
            passwordBox2.passBox.Password = "";
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
            //A_Login.mw.textBox.Focus();
        }

        public void LoadHints()
        {
            txt1Name.hintTB.Text = (string)A_Login.dict["RGnombre"];
            txt1Name.textBox.MaxLength = 25;
            txt1Name.textBox.TabIndex = 1;
            txt2Apell.hintTB.Text = (string)A_Login.dict["RGapell"];
            txt2Apell.textBox.MaxLength = 25;
            txt2Apell.textBox.TabIndex = 2;
            txt3Nick.hintTB.Text = (string)A_Login.dict["RGnick"];
            txt3Nick.textBox.MaxLength = 25;
            txt3Nick.textBox.TabIndex = 3;
            comboBox.hintTB.Text = (string)A_Login.dict["RGnacion"];
            comboBox.keyHint = "RGnacion";
            comboBox.comboBox.TabIndex = 4;
            txt4Email.hintTB.Text = (string)A_Login.dict["RGemail"];
            txt4Email.textBox.TabIndex = 5;
            txt5Dir.hintTB.Text = (string)A_Login.dict["RGdir"];
            txt5Dir.textBox.TabIndex = 6;
            txt6Tlf.hintTB.Text = (string)A_Login.dict["RGtlf"];
            txt6Tlf.textBox.TabIndex = 7;
        }

        private void passwordBox1_HintPassBox_PassChanged(object sender, RoutedEventArgs e)
        {

        }

        private void passwordBox1_HintPassBox_PassChanged_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
