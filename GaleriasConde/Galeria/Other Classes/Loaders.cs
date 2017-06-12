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
                    NationalityVO nVO = NationalityConverter.toVO(n);
                    VOs.Add(nVO);
                }
                comboBox.ItemsSource = null;
                comboBox.ItemsSource = VOs;
                comboBox.DisplayMemberPath = "codNation";
                comboBox.SelectedValuePath = "NationalityID";
            }
            catch (Exception ex)
            {
                ErrorLog.Log("Loaders1", ex);
            }
        }

        public static void LoadArtworks(ComboBox comboBox)//Se le pasa un cB, y carga ArtworkVOs
        {
            try
            {
                List<ArtworkVO> VOs = new List<ArtworkVO>();
                foreach (Artwork a in A_Login.u.ArtworksRep.GetAll())
                {
                    ArtworkVO aVO = ArtworkConverter.toVO(a);
                    VOs.Add(aVO);
                }
                comboBox.ItemsSource = null;
                comboBox.ItemsSource = VOs;
                comboBox.DisplayMemberPath = "title";
                comboBox.SelectedValuePath = "ArtworkID";
            }
            catch (Exception ex)
            {
                ErrorLog.Log("Loaders2", ex);
            }
        }



        public static void LoadUsers(ComboBox comboBox)//Se le pasa un cB, y carga Users
        {
            try
            {
                comboBox.ItemsSource = null;
                comboBox.ItemsSource = A_Login.u.UsersRep.GetAll();
                comboBox.DisplayMemberPath = "nick";
                comboBox.SelectedValuePath = "UserID";
            }
            catch (Exception ex)
            {
                ErrorLog.Log("Loaders3", ex);
            }
        }
    }
}
