namespace TP_01_GestionDeFacturas
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabProductos;
        private System.Windows.Forms.TabPage tabFacturacion;
        private System.Windows.Forms.TabPage tabConsultas;

        private System.Windows.Forms.TextBox txtProdBuscar;
        private System.Windows.Forms.Button btnProdBuscar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TextBox txtProdCodigo;
        private System.Windows.Forms.TextBox txtProdNombre;
        private System.Windows.Forms.NumericUpDown nudProdPrecio;
        private System.Windows.Forms.CheckBox chkProdActivo;
        private System.Windows.Forms.Button btnProdGuardar;
        private System.Windows.Forms.Button btnProdEliminar;

        private System.Windows.Forms.DateTimePicker dtpFacFecha;
        private System.Windows.Forms.TextBox txtFacCliente;
        private System.Windows.Forms.TextBox txtFacDni;
        private System.Windows.Forms.ComboBox cboFacProducto;
        private System.Windows.Forms.NumericUpDown nudFacCantidad;
        private System.Windows.Forms.Button btnFacAgregar;
        private System.Windows.Forms.Button btnFacQuitar;
        private System.Windows.Forms.DataGridView dgvFacDetalle;
        private System.Windows.Forms.Label lblFacTotal;
        private System.Windows.Forms.Button btnFacGrabar;

        private System.Windows.Forms.DateTimePicker dtpConsDesde;
        private System.Windows.Forms.DateTimePicker dtpConsHasta;
        private System.Windows.Forms.TextBox txtConsCliente;
        private System.Windows.Forms.Button btnConsBuscar;
        private System.Windows.Forms.DataGridView dgvConsFacturas;
        private System.Windows.Forms.DataGridView dgvConsDetalle;
        private System.Windows.Forms.DateTimePicker dtpInfDesde;
        private System.Windows.Forms.DateTimePicker dtpInfHasta;
        private System.Windows.Forms.Button btnInfGenerar;
        private System.Windows.Forms.DataGridView dgvInforme;

        private void InitializeComponent()
        {
            tabMain = new TabControl();
            tabProductos = new TabPage();
            txtProdBuscar = new TextBox();
            btnProdBuscar = new Button();
            dgvProductos = new DataGridView();
            txtProdCodigo = new TextBox();
            txtProdNombre = new TextBox();
            nudProdPrecio = new NumericUpDown();
            chkProdActivo = new CheckBox();
            btnProdGuardar = new Button();
            btnProdEliminar = new Button();
            tabFacturacion = new TabPage();
            dtpFacFecha = new DateTimePicker();
            txtFacCliente = new TextBox();
            txtFacDni = new TextBox();
            cboFacProducto = new ComboBox();
            nudFacCantidad = new NumericUpDown();
            btnFacAgregar = new Button();
            btnFacQuitar = new Button();
            dgvFacDetalle = new DataGridView();
            lblFacTotal = new Label();
            btnFacGrabar = new Button();
            tabConsultas = new TabPage();
            dtpConsDesde = new DateTimePicker();
            dtpConsHasta = new DateTimePicker();
            txtConsCliente = new TextBox();
            btnConsBuscar = new Button();
            dgvConsFacturas = new DataGridView();
            dgvConsDetalle = new DataGridView();
            lblInfTitulo = new Label();
            dtpInfDesde = new DateTimePicker();
            dtpInfHasta = new DateTimePicker();
            btnInfGenerar = new Button();
            dgvInforme = new DataGridView();
            tabMain.SuspendLayout();
            tabProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudProdPrecio).BeginInit();
            tabFacturacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudFacCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFacDetalle).BeginInit();
            tabConsultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConsFacturas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvConsDetalle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInforme).BeginInit();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabProductos);
            tabMain.Controls.Add(tabFacturacion);
            tabMain.Controls.Add(tabConsultas);
            tabMain.Dock = DockStyle.Fill;
            tabMain.Location = new Point(0, 0);
            tabMain.Margin = new Padding(3, 4, 3, 4);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1029, 720);
            tabMain.TabIndex = 0;
            // 
            // tabProductos
            // 
            tabProductos.Controls.Add(txtProdBuscar);
            tabProductos.Controls.Add(btnProdBuscar);
            tabProductos.Controls.Add(dgvProductos);
            tabProductos.Controls.Add(txtProdCodigo);
            tabProductos.Controls.Add(txtProdNombre);
            tabProductos.Controls.Add(nudProdPrecio);
            tabProductos.Controls.Add(chkProdActivo);
            tabProductos.Controls.Add(btnProdGuardar);
            tabProductos.Controls.Add(btnProdEliminar);
            tabProductos.Location = new Point(4, 29);
            tabProductos.Margin = new Padding(3, 4, 3, 4);
            tabProductos.Name = "tabProductos";
            tabProductos.Padding = new Padding(9, 11, 9, 11);
            tabProductos.Size = new Size(1021, 687);
            tabProductos.TabIndex = 0;
            tabProductos.Text = "Productos";
            // 
            // txtProdBuscar
            // 
            txtProdBuscar.Location = new Point(11, 13);
            txtProdBuscar.Margin = new Padding(3, 4, 3, 4);
            txtProdBuscar.Name = "txtProdBuscar";
            txtProdBuscar.PlaceholderText = "Buscar por código o nombre";
            txtProdBuscar.Size = new Size(251, 27);
            txtProdBuscar.TabIndex = 0;
            txtProdBuscar.KeyDown += txtProdBuscar_KeyDown;
            // 
            // btnProdBuscar
            // 
            btnProdBuscar.Location = new Point(272, 13);
            btnProdBuscar.Margin = new Padding(3, 4, 3, 4);
            btnProdBuscar.Name = "btnProdBuscar";
            btnProdBuscar.Size = new Size(80, 31);
            btnProdBuscar.TabIndex = 1;
            btnProdBuscar.Text = "Buscar";
            btnProdBuscar.Click += btnProdBuscar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeight = 29;
            dgvProductos.Location = new Point(11, 53);
            dgvProductos.Margin = new Padding(3, 4, 3, 4);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(983, 293);
            dgvProductos.TabIndex = 2;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            // 
            // txtProdCodigo
            // 
            txtProdCodigo.Location = new Point(11, 360);
            txtProdCodigo.Margin = new Padding(3, 4, 3, 4);
            txtProdCodigo.Name = "txtProdCodigo";
            txtProdCodigo.PlaceholderText = "Código";
            txtProdCodigo.Size = new Size(91, 27);
            txtProdCodigo.TabIndex = 3;
            // 
            // txtProdNombre
            // 
            txtProdNombre.Location = new Point(114, 360);
            txtProdNombre.Margin = new Padding(3, 4, 3, 4);
            txtProdNombre.Name = "txtProdNombre";
            txtProdNombre.PlaceholderText = "Nombre";
            txtProdNombre.Size = new Size(297, 27);
            txtProdNombre.TabIndex = 4;
            // 
            // nudProdPrecio
            // 
            nudProdPrecio.DecimalPlaces = 2;
            nudProdPrecio.Location = new Point(423, 360);
            nudProdPrecio.Margin = new Padding(3, 4, 3, 4);
            nudProdPrecio.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudProdPrecio.Name = "nudProdPrecio";
            nudProdPrecio.Size = new Size(114, 27);
            nudProdPrecio.TabIndex = 5;
            // 
            // chkProdActivo
            // 
            chkProdActivo.AutoSize = true;
            chkProdActivo.Checked = true;
            chkProdActivo.CheckState = CheckState.Checked;
            chkProdActivo.Location = new Point(549, 363);
            chkProdActivo.Margin = new Padding(3, 4, 3, 4);
            chkProdActivo.Name = "chkProdActivo";
            chkProdActivo.Size = new Size(73, 24);
            chkProdActivo.TabIndex = 6;
            chkProdActivo.Text = "Activo";
            // 
            // btnProdGuardar
            // 
            btnProdGuardar.Location = new Point(11, 408);
            btnProdGuardar.Margin = new Padding(3, 4, 3, 4);
            btnProdGuardar.Name = "btnProdGuardar";
            btnProdGuardar.Size = new Size(80, 37);
            btnProdGuardar.TabIndex = 8;
            btnProdGuardar.Text = "Guardar";
            btnProdGuardar.Click += btnProdGuardar_Click;
            // 
            // btnProdEliminar
            // 
            btnProdEliminar.Location = new Point(100, 408);
            btnProdEliminar.Margin = new Padding(3, 4, 3, 4);
            btnProdEliminar.Name = "btnProdEliminar";
            btnProdEliminar.Size = new Size(137, 37);
            btnProdEliminar.TabIndex = 9;
            btnProdEliminar.Text = "Eliminar / Baja";
            btnProdEliminar.Click += btnProdEliminar_Click;
            // 
            // tabFacturacion
            // 
            tabFacturacion.Controls.Add(dtpFacFecha);
            tabFacturacion.Controls.Add(txtFacCliente);
            tabFacturacion.Controls.Add(txtFacDni);
            tabFacturacion.Controls.Add(cboFacProducto);
            tabFacturacion.Controls.Add(nudFacCantidad);
            tabFacturacion.Controls.Add(btnFacAgregar);
            tabFacturacion.Controls.Add(btnFacQuitar);
            tabFacturacion.Controls.Add(dgvFacDetalle);
            tabFacturacion.Controls.Add(lblFacTotal);
            tabFacturacion.Controls.Add(btnFacGrabar);
            tabFacturacion.Location = new Point(4, 29);
            tabFacturacion.Margin = new Padding(3, 4, 3, 4);
            tabFacturacion.Name = "tabFacturacion";
            tabFacturacion.Padding = new Padding(9, 11, 9, 11);
            tabFacturacion.Size = new Size(1021, 687);
            tabFacturacion.TabIndex = 1;
            tabFacturacion.Text = "Emitir Factura";
            // 
            // dtpFacFecha
            // 
            dtpFacFecha.Format = DateTimePickerFormat.Short;
            dtpFacFecha.Location = new Point(11, 13);
            dtpFacFecha.Margin = new Padding(3, 4, 3, 4);
            dtpFacFecha.Name = "dtpFacFecha";
            dtpFacFecha.Size = new Size(148, 27);
            dtpFacFecha.TabIndex = 0;
            // 
            // txtFacCliente
            // 
            txtFacCliente.Location = new Point(171, 13);
            txtFacCliente.Margin = new Padding(3, 4, 3, 4);
            txtFacCliente.Name = "txtFacCliente";
            txtFacCliente.PlaceholderText = "Cliente *";
            txtFacCliente.Size = new Size(251, 27);
            txtFacCliente.TabIndex = 1;
            // 
            // txtFacDni
            // 
            txtFacDni.Location = new Point(434, 13);
            txtFacDni.Margin = new Padding(3, 4, 3, 4);
            txtFacDni.Name = "txtFacDni";
            txtFacDni.PlaceholderText = "DNI/CUIT *";
            txtFacDni.Size = new Size(148, 27);
            txtFacDni.TabIndex = 2;
            // 
            // cboFacProducto
            // 
            cboFacProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFacProducto.Location = new Point(11, 60);
            cboFacProducto.Margin = new Padding(3, 4, 3, 4);
            cboFacProducto.Name = "cboFacProducto";
            cboFacProducto.Size = new Size(319, 28);
            cboFacProducto.TabIndex = 3;
            // 
            // nudFacCantidad
            // 
            nudFacCantidad.Location = new Point(343, 60);
            nudFacCantidad.Margin = new Padding(3, 4, 3, 4);
            nudFacCantidad.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudFacCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudFacCantidad.Name = "nudFacCantidad";
            nudFacCantidad.Size = new Size(80, 27);
            nudFacCantidad.TabIndex = 4;
            nudFacCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnFacAgregar
            // 
            btnFacAgregar.Location = new Point(434, 59);
            btnFacAgregar.Margin = new Padding(3, 4, 3, 4);
            btnFacAgregar.Name = "btnFacAgregar";
            btnFacAgregar.Size = new Size(80, 33);
            btnFacAgregar.TabIndex = 5;
            btnFacAgregar.Text = "Agregar";
            btnFacAgregar.Click += btnFacAgregar_Click;
            // 
            // btnFacQuitar
            // 
            btnFacQuitar.Location = new Point(523, 59);
            btnFacQuitar.Margin = new Padding(3, 4, 3, 4);
            btnFacQuitar.Name = "btnFacQuitar";
            btnFacQuitar.Size = new Size(80, 33);
            btnFacQuitar.TabIndex = 6;
            btnFacQuitar.Text = "Quitar";
            btnFacQuitar.Click += btnFacQuitar_Click;
            // 
            // dgvFacDetalle
            // 
            dgvFacDetalle.AllowUserToAddRows = false;
            dgvFacDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFacDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacDetalle.ColumnHeadersHeight = 29;
            dgvFacDetalle.Location = new Point(11, 107);
            dgvFacDetalle.Margin = new Padding(3, 4, 3, 4);
            dgvFacDetalle.Name = "dgvFacDetalle";
            dgvFacDetalle.ReadOnly = true;
            dgvFacDetalle.RowHeadersWidth = 51;
            dgvFacDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacDetalle.Size = new Size(983, 400);
            dgvFacDetalle.TabIndex = 7;
            // 
            // lblFacTotal
            // 
            lblFacTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblFacTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFacTotal.Location = new Point(11, 527);
            lblFacTotal.Name = "lblFacTotal";
            lblFacTotal.Size = new Size(286, 29);
            lblFacTotal.TabIndex = 8;
            lblFacTotal.Text = "TOTAL: $ 0,00";
            // 
            // btnFacGrabar
            // 
            btnFacGrabar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnFacGrabar.Location = new Point(846, 520);
            btnFacGrabar.Margin = new Padding(3, 4, 3, 4);
            btnFacGrabar.Name = "btnFacGrabar";
            btnFacGrabar.Size = new Size(149, 43);
            btnFacGrabar.TabIndex = 9;
            btnFacGrabar.Text = "Emitir factura";
            btnFacGrabar.Click += btnFacGrabar_Click;
            // 
            // tabConsultas
            // 
            tabConsultas.AutoScroll = true;
            tabConsultas.Controls.Add(dtpConsDesde);
            tabConsultas.Controls.Add(dtpConsHasta);
            tabConsultas.Controls.Add(txtConsCliente);
            tabConsultas.Controls.Add(btnConsBuscar);
            tabConsultas.Controls.Add(dgvConsFacturas);
            tabConsultas.Controls.Add(dgvConsDetalle);
            tabConsultas.Controls.Add(lblInfTitulo);
            tabConsultas.Controls.Add(dtpInfDesde);
            tabConsultas.Controls.Add(dtpInfHasta);
            tabConsultas.Controls.Add(btnInfGenerar);
            tabConsultas.Controls.Add(dgvInforme);
            tabConsultas.Location = new Point(4, 29);
            tabConsultas.Margin = new Padding(3, 4, 3, 4);
            tabConsultas.Name = "tabConsultas";
            tabConsultas.Padding = new Padding(9, 11, 9, 11);
            tabConsultas.Size = new Size(1021, 687);
            tabConsultas.TabIndex = 2;
            tabConsultas.Text = "Consultas";
            // 
            // dtpConsDesde
            // 
            dtpConsDesde.Format = DateTimePickerFormat.Short;
            dtpConsDesde.Location = new Point(11, 13);
            dtpConsDesde.Margin = new Padding(3, 4, 3, 4);
            dtpConsDesde.Name = "dtpConsDesde";
            dtpConsDesde.Size = new Size(148, 27);
            dtpConsDesde.TabIndex = 0;
            // 
            // dtpConsHasta
            // 
            dtpConsHasta.Format = DateTimePickerFormat.Short;
            dtpConsHasta.Location = new Point(171, 13);
            dtpConsHasta.Margin = new Padding(3, 4, 3, 4);
            dtpConsHasta.Name = "dtpConsHasta";
            dtpConsHasta.Size = new Size(148, 27);
            dtpConsHasta.TabIndex = 1;
            // 
            // txtConsCliente
            // 
            txtConsCliente.Location = new Point(331, 13);
            txtConsCliente.Margin = new Padding(3, 4, 3, 4);
            txtConsCliente.Name = "txtConsCliente";
            txtConsCliente.PlaceholderText = "Cliente";
            txtConsCliente.Size = new Size(182, 27);
            txtConsCliente.TabIndex = 2;
            // 
            // btnConsBuscar
            // 
            btnConsBuscar.Location = new Point(523, 13);
            btnConsBuscar.Margin = new Padding(3, 4, 3, 4);
            btnConsBuscar.Name = "btnConsBuscar";
            btnConsBuscar.Size = new Size(80, 31);
            btnConsBuscar.TabIndex = 3;
            btnConsBuscar.Text = "Buscar";
            btnConsBuscar.Click += btnConsBuscar_Click;
            // 
            // dgvConsFacturas
            // 
            dgvConsFacturas.AllowUserToAddRows = false;
            dgvConsFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvConsFacturas.ColumnHeadersHeight = 29;
            dgvConsFacturas.Location = new Point(11, 56);
            dgvConsFacturas.Margin = new Padding(3, 4, 3, 4);
            dgvConsFacturas.Name = "dgvConsFacturas";
            dgvConsFacturas.ReadOnly = true;
            dgvConsFacturas.RowHeadersWidth = 51;
            dgvConsFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsFacturas.Size = new Size(983, 173);
            dgvConsFacturas.TabIndex = 4;
            dgvConsFacturas.SelectionChanged += dgvConsFacturas_SelectionChanged;
            // 
            // dgvConsDetalle
            // 
            dgvConsDetalle.AllowUserToAddRows = false;
            dgvConsDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvConsDetalle.ColumnHeadersHeight = 29;
            dgvConsDetalle.Location = new Point(11, 243);
            dgvConsDetalle.Margin = new Padding(3, 4, 3, 4);
            dgvConsDetalle.Name = "dgvConsDetalle";
            dgvConsDetalle.ReadOnly = true;
            dgvConsDetalle.RowHeadersWidth = 51;
            dgvConsDetalle.Size = new Size(983, 147);
            dgvConsDetalle.TabIndex = 5;
            // 
            // lblInfTitulo
            // 
            lblInfTitulo.Location = new Point(0, 0);
            lblInfTitulo.Name = "lblInfTitulo";
            lblInfTitulo.Size = new Size(114, 31);
            lblInfTitulo.TabIndex = 6;
            // 
            // dtpInfDesde
            // 
            dtpInfDesde.Format = DateTimePickerFormat.Short;
            dtpInfDesde.Location = new Point(11, 433);
            dtpInfDesde.Margin = new Padding(3, 4, 3, 4);
            dtpInfDesde.Name = "dtpInfDesde";
            dtpInfDesde.Size = new Size(148, 27);
            dtpInfDesde.TabIndex = 7;
            // 
            // dtpInfHasta
            // 
            dtpInfHasta.Format = DateTimePickerFormat.Short;
            dtpInfHasta.Location = new Point(171, 433);
            dtpInfHasta.Margin = new Padding(3, 4, 3, 4);
            dtpInfHasta.Name = "dtpInfHasta";
            dtpInfHasta.Size = new Size(148, 27);
            dtpInfHasta.TabIndex = 8;
            // 
            // btnInfGenerar
            // 
            btnInfGenerar.Location = new Point(331, 433);
            btnInfGenerar.Margin = new Padding(3, 4, 3, 4);
            btnInfGenerar.Name = "btnInfGenerar";
            btnInfGenerar.Size = new Size(80, 31);
            btnInfGenerar.TabIndex = 9;
            btnInfGenerar.Text = "Informe";
            btnInfGenerar.Click += btnInfGenerar_Click;
            // 
            // dgvInforme
            // 
            dgvInforme.AllowUserToAddRows = false;
            dgvInforme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInforme.ColumnHeadersHeight = 29;
            dgvInforme.Location = new Point(11, 473);
            dgvInforme.Margin = new Padding(3, 4, 3, 4);
            dgvInforme.Name = "dgvInforme";
            dgvInforme.ReadOnly = true;
            dgvInforme.RowHeadersWidth = 51;
            dgvInforme.Size = new Size(983, 173);
            dgvInforme.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 720);
            Controls.Add(tabMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Facturas";
            Load += Form1_Load;
            tabMain.ResumeLayout(false);
            tabProductos.ResumeLayout(false);
            tabProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudProdPrecio).EndInit();
            tabFacturacion.ResumeLayout(false);
            tabFacturacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudFacCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFacDetalle).EndInit();
            tabConsultas.ResumeLayout(false);
            tabConsultas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConsFacturas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvConsDetalle).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInforme).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblInfTitulo;
    }
}
