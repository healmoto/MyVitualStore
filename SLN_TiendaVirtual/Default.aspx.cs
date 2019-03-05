using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Entities;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString[UtilidadesPeterPan.CATALOGO] != null)
            {
                Session[UtilidadesPeterPan.TIPO_PROD] = Request.QueryString[UtilidadesPeterPan.CATALOGO].ToString();
                //Timer1.Enabled = true;
                Response.Redirect("~/Frm_Catalogo.aspx", true);
            }
            else
            {
                Session[UtilidadesPeterPan.TIPO_PROD] = UtilidadesPeterPan.TIPO_DEFAULT;
                Response.Redirect("~/Frm_Catalogo.aspx", true);
            }
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //System.Threading.Thread.Sleep(2000);
        Timer1.Enabled = false;
        Response.Redirect("~/Frm_Catalogo.aspx", true);
    }
}