using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class EstatusPedido
    {
        [Key]
        public int EstatusID { get; set; }

        [Required]
        public string DescEstatus { get; set; }
        
        public ICollection<Pedidos> Pedidos { get; set; }
    }
}
