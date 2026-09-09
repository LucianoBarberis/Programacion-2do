using Microsoft.Data.SqlClient;
using TP_01_GestionDeFacturas.Modelos;

namespace Taller.Datos;

internal class ProductosDao
{
    public List<Producto> Listar(string? filtro = null)
    {
        var lista = new List<Producto>();

        using SqlConnection conexion = Conexion.Crear();
        conexion.Open();

        string sql = "SELECT id, codigo, name, price, isActive FROM Productos WHERE 1=1 ";
        if (!string.IsNullOrWhiteSpace(filtro))
            sql += "AND (CAST(codigo AS NVARCHAR) LIKE @f OR name LIKE @f) ";
        sql += "ORDER BY name";

        using SqlCommand comando = new SqlCommand(sql, conexion);
        if (!string.IsNullOrWhiteSpace(filtro))
            comando.Parameters.AddWithValue("@f", $"%{filtro.Trim()}%");

        using SqlDataReader lector = comando.ExecuteReader();
        while (lector.Read())
            lista.Add(Mapear(lector));

        return lista;
    }

    public List<Producto> ListarActivos()
    {
        var lista = new List<Producto>();

        using SqlConnection conexion = Conexion.Crear();
        conexion.Open();

        using SqlCommand comando = new SqlCommand(
            "SELECT id, codigo, name, price, isActive FROM Productos WHERE isActive = 1 ORDER BY name",
            conexion);

        using SqlDataReader lector = comando.ExecuteReader();
        while (lector.Read())
            lista.Add(Mapear(lector));

        return lista;
    }

    public Producto? ObtenerPorId(int id)
    {
        using SqlConnection conexion = Conexion.Crear();
        conexion.Open();

        using SqlCommand comando = new SqlCommand(
            "SELECT id, codigo, name, price, isActive FROM Productos WHERE id = @id",
            conexion);
        comando.Parameters.AddWithValue("@id", id);

        using SqlDataReader lector = comando.ExecuteReader();
        if (!lector.Read()) return null;
        return Mapear(lector);
    }

    public bool ExisteCodigo(int codigo, int? excluirId = null)
    {
        using SqlConnection conexion = Conexion.Crear();
        conexion.Open();

        string sql = "SELECT COUNT(*) FROM Productos WHERE codigo = @cod";
        if (excluirId.HasValue) sql += " AND id <> @excluir";

        using SqlCommand comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@cod", codigo);
        if (excluirId.HasValue) comando.Parameters.AddWithValue("@excluir", excluirId.Value);

        return (int)comando.ExecuteScalar()! > 0;
    }

    public int Insertar(Producto p)
    {
        if (string.IsNullOrWhiteSpace(p.Nombre))
            throw new ArgumentException("El nombre no puede estar vacío.");
        if (p.Precio < 0)
            throw new ArgumentException("El precio no puede ser negativo.");
        if (p.Codigo <= 0)
            throw new ArgumentException("El código debe ser mayor a 0.");
        if (ExisteCodigo(p.Codigo))
            throw new InvalidOperationException($"Ya existe un producto con código {p.Codigo}.");

        using SqlConnection conexion = Conexion.Crear();
        conexion.Open();

        using SqlCommand comando = new SqlCommand(
            """
            INSERT INTO Productos (codigo, name, price, isActive)
            VALUES (@cod, @nom, @pre, @act);
            SELECT CAST(SCOPE_IDENTITY() AS INT);
            """,
            conexion);

        comando.Parameters.AddWithValue("@cod", p.Codigo);
        comando.Parameters.AddWithValue("@nom", p.Nombre.Trim());
        comando.Parameters.AddWithValue("@pre", p.Precio);
        comando.Parameters.AddWithValue("@act", p.Activo);

        return (int)comando.ExecuteScalar()!;
    }

    public void Actualizar(Producto p)
    {
        if (string.IsNullOrWhiteSpace(p.Nombre))
            throw new ArgumentException("El nombre no puede estar vacío.");
        if (p.Precio < 0)
            throw new ArgumentException("El precio no puede ser negativo.");
        if (ExisteCodigo(p.Codigo, p.Id))
            throw new InvalidOperationException($"Ya existe otro producto con código {p.Codigo}.");

        using SqlConnection conexion = Conexion.Crear();
        conexion.Open();

        using SqlCommand comando = new SqlCommand(
            "UPDATE Productos SET codigo=@cod, name=@nom, price=@pre, isActive=@act WHERE id=@id",
            conexion);

        comando.Parameters.AddWithValue("@cod", p.Codigo);
        comando.Parameters.AddWithValue("@nom", p.Nombre.Trim());
        comando.Parameters.AddWithValue("@pre", p.Precio);
        comando.Parameters.AddWithValue("@act", p.Activo);
        comando.Parameters.AddWithValue("@id", p.Id);

        int filas = comando.ExecuteNonQuery();
        if (filas == 0) throw new InvalidOperationException("Producto no encontrado.");
    }

    public bool EstaReferenciado(int productoId)
    {
        using SqlConnection conexion = Conexion.Crear();
        conexion.Open();

        using SqlCommand comando = new SqlCommand(
            "SELECT COUNT(*) FROM FacturaDetalle WHERE productId = @id",
            conexion);
        comando.Parameters.AddWithValue("@id", productoId);

        return (int)comando.ExecuteScalar()! > 0;
    }

    public int EliminarSiNoTieneDetalle(int id)
    {
        if (EstaReferenciado(id))
            throw new InvalidOperationException("No se puede eliminar: el producto está usado en facturas. Desactívelo en su lugar.");

        using SqlConnection conexion = Conexion.Crear();
        conexion.Open();

        using SqlCommand comando = new SqlCommand("DELETE FROM Productos WHERE id = @id", conexion);
        comando.Parameters.AddWithValue("@id", id);
        return comando.ExecuteNonQuery();
    }

    public void Desactivar(int id)
    {
        using SqlConnection conexion = Conexion.Crear();
        conexion.Open();

        using SqlCommand comando = new SqlCommand(
            "UPDATE Productos SET isActive = 0 WHERE id = @id", conexion);
        comando.Parameters.AddWithValue("@id", id);
        comando.ExecuteNonQuery();
    }

    private static Producto Mapear(SqlDataReader lector)
    {
        return new Producto
        {
            Id = (int)lector["id"],
            Codigo = (int)lector["codigo"],
            Nombre = lector["name"].ToString() ?? string.Empty,
            Precio = (decimal)lector["price"],
            Activo = (bool)lector["isActive"]
        };
    }
}
