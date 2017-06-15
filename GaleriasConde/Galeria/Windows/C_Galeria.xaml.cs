using Galeria.Dict;
using Galeria.Model;
using Galeria.Other_Classes;
using Galeria.User_Controls;
using Galeria.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        CargarDiccionarios cd = new CargarDiccionarios();
        List<TypeVO> typesVO = new List<TypeVO>();

        public C_Galeria()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
                MessageBox.Show("Inner: " + ex.InnerException);
            }
            this.Name = "C_Galeria";
            cg = this;
            A_Login.windows.Add(cg);
            tbNick.Text = A_Login.user.nick;
            shadow.Visibility = Visibility.Hidden;
            
            Resources.MergedDictionaries.Add(A_Login.dict);
            LoadWindow();
            OnLangChange();
        }

        public void LoadWindow()//TODO: Añadir elementos de la pestaña Gestión
        {
            if (!Authorization(2))//Usuario registrado
            {
                Pst3.Width = 0;
            }
            if (!Authorization(3))//Admin
            {
                Pst4.Width = 0;
            }
            if (!Authorization(4))//Master
            {
                Pst5.Width = 0;
                sub_Users.Width = 0;
            }
            HideGrids();
        }
        
        public bool Authorization(int perfil)
        {
            if (A_Login.user.Profile.ProfileID >= perfil)
            {
                return true;
            }
            else return false;
        }

        void HideGrids()
        {//Oculta grids de Gestión
            sub_Users.Background = Brushes.LightSteelBlue;
            sub_Trans.Background = Brushes.LightSteelBlue;
            sub_Nats.Background = Brushes.LightSteelBlue;
            sub_Auths.Background = Brushes.LightSteelBlue;
            sub_Types.Background = Brushes.LightSteelBlue;
            sub_Arts.Background = Brushes.LightSteelBlue;

            sub_Users.Foreground = Brushes.Teal;
            sub_Trans.Foreground = Brushes.Teal;
            sub_Nats.Foreground = Brushes.Teal;
            sub_Auths.Foreground = Brushes.Teal;
            sub_Types.Foreground = Brushes.Teal;
            sub_Arts.Foreground = Brushes.Teal;

            gridUsers.Visibility = Visibility.Hidden;
            gridTrans.Visibility = Visibility.Hidden;
            gridNats.Visibility = Visibility.Hidden;
            gridAuths.Visibility = Visibility.Hidden;
            gridTypes.Visibility = Visibility.Hidden;
            gridArts.Visibility = Visibility.Hidden;
        }


        private void Window_Closing(object sender, EventArgs e)
        {//Cierra todas las demás ventanas, o lleva al menú principal
            var result = MessageBox.Show((string)A_Login.dict["UPMsg"], (string)A_Login.dict["UPCaption"], MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
                //Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            }
        }




        #region FilterPanel
        double ih;//Altura inicial
        double dh;//Desired Height (altura final)
        double desplazamiento;
        //Mostrar/Ocultar Panel
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
        //Evento Tick
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (hidenL)
            {
                if (MyScrollViewer.Margin.Left < 210)
                {
                    if (docky.Width < 200)
                    {
                        docky.Width = docky.Width + 10;
                        label.Width = label.Width + 10;
                        docky.Height = docky.Height + (desplazamiento / 13);
                    }
                    MyScrollViewer.Margin = new Thickness((MyScrollViewer.Margin.Left + 10), 10, 10, 10);
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
                if (MyScrollViewer.Margin.Left > 10)
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
                    if (MyScrollViewer.Margin.Left > 15)
                    {
                        MyScrollViewer.Margin = new Thickness((MyScrollViewer.Margin.Left - 15), 10, 10, 10);
                    }
                    else
                    {
                        MyScrollViewer.Margin = new Thickness((MyScrollViewer.Margin.Left - 5), 10, 10, 10);
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


        void LoadFilters()
        {
            spFilter.Children.Clear();

            //Añade un botón para mostrar todos
            Button b1 = new Button();
            b1.Name = "buttAll";
            b1.Content = (string)A_Login.dict["CG1AllFilter"];
            b1.Click += B1_Click;
            Style style = this.FindResource("filterAll") as Style;
            b1.Style = style;

            spFilter.Children.Add(b1);

            //Añade todos los tipos de obras
            foreach (Model.Type t in A_Login.u.TypesRep.GetAll())
            {
                Button b = new Button();
                b.Name = "butt" + t.TypeID;
                string lang = cd.GetCurrentLanguage();
                b.Content = A_Login.u.TypeTranslationsRep.Single(c => c.TypeID == t.TypeID && c.lang == lang).codType;
                b.Click += B_Click;
                style = this.FindResource("filterButtons") as Style;
                b.Style = style;

                spFilter.Children.Add(b);
            }
        }

        //Botón cargar todo
        private void B1_Click(object sender, RoutedEventArgs e)
        {
            List<ArtworkVO> aVOs = new List<ArtworkVO>();
            foreach (Artwork a in A_Login.u.ArtworksRep.GetAll())
            {
                aVOs.Add(new ArtworkVO(a.ArtworkID));
            }
            LoadArtworks(aVOs);
        }

        //Botón cargar Tipo de Obra
        private void B_Click(object sender, RoutedEventArgs e)
        {
            int typeIndex = int.Parse(Regex.Match(((sender as Button).Name), @"\d+").Value);
            List<ArtworkVO> aVOs = new List<ArtworkVO>();
            foreach (Artwork a in A_Login.u.ArtworksRep.Get(c=>c.Type.TypeID == typeIndex))
            {
                aVOs.Add(new ArtworkVO(a.ArtworkID));
            }
            LoadArtworks(aVOs);
        }
        #endregion

        #region Pst1Artworks
        void LoadArtworks(List<ArtworkVO> l)
        {//Cargar Obras
            awpArtworks.Children.Clear();
            foreach (ArtworkVO a in l)
            {//Crea para cada obra, un botón con la imagen de la Obra, y el título como Tooltip
                Button ObraBtn = new Button();
                ObraBtn.ToolTip = a.title;
                ObraBtn.MaxHeight = 250;
                ObraBtn.MaxWidth = 500;
                //ObraBtn.Padding = new Thickness(3);
                ObraBtn.Margin = new Thickness(2);

                Viewbox container = new Viewbox();
                //StackPanel container = new StackPanel();
                container.Margin = new Thickness(3,3,3,3);
                container.HorizontalAlignment = HorizontalAlignment.Left;
                container.VerticalAlignment = VerticalAlignment.Top;
                Image img = new Image();
                img.HorizontalAlignment = HorizontalAlignment.Center;
                img.Source = Converters.BytesToImg(a.img);
                img.Height = 300;
                container.Child = img;
                //container.Children.Add(img);
                ObraBtn.Content = container;

                ObraBtn.Name = "pButton" + a.ArtworkID.ToString();
                //TODO: ObraBtnClick
                //ObraBtn.Click += ObraBtn_Click;

                if (!checkOnStock.IsChecked)
                {
                    awpArtworks.Children.Add(ObraBtn);
                }
                else
                {//Sólo debe mostrar las que están disponibles
                    if (a.onStock)
                    {
                        awpArtworks.Children.Add(ObraBtn);
                    }
                }
            }
        }

        //Mientras escribe, voy buscando las obras para cargarlas
        //Si se alcanza un nº muy elevado de registros, quizás haga falta cambiar esto por un botón de búsqueda
        //Como no se espera alcanzar el caso, queda así para dejar más espacio al textBox
        private void txtSearchArt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string lang = cd.GetCurrentLanguage();
            HashSet<Artwork> artworks = A_Login.u.ArtworksRep.GetFiltrado(txtSearchArt.Text).ToHashSet();//HashSet para evitar repeticiones
            foreach (Model.Translation.ArtworkTranslations at in A_Login.u.ArtworkTranslationsRep.GetFiltrado(txtSearchArt.Text))
            {
                if (at.lang == lang)
                {//Si at está en el idioma en el que estamos buscando
                    artworks.Add(A_Login.u.ArtworksRep.Single(c => c.ArtworkID == at.ArtworkID));//Añado tambien el objeto Artwork
                }
            }

            List<ArtworkVO> aVOs = new List<ArtworkVO>();//Lista que voy a cargar
            foreach (Artwork a in artworks)
            {
                aVOs.Add(new ArtworkVO(a.ArtworkID));
            }
            LoadArtworks(aVOs);
        }
        #endregion



        //Método que se lanza al abrir ventana, y cada vez que se cambia de idioma
        public void OnLangChange()
        {
            LoadFilters();
            List<ArtworkVO> aVOs = new List<ArtworkVO>();
            foreach (Artwork a in A_Login.u.ArtworksRep.GetAll())
            {
                aVOs.Add(new ArtworkVO(a.ArtworkID));
            }
            LoadArtworks(aVOs);//Esto implica que al cambiar de idioma elimina los filtros, pero está bien así
            gridUsers.ReloadData();
            gridTrans.ReloadData();
            gridNats.ReloadData();
            gridAuths.ReloadData();
            gridTypes.ReloadData();
            gridArts.ReloadData();
        }
        
        //Botón que muestra el panel de usuario
        private void userButton_Click(object sender, RoutedEventArgs e)
        {
            shadow.Visibility = Visibility.Visible;
            UserPanel up = new UserPanel();
            up.VerticalAlignment = VerticalAlignment.Top;
            up.HorizontalAlignment = HorizontalAlignment.Right;
            up.Margin = new Thickness(0, 5, 5, 0);
            show.Children.Add(up);
        }
        private void shadow_MouseUp(object sender, MouseButtonEventArgs e)
        {//Cierra el panel, y oculta el grid shadow
            show.Children.Clear();
            shadow.Visibility = Visibility.Hidden;
        }
        private void overAllShadow_MouseUp(object sender, MouseButtonEventArgs e)
        {//Significa que esta ventana recupera el focus, cierra las otras (excepto A_Login)
            foreach (Window item in A_Login.windows)
            {
                if (item.Name != "A_Login" && item.Name != "C_Galeria")
                {
                    item.Close();
                }
            }
            overAllShadow.Visibility = Visibility.Hidden;
        }

        //Método cerrar App
        public void LogOut()
        {
            Close();
        }

        #region subMenus
        private void sub_Users_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Ocultar los demás grids, y recargar datagrid, hacer método con switch
            HideGrids();
            sub_Users.Background = Brushes.SlateBlue;
            sub_Users.Foreground = Brushes.OrangeRed;
            sub_Users.FontWeight = FontWeights.Black;
            sub_Users.FontStretch = FontStretches.Medium;
            gridUsers.Visibility = Visibility.Visible;
            gridUsers.dataGrid.SelectedIndex = -1;
        }

        private void sub_Trans_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HideGrids();
            sub_Trans.Background = Brushes.SlateBlue;
            sub_Trans.Foreground = Brushes.OrangeRed;
            sub_Trans.FontWeight = FontWeights.Black;
            sub_Trans.FontStretch = FontStretches.Medium;
            gridTrans.Visibility = Visibility.Visible;
            gridTrans.dataGrid.SelectedIndex = -1;
        }

        private void sub_Nats_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HideGrids();
            sub_Nats.Background = Brushes.SlateBlue;
            sub_Nats.Foreground = Brushes.OrangeRed;
            sub_Nats.FontWeight = FontWeights.Black;
            sub_Nats.FontStretch = FontStretches.Medium;
            gridNats.Visibility = Visibility.Visible;
            gridNats.dataGrid.SelectedIndex = -1;
        }

        private void sub_Auths_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HideGrids();
            sub_Auths.Background = Brushes.SlateBlue;
            sub_Auths.Foreground = Brushes.OrangeRed;
            sub_Auths.FontWeight = FontWeights.Black;
            sub_Auths.FontStretch = FontStretches.Medium;
            gridAuths.Visibility = Visibility.Visible;
            gridAuths.dataGrid.SelectedIndex = -1;
        }

        private void sub_Types_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HideGrids();
            sub_Types.Background = Brushes.SlateBlue;
            sub_Types.Foreground = Brushes.OrangeRed;
            sub_Types.FontWeight = FontWeights.Black;
            sub_Types.FontStretch = FontStretches.Medium;
            gridTypes.Visibility = Visibility.Visible;
            gridTypes.dataGrid.SelectedIndex = -1;
        }

        private void sub_Arts_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HideGrids();
            sub_Arts.Background = Brushes.SlateBlue;
            sub_Arts.Foreground = Brushes.OrangeRed;
            sub_Arts.FontWeight = FontWeights.Black;
            sub_Arts.FontStretch = FontStretches.Medium;
            gridArts.Visibility = Visibility.Visible;
            gridArts.dataGrid.SelectedIndex = -1;
        }
        #endregion

    }
}
