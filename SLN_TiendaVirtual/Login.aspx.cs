using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.DAL_Consultas;

public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        UsuarioVO usuario = new UsuarioVO();
        DAL_Consultascs consultas = new DAL_Consultascs();
        int existe=0;
        existe = consultas.IniciarSesion(LoginUser.UserName.ToString(), LoginUser.Password.ToString());
        if (existe != 0)
        {
            usuario.Contraseña = LoginUser.Password.ToString();
            usuario.Usuario = LoginUser.UserName.ToString();
            Session[UtilidadesPeterPan.USUARIO] = usuario;
            Response.Redirect("Default.aspx", true);
        }
        else
        {
            Response.Redirect("Login.aspx", true);
        }
    }
}
