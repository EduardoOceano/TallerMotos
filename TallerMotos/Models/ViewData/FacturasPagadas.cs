using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models.ViewData
{
    public class FacturasPagadas
    {
        
        public int idFactura { get; set; }
        public int idCliente { get; set; }
        public int total { get; set; }  
        public bool isPagado { get; set; }

    }
}
