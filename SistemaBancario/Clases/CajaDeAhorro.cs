using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Clases
{
    public class CuentaAhorros : CuentaBancaria
    {
        private int retirosEsteMes;
        private int mesRegistro;

        private const int LIMITE_RETIROS_MES = 3;

        public CuentaAhorros(string titular)
            : base(titular)
        {
            mesRegistro = DateTime.Now.Month;
            retirosEsteMes = 0;
        }

        public override void Retirar(decimal monto)
        {
            if (monto <= 0) throw new DatosInvalidosException("El monto de retiro debe ser mayor que cero.");

            if (mesRegistro != DateTime.Now.Month)
            {
                retirosEsteMes = 0;
                mesRegistro = DateTime.Now.Month;
            }

            if (retirosEsteMes >= LIMITE_RETIROS_MES)
                throw new LimiteRetirosExcedidoException($"Límite de {LIMITE_RETIROS_MES} retiros mensuales excedido.");

            if (Saldo < monto)
                throw new FondosInsuficientesException("Fondos insuficientes.");

            Saldo -= monto;
            retirosEsteMes++;
        }
    }
}
