using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Motos
    {
        [Key]
        [Column("idMoto")]
        public int id { get; set; }
        public string matricula { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int? cilindrada { get; set; }

        [Column("idCliente")]
        public int? ClienteId { get; set; }

        public Clientes Cliente { get; set; }

    }
}
