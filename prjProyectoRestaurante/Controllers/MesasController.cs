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
    public class MesasController : Controller
    {
        private readonly SiteContext _context;

        public MesasController(SiteContext context)
        {
            _context = context;
        }

        // GET: Mesas
        public async Task<IActionResult> Index()
        {
            var siteContext = _context.Mesas.Include(m => m.EstadoMesa).Include(m => m.ReservaMesa);
            return View(await siteContext.ToListAsync());
        }

        // GET: Mesas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesa = await _context.Mesas
                .Include(m => m.EstadoMesa)
                .Include(m => m.ReservaMesa)
                .FirstOrDefaultAsync(m => m.IDMesa == id);
            if (mesa == null)
            {
                return NotFound();
            }

            return View(mesa);
        }

        // GET: Mesas/Create
        public IActionResult Create()
        {
            ViewData["IDEstado"] = new SelectList(_context.EstadoMesas, "IDEstado", "IDEstado");
            ViewData["IDReservaMesa"] = new SelectList(_context.ReservaMesas, "IDReservaMesa", "IDReservaMesa");
            return View();
        }

        // POST: Mesas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDMesa,NumeroMesa,IDEstado,IDReservaMesa")] Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDEstado"] = new SelectList(_context.EstadoMesas, "IDEstado", "IDEstado", mesa.IDEstado);
            ViewData["IDReservaMesa"] = new SelectList(_context.ReservaMesas, "IDReservaMesa", "IDReservaMesa", mesa.IDReservaMesa);
            return View(mesa);
        }

        // GET: Mesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesa = await _context.Mesas.FindAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }
            ViewData["IDEstado"] = new SelectList(_context.EstadoMesas, "IDEstado", "IDEstado", mesa.IDEstado);
            ViewData["IDReservaMesa"] = new SelectList(_context.ReservaMesas, "IDReservaMesa", "IDReservaMesa", mesa.IDReservaMesa);
            return View(mesa);
        }

        // POST: Mesas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDMesa,NumeroMesa,IDEstado,IDReservaMesa")] Mesa mesa)
        {
            if (id != mesa.IDMesa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MesaExists(mesa.IDMesa))
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
            ViewData["IDEstado"] = new SelectList(_context.EstadoMesas, "IDEstado", "IDEstado", mesa.IDEstado);
            ViewData["IDReservaMesa"] = new SelectList(_context.ReservaMesas, "IDReservaMesa", "IDReservaMesa", mesa.IDReservaMesa);
            return View(mesa);
        }

        // GET: Mesas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesa = await _context.Mesas
                .Include(m => m.EstadoMesa)
                .Include(m => m.ReservaMesa)
                .FirstOrDefaultAsync(m => m.IDMesa == id);
            if (mesa == null)
            {
                return NotFound();
            }

            return View(mesa);
        }

        // POST: Mesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mesa = await _context.Mesas.FindAsync(id);
            _context.Mesas.Remove(mesa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MesaExists(int id)
        {
            return _context.Mesas.Any(e => e.IDMesa == id);
        }
    }
}
