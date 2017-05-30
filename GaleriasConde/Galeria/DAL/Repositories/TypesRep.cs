using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL.Repositories
{
    public class TypesRep : GenericRepository<Model.Type>
    {
        public TypesRep(GaleriaContext context) : base(context)
        {
        }
        public IEnumerable<Model.Type> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (c => c.TypeID.ToString().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
