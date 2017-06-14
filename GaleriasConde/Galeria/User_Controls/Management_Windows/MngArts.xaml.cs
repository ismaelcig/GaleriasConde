using Galeria.Dict;
using Galeria.Model;
using Galeria.Model.Translation;
using Galeria.Other_Classes;
using Galeria.VO;
using Galeria.Windows;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MngArts.xaml
    /// </summary>
    public partial class MngArts : UserControl
    {
        CargarDiccionarios cd = new CargarDiccionarios();
        ArtworkVO obj = new ArtworkVO();
        List<ArtworkVO> VOs = new List<ArtworkVO>();
        byte[] arrayImg;//Para almacenar la img seleccionada como array hasta que se guarde en BD
        public MngArts()
        {
            InitializeComponent();
            if (A_Login.user.nick != "master")//Master tiene la posibilidad de registrar obras como en posesión, los demás no -> Deben registrar una transferencia de compra
            {
                checkBox.Visibility = Visibility.Hidden;
                label1.Visibility = Visibility.Hidden;
            }
            ReloadData();
        }
        
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedIndex > -1)
            {
                obj = new ArtworkVO();
                obj = (ArtworkVO)dataGrid.SelectedItem;
                txtID.Text = obj.ArtworkID.ToString();
                checkBox.IsChecked = obj.onStock;
                txtTitle.Text = obj.title;
                foreach (AuthorVO item in comboBoxAut.ItemsSource)
                {
                    if (item.AuthorID == obj.authorVO.AuthorID)
                    {
                        comboBoxAut.SelectedItem = item;
                    }
                }
                foreach (TypeVO item in comboBoxType.ItemsSource)
                {
                    if (item.TypeID == obj.typeVO.TypeID)
                    {
                        comboBoxType.SelectedItem = item;
                    }
                }
                txtDim.Text = obj.dimensions;
                txtDate.Text = obj.date;
                txtinfo.Text = obj.info;
                img.Source = Converters.BytesToImg(obj.img);

                buttMod.IsEnabled = true;
            }
            else
            {
                buttMod.IsEnabled = false;

                txtID.Text = "";
                checkBox.IsChecked = false;
                txtTitle.Text = "";
                comboBoxAut.SelectedIndex = -1;
                comboBoxType.SelectedIndex = -1;
                txtDim.Text = "";
                txtDate.Text = "";
                txtinfo.Text = "";
                img.Source = null;
                ReloadData();
            }
        }
        
        private void imgSelector_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = (string)A_Login.dict["ofdFilter"];
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == true)
            {
                string[] split = ofd.FileName.Split('.');
                if (split.Last().Equals("png") || split.Last().Equals("jpg") || split.Last().Equals("jpeg") || split.Last().Equals("gif"))//En principio son los formatos que admito, se podrían poner más
                {
                    arrayImg = Converters.ReadImageFile(ofd.FileName);//Guarda la img seleccionada como array de Bytes
                    img.Source = Converters.BytesToImg(arrayImg);//La muestra en la interfaz
                }
                else
                {
                    MessageBox.Show((string)A_Login.dict["MngArt_Msg1"]);//Formato incorrecto
                }
            }
        }

        private void buttAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTitle.Text) && comboBoxAut.SelectedIndex != -1 && comboBoxType.SelectedIndex != -1 && arrayImg != null)//El resto puede quedar en blanco, si es desconocido
            {//Rollback(?)
                try
                {
                    Artwork a = new Artwork();
                    a.Author = A_Login.u.AuthorsRep.Single(c => c.AuthorID == (int)comboBoxAut.SelectedValue);
                    a.Type = A_Login.u.TypesRep.Single(c => c.TypeID == (int)comboBoxType.SelectedValue);
                    a.date = txtDate.Text;
                    a.dimensions = txtDim.Text;
                    a.onStock = checkBox.IsChecked;
                    a.img = arrayImg;
                    A_Login.u.ArtworksRep.Create(a);//Creo el objeto Artwork

                    a = A_Login.u.ArtworksRep.GetAll().Last();//Para asegurar que tengo el último elemento, recién añadido
                    foreach (Lang lang in A_Login.u.LangsRep.GetAll())//Creo un objeto Translations por cada idioma, por defecto se crean todos iguales (salvo por codLang)
                    {                                                 //Se supone que un encargado de traducción se dedicará a adaptarlo a todos los idiomas disponibles
                        ArtworkTranslations at = new ArtworkTranslations(a, lang.codLang, txtTitle.Text, txtinfo.Text);
                        A_Login.u.ArtworkTranslationsRep.Create(at);
                    }
                    ReloadData();
                    dataGrid.SelectedIndex = 0;
                    dataGrid.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    ErrorLog.Log("MngArts1", ex);
                }
            }
            else
            {
                MessageBox.Show((string)A_Login.dict["RG_Msg1"]);//Campo vacío
            }
        }

        private void buttMod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtTitle.Text) && comboBoxAut.SelectedIndex != -1 && comboBoxType.SelectedIndex != -1)
                {
                    string lang = cd.GetCurrentLanguage();
                    ArtworkTranslations at = A_Login.u.ArtworkTranslationsRep.Single(c => c.ArtworkID == obj.ArtworkID && c.lang == lang);
                    at.title = txtTitle.Text;
                    at.info = txtinfo.Text;
                    A_Login.u.ArtworkTranslationsRep.Update(at);

                    Artwork a = A_Login.u.ArtworksRep.Single(c => c.ArtworkID == obj.ArtworkID);
                    a.date = txtDate.Text;
                    a.dimensions = txtDim.Text;
                    a.img = arrayImg;
                    a.onStock = checkBox.IsChecked;
                    A_Login.u.ArtworksRep.Update(a);

                    ReloadData();
                    dataGrid.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show((string)A_Login.dict["RG_Msg1"]);//Campo vacío
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("MngArts2", ex);
            }
        }

        public void ReloadData()
        {//Carga elementos VO en el dataGrid
            dataGrid.ItemsSource = null;
            VOs.Clear();
            foreach (Artwork item in A_Login.u.ArtworksRep.GetAll())
            {
                VOs.Add(new ArtworkVO(item.ArtworkID));
            }
            dataGrid.ItemsSource = VOs;
            Loaders.LoadAuthors(comboBoxAut);
            Loaders.LoadTypes(comboBoxType);
        }
    }
}
