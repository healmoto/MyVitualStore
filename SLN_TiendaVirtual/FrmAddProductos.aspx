<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrmAddProductos.aspx.cs" Inherits="FrmAddProductos"
    Theme="Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="width: 80%" align="center">
        <tr>
            <td>
                <asp:Label runat="server" Text="Nombre Producto"></asp:Label>
                <asp:TextBox runat="server" ID="txtCriterio" Width="60%"></asp:TextBox>
                <asp:Button runat="server" ID="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel runat="server" ID="pnlProducto" Visible="false">
                    <table width="60%" style="border:dashed;">
                        <tr>
                            <td style="text-align: right; width: 50%">Consecutivo</td>
                            <td style="text-align: left; width: 50%">
                                <asp:Label runat="server" ID="lblConsecutivo"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50%">Referencia</td>
                            <td style="text-align: left; width: 50%">
                                <asp:TextBox ID="txtReferencia" runat="server" Width="90%"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtReferencia" Display="Dynamic" ErrorMessage="Campo Obligatorio"
                                    ValidationGroup="Guardar" ForeColor="Red" ></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50%">Nombre</td>
                            <td style="text-align: left; width: 50%">
                                <asp:TextBox ID="txtNombre" runat="server" Width="90%"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" Display="Dynamic" ErrorMessage="Campo Obligatorio"
                                    ValidationGroup="Guardar" ForeColor="Red" ></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50%">Descripción</td>
                            <td style="text-align: left; width: 50%">
                                <asp:TextBox ID="txtDescripcion" runat="server" Width="90%"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDescripcion" Display="Dynamic" ErrorMessage="Campo Obligatorio"
                                    ValidationGroup="Guardar" ForeColor="Red" ></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50%">Costo</td>
                            <td style="text-align: left; width: 50%">
                                <asp:TextBox ID="txtCosto" runat="server" Width="90%"></asp:TextBox>
                                <asp:CompareValidator runat="server" ControlToValidate="txtCosto" Display="Dynamic" ErrorMessage="Dato Incorrecto" Operator="DataTypeCheck"
                                 Type="Double" ValidationGroup="Guardar" ForeColor="Red"></asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCosto" Display="Dynamic" ErrorMessage="Campo Obligatorio"
                                    ValidationGroup="Guardar" ForeColor="Red" ></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50%">Precio Venta</td>
                            <td style="text-align: left; width: 50%">
                                <asp:TextBox ID="txtPrecioVenta" runat="server" Width="90%"></asp:TextBox>
                                <asp:CompareValidator runat="server" ControlToValidate="txtPrecioVenta" Display="Dynamic" ErrorMessage="Dato Incorrecto" Operator="DataTypeCheck"
                                 Type="Double" ValidationGroup="Guardar" ForeColor="Red"></asp:CompareValidator>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrecioVenta" Display="Dynamic" ErrorMessage="Campo Obligatorio"
                                    ValidationGroup="Guardar" ForeColor="Red" ></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50%">Imagen</td>
                            <td style="text-align: left; width: 50%">
                                <asp:TextBox ID="txtImagen" runat="server" Width="90%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50%">Tipo de Producto</td>
                            <td style="text-align: left; width: 50%">
                                <asp:DropDownList runat="server" ID="ddlTipo" Width="90%"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50%">Estado</td>
                            <td style="text-align: left; width: 50%">
                                <asp:CheckBox runat="server" ID="chkEstado" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50%">Promoción</td>
                            <td style="text-align: left; width: 50%">
                                <asp:CheckBox runat="server" ID="chkPromocion" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right" >
                                <asp:Button runat="server"  ID="btnAceptar" Text="Aceptar" ValidationGroup="Guardar" OnClick="btnAceptar_Click" />
                                <asp:Button runat="server"  ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton runat="server" ID="btnAgregar" AlternateText="Nuevo Producto" ImageUrl="~/App_Themes/Principal/001_01.ico" OnClick="btnAgregar_Click" />
                <asp:Label runat="server" Text=" Nuevo Producto" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView runat="server" ID="gvProductos" AutoGenerateColumns="False" Width="100%" AllowPaging="True" DataKeyNames="Consecutivo" OnPageIndexChanging="gvProductos_PageIndexChanging" OnRowEditing="gvProductos_RowEditing" OnRowCommand="gvProductos_RowCommand" OnRowDeleting="gvProductos_RowDeleting">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/Principal/001_05.png" ToolTip="Eliminar"
                                    CommandName="Delete" OnClientClick="Javascript:return confirm('Desea Eliminar Registro?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ImageUrl="~/App_Themes/Principal/001_45.ico" ToolTip="Editar"
                                    CommandName="Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="Referencia" HeaderText="Referencia" />
                        <asp:BoundField DataField="Costo" HeaderText="Costo" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Precio_Venta" HeaderText="Precio Venta" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    </Columns>

                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

