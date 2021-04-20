using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Proveedores
    {
        [Key]
        public int idProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public string Comentario { get; set; }
        public string telefono { get; set; }
        
        
    }
}
