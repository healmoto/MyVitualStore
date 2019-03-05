<%@ Page Title="Pañalera Peter Pan" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeFile="Frm_Contactenos.aspx.cs" Inherits="Frm_Contactenos"
    Theme="Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="75%" align="center">
        <tr>
            <td style="width:50%; Border-color:#aa0044; border:1px; border-style:ridge">
                <table width="100%" >
                    <tr>
                        <td colspan="2">
                            <asp:Label runat="server" Text="Contactenos" Font-Size="Large"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label runat="server" ID="lblMensaje" ForeColor="Red" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:50%">Nombre:</td>
                        <td style="width:50%">
                            <asp:TextBox runat="server" ID="txtNombre" MaxLength="100" Width="90%"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtNombre" Display="Dynamic" ForeColor="Red" runat="server" 
                            ValidationGroup="Enviar" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:50%">Email:</td>
                        <td style="width:50%">
                            <asp:TextBox runat="server" ID="txtEmail" MaxLength="50" Width="90%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" runat="server" 
                            ValidationGroup="Enviar" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:50%">Producto:</td>
                        <td style="width:50%">
                            <asp:TextBox runat="server" ID="txtProducto" MaxLength="50" Width="90%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtProducto" Display="Dynamic" ForeColor="Red" runat="server" 
                            ValidationGroup="Enviar" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:50%">Comentarios:</td>
                        <td style="width:50%">
                            <asp:TextBox runat="server" ID="txtComentarios" MaxLength="200" TextMode="MultiLine" Width="90%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtComentarios" Display="Dynamic" ForeColor="Red" runat="server" 
                            ValidationGroup="Enviar" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:50%"></td>
                        <td style="width:50%">
                            <asp:Button runat="server" Text="Enviar" ID="btnEnviar" 
                                ValidationGroup="Enviar" onclick="btnEnviar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width:50%">
                <asp:Image runat="server" ImageUrl="~/App_Themes/Principal/ubicacion.PNG"  Width="350px" Height="300px" />
            </td>
        </tr>
    </table>
    <table width="75%" align="center" style="background-color:#aa0044">
        <tr style="background-color:#aa0044; border-bottom-color:Silver">
            <td colspan="2" align="left">
                <asp:Label runat="server" Font-Bold="true" ForeColor="White" Font-Size="Large" Text="Visitenos: Carrera 77A # 64B 22 Barrio Villa Luz. Telefono: 547 06 94"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                <asp:Label runat="server" Font-Bold="true" ForeColor="White" Font-Size="Large" Text="Escribanos: info@bebespeterpan.com. Twitter: @bebespeterpan"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 50%; height: 300px" align="center">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Fotos/PP1.png" Width="350px" Height="300px" />
            </td>
            <td style="width: 50%; height: 300px" align="center">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Fotos/PP2.png" Width="350px" Height="300px" />
            </td>
        </tr>
        <tr>
            <td style="width: 50%; height: 300px" align="center">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Fotos/PP3.png" Width="350px" Height="300px" />
            </td>
            <td style="width: 50%; height: 300px" align="center">
                <asp:Image ID="Image4" runat="server" ImageUrl="~/Fotos/PP4.png" Width="350px" Height="300px" />
            </td>
        </tr>
    </table>
</asp:Content>
