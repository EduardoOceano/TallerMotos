﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{

    public class Clientes
    {
        [Key]
        public int idCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidosCliente { get; set; }
        public string ciudadCliente { get; set; }
        
        public string DNICliente { get; set; }
        public string DomicilioCliente { get; set; }
    }
}
