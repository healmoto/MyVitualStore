using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.DAL_Consultas;
using Entities;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String _anonimo = "Anonimo";
        UsuarioVO usuario = new UsuarioVO();
        CargarMenu(1);
        if (Session[UtilidadesPeterPan.USUARIO] == null)
        {
            usuario.Usuario = _anonimo;
            Session[UtilidadesPeterPan.USUARIO] = usuario;
        }
        else
        {
            usuario = (UsuarioVO)Session[UtilidadesPeterPan.USUARIO];
            if (usuario.Usuario != _anonimo)
            {
                CargarMenu(2);
            }
        }
    }
    protected void lblIniciarSesion_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx", true);
    }

    void CargarMenu(int modulo)
    {
        /*if (NavigationMenu.Items.Count == 1)
        {*/
            DAL_Consultascs consultas = new DAL_Consultascs();
            List<Opcion> opciones = new List<Opcion>();
            opciones = consultas.ConsultarMenu(modulo);
            int contador = NavigationMenu.Items.Count-1;
            foreach (Opcion opt in opciones)
            {
                if (opt.padre == 0)
                {
                    NavigationMenu.Items.Add(new MenuItem(opt.nombre, opt.Consecutivo.ToString(), String.Empty, opt.url));
                    contador = contador + 1;
                }
                else
                {
                    NavigationMenu.Items[contador].ChildItems.Add(new MenuItem(opt.nombre, opt.Consecutivo.ToString(), String.Empty, opt.url));
                }
            }
        //}
    }
}
