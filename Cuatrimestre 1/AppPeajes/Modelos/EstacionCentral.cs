using AppPeajes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeajes.Modelos
{
    public class EstacionCentral : IEstacionPeaje<Vehiculo>
    {
        private List<Vehiculo> _vehiculosProcesados = new List<Vehiculo>();
        public List<Vehiculo> VehiculosProcesados { get => _vehiculosProcesados; }

        public decimal Cobrar(Vehiculo vehiculo)
        {
            VehiculosProcesados.Add(vehiculo);
            decimal montoACobrar = vehiculo.CalcularPeajeTotal();
            vehiculo.RegistrarPasoPorCabina();
            return montoACobrar;
        }
    }
}
