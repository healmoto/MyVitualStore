using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class Frm_Sincro : Form
    {
        public Frm_Sincro()
        {
            InitializeComponent();
        }

        private void Frm_Sincro_Load(object sender, EventArgs e)
        {
            
            Animacion.Image = Properties.Resources.Animation;
            lblTexto.Text = "Sincronizando ...";
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int porcentaje = 0;
            Random rand = new Random();
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            WS_Info.UsuarioVO _token = new WS_Info.UsuarioVO();
            _token.Usuario = Properties.Settings.Default.UsuarioConectar;
            _token.Contraseña = Properties.Settings.Default.ContrasenaConectar;
            _token.Equipo = System.Environment.MachineName.ToString();
            Sincronizar(_token);
            porcentaje = 100;
            // report progress
            worker.ReportProgress(porcentaje, porcentaje );
            // simulate operation step
            System.Threading.Thread.Sleep(rand.Next(100, 1000));
        }

        void Sincronizar(WS_Info.UsuarioVO  _token)
        {
            DateTime Hoy= DateTime.Now;
            PuntoVenta_Business oPuntoVenta = new PuntoVenta_Business();
            List<WS_Info.ProductoVO> _listaProducto = new List<WS_Info.ProductoVO>();
            List<WS_Info.ProveedorVO> _listaProveedores = new List<WS_Info.ProveedorVO>();
            bool _sincronizacion = false;

            String filename = Properties.Settings.Default.Files.ToString() + "\\" +
                Properties.Settings.Default.ListaProductos + Hoy.Year.ToString() + Hoy.Month.ToString() + Hoy.Day.ToString() + ".txt";

            String filenameProveedores = Properties.Settings.Default.Files.ToString() + "\\" +
                Properties.Settings.Default.ListaProveedores + Hoy.Year.ToString() + Hoy.Month.ToString() + Hoy.Day.ToString() + ".txt";

            try
            {
                WS_Info.WS_InfoSoapClient ws = new WS_Info.WS_InfoSoapClient();
                _listaProducto = ws.ConsultarProductos(_token).ToList<WS_Info.ProductoVO>();
                _listaProveedores = ws.ConsultarProveedores(_token).ToList<WS_Info.ProveedorVO>();
                _sincronizacion = true;
            }
            catch(Exception ex)
            {
                _sincronizacion = false;
                MessageBox.Show("No se pudo sincronizar, intente mas tarde " + ex.Message);
            }

            if (!File.Exists(filename) && _sincronizacion==true)
            {
                foreach (string _archivo in Directory.GetFiles(Properties.Settings.Default.Files.ToString()))
                {
                    int longitud = _archivo.Length;
                    if (_archivo.Substring(longitud - 3, 3) == "txt")
                    {
                        File.Delete(_archivo);
                    }
                }
                oPuntoVenta.Serializar(filename, _listaProducto);
                oPuntoVenta.Serializar(filenameProveedores, _listaProveedores);
            }

        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            Frm_Menu menu = new Frm_Menu();
            menu.Show();
            this.Hide();
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = (int)e.UserState;
        }

        private void Frm_Sincro_FormClosing(object sender, FormClosingEventArgs e)
        {   
        }

    }
}
