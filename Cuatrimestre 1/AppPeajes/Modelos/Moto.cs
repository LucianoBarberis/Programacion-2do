using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeajes.Modelos
{
    public class Moto : Vehiculo
    {
        public override decimal CalcularPeajeTotal()
        {
            return 1500 / 2;
        }
    }
}
