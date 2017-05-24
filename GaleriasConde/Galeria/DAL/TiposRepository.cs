using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL
{
    public class TiposRepository : GenericRepository<Tipo>
    {
        public TiposRepository(GaleriaContext context)
            : base(context)
        {
        }
        public IEnumerable<Tipo> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (tip => tip.TipoID.ToString().Contains(buscado.ToUpper())
                                         || tip.nombre.ToUpper().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
