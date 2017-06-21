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
    /// Lógica de interacción para MngTypes.xaml
    /// </summary>
    public partial class MngTypes : UserControl
    {
        CargarDiccionarios cd = new CargarDiccionarios();
        TypeVO obj = new TypeVO();
        List<TypeVO> VOs = new List<TypeVO>();
        public MngTypes()
        {
            InitializeComponent();
            if (A_Login.user.Profile.ProfileID >= 3)
            {
                ReloadData();
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)//Datagrid carga VOs
        {
            if (dataGrid.SelectedIndex > -1)
            {
                obj = new TypeVO();
                obj = (TypeVO)dataGrid.SelectedItem;
                txtID.Text = obj.TypeID.ToString();
                txtType.Text = obj.codType;//Muestra el cod en el idioma de la aplicación
                
                buttMod.IsEnabled = true;
                buttDel.IsEnabled = true;
            }
            else
            {
                ReloadData();
            }
        }

        private void buttAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtType.Text))
            {//Rollback(?)
                try
                {
                    Model.Type t = new Model.Type();
                    A_Login.u.TypesRep.Create(t);//Creo el objeto Type
                    t = A_Login.u.TypesRep.GetAll().Last();//Para asegurar que tengo el último elemento, recién añadido
                    foreach (Lang lang in A_Login.u.LangsRep.GetAll())//Creo un objeto Translations por cada idioma, por defecto se crean todos iguales (salvo por codLang)
                    {                                                 //Se supone que un encargado de traducción se dedicará a adaptarlo a todos los idiomas disponibles
                        TypeTranslations tt = new TypeTranslations(t, lang.codLang, txtType.Text);
                        A_Login.u.TypeTranslationsRep.Create(tt);
                    }
                    ReloadData();
                }
                catch (Exception ex)
                {
                    ErrorLog.Log("MngTypes1", ex);
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
                if (!string.IsNullOrWhiteSpace(txtType.Text))
                {
                    string lang = cd.GetCurrentLanguage();
                    TypeTranslations tt = A_Login.u.TypeTranslationsRep.Single(c => c.TypeID == obj.TypeID && c.lang == lang);
                    tt.codType = txtType.Text;
                    A_Login.u.TypeTranslationsRep.Update(tt);
                    
                    ReloadData();
                }
                else
                {
                    MessageBox.Show((string)A_Login.dict["RG_Msg1"]);//Campo vacío
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("MngTypes2", ex);
            }
        }

        private void buttDel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show((string)A_Login.dict["DelConfirmation"], (string)A_Login.dict["UPCaption"], MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {//Comprueba si alguna obra pertenece a este tipo, en tal caso impide seguir
                int cont = 0;
                foreach (Artwork a in A_Login.u.ArtworksRep.GetAll())
                {
                    if (obj.TypeID == a.Type.TypeID)
                    {
                        cont++;
                    }
                }
                if (cont > 0)
                {
                    MessageBox.Show(cont + (string)A_Login.dict["MngT_Msg1"]);//x obras son de tal tipo, no se puede eliminar
                }
                else
                {//A continuación, elimina el tipo, y todos sus nt
                    try
                    {
                        foreach (TypeTranslations tt in A_Login.u.TypeTranslationsRep.Get(c => c.TypeID == obj.TypeID))
                        {
                            A_Login.u.TypeTranslationsRep.Delete(tt);
                        }
                        A_Login.u.TypesRep.Delete(A_Login.u.TypesRep.Single(c => c.TypeID == obj.TypeID));

                        ReloadData();
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.Log("MngTypes3", ex);
                    }

                }
            }
        }

        public void ReloadData()
        {//Carga elementos VO en el dataGrid
            dataGrid.ItemsSource = null;
            VOs.Clear();
            foreach (Model.Type item in A_Login.u.TypesRep.GetAll())
            {
                VOs.Add(new TypeVO(item.TypeID));
            }
            dataGrid.ItemsSource = VOs;

            buttMod.IsEnabled = false;
            buttDel.IsEnabled = false;

            txtID.Text = "";
            txtType.Text = "";
        }
    }
}