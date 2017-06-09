using Galeria.Model.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL.Repositories.Translations
{
    public class NationalityTranslationsRep : GenericRepository<NationalityTranslations>
    {
        public NationalityTranslationsRep(GaleriaContext context) : base(context)
        {
        }
        public IEnumerable<NationalityTranslations> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (c => c.NationalityID.ToString().Contains(buscado.ToUpper())
                                         || c.lang.ToUpper().Contains(buscado.ToUpper())
                                         || c.codNation.ToString().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
