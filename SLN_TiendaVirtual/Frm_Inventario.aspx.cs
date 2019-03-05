using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.DAL_Consultas;
using Entities;


public partial class Frm_Inventario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UtilidadesPeterPan.VerificarSesion();
        if (!IsPostBack)
        {
            DAL_Consultascs datos = new DAL_Consultascs();
            DateTime _fechaInventario = datos.ConsultarFechaInventario();
            txtFechaInicial.Text = String.Format("{0}/{1}/{2}", _fechaInventario.Year.ToString(), _fechaInventario.Month.ToString(), _fechaInventario.Day.ToString());
            txtFechaInicial.Enabled = false;
        }
    }
    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        DAL_Consultascs datos = new DAL_Consultascs();
        DateTime _fechaInicial = DateTime.Parse(txtFechaInicial.Text );
        DateTime _fechaFinal = DateTime.Parse(txtFechaFinal.Text );
        gvConsolidado.DataSource = datos.ConsultarIventario(_fechaInicial, _fechaFinal);
        gvConsolidado.DataBind();
        if (gvConsolidado.Rows.Count > 1)
        {
            btnExcel.Visible = true;
        }
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment;filename=inventario.xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        this.EnableViewState = false;

        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

        gvConsolidado.RenderControl(htw);

        Response.Write(sw.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}