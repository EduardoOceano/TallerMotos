using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Servicios
    {
        [Key]
        public int idServicio { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
    }
}
