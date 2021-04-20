using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    [Table("Clientes")]
    public class Clientes
    {
        [Key]
        public int idCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string CiudadCliente { get; set; }
        public int idMoto { get; set; }
        public string DomicilioCliente { get; set; }
    }
}
