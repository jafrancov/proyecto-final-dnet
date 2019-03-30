using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Promociones
    {
        [Key]
        public int PromocionID { get; set; }

        [Required]
        public decimal Descuento { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

        public int ProductoID { get; set; }
        [ForeignKey("ProductoID")]
        public virtual Productos Productos { get; set; }
    }
}
