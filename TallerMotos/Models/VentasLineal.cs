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
        int idVentaLineal { get; set; }
        bool montaje { get; set; }
        int idProducto { get; set; }
    }
}
