using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Productos
    {
        [Key]
        public int idProducto { get; set; }
        public string tipo { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }

        public int idProveedor { get; set; }
        public string Fabricante { get; set; }
        public string Descripcion { get; set; }
    }
}
