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

        public CuentaCorriente(string titular)
            : base(titular) { }

        public override void Retirar(decimal monto)
        {
            if (monto <= 0) throw new DatosInvalidosException("El monto de retiro debe ser mayor que cero.");

            decimal disponible = Saldo + SOBREGIRO_MAXIMO;
            if (monto > disponible)
                throw new FondosInsuficientesException("Fondos insuficientes (incluyendo sobregiro).");

            Saldo -= monto;
        }
    }
}
