using Galeria.Dict;
using Galeria.Model;
using Galeria.Model.Translation;
using Galeria.Other_Classes;
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
            if (dataGrid.SelectedIndex > -1)
            {
                obj = new AuthorVO();
                obj = (AuthorVO)dataGrid.SelectedItem;
                txtID.Text = obj.AuthorID.ToString();
                txtName.Text = obj.realName;
                txtArt.Text = obj.artName;
                txtInfo.Text = obj.description;
                //comboBox.SelectedItem = obj.nationalityVO;
                foreach (NationalityVO item in comboBox.ItemsSource)
                {
                    if (item.NationalityID == obj.nationalityVO.NationalityID)
                    {
                        comboBox.SelectedItem = item;//Así funciona
                    }
                }

                buttMod.IsEnabled = true;
                buttDel.IsEnabled = true;
            }
            else
            {
                buttMod.IsEnabled = false;
                buttDel.IsEnabled = false;

                txtID.Text = "";
                txtName.Text = "";
                txtArt.Text = "";
                txtInfo.Text = "";
                ReloadData();
            }
        }

        private void buttAdd_Click(object sender, RoutedEventArgs e)
        {//!string.IsNullOrWhiteSpace(txtName.Text) &&  //Nombre real no tiene por qué ser conocido (ej: Banksy)
            if (!string.IsNullOrWhiteSpace(txtArt.Text) && !string.IsNullOrWhiteSpace(txtInfo.Text))
            {//Rollback(?)
                try
                {
                    Author a = new Author();
                    a.realName = txtName.Text;//Probar si da error al dejar el campo en blanco
                    a.artName = txtArt.Text;
                    Nationality n = A_Login.u.NationalitiesRep.Single(c => c.NationalityID == (int)comboBox.SelectedValue);
                    a.Nationality = n;
                    A_Login.u.AuthorsRep.Create(a);//Creo el objeto Author
                    a = A_Login.u.AuthorsRep.GetAll().Last();//Para asegurar que tengo el último elemento, recién añadido
                    foreach (Lang lang in A_Login.u.LangsRep.GetAll())//Creo un objeto Translations por cada idioma, por defecto se crean todos iguales (salvo por codLang)
                    {                                                 //Se supone que un encargado de traducción se dedicará a adaptarlo a todos los idiomas disponibles
                        AuthorTranslations at = new AuthorTranslations(a, lang.codLang, txtInfo.Text);
                        A_Login.u.AuthorTranslationsRep.Create(at);
                    }
                    ReloadData();
                    dataGrid.SelectedIndex = 0;
                    dataGrid.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    ErrorLog.Log("MngAuths1", ex);
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
                if (!string.IsNullOrWhiteSpace(txtArt.Text) && !string.IsNullOrWhiteSpace(txtInfo.Text))
                {
                    string lang = cd.GetCurrentLanguage();
                    AuthorTranslations at = A_Login.u.AuthorTranslationsRep.Single(c => c.AuthorID == obj.AuthorID && c.lang == lang);
                    at.description = txtInfo.Text;
                    A_Login.u.AuthorTranslationsRep.Update(at);

                    Author a = A_Login.u.AuthorsRep.Single(c => c.AuthorID == obj.AuthorID);
                    a.artName = txtArt.Text;
                    a.realName = txtName.Text;
                    a.Nationality = A_Login.u.NationalitiesRep.Single(c => c.NationalityID == (int)comboBox.SelectedValue);
                    A_Login.u.AuthorsRep.Update(a);

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
                ErrorLog.Log("MngAuths2", ex);
            }
        }

        private void buttDel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show((string)A_Login.dict["DelConfirmation"], (string)A_Login.dict["UPCaption"], MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {//Comprueba si es autor de alguna obra, en tal caso impide seguir
                int cont = 0;
                foreach (Artwork item in A_Login.u.ArtworksRep.GetAll())
                {
                    if (obj.AuthorID == item.Author.AuthorID)
                    {
                        cont++;
                    }
                }
                if (cont > 0)
                {
                    MessageBox.Show(cont + (string)A_Login.dict["MngA_Msg1"]);//x Obras tienen asociado a este Autor. No puede ser eliminado.
                }
                else
                {//A continuación, elimina el autor, y todos sus at
                    try
                    {
                        foreach (AuthorTranslations at in A_Login.u.AuthorTranslationsRep.Get(c => c.AuthorID == obj.AuthorID))
                        {
                            A_Login.u.AuthorTranslationsRep.Delete(at);
                        }
                        A_Login.u.AuthorsRep.Delete(A_Login.u.AuthorsRep.Single(c => c.AuthorID == obj.AuthorID));

                        ReloadData();
                        dataGrid.SelectedIndex = -1;
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.Log("MngAuths3", ex);
                    }

                }
            }
        }

        public void ReloadData()
        {//Carga elementos VO en el dataGrid
            dataGrid.ItemsSource = null;
            VOs.Clear();
            foreach (Author item in A_Login.u.AuthorsRep.GetAll())
            {
                VOs.Add(new AuthorVO(item.AuthorID));
            }
            dataGrid.ItemsSource = VOs;
            Loaders.LoadNationalities(comboBox);
        }
    }
}
