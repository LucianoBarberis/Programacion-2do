using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTorneos.Clases
{
    public class Partida
    {
        private Equipo resultado;
        private Equipo equipo1;
        private Equipo equipo2;

        internal Equipo Resultado { get => resultado; set => resultado = value; }
        internal Equipo Equipo1 { get => equipo1; set => equipo1 = value; }
        internal Equipo Equipo2 { get => equipo2; set => equipo2 = value; }
    }
}
