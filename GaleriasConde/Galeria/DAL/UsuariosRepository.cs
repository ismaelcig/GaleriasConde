using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL
{
    public class UsuariosRepository : GenericRepository<Usuario>
    {
        public UsuariosRepository(GaleriaContext context)
            : base(context)
        {
        }
        public IEnumerable<Usuario> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (user => user.UsuarioID.ToString().Contains(buscado.ToUpper())
                                         || user.nombre.ToUpper().Contains(buscado.ToUpper())
                                         || user.nick.ToUpper().Contains(buscado.ToUpper())
                                         //|| user.admin.ToString().Contains(buscado.ToUpper())
                                         || user.apellidos.ToUpper().Contains(buscado.ToUpper())
                                         || user.direccion.ToUpper().Contains(buscado.ToUpper())
                                         || user.email.ToUpper().Contains(buscado.ToUpper())
                                         || user.tlf.ToUpper().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
