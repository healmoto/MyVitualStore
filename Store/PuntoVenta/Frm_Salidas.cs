using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entities;

namespace PuntoVenta
{
    public partial class Frm_Salidas : Form
    {

        List<WS_Info.ProductoVO> _listaProductos = new List<WS_Info.ProductoVO>();
        WS_Info.ProductoVO _producto = null;
        List<WS_Info.ProductoVO> _productos = new List<WS_Info.ProductoVO>();
        decimal _totalVenta = 0;
        const int COLUMNA_REFERENCIA = 2;
        int consecutivo = 1200;
        
        public Frm_Salidas()
        {
            InitializeComponent();
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

        private void Frm_Salidas_Load(object sender, EventArgs e)
        {
            DateTime Hoy = DateTime.Now;
            PuntoVenta_Business oPuntoVenta = new PuntoVenta_Business();
            string filename = Properties.Settings.Default.Files.ToString() + "\\" +
                Properties.Settings.Default.ListaProductos + Hoy.Year.ToString() + Hoy.Month.ToString() + Hoy.Day.ToString() + ".txt";
            lblFecha.Text = DateTime.Now.ToShortDateString();
            txtCodigoBarras.Focus();
            _productos = (List<WS_Info.ProductoVO>) oPuntoVenta.Deserializar(filename);
        }

        private WS_Info.ProductoVO BuscarProducto(string referencia)
        {
            //BUSCAR EN COLUMNA REFRENCIA
            WS_Info.ProductoVO _productoEncontrar = new WS_Info.ProductoVO();
            _productoEncontrar = _productos.Find(
                        delegate(WS_Info.ProductoVO pp)
                        {
                            return pp.Referencia == referencia;
                        });
            _producto = null;
            if (_productoEncontrar == null)
            {
                MessageBox.Show("Producto no encontrado");
            }
            else
            {
                _producto = new WS_Info.ProductoVO();
                _producto.CodigoBarras = referencia;
                _producto.Nombre = _productoEncontrar.Nombre;
                _producto.Precio_Venta = _productoEncontrar.Precio_Venta;
            }
            return _producto;
        }

        void DataBin()
        {
            gvProductos.DataSource = null;
            gvProductos.DataSource = _listaProductos;
            lblTotal.Text = _totalVenta.ToString("C");
            gvProductos.Refresh();
        }

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtCodigoBarras.Text.Length > 0)
            {
                _producto = BuscarProducto(txtCodigoBarras.Text.Trim());
                if (_producto != null)
                {
                    txtPrecioVenta.Text = _producto.Precio_Venta.ToString("C");
                    txtCantidad.SelectionStart = 0;
                    txtCantidad.SelectionLength = txtCantidad.ToString().Length;
                    txtCantidad.Focus();
                }
                else
                {
                    LimpiarDatos(txtCodigoBarras);
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtCantidad.Text.Length > 0)
            {
                txtPrecioVenta.SelectionStart = 0;
                txtPrecioVenta.SelectionLength = txtPrecioVenta.ToString().Length;
                txtPrecioVenta.Focus();
            }
            if (EsNumerico(e) == false)
            {
                e.KeyChar = Convert.ToChar(Keys.Escape);
            }
        }

        void AgregarProducto()
        {
            _producto.Consecutivo = gvProductos.Rows.Count;
            _producto.Precio_Venta = Convert.ToDecimal(txtPrecioVenta.Text.Replace("$",""));
            _producto.Cantidad = Convert.ToInt32(txtCantidad.Text);
            _listaProductos.Add(_producto);
            _producto.TotalUnitario = _producto.Cantidad * _producto.Precio_Venta;
            _totalVenta = _totalVenta + _producto.TotalUnitario;
            DataBin();
            LimpiarDatos();
            lblCambio.Text = String.Empty;
            txtCantidad.Text = "1";
            txtCodigoBarras.Focus();
            lblNombre.Text = _producto.Nombre;
            for (int i = 0; i < gvProductos.Columns.Count; i++)
            {
                if (gvProductos.Rows[_listaProductos.Count - 1].Cells[i].Value == null || gvProductos.Rows[_listaProductos.Count - 1].Cells[i].Value.ToString() == "0")
                {
                    gvProductos.Columns[i].Visible = false;
                }
            }
        }

        void LimpiarDatos()
        {
            LimpiarDatos(txtPrecioVenta);
            LimpiarDatos(txtCantidad);
            LimpiarDatos(txtCodigoBarras);
        }

        void LimpiarDatos(TextBox texto)
        {
            texto.Text = String.Empty;
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtPrecioVenta.Text.Length > 0)
            {
                AgregarProducto();
            }
            if (EsNumerico(e) == false)
            {
                e.KeyChar = Convert.ToChar(Keys.Escape);
            }
        }

        private void gvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult respuesta;
            WS_Info.ProductoVO _productoEliminar = new WS_Info.ProductoVO();
            if (e.ColumnIndex == 0)
            {
                respuesta = MessageBox.Show(Properties.Settings.Default.MensajeEliminacion, Properties.Settings.Default.Aplicativo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (respuesta == DialogResult.Yes)
                {
                    _listaProductos = (List<WS_Info.ProductoVO>)gvProductos.DataSource;
                    _productoEliminar = _listaProductos.Find(
                        delegate(WS_Info.ProductoVO pp)
                        {
                            return pp.Consecutivo.ToString() == e.RowIndex.ToString();
                        });
                    _totalVenta = _totalVenta - _productoEliminar.TotalUnitario;
                    _listaProductos.Remove(_productoEliminar);
                    DataBin();
                }
            }
        }

        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8) 
            {
                CerrarVenta();
            }
        }

        private void Frm_Salidas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                CerrarVenta();
            }
        }

        void CerrarVenta()
        {
            WS_Info.VentaVO _venta = new WS_Info.VentaVO();
            PuntoVenta_Business oPuntoVenta = new PuntoVenta_Business();
            if (_totalVenta > 0)
            {
                decimal _cambio;
                Frm_Input input = new Frm_Input();
                input.ShowDialog();
                if (input._CANCELA == 0)
                {
                    _cambio = 0;
                }
                else
                {
                    _cambio = input._CANCELA - _totalVenta;
                }
                _venta.Fecha = Convert.ToDateTime(lblFecha.Text);
                _venta.Tarjeta = input._TARJETA;
                _venta.Productos = _listaProductos.ToArray();
                _venta.PuntoVenta = 1;
                _venta.NombreCliente = Properties.Settings.Default.Aplicativo;
                String nombreArchivo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString()
                        + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                String filename = Properties.Settings.Default.Files.ToString() + "\\" + nombreArchivo + ".vpv";
                _venta.Archivo = nombreArchivo;
                ImprimirTiquete(_venta, input._CANCELA, _cambio, _totalVenta);
                oPuntoVenta.Serializar(filename, _venta);
                lblCambio.Text = _cambio.ToString("C");
                InicioNuevaVenta();
            }
        }

        void InicioNuevaVenta()
        {
            _listaProductos.RemoveAll(delegate(WS_Info.ProductoVO pp)
            {
                return pp.Consecutivo >= 0;
            });
            _producto = null;
            lblNombre.Text = String.Empty;
            DataBin();
            _totalVenta = 0;
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                CerrarVenta();
            }
        }

        private void txtPrecioVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                CerrarVenta();
            }
        }

        private void gvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                CerrarVenta();
            }
        }

        void ImprimirTiquete(WS_Info.VentaVO _venta, decimal _efectivo, decimal _cambio, decimal _total)
        {
            consecutivo = consecutivo + 1;
            Ticket tc = new Ticket();
            tc.AddHeaderLine("PAÑALERA PETER PAN - Villa Luz");
            tc.AddHeaderLine("Tel : 5470694");
            tc.AddHeaderLine("Dir: CARRERA 77A 64B 22 PRIMER PISO");
            tc.AddHeaderLine("NIT: 80773117-0");
            tc.AddHeaderLine("Resolucion DIAN #320001382769");
            tc.AddHeaderLine("Del 2016/03/31 desde la #-1");
            tc.AddHeaderLine("hasta la A # 2000");
            tc.AddHeaderLine("Regimen Comun");
            tc.AddHeaderLine("Bogota, Colombia");
            tc.AddHeaderLine("Factura de Venta - " + consecutivo.ToString());
            tc.AddSubHeaderLine("Fecha: " + DateTime.Now.ToString());
            tc.AddSubHeaderLine("Venta: " + _venta.Archivo.ToString());
            foreach (WS_Info.ProductoVO prod in _venta.Productos)
            {
                tc.AddItem(prod.Cantidad.ToString(), prod.Nombre.ToString(), prod.TotalUnitario.ToString("C"));
            }
            decimal iva = Convert.ToDecimal(1.19);
            decimal subtotalFactura = Math.Round(_total / iva);
            decimal totalIva = _total - subtotalFactura;
            tc.AddTotal("SUBTOTAL: ", subtotalFactura.ToString("C"));
            tc.AddTotal("IVA: ", totalIva.ToString("C"));
            tc.AddTotal("TOTAL VENTA: ", _total.ToString("C"));
            tc.AddFooterLine("EFECTIVO: " + _efectivo.ToString("C"));
            tc.AddFooterLine("CAMBIO: " + _cambio.ToString("C"));
            tc.AddFooterLine("VISITENOS EN: www.bebespeterpan.com");
            tc.PrintTicket(Properties.Settings.Default.Impresora.ToString());
        }
    }
}
