using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model
{
    public class Nacionalidad
    {
        public Nacionalidad()
        {
            Usuarios = new HashSet<Usuario>();
            Autores = new HashSet<Autor>();
        }
        public int NacionalidadID { get; set; }
        [StringLength(25)]
        public string nombre { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Autor> Autores { get; set; }
    }
}
