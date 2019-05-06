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
    public partial class Frm_Input : Form
    {
        public decimal _CANCELA = 0;
        public Int16 _TARJETA = 0;
        public Frm_Input()
        {
            InitializeComponent();
        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                _CANCELA = Convert.ToDecimal(txtPago.Text);
                this.Close();
            }
            if (EsNumerico(e) == false)
            {
                e.KeyChar = Convert.ToChar(Keys.Escape);
            }
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

        private void chkTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult respuesta;
            if (chkTarjeta.Checked == true)
            {
                respuesta = MessageBox.Show("Esta Seguro(a) de realizar la transacción?", "Punto Venta", MessageBoxButtons.YesNo);
                if (respuesta == System.Windows.Forms.DialogResult.Yes)
                {
                    _TARJETA = 1;
                    this.Close();
                }
                else
                {
                    chkTarjeta.Checked = false;
                }
            }
        }
    }
}
