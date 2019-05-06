using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using DAL.DAL_Consultas;
using Entities;

public partial class Frm_Catalogo : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Request.QueryString[UtilidadesPeterPan.CATALOGO] != null)
            //{
            //    Session[UtilidadesPeterPan.TIPO_PROD] = Request.QueryString[UtilidadesPeterPan.CATALOGO].ToString();
            //}
            //else
            //{
            //    Session[UtilidadesPeterPan.TIPO_PROD] = UtilidadesPeterPan.TIPO_DEFAULT;
            //}
            try
            {
                ObtenerDominio(UtilidadesPeterPan.DOMINIO_ORDEN, dllOrdenar);
                dllOrdenar.SelectedValue = UtilidadesPeterPan.DOMINIO_ORDEN_DEFAULT;
                ObtenerCatalogo(Session[UtilidadesPeterPan.TIPO_PROD].ToString(), dllOrdenar.SelectedItem.Value);
                ObtenerPromociones();
                lblBusqueda.Text = String.Empty;
                if (Session[UtilidadesPeterPan.BUSQUEDA] != null)
                {
                    Session.Remove(UtilidadesPeterPan.BUSQUEDA);
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/About.aspx");
            }
        }
    }

    void ObtenerCatalogo(string strTipo, string codOrden)
    {
        DAL_Consultascs consultas = new DAL_Consultascs();
        List<ProductoVO> productos = new List<ProductoVO>();
        productos = consultas.ConsultarCatalogo(strTipo, codOrden);
        gvCatalogo.DataSource = productos;
        gvCatalogo.DataBind();
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

    void ObtenerPromociones()
    {
        List<ProductoVO> productos = new List<ProductoVO>();
        DAL_Consultascs consultas = new DAL_Consultascs();
        ProductoVO producto=new ProductoVO();
        productos = consultas.ConsultarPromociones();
        producto=productos.First<ProductoVO>();
        AsignarPromocion(producto);
        Session[UtilidadesPeterPan.PRODUCTOS] = productos;
    }

    void ObtenerBusqueda(string _busqueda, string  strOrden)
    {
        DAL_Consultascs consultas = new DAL_Consultascs();
        List<ProductoVO> productos = new List<ProductoVO>();
        productos = consultas.ConsultarXCriterio(strOrden, _busqueda);
        gvCatalogo.DataSource = productos;
        gvCatalogo.DataBind();
    }

    protected void dllOrdenar_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session[UtilidadesPeterPan.BUSQUEDA] != null)
        {
            ObtenerBusqueda(Session[UtilidadesPeterPan.BUSQUEDA].ToString(), dllOrdenar.SelectedItem.Value);
        }
        else
        {
            ObtenerCatalogo(Session[UtilidadesPeterPan.TIPO_PROD].ToString(), dllOrdenar.SelectedItem.Value);
        }
    }

    /// <summary>
    /// Asignar a Labels
    /// </summary>
    /// <param name="producto"></param>
    void AsignarPromocion(ProductoVO producto)
    {
        //imgPromocion.ImageUrl = producto.Imagen;
        //lblDescripcionPromo.Text = producto.Descripcion;
        //lblValorPromo.Text = String.Format("${0:#,#}", producto.Precio_Venta);
        //Session[UtilidadesPeterPan.PROMO_ACTUAL] = producto.Referencia;
    }

    protected void tmPromo_Tick(object sender, EventArgs e)
    {
        /*ProductoVO prod = new ProductoVO();
        List<ProductoVO> productos = new List<ProductoVO>();
        productos = (List<ProductoVO>)Session[UtilidadesPeterPan.PRODUCTOS];
        bool _encontrado = false;
        if (productos.Last<ProductoVO>().Imagen == imgPromocion.ImageUrl)
        {
            prod = productos.First<ProductoVO>();
            AsignarPromocion(prod);
        }
        else
        {
            
            foreach (ProductoVO producto in productos)
            {
                if (_encontrado == true)
                {
                    AsignarPromocion(producto);
                    break;
                }
                if (producto.Imagen == imgPromocion.ImageUrl)
                {
                    _encontrado = true;
                }
            }
        }*/
    }
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        if (txtBuscar.Text != String.Empty)
        {
            //LLAMAR PROCEDIMIENTO BUSQUEDA
            Busqueda(txtBuscar.Text);
        }
    }
    protected void gvCatalogo_SelectedIndexChanged(object sender, EventArgs e)
    {
        String referencia;
        referencia = Convert.ToString(gvCatalogo.DataKeys[gvCatalogo.SelectedIndex].Value);
        AgregarCarrito(referencia);
    }

    void AgregarCarrito(string referencia)
    {
        ProductoVO _producto = new ProductoVO();
        List<ProductoVO> _productos = new List<ProductoVO>();
        _producto = ConsultarProducto(referencia);
        if (Session[UtilidadesPeterPan.VENTAS] == null)
        {
            _productos.Add(_producto);
            Session[UtilidadesPeterPan.VENTAS] = _productos;
        }
        else
        {
            _productos = (List<ProductoVO>)Session[UtilidadesPeterPan.VENTAS];
            _productos.Add(_producto);
            Session[UtilidadesPeterPan.VENTAS] = _productos;
        }
        DataBindVentas(_productos);
        pnlCompras.Visible = true;
    }

    void DataBindVentas(List<ProductoVO> productos)
    {
        decimal valor=0;
        gvCompras.DataSource = productos;
        gvCompras.DataBind();
        lblNumeroCompras.Text = "Productos: " + productos.Count.ToString();
        foreach(ProductoVO prod in productos)
        {
            valor=valor+prod.Precio_Venta;
        }
        lblTotal.Text = "Total: " + String.Format("${0:#,#}", valor);
    }

    ProductoVO ConsultarProducto(string strReferencia)
    {
        DAL_Consultascs consultas = new DAL_Consultascs();
        return consultas.ConsultarXReferencia(strReferencia);
    }
    protected void btnCancelarCompra_Click(object sender, EventArgs e)
    {
        CancelaCompra();
    }

    void CancelaCompra()
    {
        gvCompras.DataSource = null;
        gvCompras.DataBind();
        pnlCompras.Visible = false;
        Session.Remove(UtilidadesPeterPan.VENTAS);
    }

    protected void gvCompras_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string referencia;
        referencia = gvCompras.DataKeys[e.RowIndex].Value.ToString();
        ProductoVO _producto;
        List<ProductoVO> _productos = new List<ProductoVO>();
        _productos = (List<ProductoVO>)Session[UtilidadesPeterPan.VENTAS];
        _producto = ConsultarProducto(referencia);
        _producto = _productos.Find(
            delegate(ProductoVO cnt)
            {
                return cnt.Referencia  == _producto.Referencia;
            }
         );
        _productos.Remove(_producto);
        if (_productos.Count > 0)
        {
            DataBindVentas(_productos);
        }
        else
        {
            CancelaCompra();
        }
    }

    void Busqueda(String strBusqueda)
    {
        //LLAMAR PROCEDIMIENTO BUSQUEDA
        ObtenerBusqueda(strBusqueda, dllOrdenar.SelectedItem.Value);
        lblBusqueda.Text = "Su busqueda: " + strBusqueda + " arrojo los siguientes resultados ...";
        Session[UtilidadesPeterPan.BUSQUEDA] = strBusqueda;
    }

    protected void imgPromocion_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx?catalogo=P", true);
    }
    protected void btnFinalizar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Frm_Compra.aspx", true);
    }
}