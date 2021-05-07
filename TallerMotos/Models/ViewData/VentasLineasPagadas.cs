using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models.ViewData
{
    public class VentasLineasPagadas
    {
        public int idVentasLineas { get; set; }
        public int idProducto { get; set; }
        public int idServicio { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public int idFactura { get; set; }

        public bool isPagado { get; set; }

    }
}
