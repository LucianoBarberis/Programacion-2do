# TP01 — Gestión de Facturas

App de escritorio **.NET 8 + Windows Forms + ADO.NET modo conectado** para emitir y consultar facturas. Un solo formulario con `TabControl`.

## Requisitos

- .NET SDK 8
- SQL Server LocalDB (instalado con Visual Studio) o SQL Server
- Windows

## Base de datos

No hay que ejecutar scripts a mano. Al iniciar la app:

1. `Conexion.AsegurarBaseDeDatos()` crea la base `TP01Facturas` si no existe (`master -> CREATE DATABASE`).
2. Crea las 3 tablas si faltan (`Productos`, `Facturas`, `FacturaDetalle`) con PK, FK, `UNIQUE`, `CHECK` y `NOT NULL`.
3. Inserta datos de prueba si `Productos` está vacía (3 productos).

Para forzar recreación: borrá la base en SSMS / `sqllocaldb` o cambiá el nombre en la cadena.

## Cadena de conexión

Archivo `BaseDeDatos/Conexion.cs`:

```csharp
public const string CadenaConexion =
    @"Server=(localdb)\mssqllocaldb;Database=TP01Facturas;Integrated Security=true;TrustServerCertificate=true;";
```

- `Server=(localdb)\mssqllocaldb` → LocalDB local
- `Database=TP01Facturas` → nombre de la base
- `TrustServerCertificate=true` → evita error de certificado local

Si usás SQL Server Express/otro: cambiá `Server=.\SQLEXPRESS` o `Server=localhost` y ajustá `Integrated Security` / `User Id` / `Password`.

## Cómo ejecutar

Desde Visual Studio: abrir `TP_01-GestionDeFacturas.slnx` → **F5**.

Desde terminal:

```bash
dotnet restore
dotnet build
dotnet run --project "Cuatrimestre 2/TP_01-GestionDeFacturas/TP_01-GestionDeFacturas.csproj"
```

## Uso

- **Productos:** buscar por código/nombre, alta/modificación (código único, nombre no vacío, precio ≥0), baja física si no tiene detalles o lógica (`Activo=0`) si está facturado.
- **Emitir Factura:** fecha (hoy), cliente/DNI obligatorios, agregar/quitar líneas (producto activo, cantidad >0, duplicados suman), total en pantalla, grabar en **una transacción** (`SqlTransaction`) copia `PrecioUnitario` al detalle.
- **Consultas:** filtro por fechas y cliente, ver detalle solo lectura, informe por producto (cantidad y monto en período).

## Estructura

```
Modelos/         -> Producto, Factura, FacturaDetalle, InformeProducto
BaseDeDatos/     -> Conexion.cs, ProductosDao.cs, FacturacionDao.cs (SqlConnection/SqlCommand/SqlDataReader/SqlTransaction, parámetros @Nombre)
Form1.cs         -> único formulario (3 tabs, sin SQL, validación en UI + DAO)
```

Formularios no contienen SQL; todo acceso pasa por los DAO con parámetros (nunca concatenar).
