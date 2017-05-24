using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL
{
    public class NacionalidadesRepository : GenericRepository<Nacionalidad>
    {
        public NacionalidadesRepository(GaleriaContext context)
            : base(context)
        {
        }
        public IEnumerable<Nacionalidad> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (nac => nac.NacionalidadID.ToString().Contains(buscado.ToUpper())
                                         || nac.nombre.ToUpper().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
