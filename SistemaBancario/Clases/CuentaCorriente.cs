using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Clases
{
    public class CuentaCorriente : CuentaBancaria
    {
        private const decimal SOBREGIRO_MAXIMO = 100_000m;
        public static decimal SOBREGIRO_MAXIMO1 => SOBREGIRO_MAXIMO;

        public override void Retirar(decimal monto)
        {
            if (monto <= 0) throw new DatosInvalidosException("El monto de retiro debe ser mayor que cero.");

            decimal disponible = Saldo + SOBREGIRO_MAXIMO1;
            if (monto > disponible)
                throw new FondosInsuficientesException("Fondos insuficientes (incluyendo sobregiro).");

            Saldo -= monto;
        }
    }
}
