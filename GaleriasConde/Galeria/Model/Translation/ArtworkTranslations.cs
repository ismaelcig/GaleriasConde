using Galeria.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model.Translation
{
    public class ArtworkTranslations
    {
        public ArtworkTranslations(Artwork data, string codLang, string title, string info)
        {
            this.ArtworkID = data.ArtworkID;
            this.lang = codLang;
            this.Artwork = data;//necesario (?)
            this.title = title;
            this.info = info;
        }
        public ArtworkTranslations(ArtworkVO data, string codLang)
        {
            this.ArtworkID = data.ArtworkID;
            this.lang = codLang;
            this.title = data.title;
            this.info = data.info;
        }
        public ArtworkTranslations()
        {

        }

        [Key, Column(Order = 1)]
        public int ArtworkID { get; set; }
        [Key, Column(Order = 2)]
        public string lang { get; set; }//es-ES, en-US,....
        //[StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
        public string title { get; set; }
        public string info { get; set; }

        public virtual Artwork Artwork { get; set; }
    }
}
