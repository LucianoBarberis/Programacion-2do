namespace Ejercicio_Laboratorios.Excepciones;

public class EquipoEnMantenimientoException : Exception
{
    public EquipoEnMantenimientoException()
        : base("El equipo se encuentra en mantenimiento y no puede utilizarse.") { }

    public EquipoEnMantenimientoException(string mensaje)
        : base(mensaje) { }
}
