using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model
{
    public class Autor
    {
        public Autor()
        {
            Obras = new HashSet<Obra>();
        }
        public int AutorID { get; set; }
        [StringLength(150, ErrorMessage = "Un nombre no puede superar los 150 caracteres")]
        public string nombreReal { get; set; }
        [StringLength(150, ErrorMessage = "Un nombre no puede superar los 150 caracteres")]
        public string nombreArtistico { get; set; }
        [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
        public string descripcion { get; set; }

        public virtual ICollection<Obra> Obras { get; set; }
        public virtual Nacionalidad Nacionalidad { get; set; }
    }
}
