using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL
{
    public class PerfilesRepository : GenericRepository<Perfil>
    {
        public PerfilesRepository(GaleriaContext context)
            : base(context)
        {
        }
        public IEnumerable<Perfil> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (perf => perf.PerfilID.ToString().Contains(buscado.ToUpper())
                                         || perf.nombre.ToUpper().Contains(buscado.ToUpper())
                                         ));
            }
            else return Get();
        }
    }
}
