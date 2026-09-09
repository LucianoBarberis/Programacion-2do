namespace TP_01_GestionDeFacturas.Modelos
{
    public class FacturaDetalle
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }

        // Solo para mostrar en grilla (JOIN)
        public string ProductoNombre { get; set; } = string.Empty;
        public int ProductoCodigo { get; set; }
    }

    public class InformeProducto
    {
        public int ProductoId { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int CantidadFacturada { get; set; }
        public decimal MontoFacturado { get; set; }
    }
}
