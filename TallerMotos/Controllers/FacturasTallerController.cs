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
    public class FacturasTallerController : Controller
    {
        private readonly Contexto _context;
        private readonly ServicioSQL _sql;

        public FacturasTallerController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }

        public IActionResult Index(FacturasTaller t)
        {

            string sql = " SELECT f.idFactura, c.nombreCliente, t.idTaller, t.ciudad" +
                " FROM facturas f" +
                " INNER JOIN talleres t ON (t.idTaller=f.idTaller) " + 
                " INNER JOIN clientes c on (f.idCliente=c.idCliente) " + 
                " WHERE 1=1"+ (t.ciudad!=null ? " AND t.ciudad=@ciudad " : "") ;

            MySqlParameter[] parametros =
            {
                new MySqlParameter("@idFactura", t.idFactura),
                new MySqlParameter("@nombreCliente", t.nombreCliente),
                new MySqlParameter("@idTaller", t.idTaller),
                new MySqlParameter("@ciudad", t.ciudad)
            };

            List<FacturasTaller> lista = _sql.EjecutarSQL<FacturasTaller>(
                _context, sql,
                x => new FacturasTaller()
                {
                    idFactura = x.GetInt32(0),
                    nombreCliente = x.GetString(1),
                    idTaller = x.GetInt32(2),
                    ciudad = x.GetString(3)
                },
                parametros
                );

            ViewBag.Facturas = t.idFactura;
            ViewBag.Taller = t.ciudad;
            ViewBag.Cliente = t.nombreCliente;

            return View(lista);
        }
    }
}
