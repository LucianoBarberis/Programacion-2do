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
        private int numeroCuenta;
        private string titular;
        private decimal saldo;

        public int NumeroCuenta { get => numeroCuenta; }
        public string Titular { get => titular; }
        public decimal Saldo { get => saldo; protected set => saldo = value; }


        public virtual void Depositar(decimal monto)
        {
            if (monto <= 0) throw new DatosInvalidosException("El monto de depósito debe ser mayor que cero.");
            Saldo += monto;
        }

        public abstract void Retirar(decimal monto);
    }
}
