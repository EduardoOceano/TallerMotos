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

        public IActionResult Index(string taller)
        {

            string sql = " SELECT DISTINCT f.idFactura, c.nombreCliente, t.idTaller, t.ciudad" +
                " FROM facturas f" +
                " INNER JOIN talleres t ON (t.idTaller=f.idTaller) " + 
                " INNER JOIN clientes c on (f.idCliente=c.idCliente) " + 
                " WHERE 1=1"+ (taller !=null && taller!="" ? " AND t.ciudad LIKE @ciudad " : "") ;

            MySqlParameter[] parametros =
            {
                
                new MySqlParameter("@ciudad", taller)
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
                       
            ViewBag.Taller = new SelectList(_context.Talleres, "ciudad", "ciudad", taller);
           
            return View(lista);
        }
    }
}
