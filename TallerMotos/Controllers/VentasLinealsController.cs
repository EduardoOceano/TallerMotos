using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerMotos.Models;

namespace TallerMotos.Controllers
{
    public class VentasLinealsController : Controller
    {
        private readonly Contexto _context;

        public VentasLinealsController(Contexto context)
        {
            _context = context;
        }

        // GET: VentasLineals
        public async Task<IActionResult> Index()
        {
            return View(await _context.VentasLineal.ToListAsync());
        }

        // GET: VentasLineals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasLineal = await _context.VentasLineal
                .FirstOrDefaultAsync(m => m.idVentaLineal == id);
            if (ventasLineal == null)
            {
                return NotFound();
            }

            return View(ventasLineal);
        }

        // GET: VentasLineals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VentasLineals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VentasLineal ventasLineal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventasLineal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventasLineal);
        }

        // GET: VentasLineals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasLineal = await _context.VentasLineal.FindAsync(id);
            if (ventasLineal == null)
            {
                return NotFound();
            }
            return View(ventasLineal);
        }

        // POST: VentasLineals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VentasLineal ventasLineal)
        {
            if (id != ventasLineal.idVentaLineal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventasLineal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasLinealExists(ventasLineal.idVentaLineal))
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
            return View(ventasLineal);
        }

        // GET: VentasLineals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasLineal = await _context.VentasLineal
                .FirstOrDefaultAsync(m => m.idVentaLineal == id);
            if (ventasLineal == null)
            {
                return NotFound();
            }

            return View(ventasLineal);
        }

        // POST: VentasLineals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventasLineal = await _context.VentasLineal.FindAsync(id);
            _context.VentasLineal.Remove(ventasLineal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentasLinealExists(int id)
        {
            return _context.VentasLineal.Any(e => e.idVentaLineal == id);
        }
    }
}
