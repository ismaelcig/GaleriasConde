using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model
{
    public class Transaccion
    {
        public Transaccion()
        {
            realizada = false;
        }
        public int TransaccionID { get; set; }

        [DataType(DataType.Text)]
        public string tipo { get; set; } //Será Compra o Venta

        [DataType(DataType.Currency)]
        public double precio { get; set; }

        [Range(0, 150), DataType(DataType.Text)]
        public string anotacion { get; set; }

        public bool realizada { get; set; }//La transacción se crea cuando llega a un acuerdo, esto indica que se ha llevado a cabo el pago y la transferencia

        public virtual Usuario Usuario { get; set; }
        public virtual Obra Obra { get; set; }
    }
}
