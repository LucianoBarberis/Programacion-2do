namespace GestorDeTorneos.Clases
{
    public class Entrenador
    {
        public string Nombre { get; set; } = string.Empty;
        public int AniosDeExperiencia { get; set; }

        public override string ToString() => Nombre;
    }
}
