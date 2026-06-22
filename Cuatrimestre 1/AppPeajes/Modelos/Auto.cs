using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPeajes;

namespace AppPeajes.Modelos
{
    public class Auto : Vehiculo
    {
        private bool esHibrido = false;

        public bool EsHibrido { get => esHibrido; set => esHibrido = value; }

        public override decimal CalcularPeajeTotal()
        {
            if (esHibrido && TipoTarifa != TipoTarifa.HoraPico)
            {
                return (decimal)(1500 * 0.80);
            }
            return 1500;
        }
    }
}
