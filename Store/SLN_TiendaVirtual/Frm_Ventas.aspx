<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Frm_Ventas.aspx.cs" Inherits="Frm_Ventas" Theme="Principal"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" >
        <tr>
            <td>Fecha:</td>
            <td>
                <asp:Calendar ID="clFecha" runat="server" TitleFormat="Month" OnSelectionChanged="clFecha_SelectionChanged"></asp:Calendar>
            </td>
            <td>
                <asp:CheckBox runat="server" ID="chkTarjeta" Text="Tarjeta" />
            </td>
            <td>
                <asp:CheckBox runat="server" ID="chkWeb" Text="Web" />
                <asp:Button ID="btnRefrescar" Text="Refrescar" runat="server" OnClick="btnRefrescar_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="btnCerrar" runat="server" Text="Cierre Caja" OnClick="btnCerrar_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center" >
                <asp:Panel ID="pnlCierre" Visible="false" runat="server" >
                    <table width="60%">
                        <tr>
                            <td colspan="2">
                                <asp:Label runat="server" ID="lblMensaje" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:50%" align="right" >Base</td>
                            <td style="width:50%" align="left"  >
                                <asp:TextBox runat="server" ID="txtBase" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:50%" align="right"   >Efectivo</td>
                            <td style="width:50%" align="left"  >
                                <asp:TextBox runat="server" ID="txtEfectivo" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right" >
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center" >
                <asp:GridView runat="server" ID="gvVentas" Width="100%" AutoGenerateColumns="False" DataKeyNames="Numero_Venta,Numero_Detalle" OnRowDeleting="gvVentas_RowDeleting"  >
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/Principal/001_05.png" ToolTip="Eliminar"
                                    CommandName="Delete" OnClientClick="Javascript:return confirm('Desea Eliminar Registro?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Producto" HeaderText="Producto" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio Venta" DataFormatString="{0:C}"  />
                        <asp:BoundField DataField="Total" HeaderText="Total Venta" DataFormatString="{0:C}"  />
                        <asp:BoundField DataField="Numero_Venta" HeaderText="Nro. Factura" />
                        <asp:BoundField DataField="Archivo" HeaderText="Archivo" />
                    </Columns>
                    <EmptyDataTemplate>
                        No existen datos para mostrar
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="right" >
                <asp:Label runat="server" ID="lblTotal"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

