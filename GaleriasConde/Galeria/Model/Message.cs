using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model//Todavía no está en la BD
{
    public class Message
    {
        public Message()
        {
            //sinLeer = true;
        }
        public int MessageID { get; set; }

        //[Required]
        public string text { get; set; }

        //El usuario que envía (o el admin que responde)
        public virtual User Sender { get; set; }
        //Chat al que se envía
        //El usuario que recibe (cuando el usuario envía, esto queda vacío)
        //public virtual Usuario Receptor { get; set; }

        //public int UsuarioID { get; set; }

        //Receptor/es (Conversación)
        //public virtual Conversacion Conversación { get; set; }

        public bool sinLeer { get; set; }
    }
}
