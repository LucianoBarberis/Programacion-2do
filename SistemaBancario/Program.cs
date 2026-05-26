using SistemaBancario.Clases;
using System;
using System.Collections.Generic;

namespace SistemaBancario
{
    public class Banco : IBanco
    {
        private readonly Dictionary<int, CuentaBancaria> cuentas = new();

        public void AgregarCuenta(CuentaBancaria cuenta)
        {
            if (cuentas.ContainsKey(cuenta.NumeroCuenta))
                throw new DatosInvalidosException("El número de cuenta ya existe.");
            cuentas[cuenta.NumeroCuenta] = cuenta;
        }

        public CuentaBancaria ObtenerCuenta(int numeroCuenta)
        {
            if (!cuentas.TryGetValue(numeroCuenta, out var cuenta))
                throw new DatosInvalidosException("Cuenta no encontrada.");
            return cuenta;
        }

        public IEnumerable<CuentaBancaria> ListarCuentas() => cuentas.Values;
    }

    class Program
    {
        static void Main()
        {
            var banco = new Banco();
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("_______________________________________________________________");
                Console.WriteLine("   _____ _           ____                              _       ");
                Console.WriteLine("  / ___/(_)____     / __ )____ _____  _________ ______(_)___   ");
                Console.WriteLine("  \\__ \\/ / ___/    / __  / __ `/ __ \\/ ___/ __ `/ ___/ / __ \\   ");
                Console.WriteLine(" ___/ / (__  )    / /_/ / /_/ / / / / /__/ /_/ / /  / / /_/ / ");
                Console.WriteLine("/____/_/____(_)  /_____/\\__,_/_/ /_/\\___/\\__,_/_/  /_/\\____/  ");
                Console.WriteLine("_______________________________________________________________");
                Console.ForegroundColor = ConsoleColor.White;
                if (banco.ListarCuentas().Any())
                {
                    Console.WriteLine("-----------------------------------------------------------");
                    ListarCuentas(banco);
                    Console.WriteLine("-----------------------------------------------------------");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No hay cuentas registradas.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");

                }

                Console.WriteLine("Menu de opciones:");
                Console.WriteLine("1. Crear cuenta de ahorro");
                Console.WriteLine("2. Crear cuenta corriente");
                Console.WriteLine("3. Depositar");
                Console.WriteLine("4. Retirar");
                Console.WriteLine("5. Consultar saldo");
                Console.WriteLine("6. Listar cuentas");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                var opcion = Console.ReadLine();
                try
                {
                    switch (opcion)
                    {
                        case "1":
                            CrearCuenta(banco, tipoAhorro: true);
                            break;
                        case "2":
                            CrearCuenta(banco, tipoAhorro: false);
                            break;
                        case "3":
                            RealizarDeposito(banco);
                            break;
                        case "4":
                            RealizarRetiro(banco);
                            break;
                        case "5":
                            ConsultarSaldo(banco);
                            break;
                        case "6":
                            ListarCuentas(banco);
                            Pausa();
                            break;
                        case "7":
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            Pausa();
                            break;
                    }
                }
                catch (Exception ex) when (ex is DatosInvalidosException || ex is FondosInsuficientesException || ex is LimiteRetirosExcedidoException)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Pausa();
                }
            }
        }

        static void CrearCuenta(Banco banco, bool tipoAhorro)
        {
            Console.Write("Titular: ");
            var titular = Console.ReadLine();

            CuentaBancaria cuenta = tipoAhorro
                ? new CuentaAhorros(titular)
                : new CuentaCorriente(titular);

            banco.AgregarCuenta(cuenta);
            Console.WriteLine("Cuenta creada correctamente.");
            Pausa();
        }

        static void RealizarDeposito(Banco banco)
        {
            Console.Write("Número de cuenta: ");
            if (!int.TryParse(Console.ReadLine(), out var num))
                throw new DatosInvalidosException("Número de cuenta inválido.");
            Console.Write("Monto a depositar: ");
            if (!decimal.TryParse(Console.ReadLine(), out var monto))
                throw new DatosInvalidosException("Monto inválido.");

            var cuenta = banco.ObtenerCuenta(num);
            cuenta.Depositar(monto);
            Console.WriteLine("Depósito realizado.");
            Pausa();
        }

        static void RealizarRetiro(Banco banco)
        {
            Console.Write("Número de cuenta: ");
            if (!int.TryParse(Console.ReadLine(), out var num))
                throw new DatosInvalidosException("Número de cuenta inválido.");
            Console.Write("Monto a retirar: ");
            if (!decimal.TryParse(Console.ReadLine(), out var monto))
                throw new DatosInvalidosException("Monto inválido.");

            var cuenta = banco.ObtenerCuenta(num);
            cuenta.Retirar(monto);
            Console.WriteLine("Retiro realizado.");
            Pausa();
        }

        static void ConsultarSaldo(Banco banco)
        {
            Console.Write("Número de cuenta: ");
            if (!int.TryParse(Console.ReadLine(), out var num))
                throw new DatosInvalidosException("Número de cuenta inválido.");
            var cuenta = banco.ObtenerCuenta(num);
            Console.WriteLine($"Titular: {cuenta.Titular}");
            Console.WriteLine($"Saldo: {cuenta.Saldo:C}");
            Pausa();
        }

        static void ListarCuentas(Banco banco)
        {
            Console.WriteLine("Cuentas registradas:");
            foreach (var c in banco.ListarCuentas())
            {
                Console.WriteLine($"- {c.NumeroCuenta} | {c.Titular} | {c.GetType().Name} | Saldo: {c.Saldo:C}");
            }
        }

        static void Pausa()
        {
            Console.WriteLine();
            Console.Write("Pulse una tecla para continuar...");
            Console.ReadKey(intercept: true);
        }
    }
}