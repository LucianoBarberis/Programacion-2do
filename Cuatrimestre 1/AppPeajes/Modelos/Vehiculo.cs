using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppPeajes.Modelos
{
    public abstract class Vehiculo
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private string _patente = RandomNumberGenerator.GetString(chars ,7);
        private int _ejes;
        private double _tarifaBase;
        private TipoTarifa tipoTarifa;
        private int _pasosPorCabina = 0;

        public string Patente { get => _patente;}
        public int Ejes { get => _ejes; set => _ejes = value; }
        public double TarifaBase { get => _tarifaBase; set => _tarifaBase = value; }
        public TipoTarifa TipoTarifa { get => tipoTarifa; set => tipoTarifa = value; }

        public abstract decimal CalcularPeajeTotal();
        public virtual void RegistrarPasoPorCabina() 
        {
            _pasosPorCabina++;
        }
    }
}
