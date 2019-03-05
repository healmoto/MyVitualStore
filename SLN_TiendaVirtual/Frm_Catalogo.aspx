<%@ Page Title="Pañalera Peter Pan" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Frm_Catalogo.aspx.cs" Inherits="Frm_Catalogo" Theme="Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table border="0" width="80%" align="center">
        <tr>
            <td align="right" style="width: 80%">
                <asp:TextBox runat="server" ID="txtBuscar" Width="80%"></asp:TextBox>
            </td>
            <td align="left" style="width: 20%">
                <%--<asp:Button ID="btnBuscar" runat="server" Text="Buscar" />--%>
                <asp:ImageButton runat="server" ID="btnBuscar" ImageUrl="~/App_Themes/Principal/001_37.png"
                    OnClick="btnBuscar_Click" ToolTip="Buscar" />
            </td>
        </tr>
    </table>
    <table width="90%" align="center">
        <tr>
            <td>
                <asp:Panel runat="server" ID="pnlCompras" Width="100%" Visible="false">
                    <table width="100%" style="border-color: #aa0044; border-style: ridge">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label2" runat="server" Text="TUS COMPRAS" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%" align="center">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/Principal/carrito.png" ImageAlign="Middle" Width="100px" Height="100px" />
                                <asp:Label runat="server" ID="lblNumeroCompras"></asp:Label>
                            </td>
                            <td style="width: 70%">
                                <asp:GridView runat="server" ID="gvCompras" Width="100%" 
                                    AutoGenerateColumns="False" onrowdeleting="gvCompras_RowDeleting" DataKeyNames="referencia" >
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/Principal/001_05.png" ToolTip="Eliminar"
                                                    CommandName="Delete" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Referencia" HeaderText="Referencia" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                        <asp:BoundField DataField="Precio_Venta" HeaderText="Precio" DataFormatString="${0:#,#}" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td  align="center">
                                <asp:Label runat="server" ID="lblTotal" Font-Size="Large" Font-Names="Arial Black"
                            Font-Bold="true"></asp:Label>
                            </td>
                            <td align="right" >
                                <asp:Button runat="server" ID="btnCancelarCompra" Text="Cancelar Compra" 
                                    onclick="btnCancelarCompra_Click" />
                                <asp:Button runat="server" ID="btnFinalizar" Text="Finalizar Compra" 
                                    onclick="btnFinalizar_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <%--<tr>
            <td>
                <asp:Timer ID="tmPromo" runat="server" Interval="4000" OnTick="tmPromo_Tick">
                </asp:Timer>
                <asp:Label ID="Label1" runat="server" Text="DESTACADOS" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
            </td>
        </tr>--%>
        <%--<tr>
            <td style="width: 100%; border-color: #aa0044; border-style: ridge; height:250px" align="center">
                <asp:UpdatePanel runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:ImageButton runat="server" ID="imgPromocion" 
                            onclick="imgPromocion_Click" Height="250px" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="tmPromo" EventName="Tick" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>--%>
        <%--<tr>
            <td align="center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label runat="server" ID="lblDescripcionPromo" Font-Size="Large" Font-Names="Arial"></asp:Label>
                        <asp:Label runat="server" ID="lblValorPromo" Font-Size="Large" Font-Names="Arial Black"
                            Font-Bold="true"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="tmPromo" EventName="Tick" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>--%>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblBusqueda"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label runat="server" Text="Ordernar Por:"></asp:Label>
                <asp:DropDownList runat="server" ID="dllOrdenar" Width="20%" AutoPostBack="true"
                    OnSelectedIndexChanged="dllOrdenar_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView runat="server" ShowHeader="False" AutoGenerateColumns="False" Width="100%"
                    ID="gvCatalogo" BorderColor="#AA0044" GridLines="Horizontal" DataKeyNames="Referencia"
                    OnSelectedIndexChanged="gvCatalogo_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ImageUrl="~/App_Themes/Principal/carrito.png" ImageAlign="Middle"
                                    Width="50px" Height="50px" ToolTip="Comprar" CommandName="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ImageField DataImageUrlField="Imagen" ControlStyle-Width="200px" ControlStyle-Height="200px"
                            ItemStyle-HorizontalAlign="Center" ControlStyle-BorderWidth="0">
                            <ControlStyle BorderWidth="0px" Height="200px" Width="200px"></ControlStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:ImageField>
                        <asp:BoundField DataField="Descripcion" ItemStyle-Font-Size="Large" ItemStyle-Font-Names="Arial">
                            <ItemStyle Font-Names="Arial" Font-Size="Large"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Precio_Venta" DataFormatString="${0:#,#}" ItemStyle-Font-Size="Large"
                            ItemStyle-Font-Names="Arial Black" ItemStyle-Font-Bold="true">
                            <ItemStyle Font-Bold="True" Font-Names="Arial Black" Font-Size="Large"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
