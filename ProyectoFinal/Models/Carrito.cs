using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Models
{
    public class Carrito
    {
        public Carrito()
        {
            Registrado = DateTime.Now;
        }

        public int CarritoID { get; set; }
        public string Sesion { get; set; }
        [DataType(DataType.Date)]
        public DateTime Registrado { get; set; }

        public int ProductoID { get; set; }
        public Productos Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int Descuento { get; set; }
    }
}
