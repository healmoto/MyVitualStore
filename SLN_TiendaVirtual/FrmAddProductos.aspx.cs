using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.DAL_Consultas;
using Entities;

public partial class FrmAddProductos : System.Web.UI.Page
{
    enum eTipoRegistro
    {
        Crear,
        Editar
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        UtilidadesPeterPan.VerificarSesion();
        if (!IsPostBack)
        {
            ObtenerDominio(UtilidadesPeterPan.DOMINIO_TIPO_PROD, ddlTipo);
            ConsultarProductos();
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


    void ConsultarProductos()
    {
        DAL_Consultascs datos = new DAL_Consultascs();
        gvProductos.DataSource = datos.ConsultarProductos(txtCriterio.Text);
        gvProductos.DataBind();
    }
    protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProductos.PageIndex = e.NewPageIndex;
        ConsultarProductos();
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        ConsultarProductos();
    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        Session["TipoRegistro"] = eTipoRegistro.Crear;
        pnlProducto.Visible = true;
        txtReferencia.Focus();
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlProducto.Visible = false;
        Borrar();
    }

    void Borrar()
    {
        Borrar(txtCosto);
        Borrar(txtDescripcion);
        Borrar(txtImagen);
        Borrar(txtNombre);
        Borrar(txtPrecioVenta);
        Borrar(txtReferencia);
        Borrar(chkEstado);
        Borrar(chkPromocion);
        Borrar(lblConsecutivo);
    }

    void Borrar(TextBox texto)
    {
        texto.Text  = string.Empty;
    }

    void Borrar(Label lbl)
    {
        lbl.Text = string.Empty;
    }

    void Borrar(CheckBox chk)
    {
        chk.Checked = false;
    }
    protected void gvProductos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        e.NewEditIndex = -1;
    }

    void LLenar(ProductoVO _producto)
    {
        txtCosto.Text = _producto.Costo.ToString("N0").Replace(".", "").Replace(",", "").Replace("$", "");
        txtDescripcion.Text = _producto.Descripcion;
        txtImagen.Text = _producto.Imagen;
        txtNombre.Text = _producto.Nombre;
        txtPrecioVenta.Text = _producto.Precio_Venta.ToString("N0").Replace(".", "").Replace(",", "").Replace("$","");
        txtReferencia.Text = _producto.Referencia;
        chkEstado.Checked = _producto.estado == "A" ? true : false;
        chkPromocion.Checked = _producto.Promocion == 1 ? true : false;
        lblConsecutivo.Text = _producto.Consecutivo.ToString();
        try
        {
            ddlTipo.SelectedValue = _producto.Tipo;
        }
        catch (Exception)
        {

        }
    }

    protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row=((Control)e.CommandSource).NamingContainer as GridViewRow;
        if (e.CommandName == "Edit")
        {
            DAL_Consultascs datos = new DAL_Consultascs();
            ProductoVO _producto = new ProductoVO();
            Session["TipoRegistro"] = eTipoRegistro.Editar;
            Int32 _consecutivo = Convert.ToInt32(gvProductos.DataKeys[row.RowIndex].Value.ToString());
            _producto = datos.ConsultarProducto(_consecutivo);
            pnlProducto.Visible = true;
            LLenar(_producto);
        }
    }

    void Guardar(ProductoVO _producto)
    {
        DAL_Consultascs oDatos = new DAL_Consultascs();
        eTipoRegistro eTipo;
        eTipo = (eTipoRegistro)Session["TipoRegistro"];
        if (eTipo == eTipoRegistro.Editar)
        {
            oDatos.Guardar(_producto,1);
        }
        else
        {
            oDatos.Guardar(_producto, 2);
        }
        Borrar();
        pnlProducto.Visible = false;
        ConsultarProductos();
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        ProductoVO _producto = new ProductoVO();
        if (lblConsecutivo.Text != String.Empty)
        {
            _producto.Consecutivo = Convert.ToInt32(lblConsecutivo.Text);
        }
        _producto.Referencia = txtReferencia.Text;
        _producto.Costo = Convert.ToDecimal(txtCosto.Text);
        _producto.Descripcion = txtDescripcion.Text;
        _producto.estado = chkEstado.Checked == true ? "A" : "I";
        _producto.Imagen = txtImagen.Text;
        _producto.Nombre = txtNombre.Text;
        _producto.Precio_Venta = Convert.ToDecimal(txtPrecioVenta.Text);
        _producto.Promocion = Convert.ToInt16(chkPromocion.Checked == true ? 1 : 0);
        _producto.Tipo = ddlTipo.SelectedItem.Value;
        Guardar(_producto);
    }

    void Eliminar(Int32 _consecutivo)
    {
        DAL_Consultascs _datos = new DAL_Consultascs();
        _datos.Eliminar(_consecutivo);
        ConsultarProductos();
    }

    protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Int32 _consecutivo = Convert.ToInt32(gvProductos.DataKeys[e.RowIndex].Value.ToString());
        Eliminar(_consecutivo);
    }
}