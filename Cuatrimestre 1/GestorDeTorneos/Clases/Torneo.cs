using System.Security.Cryptography;

namespace GestorDeTorneos.Clases
{
    public class Torneo
    {
        public string Name { get; set; } = string.Empty;
        public Juego Juego { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public List<Partida> Partidas { get; set; } = new();
        public decimal PremioMonetario { get; set; }
        public int IdTorneo { get; } = RandomNumberGenerator.GetInt32(100000, 999999);
        public bool IsActive { get; set; } = true;
        public FormatoTorneo Formato { get; set; } = FormatoTorneo.SingleElimination;
        public EstadoTorneo Estado { get; set; } = EstadoTorneo.Proximamente;
        public List<Equipo> Equipos { get; set; } = new();

        public override string ToString() => Name;
    }
}
