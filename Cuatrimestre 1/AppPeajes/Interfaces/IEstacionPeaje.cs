using AppPeajes.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeajes.Interfaces
{
    internal interface IEstacionPeaje<T> where T : Vehiculo
    {
        public decimal Cobrar(Vehiculo vehiculo);
    }
}
