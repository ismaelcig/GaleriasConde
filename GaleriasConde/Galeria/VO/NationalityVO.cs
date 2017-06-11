using Galeria.Dict;
using Galeria.Model;
using Galeria.Model.Translation;
using Galeria.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.VO
{
    public class NationalityVO
    {
        public int NationalityID { get; set; }
        public string codNation { get; set; }
    }//Añadir lista de Usuarios/Autores?

    public static class NationalityConverter
    {
        public static NationalityVO toVO(Nationality data)//Pasa de Nationality a NationalityVO en el idioma de la app
        {
            CargarDiccionarios cd = new CargarDiccionarios();
            string lang = cd.GetCurrentLanguage();
            NationalityVO result = new NationalityVO();
            result.NationalityID = data.NationalityID;
            result.codNation = A_Login.u.NationalityTranslationsRep.Single(c => c.NationalityID == data.NationalityID && c.lang == lang).codNation;
            return result;
        }
    }
}
