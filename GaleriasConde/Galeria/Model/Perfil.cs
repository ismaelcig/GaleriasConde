using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model
{
    public class Perfil
    {
        public Perfil()
        {
            //Permisos = new HashSet<Permiso>();
            Usuarios = new HashSet<Usuario>();
        }
        public int PerfilID { get; set; }
        public string nombre { get; set; }

        //public virtual ICollection<Permiso> Permisos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
