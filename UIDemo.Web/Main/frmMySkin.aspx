<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" CodeBehind="frmMySkin.aspx.cs" Inherits="SMWeb05.Main.frmMySkin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
    <SMWC:SkinTextImageButton ID="SaveTextImageButton" runat="server" ResourceIDGlobal="@Save" ImageFile="Icons/Save.png" CssClass="ButtonBarImageButton" OnClick="SaveTextImageButton_Click" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="MPH" runat="server">
	<table class="SettingsContent" id="tblSkinning" runat="server">
	    <tr>
		    <td class="SettingsLabel">
			    <STWC:GlobalizedLabel runat="server" ResourceIDGlobal="@Skin" EnableViewState="False" Auto="False" ID="Globalizedlabel8" />
		    </td>
		    <td class="SettingsSetting">
			    <asp:DropDownList runat="server" ID="lstSkins">
			    </asp:DropDownList>
		    </td>
	    </tr>
	</table>
</asp:Content>

