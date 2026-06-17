using Ejercicio_Laboratorios.Enums;
using Ejercicio_Laboratorios.Excepciones;

namespace Ejercicio_Laboratorios.Modelos;

public class CentroLaboratorios
{
    public CentroLaboratorios() { }

    public List<Laboratorio> Laboratorios { get; set; } = new();

    public void AgregarLaboratorio(Laboratorio laboratorio)
    {
        if (Laboratorios.Any(l => l.Codigo == laboratorio.Codigo))
            throw new InvalidOperationException(
                $"Ya existe un laboratorio con el código '{laboratorio.Codigo}'.");

        Laboratorios.Add(laboratorio);
    }

    public Laboratorio? BuscarPorCodigo(string codigo) =>
        Laboratorios.FirstOrDefault(l => l.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));

    public void ReservarLaboratorio(string codigo, Reserva reserva)
    {
        var laboratorio = BuscarPorCodigo(codigo)
            ?? throw new InvalidOperationException($"No se encontró el laboratorio con código '{codigo}'.");

        laboratorio.Reservar(reserva);
    }

    public void RegistrarUsoEquipos(string codigo, string nombreEquipo, int cantidadUsuarios)
    {
        var laboratorio = BuscarPorCodigo(codigo)
            ?? throw new InvalidOperationException($"No se encontró el laboratorio con código '{codigo}'.");

        laboratorio.RegistrarUsoEquipos(nombreEquipo, cantidadUsuarios);
    }

    public string GenerarReporteDanos(string codigo, string nombreEquipo, string descripcion)
    {
        var laboratorio = BuscarPorCodigo(codigo)
            ?? throw new InvalidOperationException($"No se encontró el laboratorio con código '{codigo}'.");

        return laboratorio.GenerarReporteDanos(nombreEquipo, descripcion);
    }

    public void ListarLaboratorios()
    {
        Console.WriteLine("\n--- Laboratorios registrados ---");
        foreach (var lab in Laboratorios)
        {
            Console.WriteLine($"  [{lab.Codigo}] {lab.Nombre} | Capacidad: {lab.Capacidad} | Estado: {lab.Estado}");
            Console.WriteLine($"    Equipos: {string.Join(", ", lab.EquiposDisponibles.Select(e => $"{e.Nombre} ({e.Estado})"))}");
        }
    }

    public void GenerarReporteGeneral()
    {
        Console.WriteLine("\n--- Reporte general del centro ---");
        foreach (var lab in Laboratorios)
        {
            var reportes = lab.ObtenerReportesDanos();
            Console.WriteLine($"\n  {lab.Nombre} ({lab.Codigo}) - Estado: {lab.Estado}");
            if (reportes.Count == 0)
            {
                Console.WriteLine("    Sin reportes de daños.");
            }
            else
            {
                foreach (var reporte in reportes)
                    Console.WriteLine($"    • {reporte}");
            }
        }
    }
}
