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
    public class VentasLineasPagadasController : Controller
    {
        private readonly Contexto _context;
        private readonly ServicioSQL _sql;

        public VentasLineasPagadasController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }

        public IActionResult Index(string factura)
        {
            string sql = " SELECT cantidad, precio, idFactura, isPagado FROM ventasLineas " +
                " WHERE isPagado= 1 " + 
                ( factura != null && factura!= "" ? " AND idFactura = @idFactura" : "");

            MySqlParameter[] par =
            {
                new MySqlParameter("@idFactura", factura)
            };


            List<VentasLineasPagadas> lista = _sql.EjecutarSQL<VentasLineasPagadas>(
                   _context,
                   sql,
                   x => new VentasLineasPagadas()
                   {
                       cantidad = x.GetInt32(0),
                       precio = x.GetDecimal(1),
                       idFactura = x.GetInt32(2),
                       isPagado = x.GetBoolean(3)
                   },
                   par
               );

            ViewBag.VLPagada = new SelectList(_context.VentasLineas, "FacturasId", "FacturasId", factura);

            return View(lista);
        }
    }
}
