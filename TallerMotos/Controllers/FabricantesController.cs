using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using TallerMotos.Models;
using TallerMotos.Models.ViewData;

namespace TallerMotos.Controllers
{
    public class FabricantesController : Controller
    {
        private readonly Contexto _context;
        private readonly ServicioSQL _sql;

        public FabricantesController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }



        // GET: Fabricantes
        public IActionResult Index(string nombre)
        {
            string sql = " SELECT id, nombreFabricante, pais FROM Fabricantes  " +
                " WHERE 1 = 1 "
                + (nombre != null && nombre != "" ? " AND pais= @pais" : "");

            MySqlParameter[] par =
            {
                new MySqlParameter("@pais", nombre)
            };

            List<Fabricantes> lista = _sql.EjecutarSQL<Fabricantes>(
                _context, sql,
                x => new Fabricantes()
                {
                    id = x.GetInt32(0),
                    nombreFabricante = x.GetString(1),
                    pais = x.GetString(2)
                    
                },
                par
                );
            ViewBag.Pais = new SelectList(_context.Fabricantes.Select(x=>new Fabricantes() { pais=x.pais }).Distinct(), "pais", "pais", nombre);
            return View(lista);
        }
       

        // GET: Fabricantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fabricantes = await _context.Fabricantes
                .FirstOrDefaultAsync(m => m.id == id);
            if (fabricantes == null)
            {
                return NotFound();
            }

            return View(fabricantes);
        }

        // GET: Fabricantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fabricantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombreFabricante,pais")] Fabricantes fabricantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fabricantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fabricantes);
        }

        // GET: Fabricantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fabricantes = await _context.Fabricantes.FindAsync(id);
            if (fabricantes == null)
            {
                return NotFound();
            }
            return View(fabricantes);
        }

        // POST: Fabricantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombreFabricante,pais")] Fabricantes fabricantes)
        {
            if (id != fabricantes.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fabricantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FabricantesExists(fabricantes.id))
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
            return View(fabricantes);
        }

        // GET: Fabricantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fabricantes = await _context.Fabricantes
                .FirstOrDefaultAsync(m => m.id == id);
            if (fabricantes == null)
            {
                return NotFound();
            }

            return View(fabricantes);
        }

        // POST: Fabricantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fabricantes = await _context.Fabricantes.FindAsync(id);
            _context.Fabricantes.Remove(fabricantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FabricantesExists(int id)
        {
            return _context.Fabricantes.Any(e => e.id == id);
        }
    }
}
