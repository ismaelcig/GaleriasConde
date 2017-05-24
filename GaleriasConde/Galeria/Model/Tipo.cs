using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model
{
    public class Tipo
    {
        public Tipo()
        {
            Obras = new HashSet<Obra>();
        }
        public int TipoID { get; set; }
        [StringLength(25)]
        public string nombre { get; set; }

        public virtual ICollection<Obra> Obras { get; set; }
    }
}
