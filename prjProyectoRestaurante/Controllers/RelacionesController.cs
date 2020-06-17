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
    public class RelacionesController : Controller
    {
        private readonly SiteContext _context;

        public RelacionesController(SiteContext context)
        {
            _context = context;
        }

        // GET: Relaciones
        public async Task<IActionResult> Index()
        {
            var siteContext = _context.Relaciones.Include(r => r.Persona);
            return View(await siteContext.ToListAsync());
        }

        // GET: Relaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relacion = await _context.Relaciones
                .Include(r => r.Persona)
                .FirstOrDefaultAsync(m => m.IDRelacion == id);
            if (relacion == null)
            {
                return NotFound();
            }

            return View(relacion);
        }

        // GET: Relaciones/Create
        public IActionResult Create()
        {
            ViewData["IDPersona"] = new SelectList(_context.Personas, "IDPersona", "IDPersona");
            return View();
        }

        // POST: Relaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDRelacion,Descripcion,IDPersona")] Relacion relacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDPersona"] = new SelectList(_context.Personas, "IDPersona", "IDPersona", relacion.IDPersona);
            return View(relacion);
        }

        // GET: Relaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relacion = await _context.Relaciones.FindAsync(id);
            if (relacion == null)
            {
                return NotFound();
            }
            ViewData["IDPersona"] = new SelectList(_context.Personas, "IDPersona", "IDPersona", relacion.IDPersona);
            return View(relacion);
        }

        // POST: Relaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDRelacion,Descripcion,IDPersona")] Relacion relacion)
        {
            if (id != relacion.IDRelacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelacionExists(relacion.IDRelacion))
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
            ViewData["IDPersona"] = new SelectList(_context.Personas, "IDPersona", "IDPersona", relacion.IDPersona);
            return View(relacion);
        }

        // GET: Relaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relacion = await _context.Relaciones
                .Include(r => r.Persona)
                .FirstOrDefaultAsync(m => m.IDRelacion == id);
            if (relacion == null)
            {
                return NotFound();
            }

            return View(relacion);
        }

        // POST: Relaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relacion = await _context.Relaciones.FindAsync(id);
            _context.Relaciones.Remove(relacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelacionExists(int id)
        {
            return _context.Relaciones.Any(e => e.IDRelacion == id);
        }
    }
}
