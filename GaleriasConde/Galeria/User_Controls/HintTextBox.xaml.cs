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
    /// Interaction logic for HintTextBox.xaml
    /// </summary>
    public partial class HintTextBox : UserControl
    {
        public HintTextBox()
        {
            InitializeComponent();

        }
        public static DependencyProperty TxtBoxValueProperty = DependencyProperty.Register("TxtBoxValue", typeof(string), typeof(HintTextBox));

        public string TxtBoxValue
        {
            get { return (string)GetValue(TxtBoxValueProperty); }
            set
            {
                SetValue(TxtBoxValueProperty, value);
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox.Text == "")
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
