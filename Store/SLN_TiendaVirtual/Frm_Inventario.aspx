<%@ Page Title="Inventario" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Frm_Inventario.aspx.cs" Inherits="Frm_Inventario" Theme="Principal"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <table style="width: 80%" align="center">
        <tr>
            <td>
                <table style="width: 60%" align="center">
                    <tr>
                        <td>Fecha Inicial</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtFechaInicial" MaxLength="10" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Fecha Final</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtFechaFinal" MaxLength="10" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>

                        </td>
                        <td>
                            <asp:Button runat="server" ID ="btnConsultar" Text="Consultar" CssClass="submitButton " OnClick="btnConsultar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>

                        </td>
                        <td>
                            <asp:Button runat="server" ID ="btnExcel" Text="Exportar" CssClass="submitButton " OnClick="btnExcel_Click" Visible="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView runat="server" AutoGenerateColumns="False" Width ="100%" ID="gvConsolidado" >
                    <Columns>
                        <asp:BoundField DataField="Referencia" HeaderText="REFERENCIA" />
                        <asp:BoundField DataField="Producto" HeaderText="PRODUCTO" />
                        <asp:BoundField DataField="Inventario" HeaderText="INVENTARIO" />
                        <asp:BoundField DataField="Entradas" HeaderText="ENTRADAS" />
                        <asp:BoundField DataField="Salidas" HeaderText="SALIDAS" />
                        <asp:BoundField DataField="Saldo" HeaderText="SALDO" />
                    </Columns>

                    <EmptyDataTemplate>
                        No se encontraron registros.
                    </EmptyDataTemplate>

                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

