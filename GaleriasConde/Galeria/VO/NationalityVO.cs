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
        public int nUsers { get; set; }
        public int nAuthors { get; set; }

        public NationalityVO()
        {

        }

        public NationalityVO(int id)
        {
            CargarDiccionarios cd = new CargarDiccionarios();
            string lang = cd.GetCurrentLanguage();
            Nationality n = A_Login.u.NationalitiesRep.Single(c => c.NationalityID == id);
            NationalityTranslations nt = A_Login.u.NationalityTranslationsRep.Single(c => c.NationalityID == id && c.lang == lang);
            this.NationalityID = id;
            this.codNation = nt.codNation;
            this.nUsers = A_Login.u.UsersRep.Get(c => c.Nationality.NationalityID == id).Count;
            this.nAuthors = A_Login.u.AuthorsRep.Get(c => c.Nationality.NationalityID == id).Count;
        }
    }
}
