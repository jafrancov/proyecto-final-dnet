using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Pedidos
    {
        public Pedidos()
        {
            FechaPedido = DateTime.Now;
        }

        [Key]
        public int PedidoID { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaPedido { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaEmbarque { get; set; }

        public String ReferenciaBanco { get; set; }

        public int ClienteID { get; set; }
        public Clientes Clientes { get; set; }

        public int EstatusID { get; set; }
        [ForeignKey("EstatusID")]
        public virtual EstatusPedido EstatusPedido { get; set; }

        public List<DetallePedido> DetallePedido { get; set; }
    }
}
