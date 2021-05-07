using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models.ViewData
{
    public class ProductosServicios
    {
        public string titulo { get; set; }

        public string tipo { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public string NombreCliente { get; set; }
        public int ano { get; set; }
    }
}
