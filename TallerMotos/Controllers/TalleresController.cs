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
    public class TalleresController : Controller
    {
        private readonly Contexto _context;

        public TalleresController(Contexto context)
        {
            _context = context;
        }

        // GET: Talleres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Talleres.ToListAsync());
        }

        // GET: Talleres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talleres = await _context.Talleres
                .FirstOrDefaultAsync(m => m.id == id);
            if (talleres == null)
            {
                return NotFound();
            }

            return View(talleres);
        }

        // GET: Talleres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Talleres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Talleres talleres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(talleres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(talleres);
        }

        // GET: Talleres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var facturas = await _context.Facturas.FindAsync(id);
            var talleres = _context.Talleres.Include("Empleados").Where(x => x.id == id).FirstOrDefault();
            if (talleres == null)
            {
                return NotFound();
            }
            return View(talleres);
        }


        // POST: Talleres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Talleres talleres)
        {
            if (id != talleres.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talleres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TalleresExists(talleres.id))
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
            return View(talleres);
        }

        // GET: Talleres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talleres = await _context.Talleres
                .FirstOrDefaultAsync(m => m.id == id);
            if (talleres == null)
            {
                return NotFound();
            }

            return View(talleres);
        }

        // POST: Talleres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var talleres = await _context.Talleres.FindAsync(id);
            _context.Talleres.Remove(talleres);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TalleresExists(int id)
        {
            return _context.Talleres.Any(e => e.id == id);
        }
    }
}
