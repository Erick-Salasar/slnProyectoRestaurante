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
    public class EstadoMesasController : Controller
    {
        private readonly SiteContext _context;

        public EstadoMesasController(SiteContext context)
        {
            _context = context;
        }

        // GET: EstadoMesas
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoMesas.ToListAsync());
        }

        // GET: EstadoMesas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoMesa = await _context.EstadoMesas
                .FirstOrDefaultAsync(m => m.IDEstado == id);
            if (estadoMesa == null)
            {
                return NotFound();
            }

            return View(estadoMesa);
        }

        // GET: EstadoMesas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoMesas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDEstado,Descripcion")] EstadoMesa estadoMesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoMesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoMesa);
        }

        // GET: EstadoMesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoMesa = await _context.EstadoMesas.FindAsync(id);
            if (estadoMesa == null)
            {
                return NotFound();
            }
            return View(estadoMesa);
        }

        // POST: EstadoMesas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDEstado,Descripcion")] EstadoMesa estadoMesa)
        {
            if (id != estadoMesa.IDEstado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoMesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoMesaExists(estadoMesa.IDEstado))
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
            return View(estadoMesa);
        }

        // GET: EstadoMesas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoMesa = await _context.EstadoMesas
                .FirstOrDefaultAsync(m => m.IDEstado == id);
            if (estadoMesa == null)
            {
                return NotFound();
            }

            return View(estadoMesa);
        }

        // POST: EstadoMesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoMesa = await _context.EstadoMesas.FindAsync(id);
            _context.EstadoMesas.Remove(estadoMesa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoMesaExists(int id)
        {
            return _context.EstadoMesas.Any(e => e.IDEstado == id);
        }
    }
}
