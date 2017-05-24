using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL
{
    public class TransaccionesRepository : GenericRepository<Transaccion>
    {
        public TransaccionesRepository(GaleriaContext context)
            : base(context)
        {
        }
        public IEnumerable<Transaccion> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (trans => trans.TransaccionID.ToString().Contains(buscado.ToUpper())
                                         || trans.anotacion.ToUpper().Contains(buscado.ToUpper())
                                         || trans.precio.ToString().Contains(buscado.ToUpper())
                                         || trans.tipo.ToUpper().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
