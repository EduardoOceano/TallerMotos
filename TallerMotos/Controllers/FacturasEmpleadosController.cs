using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using TallerMotos.Models;
using TallerMotos.Models.ViewData;

namespace TallerMotos.Controllers
{
    public class FacturasEmpleadosController : Controller
    {
        private readonly Contexto _context;
        private readonly ServicioSQL _sql;
        public FacturasEmpleadosController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }
        public IActionResult Index(string nombreEmpleado)
        {
            string sql = " SELECT f.idFactura, f.total, e.idEmpleado, e.NombreEmpleado" +
                " FROM facturas f" +
                " INNER JOIN empleados e ON (e.idEmpleado=f.idEmpleado) " +
                " WHERE 1=1" + (nombreEmpleado != null && nombreEmpleado != "" ? " AND e.nombreEmpleado LIKE @empleado " : "");

            MySqlParameter[] parametros =
            {

                new MySqlParameter("@empleado", nombreEmpleado)
            };

            List<FacturasEmpleados> lista = _sql.EjecutarSQL<FacturasEmpleados>(
                _context, sql,
                x => new FacturasEmpleados()
                {
                    idFactura = x.GetInt32(0),
                    total = x.GetDecimal(1),
                    idEmpleado = x.GetInt32(2),
                    nombreEmpleado = x.GetString(3)
                },
                parametros
                );

            ViewBag.Empleado = new SelectList(_context.Empleados, "nombreEmpleado", "nombreEmpleado", nombreEmpleado);

            return View(lista);
        }
    }
}
