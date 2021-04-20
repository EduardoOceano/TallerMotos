﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Motos
    {
        [Key]
        public int idMotos { get; set; }
        public string matricula { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int cilindrada { get; set; }
        public int idCliente { get; set; }

    }
}
