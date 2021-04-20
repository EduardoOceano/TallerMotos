using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Empleados
    {
        [Key]
        public int idEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public string telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }

        public int idTaller { get; set; }
    }
}
