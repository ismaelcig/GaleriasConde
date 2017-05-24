using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL
{
    public class MensajesRepository : GenericRepository<Mensaje>
    {
        public MensajesRepository(GaleriaContext context)
            : base(context)
        {
        }
        public IEnumerable<Mensaje> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (msj => msj.MensajeID.ToString().Contains(buscado.ToUpper())
                                         || msj.texto.ToUpper().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
