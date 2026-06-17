using Ejercicio_Laboratorios.Enums;

namespace Ejercicio_Laboratorios.Modelos;

public class Equipo
{
    public Equipo() { }

    public string Nombre { get; set; } = string.Empty;
    public EstadoEquipo Estado { get; set; } = EstadoEquipo.Disponible;
    public string? DescripcionDano { get; set; }
}
