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
    public class FacturasEmpleadosController : Controller
    {
        private readonly Contexto _context;
        public FacturasEmpleadosController(Contexto context)
        {
            _context = context;
        }
        public IActionResult Index(string? nombreEmpleado)
        {
            List<FacturasEmpleados> lista = new List<FacturasEmpleados>();
            using (DbCommand cn = _context.Database.GetDbConnection().CreateCommand())
            {
                cn.CommandText = "SELECT f.idFactura, f.total, e.idEmpleado, e.NombreEmpleado FROM facturas f, empleados e WHERE e.nombreEmpleado LIKE '"+nombreEmpleado+"';";
                _context.Database.OpenConnection();
                using (DbDataReader dr = cn.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FacturasEmpleados facturaDeEmpleado = new FacturasEmpleados();
                        facturaDeEmpleado.idFactura = int.Parse(dr["idFactura"].ToString());
                        facturaDeEmpleado.total = Decimal.Parse(dr["total"].ToString());
                        facturaDeEmpleado.idEmpleado = int.Parse(dr["idEmpleado"].ToString());
                        facturaDeEmpleado.nombreEmpleado= dr["NombreEmpleado"].ToString();

                        lista.Add(facturaDeEmpleado);
                    }
                }

            }
            return View(lista);
        }
    }
}
