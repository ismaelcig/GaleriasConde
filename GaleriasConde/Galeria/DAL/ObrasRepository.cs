using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL
{
    public class ObrasRepository : GenericRepository<Obra>
    {
        public ObrasRepository(GaleriaContext context)
            : base(context)
        {
        }
        public IEnumerable<Obra> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (obr => obr.ObraID.ToString().Contains(buscado.ToUpper())
                                         || obr.dimensiones.ToUpper().Contains(buscado.ToUpper())
                                         || obr.fecha.ToString().Contains(buscado.ToUpper())
                                         || obr.enPosesion.ToString().Contains(buscado.ToUpper())
                                         || obr.img.ToUpper().Contains(buscado.ToUpper())
                                         || obr.info.ToUpper().Contains(buscado.ToUpper())
                                         || obr.titulo.ToUpper().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
