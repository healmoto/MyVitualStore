using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.DAL_Consultas;
using Entities;
using DAL;

public partial class Frm_Ventas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UtilidadesPeterPan.VerificarSesion();
        if (!IsPostBack)
        {
            clFecha.SelectedDate = DateTime.Now.Date;
            Ventas();
        }
    }

    void Ventas()
    {
        DateTime _fecha; 
        Int16 _tarjeta;
        Int16 _web;
        _fecha = clFecha.SelectedDate;
        if (chkWeb.Checked == true)
        {
            _web = 1;
        }
        else
        {
            _web = 0;
        }
        if (chkTarjeta.Checked == true)
        {
            _tarjeta = 1;
        }
        else
        {
            _tarjeta = 0;
        }
        if (Session[UtilidadesPeterPan.USUARIO] != null)
        {
            decimal total=0;
            List<ConsultaVentaVO> ventas = new List<ConsultaVentaVO>();
            DAL_Consultascs consultas = new DAL_Consultascs();
            ventas = consultas.ConsultarVentas(_fecha, _tarjeta, _web);
            gvVentas.DataSource = ventas;
            gvVentas.DataBind();
            foreach (ConsultaVentaVO _venta in ventas)
            {
                total = total + (_venta.Cantidad * _venta.Precio);
            }
            lblTotal.Text = total.ToString("C");
        }
        else
        {
            Response.Redirect("Login.aspx", true);
        }
    }

    protected void btnRefrescar_Click(object sender, EventArgs e)
    {
        Ventas();
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensaje.Text = String.Empty;
            Cerrar(Convert.ToDecimal(txtBase.Text), Convert.ToDecimal(txtEfectivo.Text), clFecha.SelectedDate);
            Cancelar();
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Cancelar();
    }

    void Cancelar()
    {
        lblMensaje.Text = String.Empty;
        txtBase.Text = string.Empty;
        txtEfectivo.Text = String.Empty;
        pnlCierre.Visible = false;
    }

    void Cerrar(decimal _base, decimal _efectivo, DateTime _fecha)
    {
        DAL.DAL_Ventas.DAL_Venta _cierre = new DAL.DAL_Ventas.DAL_Venta();
        _cierre.InsertarCierre(_base, _efectivo, _fecha);
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        pnlCierre.Visible = true;
    }
    protected void clFecha_SelectionChanged(object sender, EventArgs e)
    {
        Ventas();
    }
    protected void gvVentas_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DAL_Consultascs oDatos = new DAL_Consultascs();
        Int64 _numero_venta = Convert.ToInt32(gvVentas.DataKeys[e.RowIndex].Values[0].ToString());
        Int64 _numero_detalle = Convert.ToInt32(gvVentas.DataKeys[e.RowIndex].Values[1].ToString());
        oDatos.EliminarVenta(_numero_venta, _numero_detalle);
        Ventas();
    }
}