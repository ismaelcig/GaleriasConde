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
        [Key, Column(Order = 1)]
        public int NationalityID { get; set; }
        [Key, Column(Order = 2)]
        public string lang { get; set; }//es-ES, en-US,....
        public bool isDefault { get; set; }
        //[StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
        public string codNation { get; set; }

        public virtual Nationality Nationality { get; set; }
    }
}
