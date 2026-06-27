using ActividadesInstitucionalesPOO.Clases;

namespace ActividadesInstitucionalesPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CentroEventos centroEventos = new();
            int opc = -1;
            while(opc != 0) 
            {
                Console.Clear();
                Console.WriteLine("----------------------------");
                Console.WriteLine("Gestor de eventos academicos");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1. Crear nuevo evento");
                Console.WriteLine("2. Incribir participante en un evento");
                Console.WriteLine("0. Salir");
                Console.WriteLine("");
                if (centroEventos.eventos.Count > 0)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("     Lista de eventos");
                    Console.WriteLine("----------------------------");
                    centroEventos.ListarEventos();
                }
                opc = inputIntOrDefault(-1);
                switch(opc) 
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("       Nuevo Evento");
                        Console.WriteLine("----------------------------");
                        string codigo;
                        string tituilo;
                        DateTime fecha = DateTime.Now.AddDays(50);
                        string organizador;
                        string lugar;
                        int capMax;
                        Console.WriteLine("Codigo:");
                        codigo = Console.ReadLine();
                        Console.WriteLine("Titulo:");
                        tituilo = Console.ReadLine();
                        Console.WriteLine("Organizador:");
                        organizador = Console.ReadLine();
                        Console.WriteLine("Lugar:");
                        lugar = Console.ReadLine();
                        Console.WriteLine("Capacidad maxima:");
                        capMax = inputIntOrDefault(5);

                    ;break;
                    case 2: ;break;
                    case 0: Console.WriteLine("Saliendo del sistema"); ;break;
                    default: Console.WriteLine("Opcion invalida");break;
                }
            }
        }

            static int inputIntOrDefault(int defaultOption)
            {
                int opc;
                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Entrada invalida | Unicamente se admiten enteros");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    opc = defaultOption;
                }
                return opc;
            }
        }
    }

