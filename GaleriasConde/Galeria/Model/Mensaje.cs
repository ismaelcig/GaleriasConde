using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model
{
    public class Mensaje
    {
        public Mensaje()
        {
            sinLeer = true;
        }
        public int MensajeID { get; set; }

        [Required]
        public string texto { get; set; }

        //El usuario que envía (o el admin que responde)
        public virtual Usuario Emisor { get; set; }
        //El usuario que recibe (cuando el usuario envía, esto queda vacío)
        public virtual Usuario Receptor { get; set; }

        //public int UsuarioID { get; set; }

        //Receptor/es (Conversación)
        //public virtual Conversacion Conversación { get; set; }

        public bool sinLeer { get; set; }
    }
}
