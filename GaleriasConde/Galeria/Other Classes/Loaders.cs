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
                CargarDiccionarios cd = new CargarDiccionarios();
                List<NationalityVO> nationalitiesVO = new List<NationalityVO>();
                foreach (Nationality n in A_Login.u.NationalitiesRep.GetAll())
                {
                    NationalityVO nVO = new NationalityVO();
                    nVO.NationalityID = n.NationalityID;
                    string lang = cd.GetCurrentLanguage();
                    nVO.codNation = A_Login.u.NationalityTranslationsRep.Single(c => c.NationalityID == n.NationalityID && c.lang == lang).codNation;
                    nationalitiesVO.Add(nVO);
                }
                comboBox.ItemsSource = null;
                comboBox.ItemsSource = nationalitiesVO;
                comboBox.DisplayMemberPath = "codNation";
                comboBox.SelectedValuePath = "NationalityID";
            }
            catch (Exception ex)
            {
                ErrorLog.Log("Loaders1", ex);
            }
        }
    }
}
