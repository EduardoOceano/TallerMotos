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
    public class MotosClientesParamController : Controller
    {
        private readonly Contexto _context;
        private readonly ServicioSQL _sql;

        public MotosClientesParamController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }

        public IActionResult Index(string nombre)
        {
            string sql = " SELECT m.modelo, m.marca, c.idCliente, c.NombreCliente FROM motos m " +
                " INNER JOIN clientes c on (c.idCliente=m.idCliente) " +
                " WHERE 1 = 1 "
                + (nombre != null && nombre != "" ? " AND c.nombreCliente= @nombreCliente " : "" );

            MySqlParameter[] par =
            {
                new MySqlParameter("@nombreCliente", nombre)
            };

            List<MotosClientesParam> lista = _sql.EjecutarSQL<MotosClientesParam>(
                _context, sql,
                x => new MotosClientesParam()
                {
                    idCliente = x.GetInt32(2),
                    modelo = x.GetString(0),
                    marca = x.GetString(1),
                    nombreCliente = x.GetString(3)
                },
                par
                );

            ViewBag.Cliente = new SelectList(_context.Clientes, "nombreCliente", "nombreCliente", nombre);

            return View(lista);
        }
    }
}
