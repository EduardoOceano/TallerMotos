using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using TallerMotos;
using TallerMotos.Models;
using TallerMotos.Models.ViewData;

namespace Top10Empleados.Controllers
{
    public class ClientesTalleresController : Controller
    {

        private readonly Contexto _context;
        private readonly ServicioSQL _sql;

        public ClientesTalleresController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }

        public IActionResult Index(string taller)
        {
            string sql = "SELECT DISTINCT ifnull(c.NombreCliente,''), ifnull(c.apellidosCliente, ''),  ifnull(t.idTaller, 0), ifnull(t.ciudad, '') "+
            " FROM clientes c"+
            " INNER JOIN facturas f ON(c.idCliente = f.idCliente)" +
            " INNER JOIN talleres t ON(t.idTaller = f.idTaller)"+
            " WHERE 1=1" + (taller != null && taller != "" ? " AND t.ciudad=@ciudad " : "");


            MySqlParameter[] parametros =
            {

                new MySqlParameter("@ciudad", taller)
            };


            List<ClientesTalleres> lista = _sql.EjecutarSQL<ClientesTalleres>(
                   _context,
                   sql,
                   x => new ClientesTalleres()
                   {
                       nombreCliente = x.GetString(0),
                       apellidoCliente = x.GetString(1),
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


