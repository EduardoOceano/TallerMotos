using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{

    public class Clientes
    {
        [Key]
        [Column("idCliente")]
        public int id { get; set; }
        public string nombreCliente { get; set; }
        public string apellidosCliente { get; set; }
        public string ciudadCliente { get; set; }
        public string dniCliente { get; set; }
        public string domicilioCliente { get; set; }
    }
}
