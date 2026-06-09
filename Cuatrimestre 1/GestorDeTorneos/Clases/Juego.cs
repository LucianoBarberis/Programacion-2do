using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTorneos.Clases
{
    public class Juego
    {
        private string nombre;
        private int jugadoresPorEquipo;

        public string Nombre { get => nombre; set => nombre = value; }
        public int JugadoresPorEquipo { get => jugadoresPorEquipo; set => jugadoresPorEquipo = value; }
    }
}
