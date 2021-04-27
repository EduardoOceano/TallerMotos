using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Talleres
    {
        [Key]
        [Column("idTaller")]
        public int id { get; set; }
        public int numEmpleados { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }

        public virtual IEnumerable<Empleados> Empleados { get; set; }

    }
}
