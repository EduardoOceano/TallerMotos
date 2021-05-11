using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerMotos.Models;

namespace TallerMotos.Controllers
{
    public class MotosClientesController : Controller
    {
        private readonly Contexto _context;
        private readonly ServicioSQL _sql;

        public MotosClientesController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }

        public IActionResult Index()
        {
            string sql = "SELECT m.modelo, m.marca, c.idCliente, c.NombreCliente FROM motos m" +
                "INNER JOIN clientes c ON (c.idCliente=m.idCliente)" +
                "WHERE m.idCliente = c.idCliente";
            List<Models.ViewData.MotosClientes> lista = _sql.EjecutarSQL<Models.ViewData.MotosClientes>(
                   _context,
                   sql,
                   x => new Models.ViewData.MotosClientes()
                   {
                       modelo = x.GetString(0),
                       marca = x.GetString(1),
                       nombreCliente = x.GetString(3)
                   }
               ); 
            return View(lista);
        }
    }
}
