using FromUMLtoApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FromUMLtoApp.Models
{
    public class Pelicula : Contenido
    {
        private ClasificacionEnum _clasificacion;
        internal ClasificacionEnum Clasificacion { get => _clasificacion; set => _clasificacion = value; }
    }
}
