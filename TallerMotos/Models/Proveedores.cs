using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Proveedores
    {
        [Key]
        [Column("idProveedor")]
        public int id { get; set; }
        public string nombreProveedor { get; set; }
        public string direccion { get; set; }
        public string pais { get; set; }
        public string comentario { get; set; }
        public string telefono { get; set; }
        
    }
}
