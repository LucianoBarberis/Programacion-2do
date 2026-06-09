using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTorneos.Clases
{
    public class Torneo
    {
        private string name = string.Empty;
        private Juego juego;
        private DateTime fechaIni;
        private DateTime fechaFin;
        private List<Partida> partidas;
        private decimal premioMonetario;
        private int idTorneo = RandomNumberGenerator.GetInt32(100000,999999);

        public string Name { get => name; set => name = value; }
        public DateTime FechaIni { get => fechaIni; set => fechaIni = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public List<Partida> Partidas { get => partidas; set => partidas = value; }
        public decimal PremioMonetario { get => premioMonetario; set => premioMonetario = value; }
        public int IdTorneo { get => idTorneo; }
        internal Juego Juego { get => juego; set => juego = value; }
    }
}
