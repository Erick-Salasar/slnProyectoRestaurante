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
    public class FacturasController : Controller
    {
        private readonly SiteContext _context;

        public FacturasController(SiteContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var siteContext = _context.Facturas.Include(f => f.Orden).Include(f => f.Persona);
            return View(await siteContext.ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.Orden)
                .Include(f => f.Persona)
                .FirstOrDefaultAsync(m => m.IDFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            ViewData["IDOrden"] = new SelectList(_context.Ordenes, "IDOrden", "IDOrden");
            ViewData["IDPersona"] = new SelectList(_context.Personas, "IDPersona", "IDPersona");
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDFactura,FechaFactura,IDPersona,EstadoDeFactura,Observacion,IDOrden")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDOrden"] = new SelectList(_context.Ordenes, "IDOrden", "IDOrden", factura.IDOrden);
            ViewData["IDPersona"] = new SelectList(_context.Personas, "IDPersona", "IDPersona", factura.IDPersona);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["IDOrden"] = new SelectList(_context.Ordenes, "IDOrden", "IDOrden", factura.IDOrden);
            ViewData["IDPersona"] = new SelectList(_context.Personas, "IDPersona", "IDPersona", factura.IDPersona);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDFactura,FechaFactura,IDPersona,EstadoDeFactura,Observacion,IDOrden")] Factura factura)
        {
            if (id != factura.IDFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.IDFactura))
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
            ViewData["IDOrden"] = new SelectList(_context.Ordenes, "IDOrden", "IDOrden", factura.IDOrden);
            ViewData["IDPersona"] = new SelectList(_context.Personas, "IDPersona", "IDPersona", factura.IDPersona);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.Orden)
                .Include(f => f.Persona)
                .FirstOrDefaultAsync(m => m.IDFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
            return _context.Facturas.Any(e => e.IDFactura == id);
        }
    }
}
