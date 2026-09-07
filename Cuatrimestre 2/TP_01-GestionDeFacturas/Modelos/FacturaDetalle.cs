using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_01_GestionDeFacturas.Modelos
{
    public class FacturaDetalle
    {
        private int id { get; set; }
        private int facturaId { get; set; }
        private int productId { get; set; }
        private int cantidad { get; set; }
        private decimal precioUnitario { get; set; }
        private decimal subtotal { get; set; }
    }
}
