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
    /// Interaction logic for C_Galeria.xaml
    /// </summary>
    public partial class C_Galeria : Elysium.Controls.Window
    {
        public static C_Galeria cg;
        bool hidenL = false;
        System.Windows.Threading.DispatcherTimer dispatcherTimer;

        public C_Galeria()
        {
            InitializeComponent();
            this.Name = "C_Galeria";
            cg = this;
            A_Login.windows.Add(cg);
            
            Resources.MergedDictionaries.Add(A_Login.dict);
            LoadWindow();
            
        }

        public void LoadWindow()
        {
            if (!Permisos(2))
            {
                Pst3.Width = 0;
            }
            if (!Permisos(3))
            {
                Pst4.Width = 0;
            }
            if (!Permisos(4))
            {
                Pst5.Width = 0;
            }

        }
        
        public bool Permisos(int perfil)
        {
            if (A_Login.user.Profile.ProfileID >= perfil)
            {
                return true;
            }
            else return false;
        }



        private void Window_Closed(object sender, EventArgs e)
        {//TODO: No volver a abrir login, sino cerrar todo, no permitir cerrar si hay algo abierto (?)
            //A_Login.mw.Show();
            A_Login.mw.Close();
            Close();
        }

        
    



        void LoadArtworks()
        {//Cargar Obras

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            button.IsEnabled = false;
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (hidenL)
            {
                if (docky.Width < 200)
                {
                    docky.Width = docky.Width + 10;
                }
                else
                {
                    hidenL = false;
                    button.IsEnabled = true;
                    button.Content = "<-";
                    dispatcherTimer.Stop();
                }
            }
            else
            {
                if (docky.Width > button.Width)
                {
                    docky.Width = docky.Width - 10;
                }
                else
                {
                    hidenL = true;
                    button.IsEnabled = true;
                    button.Content = "->";
                    dispatcherTimer.Stop();
                }
            }
        }
    }
}
