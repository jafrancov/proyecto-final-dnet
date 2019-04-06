using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProyectoFinal.Models;
using ProyectoFinal.Data;
using Newtonsoft.Json;

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
            var objCarrito = new SessionExtension();
            objCarrito = HttpContext.Session.GetObjectFromJson<SessionExtensions>("carrito");
            if (objCarrito==null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(_context.Productos.Find(id), 1));
                HttpContext.Session.SetObjectAsJson("carrito", compras);
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>HttpContext.Session.GetObjectFromJson<SessionExtensions>("carrito"));
                int IndexExistente = getIndex(id);
                if (IndexExistente == -1)
                    compras.Add(new CarritoItem(_context.Productos.Find(id), 1));
                else
                    compras[IndexExistente].Cantidad++;
                HttpContext.Session.SetObjectAsJson("carrito", compras);
            }
            return View();
        }
        private int getIndex(int id)
        {
            List<CarritoItem> compras = (List < CarritoItem > HttpContext.Session.GetObjectFromJson<SessionExtensions>("carrito"));
            for(int i=0; i<compras.Count; i++)
            {
                if (compras[i].Productos.ProductoID == id)
                    return i;
            }
            return -1;
        }

        public IActionResult Delete(int id)
        {
            List<CarritoItem> compras = (List < CarritoItem > HttpContext.Session.GetObjectFromJson<SessionExtensions>("carrito"));
            compras.RemoveAt(getIndex(id));
            return View("AgregarCarrito");
        }
    }
     
    // agregar a una clase externa
   
        public static class SessionExtensions
        {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
   
}
}