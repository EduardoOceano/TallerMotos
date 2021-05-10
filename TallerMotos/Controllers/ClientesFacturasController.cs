using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerMotos.Models;

namespace TallerMotos.Controllers
{
    public class ClientesFacturasController : Controller
    {
        private readonly Contexto _context;
        private readonly ServicioSQL _sql;

        public ClientesFacturasController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }

        public IActionResult Index()
        {
            string sql = "SELECT c.nombreCliente, SUM(f.total) total FROM clientes c INNER JOIN facturas f ON(c.idCliente = f.idCliente) ORDER BY f.total ASC LIMIT 10; ";
            List<Models.ViewData.ClientesFacturas> lista = _sql.EjecutarSQL<Models.ViewData.ClientesFacturas>(
                   _context,
                   sql,
                   x => new Models.ViewData.ClientesFacturas()
                   {
                       total = x.GetDecimal(1),
                       nombreCliente = x.GetString(0)
                   }
               );
            return View(lista);
        }
    }
}
