using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            { 
                RetornarProductos(textBox1.Text);
            }
        }

        void RetornarProductos(String text)
        {
            List<WS_Info.ProductoVO> _productos = new List<WS_Info.ProductoVO>();
            List<WS_Info.ProductoVO> _productosMostrar = new List<WS_Info.ProductoVO>();
            _productos = (List<WS_Info.ProductoVO>)Deserializar(eTipoObjeto.Productos);
            foreach (WS_Info.ProductoVO prod in _productos)
            {
                if (prod.Nombre.Contains(text.ToUpper()))
                {
                    _productosMostrar.Add(prod);
                }
            }
            gvProductos.DataSource = _productosMostrar;
            int columnas = 0;
            columnas = gvProductos.Columns.Count - 1;
            gvProductos.AutoGenerateColumns = false;
            for (int i = 0; i <= columnas; i++)
            {
                if (gvProductos.Columns[i].HeaderText != "NOMBRE" && gvProductos.Columns[i].HeaderText != "PRECIO" && gvProductos.Columns[i].HeaderText != "CODIGO")
                {
                    gvProductos.Columns[i].Visible = false;
                }
            }
            gvProductos.Refresh();
        }

        Object Deserializar(eTipoObjeto eTipo)
        {
            Object objetoDeserializado = null;
            PuntoVenta_Business oBusiness = new PuntoVenta_Business();
            DateTime Hoy = DateTime.Now;
            String filename = String.Empty;
            if (eTipo == eTipoObjeto.Productos)
            {
                filename = Properties.Settings.Default.Files.ToString() + "\\" +
                Properties.Settings.Default.ListaProductos + Hoy.Year.ToString() + Hoy.Month.ToString() + Hoy.Day.ToString() + ".txt";
                objetoDeserializado = oBusiness.Deserializar(filename);
            }
            return objetoDeserializado;
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {

        }
    }
}
