namespace Ejercicio_Laboratorios.Excepciones;

public class HorarioNoDisponibleException : Exception
{
    public HorarioNoDisponibleException()
        : base("El horario solicitado no está disponible.") { }

    public HorarioNoDisponibleException(string mensaje)
        : base(mensaje) { }
}
