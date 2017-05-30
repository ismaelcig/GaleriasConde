using Galeria.Model.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL.Repositories.Translations
{
    public class TypeTranslationsRep : GenericRepository<TypeTranslations>
    {
        public TypeTranslationsRep(GaleriaContext context) : base(context)
        {
        }
        public IEnumerable<TypeTranslations> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (c => c.TypeID.ToString().Contains(buscado.ToUpper())
                                         || c.lang.ToUpper().Contains(buscado.ToUpper())
                                         || c.isDefault.ToString().Contains(buscado.ToUpper())
                                         || c.codType.ToString().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
