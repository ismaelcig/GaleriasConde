using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model
{
    public class Author
    {
        public Author()
        {
            Artworks = new HashSet<Artwork>();
        }
        public int AuthorID { get; set; }
        [StringLength(150)]
        public string realName { get; set; }
        [StringLength(150)]
        public string artName { get; set; }
        //[StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
        //public string descripcion { get; set; }

        public virtual ICollection<Artwork> Artworks { get; set; }
        public virtual Nationality Nationality { get; set; }
    }
}
