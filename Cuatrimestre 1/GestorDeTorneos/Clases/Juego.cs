namespace GestorDeTorneos.Clases
{
    public class Juego
    {
        public string Nombre { get; set; } = string.Empty;
        public int JugadoresPorEquipo { get; set; }
        public CategoriaJuego Categoria { get; set; } = CategoriaJuego.Otro;

        public override string ToString() => Nombre;
    }
}
