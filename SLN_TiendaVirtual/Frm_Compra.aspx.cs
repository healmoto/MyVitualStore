using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using DAL.DAL_Consultas;
using DAL.DAL_Ventas;
using Entities;

public partial class Frm_Compra : System.Web.UI.Page
{
    const String KS_BOGOTA = "01";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ObtenerDominio(UtilidadesPeterPan.DOMINIO_CIUDAD, dllCiudad);
            if (Session[UtilidadesPeterPan.VENTAS] == null)
            {
                Response.Redirect("Frm_Catalogo.aspx", true);
            }
            else
            {
                DataBindVentas((List < ProductoVO >)Session[UtilidadesPeterPan.VENTAS]);
            }
        }
    }

    void ObtenerDominio(string codDominio, DropDownList combo)
    {
        DAL.DAL_COMUN.DAL_Dominio consulta = new DAL.DAL_COMUN.DAL_Dominio();
        List<ValorDominioVO> dominios = new List<ValorDominioVO>();
        dominios = consulta.ConsultarDominio(codDominio);
        combo.DataSource = dominios;
        combo.DataTextField = UtilidadesPeterPan.DATATEXT_DOMINIO;
        combo.DataValueField = UtilidadesPeterPan.DATAVALUE_DOMINIO;
        combo.DataBind();
    }

    void DataBindVentas(List<ProductoVO> productos)
    {
        decimal valor = 0;
        gvCompras.DataSource = productos;
        gvCompras.DataBind();
        lblNumeroCompras.Text = "Productos: " + productos.Count.ToString();
        foreach (ProductoVO prod in productos)
        {
            valor = valor + prod.Precio_Venta;
        }
        lblTotal.Text = "Total: " + String.Format("${0:#,#}", valor);
    }
    protected void dllCiudad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dllCiudad.SelectedItem.Value != KS_BOGOTA)
        {
            optContra.Enabled = false;
            optDom.Enabled = false;
            optSin.Enabled = false;
        }
        else
        {
            optContra.Enabled = true;
            optDom.Enabled = true;
            optSin.Enabled = true;
        }
    }
    protected void btnContinuar_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = string.Empty;
        DAL_Venta oVenta = new DAL_Venta();
        VentaVO venta = new VentaVO();
        venta.Barrio = txtBarrio.Text;
        venta.Ciudad = dllCiudad.SelectedItem.Value;
        venta.Comentarios = txtComentarios.Text;
        venta.Direccion = txtDireccion.Text;
        venta.Email = txtEmail.Text;
        venta.NombreCliente = txtNombre.Text;
        venta.Telefono = txtTelefono.Text;
        if (optConsignacion.Checked == true)
        {
            venta.Pago = Convert.ToInt16(UtilidadesPeterPan.eTipoPago.eConsignacion);
        }
        /*if (optPagos.Checked == true)
        {
            venta.Pago = Convert.ToInt16(UtilidadesPeterPan.eTipoPago.ePagos);
        }
        if (optPay.Checked == true)
        {
            venta.Pago = Convert.ToInt16(UtilidadesPeterPan.eTipoPago.ePaypal);
        }*/
        if (optContra.Checked == true)
        {
            venta.Pago = Convert.ToInt16(UtilidadesPeterPan.eTipoPago.eContraentrega);
        }
        if (optSer.Checked == true)
        {
            venta.Envio = Convert.ToInt16(UtilidadesPeterPan.eEnvio.eServientrega);
        }
        if (optDom.Checked == true)
        {
            venta.Envio = Convert.ToInt16(UtilidadesPeterPan.eEnvio.eDomicilio);
        }
        if (optSin.Checked == true)
        {
            venta.Envio = Convert.ToInt16(UtilidadesPeterPan.eEnvio.eSinEnvio);
        }
        venta.Productos = (List<ProductoVO>)Session[UtilidadesPeterPan.VENTAS];
        try
        {
            venta.Numero_venta=oVenta.InsertarVenta(venta);
            Session[UtilidadesPeterPan.SESION_VENTA] = venta;
            Session.Remove(UtilidadesPeterPan.VENTAS);
            EnviarCorreo(venta);
            Response.Redirect("Frm_Confirmacion.aspx", true);
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    ParametroVO ObtenerValorParametro(string strNemonico)
    {
        DAL.DAL_COMUN.DAL_Dominio consulta = new DAL.DAL_COMUN.DAL_Dominio();
        ParametroVO parametro = new ParametroVO();
        parametro = consulta.ConsultarParametro(strNemonico);
        return parametro;
    }

    void EnviarCorreo(VentaVO _venta)
    {
        // Gmail Address from where you send the mail
        var fromAddress = ConfigurationManager.AppSettings["Correo"].ToString();
        string  toAddress;
        if (ConfigurationManager.AppSettings["Copia"].ToString() != String.Empty)
        {
            // any address where the email will be sending
            toAddress = ConfigurationManager.AppSettings["Copia"].ToString() + "," + _venta.Email;
        }
        else
        {
            // any address where the email will be sending
            toAddress = _venta.Email;
        }
        //Password of your gmail address
        string fromPassword = ConfigurationManager.AppSettings["Password"].ToString();
        // Passing the values and make a email formate to display
        string subject = ConfigurationManager.AppSettings["Asunto"].ToString();
        string body = "De: " + ConfigurationManager.AppSettings["Tienda"].ToString() +"\n";
        body += "Subject: " + ConfigurationManager.AppSettings["Asunto"].ToString() + "\n";
        body += "Telefono contacto: " + _venta.Telefono + "\n";
        body += "Dirección contacto: " + _venta.Direccion + "\n";
        body += "Barrio contacto: " + _venta.Barrio + "\n";
        body += "Hola Sr(a): " + _venta.NombreCliente + " Se confirmo la siguiente compra: \n";
        decimal valor = 0;
        decimal valor_envio = 0;
        if (_venta.Envio == Convert.ToInt16(UtilidadesPeterPan.eEnvio.eDomicilio))
        {
            valor_envio = ObtenerValorParametro(UtilidadesPeterPan.PARAMETRO_DOM).Moneda;
        }
        if (_venta.Envio == Convert.ToInt16(UtilidadesPeterPan.eEnvio.eServientrega))
        {
            valor_envio = ObtenerValorParametro(UtilidadesPeterPan.PARAMETRO_SERV).Moneda;
        }
        foreach (ProductoVO prod in _venta.Productos)
        {
            body += "\n" + prod.Descripcion.ToString() + "\n";
            valor = valor + prod.Precio_Venta;
        }
        valor = valor + valor_envio;
        body += "\nTOTAL COMPRA" + String.Format("${0:#,#}", valor) +"\n";
        var smtp = new System.Net.Mail.SmtpClient();
        smtp.Send(fromAddress, toAddress, subject, body);
        /*
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = ConfigurationManager.AppSettings["Host"].ToString();
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Puerto"]);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 200000;
        }
        // Passing values to smtp object
        smtp.Send(fromAddress, toAddress, subject, body);
        */
    }
}