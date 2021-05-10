using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models.ViewData
{
    public class PublicidadProductos
    {
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinal { get; set; }
        public int descuento { get; set; }
        public string tipo { get; set; }
        public decimal precio { get; set; }
        public string fabricante { get; set; }

        public int idProducto { get; set; }
    }
}
