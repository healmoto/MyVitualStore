namespace PuntoVenta
{
    partial class Frm_Entradas
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
            this.label1 = new System.Windows.Forms.Label();
            this.ddlProducto = new System.Windows.Forms.ComboBox();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.ddlProveedor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gvProductos = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFactura = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto:";
            // 
            // ddlProducto
            // 
            this.ddlProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlProducto.FormattingEnabled = true;
            this.ddlProducto.Location = new System.Drawing.Point(152, 63);
            this.ddlProducto.Name = "ddlProducto";
            this.ddlProducto.Size = new System.Drawing.Size(271, 28);
            this.ddlProducto.TabIndex = 3;
            this.ddlProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ddlProducto_KeyPress);
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoBarras.Location = new System.Drawing.Point(152, 129);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(271, 26);
            this.txtCodigoBarras.TabIndex = 7;
            this.txtCodigoBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarras_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Codigo:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(39, 471);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(158, 51);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(578, 65);
            this.txtCantidad.MaxLength = 3;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(110, 26);
            this.txtCantidad.TabIndex = 4;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(429, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cantidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "Costo:";
            // 
            // txtCosto
            // 
            this.txtCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Location = new System.Drawing.Point(152, 96);
            this.txtCosto.MaxLength = 12;
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(110, 26);
            this.txtCosto.TabIndex = 5;
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCosto_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(429, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "Precio Venta:";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioVenta.Location = new System.Drawing.Point(578, 97);
            this.txtPrecioVenta.MaxLength = 12;
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(110, 26);
            this.txtPrecioVenta.TabIndex = 6;
            this.txtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioVenta_KeyPress);
            // 
            // ddlProveedor
            // 
            this.ddlProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlProveedor.FormattingEnabled = true;
            this.ddlProveedor.Location = new System.Drawing.Point(152, 29);
            this.ddlProveedor.Name = "ddlProveedor";
            this.ddlProveedor.Size = new System.Drawing.Size(271, 28);
            this.ddlProveedor.TabIndex = 1;
            this.ddlProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ddlProveedor_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 26);
            this.label6.TabIndex = 12;
            this.label6.Text = "Proveedor:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(530, 129);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(158, 30);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gvProductos
            // 
            this.gvProductos.AllowUserToAddRows = false;
            this.gvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.gvProductos.Location = new System.Drawing.Point(44, 201);
            this.gvProductos.Name = "gvProductos";
            this.gvProductos.ReadOnly = true;
            this.gvProductos.Size = new System.Drawing.Size(644, 255);
            this.gvProductos.TabIndex = 9;
            this.gvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvProductos_CellClick);
            this.gvProductos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvProductos_CellMouseClick);
            // 
            // Eliminar
            // 
            this.Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Eliminar.HeaderText = "";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.ToolTipText = "Eliminar";
            this.Eliminar.UseColumnTextForButtonValue = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(429, 471);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 26);
            this.label7.TabIndex = 14;
            this.label7.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(570, 471);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 26);
            this.lblTotal.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(429, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 26);
            this.label8.TabIndex = 17;
            this.label8.Text = "Factura:";
            // 
            // txtFactura
            // 
            this.txtFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFactura.Location = new System.Drawing.Point(578, 33);
            this.txtFactura.MaxLength = 10;
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(110, 26);
            this.txtFactura.TabIndex = 2;
            // 
            // Frm_Entradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 544);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFactura);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gvProductos);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.ddlProveedor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigoBarras);
            this.Controls.Add(this.ddlProducto);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Frm_Entradas";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COMPRAS";
            this.Load += new System.EventHandler(this.Frm_Entradas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlProducto;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.ComboBox ddlProveedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView gvProductos;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFactura;
    }
}