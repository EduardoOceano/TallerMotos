using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class VentasTallerController : Controller
    {
        private readonly Contexto _context;

        public VentasTallerController(Contexto context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            List<VentasTaller> lista = new List<VentasTaller>();
            using (DbCommand cn = _context.Database.GetDbConnection().CreateCommand())
            {
                cn.CommandText = "SELECT SUM(f.total) total, t.idTaller, f.fecha, t.ciudad FROM facturas f INNER JOIN talleres t ON(t.idTaller = f.idTaller) GROUP BY YEAR(f.fecha) ORDER BY t.idTaller";
                _context.Database.OpenConnection();
                using (DbDataReader dr = cn.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VentasTaller ventas = new VentasTaller();
                        ventas.total = Decimal.Parse(dr["total"].ToString());
                        ventas.idTaller = int.Parse(dr["idTaller"].ToString());
                        ventas.ciudad = dr["ciudad"].ToString();
                        ventas.fecha = (DateTime)dr["fecha"];
                       
                        lista.Add(ventas);
                    }
                }

            }

            

            return View(lista);
        }
    }
}
