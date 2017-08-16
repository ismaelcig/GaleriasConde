using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL.Repositories
{
    public class MessagesRep : GenericRepository<Message>
    {
        public MessagesRep(GaleriaContext context) : base(context)
        {
        }
        public IEnumerable<Message> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (c => c.MessageID.ToString().Equals(buscado.ToUpper())
                                         //|| c.ChatID.ToString().Equals(buscado.ToUpper())
                                         || c.text.Equals(buscado)
                                         )
                                         );
            }
            else return Get();
        }
    }
}
