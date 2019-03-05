using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.DAL_Ventas;

public partial class Frm_Contactenos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = String.Empty;
        DAL_Venta oVenta = new DAL_Venta();
        Contacto contacto = new Contacto();
        contacto.Comentarios = txtComentarios.Text;
        contacto.Email = txtEmail.Text;
        contacto.Nombre = txtNombre.Text;
        contacto.Producto = txtProducto.Text;
        try
        {
            oVenta.InsertarContacto(contacto);
            lblMensaje.Text = "Se envio su solicitud. Nuestro equipo lo contactara, gracias por la información.";
        }
        catch
        {
            Response.Redirect("~/About.aspx");
        }
    }
}