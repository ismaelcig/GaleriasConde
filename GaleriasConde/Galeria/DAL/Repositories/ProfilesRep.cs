using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL.Repositories
{
    public class ProfilesRep : GenericRepository<Profile>
    {
        public ProfilesRep(GaleriaContext context) : base(context)
        {
        }
        public IEnumerable<Profile> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (c => c.ProfileID.ToString().Contains(buscado.ToUpper())
                                         || c.codProfile.ToUpper().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
