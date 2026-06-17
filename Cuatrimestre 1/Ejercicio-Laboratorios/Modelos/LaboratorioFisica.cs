using Ejercicio_Laboratorios.Excepciones;

namespace Ejercicio_Laboratorios.Modelos;

public class LaboratorioFisica : Laboratorio
{
    public LaboratorioFisica() { }

    public int LimiteHorasPorSesion { get; set; } = 4;

    public override void Reservar(Reserva reserva)
    {
        ValidarEstadoDisponible();
        ValidarCapacidad(reserva.CantidadPersonas);
        ValidarHorarioLibre(reserva.Inicio, reserva.Fin);
        ValidarDuracionSesion(reserva.Inicio, reserva.Fin, LimiteHorasPorSesion);

        ConfirmarReserva(reserva);

        Console.WriteLine(
            $"Reserva confirmada en '{Nombre}' ({Codigo}): " +
            $"{reserva.Inicio:dd/MM/yyyy HH:mm} - {reserva.Fin:HH:mm} " +
            $"| Responsable: {reserva.Responsable} | Máx. {LimiteHorasPorSesion}h/sesión.");
    }
}
