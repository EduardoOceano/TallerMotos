using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Servicios
    {
        [Key]
        [Column("idServicio")]
        public int id { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
    }
}
