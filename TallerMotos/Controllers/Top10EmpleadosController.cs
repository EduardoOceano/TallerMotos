using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TallerMotos;
using TallerMotos.Models;

namespace Top10Empleados.Controllers
{
    public class Top10EmpleadosController : Controller
    {

        private readonly Contexto _context;
        private readonly ServicioSQL _sql;

        public Top10EmpleadosController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }

        public IActionResult Index()
        {
            string sql = "SELECT nombreEmpleado, apellidoEmpleado, SUM(total) t FROM facturas f INNER JOIN empleados e ON(f.idEmpleado= e.idEmpleado) where e.isActive = 1 GROUP BY f.idEmpleado, e.nombreEmpleado ORDER BY t DESC LIMIT 10";
            List<TallerMotos.Models.ViewData.Top10Empleados> lista = _sql.EjecutarSQL<TallerMotos.Models.ViewData.Top10Empleados>(
                   _context,
                   sql,
                   x => new TallerMotos.Models.ViewData.Top10Empleados()
                   {
                       nombreEmpleado = x.GetString(0),
                       apellidoEmpleado = x.GetString(1),
                       t = x.GetDecimal(2),
                   }
               );

            return View(lista);
        }
    }
}

