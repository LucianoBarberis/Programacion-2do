using Ejercicio_Laboratorios.Enums;
using Ejercicio_Laboratorios.Excepciones;
using Ejercicio_Laboratorios.Modelos;

var centro = new CentroLaboratorios();

int opc = 1;
while (opc != 0)
{
    Console.Clear();
    Console.WriteLine("=== Sistema de Gestión de Laboratorios Universitarios ===\n");
    centro.ListarLaboratorios();
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("--- Menu de Opciones ---");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("1. Crear laboratorio");
    Console.WriteLine("2. Crear reserva");
    Console.WriteLine("3. Registrar uso de equipos");
    Console.WriteLine("4. Generar Reporte de daños");
    Console.WriteLine("5. Generar Reporte general");
    Console.WriteLine("0. Salir");
    opc = inputIntOrDefault(-1);
    switch(opc)
    {
        case 1:
            int opcNewLab;
            string codigo;
            string nombre;
            int capacidadMax;
            Console.Clear();
            Console.WriteLine("== Nuevo Laboratorio ==");
            Console.WriteLine("Tipo de laboratorio:");
            Console.WriteLine("1. Informatica");
            Console.WriteLine("2. Fisica");
            Console.WriteLine("3. Quimica");
            opcNewLab = inputIntOrDefault(-1);
            Console.Clear();
            Console.WriteLine("Codigo del laboratorio:");
            codigo = Console.ReadLine();
            Console.WriteLine("Nombre:");
            nombre = Console.ReadLine();
            Console.WriteLine("Capacidad Max.:");
            capacidadMax = inputIntOrDefault(-1);

            if(opcNewLab == 1)
            {
                int opcEquipos = -1;
                string nombreEquipo = "";
                var labInformatica = new LaboratorioInformatica
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    Capacidad = capacidadMax,
                    Estado = EstadoLaboratorio.Libre,
                    RequiereReservaPrevia = true,
                    LimiteHorasPorSesion = 3
                };

                while(opcEquipos != 0)
                {
                    Console.Clear(); 
                    Console.WriteLine("Equipos del laboratorio de informatica");
                    Console.WriteLine("1. Agregar equipo");
                    Console.WriteLine("0. Salir");
                    opcEquipos = inputIntOrDefault(-1);
                    if(opcEquipos == 1)
                    {
                        Console.WriteLine("Nombre del equipo");
                        nombreEquipo = Console.ReadLine();
                        if(nombreEquipo == string.Empty || nombreEquipo == null)
                        {
                            Console.WriteLine("El nombre del equipo es invalido.");
                        } else
                        {
                            labInformatica.EquiposDisponibles.Add(new Equipo { Nombre = nombreEquipo });
                        }
                    }
                }
                centro.AgregarLaboratorio(labInformatica);
            }
            if (opcNewLab == 2)
            {
                int opcEquipos = -1;
                string nombreEquipo = "";
                var labQuimica = new LaboratorioQuimica
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    Capacidad = capacidadMax,
                    Estado = EstadoLaboratorio.Libre,
                    CertificacionSeguridad = true,
                    SupervisorPresente = true
                };

                while (opcEquipos != 0)
                {
                    Console.Clear();
                    Console.WriteLine("Equipos del laboratorio de quimica");
                    Console.WriteLine("1. Agregar equipo");
                    Console.WriteLine("0. Salir");
                    opcEquipos = inputIntOrDefault(-1);
                    if (opcEquipos == 1)
                    {
                        Console.WriteLine("Nombre del equipo");
                        nombreEquipo = Console.ReadLine();
                        if (nombreEquipo == string.Empty || nombreEquipo == null)
                        {
                            Console.WriteLine("El nombre del equipo es invalido.");
                        }
                        else
                        {
                            labQuimica.EquiposDisponibles.Add(new Equipo { Nombre = nombreEquipo });
                        }
                    }
                }
                centro.AgregarLaboratorio(labQuimica);
            }
            if (opcNewLab == 3)
            {
                int opcEquipos = -1;
                string nombreEquipo = "";
                var labFisica = new LaboratorioFisica
                {
                    Codigo = "FIS-01",
                    Nombre = "Laboratorio de Física Experimental",
                    Capacidad = 25,
                    Estado = EstadoLaboratorio.Libre,
                    LimiteHorasPorSesion = 4
                };

                while (opcEquipos != 0)
                {
                    Console.Clear();
                    Console.WriteLine("Equipos del laboratorio de quimica");
                    Console.WriteLine("1. Agregar equipo");
                    Console.WriteLine("0. Salir");
                    opcEquipos = inputIntOrDefault(-1);
                    if (opcEquipos == 1)
                    {
                        Console.WriteLine("Nombre del equipo");
                        nombreEquipo = Console.ReadLine();
                        if (nombreEquipo == string.Empty || nombreEquipo == null)
                        {
                            Console.WriteLine("El nombre del equipo es invalido.");
                        }
                        else
                        {
                            labFisica.EquiposDisponibles.Add(new Equipo { Nombre = nombreEquipo });
                        }
                    }
                }
                centro.AgregarLaboratorio(labFisica);
            }
            if (opcNewLab != 1 && opcNewLab != 2 && opcNewLab != 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opcion Invalidaa");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            ; break;
        case 2:
            string responsable;
            int hsInicio = 0;
            int hsFin = 0;
            int cantidadDePersonas = 0;
            string codigoLab;

            Console.WriteLine("== Crear Reserva ==");
            Console.WriteLine("Nombre y apellido del responsable:");
            responsable = Console.ReadLine();
            Console.WriteLine("Codigo lab.:");
            codigoLab = Console.ReadLine();
            Console.WriteLine("Hora de inicio.:");
            hsInicio = inputIntOrDefault(0);
            Console.WriteLine("Hora de fin.:");
            hsFin = inputIntOrDefault(0);
            Console.WriteLine("Cantidad de personas.:");
            cantidadDePersonas = inputIntOrDefault(0);
            try
            {
                var reservaInfo = new Reserva
                {
                    Inicio = DateTime.Today.AddHours(hsInicio),
                    Fin = DateTime.Today.AddHours(hsFin),
                    CantidadPersonas = cantidadDePersonas,
                    Responsable = responsable
                };
                centro.ReservarLaboratorio(codigoLab, reservaInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            ; break;
        case 3:
            Console.WriteLine("== Registro de uso de equipos ==");
            Console.WriteLine("Codigo del laboratorio:");
            string codLaboratorio = Console.ReadLine();
            Console.WriteLine("Nombre del equipo: ");
            string nombreEquipo2 = Console.ReadLine();
            Console.WriteLine("Cantidad de usuarios: ");
            int cantidadUsuarios = inputIntOrDefault(1);
            try
            {
                centro.RegistrarUsoEquipos(codLaboratorio, nombreEquipo2, cantidadUsuarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            ; break;
        case 4:
            
            Console.WriteLine("Codigo del laboratorio:");
            codLaboratorio = Console.ReadLine();
            Console.WriteLine("Nombre del equipo: ");
            nombreEquipo2 = Console.ReadLine();
            Console.WriteLine("Detalle del dano: ");
            string detalla = Console.ReadLine();
            var reporte = centro.GenerarReporteDanos(codLaboratorio, nombreEquipo2, detalla);
            Console.WriteLine(reporte);
            ; break;
        case 5:
            centro.GenerarReporteGeneral();
            ; break;
        default: Console.WriteLine();break;
    }
}

int inputIntOrDefault(int defaultOption)
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
