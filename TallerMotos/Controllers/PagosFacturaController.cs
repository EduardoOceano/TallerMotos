using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerMotos.Models;
using TallerMotos.Models.ViewData;

namespace TallerMotos.Controllers
{
    public class PagosFacturaController : Controller
    {

        private readonly Contexto _context;
        private readonly ServicioSQL _sql;

        public PagosFacturaController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }

        public IActionResult Index(string factura)
        {
            string sql = " SELECT p.* FROM Pagos p " +
                " INNER JOIN Facturas f on (f.idFactura=p.id_factura) " +
                " WHERE 1 = 1 " + (factura != null && factura != "" ? " AND f.idFactura = @id_factura" : "");

            MySqlParameter[] parametros =
            {
                new MySqlParameter("@id_factura", factura)
            };

            List<PagosFactura> lista = _sql.EjecutarSQL<PagosFactura>(
                _context,
                sql,
                x => new PagosFactura()
                {
                    id_factura = x.GetInt32(0),
                    importe = x.GetDecimal(1),
                    fechaPago = x.GetDateTime(2)
                },
                parametros
                );

            ViewBag.Factura = new SelectList(_context.Facturas, "id", "id", factura);
            return View(lista);
        }
    }
}
