<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <asp:UpdatePanel ID="uPanelPrueba" runat="server">
            <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="0001" OnTick="Timer1_Tick">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1000" AssociatedUpdatePanelID="uPanelPrueba">
            <ProgressTemplate>
                <div>
                    <span></span>
                    <br />
                    <table width="80%" align="center">
                        <tr>
                            <td align="center">
                                <img id="idjecutando" runat="server" alt="generando" src="~/App_Themes/Principal/clock.gif" />    
                            </td>
                        </tr>
                    </table>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>

