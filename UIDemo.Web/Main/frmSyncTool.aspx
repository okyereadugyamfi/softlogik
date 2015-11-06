<%@ Page Language="C#" AutoEventWireup="false" Codebehind="frmSyncTool.aspx.cs" Inherits="SMWeb05.Main.frmSyncTool"
    MasterPageFile="~/MasterPages/Dummy.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MPH" runat="server">
    <table class="DataGridContent">
        <tr>
            <td class="SettingsHeader">
                <STWC:GlobalizedLabel ID="Globalizedlabel1" ResourceIDPage="Information" runat="server"></STWC:GlobalizedLabel></td>
        </tr>
        <tr>
            <td class="IndentBothSides">
                <br style="line-height: 5px;" /><STWC:GlobalizedLabel ID="Globalizedlabel11" runat="server"></STWC:GlobalizedLabel><br /></td>
        </tr>
        <tr>
            <td class="SettingsHeader">
                <STWC:GlobalizedLabel ID="Globalizedlabel2" ResourceIDPage="Downloads" runat="server"></STWC:GlobalizedLabel></td>
        </tr>
        <tr>
            <td class="IndentBothSides">
                <STWC:HoverGrid ID="ProductsGrid" runat="server" HG_ColumnExclusionIndexes="0,1,2" HG_ClassSetName="SmallerDataGrid"
                    HG_StandardSettings="True" HG_HoverEnabled="False" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundColumn DataField="Name" />
                        <asp:BoundColumn DataField="DownloadLink"></asp:BoundColumn>
                        <asp:BoundColumn DataField="MoreInfoLink"></asp:BoundColumn>
                    </Columns>
                </STWC:HoverGrid>
            </td>
        </tr>
    </table>
</asp:Content>

