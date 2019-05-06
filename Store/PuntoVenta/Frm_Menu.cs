using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entities;

namespace PuntoVenta
{
    enum eTipoRegistro 
    {
        eCompra,
        eVenta
    }
    public partial class Frm_Menu : Form
    {
        bool salir = false;
        public Frm_Menu()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            Frm_Entradas _entradas = new Frm_Entradas();
            _entradas.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            //FrmProductos _forma = new FrmProductos();
            //_forma.Show();
            Frm_Salidas _salidas = new Frm_Salidas();
            _salidas.Show();
        }

        bool EnviarDatos(WS_Info.VentaVO _venta, WS_Info.UsuarioVO _token)
        {
            bool _valido = false;
            try
            {
                WS_Info.WS_InfoSoapClient ws = new WS_Info.WS_InfoSoapClient();
                ws.VentaNueva(_token, _venta);
                _valido = true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Imposible Transmitir " + ex.Message);
                _valido = false;
            }
            return _valido;
        }

        bool EnviarDatos(WS_Info.Compra _compra, WS_Info.UsuarioVO _token)
        {
            bool _valido = false;
            try
            {
                WS_Info.WS_InfoSoapClient ws = new WS_Info.WS_InfoSoapClient();
                ws.CompraNueva(_token, _compra);
                _valido = true;
            }
            catch
            {
                _valido = false;
            }
            return _valido;
        }

        WS_Info.UsuarioVO getToken()
        {
            WS_Info.UsuarioVO _token = new WS_Info.UsuarioVO();
            _token.Usuario = Properties.Settings.Default.UsuarioConectar;
            _token.Contraseña = Properties.Settings.Default.ContrasenaConectar;
            _token.Equipo = System.Environment.MachineName.ToString();
            return _token;
        }

        private void tm_replica_Tick(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task _tarea;
            _tarea = System.Threading.Tasks.Task.Factory.StartNew(() => EnviarDatos());
            //EnviarDatos();
        }

        private void EnviarDatos()
        {
            EnviarDatos(eTipoRegistro.eVenta);
            EnviarDatos(eTipoRegistro.eCompra);
        }

        void EnviarDatos(eTipoRegistro _tipo)
        {
            String _patron = String.Empty;
            switch (_tipo)
            {
                case eTipoRegistro.eCompra:
                    _patron = "*.cpv";
                    break;
                case eTipoRegistro.eVenta:
                    _patron = "*.vpv";
                    break;
            }
            PuntoVenta_Business oPuntoVenta = new PuntoVenta_Business();
            try
            {
                foreach (String _file in Directory.GetFiles(Properties.Settings.Default.Files.ToString(), _patron))
                {
                    bool _enviar = false;
                    switch (_tipo)
                    {
                        case eTipoRegistro.eCompra:
                            WS_Info.Compra _compra = new WS_Info.Compra();
                            _compra = (WS_Info.Compra)oPuntoVenta.Deserializar(_file);
                            _enviar = EnviarDatos(_compra, getToken());
                            break;
                        case eTipoRegistro.eVenta:
                            WS_Info.VentaVO _venta = new WS_Info.VentaVO();
                            _venta = (WS_Info.VentaVO)oPuntoVenta.Deserializar(_file);
                            _enviar = EnviarDatos(_venta, getToken());
                            break;
                    }
                    if (_enviar == true)
                    {
                        File.Delete(_file);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Imposible enviar datos " + ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox1.Focus();
            //FrmTotalVentas _forma = new FrmTotalVentas();
            //_forma.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FrmProductos _forma = new FrmProductos();
            _forma.Show();
        }

        private void Frm_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salir != true)
            {
                DialogResult cierre;
                cierre = MessageBox.Show("Seguro que quiere cerrar la aplicación", "Punto Venta", MessageBoxButtons.YesNo);
                if (cierre == System.Windows.Forms.DialogResult.Yes)
                {
                    salir = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (textBox1.Text == "Suprimir5383309")
                {
                    textBox1.Text = String.Empty;
                    FrmTotalVentas _forma = new FrmTotalVentas();
                    _forma.Show();
                    textBox1.Visible = false;
                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta", "Punto Venta", MessageBoxButtons.OK);
                }
            }
        }

    }
}
