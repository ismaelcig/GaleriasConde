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
        //[StringLength(50)]
        //[Required(ErrorMessage = "Es necesario un título")]
        //public string titulo { get; set; }
        //[Required]
        public bool onStock { get; set; }

        //[DataType(DataType.Text)]
        //[Required(ErrorMessage = "Es necesaria una imagen")]
        //public Image img { get; set; }
        public byte[] img { get; set; }
        //public string img { get; set; }
        //[Required(ErrorMessage = "La fecha es obligatoria")]
        public string date { get; set; }
        //[DataType(DataType.Text)]
        public string dimensions { get; set; }
        //[StringLength(500, MinimumLength = 10, ErrorMessage = "La info debe estar entre 10 y 500 caracteres")]
        //public string info { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual Type Type { get; set; }
        public virtual Author Author { get; set; }
    }
}
