using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Models
{
    public class CarritoItem
    {
        public int CarritoItemID { get; set; }
        private Productos _productos;
        private int _cantidad;

        public CarritoItem()
        {
           // Registrado = DateTime.Now;
        }

        public CarritoItem( Productos productos, int cantidad)
        {
            this.Productos = productos;
            this.Cantidad = cantidad;
        }

        public Productos Productos { get => _productos; set => _productos = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }

        /*public int CarritoID { get; set; }
        public string Sesion { get; set; }
        [DataType(DataType.Date)]
        public DateTime Registrado { get; set; }

        public int ProductoID { get; set; }
        public Productos Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int Descuento { get; set; }*/
    }
}
