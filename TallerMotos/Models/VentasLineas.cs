using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{

    [Table("VentasLineas")]
    public class VentasLineas
    {
        [Key]
        [Column("idVentasLineas")]
        public int id { get; set; }
        [Column("idProducto")]
        public int? ProductoId { get; set; }
        /*
        [Column("descripcion")]
        public string ProductoDescripcion{ get; set; }
        */
        public Productos Producto { get; set; }
        public int? idServicio { get; set; }
        public int? cantidad { get; set; }
        public int? precio { get; set; }

        [Column("idFactura")]
        public int? FacturasId { get; set; }

        public Facturas facturas { get; set; }


    }
}
