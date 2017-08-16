using Galeria.Dict;
using Galeria.Model;
using Galeria.Other_Classes;
using Galeria.User_Controls;
using Galeria.User_Controls.Messages_Window;
using Galeria.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Galeria.Windows
{
    /// <summary>
    /// Interaction logic for C_Galeria.xaml
    /// </summary>
    public partial class C_Galeria : Elysium.Controls.Window
    {
        public static C_Galeria cg;
        bool hidenL = false;
        DispatcherTimer dispatcherTimer;
        CargarDiccionarios cd = new CargarDiccionarios();
        List<TypeVO> typesVO = new List<TypeVO>();
        //List<Chat> chats = new List<Chat>();//Lista de Chats del Usuario
        public Chat selectedChat;
        List<Message> lastMsgs = new List<Message>();
        public static List<Chat> chatsUser;

        DispatcherTimer timerChats = new DispatcherTimer();//Timer para actualizar cada poco los mensajes

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
        }

        

        void InitializeChats()
        {
            chatsUser = new List<Chat>();//Guardo en una lista los chats del usuario
            foreach (Chat item in A_Login.u.ChatsRep.GetAll())
            {
                foreach (User item2 in item.users)
                {
                    if (item2.nick == A_Login.user.nick)
                    {
                        chatsUser.Add(item);
                    }
                }
            }
            foreach (Chat item in chatsUser)
            {
                if (item.messages.Count > 0)
                {
                    lastMsgs.Add(item.messages.Last());//Guardo todos los últimos mensajes de los chats de este user
                }
                ChatControl cc = new ChatControl(item);//Creo un ChatControl por cada chat
                cc.Name = "cc_" + item.ChatID;//Uso el id del chat como nombre para el control
                cc.Margin = new Thickness(3, 3, 0, 0);
                spChat.Children.Add(cc);
            }
            //Cada x segundos actualiza los mensajes
            timerChats = new DispatcherTimer();
            timerChats.Tick += TimerChats_Tick;
            timerChats.Interval = new TimeSpan(0, 0, 0, 3);//TODO: Controlar tiempo
            timerChats.Start();
        }

        private void TimerChats_Tick(object sender, EventArgs e)//Recarga Chats si hay msgs nuevos
        {
            try
            {
                foreach (Chat item in chatsUser)
                {
                    List<Message> aux = lastMsgs.Where(c => c.Chat.ChatID == item.ChatID).ToList();
                    if (aux.Count() > 0)
                    {//Comprueba si hay algún mensaje de este chat en lastMsgs
                        if (lastMsgs.Single(c => c.Chat.ChatID == item.ChatID).MessageID != item.messages.Last().MessageID)
                        {//Si el último msg de este chat en la app != último msg de este chat en BD => ACTUALIZA ESE CHAT
                            lastMsgs.Remove(lastMsgs.Single(c => c.Chat.ChatID == item.ChatID));
                            lastMsgs.Add(item.messages.Last());//Actualiza el último msg de este chat en la lista

                            foreach (ChatControl element in spChat.Children)
                            {
                                if (element.Name == ("cc_" + item.ChatID))
                                {
                                    spChat.Children.Remove(element);
                                    break;
                                }
                            }
                            ChatControl cc = new ChatControl(item);//Añado el nuevo
                            cc.Name = "cc_" + item.ChatID;
                            cc.Margin = new Thickness(3, 3, 0, 0);
                            spChat.Children.Insert(0, cc);
                            chatView.LoadChatView(selectedChat);
                        }
                    }
                    else
                    {
                        if (item.messages.Count > 0)
                        {//Comprueba si hay algún mensaje de este chat en la BD
                            lastMsgs.Add(item.messages.Last());//Actualiza el último msg de este chat en la lista

                            foreach (ChatControl element in spChat.Children)
                            {
                                if (element.Name == ("cc_" + item.ChatID))
                                {
                                    spChat.Children.Remove(element);
                                    break;
                                }
                            }
                            ChatControl cc = new ChatControl(item);//Añado el nuevo
                            cc.Name = "cc_" + item.ChatID;
                            cc.Margin = new Thickness(3, 3, 0, 0);
                            spChat.Children.Insert(0, cc);
                            chatView.LoadChatView(selectedChat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.SilentLog("Tick", ex);
            }
        }

        public void LoadWindow()
        {
            //Inicialmente carga todas las obras disponibles
            List<ArtworkVO> aVOs = new List<ArtworkVO>();
            foreach (Artwork a in A_Login.u.ArtworksRep.GetAll())
            {
                aVOs.Add(new ArtworkVO(a.ArtworkID));
            }
            LoadArtworks(aVOs);
            //Carga los filtros
            LoadFilters();


            //Limita acceso según los permisos
            if (A_Login.user.Profile.ProfileID == 1)//Usuario no registrado
            {
                Pst2.Visibility = Visibility.Hidden;//Subasta
                Pst3.Visibility = Visibility.Hidden;//Mensajes
                Pst4.Visibility = Visibility.Hidden;//Gestión
                sellButton.Visibility = Visibility.Hidden;//Botón Venta
            }
            else if (A_Login.user.Profile.ProfileID == 2)//Usuario registrado
            {
                Pst4.Visibility = Visibility.Hidden;//Gestión
                InitializeChats();
            }
            else if (A_Login.user.Profile.ProfileID == 3)//Admin
            {
                sub_Users.Width = 0;//Gestión Usuarios
                sub_Users.Margin = new Thickness(0);
                InitializeChats();
                HideGrids();
            }
            else if (A_Login.user.Profile.ProfileID == 4)//Master
            {
                InitializeChats();
                HideGrids();
            }
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
            var result = MessageBox.Show((string)A_Login.dict["UPMsg"], (string)A_Login.dict["UPCaption"], MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                A_Login.mw.Show();
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
                ObraBtn.Click += ObraBtn_Click;

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

        private void ObraBtn_Click(object sender, RoutedEventArgs e)
        {
            if (A_Login.user.Profile.ProfileID == 1)
            {
                MessageBox.Show((string)A_Login.dict["CG1_Msg1"]);//Debes estar registrado
            }
            else
            {
                int indexObra = int.Parse(Regex.Match(((sender as Button).Name), @"\d+").Value);
                E_Buy eb = new E_Buy(new ArtworkVO(indexObra));
                A_Login.windows.Add(eb);
                eb.Show();
                overAllShadow.Visibility = Visibility.Visible;
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



        //Método que se lanza cada vez que se cambia de idioma
        public void OnLangChange()
        {
            LoadWindow();
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
            gridUsers.ReloadData();
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
            //gridTrans.comboBox.SelectedIndex = 0;
            gridTrans.comboBox.SelectedIndex = -1;
            gridTrans.ReloadData();
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
            gridNats.ReloadData();
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
            gridAuths.ReloadData();
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
            gridTypes.ReloadData();
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
            gridArts.ReloadData();
        }
        #endregion

        private void sellButton_Click(object sender, RoutedEventArgs e)
        {
            E_Sell es = new E_Sell();
            A_Login.windows.Add(es);
            es.Show();
            overAllShadow.Visibility = Visibility.Visible;
        }

        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {//Artworks
            //arga todas las obras disponibles
            List<ArtworkVO> aVOs = new List<ArtworkVO>();
            foreach (Artwork a in A_Login.u.ArtworksRep.GetAll())
            {
                aVOs.Add(new ArtworkVO(a.ArtworkID));
            }
            LoadArtworks(aVOs);
            //Carga los filtros
            LoadFilters();
        }

        private void Label_MouseDown_2(object sender, MouseButtonEventArgs e)
        {//Subastas
            //Delegados
            de = new DelegadoEstado(ActualizarEstado);
            dt = new DelegadoTitulo(ActualizarTitulo);
            di = new DelegadoImg(ActualizarImg);
            dp = new DelegadoPuja(enPuja);
            dl = new DelegadoLabel(AddLabel);

            //Comienza con la interfaz bloqueada
            pujaActiva = false;
            enPuja();
        }

        private void Label_MouseDown_3(object sender, MouseButtonEventArgs e)
        {//Mensajes
            
        }

        private void Label_MouseDown_4(object sender, MouseButtonEventArgs e)
        {//Gestión

        }
        
        private void Label_MouseDown_5(object sender, MouseButtonEventArgs e)
        {//Informes

        }


        #region Subastas

        #region Declaraciones
        TcpClient client;
        NetworkStream ns;
        StreamReader sr;
        StreamWriter sw;
        string dato;

        TcpListener newsock;
        int puertoEscucha;

        string strEstado = (string)A_Login.dict["E1"];
        string strLbl;
        string strTitulo = "";
        byte[] arrayImg;
        delegate void DelegadoEstado();
        DelegadoEstado de;
        delegate void DelegadoTitulo();
        DelegadoTitulo dt;
        delegate void DelegadoImg();
        DelegadoImg di;
        delegate void DelegadoPuja();
        DelegadoPuja dp;
        delegate void DelegadoLabel();
        DelegadoLabel dl;

        public bool pujaActiva;

        int contLBL = 0;

        ArtworkVO aVO;
        #endregion

        #region InterfazPuja
        bool hiddenPuja = false;
        DispatcherTimer dispatcherTimer1;

        private void buttPuja_Click(object sender, RoutedEventArgs e)
        {
            EnviaPuja();
        }
        
        private void txtPuja_KeyDown(object sender, KeyEventArgs e)
        {//Presionar Enter = pulsar botón Pujar
            if (e.Key == Key.Enter)
            {
                EnviaPuja();
            }
        }

        private void txtPuja_TextChanged(object sender, TextChangedEventArgs e)
        {//Comprobar
            Regex regex = new Regex("[^0-9]");
            if (regex.IsMatch(txtPuja.Text))
            {//Hay letras/símbolos
                txtPuja.Text = "";
                MessageBox.Show((string)A_Login.dict["CG2_Msg1"]);
            }
        }

        double ih1;//Altura inicial
        double dh1;//Desired Height (altura final)
        double desplazamiento1;
        //Mostrar/Ocultar Panel
        private void imgPuja_MouseDown(object sender, RoutedEventArgs e)
        {
            if (!hiddenPuja)
            {
                ih1 = 90;
                dh1 = 10;
            }
            else
            {
                ih1 = 10;
                dh1 = 90;

            }
            desplazamiento1 = dh1 - ih1;
            borderPuja.Height = borderPuja.ActualHeight;

            imgPuja.IsEnabled = false;
            dispatcherTimer1 = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer1.Tick += DispatcherTimer1_Tick;
            dispatcherTimer1.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer1.Start();
        }
        //Evento Tick
        private void DispatcherTimer1_Tick(object sender, EventArgs e)
        {
            if (hiddenPuja)
            {
                if (borderPuja.ActualHeight < 90)
                {
                    borderPuja.Height = borderPuja.Height + 10;
                    borderPuja.Width = borderPuja.Width + 20;

                }
                else
                {//Termina de ampliar
                    hiddenPuja = false;
                    imgPuja.IsEnabled = true;
                    imgPuja.Source = (ImageSource)FindResource("minimize");
                    txtPuja.Visibility = Visibility.Visible;

                    borderPuja.Height = 90;
                    borderPuja.Width = 200;
                    dispatcherTimer1.Stop();
                }
            }
            else
            {
                if (borderPuja.ActualHeight > 10)
                {
                    borderPuja.Height = borderPuja.Height - 10;
                    borderPuja.Width = borderPuja.Width - 20;
                    txtPuja.Visibility = Visibility.Hidden;
                }
                else
                {//Termina de reducir
                    hiddenPuja = true;
                    imgPuja.IsEnabled = true;
                    imgPuja.Source = (ImageSource)FindResource("expand");

                    borderPuja.Height = 10;
                    borderPuja.Width = 10;
                    dispatcherTimer1.Stop();
                }
            }
        }
        #endregion



        private void tryConnect_Click(object sender, RoutedEventArgs e)
        {
            Conectar("127.0.0.1");
        }

        #region MetodosInterfaz
        private void ActualizarEstado()
        {
            lblEstado.Content = strEstado;
        }
        private void ActualizarTitulo()
        {
            lblObra.Content = strTitulo;
        }
        private void ActualizarImg()
        {
            image.Source = Converters.BytesToImg(arrayImg);
        }
        //  Activa / Desactiva la interfaz
        void enPuja()
        {
            buttPuja.IsEnabled = pujaActiva;
            txtPuja.IsEnabled = pujaActiva;
            if (pujaActiva)
            {
                txtPuja.Focus();
            }
        }
        //Añade una Label al historial
        private void AddLabel()
        {//Añade el estado anterior al historial
            Label l = new Label();

            //Esto sirve para que el mensaje pueda leerse en el espacio que tiene en la interfaz
            l.Content = "";
            foreach (string item in Loaders.AdjustLblLenght(strLbl, 39))
            {
                l.Content += item + Environment.NewLine;
            }
            l.Name = "lbl" + contLBL;
            contLBL++;

            spHist.Children.Add(l);
            scrollViewer.ScrollToBottom();
        }
        #endregion

        #region MetodosSubastas
        //Intenta conectar con el Server
        public void Conectar(string ip)
        {
            try
            {
                client = new TcpClient(ip, 2000);
                ns = client.GetStream();
                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);

                strEstado = (string)A_Login.dict["E2"];
                Dispatcher.BeginInvoke(de);
                closedServer.Visibility = Visibility.Hidden;
                Acceder();
            }
            catch (Exception ex)
            {
                ErrorLog.Log("ConnectServer", ex);
                strEstado = (string)A_Login.dict["E3"];
                Dispatcher.BeginInvoke(de);
            }
        }

        //Si conecta, envía un mensaje para acceder, y se queda a la escucha
        public void Acceder()
        {//"-ACCEDER-ID-puertoEscucha-dinero_disponible-"
            puertoEscucha = 2000 + A_Login.user.UserID;
            sw.WriteLine("-ACCEDER-" + A_Login.user.UserID + "-" + puertoEscucha + "-");//Eliminado dineroDisponible
            sw.Flush();
            //dato = sr.ReadLine();
            dato = sr.ReadLine() + Environment.NewLine +
            sr.ReadLine() + Environment.NewLine +
            sr.ReadLine() + Environment.NewLine +
            sr.ReadLine() + Environment.NewLine +
            sr.ReadLine();

            Console.WriteLine("C# Dato from server:\r " + dato);

            strEstado = (string)A_Login.dict["E4"];
            Dispatcher.BeginInvoke(de);

            //Abrir thread escucha
            Thread t = new Thread(this.Escucha);
            t.IsBackground = true;
            t.Start();
        }

        private void Escucha()
        {
            newsock = new TcpListener(IPAddress.Any, puertoEscucha);
            newsock.Start();

            while (true)
            {
                try
                {
                    TcpClient client = newsock.AcceptTcpClient();
                    NetworkStream ns = client.GetStream();
                    StreamReader sr = new StreamReader(ns);
                    StreamWriter sw = new StreamWriter(ns);

                    dato = sr.ReadLine();
                    Console.WriteLine("C# Dato from Server: " + dato);
                    //#OBRA#1#6000#
                    /************************************************************************************/

                    if (dato.Contains('#'))
                    {
                        string[] subdatos = dato.Split('#');
                        // #OBRA#obraID#dinero#
                        #region Obra
                        if (subdatos[1].ToUpper() == "OBRA")
                        {
                            //subdatos[2] = ID
                            //subdatos[3] = PujaInicial

                            //Get Obra
                            aVO = new ArtworkVO();
                            int id = Convert.ToInt32(subdatos[2]);
                            aVO = new ArtworkVO(id);
                            //Muestra título
                            strTitulo = aVO.title;
                            Dispatcher.BeginInvoke(dt);
                            //Muestra imagen
                            image.Source = Converters.BytesToImg(arrayImg);
                            Dispatcher.BeginInvoke(di);
                            //Muestra estado (puja inicial)
                            strEstado = (string)A_Login.dict["E5"] + " " + subdatos[3] + "€";
                            Dispatcher.BeginInvoke(de);
                            //Permite enviar puja
                            pujaActiva = true;
                            Dispatcher.BeginInvoke(dp);
                            //Añade el estado al historial
                            strLbl = (string)A_Login.dict["E6"]+ " \"" + aVO.title + "\" " + (string)A_Login.dict["E7"] + subdatos[3] + "€.";
                            Dispatcher.BeginInvoke(dl);
                        }
                        #endregion

                        // #PUJAMAX#nombre#dinero#
                        #region PujaMAX
                        else if (subdatos[1].ToUpper() == "PUJAMAX")
                        {
                            //Actualiza estado (Indica ascenso puja)
                            if (subdatos[2] == A_Login.user.nick)
                            {
                                strEstado = (string)A_Login.dict["E8"] + " " + subdatos[3] + "€";
                            }
                            else
                            {
                                strEstado = subdatos[2] + (string)A_Login.dict["E8"] + subdatos[3] + "€";
                            }
                            Dispatcher.BeginInvoke(de);
                            //Añade el estado al historial
                            strLbl = strEstado;
                            Dispatcher.BeginInvoke(dl);
                        }
                        #endregion

                        // #FIN#-1#9000#
                        // #FIN#user1#9000#
                        #region FIN
                        else if (subdatos[1].ToUpper() == "FIN")
                        {
                            //subdatos[2] = nick Cliente
                            //subdatos[3] = puja final

                            if (subdatos[2] == "-1")
                            {//Significa que nadie ha pujado
                                strEstado = (string)A_Login.dict["E10"];
                                strLbl = (string)A_Login.dict["E11"]+ "\"" + aVO.title + "\""+ (string)A_Login.dict["E13"];
                            }
                            else
                            {
                                strEstado = (string)A_Login.dict["E14"] + subdatos[3] + "€. "+(string)A_Login.dict["E12"]+ " " + subdatos[2];
                                strLbl = (string)A_Login.dict["E11"] + "\"" + aVO.title + "\" "+ (string)A_Login.dict["E17"] + subdatos[3] + "€. " + (string)A_Login.dict["e12"] + subdatos[2];
                            }//Actualiza estado
                            Dispatcher.BeginInvoke(de);
                            //Bloquea Interfaz
                            pujaActiva = false;
                            Dispatcher.BeginInvoke(dp);
                            //Añade el estado al historial
                            Dispatcher.BeginInvoke(dl);
                        }

                        #endregion

                        // #CERRADO#
                        #region CERRADO
                        else if (subdatos[1].ToUpper() == "CERRADO")
                        {//Indica que se ha cerrado la sala
                            strEstado = (string)A_Login.dict["E16"];
                            MessageBox.Show((string)A_Login.dict["E17"]);

                            Dispatcher.BeginInvoke(de);
                        }
                        #endregion

                        // #DESCONECTADO#nick#
                        #region DESCONECTADO
                        else if (subdatos[1].ToUpper() == "DESCONECTADO")
                        {
                            //subdatos[2] = nick Cliente que se va

                            //Añade el mensaje en el historial, no en el estado
                            strLbl = subdatos[2] + " "+ (string)A_Login.dict["E18"];
                            Dispatcher.BeginInvoke(dl);
                        }
                        #endregion

                        // #NOK#PUJA#"dinero#
                        #region NOK
                        else if (subdatos[1].ToUpper() == "NOK")
                        {//Queda así hecho para permitir añadir más excepciones en un futuro
                            if (subdatos[2].ToUpper() == "PUJA")
                            {//Ocurre cuando la cantidad pujada no supera la puja actual
                                strEstado = (string)A_Login.dict["E18"]+ " " + subdatos[3].ToString() + "€";
                                Dispatcher.BeginInvoke(de);
                            }
                            //Añade el estado al historial
                            strLbl = strEstado;
                            Dispatcher.BeginInvoke(dl);
                        }
                        #endregion

                        /*************************************************************************************/
                    }

                }
                catch (Exception ex)
                {
                    ErrorLog.SilentLog("BreakCliente", ex);
                    break;
                }
            }
        }

        void EnviaPuja()
        {
            //Enviar puja: sw.WriteLine("-PUJA-id-dinero-");
            try
            {
                sw.WriteLine("-PUJA-" + A_Login.user.UserID + "-" + txtPuja.Text + "-");
                sw.Flush();

                txtPuja.Text = "";
                txtPuja.Focus();
            }
            catch (Exception ex)
            {
                ErrorLog.Log("SendBid", ex);
            }
        }
        void Abandonar()
        {
            try
            {
                closedServer.Visibility = Visibility.Visible;
                image.Source = null;
                sw.WriteLine("-DESCONECTAR-");
                sw.Flush();
                newsock.Stop();
            }
            catch (Exception)
            {
            }

        }
        #endregion

        #endregion
    }
}
