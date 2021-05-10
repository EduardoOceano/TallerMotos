using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerMotos.Models;

namespace TallerMotos.Controllers
{
    public class PublicidadProductosController : Controller
    {
        private readonly Contexto _context;
        private readonly ServicioSQL _sql;

        public PublicidadProductosController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }

        public IActionResult Index()
        {
            string sql = "SELECT pu.fechaInicio, pu.fechaFinal,(pr.precio-pu.descuento*pr.precio/100) descuento,pu.descuento, pr.tipo, pr.fabricante FROM publicidad pu INNER JOIN productos pr ON(pu.idProducto = pr.idProducto)";

            List<Models.ViewData.PublicidadProductos> lista = _sql.EjecutarSQL<Models.ViewData.PublicidadProductos>(
                _context, sql,
                x => new Models.ViewData.PublicidadProductos()
                {
                    fechaInicio = x.GetDateTime(0),
                    fechaFinal = x.GetDateTime(1),
                    precio = x.GetDecimal(2),
                    descuento = x.GetInt32(3),
                    tipo = x.GetString(4),
                    fabricante = x.GetString(5),
                }
                );

            return View(lista);
        }
    }
}
