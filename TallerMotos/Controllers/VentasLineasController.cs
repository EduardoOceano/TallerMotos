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
    public class VentasLineasController : Controller
    {
        private readonly Contexto _context;

        public VentasLineasController(Contexto context)
        {
            _context = context;
        }

        // GET: VentasLineass
        public async Task<IActionResult> Index()
        {
            return View(await _context.VentasLineas.Include("Producto").ToListAsync());
        }

        // GET: VentasLineass/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var VentasLineas = _context.VentasLineas.Include("Producto").Where(x => x.id == id)
                .FirstOrDefault();
            if (VentasLineas == null)
            {
                return NotFound();
            }

            return View(VentasLineas);
        }

        // GET: VentasLineass/Create
        public IActionResult Create(int? idFactura)
        {
            //ViewData["VentasLineal"] = _context.VentasLineal.Where(x => x.idFactura == ventaId).FirstOrDefault();
            ViewBag.Producto = new SelectList(_context.Productos.Select(x => new Productos() { tipo = x.tipo }).Distinct(), "id", "tipo");
            ViewBag.Factura = idFactura;
            ViewBag.Servicio = new SelectList(_context.Servicios, "id", "tipo");
            return View();
        }

        // POST: VentasLineass/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VentasLineas VentasLineas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(VentasLineas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(VentasLineas);
        }

        // GET: VentasLineass/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var VentasLineas = await _context.VentasLineas.FindAsync(id);
            if (VentasLineas == null)
            {
                return NotFound();
            }

            ViewBag.Productos = new SelectList(_context.Productos, "tipo", "tipo", id);
            ViewBag.Servicios = new SelectList(_context.Servicios, "tipo", "tipo", id);

            return View(VentasLineas);
        }

        // POST: VentasLineass/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VentasLineas VentasLineas)
        {
            if (id != VentasLineas.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(VentasLineas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasLineasExists(VentasLineas.id))
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

            ViewBag.Productos = new SelectList(_context.Productos, "tipo", "tipo", id);
            ViewBag.Servicios = new SelectList(_context.Servicios, "tipo", "tipo", id);

            return View(VentasLineas);
        }

        // GET: VentasLineass/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var VentasLineas = await _context.VentasLineas
                .FirstOrDefaultAsync(m => m.id == id);
            if (VentasLineas == null)
            {
                return NotFound();
            }

            return View(VentasLineas);
        }

        // POST: VentasLineass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var VentasLineas = await _context.VentasLineas.FindAsync(id);
            _context.VentasLineas.Remove(VentasLineas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentasLineasExists(int id)
        {
            return _context.VentasLineas.Any(e => e.id == id);
        }
    }
}
