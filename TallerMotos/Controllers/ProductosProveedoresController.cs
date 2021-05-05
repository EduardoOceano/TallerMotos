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

            int counterTotal = 0;
            IDictionary<string, int> stockProductos = new Dictionary<string, int>();
            stockProductos["motoresStock"] = 0;
            stockProductos["cascosStock"] = 0;
            stockProductos["neumaticosStock"] = 0;
            stockProductos["suspensionesStock"] = 0;
            stockProductos["accesoriosStock"] = 0;
            stockProductos["frenosStock"] = 0;

            IDictionary<string, int> stockProveedores = new Dictionary<string, int>();
            stockProveedores["mBienStock"] = 0;
            stockProveedores["juanStock"] = 0;
            stockProveedores["RPTiStock"] = 0;
            stockProveedores["RPTtiaStock"] = 0;
            stockProveedores["pacoStock"] = 0;
            stockProveedores["verdinStock"] = 0;

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
                        counterTotal += producto.stock;
                        if (producto.tipo == "MT")
                        {
                            stockProductos["motoresStock"] += producto.stock;
                        }
                        else if(producto.tipo == "CA")
                        {
                            stockProductos["cascosStock"] += producto.stock;
                        }
                        else if (producto.tipo == "NM")
                        {
                            stockProductos["neumaticosStock"] += producto.stock;
                        }
                        else if (producto.tipo == "SU")
                        {
                            stockProductos["suspensionesStock"] += producto.stock;
                        }
                        else if (producto.tipo == "CC")
                        {
                            stockProductos["accesoriosStock"] += producto.stock;
                        }
                        else if (producto.tipo == "FR")
                        {
                            stockProductos["frenosStock"] += producto.stock;
                        }

                        if (producto.nombreProveedor == "Motores bien")
                        {
                            stockProveedores["mBienStock"] += producto.stock;
                        }
                        else if (producto.nombreProveedor == "Motores Juan")
                        {
                            stockProveedores["juanStock"] += producto.stock;
                        }
                        else if (producto.nombreProveedor == "Recambios pa ti")
                        {
                            stockProveedores["RPTiStock"] += producto.stock;
                        }
                        else if (producto.nombreProveedor == "Recambios pa tu tia")
                        {
                            stockProveedores["RPTtiaStock"] += producto.stock;
                        }
                        else if (producto.nombreProveedor == "Recambios Paco")
                        {
                            stockProveedores["pacoStock"] += producto.stock;
                        }
                        else if (producto.nombreProveedor == "Recambios Verdin")
                        {
                            stockProveedores["verdinStock"] += producto.stock;
                        }
                    }
                }

            }
            stockProductos["frenosStock"] = 100 * stockProductos["frenosStock"] / counterTotal;
            stockProductos["motoresStock"] = 100 * stockProductos["motoresStock"] / counterTotal;
            stockProductos["cascosStock"] = 100 * stockProductos["cascosStock"] / counterTotal;
            stockProductos["neumaticosStock"] = 100 * stockProductos["neumaticosStock"] / counterTotal;
            stockProductos["suspensionesStock"] = 100 * stockProductos["suspensionesStock"] / counterTotal;
            stockProductos["accesoriosStock"] = 100 * stockProductos["accesoriosStock"] / counterTotal;


            stockProveedores["mBienStock"] = 100 * stockProveedores["mBienStock"] / counterTotal;
                stockProveedores["juanStock"] = 100 * stockProveedores["juanStock"] / counterTotal;
                stockProveedores["RPTiStock"] = 100 * stockProveedores["RPTiStock"] / counterTotal;
                stockProveedores["RPTtiaStock"] = 100 * stockProveedores["RPTtiaStock"] / counterTotal;
                stockProveedores["pacoStock"] = 100 * stockProveedores["pacoStock"] / counterTotal;
                stockProveedores["verdinStock"] = 100 * stockProveedores["verdinStock"] / counterTotal;

            ViewData["assocArray01"] = stockProductos;
                ViewData["assocArray02"] = stockProveedores;
                return View(lista);
        }
    }
}
