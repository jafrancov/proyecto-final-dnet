using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Productos
    {
        [Key]
        public int ProductoID { get; set; }

        [Required]
        public string NombreProducto { get; set; }

        [Required]
        public int Existencia { get; set; }

        [Required]
        [Range(0.01, 100000.00,ErrorMessage = "El precio debe estar entre 0.01 y 100000.00")]
        public decimal Precio { get; set; }

        public bool Descontinuado { get; set; }
        public byte[] Image { get; set; }
    
        public int CategoriaID { get; set; }
        [ForeignKey("CategoriaID")]
        public virtual Categorias Categorias { get; set; }

        public ICollection<Promociones> Promociones { get; set; }
        public List<DetallePedido> DetallePedido { get; set; }
    }
}
