using Galeria.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model
{
    public class Chat
    {
        public Chat()
        {
            users = new HashSet<User>();
            messages = new HashSet<Message>();
        }

        public Chat(ICollection<User> us)//Establece automáticamente el nombre
        {
            this.users = us;
            name = "";
            foreach (User item in us)
            {
                if (item.nick != A_Login.user.nick)
                {
                    if (name != "")
                    {
                        name += ", ";
                    }
                    name += item.nick;
                }
            }
        }

        public int ChatID { get; set; }
        public string name { get; set; }
        public virtual ICollection<User> users { get; set; }
        public virtual ICollection<Message> messages { get; set; }
    }
}
