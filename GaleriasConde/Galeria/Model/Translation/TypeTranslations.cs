using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model.Translation
{
    public class TypeTranslations
    {
        [Key, Column(Order = 1)]
        public int TypeID { get; set; }
        [Key, Column(Order = 2)]
        public string lang { get; set; }//es-ES, en-US,....
        public bool isDefault { get; set; }
        //[StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
        public string codType { get; set; }

        public virtual Type Type { get; set; }
    }
}
