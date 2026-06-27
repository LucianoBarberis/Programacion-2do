using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadesInstitucionalesPOO.Exceptions
{
    public class InscripcionTardiaException : Exception
    {
        public InscripcionTardiaException() : base("El tiempo para inscribirse en el evento fue exedido...") { }
        public InscripcionTardiaException(string message) : base(message) { }
    }
}
