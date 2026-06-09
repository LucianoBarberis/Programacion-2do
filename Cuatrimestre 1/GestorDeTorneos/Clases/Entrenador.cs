using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTorneos.Clases
{
    internal class Entrenador
    {
        private string name;
        private int edad;

        public string Name { get => name; set => name = value; }
        public int Edad { get => edad; set => edad = value; }
    }
}
