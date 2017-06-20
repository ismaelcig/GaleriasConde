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
        public User()
        {
            Transactions = new HashSet<Transaction>();
            Chats = new HashSet<Chat>();
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
        public byte[] picture { get; set; }
        ////[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        ////public bool autenticado { get; set; }

        ////[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        ////public bool mantenerSesion { get; set; }

        public virtual Nationality Nationality { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        ////public virtual ICollection<Conversacion> Conversaciones { get; set; }
        //public virtual ICollection<Mensaje> Mensajes { get; set; }

        public static List<User> GetUsers()
        {
            return A_Login.u.UsersRep.GetAll();
        }

        public static List<User> GetUsers(int ID, string field)
        {
            List<User> l = new List<User>();
            switch (field)
            {
                default:
                    break;
                case "Nationality":
                    foreach (User u in A_Login.u.UsersRep.Get(c => c.Nationality.NationalityID == ID))
                    {
                        l.Add(u);
                    }
                    break;
                case "Profile":
                    foreach (User u in A_Login.u.UsersRep.Get(c => c.Profile.ProfileID == ID))
                    {
                        l.Add(u);
                    }
                    break;
            }
            return l;
        }


    }
}
