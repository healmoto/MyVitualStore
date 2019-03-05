using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entities;

namespace PuntoVenta
{
    public partial class Frm_Entradas : Form
    {
        List<WS_Info.ProductoVO> _listado = new List<WS_Info.ProductoVO>();
        decimal _totalFactura = 0;

        public Frm_Entradas()
        {
            InitializeComponent();
        }

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtCodigoBarras.Text.Length>0)
            {
                AgregarProducto();
            }
        }

        void AgregarProducto()
        {
            WS_Info.ProductoVO _producto;
            if (ValidarFormulario() == false)
            {
                MessageBox.Show (Properties.Settings.Default.MensajeCompras.ToString());
                return;
            }
            _producto = new WS_Info.ProductoVO();
            //_producto.Consecutivo = (int)ddlProducto.SelectedValue;
            _producto.CodigoBarras = txtCodigoBarras.Text;
            _producto.Nombre = ddlProducto.Text;
            _producto.Costo = Convert.ToDecimal(txtCosto.Text);
            _producto.Precio_Venta = Convert.ToDecimal(txtPrecioVenta.Text);
            _producto.Cantidad = Convert.ToInt32(txtCantidad.Text);
            _producto.Referencia = gvProductos.Rows.Count.ToString();
            _producto.TotalUnitario = _producto.Cantidad * _producto.Costo;
            _totalFactura = _totalFactura + _producto.TotalUnitario;
            _producto.ReferenciaAnterior = ddlProducto.SelectedValue.ToString();
            AgregarBarra(_producto);
            
        }

        void borrarInfo()
        {
            Limpiar(txtCantidad);
            Limpiar(txtCosto);
            Limpiar(txtPrecioVenta);
            Limpiar(txtCodigoBarras);
            Limpiar(ddlProducto);
        }

        void Limpiar(TextBox txt)
        {
            txt.Text = String.Empty;
        }

        void Limpiar(ComboBox cmb)
        {
            cmb.Text = String.Empty;
        }

        bool ValidarFormulario()
        {
            if (ValidarValor(ddlProveedor) == false)
            {
                return false;
            }
            if (ValidarValor(ddlProducto) == false)
            {
                return false;
            }
            if (ValidarValor(txtCantidad) == false)
            {
                return false;
            }
            if (ValidarValor(txtCosto) == false)
            {
                return false;
            }
            if (ValidarValor(txtPrecioVenta) == false)
            {
                return false;
            }
            if (ValidarValor(txtCodigoBarras) == false)
            {
                return false;
            }
            return true;
        }

        bool ValidarValor(TextBox texto)
        {
            if (texto.Text.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool ValidarValor(ComboBox texto)
        {
            if (texto.Text.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void DataBind()
        {
            if (_totalFactura > 0)
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
            gvProductos.DataSource = null;
            gvProductos.DataSource = _listado;
        }

        void AgregarBarra(WS_Info.ProductoVO _producto)
        {
            _listado.Add(_producto);
            lblTotal.Text = _totalFactura.ToString();
            borrarInfo();
            DataBind();
            for (int i = 0; i<gvProductos.Columns.Count; i++)
            {
                if (gvProductos.Rows[_listado.Count-1].Cells[i].Value == null)
                {
                    gvProductos.Columns[i].Visible = false;
                }
            }
            gvProductos.Refresh();
        }

        private void Frm_Entradas_Load(object sender, EventArgs e)
        {
            ddlProducto.DataSource = Deserializar(eTipoObjeto.Productos);
            ddlProducto.DisplayMember = Properties.Settings.Default.ComboTexto;
            ddlProducto.ValueMember = "Referencia";

            ddlProveedor.DataSource = Deserializar(eTipoObjeto.Proveedores);
            ddlProveedor.DisplayMember = Properties.Settings.Default.ComboTexto;
            ddlProveedor.ValueMember = Properties.Settings.Default.ComboValor;
        }

        Object Deserializar(eTipoObjeto eTipo)
        {
            Object objetoDeserializado=null;
            PuntoVenta_Business oBusiness = new PuntoVenta_Business();
            DateTime Hoy = DateTime.Now;
            String filename = String.Empty;
            if (eTipo==eTipoObjeto.Productos)
            {
                filename = Properties.Settings.Default.Files.ToString() + "\\" +
                Properties.Settings.Default.ListaProductos + Hoy.Year.ToString() + Hoy.Month.ToString() + Hoy.Day.ToString() + ".txt";
                objetoDeserializado = oBusiness.Deserializar(filename);
            }
            if (eTipo == eTipoObjeto.Proveedores)
            {
                filename = Properties.Settings.Default.Files.ToString() + "\\" +
                Properties.Settings.Default.ListaProveedores + Hoy.Year.ToString() + Hoy.Month.ToString() + Hoy.Day.ToString() + ".txt";
                objetoDeserializado = oBusiness.Deserializar(filename);
            }
            return objetoDeserializado;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        private bool EsNumerico(KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 8))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EsNumerico(e) == false)
            {
                e.KeyChar = Convert.ToChar(Keys.Escape);
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EsNumerico(e) == false)
            {
                e.KeyChar = Convert.ToChar(Keys.Escape);
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EsNumerico(e) == false)
            {
                e.KeyChar = Convert.ToChar(Keys.Escape);
            }
        }

        private void gvProductos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void gvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult respuesta;
            List<WS_Info.ProductoVO> _productos = new List<WS_Info.ProductoVO>();
            WS_Info.ProductoVO _productoEliminar = new WS_Info.ProductoVO();
            if (e.ColumnIndex == 0)
            {
                respuesta = MessageBox.Show(Properties.Settings.Default.MensajeEliminacion, Properties.Settings.Default.Aplicativo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (respuesta == DialogResult.Yes)
                {
                    _productos = (List<WS_Info.ProductoVO>)gvProductos.DataSource;
                    _productoEliminar = _productos.Find(
                        delegate(WS_Info.ProductoVO pp)
                        {
                            return pp.Referencia == e.RowIndex.ToString();
                        });
                    _totalFactura = _totalFactura - _productoEliminar.TotalUnitario;
                    lblTotal.Text = _totalFactura.ToString();
                    _listado.Remove(_productoEliminar);
                    DataBind();
                }
            }
        }

        private void ddlProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(Keys.Escape);
        }

        private void ddlProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(Keys.Escape);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta;
            bool _exitoso = false;
            respuesta = MessageBox.Show("Desea confirmar compra por: " + _totalFactura.ToString(), "Punto Venta", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
            {
                PuntoVenta_Business oPuntoVenta = new PuntoVenta_Business();
                WS_Info.Compra _compra = new WS_Info.Compra();
                string filename = String.Empty;
                try
                {
                    _compra.Proveedor = ddlProveedor.SelectedValue.ToString();
                    _compra.factura = txtFactura.Text;
                    _compra.Fecha = DateTime.Now;
                    _compra.Productos = _listado.ToArray();
                    filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString()
                        + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString()+".cpv";
                    oPuntoVenta.Serializar(filename, _compra);
                    _exitoso = true;
                }
                catch (Exception ex) {
                    _exitoso = false;
                    MessageBox.Show("Hubo un error en el proceso: " + ex.Message);
                }
                if (_exitoso == true)
                {
                    lblTotal.Text = String.Empty;
                    _totalFactura = 0;
                    _listado = new List<WS_Info.ProductoVO>();
                    DataBind();
                    btnGuardar.Enabled = false;
                    txtFactura.Text = String.Empty;
                    MessageBox.Show("Registro Exitoso");
                }
            }
        }
    }
}
