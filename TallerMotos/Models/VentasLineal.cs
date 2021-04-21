﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class VentasLineal
    {
        [Key]
        public int idVentaLineal { get; set; }
        public int idProducto { get; set; }
        public int idServicio { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }

        public int idFactura { get; set; }

    }
}
