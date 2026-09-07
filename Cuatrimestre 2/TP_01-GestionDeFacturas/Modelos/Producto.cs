using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_01_GestionDeFacturas.Modelos
{
    public class Producto
    {
        private int id { get; set; }
        private string name { get; set; }
        private decimal price { get; set; }
        private int codigo { get; set; }
        private bool isActive { get; set; }
    }
}
