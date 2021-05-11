using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TallerMotos.Models;

namespace TallerMotos.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly Contexto _context;

        public EmpleadosController(Contexto context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleados.ToListAsync());
        }
        public async Task<IActionResult> ListadoEmpleados(string sql)
        {
            List<Empleados> lista = new List<Empleados>();
            using(DbCommand cn = _context.Database.GetDbConnection().CreateCommand())
            {
                cn.CommandText = "SELECT nombreEmpleado, apellidoEmpleado, telefono, direccion, ciudad, isActive FROM empleados ORDER BY apellidoEmpleado, nombreEmpleado";
                cn.CommandType = CommandType.Text;
                _context.Database.OpenConnection();
                using (DbDataReader dr = cn.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Empleados empleado = new Empleados();
                        empleado.nombreEmpleado = dr["nombreEmpleado"].ToString();
                        empleado.apellidoEmpleado = dr["apellidoEmpleado"].ToString();
                        empleado.telefono = dr["telefono"].ToString();
                        empleado.direccion = dr["direccion"].ToString();
                        empleado.ciudad = dr["ciudad"].ToString();
                        empleado.isActive = Int32.Parse(dr["isActive"].ToString());
                        lista.Add(empleado);
                    }
                }

            }
            return View(lista);
        }

        public async Task<IActionResult> ListadoEmpleadosDespedidos(string sql)
        {
            List<Empleados> lista = new List<Empleados>();
            using (DbCommand cn = _context.Database.GetDbConnection().CreateCommand())
            {
                cn.CommandText = "SELECT nombreEmpleado, apellidoEmpleado, telefono, direccion, ciudad, isActive FROM empleados WHERE isActive = 0 ORDER BY apellidoEmpleado, nombreEmpleado";
                cn.CommandType = CommandType.Text;
                _context.Database.OpenConnection();
                using (DbDataReader dr = cn.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Empleados empleado = new Empleados();
                        empleado.nombreEmpleado = dr["nombreEmpleado"].ToString();
                        empleado.apellidoEmpleado = dr["apellidoEmpleado"].ToString();
                        empleado.telefono = dr["telefono"].ToString();
                        empleado.direccion = dr["direccion"].ToString();
                        empleado.ciudad = dr["ciudad"].ToString();
                        empleado.isActive = Int32.Parse(dr["isActive"].ToString());
                        lista.Add(empleado);
                    }
                }

            }
            return View(lista);
        }
        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .FirstOrDefaultAsync(m => m.id == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }

            ViewBag.Taller = new SelectList(_context.Talleres, "ciudad", "ciudad", id);

            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Empleados empleados)
        {
            if (id != empleados.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosExists(empleados.id))
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
            ViewBag.Taller = new SelectList(_context.Talleres, "ciudad", "ciudad", id);

            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .FirstOrDefaultAsync(m => m.id == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleados = await _context.Empleados.FindAsync(id);
            _context.Empleados.Remove(empleados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosExists(int id)
        {
            return _context.Empleados.Any(e => e.id == id);
        }
    }
}
