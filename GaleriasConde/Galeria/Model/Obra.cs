using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.Model
{
    public class Obra
    {
        public Obra()
        {
            Transacciones = new HashSet<Transaccion>();
        }
        public int ObraID { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Es necesario un título")]
        public string titulo { get; set; }
        [Required]
        public bool enPosesion { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Es necesaria una imagen")]
        public string img { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public string fecha { get; set; }
        [DataType(DataType.Text)]
        public string dimensiones { get; set; }
        [StringLength(500, MinimumLength =10, ErrorMessage = "La info debe estar entre 10 y 500 caracteres")]
        public string info { get; set; }

        public virtual ICollection<Transaccion> Transacciones { get; set; }
        public virtual Tipo Tipo { get; set; }
        public virtual Autor Autor { get; set; }
    }
}
