using System;
using System.Collections.Generic;
using System.Text;

namespace AppDePasaje_POO
{
    internal class Boleto
    {

        private int costo = 1000;
        public string Cobrar(Pasajero pasajero)
        {
            if (pasajero == null || pasajero.Tarjeta == null)
            {
                return "Error al cobrar: No existe el pasajero";
            }

            if(pasajero.Beneficio == TipoBeneficio.Null && pasajero.Saldo >= costo)
            {
                pasajero.Saldo = pasajero.Saldo - costo;
                return $"Se le cobro {costo} | Saldo: {pasajero.Saldo}";
            }

            if (pasajero.Beneficio == TipoBeneficio.Estudiante)
            {
                return "Se le cobro $0 al estudiante | Saldo: {pasajero.Saldo}";
            }

            if (pasajero.Beneficio == TipoBeneficio.Jubilido && pasajero.Saldo >= (costo/2))
            {
                pasajero.Saldo = pasajero.Saldo - (costo/2);
                return $"Se le cobro {costo/2} al jubilado | Saldo: {pasajero.Saldo}";
            }

            return "Saldo insuficiente";
        }
    }
}
