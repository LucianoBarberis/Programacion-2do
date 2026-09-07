using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_01_GestionDeFacturas.Modelos
{
    public class Factura
    {
        private int Id { get; set; }
        private int facturaNro { get; set; }
        private DateTime dateCreated { get; set; }
        private string clientName { get; set; }
        private string clientDni { get; set; }
        private decimal totalAmount { get; set; }
    }
}
