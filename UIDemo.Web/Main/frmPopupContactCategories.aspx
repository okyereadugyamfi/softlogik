<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmPopupContactCategories.aspx.cs" Inherits="SMWeb05.Main.frmPopupContactCategories" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="OKImageButton" runat="server" ResourceIDGlobal="@OK" ImageFile="Icons/Save.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="CancelTextImageButton" runat="server" ImageFile="Icons/Cancel_close.png" CssClass="ButtonBarImageButton" ResourceIDGlobal="@Cancel"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">

	<script language="javascript">
		<!--
		function okclick()
		{
			top.opener.__doPostBack('frmPopupMasterCategories','');
			window.close();
		}
		-->
	</script>

	<table class="TabStripContent">
		<tr>
			<td class="SettingsSettingSingle">
				<STWC:GlobalizedLabel runat="server" ResourceIDGlobal="@Categories" EnableViewState="False" Auto="False" ID="Globalizedlabel2" name="Globalizedlabel2"></STWC:GlobalizedLabel><br />
				<asp:TextBox runat="server" ID="txtCategories" width="100%" Rows="8" TextMode="MultiLine"></asp:TextBox>
			</td>
		</tr>
	</table>
	<asp:Label runat="server" ID="lblScript"></asp:Label>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FPH" runat="server">
</asp:Content>

