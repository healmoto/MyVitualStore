<%@ Page Title="Pañalera Peter Pan" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeFile="Frm_Confirmacion.aspx.cs" Inherits="Frm_Confirmacion"
    Theme="Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <br />
    <table width="80%" align="center" style="border-color: #aa0044; border-style: ridge">
        <tr>
            <td colspan="2" style="border-bottom-style: ridge">
                <asp:Label runat="server" Text="DATOS DE COMPRA" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lblMensajeFinal"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <asp:Label ID="Label9" runat="server" Text="Número Aprobación" Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:Label runat="server" ID="lblNumeroAprobacion"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <asp:Label ID="Label1" runat="server" Text="Nombre Completo" Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:Label runat="server" ID="txtNombre"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <asp:Label ID="Label3" runat="server" Text="Email" Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:Label ID="txtEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <asp:Label ID="Label4" runat="server" Text="Telefono" Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:Label ID="txtTelefono" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <asp:Label ID="Label5" runat="server" Text="Dirección" Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:Label ID="txtDireccion" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <asp:Label ID="Label6" runat="server" Text="Ciudad" Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:Label ID="dllCiudad" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <asp:Label ID="Label7" runat="server" Text="Barrio" Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:Label ID="txtBarrio" runat="server" Width="90%" MaxLength="50"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <asp:Label ID="Label2" runat="server" Text="Envio" Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:Label ID="lblEnvio" runat="server" Width="90%" MaxLength="50"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <asp:Label ID="Label8" runat="server" Text="Pago" Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:Label ID="lblPago" runat="server" MaxLength="50"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <div runat="server" id="divPrint">
                <asp:GridView runat="server" ID="gvCompras" Width="100%" AutoGenerateColumns="False"
                    DataKeyNames="referencia">
                    <Columns>
                        <asp:BoundField DataField="Referencia" HeaderText="Referencia" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Precio_Venta" HeaderText="Precio" DataFormatString="${0:#,#}" />
                    </Columns>
                </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
            <td align="right">
                <asp:Label runat="server" ID="lblTotal" Font-Size="Large" Font-Names="Arial Black"
                    Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
            </td>
            <td align="left" style="width: 50%">
                <asp:Button ID="btnContinuar" runat="server" Text="Imprimir" 
                    onclick="btnContinuar_Click"  />
            </td>
        </tr>
    </table>
</asp:Content>
