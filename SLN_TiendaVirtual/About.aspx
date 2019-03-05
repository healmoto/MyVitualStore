<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Lo Sentimos ocurrio un error. Intente mas tarde, lo estamos arreglando.
    </h2>
        <table width="100%" align="center">
            <tr>
                <td align="center">
                    <asp:Image runat="server" ImageUrl="~/Fotos/error.jpg" />
                </td>
            </tr>
        </table>
</asp:Content>
