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
    /// Interaction logic for HintComboBox.xaml
    /// </summary>
    public partial class HintComboBox : UserControl
    {
        public string keyHint;
        public HintComboBox()
        {
            InitializeComponent();


        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex == -1)
            {
                hintTB.Visibility = Visibility.Visible;
            }
            else
            {
                hintTB.Visibility = Visibility.Hidden;
            }
        }
    }
}
