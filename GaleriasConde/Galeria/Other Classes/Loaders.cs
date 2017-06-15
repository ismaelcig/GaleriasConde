using Galeria.Dict;
using Galeria.Model;
using Galeria.VO;
using Galeria.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Galeria.Other_Classes
{
    class Loaders
    {
        public static void LoadNationalities(ComboBox comboBox)//Se le pasa un cB, y carga NationalityVOs
        {
            try
            {
                List<NationalityVO> VOs = new List<NationalityVO>();
                foreach (Nationality n in A_Login.u.NationalitiesRep.GetAll())
                {
                    NationalityVO nVO = new NationalityVO(n.NationalityID);
                    VOs.Add(nVO);
                }
                VOs = VOs.OrderBy(c => c.codNation).ToList();
                comboBox.ItemsSource = null;
                comboBox.ItemsSource = VOs;
                comboBox.DisplayMemberPath = "codNation";
                comboBox.SelectedValuePath = "NationalityID";
            }
            catch (Exception ex)
            {
                ErrorLog.SilentLog("Loaders1", ex);
            }
        }

        public static void LoadArtworks(ComboBox comboBox)//Se le pasa un cB, y carga ArtworkVOs
        {
            try
            {
                List<ArtworkVO> VOs = new List<ArtworkVO>();
                foreach (Artwork a in A_Login.u.ArtworksRep.GetAll())
                {
                    ArtworkVO aVO = new ArtworkVO(a.ArtworkID);
                    VOs.Add(aVO);
                }
                VOs = VOs.OrderBy(c => c.title).ToList();
                comboBox.ItemsSource = null;
                comboBox.ItemsSource = VOs;
                comboBox.DisplayMemberPath = "title";
                comboBox.SelectedValuePath = "ArtworkID";
            }
            catch (Exception ex)
            {
                ErrorLog.SilentLog("Loaders2", ex);
            }
        }

        public static void LoadArtworks(ComboBox comboBox, bool onStock)//Se le pasa un cB, y carga ArtworkVOs
        {
            try
            {
                List<ArtworkVO> VOs = new List<ArtworkVO>();
                foreach (Artwork a in A_Login.u.ArtworksRep.Get(c=>c.onStock == onStock))
                {
                    ArtworkVO aVO = new ArtworkVO(a.ArtworkID);
                    VOs.Add(aVO);
                }
                VOs = VOs.OrderBy(c => c.title).ToList();
                comboBox.ItemsSource = null;
                comboBox.ItemsSource = VOs;
                comboBox.DisplayMemberPath = "title";
                comboBox.SelectedValuePath = "ArtworkID";
            }
            catch (Exception ex)
            {
                ErrorLog.SilentLog("Loaders2", ex);
            }
        }



        public static void LoadUsers(ComboBox comboBox)//Se le pasa un cB, y carga Users
        {
            try
            {
                comboBox.ItemsSource = null;
                comboBox.ItemsSource = A_Login.u.UsersRep.GetAll().OrderBy(c=>c.nick);
                comboBox.DisplayMemberPath = "nick";
                comboBox.SelectedValuePath = "UserID";
            }
            catch (Exception ex)
            {
                ErrorLog.SilentLog("Loaders3", ex);
            }
        }

        public static void LoadAuthors(ComboBox comboBox)
        {
            try
            {
                List<AuthorVO> VOs = new List<AuthorVO>();
                foreach (Author a in A_Login.u.AuthorsRep.GetAll())
                {
                    AuthorVO aVO = new AuthorVO(a.AuthorID);
                    VOs.Add(aVO);
                }
                VOs = VOs.OrderBy(c => c.artName).ToList();
                comboBox.ItemsSource = null;
                comboBox.ItemsSource = VOs;
                comboBox.DisplayMemberPath = "artName";
                comboBox.SelectedValuePath = "AuthorID";
            }
            catch (Exception ex)
            {
                ErrorLog.SilentLog("Loaders4", ex);
            }
        }

        public static void LoadTypes(ComboBox comboBox)
        {
            try
            {
                List<TypeVO> VOs = new List<TypeVO>();
                foreach (Model.Type a in A_Login.u.TypesRep.GetAll())
                {
                    TypeVO aVO = new TypeVO(a.TypeID);
                    VOs.Add(aVO);
                }
                VOs = VOs.OrderBy(c => c.codType).ToList();
                comboBox.ItemsSource = null;
                comboBox.ItemsSource = VOs;
                comboBox.DisplayMemberPath = "codType";
                comboBox.SelectedValuePath = "TypeID";
            }
            catch (Exception ex)
            {
                ErrorLog.SilentLog("Loaders5", ex);
            }
        }

        public static void LoadLangs(ComboBox comboBox)//Se le pasa un cB, y carga Langs
        {
            try
            {
                comboBox.ItemsSource = null;
                comboBox.ItemsSource = A_Login.u.LangsRep.GetAll().OrderBy(c => c.display);
                comboBox.DisplayMemberPath = "display";
                comboBox.SelectedValuePath = "codLang";
            }
            catch (Exception ex)
            {
                ErrorLog.SilentLog("Loaders3", ex);
            }
        }



    }
}
