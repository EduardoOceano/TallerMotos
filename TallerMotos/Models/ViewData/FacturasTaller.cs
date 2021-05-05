using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models.ViewData
{
    public class FacturasTaller
    {
        public int idFactura { get; set; }
        public string nombreCliente { get; set; }
        public int idTaller { get; set; }
        public string ciudad { get; set; }
    }
}
