﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerMotos.Models;
using TallerMotos.Models.ViewData;

namespace TallerMotos.Controllers
{
    public class FabricantesController : Controller
    {
        private readonly Contexto _context;

        public FabricantesController(Contexto context)
        {
            _context = context;
        }

        // GET: Fabricantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fabricantes.ToListAsync());
        }
        public async Task<IActionResult> ListadoFabricantes()
        {
            return View(await _context.Fabricantes.ToListAsync());
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
