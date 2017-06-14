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
    public class AuthorVO
    {
        public int AuthorID { get; set; }
        public string realName { get; set; }
        public string artName { get; set; }
        public string description { get; set; }
        public int nArts { get; set; }
        public NationalityVO nationalityVO { get; set; }

        public AuthorVO(int id)
        {
            CargarDiccionarios cd = new CargarDiccionarios();
            string lang = cd.GetCurrentLanguage();
            Author a = A_Login.u.AuthorsRep.Single(c => c.AuthorID == id);
            AuthorTranslations at = A_Login.u.AuthorTranslationsRep.Single(c => c.AuthorID == id && c.lang == lang);
            this.AuthorID = a.AuthorID;
            this.realName = a.realName;
            this.artName = a.artName;
            this.description = at.description;
            this.nArts = A_Login.u.ArtworksRep.Get(c => c.Author.AuthorID == id).Count;
            this.nationalityVO = new NationalityVO(a.Nationality.NationalityID);
        }

        public AuthorVO()
        {

        }
    }
}
