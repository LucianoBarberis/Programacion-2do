using GestorDeTorneos.Clases;

namespace GestorDeTorneos
{
    public class Repository
    {
        public List<Torneo> Torneos { get; set; } = new List<Torneo>();
        public List<Juego> Juegos { get; set; } = new List<Juego>()
        {
            new Juego()
            {
                Nombre = "CS:GO",
                JugadoresPorEquipo = 5,
                Categoria = CategoriaJuego.FPS,
            },
            new Juego()
            {
                Nombre = "League of Legends",
                JugadoresPorEquipo = 5,
                Categoria = CategoriaJuego.MOBA,
            },
            new Juego()
            {
                Nombre = "Valorant",
                JugadoresPorEquipo = 5,
                Categoria = CategoriaJuego.FPS,
            },
            new Juego()
            {
                Nombre = "Fortnite",
                JugadoresPorEquipo = 100,
                Categoria = CategoriaJuego.BattleRoyale,
            }
        };
        public List<Equipo> Equipos { get; set; } = new List<Equipo>();

        public bool InscribirJugadorEnEquipo(Jugador jugador, Equipo equipo)
        {
            if (equipo.CuposDisponibles <= 0)
                return false;

            equipo.Jugadores.Add(jugador);
            return true;
        }

        public bool ProgramarPartida(Torneo torneo, Partida partida)
        {
            foreach (var p in torneo.Partidas)
            {
                if (p.Fecha == partida.Fecha && p.Estado != EstadoPartida.Finalizada)
                    return false;
            }

            torneo.Partidas.Add(partida);
            return true;
        }

        public bool IniciarPartida(Partida partida)
        {
            if (partida.Estado != EstadoPartida.Programada)
                return false;

            if (partida.EquipoLocal == null || partida.EquipoVisitante == null)
                return false;

            if (!partida.EquipoLocal.EstaCompleto || !partida.EquipoVisitante.EstaCompleto)
                return false;

            partida.Estado = EstadoPartida.EnCurso;
            return true;
        }
    }
}
