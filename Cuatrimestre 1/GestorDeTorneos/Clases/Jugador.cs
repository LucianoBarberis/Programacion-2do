namespace GestorDeTorneos.Clases
{
    public class Jugador
    {
        public string Nombre { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public int Edad { get; set; }
        public Rangos Rango { get; set; }
        public Region Region { get; set; }

        public override string ToString() => $"{UserName} ({Nombre})";
    }
}
