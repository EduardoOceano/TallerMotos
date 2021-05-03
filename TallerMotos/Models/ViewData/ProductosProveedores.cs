using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models.ViewData
{
    public class ProductosProveedores
    {
        public string tipo { get; set; }
        public decimal precio { get; set; }
        public string fabricante { get; set; }
        public string descripcion { get; set; }
        public string nombreProveedor { get; set; }
        public string direccion { get; set; }
        public string pais { get; set; }
        public string telefono { get; set; }
    }
}
