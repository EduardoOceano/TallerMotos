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
    public class PublicidadController : Controller
    {
        private readonly Contexto _context;

        private readonly ServicioSQL _sql;

        public PublicidadController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }



        // GET: Publicidads
       
            public async Task<IActionResult> Index( int? idDescuento)
        {
            if (idDescuento != null)
            {
                return PartialView(await _context.Publicidad.Where(x => x.id == idDescuento).ToListAsync());
            }
            return PartialView(await _context.Publicidad.ToListAsync());
        }
        

        // GET: Publicidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicidad = await _context.Publicidad.Include("producto")
                .FirstOrDefaultAsync(m => m.id == id);
            if (publicidad == null)
            {
                return NotFound();
            }

            return View(publicidad);
        }

        // GET: Publicidads/Create
        public IActionResult Create()
        {
            ViewBag.Producto = new SelectList(_context.Productos.Select(x => new Productos() { id = x.id, tipo = x.tipo + "-" + x.id }).Distinct(), "id", "tipo");
            ViewBag.Descuento = new SelectList(_context.Publicidad, "descuento", "descuento");
            return View();
        }

        // POST: Publicidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Publicidad publicidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Descuento = new SelectList(_context.Publicidad, "descuento", "descuento");
            return View(publicidad);
        }

        // GET: Publicidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicidad = await _context.Publicidad.FindAsync(id);
            if (publicidad == null)
            {
                return NotFound();
            }

            ViewBag.Producto = new SelectList(_context.Productos.Select(x => new Productos() { tipo = x.tipo }).Distinct(), "tipo", "tipo");
            ViewBag.Descuento = new SelectList(_context.Publicidad, "descuento", "descuento");

            return View(publicidad);
        }

        // POST: Publicidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Publicidad publicidad)
        {
            if (id != publicidad.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicidadExists(publicidad.id))
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

            ViewBag.Producto = new SelectList(_context.Productos, "id", "id", id);
            ViewBag.Descuento = new SelectList(_context.Publicidad, "descuento", "descuento", id);

            return View(publicidad);
        }

        // GET: Publicidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicidad = await _context.Publicidad.Include("producto")
                .FirstOrDefaultAsync(m => m.id == id);
            if (publicidad == null)
            {
                return NotFound();
            }

            return View(publicidad);
        }

        // POST: Publicidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publicidad = await _context.Publicidad.FindAsync(id);
            _context.Publicidad.Remove(publicidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicidadExists(int id)
        {
            return _context.Publicidad.Any(e => e.id == id);
        }
    }
}
