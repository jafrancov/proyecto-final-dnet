using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class DetallePedido
    {
        public int PedidoID { get; set; }
        public Pedidos Pedido { get; set; }

        public int ProductoID { get; set; }
        public Productos Producto { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal PrecioVenta { get; set; }

        [Required]
        [Range(1,100000)]
        public int CantidadVendida { get; set; }

        public decimal DescuentoVenta { get; set; }
    }
}
