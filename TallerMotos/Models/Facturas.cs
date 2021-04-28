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
        public int idCliente { get; set; }
        public int idEmpleado { get; set; }
        public DateTime fecha { get; set; }

        public int idTaller { get; set; }
        public decimal total { get; set; }

        public virtual IEnumerable<VentasLineas> VentasLineas { get; set; }

        public Clientes Cliente { get; set; }

    }
}
