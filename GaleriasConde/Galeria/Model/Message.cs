using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model//Todavía no está en la BD
{
    public class Message
    {
        public Message()
        {
        }

        public Message(Chat chat, string txt, User sender)
        {
            this.Chat = chat;
            this.text = txt;
            this.Sender = sender;
        }

        public Message(Chat chat, byte[] img, User sender)
        {
            this.Chat = chat;
            this.adjunto = img;
            this.Sender = sender;
        }

        public Message(Chat chat, string txt, byte[] img, User sender)
        {
            this.Chat = chat;
            this.text = txt;
            this.adjunto = img;
            this.Sender = sender;
        }
        //[Key, Column(Order = 1)]
        public int MessageID { get; set; }
        //[Key, Column(Order = 2)]
        //public int ChatID { get; set; }
        public string text { get; set; }
        public byte[] adjunto { get; set; }

        //El usuario que envía
        public virtual User Sender { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
