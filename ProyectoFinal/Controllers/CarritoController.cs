using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using ProyectoFinal.Models;
using ProyectoFinal.Data;



namespace ProyectoFinal.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarritoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult AgregrarCarrito(int id)
        {
            if(Session["carrito"]==null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(_context.Productos.Find(id), 1));
                Session["carrito"] = compras;
            }
            else
            {

            }
            return View();
        }
    }
}