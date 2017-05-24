using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL
{
    public class AutoresRepository : GenericRepository<Autor>
    {
        public AutoresRepository(GaleriaContext context)
            : base(context)
        {
        }
        public IEnumerable<Autor> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (aut => aut.AutorID.ToString().Contains(buscado.ToUpper())
                                         || aut.nombreReal.ToUpper().Contains(buscado.ToUpper())
                                         || aut.nombreArtistico.ToString().Contains(buscado.ToUpper())
                                         || aut.descripcion.ToUpper().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
