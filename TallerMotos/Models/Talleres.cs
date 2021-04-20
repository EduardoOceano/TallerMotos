﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Talleres
    {
        [Key]
        public int idTaller { get; set; }
        public string numEmpleados { get; set; }
        public string telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }

    }
}
