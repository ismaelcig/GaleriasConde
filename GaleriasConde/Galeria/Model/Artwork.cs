using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Galeria.Model
{
    public class Artwork
    {
        public Artwork()
        {
            Transactions = new HashSet<Transaction>();
        }
        public int ArtworkID { get; set; }
        public bool onStock { get; set; }
        public byte[] img { get; set; }
        public string date { get; set; }
        //public string dimensions { get; set; }
        public double money { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual Type Type { get; set; }
        public virtual Author Author { get; set; }
    }
}
