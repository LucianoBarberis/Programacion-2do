namespace Ejercicio_Laboratorios.Modelos;

public class Reserva
{
    public Reserva() { }

    public string CodigoLaboratorio { get; set; } = string.Empty;
    public DateTime Inicio { get; set; }
    public DateTime Fin { get; set; }
    public int CantidadPersonas { get; set; }
    public string Responsable { get; set; } = string.Empty;
}
