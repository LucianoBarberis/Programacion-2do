using System;
using System.Collections.Generic;
using System.Text;

namespace FromUMLtoApp.Models
{
    public class Actor
    {
        private string _nombre = string.Empty;
        private string _nacionalidad = string.Empty;
        private int _añoNacimiento;
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Nacionalidad { get => _nacionalidad; set => _nacionalidad = value; }
        public int AñoNacimiento { get => _añoNacimiento; set => _añoNacimiento = value; }
    }
}
