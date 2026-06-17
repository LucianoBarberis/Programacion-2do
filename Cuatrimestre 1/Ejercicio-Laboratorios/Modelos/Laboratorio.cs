using Ejercicio_Laboratorios.Enums;
using Ejercicio_Laboratorios.Excepciones;

namespace Ejercicio_Laboratorios.Modelos;

public abstract class Laboratorio
{
    public Laboratorio() { }

    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public int Capacidad { get; set; }
    public List<Equipo> EquiposDisponibles { get; set; } = new();
    public EstadoLaboratorio Estado { get; set; } = EstadoLaboratorio.Libre;

    protected List<Reserva> Reservas { get; set; } = new();
    protected List<string> ReportesDanos { get; set; } = new();

    public abstract void Reservar(Reserva reserva);

    public virtual void RegistrarUsoEquipos(string nombreEquipo, int cantidadUsuarios)
    {
        var equipo = BuscarEquipo(nombreEquipo);

        if (equipo.Estado == EstadoEquipo.EnMantenimiento)
            throw new EquipoEnMantenimientoException(
                $"El equipo '{nombreEquipo}' está en mantenimiento.");

        if (equipo.Estado == EstadoEquipo.Danado)
            throw new EquipoEnMantenimientoException(
                $"El equipo '{nombreEquipo}' está dañado y no puede utilizarse.");

        if (cantidadUsuarios > Capacidad)
            throw new CapacidadExcedidaException(
                $"No se pueden registrar {cantidadUsuarios} usuarios. Capacidad máxima: {Capacidad}.");

        equipo.Estado = EstadoEquipo.EnUso;
        Console.WriteLine($"Uso registrado: '{nombreEquipo}' en laboratorio '{Nombre}'.");
    }

    public virtual string GenerarReporteDanos(string nombreEquipo, string descripcion)
    {
        var equipo = BuscarEquipo(nombreEquipo);
        equipo.Estado = EstadoEquipo.Danado;
        equipo.DescripcionDano = descripcion;

        var reporte = $"[{DateTime.Now:dd/MM/yyyy HH:mm}] Laboratorio '{Nombre}' ({Codigo}) - " +
                      $"Equipo '{nombreEquipo}': {descripcion}";

        ReportesDanos.Add(reporte);
        return reporte;
    }

    public IReadOnlyList<string> ObtenerReportesDanos() => ReportesDanos.AsReadOnly();

    protected void ValidarCapacidad(int cantidadPersonas)
    {
        if (cantidadPersonas > Capacidad)
            throw new CapacidadExcedidaException(
                $"La reserva para {cantidadPersonas} personas excede la capacidad de {Capacidad}.");
    }

    protected void ValidarEstadoDisponible()
    {
        if (Estado == EstadoLaboratorio.EnMantenimiento)
            throw new HorarioNoDisponibleException(
                $"El laboratorio '{Nombre}' se encuentra en mantenimiento.");

        if (Estado == EstadoLaboratorio.Ocupado)
            throw new HorarioNoDisponibleException(
                $"El laboratorio '{Nombre}' está ocupado en este momento.");
    }

    protected void ValidarHorarioLibre(DateTime inicio, DateTime fin)
    {
        if (fin <= inicio)
            throw new HorarioNoDisponibleException("La hora de fin debe ser posterior a la de inicio.");

        bool hayConflicto = Reservas.Any(r =>
            inicio < r.Fin && fin > r.Inicio);

        if (hayConflicto)
            throw new HorarioNoDisponibleException(
                $"El horario {inicio:HH:mm} - {fin:HH:mm} ya tiene una reserva en '{Nombre}'.");
    }

    protected void ValidarDuracionSesion(DateTime inicio, DateTime fin, int horasMaximas)
    {
        var duracion = fin - inicio;

        if (duracion.TotalHours > horasMaximas)
            throw new HorarioNoDisponibleException(
                $"La sesión no puede superar las {horasMaximas} horas. Duración solicitada: {duracion.TotalHours:F1} h.");
    }

    protected void ConfirmarReserva(Reserva reserva)
    {
        reserva.CodigoLaboratorio = Codigo;
        Reservas.Add(reserva);
        Estado = EstadoLaboratorio.Ocupado;
    }

    private Equipo BuscarEquipo(string nombreEquipo)
    {
        var equipo = EquiposDisponibles
            .FirstOrDefault(e => e.Nombre.Equals(nombreEquipo, StringComparison.OrdinalIgnoreCase));

        if (equipo is null)
            throw new InvalidOperationException(
                $"El equipo '{nombreEquipo}' no existe en el laboratorio '{Nombre}'.");

        return equipo;
    }
}
