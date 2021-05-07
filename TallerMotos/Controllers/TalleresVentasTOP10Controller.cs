using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerMotos.Models;

namespace TallerMotos.Controllers
{
    public class TalleresVentasTOP10Controller : Controller
    {
        private readonly Contexto _context;
        private readonly ServicioSQL _sql;

        public TalleresVentasTOP10Controller(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }

        public IActionResult Index()
        {
            string sql = "SELECT t.idTaller, t.ciudad, SUM(total) total FROM talleres t INNER JOIN facturas f ON(f.idTaller = t.idTaller) GROUP BY t.idTaller ORDER BY total DESC LIMIT 10";
            List<TallerMotos.Models.ViewData.TalleresVentasTOP10> lista = _sql.EjecutarSQL<TallerMotos.Models.ViewData.TalleresVentasTOP10>(
                   _context,
                   sql,
                   x => new TallerMotos.Models.ViewData.TalleresVentasTOP10()
                   {
                       idTaller = x.GetInt32(0),
                       ciudad = x.GetString(1),
                       total = x.GetDecimal(2),
                   }
               );

            return View(lista);
        }
    }
}
