using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActividadesInstitucionalesPOO.Exceptions;

namespace ActividadesInstitucionalesPOO.Clases
{
    public class Conferencia : EventoAcademico
    {
        public override void inscribirParticipante(bool esEstudiante, string nombreParticipante, bool pagoPendiente)
        {
            if ((DateTime.Now-this.Fecha).TotalHours <= 1 ) 
            {
                throw new InscripcionTardiaException();
            }
            if (esEstudiante && (this.Fecha - DateTime.Now).TotalDays <= 30)
            {
                throw new InscripcionTardiaException("La inscripcion como estudiante requiere 30 dias de anticipación...");
            }

            if(verificarCupos() == false)
            {
                throw new EventoLlenoException();
            }

            this.Participantes.Add(nombreParticipante);
        }

        public override bool? procesarPago(decimal pago)
        {
            // No se implementa ya que las incripciones de las conferencias son siempre gratuitas
            throw new NotImplementedException("Funcion de procesar pago no implementada en Conferencias");
        }
    }
}
