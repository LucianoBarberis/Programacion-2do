using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadesInstitucionalesPOO.Clases
{
    public abstract class EventoAcademico
    {
        private string codigo;
        private string tituilo;
        private DateTime fecha;
        private string organizador;
        private string lugar;
        private int capMax;
        private List<string> participantes = new();

        public string Codigo { get => codigo; set => codigo = value; }
        public string Tituilo { get => tituilo; set => tituilo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Organizador { get => organizador; set => organizador = value; }
        public string Lugar { get => lugar; set => lugar = value; }
        public int CapMax { get => capMax; set => capMax = value; }
        public List<string> Participantes { get => participantes; }

        public abstract void inscribirParticipante (bool esEstudiante, string nombreParticipante, bool pagoPendiente);
        public abstract bool? procesarPago(decimal pago);
        public bool verificarCupos()
        {
            if (Participantes.Count() >= CapMax)
            {
                // devuelve false si esta lleno
                return false;
            }
            return true;
        }
    }
}
