using Galeria.Model;
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
using System.Windows.Shapes;

namespace Galeria.Windows
{
    /// <summary>
    /// Lógica de interacción para E_Buy.xaml
    /// </summary>
    public partial class E_Buy : Window
    {
        AuthorVO authorVO = new AuthorVO();
        public E_Buy()
        {
            InitializeComponent();
        }

        public E_Buy(ArtworkVO artworkVO)
        {
            InitializeComponent();
            image.Source = Converters.BytesToImg(artworkVO.img);
            lblName.Content += artworkVO.title;
            button1.Content = artworkVO.authorVO.artName;
            authorVO = artworkVO.authorVO;
            lblDate.Content += artworkVO.date;
            lblDim.Content += artworkVO.dimensions;
            descr.Text = artworkVO.info;
            checkBox.IsChecked = artworkVO.onStock;
            button.IsEnabled = artworkVO.onStock;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Mostrar Autor
        }
    }
}
