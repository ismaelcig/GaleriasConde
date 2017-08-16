using Galeria.Other_Classes;
using Galeria.VO;
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
    /// Lógica de interacción para AuthorControl.xaml
    /// </summary>
    public partial class AuthorControl : UserControl
    {
        public AuthorControl()
        {
            InitializeComponent();
        }

        public AuthorControl(AuthorVO author)
        {
            InitializeComponent();
            try
            {
                lblName.Content = author.realName;
                lblArtName.Content = author.artName;
                tbDescr.Text = author.description;
            }
            catch (Exception ex)
            {
                ErrorLog.SilentLog("AuthContrInit", ex);
            }
        }
    }
}
