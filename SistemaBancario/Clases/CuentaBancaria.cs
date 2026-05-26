using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SistemaBancario;

namespace SistemaBancario.Clases
{
    public abstract class CuentaBancaria
    {
        public int NumeroCuenta { get; }
        public string Titular { get; }
        public decimal Saldo { get; protected set; }

        public CuentaBancaria(string titular)
        {
            if (string.IsNullOrWhiteSpace(titular))
                throw new ("Datos de cuenta inválidos.");

            NumeroCuenta = RandomNumberGenerator.GetInt32(1000000, 9000000);
            Titular = titular;
            Saldo = 0;
        }

        public virtual void Depositar(decimal monto)
        {
            if (monto <= 0) throw new DatosInvalidosException("El monto de depósito debe ser mayor que cero.");
            Saldo += monto;
        }

        public abstract void Retirar(decimal monto);
    }
}
