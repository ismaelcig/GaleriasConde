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
    public class ArtworkVO
    {
        public int ArtworkID { get; set; }
        public bool onStock { get; set; }
        public byte[] img { get; set; }
        public string date { get; set; }
        public string dimensions { get; set; }
        public string title { get; set; }
        public string info { get; set; }
        public AuthorVO authorVO { get; set; }
        public TypeVO typeVO { get; set; }

        public ArtworkVO()
        {

        }

        public ArtworkVO(int id)
        {
            CargarDiccionarios cd = new CargarDiccionarios();
            string lang = cd.GetCurrentLanguage();
            Artwork a = A_Login.u.ArtworksRep.Single(c => c.ArtworkID == id);
            ArtworkTranslations at = A_Login.u.ArtworkTranslationsRep.Single(c => c.ArtworkID == id && c.lang == lang);
            this.ArtworkID = a.ArtworkID;
            this.onStock = a.onStock;
            this.img = a.img;
            this.date = a.date;
            this.dimensions = a.dimensions;
            this.title = at.title;
            this.info = at.info;
            this.authorVO = new AuthorVO(a.Author.AuthorID);
            this.typeVO = new TypeVO(a.Type.TypeID);
        }
    }
}
