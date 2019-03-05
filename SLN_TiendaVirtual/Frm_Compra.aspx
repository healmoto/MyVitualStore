<%@ Page Title="Pañalera Peter Pan" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeFile="Frm_Compra.aspx.cs" Inherits="Frm_Compra" Theme="Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%" style="border-color: #aa0044; border-style: ridge">
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" Text="CONFIRMACIÓN DE COMPRA" Font-Bold="true"
                    Font-Size="XX-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 30%" align="center">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/Principal/carrito.png"
                    ImageAlign="Middle" Width="100px" Height="100px" />
                <asp:Label runat="server" ID="lblNumeroCompras"></asp:Label>
            </td>
            <td style="width: 70%">
                <asp:GridView runat="server" ID="gvCompras" Width="100%"
                    AutoGenerateColumns="False" DataKeyNames="referencia">
                    <Columns>
                        <asp:BoundField DataField="Referencia" HeaderText="Referencia" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Precio_Venta" HeaderText="Precio" DataFormatString="${0:#,#}" />
                    </Columns>
                </asp:GridView>
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
    </table>
    <br />
    <br />
    <table width="80%" align="center" style="border-color:#aa0044; border-style:ridge">
        <tr>
            <td colspan="2" style="border-bottom-style:ridge">
                <asp:Label ID="Label1" runat="server" Text="DATOS DE COMPRA" Font-Bold="true"
                    Font-Size="XX-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary runat="server" ValidationGroup="Compra" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lblMensaje" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%" >
                <asp:Label runat="server" Text="Nombre Completo"  Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:TextBox runat="server" Width="90%" ID="txtNombre" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" Display="Dynamic" ErrorMessage="Campo Nombre Requerido" 
                Text="*" ValidationGroup="Compra" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <asp:Label ID="Label3" runat="server" Text="Email" Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:TextBox ID="txtEmail" runat="server" Width="90%" MaxLength="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Campo Email Requerido" 
                Text="*" ValidationGroup="Compra" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email Invalido" ForeColor="Red" 
                Text="*" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$" ValidationGroup="Compra" ></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <asp:Label ID="Label4" runat="server" Text="Telefono" Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:TextBox ID="txtTelefono" runat="server" Width="90%" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTelefono" Display="Dynamic" ErrorMessage="Campo Telefono Requerido" 
                Text="*" ValidationGroup="Compra" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <asp:Label ID="Label5" runat="server" Text="Dirección" Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:TextBox ID="txtDireccion" runat="server" Width="90%" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDireccion" Display="Dynamic" ErrorMessage="Campo Direccion Requerido" 
                Text="*" ValidationGroup="Compra" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <asp:Label ID="Label6" runat="server" Text="Ciudad" Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:DropDownList ID="dllCiudad" runat="server" Width="90%" AutoPostBack="true" 
                    onselectedindexchanged="dllCiudad_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dllCiudad" Display="Dynamic" ErrorMessage="Campo Ciudad Requerido" 
                Text="*" ValidationGroup="Compra" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <asp:Label ID="Label7" runat="server" Text="Barrio" Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:TextBox ID="txtBarrio" runat="server" Width="90%" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtBarrio" Display="Dynamic" ErrorMessage="Campo Barrio Requerido" 
                Text="*" ValidationGroup="Compra" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <asp:Label ID="Label8" runat="server" Text="Comentarios Adicionales" Font-Bold="true"></asp:Label>
            </td>
            <td align="left" style="width: 50%">
                <asp:TextBox ID="txtComentarios" runat="server" Width="90%" 
                    TextMode="MultiLine" MaxLength="200"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="border-bottom-style:ridge; width: 50%">
                <asp:Label ID="Label9" runat="server" Text="Método de Envio" Font-Bold="true"></asp:Label>
            </td>
            <td align="left"  style="border-bottom-style:ridge; width: 50%"></td>
        </tr>
        <tr>
            <td align="right" style="width: 50%"></td>
            <td align="left" style="width: 50%">
                <asp:RadioButton ID="optSer" runat="server" Text="Servientrega - $ 11.643" GroupName="Envio" Checked="true" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%"></td>
            <td align="left" style="width: 50%">
                <asp:RadioButton ID="optDom" runat="server" Text="Domicilio - $ 5.000" GroupName="Envio" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%"></td>
            <td align="left" style="width: 50%">
                <asp:RadioButton ID="optSin" runat="server" Text="Sin Envio" GroupName="Envio" />
            </td>
        </tr>
        <tr>
            <td align="right" style="border-bottom-style:ridge; width: 50%">
                <asp:Label ID="Label10" runat="server" Text="Método de Pago" Font-Bold="true"></asp:Label>
            </td>
            <td align="left"  style="border-bottom-style:ridge; width: 50%"></td>
        </tr>
        <%--<tr>
            <td align="right" style="width: 50%"></td>
            <td align="left" style="width: 50%">
                <asp:RadioButton ID="optPagos" runat="server" Text="Pagos Online - " Enabled="false" GroupName="MedioPago" />
                <asp:Image runat="server" ImageUrl="~/App_Themes/Principal/Pagos.png" Width="60%" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%"></td>
            <td align="left" style="width: 50%">
                <asp:RadioButton ID="optPay" runat="server" Text="Paypal - " Enabled="false" GroupName="MedioPago" />
                <asp:Image ID="Image2" runat="server" ImageUrl="~/App_Themes/Principal/paypal.png" Width="50%" Height="20px" />
            </td>
        </tr>--%>
        <tr>
            <td align="right" style="width: 50%"></td>
            <td align="left" style="width: 50%">
                <asp:RadioButton ID="optConsignacion" runat="server" Text="Consignación Bancaria" GroupName="MedioPago" Checked="true" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%"></td>
            <td align="left" style="width: 50%">
                <asp:RadioButton ID="optContra" runat="server" Text="Contraentrega" GroupName="MedioPago" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%"></td>
            <td align="left" style="width: 50%">
                <asp:Button ID="btnContinuar" runat="server" Text="Continuar" 
                    ValidationGroup="Compra" onclick="btnContinuar_Click" style="height: 26px" />
            </td>
        </tr>
    </table>
</asp:Content>
