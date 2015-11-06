<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="frmWelcome.aspx.cs" Inherits="SMWeb05.Main.frmWelcome" MasterPageFile="~/MasterPages/Dummy.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BPH" runat="server">
    <div id="divNormalPage" runat="server">
        <SMWC:SkinTextImageButton ID="BackTextImageButton" runat="server" ResourceIDGlobal="@Back"
            CssClass="ButtonBarImageButton" ImageFile="Icons/previous.png" />
        <SMWC:SkinTextImageButton ID="NextTextImageButton" runat="server" ResourceIDGlobal="@Next"
            CssClass="ButtonBarImageButton" ImageFile="Icons/Next.png" />
        <SMWC:SkinTextImageButton ID="SaveTextImageButton" runat="server" ResourceIDGlobal="@Save"
            CssClass="ButtonBarImageButton" ImageFile="Icons/Save.png" />
    </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MPH" runat="server">
    <table>
        <tr>
            <td class="SettingsLabel">
                <asp:Label runat="server" ID="lblProgress"></asp:Label>
            </td>
        </tr>
    </table>
    <table class="TabStripContent" runat="server" id="tblWelcome">
        <tr>
            <td class="SettingsHeader" colspan="2">
                <STWC:GlobalizedLabel runat="server" ResourceIDPage="Welcome" EnableViewState="False"
                    Auto="False" ID="Globalizedlabel17" />
            </td>
        </tr>
        <tr>
            <td class="SettingsSettingSingleInd" colspan="2">
                <STWC:GlobalizedLabel runat="server" Auto="False" ID="lblWelcomeMessage" />
            </td>
        </tr>
    </table>
    <table class="TabStripContent" runat="server" id="tblPage1">
        <tr>
            <td class="SettingsHeader" colspan="2">
                <STWC:GlobalizedLabel runat="server" ResourceIDPage="WebMailSettings" EnableViewState="False"
                    Auto="False" ID="Globalizedlabel12" />
            </td>
        </tr>
        <tr><td class="SettingsLabelInd">
                <STWC:GLOBALIZEDLABEL id="GLOBALIZEDLABEL2" runat="server" ResourceIDPage="TimeZone"></STWC:GLOBALIZEDLABEL>
            </td>
            <td class="SettingsSetting">
                <asp:dropdownlist id="ddTimeZone" runat="server"></asp:dropdownlist>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td colspan="2">
                <asp:TextBox runat="server" ID="txtPageNumber" Visible="false"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>