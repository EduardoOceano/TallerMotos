using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Facturas
    {

        [Key]
        [Column("idFactura")]
        public int id { get; set; }
        [Column("idEmpleado")]
        public int? EmpleadoId { get; set; }
        public DateTime fecha { get; set; }

        public int? idTaller { get; set; }
        public decimal total { get; set; }

        public virtual IEnumerable<VentasLineas> VentasLineas { get; set; }

        [Column("idCliente")] //En la base de datos
        public int? ClienteId { get; set; } //En la parte C
        public Clientes Cliente { get; set; }

        public Empleados Empleado { get; set; }
        public Boolean isPagado { get; set; }

    }
}
