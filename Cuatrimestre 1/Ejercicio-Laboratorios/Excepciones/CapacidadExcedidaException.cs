namespace Ejercicio_Laboratorios.Excepciones;

public class CapacidadExcedidaException : Exception
{
    public CapacidadExcedidaException()
        : base("La cantidad de personas excede la capacidad del laboratorio.") { }

    public CapacidadExcedidaException(string mensaje)
        : base(mensaje) { }
}
