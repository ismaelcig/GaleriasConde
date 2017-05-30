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
        public static C_Galeria CGaleria;
        public C_Galeria()
        {
            InitializeComponent();
            CGaleria = this;
            
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
    }
}
