using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AppDePasaje_POO
{
    internal class Pasajero
    {
        public Pasajero(string name, string tarjeta, int saldo, TipoBeneficio beneficio) 
        {
            Name = name;
            Tarjeta = tarjeta;
            Saldo = saldo;
            Beneficio = beneficio;
        }
        private string name;
        private string tarjeta;
        private int saldo;
        private TipoBeneficio beneficio;

        public string Name { get { return name; } set { name = value; } }
        public string Tarjeta { get { return tarjeta; } set { tarjeta = value; } }
        public int Saldo { get; set { saldo = value; }  }
        public TipoBeneficio Beneficio { get { return beneficio; } set { beneficio = value; } }

        public string CargarSaldo(int _saldo)
        {
            if (_saldo < 0)
            {
                return "No se puede recargar saldo negativo";
            }

            Saldo += _saldo;
            return "";
        }

        public void showData()
        {
            Console.WriteLine("Nombre: " + Name);
            Console.WriteLine("Tarjeta: " + Tarjeta);
            Console.WriteLine("Saldo: " + Saldo);
            Console.WriteLine("Beneficio: " + Beneficio);
        }
    }

    public enum TipoBeneficio
    {
        Null = 0,
        Estudiante = 1,
        Jubilido = 2
    }
}
