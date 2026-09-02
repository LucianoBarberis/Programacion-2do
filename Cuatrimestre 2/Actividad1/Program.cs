using System.Reflection;

Assembly assembly = Assembly.GetExecutingAssembly();
Console.WriteLine($"Assembly: {assembly.GetName().Name}");
 
foreach (Type type in assembly.GetTypes())
{
    Console.WriteLine(type.FullName + " || Tipo:"  + type.Assembly.GetType());
}

Producto producto1 = new Producto(){
    Id = 1,
    Nombre = "Jabon",
    Precio = 150,
};

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public decimal Precio { get; set; }
}