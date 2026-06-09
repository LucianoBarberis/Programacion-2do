using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario
{
    public class FondosInsuficientesException : Exception
    {
        public FondosInsuficientesException(string msg) : base(msg) { }
    }

    public class LimiteRetirosExcedidoException : Exception
    {
        public LimiteRetirosExcedidoException(string msg) : base(msg) { }
    }

    public class DatosInvalidosException : Exception
    {
        public DatosInvalidosException(string msg) : base(msg) { }
    }
}
