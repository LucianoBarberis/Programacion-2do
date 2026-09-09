using Microsoft.Data.SqlClient;
using Taller.Datos;
using TP_01_GestionDeFacturas.Modelos;

namespace TP_01_GestionDeFacturas
{
    public partial class Form1 : Form
    {
        private readonly ProductosDao _productosDao = new();
        private readonly FacturacionDao _facturacionDao = new();

        private Producto? _productoEditando = null;
        private readonly List<FacturaDetalle> _carrito = new();
        private List<Producto> _productosActivosCache = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try { Conexion.AsegurarBaseDeDatos(); }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar a SQL Server LocalDB.\n" + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dtpFacFecha.Value = DateTime.Today;
            dtpConsDesde.Value = DateTime.Today.AddMonths(-1);
            dtpConsHasta.Value = DateTime.Today;
            dtpInfDesde.Value = DateTime.Today.AddMonths(-1);
            dtpInfHasta.Value = DateTime.Today;

            CargarProductos();
            CargarComboProductosActivos();
            BuscarFacturas();
        }


        private void btnProdBuscar_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void txtProdBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CargarProductos();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            CargarProductoDesdeGrilla();
        }

        private void btnProdGuardar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtProdCodigo.Text.Trim(), out int codigo) || codigo <= 0)
            { MessageBox.Show("Código debe ser un número entero mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtProdCodigo.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtProdNombre.Text))
            { MessageBox.Show("El nombre no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtProdNombre.Focus(); return; }
            if (nudProdPrecio.Value < 0)
            { MessageBox.Show("El precio no puede ser negativo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var p = new Producto
            {
                Id = _productoEditando?.Id ?? 0,
                Codigo = codigo,
                Nombre = txtProdNombre.Text.Trim(),
                Precio = nudProdPrecio.Value,
                Activo = chkProdActivo.Checked
            };

            try
            {
                if (_productoEditando == null)
                {
                    int nuevoId = _productosDao.Insertar(p);
                    MessageBox.Show($"Producto creado (Id {nuevoId}).", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _productosDao.Actualizar(p);
                    MessageBox.Show("Producto actualizado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CargarProductos();
                CargarComboProductosActivos();
                LimpiarFormProducto();
            }
            catch (InvalidOperationException ex) { MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (SqlException ex) { MostrarErrorSql(ex); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnProdEliminar_Click(object sender, EventArgs e)
        {
            if (_productoEditando == null)
            { MessageBox.Show("Seleccione un producto de la grilla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            var p = _productoEditando;
            bool referenciado = false;
            try { referenciado = _productosDao.EstaReferenciado(p.Id); } catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (referenciado)
            {
                if (MessageBox.Show($"'{p.Nombre}' está usado en facturas. ¿Desactivarlo (baja lógica)?", "Confirmar baja lógica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                try
                {
                    _productosDao.Desactivar(p.Id);
                    MessageBox.Show("Producto desactivado. No podrá usarse en facturas nuevas.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex) { MostrarErrorSql(ex); return; }
            }
            else
            {
                if (MessageBox.Show($"¿Eliminar '{p.Nombre}' (código {p.Codigo})?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
                try
                {
                    _productosDao.EliminarSiNoTieneDetalle(p.Id);
                    MessageBox.Show("Producto eliminado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (InvalidOperationException ex) { MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                catch (SqlException ex) { MostrarErrorSql(ex); return; }
            }

            CargarProductos();
            CargarComboProductosActivos();
            LimpiarFormProducto();
        }

        private void CargarProductos()
        {
            try
            {
                var lista = _productosDao.Listar(txtProdBuscar.Text.Trim());
                dgvProductos.DataSource = null;
                dgvProductos.AutoGenerateColumns = false;
                dgvProductos.Columns.Clear();
                dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", Visible = false });
                dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Codigo", HeaderText = "Código", Width = 80 });
                dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Precio", HeaderText = "Precio", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
                dgvProductos.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "Activo", HeaderText = "Activo", Width = 60 });

                if (lista.Count == 0)
                    dgvProductos.DataSource = new List<object> { new { Id = 0, Codigo = 0, Nombre = "(sin resultados)", Precio = 0m, Activo = false } };
                else
                    dgvProductos.DataSource = lista.Select(p => new { p.Id, p.Codigo, p.Nombre, p.Precio, p.Activo }).ToList();
            }
            catch (SqlException ex) { MostrarErrorSql(ex); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void CargarProductoDesdeGrilla()
        {
            if (dgvProductos.SelectedRows.Count == 0) return;
            var row = dgvProductos.SelectedRows[0];
            if (row.DataBoundItem == null) return;
            var prop = row.DataBoundItem.GetType().GetProperty("Id");
            if (prop == null) return;
            int id = (int)prop.GetValue(row.DataBoundItem)!;
            if (id == 0) return;

            try
            {
                var p = _productosDao.ObtenerPorId(id);
                if (p == null) return;
                _productoEditando = p;
                txtProdCodigo.Text = p.Codigo.ToString();
                txtProdNombre.Text = p.Nombre;
                nudProdPrecio.Value = p.Precio < 0 ? 0 : (p.Precio > nudProdPrecio.Maximum ? nudProdPrecio.Maximum : p.Precio);
                chkProdActivo.Checked = p.Activo;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void LimpiarFormProducto()
        {
            _productoEditando = null;
            txtProdCodigo.Clear();
            txtProdNombre.Clear();
            nudProdPrecio.Value = 0;
            chkProdActivo.Checked = true;
            txtProdCodigo.Focus();
            dgvProductos.ClearSelection();
        }

        private void CargarComboProductosActivos()
        {
            try
            {
                _productosActivosCache = _productosDao.ListarActivos();
                cboFacProducto.DataSource = null;
                cboFacProducto.DataSource = _productosActivosCache;
                cboFacProducto.DisplayMember = "Nombre";
                cboFacProducto.ValueMember = "Id";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnFacAgregar_Click(object sender, EventArgs e)
        {
            if (cboFacProducto.SelectedItem is not Producto prod)
            { MessageBox.Show("Seleccione un producto activo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (nudFacCantidad.Value <= 0)
            { MessageBox.Show("La cantidad debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int cant = (int)nudFacCantidad.Value;
            var existente = _carrito.FirstOrDefault(d => d.ProductoId == prod.Id);
            if (existente != null)
            {
                existente.Cantidad += cant;
                existente.Subtotal = existente.Cantidad * existente.PrecioUnitario;
            }
            else
            {
                _carrito.Add(new FacturaDetalle
                {
                    ProductoId = prod.Id,
                    ProductoCodigo = prod.Codigo,
                    ProductoNombre = prod.Nombre,
                    Cantidad = cant,
                    PrecioUnitario = prod.Precio,
                    Subtotal = prod.Precio * cant
                });
            }
            RefrescarCarrito();
        }

        private void btnFacQuitar_Click(object sender, EventArgs e)
        {
            if (dgvFacDetalle.SelectedRows.Count == 0)
            { MessageBox.Show("Seleccione una línea para quitar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            int idx = dgvFacDetalle.SelectedRows[0].Index;
            if (idx >= 0 && idx < _carrito.Count)
            {
                _carrito.RemoveAt(idx);
                RefrescarCarrito();
            }
        }

        private void btnFacGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFacCliente.Text))
            { MessageBox.Show("Ingrese el nombre del cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtFacCliente.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtFacDni.Text))
            { MessageBox.Show("Ingrese el DNI/CUIT del cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtFacDni.Focus(); return; }
            if (_carrito.Count == 0)
            { MessageBox.Show("Agregue al menos una línea.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var factura = new Factura
            {
                Fecha = dtpFacFecha.Value.Date,
                ClienteNombre = txtFacCliente.Text.Trim(),
                ClienteDocumento = txtFacDni.Text.Trim(),
                Detalles = new List<FacturaDetalle>(_carrito)
            };

            try
            {
                int nro = _facturacionDao.Emitir(factura);
                MessageBox.Show($"Factura N° {nro} emitida.\nTotal: $ {factura.Detalles.Sum(d => d.PrecioUnitario * d.Cantidad):N2}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFacCliente.Clear();
                txtFacDni.Clear();
                dtpFacFecha.Value = DateTime.Today;
                _carrito.Clear();
                RefrescarCarrito();
                BuscarFacturas();
            }
            catch (InvalidOperationException ex) { MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (SqlException ex) { MostrarErrorSql(ex); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void RefrescarCarrito()
        {
            dgvFacDetalle.DataSource = null;
            dgvFacDetalle.AutoGenerateColumns = false;
            dgvFacDetalle.Columns.Clear();
            dgvFacDetalle.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductoCodigo", HeaderText = "Código", Width = 70 });
            dgvFacDetalle.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductoNombre", HeaderText = "Producto", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvFacDetalle.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = "Cant.", Width = 60 });
            dgvFacDetalle.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrecioUnitario", HeaderText = "Precio unit.", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvFacDetalle.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Subtotal", HeaderText = "Subtotal", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvFacDetalle.DataSource = _carrito.Select(d => new { d.ProductoCodigo, d.ProductoNombre, d.Cantidad, d.PrecioUnitario, d.Subtotal, d.ProductoId }).ToList();
            lblFacTotal.Text = $"TOTAL: $ {_carrito.Sum(d => d.Subtotal):N2}";
        }


        private void btnConsBuscar_Click(object sender, EventArgs e)
        {
            BuscarFacturas();
        }

        private void dgvConsFacturas_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDetalleFacturaSeleccionada();
        }

        private void btnInfGenerar_Click(object sender, EventArgs e)
        {
            if (dtpInfDesde.Value.Date > dtpInfHasta.Value.Date)
            { MessageBox.Show("La fecha 'desde' no puede ser mayor que 'hasta'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                var lista = _facturacionDao.InformePorProducto(dtpInfDesde.Value.Date, dtpInfHasta.Value.Date);
                dgvInforme.DataSource = null;
                dgvInforme.AutoGenerateColumns = false;
                dgvInforme.Columns.Clear();
                dgvInforme.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Codigo", HeaderText = "Código", Width = 70 });
                dgvInforme.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Producto", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvInforme.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CantidadFacturada", HeaderText = "Cantidad", Width = 80 });
                dgvInforme.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MontoFacturado", HeaderText = "Monto", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });

                if (lista.Count == 0)
                    dgvInforme.DataSource = new List<object> { new { Codigo = 0, Nombre = "(sin datos en el período)", CantidadFacturada = 0, MontoFacturado = 0m } };
                else
                    dgvInforme.DataSource = lista.Select(x => new { x.Codigo, x.Nombre, x.CantidadFacturada, x.MontoFacturado }).ToList();
            }
            catch (SqlException ex) { MostrarErrorSql(ex); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BuscarFacturas()
        {
            try
            {
                if (dtpConsDesde.Value.Date > dtpConsHasta.Value.Date)
                { MessageBox.Show("La fecha 'desde' no puede ser mayor que 'hasta'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                var lista = _facturacionDao.Listar(dtpConsDesde.Value.Date, dtpConsHasta.Value.Date, txtConsCliente.Text.Trim());
                dgvConsFacturas.DataSource = null;
                dgvConsFacturas.AutoGenerateColumns = false;
                dgvConsFacturas.Columns.Clear();
                dgvConsFacturas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", Visible = false });
                dgvConsFacturas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "N°", Width = 60 });
                dgvConsFacturas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Fecha", HeaderText = "Fecha", Width = 95, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
                dgvConsFacturas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClienteNombre", HeaderText = "Cliente", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvConsFacturas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClienteDocumento", HeaderText = "DNI/CUIT", Width = 110 });
                dgvConsFacturas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Total", HeaderText = "Total", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });

                if (lista.Count == 0)
                {
                    dgvConsFacturas.DataSource = new List<object>();
                    dgvConsDetalle.DataSource = null;
                    return;
                }
                dgvConsFacturas.DataSource = lista.Select(f => new { f.Id, f.Numero, f.Fecha, f.ClienteNombre, f.ClienteDocumento, f.Total }).ToList();
                dgvConsDetalle.DataSource = null;
            }
            catch (SqlException ex) { MostrarErrorSql(ex); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void MostrarDetalleFacturaSeleccionada()
        {
            if (dgvConsFacturas.SelectedRows.Count == 0) return;
            var item = dgvConsFacturas.SelectedRows[0].DataBoundItem;
            if (item == null) return;
            var prop = item.GetType().GetProperty("Id");
            if (prop == null) return;
            int id = (int)prop.GetValue(item)!;

            try
            {
                var fac = _facturacionDao.ObtenerConDetalle(id);
                if (fac == null) return;
                dgvConsDetalle.DataSource = null;
                dgvConsDetalle.AutoGenerateColumns = false;
                dgvConsDetalle.Columns.Clear();
                dgvConsDetalle.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductoCodigo", HeaderText = "Código", Width = 70 });
                dgvConsDetalle.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductoNombre", HeaderText = "Producto", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvConsDetalle.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = "Cant.", Width = 60 });
                dgvConsDetalle.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrecioUnitario", HeaderText = "Precio unit. (copiado)", Width = 140, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
                dgvConsDetalle.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Subtotal", HeaderText = "Subtotal", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
                dgvConsDetalle.DataSource = fac.Detalles.Select(d => new { d.ProductoCodigo, d.ProductoNombre, d.Cantidad, d.PrecioUnitario, d.Subtotal }).ToList();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private static void MostrarErrorSql(SqlException ex)
        {
            string msg = ex.Number switch
            {
                2627 or 2601 => "Violación de unicidad (código o número de factura duplicado).\n" + ex.Message,
                547 => "Violación de clave foránea (referencia inexistente).\n" + ex.Message,
                -1 or 2 or 53 => "Error de conexión a SQL Server. Verifique LocalDB y la cadena en Conexion.cs.\n" + ex.Message,
                _ => $"Error SQL ({ex.Number}): {ex.Message}"
            };
            MessageBox.Show(msg, "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
