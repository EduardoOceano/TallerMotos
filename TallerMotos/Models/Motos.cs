using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMotos.Models
{
    public class Motos
    {
        int idMotos { get; set; }
        string matricula { get; set; }
        string marca { get; set; }
        string modelo { get; set; }
        int cilindrada { get; set; }
        int idCliente { get; set; }

    }
}
