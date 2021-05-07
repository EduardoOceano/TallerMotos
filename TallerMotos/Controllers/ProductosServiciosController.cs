using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerMotos.Models;

namespace TallerMotos.Controllers
{
    public class ProductosServiciosController : Controller
    {
        private readonly Contexto _context;
        private readonly ServicioSQL _sql;

        public ProductosServiciosController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }

        public IActionResult Index()
        {
            string sql = "SELECT 'Servicio', s.tipo, s.descripcion, s.precio, c.NombreCliente, YEAR(f.fecha) ano FROM servicios s INNER JOIN ventaslineas v ON(v.idServicio= s.idServicio) INNER JOIN facturas f ON(f.idFactura = v.idFactura) INNER JOIN clientes c ON(c.idCliente = f.idCliente) GROUP BY YEAR(f.fecha) UNION ALL SELECT 'Productos',p.tipo, p.descripcion, p.precio, c.NombreCliente, YEAR(f.fecha) fecha FROM productos p INNER JOIN ventaslineas v ON(p.idProducto = v.idProducto) INNER JOIN facturas f ON(v.idFactura = f.idFactura) INNER JOIN clientes c ON(f.idCliente = c.idCliente) GROUP BY YEAR(f.fecha)";
            List<TallerMotos.Models.ViewData.ProductosServicios> lista = _sql.EjecutarSQL<TallerMotos.Models.ViewData.ProductosServicios>(
                   _context,
                   sql,
                   x => new TallerMotos.Models.ViewData.ProductosServicios()
                   {
                       titulo = x.GetString(0),
                       tipo = x.GetString(1),
                       descripcion = x.GetString(2),
                       precio = x.GetDecimal(3),
                       NombreCliente = x.GetString(4),
                       ano = x.GetInt32(5),
                   }
               );

            return View(lista);
        }
    }
}
