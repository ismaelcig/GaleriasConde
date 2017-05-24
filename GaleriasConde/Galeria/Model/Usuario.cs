using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model
{
    public class Usuario : PropertyValidateModel
    {
        public Usuario()
        {
            Transacciones = new HashSet<Transaccion>();
            //Conversaciones = new HashSet<Conversacion>();
            Mensajes = new HashSet<Mensaje>();
            //mantenerSesion = false;
            //Perfil = Windows.A_Login.u.PerfilesRepository.Single(c => c.nombre == "Default");
            //Perfil = new Perfil { PerfilID = 1, nombre = "Default" };
        }
        public int UsuarioID { get; set; }
        [StringLength(25)]
        public string nombre { get; set; }
        [StringLength(25)]
        public string apellidos { get; set; }

        //[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        //public bool autenticado { get; set; }

        //[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        //public bool mantenerSesion { get; set; }

        [Required, StringLength(25)]
        public string nick { get; set; }

        
        public string pass { get; set; }

        [DataType(DataType.Text)]
        public string direccion { get; set; }

        [Required]
        public string tlf { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Dirección email inválida")]
        public string email { get; set; }

        public virtual ICollection<Transaccion> Transacciones { get; set; }
        public virtual Nacionalidad Nacionalidad { get; set; }
        public virtual ICollection<Mensaje> Mensajes { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
