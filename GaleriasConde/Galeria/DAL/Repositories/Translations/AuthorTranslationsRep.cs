using Galeria.Model.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL.Repositories.Translations
{
    public class AuthorTranslationsRep : GenericRepository<AuthorTranslations>
    {
        public AuthorTranslationsRep(GaleriaContext context) : base(context)
        {
        }
        public IEnumerable<AuthorTranslations> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (aut => aut.AuthorID.ToString().Contains(buscado.ToUpper())
                                         || aut.lang.ToUpper().Contains(buscado.ToUpper())
                                         || aut.isDefault.ToString().Contains(buscado.ToUpper())
                                         || aut.description.ToString().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
