using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL.Repositories
{
    public class ChatsRep : GenericRepository<Chat>
    {
        public ChatsRep(GaleriaContext context) : base(context)
        {
        }
        public IEnumerable<Chat> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (c => c.ChatID.ToString().Equals(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
