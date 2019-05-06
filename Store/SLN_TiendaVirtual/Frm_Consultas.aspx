<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Frm_Consultas.aspx.cs" Inherits="Frm_Consultas" Theme="Principal"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="width: 80%" align="center">
        <tr>
            <td>Consolidado Total
                   <asp:RadioButton runat="server" ID="optCompleto" GroupName="Opciones"  OnCheckedChanged="optCompleto_CheckedChanged" AutoPostBack="true" />
            </td>
            <td>Consolidado  Mensual
                   <asp:RadioButton runat="server" ID="optMensual" GroupName="Opciones" OnCheckedChanged="optMensual_CheckedChanged" AutoPostBack="true" />
            </td>
            <td>Consolidado Diario
                   <asp:RadioButton runat="server" ID="optDiario" GroupName="Opciones" OnCheckedChanged="optDiario_CheckedChanged" AutoPostBack="true" />
            </td>
            <td>
                <asp:Button runat="server" Text="Buscar" ID="btnBuscar" OnClick="btnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 25%">
                <asp:Label runat="server" Text ="Año" ID="lblAnio" Visible="false"></asp:Label>
            </td>
            <td style="text-align: left; width: 25%">
                <asp:DropDownList runat="server" ID="ddlAnio" Visible="false" AutoPostBack="true" >
                </asp:DropDownList>
            </td>
            <td style="text-align: right; width: 25%">
                <asp:Label runat="server" Text ="Mes" ID="lblMes" Visible="false"></asp:Label>
            </td>
            <td style="text-align: left; width: 25%">
                <asp:DropDownList runat="server" ID="ddlMes" Visible="false" AutoPostBack="true" >
                    <asp:ListItem Text="Enero" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Febrero" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Marzo" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Abril" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Mayo" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Junio" Value="6"></asp:ListItem>
                    <asp:ListItem Text="Julio" Value="7"></asp:ListItem>
                    <asp:ListItem Text="Agosto" Value="8"></asp:ListItem>
                    <asp:ListItem Text="Septiembre" Value="9"></asp:ListItem>
                    <asp:ListItem Text="Octubre" Value="10"></asp:ListItem>
                    <asp:ListItem Text="Noviembre" Value="11"></asp:ListItem>
                    <asp:ListItem Text="Diciembre" Value="12"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView runat="server" AutoGenerateColumns="False" Width ="100%" ID="gvConsolidado" >
                    <Columns>
                        <asp:BoundField DataField="ANIO" HeaderText="AÑO" />
                        <asp:BoundField DataField="DIA" HeaderText="DIA" />
                        <asp:BoundField DataField="MES" HeaderText="MES" />
                        <asp:BoundField DataField="VENTAS" DataFormatString="{0:C}" HeaderText="VENTAS" />
                        <asp:BoundField DataField="TARJETA" DataFormatString="{0:C}" HeaderText="TARJETA" />
                        <asp:BoundField DataField="UTILIDAD" DataFormatString="{0:C}" HeaderText="UTILIDAD" />
                    </Columns>

                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

