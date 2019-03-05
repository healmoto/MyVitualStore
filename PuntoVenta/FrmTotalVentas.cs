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
    public partial class FrmTotalVentas : Form
    {
        public FrmTotalVentas()
        {
            InitializeComponent();
        }

        private decimal Llenar(DataGridView gv, List<WS_Info.ConsultaVentaVO> _lista)
        {
            gv.DataSource = _lista;
            decimal total = 0;
            foreach (WS_Info.ConsultaVentaVO co in _lista)
            {
                total = (co.Precio * co.Cantidad) + total;
            }
            return total;
        }

        private void FrmTotalVentas_Load(object sender, EventArgs e)
        {
            DateTime fecha;
            fecha=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            WS_Info.WS_InfoSoapClient ws = new WS_Info.WS_InfoSoapClient();
            List<WS_Info.ConsultaVentaVO> _ventas=new List<WS_Info.ConsultaVentaVO>();
            _ventas = ws.ConsultarVentas(fecha, 1, 0).ToList();
            lblTotalTarjeta.Text=Llenar(gvVentasTarjeta, _ventas).ToString("N0");
            _ventas = new List<WS_Info.ConsultaVentaVO>();
            _ventas = ws.ConsultarVentas(fecha, 0, 0).ToList();
            lblTotal.Text = Llenar(gvVentas, _ventas).ToString("N0");
        }
    }
}
