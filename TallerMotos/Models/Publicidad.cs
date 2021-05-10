using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Publicidad
    {
        public int id { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinal { get; set; }
        public int descuento { get; set; }
        public int idProducto { get; set; }
    }
}
