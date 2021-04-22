﻿using System;
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
        public int idVentasLineas { get; set; }
        [Column("idProducto")]
        public int? ProductoId { get; set; }
        public Productos Producto { get; set; }
        public int? idServicio { get; set; }
        public int? cantidad { get; set; }
        public int? precio { get; set; }

        public int? idFactura { get; set; }

    }
}
