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
    public class FacturasPagadasController : Controller
    {
        private readonly Contexto _context;
        private readonly ServicioSQL _sql;

        public FacturasPagadasController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }

        public IActionResult Index(string factura)
        {
            string sql = " SELECT idFactura, idCliente, total, isPagado FROM facturas " +
                " WHERE isPagado= 1 " + 
                ( factura != null && factura!= "" ? " AND idFactura = @idFactura" : "");

            MySqlParameter[] par =
            {
                new MySqlParameter("@idFactura", factura)
            };


            List<FacturasPagadas> lista = _sql.EjecutarSQL<FacturasPagadas>(
                   _context,
                   sql,
                   x => new FacturasPagadas()
                   {                       
                       idFactura = x.GetInt32(0),
                       idCliente = x.GetInt32(1),
                       total = x.GetInt32(2),
                       isPagado = x.GetBoolean(3)
                   },
                   par
               );

            ViewBag.VLPagada = new SelectList(_context.Facturas, "id", "id", factura);

            return View(lista);
        }
    }
}
