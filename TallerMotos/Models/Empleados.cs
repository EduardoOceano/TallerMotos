﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Empleados
    {
        [Key]
        [Column("idEmpleado")]
        public int id { get; set; }
        public string nombreEmpleado { get; set; }
        public string apellidoEmpleado { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public int isActive { get; set; }

        [Column("idTaller")]
        public int? TalleresId { get; set; }

        public Talleres Talleres { get; set; }

    }
}
