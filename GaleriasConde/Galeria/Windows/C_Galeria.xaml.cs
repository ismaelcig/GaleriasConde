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
            LoadArtworks();
            
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
        double ih;//Altura inicial
        double dh;//Desired Height (altura final)
        double desplazamiento;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!hidenL)
            {
                ih = ActualHeight - 101;
                dh = 40;
            }
            else
            {
                ih = 40;
                dh = ActualHeight - 101;

            }
            desplazamiento = dh - ih;
            docky.Height = docky.ActualHeight;

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
                    label.Width = label.Width + 10;
                    //docky.Height = docky.Height + ah;
                    docky.Height = docky.Height + (desplazamiento / 13);
                }
                else
                {//Termina de ampliar
                    hidenL = false;
                    button.IsEnabled = true;
                    button.Content = "<-";
                    docky.Height = Double.NaN;
                    docky.VerticalAlignment = VerticalAlignment.Stretch;
                    dispatcherTimer.Stop();
                }
            }
            else
            {
                if (docky.Width > button.Width)
                {
                    docky.Width = docky.Width - 10;
                    label.Width = label.Width - 10;
                    docky.VerticalAlignment = VerticalAlignment.Top;
                    if (docky.Height > 40)
                    {
                        docky.Height = docky.Height + (desplazamiento / 13);
                    }
                    
                }
                else
                {//Termina de minimizar
                    docky.Height = 40;//por si acaso con alguna resolución da problema
                    hidenL = true;
                    button.IsEnabled = true;
                    button.Content = "->";
                    dispatcherTimer.Stop();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Actdocky=" + docky.ActualHeight);
            Console.WriteLine("docky=" + docky.Height);
            Console.WriteLine("spFilter=" + spFilter.ActualHeight);
            Console.WriteLine("button1=" + button1.ActualHeight);
            docky.Height = 40;
        }
    }
}
