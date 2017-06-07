using Galeria.Dict;
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
            InitializeComponent();
            this.Name = "C_Galeria";
            cg = this;
            A_Login.windows.Add(cg);
            tbNick.Text = A_Login.user.nick;
            shadow.Visibility = Visibility.Hidden;
            
            Resources.MergedDictionaries.Add(A_Login.dict);
            LoadWindow();
            LoadArtworks(ArtworkVO.GetArtworksVO());
            LoadFilters();
            dataGridUser.ItemsSource = A_Login.u.UsersRep.GetAll();
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
            HideGrids();
        }
        
        public bool Permisos(int perfil)
        {
            if (A_Login.user.Profile.ProfileID >= perfil)
            {
                return true;
            }
            else return false;
        }

        void HideGrids()
        {//TODO: Añadir todos los grids de gestión
            gridUsers.Visibility = Visibility.Hidden;

        }


        private void Window_Closing(object sender, EventArgs e)
        {//TODO: No volver a abrir login, sino cerrar todo, no permitir cerrar si hay algo abierto (?)
            A_Login.mw.Close();
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
                if (awpArtworks.Margin.Left < 210)
                {
                    if (docky.Width < 200)
                    {
                        docky.Width = docky.Width + 10;
                        label.Width = label.Width + 10;
                        docky.Height = docky.Height + (desplazamiento / 13);
                    }
                    awpArtworks.Margin = new Thickness((awpArtworks.Margin.Left + 10), 10, 10, 10);
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
                if (awpArtworks.Margin.Left > 10)
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
                    if (awpArtworks.Margin.Left > 15)
                    {
                        awpArtworks.Margin = new Thickness((awpArtworks.Margin.Left - 15), 10, 10, 10);
                    }
                    else
                    {
                        awpArtworks.Margin = new Thickness((awpArtworks.Margin.Left - 5), 10, 10, 10);
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
            b1.Margin = new Thickness(5, 5, 5, 5);
            b1.Click += B1_Click;
            b1.Background = Brushes.LightSkyBlue;
            var converter1 = new BrushConverter();
            var brush1 = (Brush)converter1.ConvertFromString("#FF7ABAE2");
            b1.BorderBrush = brush1;

            spFilter.Children.Add(b1);

            //Añade todos los tipos de obras
            foreach (Model.Type t in A_Login.u.TypesRep.GetAll())
            {//No hace falta TypeVO, porque se puede hacer directamente
                //TypeVO tVO = new TypeVO();
                //tVO.TypeID = t.TypeID;
                //string lang = cd.GetCurrentLanguage();
                //tVO.codType = A_Login.u.TypeTranslationsRep.Single(c => c.TypeID == t.TypeID && c.lang == lang).codType;
                //typesVO.Add(tVO);

                Button b = new Button();
                b.Name = "butt" + t.TypeID;
                string lang = cd.GetCurrentLanguage();
                b.Content = A_Login.u.TypeTranslationsRep.Single(c => c.TypeID == t.TypeID && c.lang == lang).codType;
                b.Margin = new Thickness(5);
                b.Click += B_Click;
                b.Background = Brushes.LightBlue;
                var converter = new BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#FF8CBBD8");
                b.BorderBrush = brush;

                spFilter.Children.Add(b);
            }
        }

        //Botón cargar todo
        private void B1_Click(object sender, RoutedEventArgs e)
        {
            LoadArtworks(ArtworkVO.GetArtworksVO());
            //TODO: Cargar Autores
        }

        //Botón cargar Tipo de Obra
        private void B_Click(object sender, RoutedEventArgs e)
        {
            int typeIndex = int.Parse(Regex.Match(((sender as Button).Name), @"\d+").Value);
            LoadArtworks(ArtworkVO.GetArtworksVO(typeIndex));
        }
        #endregion

        #region Pst1Artworks
        void LoadArtworks(List<ArtworkVO> l)
        {//Cargar Obras
            awpArtworks.Children.Clear();
            foreach (ArtworkVO a in l)
            {//TODO: Crea para cada obra, un botón con la imagen de la Obra, y el título como Tooltip
                Button ObraBtn = new Button();
                ObraBtn.ToolTip = a.title;
                ObraBtn.Content = a.title;
                ObraBtn.Name = "pButton" + a.ArtworkID.ToString();
                //ObraBtn.Height = 200;
                ObraBtn.Padding = new Thickness(3);
                ObraBtn.Margin = new Thickness(2);

                //ObraBtn.Click += ObraBtn_Click;

                awpArtworks.Children.Add(ObraBtn);
            }
        }
        #endregion

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    Console.WriteLine("Actdocky=" + docky.ActualHeight);
        //    Console.WriteLine("docky=" + docky.Height);
        //    Console.WriteLine("spFilter=" + spFilter.ActualHeight);
        //    Console.WriteLine("button1=" + button1.ActualHeight);
        //    docky.Height = 40;
        //}



        //Método que se lanza al abrir ventana, y cada vez que se cambia de idioma
        public void OnLangChange()
        {
            LoadFilters();
            LoadArtworks(ArtworkVO.GetArtworksVO());//Esto implica que al cambiar de idioma elimina los filtros, pero está bien así
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
        
        //Método cerrar App
        public void LogOut()
        {
            var result = MessageBox.Show((string)A_Login.dict["UPMsg"], (string)A_Login.dict["UPCaption"], MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                A_Login.mw.Close();
                Close();
            }
        }



        #region Management
        private void sub_Users_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //TODO: Ocultar los demás grids, y recargar datagrid, hacer método con switch
            gridUsers.Visibility = Visibility.Visible;
        }


        #endregion
    }
}
