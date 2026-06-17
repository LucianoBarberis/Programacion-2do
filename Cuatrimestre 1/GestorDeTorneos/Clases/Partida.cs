namespace GestorDeTorneos.Clases
{
    public class Partida
    {
        public string Descripcion { get; set; } = string.Empty;
        public Equipo EquipoLocal { get; set; }
        public Equipo EquipoVisitante { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoPartida Estado { get; set; } = EstadoPartida.Programada;
        public string Resultado { get; set; } = string.Empty;

        public override string ToString()
        {
            var local = EquipoLocal?.Nombre ?? "TBD";
            var visit = EquipoVisitante?.Nombre ?? "TBD";
            return $"{local} vs {visit} - {Fecha.ToShortDateString()} [{Estado}]";
        }
    }
}
