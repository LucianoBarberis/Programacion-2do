using GestionRRHH;

//Empleado empleadoNuevo = new Empleado();
//string nombre = "Martina";
//string puesto = "Profesor";
//int sueldo = 1000;

//empleadoNuevo.DarAlta(nombre, puesto, sueldo);
//Console.WriteLine(empleadoNuevo.Nombre);
//Console.WriteLine(empleadoNuevo.Puesto);

bool salida = true;
List<Empleado> listaEmpleados = new List<Empleado>();

var empleado1 = new Empleado();
empleado1.DarAlta("Juan", "Senior Dev", 2300);
listaEmpleados.Add(empleado1);

while (salida)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("--- Menu ---");
    Console.ForegroundColor= ConsoleColor.Magenta;
    Console.WriteLine("Opciones: ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("1. Dar de alta un nuevo empleado");
    Console.WriteLine("2. Dar de baja un empleado");
    Console.WriteLine("3. Listar todos los empleados");
    Console.WriteLine("4. Modificar el sueldo de un empleado");
    Console.WriteLine("5. Salir");

    int opcion = int.Parse(Console.ReadLine());
    Console.Clear();
    switch (opcion)
    {
        case 1:
            Empleado nuevoEmpleado = new Empleado();
            string nombreNuevo; string puestoNuevo; int sueldoNuevo;
            Console.WriteLine("Ingrese el nombre");
            nombreNuevo = Console.ReadLine();
            Console.WriteLine("Ingrese el puesto");
            puestoNuevo = Console.ReadLine();
            Console.WriteLine("Ingrese el sueldo");
            sueldoNuevo = int.Parse(Console.ReadLine());
            
            Console.WriteLine(nuevoEmpleado.DarAlta(nombreNuevo, puestoNuevo, sueldoNuevo));
            listaEmpleados.Add(nuevoEmpleado);
            break;
        case 2:
            string nombreEmpleado;string puesto;
            Console.WriteLine("Ingrese el nombre del empleado");
            nombreEmpleado = Console.ReadLine();
            Console.WriteLine("Ingrese el puesto del empleado");
            puesto = Console.ReadLine();
            var empleado = listaEmpleados.Find(e => e.Nombre == nombreEmpleado && e.Puesto == puesto);
            if(empleado == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Empleado no encontrado...");
                Console.WriteLine("Presiona enter para ir al menu.");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                empleado.DarBaja();
                Console.ForegroundColor= ConsoleColor.Magenta;
                Console.WriteLine("Informacion del empleado:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(empleado.MostrarInformacion());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Empleado dado de baja correctamente!");
                Console.ReadKey();
            }
            break;
        case 3:
            if(listaEmpleados.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Hay Empleados!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Presiona enter para ir al menu.");
                Console.ReadKey();
            }else
            {
                Console.WriteLine("Lista de empleados:");
                Console.ForegroundColor = ConsoleColor.Green;
                foreach(Empleado emp in listaEmpleados)
                {
                    Console.WriteLine(emp.MostrarInformacion());
                }
                Console.WriteLine("---");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Presiona enter para ir al menu.");
                Console.ReadKey();
            }
            break;
        case 4:
            Console.WriteLine("Cuanto desea aumenta o disminuir el sueldo?");
            int monto;empleado = null;
            Console.WriteLine("Ingrese el nombre del empleado");
            nombreEmpleado = Console.ReadLine();
            Console.WriteLine("Ingrese el puesto del empleado");
            puesto = Console.ReadLine();
            empleado = listaEmpleados.Find(e => e.Nombre == nombreEmpleado && e.Puesto == puesto);
            if (empleado == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Empleado no encontrado...");
                Console.WriteLine("Presiona enter para ir al menu.");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Modificador del Sueldo (+/-):");
                if (int.TryParse(Console.ReadLine(), out monto))
                {
                    empleado.ModificarSueldo(monto);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Sueldo modificado correctamente!");
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un valor valido!");
                    Console.ReadKey();
                }
            }
            break;
        case 5:
            salida = false;
            break;
        default:
            break;
    }
}