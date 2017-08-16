using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL.Repositories
{
    public class LangsRep : GenericRepository<Lang>
    {
        public LangsRep(GaleriaContext context) : base(context)
        {
        }
        public IEnumerable<Lang> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (c => c.codLang.Equals(buscado)
                                         || c.display.ToUpper().Equals(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
