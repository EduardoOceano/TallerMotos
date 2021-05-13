using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Productos
    {
        [Key]
        [Column("idProducto")]
        public int id { get; set; }
        public string tipo { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        [Column("idProveedor")]
        public int ProveedorId { get; set; }
        public Proveedores Proveedor { get; set; }
        public string fabricante { get; set; }
        public string descripcion { get; set; }
    }
}
