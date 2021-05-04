using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using TallerMotos.Models;
using TallerMotos.Models.ViewData;

namespace TallerMotos.Controllers
{
    public class ProductosProveedoresController : Controller
    {
        private readonly Contexto _context;
        private readonly ServicioSQL _sql;



        public ProductosProveedoresController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }

        public IActionResult Index()
        {
            List<ProductosProveedores> lista = new List<ProductosProveedores>();
            using (DbCommand cn = _context.Database.GetDbConnection().CreateCommand())
            {
                cn.CommandText = "SELECT tipo, precio, fabricante, descripcion, stock, nombreProveedor, direccion, pais, telefono FROM productos pro INNER JOIN proveedores prov ON (prov.idProveedor=pro.idProveedor) ORDER BY prov.nombreProveedor";
                cn.CommandType = CommandType.Text;
                _context.Database.OpenConnection();
                using (DbDataReader dr = cn.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ProductosProveedores producto = new ProductosProveedores();
                        producto.tipo = dr["tipo"].ToString();
                        producto.precio = Decimal.Parse(dr["precio"].ToString());
                        producto.fabricante = dr["fabricante"].ToString();
                        producto.descripcion = dr["descripcion"].ToString();
                        producto.stock = Int32.Parse(dr["stock"].ToString());
                        producto.nombreProveedor = dr["nombreProveedor"].ToString();
                        producto.direccion = dr["direccion"].ToString();
                        producto.pais = dr["pais"].ToString();
                        producto.telefono = dr["telefono"].ToString();
                        lista.Add(producto);
                    }
                }

            }

            string sql = "SELECT SUM(stock) * 100 / (SELECT SUM(stock) FROM productos tp ) FROM productos tg GROUP BY tg.tipo";
            List<Models.ViewData.ProductosProveedores> porcentaje = _sql.EjecutarSQL<Models.ViewData.ProductosProveedores>(
                   _context,
                   sql,
                   x => new Models.ViewData.ProductosProveedores()
                   {

                       NM = x.GetString(0),
                       FR = x.GetString(1),
                       MT = x.GetString(2),
                       SU = x.GetString(3),
                       CC = x.GetString(4),
                       CA = x.GetString(5),

                   }
               );
            return View(lista);


        }
    }
}
