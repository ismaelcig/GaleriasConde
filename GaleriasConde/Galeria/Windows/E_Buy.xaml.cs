using Galeria.Model;
using Galeria.Other_Classes;
using Galeria.User_Controls;
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
    public partial class E_Buy : Elysium.Controls.Window
    {
        AuthorVO authorVO = new AuthorVO();
        ArtworkVO artVO;
        public E_Buy()
        {
            InitializeComponent();
        }

        public E_Buy(ArtworkVO artworkVO)
        {
            InitializeComponent();
            try
            {
                this.Name = "E_Buy";
                A_Login.windows.Add(this);
                Resources.MergedDictionaries.Add(A_Login.dict);
                
                image.Source = Converters.BytesToImg(artworkVO.img);
                lblName.Content += artworkVO.title;
                bAuth.Content = artworkVO.authorVO.artName;
                authorVO = artworkVO.authorVO;
                artVO = artworkVO;
                lblDate.Content += artworkVO.date;
                lblDim.Content += artworkVO.dimensions;
                descr.Text = artworkVO.info;
                checkBox.IsChecked = artworkVO.onStock;
                bBuy.IsEnabled = artworkVO.onStock;

                //Colocar Interfaz
                lbl1.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                Size s = lbl1.DesiredSize;
                lblName.Margin = new Thickness(s.Width, 10, 0, 0);
                lbl2.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                s = lbl2.DesiredSize;
                bAuth.Margin = new Thickness(s.Width, 41, 0, 0);
                lbl3.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                s = lbl3.DesiredSize;
                lblDate.Margin = new Thickness(s.Width, 76, 0, 0);
                lbl4.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                s = lbl4.DesiredSize;
                lblDim.Margin = new Thickness(s.Width, 109, 0, 0);
            }
            catch (Exception ex)
            {
                ErrorLog.SilentLog("BuyInit", ex);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            C_Galeria.cg.overAllShadow.Visibility = Visibility.Hidden;
            C_Galeria.cg.Show();
        }

        private void bAuth_Click(object sender, RoutedEventArgs e)
        {
            shadow.Visibility = Visibility.Visible;
            AuthorControl ac = new AuthorControl(authorVO);
            show.Children.Add(ac);
        }

        private void shadow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            show.Children.Clear();
            shadow.Visibility = Visibility.Hidden;
        }

        private void bBuy_Click(object sender, RoutedEventArgs e)
        {
            string msg = (string)A_Login.dict["B_Msg1"] + " " + artVO.money + (string)A_Login.dict["B_Msg2"];
            var result = MessageBox.Show(msg, (string)A_Login.dict["UPCaption"], MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Transaction t = new Transaction();
                    Artwork a = A_Login.u.ArtworksRep.Single(c => c.ArtworkID == artVO.ArtworkID);
                    a.onStock = false;
                    t.Artwork = a;
                    t.comment = "Transacción generada automáticamente";//Este comentario siempre aparece en español
                    t.done = true;
                    t.money = artVO.money;
                    t.User = A_Login.user;
                    t.venta = true;
                    A_Login.u.TransactionsRep.Create(t);



                    MessageBox.Show((string)A_Login.dict["B_Msg3"]);
                    Close();
                }
                catch (Exception ex)
                {
                    ErrorLog.Log("Buy", ex);
                }
            }
        }
    }
}
