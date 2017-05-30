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
        //[DataType(DataType.Text)]
        //public string operation { get; set; } //Será Compra o Venta
        //[DataType(DataType.Currency)]
        public double money { get; set; }//Si es positivo->beneficio para la empresa, es decir, una venta
        //[Range(0, 150), DataType(DataType.Text)]
        public string comment { get; set; }
        public bool done { get; set; }//La transacción se crea cuando llega a un acuerdo, esto indica que se ha llevado a cabo el pago y la transferencia

        public virtual User User { get; set; }
        public virtual Artwork Artwork { get; set; }
    }
}
