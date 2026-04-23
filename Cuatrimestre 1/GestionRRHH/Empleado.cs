using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRRHH
{
    public class Empleado
    {
        private string nombre;
        private string puesto;
        private int sueldo;
        private bool activo;

        public string Nombre { get { return nombre; } }
        public string Puesto { get { return puesto; } }
        public int Sueldo { get { return sueldo; } }
        public bool Activo { get { return activo; } }

        public string DarAlta(string nombreEmpleado, string puestoEmpleado, int sueldoEmpleado)
        {
            nombre = nombreEmpleado;
            puesto = puestoEmpleado;
            sueldo = sueldoEmpleado;
            activo = true;
            return "Empleado correctamente registrado";
        }
        public string DarBaja()
        {
            activo = false;
            return "Empleado dado de baja";
        }
        public string ModificarSueldo(int montoModificador)
        {
            sueldo += montoModificador;
            return "Sueldo Modificar";
        }
        public string MostrarInformacion()
        {
            string info = "Nombre: " + nombre + ". Puesto: " + puesto + ". Sueldo: " + sueldo + ". Activo: " + (activo == true ? "Si": "No");
            return info;
        }
    }
}
