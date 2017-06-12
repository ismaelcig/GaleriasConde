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
        public List<User> users { get; set; }
        public List<AuthorVO> authorVO { get; set; }

        public static List<NationalityVO> GetNationalitiesVO()
        {
            List<NationalityVO> l = new List<NationalityVO>();
            foreach (Nationality n in A_Login.u.NationalitiesRep.GetAll())
            {
                l.Add(NationalityConverter.toVO(n));
            }
            return l;
        }

        public static NationalityVO GetNationalityVO(int ID)
        {
            return NationalityConverter.toVO(A_Login.u.NationalitiesRep.Single(c => c.NationalityID == ID));
        }
    }

    public static class NationalityConverter
    {
        public static NationalityVO toVO(Nationality data)//Pasa de Nationality a NationalityVO en el idioma de la app
        {
            CargarDiccionarios cd = new CargarDiccionarios();
            string lang = cd.GetCurrentLanguage();
            NationalityVO result = new NationalityVO();
            result.NationalityID = data.NationalityID;
            result.codNation = A_Login.u.NationalityTranslationsRep.Single(c => c.NationalityID == data.NationalityID && c.lang == lang).codNation;
            result.users = User.GetUsers(data.NationalityID, "Nationality");
            result.authorVO = AuthorVO.GetAuthorsVO(data.NationalityID, "Nationality");
            return result;
        }

        public static Nationality fromVO(NationalityVO data)//Pasa de NationalityVO a Nationality
        {
            Nationality result = new Nationality();
            result.NationalityID = data.NationalityID;
            return result;
        }
    }
}
