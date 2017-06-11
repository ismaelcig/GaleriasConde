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
    /// Interaction logic for MngNats.xaml
    /// </summary>
    public partial class MngNats : UserControl
    {
        CargarDiccionarios cd = new CargarDiccionarios();
        NationalityVO obj = new NationalityVO();
        List<NationalityVO> VOs = new List<NationalityVO>();
        public MngNats()
        {
            InitializeComponent();
            ReloadData();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)//Datagrid carga VOs
        {
            if (dataGrid.SelectedIndex > -1)
            {
                obj = new NationalityVO();
                obj = (NationalityVO)dataGrid.SelectedItem;
                txtID.Text = obj.NationalityID.ToString();
                txtNac.Text = obj.codNation;//Muestra el cod en el idioma de la aplicación
                
                buttMod.IsEnabled = true;
                buttDel.IsEnabled = true;
            }
            else
            {
                buttMod.IsEnabled = false;
                buttDel.IsEnabled = false;

                txtID.Text = "";
                txtNac.Text = "";
                ReloadData();
            }
        }

        private void buttAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNac.Text))
            {//Rollback(?)
                try
                {
                    Nationality n = new Nationality();
                    A_Login.u.NationalitiesRep.Create(n);//Creo el objeto Nationality
                    n = A_Login.u.NationalitiesRep.GetAll().Last();//Para asegurar que tengo el último elemento, recién añadido
                    foreach (Lang lang in A_Login.u.LangsRep.GetAll())//Creo un objeto Translations por cada idioma, por defecto se crean todos iguales (salvo por codLang)
                    {                                                 //Se supone que un encargado de traducción se dedicará a adaptarlo a todos los idiomas disponibles
                        NationalityTranslations nt = new NationalityTranslations(n, lang.codLang, txtNac.Text);
                        A_Login.u.NationalityTranslationsRep.Create(nt);
                    }
                    ReloadData();
                    dataGrid.SelectedIndex = 0;
                    dataGrid.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    ErrorLog.Log("MngNats1", ex);
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
                if (!string.IsNullOrWhiteSpace(txtNac.Text))
                {
                    obj.codNation = txtNac.Text;//obj es el VO

                    NationalityTranslations nt = new NationalityTranslations(obj, cd.GetCurrentLanguage());
                    A_Login.u.NationalityTranslationsRep.Update(nt);//Modifica el codNation
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
                ErrorLog.Log("MngNats2", ex);
            }
        }

        private void buttDel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show((string)A_Login.dict["DelConfirmation"], (string)A_Login.dict["UPCaption"], MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {//Comprueba si alguien posee esta nacionalidad, en tal caso impide seguir
                int cont = 0;
                foreach (User u in A_Login.u.UsersRep.GetAll())
                {
                    if (obj.NationalityID == u.Nationality.NationalityID)
                    {
                        cont++;
                    }
                }
                if (cont > 0)
                {
                    MessageBox.Show(cont + (string)A_Login.dict["MngN_Msg1"]);//x personas tienen tal nacionalidad, no se puede eliminar
                }
                else
                {//A continuación, elimina la nacionalidad, y todos sus nt
                    try
                    {
                        foreach (NationalityTranslations nt in A_Login.u.NationalityTranslationsRep.Get(c => c.NationalityID == obj.NationalityID))
                        {
                            A_Login.u.NationalityTranslationsRep.Delete(nt);
                        }
                        A_Login.u.NationalitiesRep.Delete(A_Login.u.NationalitiesRep.Single(c => c.NationalityID == obj.NationalityID));
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.Log("MngNats3", ex);
                    }
                    
                }
            }
        }

        public void ReloadData()
        {//Carga elementos VO en el dataGrid
            dataGrid.ItemsSource = null;
            VOs.Clear();
            foreach (Nationality item in A_Login.u.NationalitiesRep.GetAll())
            {
                VOs.Add(NationalityConverter.toVO(item));
            }
            dataGrid.ItemsSource = VOs;
        }
    }
}
