using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Ventas
    {
        int idVenta { get; set; }
        int idCliente { get; set; }
        int idMoto { get; set; }
        int idEmpleado { get; set; }
        int idVentasLineal { get; set; }
        int montajePrecio { get; set; }
    }
}
