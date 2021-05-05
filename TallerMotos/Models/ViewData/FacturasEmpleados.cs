using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models.ViewData
{
    public class FacturasEmpleados
    {
        public int idFactura { get; set; }
        public decimal total { get; set; }
        public int idEmpleado { get; set; }
        public string nombreEmpleado { get; set; }
    }
}
