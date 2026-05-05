using FromUMLtoApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FromUMLtoApp.Models
{
    public class Pelicula : Contenido
    {
        private ClasificacionEnum _clasificacion;
        public ClasificacionEnum Clasificacion { get => _clasificacion; set => _clasificacion = value; }
        public override string MostrarInfo()
        {
            return $"=== Pelicula ===\nClasificacion: {Clasificacion}\nTitulo: {Titulo}\nGenero: {Genero.Nombre}\nDirector: {Director.Nombre}\nLanzamiento: {AñoLanzamiento}\nDuracion: {DuracionEnMinutos}";
        }
    }
}
