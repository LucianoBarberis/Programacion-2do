using Microsoft.Data.SqlClient;

namespace Taller.Datos;

internal static class Conexion
{
    public const string CadenaConexion =
        @"Server=(localdb)\mssqllocaldb;Database=TP01Facturas;Integrated Security=true;TrustServerCertificate=true;";

    public static SqlConnection Crear()
    {
        return new SqlConnection(CadenaConexion);
    }

    public static void AsegurarBaseDeDatos()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(CadenaConexion);
        string nombreBase = builder.InitialCatalog;
        builder.InitialCatalog = "master";

        using (SqlConnection master = new SqlConnection(builder.ConnectionString))
        {
            master.Open();
            using SqlCommand crearBase = new SqlCommand(
                $"IF DB_ID('{nombreBase}') IS NULL CREATE DATABASE [{nombreBase}]",
                master);
            crearBase.ExecuteNonQuery();
        }

        using SqlConnection conexion = Crear();
        conexion.Open();

        using SqlCommand crearTablas = new SqlCommand(
            """
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Facturas')
            BEGIN
                CREATE TABLE Facturas (
                    id INT PRIMARY KEY IDENTITY(1,1),
                    facturaNro INT NOT NULL,
                    dateCreated DATE NOT NULL,
                    clientName NVARCHAR(50) NOT NULL,
                    clientDni NVARCHAR(22) NOT NULL,
                    totalAmount DECIMAL(18,2) NOT NULL
                )
            END

            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Productos')
            BEGIN
                CREATE TABLE Productos (
                    id INT PRIMARY KEY IDENTITY(1,1),
                    name NVARCHAR(100) NOT NULL,
                    price DECIMAL(18,2) NOT NULL,
                    codigo INT NOT NULL,
                    isActive BIT NOT NULL
                )
            END

            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'FacturaDetalle')
            BEGIN
                CREATE TABLE FacturaDetalle (
                    id INT PRIMARY KEY IDENTITY(1,1),
                    facturaId INT NOT NULL FOREIGN KEY REFERENCES Facturas(id),
                    productId INT NOT NULL FOREIGN KEY REFERENCES Productos(id),
                    cantidad INT NOT NULL,
                    precioUnitario DECIMAL(18,2) NOT NULL,
                    subtotal DECIMAL(18,2) NOT NULL
                )
            END
            """,
            conexion);
        crearTablas.ExecuteNonQuery();

        using SqlCommand existeData = new SqlCommand("SELECT COUNT(*) FROM Productos", conexion);
        int cantidad = (int)existeData.ExecuteScalar();
        if (cantidad > 0)
        {
            return;
        }

        using SqlCommand seed = new SqlCommand(
            """
            INSERT INTO Productos (name, price, codigo, isActive) VALUES
            (N'Coca Cola x 1.5L', 2600.00, 1, 1),
            (N'Yerba Mate Canarias x 1kg', 11000.00, 2, 1),
            (N'Agua Mineral x 1L', 1300.00, 3, 1)
            """,
            conexion);
        seed.ExecuteNonQuery();
    }
}