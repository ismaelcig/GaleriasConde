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
    /// Interaction logic for HintPassBox.xaml
    /// </summary>
    public partial class HintPassBox : UserControl
    {
        public HintPassBox()
        {
            InitializeComponent();
        }


        /*
        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Hint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register("Hint", typeof(string), typeof(HintPassBox), new PropertyMetadata(0));
        */
        public event RoutedEventHandler HintPassBox_PassChanged;
        void HintPassBox_PassChangedHandler(object sender, RoutedEventArgs args)
        {
            RoutedEventHandler handler = HintPassBox_PassChanged;
            if (handler != null)
                handler.Invoke(this, args);
        }
        //protected virtual void OnHintPassBox_PassChanged(RoutedEventArgs e)//object sender, RoutedEventArgs e
        //{
        //    EventHandler handler = ThresholdReached;
        //    if (handler != null)
        //    {
        //        handler(this, e);
        //    }
        //}

        private void passBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passBox.Password == "")
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
