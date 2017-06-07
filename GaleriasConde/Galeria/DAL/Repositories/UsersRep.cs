using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL.Repositories
{
    public class UsersRep : GenericRepository<User>
    {
        public UsersRep(GaleriaContext context) : base(context)
        {
        }
        public IEnumerable<User> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (c => c.UserID.ToString().Equals(buscado.ToUpper())
                                         || c.name.Equals(buscado)
                                         || c.surnames.Equals(buscado)
                                         || c.nick.Equals(buscado)
                                         || c.pass.Equals(buscado)
                                         || c.address.ToString().Contains(buscado.ToUpper())
                                         || c.tlf.ToString().Equals(buscado)
                                         || c.email.ToString().Equals(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
