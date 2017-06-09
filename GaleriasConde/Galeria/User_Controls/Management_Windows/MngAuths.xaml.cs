using Galeria.Dict;
using Galeria.Model;
using Galeria.VO;
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

namespace Galeria.User_Controls.Management_Windows
{
    /// <summary>
    /// Interaction logic for MngAuths.xaml
    /// </summary>
    public partial class MngAuths : UserControl
    {
        CargarDiccionarios cd = new CargarDiccionarios();
        AuthorVO obj = new AuthorVO();
        List<AuthorVO> VOs = new List<AuthorVO>();
        public MngAuths()
        {
            InitializeComponent();
            ReloadData();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (dataGrid.SelectedIndex > -1)
            //{
            //    obj = new NationalityVO();
            //    obj = (NationalityVO)dataGrid.SelectedItem;
            //    txtID.Text = obj.NationalityID.ToString();
            //    txtNac.Text = obj.codNation;//Muestra el cod en el idioma de la aplicación


            //    buttMod.IsEnabled = true;
            //    buttDel.IsEnabled = true;
            //}
            //else
            //{
            //    buttMod.IsEnabled = false;
            //    buttDel.IsEnabled = false;

            //    txtID.Text = "";
            //    txtNac.Text = "";
            //    ReloadData();
            //}
        }

        private void buttAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttMod_Click(object sender, RoutedEventArgs e)
        {

        }

        public void ReloadData()
        {//Carga elementos VO en el dataGrid
            dataGrid.ItemsSource = null;
            foreach (Author item in A_Login.u.AuthorsRep.GetAll())
            {
                VOs.Add(AuthorConverter.toVO(item));
            }
            dataGrid.ItemsSource = VOs;
        }
    }
}
