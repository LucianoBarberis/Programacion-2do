using Microsoft.Data.SqlClient;
using TP_01_GestionDeFacturas.Modelos;

namespace Taller.Datos;

internal class FacturacionDao
{
    public int Emitir(Factura factura)
    {
        if (string.IsNullOrWhiteSpace(factura.ClienteNombre))
            throw new ArgumentException("El nombre del cliente es obligatorio.");
        if (string.IsNullOrWhiteSpace(factura.ClienteDocumento))
            throw new ArgumentException("El documento del cliente es obligatorio.");
        if (factura.Detalles == null || factura.Detalles.Count == 0)
            throw new ArgumentException("La factura debe tener al menos una línea.");

        var consolidadas = factura.Detalles
            .GroupBy(d => d.ProductoId)
            .Select(g => new { ProductoId = g.Key, Cantidad = g.Sum(x => x.Cantidad) })
            .ToList();

        if (consolidadas.Any(x => x.Cantidad <= 0))
            throw new ArgumentException("La cantidad debe ser > 0.");

        var precios = new Dictionary<int, (string nombre, decimal precio)>();

        using (SqlConnection cnVal = Conexion.Crear())
        {
            cnVal.Open();
            foreach (var item in consolidadas)
            {
                using SqlCommand cmd = new SqlCommand(
                    "SELECT name, price, isActive FROM Productos WHERE id = @id", cnVal);
                cmd.Parameters.AddWithValue("@id", item.ProductoId);

                using SqlDataReader lector = cmd.ExecuteReader();
                if (!lector.Read())
                    throw new InvalidOperationException($"Producto Id {item.ProductoId} no existe.");

                bool activo = (bool)lector["isActive"];
                if (!activo)
                    throw new InvalidOperationException($"El producto '{lector["name"]}' está inactivo y no puede facturarse.");

                precios[item.ProductoId] = (lector["name"].ToString()!, (decimal)lector["price"]);
            }
        }

        var detallesFinal = consolidadas.Select(x =>
        {
            var (nombre, precio) = precios[x.ProductoId];
            return new FacturaDetalle
            {
                ProductoId = x.ProductoId,
                ProductoNombre = nombre,
                Cantidad = x.Cantidad,
                PrecioUnitario = precio,
                Subtotal = precio * x.Cantidad
            };
        }).ToList();

        decimal total = detallesFinal.Sum(d => d.Subtotal);

        using SqlConnection conexion = Conexion.Crear();
        conexion.Open();
        using SqlTransaction transaccion = conexion.BeginTransaction();

        try
        {
            int proximoNumero;
            using (SqlCommand cmdMax = new SqlCommand("SELECT ISNULL(MAX(facturaNro),0) FROM Facturas", conexion, transaccion))
                proximoNumero = (int)cmdMax.ExecuteScalar()! + 1;
            int facturaId;

            using (SqlCommand cmdCab = new SqlCommand(
                """
                INSERT INTO Facturas (facturaNro, dateCreated, clientName, clientDni, totalAmount)
                VALUES (@nro, @fec, @nom, @dni, @tot);
                SELECT CAST(SCOPE_IDENTITY() AS INT);
                """,
                conexion, transaccion))
            {
                cmdCab.Parameters.AddWithValue("@nro", proximoNumero);
                cmdCab.Parameters.AddWithValue("@fec", factura.Fecha.Date);
                cmdCab.Parameters.AddWithValue("@nom", factura.ClienteNombre.Trim());
                cmdCab.Parameters.AddWithValue("@dni", factura.ClienteDocumento.Trim());
                cmdCab.Parameters.AddWithValue("@tot", total);
                facturaId = (int)cmdCab.ExecuteScalar()!;
            }

            foreach (var d in detallesFinal)
            {
                using SqlCommand cmdDet = new SqlCommand(
                    "INSERT INTO FacturaDetalle (facturaId, productId, cantidad, precioUnitario, subtotal) VALUES (@fid,@pid,@cant,@pu,@sub)",
                    conexion, transaccion);
                cmdDet.Parameters.AddWithValue("@fid", facturaId);
                cmdDet.Parameters.AddWithValue("@pid", d.ProductoId);
                cmdDet.Parameters.AddWithValue("@cant", d.Cantidad);
                cmdDet.Parameters.AddWithValue("@pu", d.PrecioUnitario);
                cmdDet.Parameters.AddWithValue("@sub", d.Subtotal);
                cmdDet.ExecuteNonQuery();
            }

            transaccion.Commit();
            return proximoNumero;
        }
        catch
        {
            try { transaccion.Rollback(); } catch { }
            throw;
        }
    }

    public List<Factura> Listar(DateTime? desde, DateTime? hasta, string? clienteFiltro)
    {
        var lista = new List<Factura>();

        using SqlConnection conexion = Conexion.Crear();
        conexion.Open();

        string sql = "SELECT id, facturaNro, dateCreated, clientName, clientDni, totalAmount FROM Facturas WHERE 1=1 ";
        if (desde.HasValue) sql += "AND dateCreated >= @desde ";
        if (hasta.HasValue) sql += "AND dateCreated <= @hasta ";
        if (!string.IsNullOrWhiteSpace(clienteFiltro)) sql += "AND (clientName LIKE @cli OR clientDni LIKE @cli) ";
        sql += "ORDER BY facturaNro DESC";

        using SqlCommand comando = new SqlCommand(sql, conexion);
        if (desde.HasValue) comando.Parameters.AddWithValue("@desde", desde.Value.Date);
        if (hasta.HasValue) comando.Parameters.AddWithValue("@hasta", hasta.Value.Date);
        if (!string.IsNullOrWhiteSpace(clienteFiltro)) comando.Parameters.AddWithValue("@cli", $"%{clienteFiltro.Trim()}%");

        using SqlDataReader lector = comando.ExecuteReader();
        while (lector.Read())
        {
            lista.Add(new Factura
            {
                Id = (int)lector["id"],
                Numero = (int)lector["facturaNro"],
                Fecha = (DateTime)lector["dateCreated"],
                ClienteNombre = lector["clientName"].ToString() ?? string.Empty,
                ClienteDocumento = lector["clientDni"].ToString() ?? string.Empty,
                Total = (decimal)lector["totalAmount"]
            });
        }

        return lista;
    }

    public Factura? ObtenerConDetalle(int facturaId)
    {
        using SqlConnection conexion = Conexion.Crear();
        conexion.Open();

        using SqlCommand cmdCab = new SqlCommand(
            "SELECT id, facturaNro, dateCreated, clientName, clientDni, totalAmount FROM Facturas WHERE id = @id",
            conexion);
        cmdCab.Parameters.AddWithValue("@id", facturaId);

        Factura? factura = null;
        using (SqlDataReader lector = cmdCab.ExecuteReader())
        {
            if (!lector.Read()) return null;
            factura = new Factura
            {
                Id = (int)lector["id"],
                Numero = (int)lector["facturaNro"],
                Fecha = (DateTime)lector["dateCreated"],
                ClienteNombre = lector["clientName"].ToString() ?? string.Empty,
                ClienteDocumento = lector["clientDni"].ToString() ?? string.Empty,
                Total = (decimal)lector["totalAmount"]
            };
        }

        using SqlCommand cmdDet = new SqlCommand(
            """
            SELECT d.id, d.facturaId, d.productId, d.cantidad, d.precioUnitario, d.subtotal, p.name, p.codigo
            FROM FacturaDetalle d JOIN Productos p ON p.id = d.productId
            WHERE d.facturaId = @fid ORDER BY d.id
            """,
            conexion);
        cmdDet.Parameters.AddWithValue("@fid", facturaId);

        using SqlDataReader lectorDet = cmdDet.ExecuteReader();
        while (lectorDet.Read())
        {
            factura.Detalles.Add(new FacturaDetalle
            {
                Id = (int)lectorDet["id"],
                FacturaId = (int)lectorDet["facturaId"],
                ProductoId = (int)lectorDet["productId"],
                Cantidad = (int)lectorDet["cantidad"],
                PrecioUnitario = (decimal)lectorDet["precioUnitario"],
                Subtotal = (decimal)lectorDet["subtotal"],
                ProductoNombre = lectorDet["name"].ToString() ?? string.Empty,
                ProductoCodigo = (int)lectorDet["codigo"]
            });
        }

        return factura;
    }

    public List<InformeProducto> InformePorProducto(DateTime desde, DateTime hasta)
    {
        var lista = new List<InformeProducto>();

        using SqlConnection conexion = Conexion.Crear();
        conexion.Open();

        using SqlCommand comando = new SqlCommand(
            """
            SELECT p.id, p.codigo, p.name, SUM(d.cantidad) AS cant, SUM(d.subtotal) AS monto
            FROM FacturaDetalle d
            JOIN Productos p ON p.id = d.productId
            JOIN Facturas f ON f.id = d.facturaId
            WHERE f.dateCreated BETWEEN @desde AND @hasta
            GROUP BY p.id, p.codigo, p.name
            ORDER BY monto DESC
            """,
            conexion);
        comando.Parameters.AddWithValue("@desde", desde.Date);
        comando.Parameters.AddWithValue("@hasta", hasta.Date);

        using SqlDataReader lector = comando.ExecuteReader();
        while (lector.Read())
        {
            lista.Add(new InformeProducto
            {
                ProductoId = (int)lector["id"],
                Codigo = (int)lector["codigo"],
                Nombre = lector["name"].ToString() ?? string.Empty,
                CantidadFacturada = lector["cant"] == DBNull.Value ? 0 : Convert.ToInt32(lector["cant"]),
                MontoFacturado = lector["monto"] == DBNull.Value ? 0 : (decimal)lector["monto"]
            });
        }

        return lista;
    }
}
