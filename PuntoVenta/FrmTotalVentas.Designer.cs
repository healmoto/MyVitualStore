namespace PuntoVenta
{
    partial class FrmTotalVentas
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
            this.components = new System.ComponentModel.Container();
            this.gvVentasTarjeta = new System.Windows.Forms.DataGridView();
            this.PRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvVentas = new System.Windows.Forms.DataGridView();
            this.PRODUCTOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDADT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTALT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.consultaVentaVOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalTarjeta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvVentasTarjeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.consultaVentaVOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gvVentasTarjeta
            // 
            this.gvVentasTarjeta.AllowUserToAddRows = false;
            this.gvVentasTarjeta.AllowUserToDeleteRows = false;
            this.gvVentasTarjeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvVentasTarjeta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRODUCTO,
            this.CANTIDAD,
            this.PRECIO,
            this.TOTAL});
            this.gvVentasTarjeta.Location = new System.Drawing.Point(26, 53);
            this.gvVentasTarjeta.Name = "gvVentasTarjeta";
            this.gvVentasTarjeta.ReadOnly = true;
            this.gvVentasTarjeta.Size = new System.Drawing.Size(716, 114);
            this.gvVentasTarjeta.TabIndex = 0;
            // 
            // PRODUCTO
            // 
            this.PRODUCTO.DataPropertyName = "PRODUCTO";
            this.PRODUCTO.HeaderText = "PRODUCTO";
            this.PRODUCTO.Name = "PRODUCTO";
            this.PRODUCTO.ReadOnly = true;
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.DataPropertyName = "CANTIDAD";
            this.CANTIDAD.HeaderText = "CANTIDAD";
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.ReadOnly = true;
            // 
            // PRECIO
            // 
            this.PRECIO.DataPropertyName = "PRECIO";
            this.PRECIO.HeaderText = "PRECIO";
            this.PRECIO.Name = "PRECIO";
            this.PRECIO.ReadOnly = true;
            // 
            // TOTAL
            // 
            this.TOTAL.DataPropertyName = "TOTAL";
            this.TOTAL.HeaderText = "TOTAL";
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.ReadOnly = true;
            // 
            // gvVentas
            // 
            this.gvVentas.AllowUserToAddRows = false;
            this.gvVentas.AllowUserToDeleteRows = false;
            this.gvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRODUCTOT,
            this.CANTIDADT,
            this.PRECIOT,
            this.TOTALT});
            this.gvVentas.Location = new System.Drawing.Point(26, 220);
            this.gvVentas.Name = "gvVentas";
            this.gvVentas.ReadOnly = true;
            this.gvVentas.Size = new System.Drawing.Size(716, 184);
            this.gvVentas.TabIndex = 1;
            // 
            // PRODUCTOT
            // 
            this.PRODUCTOT.DataPropertyName = "PRODUCTO";
            this.PRODUCTOT.HeaderText = "PRODUCTO";
            this.PRODUCTOT.Name = "PRODUCTOT";
            this.PRODUCTOT.ReadOnly = true;
            // 
            // CANTIDADT
            // 
            this.CANTIDADT.DataPropertyName = "CANTIDAD";
            this.CANTIDADT.HeaderText = "CANTIDAD";
            this.CANTIDADT.Name = "CANTIDADT";
            this.CANTIDADT.ReadOnly = true;
            // 
            // PRECIOT
            // 
            this.PRECIOT.DataPropertyName = "PRECIO";
            this.PRECIOT.HeaderText = "PRECIO";
            this.PRECIOT.Name = "PRECIOT";
            this.PRECIOT.ReadOnly = true;
            // 
            // TOTALT
            // 
            this.TOTALT.DataPropertyName = "TOTAL";
            this.TOTALT.HeaderText = "TOTAL";
            this.TOTALT.Name = "TOTALT";
            this.TOTALT.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "VENTAS CON TARJETA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "VENTAS DEL DIA";
            // 
            // consultaVentaVOBindingSource
            // 
            this.consultaVentaVOBindingSource.DataSource = typeof(PuntoVenta.WS_Info.ConsultaVentaVO);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(494, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "TOTAL: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(494, 410);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "TOTAL: ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(555, 410);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 6;
            // 
            // lblTotalTarjeta
            // 
            this.lblTotalTarjeta.AutoSize = true;
            this.lblTotalTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTarjeta.Location = new System.Drawing.Point(555, 170);
            this.lblTotalTarjeta.Name = "lblTotalTarjeta";
            this.lblTotalTarjeta.Size = new System.Drawing.Size(0, 13);
            this.lblTotalTarjeta.TabIndex = 7;
            // 
            // FrmTotalVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 432);
            this.Controls.Add(this.lblTotalTarjeta);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvVentas);
            this.Controls.Add(this.gvVentasTarjeta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmTotalVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Total Ventas";
            this.Load += new System.EventHandler(this.FrmTotalVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvVentasTarjeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.consultaVentaVOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvVentasTarjeta;
        private System.Windows.Forms.DataGridView gvVentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource consultaVentaVOBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDADT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTALT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalTarjeta;
    }
}