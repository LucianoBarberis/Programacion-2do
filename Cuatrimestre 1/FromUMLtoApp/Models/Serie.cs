using System;
using System.Collections.Generic;
using System.Text;

namespace FromUMLtoApp.Models
{
    public class Serie : Contenido
    {
        private int _cantidadTemporada;
        private int _cantidadEpisodios;
        public int CantidadTemporada { get => _cantidadTemporada; set => _cantidadTemporada = value; }
        public int CantidadEpisodios { get => _cantidadEpisodios; set => _cantidadEpisodios = value; }
    }
}
