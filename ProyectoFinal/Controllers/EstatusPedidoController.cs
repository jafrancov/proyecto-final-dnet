using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
using ProyectoFinal.Data;

namespace ProyectoFinal.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class EstatusPedidoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstatusPedidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EstatusPedido
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstatusPedido.ToListAsync());
        }

        // GET: EstatusPedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estatusPedido = await _context.EstatusPedido
                .FirstOrDefaultAsync(m => m.EstatusID == id);
            if (estatusPedido == null)
            {
                return NotFound();
            }

            return View(estatusPedido);
        }

        // GET: EstatusPedido/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstatusPedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstatusID,DescEstatus")] EstatusPedido estatusPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estatusPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estatusPedido);
        }

        // GET: EstatusPedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estatusPedido = await _context.EstatusPedido.FindAsync(id);
            if (estatusPedido == null)
            {
                return NotFound();
            }
            return View(estatusPedido);
        }

        // POST: EstatusPedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstatusID,DescEstatus")] EstatusPedido estatusPedido)
        {
            if (id != estatusPedido.EstatusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estatusPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstatusPedidoExists(estatusPedido.EstatusID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estatusPedido);
        }

        // GET: EstatusPedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estatusPedido = await _context.EstatusPedido
                .FirstOrDefaultAsync(m => m.EstatusID == id);
            if (estatusPedido == null)
            {
                return NotFound();
            }

            return View(estatusPedido);
        }

        // POST: EstatusPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estatusPedido = await _context.EstatusPedido.FindAsync(id);
            _context.EstatusPedido.Remove(estatusPedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstatusPedidoExists(int id)
        {
            return _context.EstatusPedido.Any(e => e.EstatusID == id);
        }
    }
}
