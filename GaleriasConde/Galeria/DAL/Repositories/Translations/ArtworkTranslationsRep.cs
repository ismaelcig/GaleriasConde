using Galeria.Model.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL.Repositories.Translations
{
    public class ArtworkTranslationsRep : GenericRepository<ArtworkTranslations>
    {
        public ArtworkTranslationsRep(GaleriaContext context) : base(context)
        {
        }
        public IEnumerable<ArtworkTranslations> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (c => c.ArtworkID.ToString().Contains(buscado.ToUpper())
                                         || c.lang.ToUpper().Contains(buscado.ToUpper())
                                         || c.title.ToString().Contains(buscado.ToUpper())
                                         || c.dimensions.ToString().Contains(buscado.ToUpper())
                                         || c.info.ToString().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
