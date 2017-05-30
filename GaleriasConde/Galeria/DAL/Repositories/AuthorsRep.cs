using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL.Repositories
{
    public class AuthorsRep : GenericRepository<Author>
    {
        public AuthorsRep(GaleriaContext context) : base(context)
        {
        }
        public IEnumerable<Author> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (aut => aut.AuthorID.ToString().Contains(buscado.ToUpper())
                                         || aut.realName.ToUpper().Contains(buscado.ToUpper())
                                         || aut.artName.ToString().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
