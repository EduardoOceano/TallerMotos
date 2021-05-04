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

        public ProductosProveedoresController(Contexto context)
        {
            _context = context;
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
                return View(lista);
        }
    }
}
