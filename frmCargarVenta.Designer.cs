namespace ANINO_HNOS
{
    partial class frmCargarVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.cmbUnidad = new System.Windows.Forms.ComboBox();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.grpDetalleVenta = new System.Windows.Forms.GroupBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblT = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.Cancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.grpDetalleVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(12, 9);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Location = new System.Drawing.Point(12, 32);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(100, 13);
            this.lblUnidad.TabIndex = 1;
            this.lblUnidad.Text = "Unidad de negocio:";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(12, 75);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(96, 13);
            this.lblProducto.TabIndex = 2;
            this.lblProducto.Text = "Producto/Servicio:";
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(118, 6);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(200, 21);
            this.cmbCliente.TabIndex = 1;
            // 
            // cmbUnidad
            // 
            this.cmbUnidad.FormattingEnabled = true;
            this.cmbUnidad.Location = new System.Drawing.Point(118, 29);
            this.cmbUnidad.Name = "cmbUnidad";
            this.cmbUnidad.Size = new System.Drawing.Size(200, 21);
            this.cmbUnidad.TabIndex = 2;
            // 
            // cmbProducto
            // 
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(118, 72);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(200, 21);
            this.cmbProducto.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(388, 99);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(328, 102);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 7;
            this.lblFecha.Text = "Fecha:";
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Location = new System.Drawing.Point(12, 102);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(52, 13);
            this.LblCantidad.TabIndex = 8;
            this.LblCantidad.Text = "Cantidad:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(176, 102);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 9;
            this.lblPrecio.Text = "Precio:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(70, 99);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 4;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(222, 99);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 5;
            // 
            // grpDetalleVenta
            // 
            this.grpDetalleVenta.Controls.Add(this.btnEliminar);
            this.grpDetalleVenta.Controls.Add(this.lblTotal);
            this.grpDetalleVenta.Controls.Add(this.lblT);
            this.grpDetalleVenta.Controls.Add(this.dgvDetalle);
            this.grpDetalleVenta.Location = new System.Drawing.Point(12, 184);
            this.grpDetalleVenta.Name = "grpDetalleVenta";
            this.grpDetalleVenta.Size = new System.Drawing.Size(634, 328);
            this.grpDetalleVenta.TabIndex = 10;
            this.grpDetalleVenta.TabStop = false;
            this.grpDetalleVenta.Text = "Detalle de la Venta";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvDetalle.Location = new System.Drawing.Point(6, 19);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(622, 231);
            this.dgvDetalle.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cliente";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Unidad de Negocio";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Producto";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Cantidad";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Precio";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Subtotal";
            this.Column6.Name = "Column6";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(18, 136);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(151, 31);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Location = new System.Drawing.Point(437, 268);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(34, 13);
            this.lblT.TabIndex = 1;
            this.lblT.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTotal.Location = new System.Drawing.Point(477, 263);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(151, 22);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(484, 533);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 12;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(565, 533);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(553, 299);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // frmCargarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 568);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.grpDetalleVenta);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.LblCantidad);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.cmbUnidad);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.lblCliente);
            this.Name = "frmCargarVenta";
            this.Text = "Cargar Venta";
            this.Load += new System.EventHandler(this.frmCargarVenta_Load);
            this.grpDetalleVenta.ResumeLayout(false);
            this.grpDetalleVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbUnidad;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label LblCantidad;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.GroupBox grpDetalleVenta;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
    }
}