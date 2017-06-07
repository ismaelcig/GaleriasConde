using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL.Repositories
{
    public class ArtworksRep : GenericRepository<Artwork>
    {
        public ArtworksRep(GaleriaContext context) : base(context)
        {
        }
        public IEnumerable<Artwork> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (c => c.ArtworkID.ToString().Contains(buscado.ToUpper())
                                         || c.onStock.ToString().Contains(buscado.ToUpper())
                                         || c.date.ToString().Contains(buscado.ToUpper())
                                         || c.dimensions.ToString().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
