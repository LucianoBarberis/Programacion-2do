using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadesInstitucionalesPOO.Exceptions
{
    public class EventoLlenoException : Exception
    {
        public EventoLlenoException() : base("No hay mas lugares disponibles para este evento...") {}
        public EventoLlenoException(string message) : base(message) {}
    }
}
