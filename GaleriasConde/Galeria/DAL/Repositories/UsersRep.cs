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
                return Get(filter: (c => c.UserID.ToString().Contains(buscado.ToUpper())
                                         || c.name.ToUpper().Contains(buscado.ToUpper())
                                         || c.surnames.ToString().Contains(buscado.ToUpper())
                                         || c.nick.ToString().Contains(buscado.ToUpper())
                                         || c.pass.ToString().Contains(buscado.ToUpper())
                                         || c.address.ToString().Contains(buscado.ToUpper())
                                         || c.tlf.ToString().Contains(buscado.ToUpper())
                                         || c.email.ToString().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
