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
    public class FacturasController : Controller
    {
        private readonly Contexto _context;

        public FacturasController(Contexto context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index(int idFactura, bool? FacturaPagada)
        {
            ViewBag.Factura = new SelectList(_context.Facturas, "id", "id");
            return PartialView(await _context.Facturas.Include("Cliente")
                .Include("Empleado").ToListAsync());
        }


        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(int? idFactura)
        {
            if (idFactura == null)
            {
                return NotFound();
            }

            var facturas = await _context.Facturas.Include("VentasLineas").Include("Cliente").Include("Empleado")
                
                .FirstOrDefaultAsync(m => m.id == idFactura);
            if (facturas == null)
            {
                return NotFound();
            }

            return PartialView(facturas);
        }

        // GET: Facturas/Create
        public IActionResult Create(int idTaller)
        {
            Facturas f = new Facturas();
            f.idTaller = idTaller;
            return PartialView(f);
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facturas);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(int? idFactura)
        {
            if (idFactura == null)
            {
                return NotFound();
            }

            //var facturas = await _context.Facturas.FindAsync(id);
            var facturas = _context.Facturas.Include("VentasLineas").Include("VentasLineas.Producto").Where(x => x.id == idFactura).FirstOrDefault();
            if (facturas == null)
            {
                return NotFound();
            }

            ViewBag.Empleado = new SelectList(_context.Empleados, "id", "nombreEmpleado");

            ViewBag.Cliente = new SelectList(_context.Clientes, "id", "nombreCliente");

            return PartialView(facturas);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Facturas facturas)
        {
            if (id != facturas.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturasExists(facturas.id))
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

            ViewBag.Empleado = new SelectList(_context.Empleados, "id", "nombreEmpleado", id);

            ViewBag.Cliente = new SelectList(_context.Clientes, "id", "nombreCliente", id);

            return PartialView(facturas);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(int? idFactura)
        {
            if (idFactura == null)
            {
                return NotFound();
            }

            var facturas = await _context.Facturas.Include("VentasLineas")
                .FirstOrDefaultAsync(m => m.id == idFactura);
            if (facturas == null)
            {
                return NotFound();
            }

            ViewBag.Empleado = new SelectList(_context.Empleados, "id", "nombreEmpleado", idFactura);

            ViewBag.Cliente = new SelectList(_context.Clientes, "id", "nombreCliente", idFactura);

            return PartialView(facturas);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturas = await _context.Facturas.FindAsync(id);
            _context.Facturas.Remove(facturas);
            await _context.SaveChangesAsync();

            ViewBag.Empleado = new SelectList(_context.Empleados, "id", "nombreEmpleado", id);

            ViewBag.Cliente = new SelectList(_context.Clientes, "id", "nombreCliente", id);

            return RedirectToAction(nameof(Index));
        }

        private bool FacturasExists(int id)
        {
            return _context.Facturas.Any(e => e.id == id);
        }
    }
}
