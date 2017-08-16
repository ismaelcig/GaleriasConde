using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model
{
    public class Transaction
    {
        public Transaction()
        {
            done = false;
        }
        public int TransactionID { get; set; }
        public double money { get; set; }
        public string comment { get; set; }
        public bool done { get; set; }//La transacción se crea cuando llega a un acuerdo, esto indica que se ha llevado a cabo el pago y la transferencia
        public int registeredBy { get; set; }//Para guardar quien registra la transacción, sólo guardo su id
        public bool venta { get; set; }//True si está vendiendo, false si no

        public virtual User User { get; set; }
        public virtual Artwork Artwork { get; set; }
    }
}
