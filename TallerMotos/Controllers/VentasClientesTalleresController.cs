using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using TallerMotos.Models;
using TallerMotos.Models.ViewData;

namespace TallerMotos.Controllers
{
    public class VentasClientesTalleresController : Controller
    {
        private readonly Contexto _context;

        public VentasClientesTalleresController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<VentasClientesTalleres> lista = new List<VentasClientesTalleres>();
            using (DbCommand cn = _context.Database.GetDbConnection().CreateCommand())
            {
                cn.CommandText = "SELECT AVG(f.total) total, t.idTaller, c.nombreCliente FROM facturas f, talleres t, clientes c ORDER BY c.nombreCliente";
                _context.Database.OpenConnection();
                using (DbDataReader dr = cn.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VentasClientesTalleres ventas = new VentasClientesTalleres();
                        ventas.total = Decimal.Parse(dr["total"].ToString());
                        ventas.idTaller = int.Parse(dr["idTaller"].ToString());
                        ventas.nombreCliente = dr["nombreCliente"].ToString();

                        lista.Add(ventas);
                    }
                }

            }
            return View(lista);
        }
    }
}
    

