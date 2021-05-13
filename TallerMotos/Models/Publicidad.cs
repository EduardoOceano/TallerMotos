using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Publicidad
    {
        public int id { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinal { get; set; }
        public int descuento { get; set; }
        [Column("idProducto")]
        public int productoId { get; set; }

        public Productos producto { get; set; }
    }
}
