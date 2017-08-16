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
    public class AuthorTranslations
    {
        public AuthorTranslations(Author data, string codLang, string description)
        {
            this.AuthorID = data.AuthorID;
            this.lang = codLang;
            this.Author = data;//necesario (?)
            this.description = description;
        }
        public AuthorTranslations(AuthorVO data, string codLang)
        {
            this.AuthorID = data.AuthorID;
            this.lang = codLang;
            this.description = data.description;
        }
        public AuthorTranslations()
        {

        }

        [Key, Column(Order = 1)]
        public int AuthorID { get; set; }
        [Key, Column(Order = 2)]
        public string lang { get; set; }//es-ES, en-US,....
        //[StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
        public string description { get; set; }

        public virtual Author Author { get; set; }
    }
}
