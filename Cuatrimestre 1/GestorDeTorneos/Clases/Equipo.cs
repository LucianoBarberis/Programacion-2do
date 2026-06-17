namespace GestorDeTorneos.Clases
{
    public class Equipo
    {
        public string Nombre { get; set; } = string.Empty;
        public Juego Juego { get; set; }
        public Entrenador Entrenador { get; set; }
        public List<Jugador> Jugadores { get; set; } = new();

        public bool EstaCompleto => Jugadores.Count >= (Juego?.JugadoresPorEquipo ?? 0);
        public int CuposDisponibles => (Juego?.JugadoresPorEquipo ?? 0) - Jugadores.Count;

        public override string ToString() => $"{Nombre} ({Juego?.Nombre})";
    }
}
