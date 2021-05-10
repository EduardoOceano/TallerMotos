using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models.ViewData
{
    public class PagosFactura
    {
        public int id_factura { get; set; }
        public decimal importe { get; set; }
        public DateTime fechaPago { get; set; }
    }
}
