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
    public class MotosController : Controller
    {
        private readonly Contexto _context;

        public MotosController(Contexto context)
        {
            _context = context;
        }

        // GET: Motos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Motos.ToListAsync());
        }

        // GET: Motos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motos = await _context.Motos
                .FirstOrDefaultAsync(m => m.idMoto == id);
            if (motos == null)
            {
                return NotFound();
            }

            return View(motos);
        }

        // GET: Motos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Motos motos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motos);
        }

        // GET: Motos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motos = await _context.Motos.FindAsync(id);
            if (motos == null)
            {
                return NotFound();
            }
            return View(motos);
        }

        // POST: Motos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Motos motos)
        {
            if (id != motos.idMoto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotosExists(motos.idMoto))
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
            return View(motos);
        }

        // GET: Motos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motos = await _context.Motos
                .FirstOrDefaultAsync(m => m.idMoto == id);
            if (motos == null)
            {
                return NotFound();
            }

            return View(motos);
        }

        // POST: Motos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motos = await _context.Motos.FindAsync(id);
            _context.Motos.Remove(motos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotosExists(int id)
        {
            return _context.Motos.Any(e => e.idMoto == id);
        }
    }
}
