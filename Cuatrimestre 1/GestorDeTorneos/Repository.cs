using GestorDeTorneos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            },
            new Juego()
            {
                Nombre = "Leage of Legends",
                JugadoresPorEquipo = 5,
            },
            new Juego()
            {
                Nombre = "Valorant",
                JugadoresPorEquipo = 5,
            },
            new Juego()
            {
                Nombre = "Fornite",
                JugadoresPorEquipo = 100,
            }
        }; 
    }
}
