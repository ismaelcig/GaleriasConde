using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL.Repositories
{
    public class TransactionsRep : GenericRepository<Transaction>
    {
        public TransactionsRep(GaleriaContext context) : base(context)
        {
        }
        public IEnumerable<Transaction> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (tran => tran.TransactionID.ToString().Contains(buscado.ToUpper())
                                         || tran.money.ToString().Contains(buscado.ToUpper())
                                         || tran.done.ToString().Contains(buscado.ToUpper())
                                         )
                                         );
            }
            else return Get();
        }
    }
}
