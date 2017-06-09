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
    public class NationalityTranslations
    {
        public NationalityTranslations(Nationality data, string codLang, string codNation)
        {
            this.NationalityID = data.NationalityID;
            this.lang = codLang;
            this.Nationality = data;//necesario (?)
            this.codNation = codNation;
        }
        public NationalityTranslations(NationalityVO data, string codLang)
        {
            this.NationalityID = data.NationalityID;
            this.lang = codLang;
            this.codNation = data.codNation;
        }
        public NationalityTranslations()
        {

        }

        [Key, Column(Order = 1)]
        public int NationalityID { get; set; }
        [Key, Column(Order = 2)]
        public string lang { get; set; }//es-ES, en-US,....
        //[StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
        public string codNation { get; set; }

        public virtual Nationality Nationality { get; set; }
    }
}
