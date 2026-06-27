using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadesInstitucionalesPOO.Exceptions
{
    public class PagoPendienteException : Exception
    {
        public PagoPendienteException() : base("El participante debe realizar el pago...") { }
        public PagoPendienteException(string message) : base(message) { }
    }
}
