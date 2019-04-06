using ProyectoFinal.Models;
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
        public decimal Precio { get; set; }

        public bool Descontinuado { get; set; }

        public byte[] Image { get; set; }
    
        public int CategoriaID { get; set; }
        [ForeignKey("CategoriaID")]
        public virtual Categorias Categorias { get; set; }

        public ICollection<Promociones> Promociones { get; set; }
        public List<DetallePedido> DetallePedido { get; set; }
        public ICollection<Carrito> Carrito { get; set; }
    }
}
