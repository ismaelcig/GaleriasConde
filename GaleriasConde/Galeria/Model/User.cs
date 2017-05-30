using System;
using System.Collections.Generic;
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
            //Transacciones = new HashSet<Transaccion>();
            //Conversaciones = new HashSet<Conversacion>();
            //Mensajes = new HashSet<Mensaje>();
            //mantenerSesion = false;
        }
        public int UserID { get; set; }
        //[StringLength(25, ErrorMessage = "Máx. 25 caracteres")]
        public string name { get; set; }
        //[StringLength(25, ErrorMessage = "Máx. 25 caracteres")]
        public string surnames { get; set; }
        //[Required(ErrorMessage = "El nick es obligatorio"), StringLength(25, ErrorMessage = "Máx. 25 caracteres")]
        public string nick { get; set; }
        //[Required]//(ErrorMessage = "Este campo es obligatorio")]
        public string pass { get; set; }
        //[DataType(DataType.Text)]
        public string address { get; set; }
        //[Required(ErrorMessage = "Un nº de teléfono es obligatorio")]
        public string tlf { get; set; }
        //[Required(ErrorMessage = "Un email es obligatorio")]
        //[EmailAddress(ErrorMessage = "Dirección email inválida")]
        public string email { get; set; }
        ////[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        ////public bool autenticado { get; set; }

        ////[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        ////public bool mantenerSesion { get; set; }

        public virtual Nationality Nationality { get; set; }
        public virtual Profile Profile { get; set; }
        //public virtual ICollection<Transaccion> Transacciones { get; set; }
        ////public virtual ICollection<Conversacion> Conversaciones { get; set; }
        //public virtual ICollection<Mensaje> Mensajes { get; set; }
        //public virtual int PerfilID { get; set; }
        //[NotMapped]
        //public Perfil Perfil { get; set; }
        //}
    }
}
