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
    public class ReservaMesasController : Controller
    {
        private readonly SiteContext _context;

        public ReservaMesasController(SiteContext context)
        {
            _context = context;
        }

        // GET: ReservaMesas
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReservaMesas.ToListAsync());
        }

        // GET: ReservaMesas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaMesa = await _context.ReservaMesas
                .FirstOrDefaultAsync(m => m.IDReservaMesa == id);
            if (reservaMesa == null)
            {
                return NotFound();
            }

            return View(reservaMesa);
        }

        // GET: ReservaMesas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReservaMesas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDReservaMesa,Nombre,Telefono,HoraReserva")] ReservaMesa reservaMesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaMesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservaMesa);
        }

        // GET: ReservaMesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaMesa = await _context.ReservaMesas.FindAsync(id);
            if (reservaMesa == null)
            {
                return NotFound();
            }
            return View(reservaMesa);
        }

        // POST: ReservaMesas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDReservaMesa,Nombre,Telefono,HoraReserva")] ReservaMesa reservaMesa)
        {
            if (id != reservaMesa.IDReservaMesa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaMesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaMesaExists(reservaMesa.IDReservaMesa))
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
            return View(reservaMesa);
        }

        // GET: ReservaMesas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaMesa = await _context.ReservaMesas
                .FirstOrDefaultAsync(m => m.IDReservaMesa == id);
            if (reservaMesa == null)
            {
                return NotFound();
            }

            return View(reservaMesa);
        }

        // POST: ReservaMesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaMesa = await _context.ReservaMesas.FindAsync(id);
            _context.ReservaMesas.Remove(reservaMesa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaMesaExists(int id)
        {
            return _context.ReservaMesas.Any(e => e.IDReservaMesa == id);
        }
    }
}
