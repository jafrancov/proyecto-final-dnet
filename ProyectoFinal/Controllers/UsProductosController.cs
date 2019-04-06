using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using ProyectoFinal.Data;

namespace ProyectoFinal.Controllers
{
    public class UsProductosController : Controller
    { 
    
   private readonly ApplicationDbContext _context;

    public UsProductosController(ApplicationDbContext context)
    {
        _context = context;
    }
    
        public ActionResult Index()
        {
            return View(_context.Productos.ToList().OrderBy(x => x.NombreProducto));
        }
    }
}