using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Clases
{
    public class CuentaAhorros : CuentaBancaria
    {
        private int retirosEsteMes = DateTime.Now.Month;
        private int mesRegistro = 0;
        private const int LIMITE_RETIROS_MES = 3;

        public int RetirosEsteMes { get => retirosEsteMes; set => retirosEsteMes = value; }
        public int MesRegistro { get => mesRegistro; set => mesRegistro = value; }
        public static int LIMITE_RETIROS_MES1 => LIMITE_RETIROS_MES;

        public override void Retirar(decimal monto)
        {
            if (monto <= 0) throw new DatosInvalidosException("El monto de retiro debe ser mayor que cero.");

            if (MesRegistro != DateTime.Now.Month)
            {
                RetirosEsteMes = 0;
                MesRegistro = DateTime.Now.Month;
            }

            if (RetirosEsteMes >= LIMITE_RETIROS_MES1)
                throw new LimiteRetirosExcedidoException($"Límite de {LIMITE_RETIROS_MES1} retiros mensuales excedido.");

            if (Saldo < monto)
                throw new FondosInsuficientesException("Fondos insuficientes.");

            Saldo -= monto;
            RetirosEsteMes++;
        }
    }
}
