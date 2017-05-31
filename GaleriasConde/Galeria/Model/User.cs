using Galeria.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model
{
    public class User
    {
        //public class Usuario : PropertyValidateModel
        //{
        public User()
        {
            Transactions = new HashSet<Transaction>();
            //Conversaciones = new HashSet<Conversacion>();
            //Mensajes = new HashSet<Mensaje>();
            //mantenerSesion = false;
        }
        public int UserID { get; set; }
        public string name { get; set; }
        public string surnames { get; set; }
        public string nick { get; set; }
        public string pass { get; set; }
        public string address { get; set; }
        public string tlf { get; set; }
        //[EmailAddress(ErrorMessage = (string)A_Login.dict["asd"])]// "Dirección email inválida")]
        public string email { get; set; }
        ////[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        ////public bool autenticado { get; set; }

        ////[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        ////public bool mantenerSesion { get; set; }

        public virtual Nationality Nationality { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        ////public virtual ICollection<Conversacion> Conversaciones { get; set; }
        //public virtual ICollection<Mensaje> Mensajes { get; set; }
        //}
    }
}
