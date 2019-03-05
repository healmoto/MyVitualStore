using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.DAL_Consultas;
using Entities;

public partial class Frm_Consultas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UtilidadesPeterPan.VerificarSesion();
        if (!IsPostBack)
        {
            int anio = DateTime.Now.Year;
            int anioInicial = DateTime.Now.Year-5;
            for (int i = anio; i >= anioInicial; i--)
            {
                ListItem li = new ListItem();
                li.Text = i.ToString();
                li.Value = i.ToString();
                ddlAnio.Items.Add(li);
            }
            int _year = DateTime.Now.Year;
            int _month = DateTime.Now.Month;
            ddlAnio.SelectedValue = _year.ToString();
            ddlMes.SelectedValue = _month.ToString();
            Buscar();
        }
    }


    protected void optCompleto_CheckedChanged(object sender, EventArgs e)
    {
        lblAnio.Visible = false;
        lblMes.Visible = false;
        ddlAnio.Visible = false;
        ddlMes.Visible = false;
        Buscar();
    }
    protected void optMensual_CheckedChanged(object sender, EventArgs e)
    {
        lblAnio.Visible = true;
        lblMes.Visible = false;
        ddlAnio.Visible = true;
        ddlMes.Visible = false;
        Buscar();
    }
    protected void optDiario_CheckedChanged(object sender, EventArgs e)
    {
        lblAnio.Visible = true;
        lblMes.Visible = true;
        ddlAnio.Visible = true;
        ddlMes.Visible = true;
        Buscar();
    }

    public void Buscar()
    {
        int tipo = 0;
        int anio = 0;
        int mes = 0;
        if (optCompleto.Checked == true)
        {
            tipo = 1;
        }
        if (optMensual.Checked == true)
        {
            tipo = 2;
        }
        if (optDiario.Checked == true)
        {
            tipo = 3;
        }
        anio = Convert.ToInt16(ddlAnio.SelectedItem.Value);
        mes = Convert.ToInt16(ddlMes.SelectedItem.Value);
        DAL_Consultascs datos = new DAL_Consultascs();
        gvConsolidado.DataSource = datos.Consolidado(tipo, anio, mes);
        gvConsolidado.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Buscar();
    }
}


