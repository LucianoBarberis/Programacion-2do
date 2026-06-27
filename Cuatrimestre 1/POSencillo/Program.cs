using POSencillo.Modelos;

namespace POSencillo
{
    internal class Program
    {
        public static int inputIntOrDefault(int defaultOption)
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
        static void Main(string[] args)
        {
            
            List<Producto> Inventario = new List<Producto>();
            int opcion = -1;
            while(opcion != 0) 
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║          MENÚ PRINCIPAL POS          ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║  1. Nueva Venta                      ║");
                Console.WriteLine("║  2. Inventario                       ║");
                Console.WriteLine("║  0. Salir                            ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Opcion: ");
                opcion = inputIntOrDefault(-1);

                switch(opcion)
                {
                    case 1:
                        CaseCompra(Inventario);
                        break;
                    case 2:
                        CaseInventario(Inventario);
                        break;
                    case 0: 
                        Console.ForegroundColor= ConsoleColor.Yellow;
                        Console.WriteLine("Saliendo del sistema...");
                        Console.ForegroundColor= ConsoleColor.White;
                        ; break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Entrada invalida...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void CaseInventario(List<Producto> Inventario)
        {
            int opcionInventario = -1;
            while (opcionInventario != 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔══════════════════════════════╗");
                Console.WriteLine("║          INVENTARIO          ║");
                Console.WriteLine("╠══════════════════════════════╣");
                Console.WriteLine("║  1. Agregar Producto         ║");
                Console.WriteLine("║  2. Eliminar Producto        ║");
                Console.WriteLine("║  0. Salir                    ║");
                Console.WriteLine("╠══════════════════════════════╣");
                Console.WriteLine("║      Lista de Productos      ║");
                Console.WriteLine("╚══════════════════════════════╝");
                Inventario.ForEach(prod =>
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("->  " + prod.Id + "; " + prod.Name + "; X" + prod.Stock + "; $" + prod.Price);
                    Console.WriteLine("--------------------------------");

                });
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Opcion: ");
                opcionInventario = inputIntOrDefault(-1);
                if (opcionInventario == 1)
                {
                    Console.Clear();
                    string ProductName;
                    decimal ProductPrice = 0;
                    int stock = -1;

                    Console.WriteLine("Nombre del Producto:");
                    ProductName = Console.ReadLine();
                    while(ProductPrice == 0) 
                    {
                        Console.Clear();
                        Console.WriteLine("Precio:");
                        ProductPrice = inputIntOrDefault(0);
                    }
                    while(stock < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Stock Actual:");
                        stock = inputIntOrDefault(-1);
                    }
                    var nuevoProducto = new Producto(ProductName, ProductPrice, stock);
                    Inventario.Add(nuevoProducto);
                }
                else if (opcionInventario == 2)
                {
                    Console.WriteLine("Id del producto a eliminar:");
                    int id = inputIntOrDefault(-1);
                    var productToDelete = Inventario.FirstOrDefault(prod => prod.Id == id);
                    if (productToDelete == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No Existe ningun produto con ese ID");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                    }
                    Inventario.Remove(productToDelete);
                    Console.WriteLine("Producto Eliminado Correctamente!");
                    Console.ReadKey();
                }
                else if (opcionInventario == 0)
                {
                    return;
                }
            }
        }
        private static void CaseCompra(List<Producto> Inventario)
        {
            int opcionCompra = -1;
            List<Producto> Carrito = new List<Producto>();
            while (opcionCompra != 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔══════════════════════════════╗");
                Console.WriteLine("║            COMPRA            ║");
                Console.WriteLine("╠══════════════════════════════╣");
                Console.WriteLine("║  1. Agregar Producto         ║");
                Console.WriteLine("║  2. Eliminar Producto        ║");
                Console.WriteLine("║  3. Confirmar Venta          ║");
                Console.WriteLine("║  0. Salir                    ║");
                Console.WriteLine("╠══════════════════════════════╣");
                Console.WriteLine("║      Carrito de compra       ║");
                Console.WriteLine("╚══════════════════════════════╝");
                Carrito.ForEach(prod =>
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("->  " + prod.Id + "; " + prod.Name + "; $" + prod.Price);
                    Console.WriteLine("--------------------------------");

                });
                Console.WriteLine("╔══════════════════════════════╗");
                Console.WriteLine("║          INVENTARIO          ║");
                Console.WriteLine("╚══════════════════════════════╝");
                Inventario.ForEach(prod =>
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("->  " + prod.Id + "; " + prod.Name + "; X" + prod.Stock + "; $" + prod.Price);
                    Console.WriteLine("--------------------------------");

                });
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Opcion: ");
                opcionCompra = inputIntOrDefault(-1);
                if (opcionCompra == 1)
                {
                    int ProductId = 0;
                    Console.Clear();
                    while (ProductId == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Id del producto:");
                        ProductId = inputIntOrDefault(0);
                    }
                    var productToAdd = Inventario.FirstOrDefault(prod => prod.Id == ProductId);
                    if (productToAdd == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No Existe ningun produto con ese ID");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                    }
                    if (productToAdd.Stock <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("No Existe stock de ese producto");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                    }
                    Carrito.Add(productToAdd);
                }
                else if (opcionCompra == 2)
                {
                    Console.WriteLine("Id del producto a eliminar:");
                    int id = inputIntOrDefault(-1);
                    var productToDelete = Carrito.FirstOrDefault(prod => prod.Id == id);
                    if (productToDelete == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No Existe ningun produto con ese ID");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                    }
                    Carrito.Remove(productToDelete);
                    Console.WriteLine("Producto Eliminado Correctamente!");
                    Console.ReadKey();
                }
                else if (opcionCompra == 3)
                {
                    decimal subTotal = Carrito.Sum(prod => prod.Price);
                    decimal iva = subTotal * (decimal)0.21;
                    decimal total = subTotal + iva;
                    List<int> Repetidos = new List<int>();
                    foreach (var producto in Carrito)
                    {
                        var ProductoEnInventario = Inventario.FirstOrDefault(prod => prod.Id == producto.Id);
                        Repetidos.Add(producto.Id);
                        ProductoEnInventario.Stock = ProductoEnInventario.Stock - 1;
                        Console.WriteLine("Eliminado producto del inventario: ");
                        Console.WriteLine(producto.Name);
                        Console.ReadKey();
                    }
                    
                    Console.Clear();
                    Console.WriteLine("========================================");
                    Console.WriteLine("           TICKET DE VENTA");
                    Console.WriteLine("========================================");
                    Console.WriteLine("Producto          Precio           Total");
                    Console.WriteLine("----------------------------------------");
                    Carrito.ForEach(prod => Console.WriteLine(prod.Name + "          $" + prod.Price + "           " + " " + (prod.Price * Repetidos.Count(x => x == prod.Id))));
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Subtotal:                         $" + subTotal);
                    Console.WriteLine("IVA (21%):                        $" + iva);
                    Console.WriteLine("TOTAL:                            $" + total);
                    Console.WriteLine("========================================\r\n¡Gracias por su compra!");
                    Carrito.Clear();
                    Console.ReadKey();
                    return;
                }
                else if (opcionCompra == 0)
                {
                    return;
                }
            }
        }

    }
}

