using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeajes.Modelos
{
    public class Camion : Vehiculo
    {
        private double pesoCargaToneladas;
        public double PesoCargaToneladas { get => pesoCargaToneladas; set => pesoCargaToneladas = value; }

        public override decimal CalcularPeajeTotal()
        {
            if(pesoCargaToneladas > 0)
            {
                return (decimal)pesoCargaToneladas * 120 + 1500 + 1000;
            }
            return 2500;
        }
    }
}
