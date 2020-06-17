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
    public class InventarioIngredientesController : Controller
    {
        private readonly SiteContext _context;

        public InventarioIngredientesController(SiteContext context)
        {
            _context = context;
        }

        // GET: InventarioIngredientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventarioIngredientes.ToListAsync());
        }

        // GET: InventarioIngredientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioIngrediente = await _context.InventarioIngredientes
                .FirstOrDefaultAsync(m => m.IDInventarioIngre == id);
            if (inventarioIngrediente == null)
            {
                return NotFound();
            }

            return View(inventarioIngrediente);
        }

        // GET: InventarioIngredientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventarioIngredientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDInventarioIngre,Cantidad,CantidadMinima")] InventarioIngrediente inventarioIngrediente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventarioIngrediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventarioIngrediente);
        }

        // GET: InventarioIngredientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioIngrediente = await _context.InventarioIngredientes.FindAsync(id);
            if (inventarioIngrediente == null)
            {
                return NotFound();
            }
            return View(inventarioIngrediente);
        }

        // POST: InventarioIngredientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDInventarioIngre,Cantidad,CantidadMinima")] InventarioIngrediente inventarioIngrediente)
        {
            if (id != inventarioIngrediente.IDInventarioIngre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventarioIngrediente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioIngredienteExists(inventarioIngrediente.IDInventarioIngre))
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
            return View(inventarioIngrediente);
        }

        // GET: InventarioIngredientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioIngrediente = await _context.InventarioIngredientes
                .FirstOrDefaultAsync(m => m.IDInventarioIngre == id);
            if (inventarioIngrediente == null)
            {
                return NotFound();
            }

            return View(inventarioIngrediente);
        }

        // POST: InventarioIngredientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventarioIngrediente = await _context.InventarioIngredientes.FindAsync(id);
            _context.InventarioIngredientes.Remove(inventarioIngrediente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioIngredienteExists(int id)
        {
            return _context.InventarioIngredientes.Any(e => e.IDInventarioIngre == id);
        }
    }
}
