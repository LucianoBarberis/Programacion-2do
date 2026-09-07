using Taller.Datos;

namespace TP_01_GestionDeFacturas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Conexion.AsegurarBaseDeDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo conectar a SQL Server LocalDB.\n" +
                    "Verificá que esté instalado o ajustá la cadena en Datos/Conexion.cs.\n\n" +
                    ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
