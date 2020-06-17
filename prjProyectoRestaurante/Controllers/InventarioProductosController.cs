using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prjProyectoRestaurante.Data;
using prjProyectoRestaurante.Models;

namespace prjProyectoRestaurante.Controllers
{
    public class InventarioProductosController : Controller
    {
        private readonly SiteContext _context;

        public InventarioProductosController(SiteContext context)
        {
            _context = context;
        }

        // GET: InventarioProductos
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventarioProdus.ToListAsync());
        }

        // GET: InventarioProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioProdu = await _context.InventarioProdus
                .FirstOrDefaultAsync(m => m.IDIventaarioProdu == id);
            if (inventarioProdu == null)
            {
                return NotFound();
            }

            return View(inventarioProdu);
        }

        // GET: InventarioProductos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventarioProductos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDIventaarioProdu,Cantidad,CantidadMinima")] InventarioProdu inventarioProdu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventarioProdu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventarioProdu);
        }

        // GET: InventarioProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioProdu = await _context.InventarioProdus.FindAsync(id);
            if (inventarioProdu == null)
            {
                return NotFound();
            }
            return View(inventarioProdu);
        }

        // POST: InventarioProductos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDIventaarioProdu,Cantidad,CantidadMinima")] InventarioProdu inventarioProdu)
        {
            if (id != inventarioProdu.IDIventaarioProdu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventarioProdu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioProduExists(inventarioProdu.IDIventaarioProdu))
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
            return View(inventarioProdu);
        }

        // GET: InventarioProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioProdu = await _context.InventarioProdus
                .FirstOrDefaultAsync(m => m.IDIventaarioProdu == id);
            if (inventarioProdu == null)
            {
                return NotFound();
            }

            return View(inventarioProdu);
        }

        // POST: InventarioProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventarioProdu = await _context.InventarioProdus.FindAsync(id);
            _context.InventarioProdus.Remove(inventarioProdu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioProduExists(int id)
        {
            return _context.InventarioProdus.Any(e => e.IDIventaarioProdu == id);
        }
    }
}
