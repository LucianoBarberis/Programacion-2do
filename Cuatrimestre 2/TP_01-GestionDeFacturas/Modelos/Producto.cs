namespace TP_01_GestionDeFacturas.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public bool Activo { get; set; } = true;

        public override string ToString() => $"{Codigo} - {Nombre} (${Precio:N2})";
    }
}
