using Ejercicio_Laboratorios.Excepciones;

namespace Ejercicio_Laboratorios.Modelos;

public class LaboratorioQuimica : Laboratorio
{
    public LaboratorioQuimica() { }

    public bool CertificacionSeguridad { get; set; }
    public bool SupervisorPresente { get; set; }

    public override void Reservar(Reserva reserva)
    {
        if (!CertificacionSeguridad)
            throw new HorarioNoDisponibleException(
                "Se requiere certificación de seguridad para reservar el laboratorio de química.");

        if (!SupervisorPresente)
            throw new HorarioNoDisponibleException(
                "Se requiere un supervisor presente para utilizar el laboratorio de química.");

        ValidarEstadoDisponible();
        ValidarCapacidad(reserva.CantidadPersonas);
        ValidarHorarioLibre(reserva.Inicio, reserva.Fin);

        ConfirmarReserva(reserva);

        Console.WriteLine(
            $"Reserva confirmada en '{Nombre}' ({Codigo}): " +
            $"{reserva.Inicio:dd/MM/yyyy HH:mm} - {reserva.Fin:HH:mm} " +
            $"| Responsable: {reserva.Responsable} | Supervisor y certificación verificados.");
    }
}
