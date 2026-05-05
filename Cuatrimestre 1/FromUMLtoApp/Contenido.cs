using FromUMLtoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FromUMLtoApp
{
    public class Contenido
    {
        private string _titulo = string.Empty;
        private Genero _genero;
        private Director _director;
        private int _añoLanzamiento;
        private decimal _duracionEnMinutos;
        private List<Actor> _actors = new List<Actor>();

        public string Titulo { get => _titulo; set => _titulo = value; }
        public Genero Genero { get => _genero; set => _genero = value; }
        public Director Director { get => _director; set => _director = value; }
        public int AñoLanzamiento { get => _añoLanzamiento; set => _añoLanzamiento = value; }
        public decimal DuracionEnMinutos { get => _duracionEnMinutos; set => _duracionEnMinutos = value; }
        public List<Actor> Actors { get => _actors; set => _actors = value; }
    }
}
