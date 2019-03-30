using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteID { get; set; }

        [Required]
        public string NombreCliente { get; set; }

        [Required]
        public string ApellidoPaterno { get; set; }

        [Required]
        public string ApellidoMaterno { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailCliente { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string TelefonoCliente { get; set; }

        public ICollection<Pedidos> Pedidos { get; set; }
    }
}
