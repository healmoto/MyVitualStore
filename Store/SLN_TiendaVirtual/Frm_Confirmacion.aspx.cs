using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using DAL.DAL_Consultas;
using DAL.DAL_Ventas;
using Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Net;
using System.Text;

public partial class Frm_Confirmacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session[UtilidadesPeterPan.SESION_VENTA] == null)
            {
                Response.Redirect("Frm_Catalogo.aspx", true);
            }
            else
            {
                VentaVO venta = new VentaVO();
                venta = (VentaVO) Session[UtilidadesPeterPan.SESION_VENTA];
                DataBindVentas(venta.Productos);
                LLenarCamposVenta(venta);
            }
        }
    }

    void LLenarCamposVenta(VentaVO venta)
    {
        lblMensajeFinal.Text = "Tu compra ha sido aprobada ...";
        Random r = new Random(DateTime.Now.Millisecond);
        int numero = r.Next();
        lblNumeroAprobacion.Text = numero.ToString() + "-" + venta.Numero_venta.ToString();
        txtBarrio.Text = venta.Barrio;
        txtDireccion.Text = venta.Direccion;
        txtEmail.Text = venta.Email;
        txtNombre.Text = venta.NombreCliente;
        txtTelefono.Text = venta.Telefono;
        dllCiudad.Text = ObtenerValorDominio(venta.Ciudad, UtilidadesPeterPan.DOMINIO_CIUDAD).Descripcion;
        decimal valor = Convert.ToDecimal(Session[UtilidadesPeterPan.VALOR_VENTA]);
        decimal valor_envio=0;
        if (venta.Envio == Convert.ToInt16(UtilidadesPeterPan.eEnvio.eDomicilio))
        {
            valor_envio = ObtenerValorParametro(UtilidadesPeterPan.PARAMETRO_DOM).Moneda;
            lblEnvio.Text = "Domicilio: " + String.Format("${0:#,#}", valor_envio);
        }
        if (venta.Envio == Convert.ToInt16(UtilidadesPeterPan.eEnvio.eServientrega))
        {
            valor_envio = ObtenerValorParametro(UtilidadesPeterPan.PARAMETRO_SERV).Moneda;
            lblEnvio.Text = "Servientrega: " + String.Format("${0:#,#}", valor_envio);
        }
        if (venta.Envio == Convert.ToInt16(UtilidadesPeterPan.eEnvio.eSinEnvio))
        {
            lblEnvio.Text = "Sin Envio";
        }
        //PAGO
        if (venta.Pago== Convert.ToInt16(UtilidadesPeterPan.eTipoPago.eConsignacion))
        {
            lblPago.Text = "Consignación: Consignar a la cuenta corriente: 4821 6000 3687 a nombre de Hector Morales";
        }
        if (venta.Pago == Convert.ToInt16(UtilidadesPeterPan.eTipoPago.eContraentrega))
        {
            lblPago.Text = "Contraentrega";
        }
        if (venta.Pago == Convert.ToInt16(UtilidadesPeterPan.eTipoPago.ePagos))
        {
            lblPago.Text = "Pagos Online";
        }
        if (venta.Pago == Convert.ToInt16(UtilidadesPeterPan.eTipoPago.ePaypal))
        {
            lblPago.Text = "Paypal";
        }
        valor = valor + valor_envio;
        lblTotal.Text = "Total: " + String.Format("${0:#,#}", valor);
        Session.Remove(UtilidadesPeterPan.VALOR_VENTA);
    }

    ParametroVO ObtenerValorParametro(string strNemonico)
    {
        DAL.DAL_COMUN.DAL_Dominio consulta = new DAL.DAL_COMUN.DAL_Dominio();
        ParametroVO  parametro = new ParametroVO ();
        parametro = consulta.ConsultarParametro(strNemonico);
        return parametro;
    }

    ValorDominioVO ObtenerValorDominio(string codDominio, string codPadre)
    {
        DAL.DAL_COMUN.DAL_Dominio consulta = new DAL.DAL_COMUN.DAL_Dominio();
        ValorDominioVO dominio = new ValorDominioVO();
        dominio = consulta.ConsultarDominio(codDominio,codPadre);
        return dominio;
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
        foreach (ProductoVO prod in productos)
        {
            valor = valor + prod.Precio_Venta;
        }
        Session[UtilidadesPeterPan.VALOR_VENTA] = valor;
        lblTotal.Text = "Total: " + String.Format("${0:#,#}", valor);
    }

    protected void btnContinuar_Click(object sender, EventArgs e)
    {
        string attachment = "attachment; filename=" + txtNombre.Text + ".pdf";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/pdf";
        StringWriter stw = new StringWriter();
        stw.Write(HTMLPaginaCompleta());
        HtmlTextWriter htextw = new HtmlTextWriter(stw);
        //Tamaño de la pagina
        //Rectangle pageSize = new Rectangle(144, 720);
        Document document = new Document(PageSize.A4, 50, 25, 15, 10);
        PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream );
        document.Open();
        StringReader str = new StringReader(stw.ToString());
        HTMLWorker htmlworker = new HTMLWorker(document);
        htmlworker.Parse(str);
        document.Close();
        Response.Write(document);
        Response.End();
    }

    public string HTMLPaginaCompleta()
    {
        string sHTML = HTMLPagina();
        sHTML = sHTML.Replace("App_Themes/Principal/Aviso.png", Server.MapPath("~/App_Themes/Principal/Aviso.png"));
        sHTML = sHTML.Replace("{tabla}", HTMLGRid());
        sHTML = sHTML.Replace("{lblMensajeFinal}", lblMensajeFinal.Text);
        sHTML = sHTML.Replace("{lblNumeroAprobacion}", lblNumeroAprobacion.Text);
        sHTML = sHTML.Replace("{txtNombre}", txtNombre.Text);
        sHTML = sHTML.Replace("{txtEmail}", txtEmail.Text);
        sHTML = sHTML.Replace("{txtTelefono}", txtTelefono.Text);
        sHTML = sHTML.Replace("{txtDireccion}", txtDireccion.Text);
        sHTML = sHTML.Replace("{dllCiudad}", dllCiudad.Text);
        sHTML = sHTML.Replace("{txtBarrio}", txtBarrio.Text);
        sHTML = sHTML.Replace("{lblEnvio}", lblEnvio.Text);
        sHTML = sHTML.Replace("{lblPago}", lblPago.Text);
        sHTML = sHTML.Replace("{lblTotal}", lblTotal.Text);
        return sHTML;
    }

    public string HTMLPagina()
    {
        WebClient MyWebClient = new WebClient();
        Byte[] ArregloBytes = null;
        //ArregloBytes = MyWebClient.DownloadData(Server.MapPath("~/HTMLPage.htm"));
        ArregloBytes = MyWebClient.DownloadData(Server.MapPath("~/Recibo.htm"));
        return Encoding.Default.GetString(ArregloBytes);
    }

    public string HTMLGRid()
    {
        StringWriter stw = new StringWriter();
        HtmlTextWriter htextw = new HtmlTextWriter(stw);
        divPrint.RenderControl(htextw);
        return stw.ToString();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
}