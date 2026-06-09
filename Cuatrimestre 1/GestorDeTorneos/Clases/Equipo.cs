using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTorneos.Clases
{
    internal class Equipo
    {
        private List<Jugador> jugadores;
        private Entrenador entrenador;
        private string nombre;

        public string Nombre { get => nombre; set => nombre = value; }
        internal List<Jugador> Jugadores { get => jugadores; set => jugadores = value; }
        internal Entrenador Entrenador { get => entrenador; set => entrenador = value; }
    }
}
