using ActividadesInstitucionalesPOO.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadesInstitucionalesPOO.Clases
{
    public class Seminario : EventoAcademico
    {
        private decimal costo;
        
        public decimal Costo { get => costo; set => costo = value; }

        public override void inscribirParticipante(bool esEstudiante, string nombreParticipante, bool pagoPendiente)
        {
            if ((DateTime.Now - this.Fecha).TotalDays <= 7)
            {
                throw new InscripcionTardiaException();
            }
            if (esEstudiante && (this.Fecha - DateTime.Now).TotalDays <= 30)
            {
                throw new InscripcionTardiaException("La inscripcion como estudiante requiere 30 dias de anticipación...");
            }

            if (verificarCupos() == false)
            {
                throw new EventoLlenoException();
            }

            if(pagoPendiente == true)
            {
                throw new PagoPendienteException();
            }

            this.Participantes.Add(nombreParticipante);
        }

        // Este metodo define a la variable pagoPendiente, si pagoPendiente = false el sistema interpreta que se pago el costo del evento
        public override bool? procesarPago(decimal pago)
        {
            if (pago == costo)
            {
                return false;
            }
            if (pago > costo)
            {
                Console.WriteLine("Devolver $" + (pago - costo));
                return false;
            }
            if (pago < costo)
            {
                return true;
            }
            return true;
        }
    }
}
