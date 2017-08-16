using Galeria.Dict;
using Galeria.Model;
using Galeria.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.VO
{
    public class TransactionVO
    {
        public int TransactionID { get; set; }
        public double money { get; set; }
        public string comment { get; set; }
        public bool done { get; set; }//La transacción se crea cuando llega a un acuerdo, esto indica que se ha llevado a cabo el pago y la transferencia
        public User registeredBy { get; set; }//Para ver quien registra la transacción
        public bool venta { get; set; }//True si está vendiendo, false si no

        public virtual User User { get; set; }
        public virtual ArtworkVO ArtworkVO { get; set; }


        public TransactionVO()
        {

        }

        public TransactionVO(int id)
        {
            CargarDiccionarios cd = new CargarDiccionarios();
            string lang = cd.GetCurrentLanguage();
            Transaction t = A_Login.u.TransactionsRep.Single(c => c.TransactionID == id);
            this.TransactionID = t.TransactionID;
            this.money = t.money;
            this.comment = t.comment;
            this.done = t.done;
            this.registeredBy = A_Login.u.UsersRep.Single(c => c.UserID == t.registeredBy);
            this.venta = t.venta;
            this.User = t.User;
            this.ArtworkVO = new ArtworkVO(t.Artwork.ArtworkID);
        }
    }
}
