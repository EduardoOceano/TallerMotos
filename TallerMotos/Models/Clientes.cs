using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Clientes
    {
        int idCliente { get; set; }
        string NombreCliente { get; set; }
        string ApellidoCliente { get; set; }
        string CiudadCliente { get; set; }
        int idMoto { get; set; }
        string DomicilioCliente { get; set; }
    }
}
