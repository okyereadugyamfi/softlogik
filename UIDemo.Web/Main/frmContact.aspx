<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmContact.aspx.cs" Inherits="SMWeb05.Main.frmContact"  %>

<%@ Register TagPrefix="uc1" TagName="ContactInfo" Src="../UserControls/ContactInfo.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnSave" runat="server" ResourceIDGlobal="@Save" ImageFile="Icons/Save.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="btnDownloadVCard" runat="server" CssClass="ButtonBarImageButton" ImageFile="Tree/Contacts.gif" ResourceIDGlobal="@DownloadVCard"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="btnManageCategories" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/masterCatagories.png" ResourceIDGlobal="@MasterCategories" NavigateURL="javascript:OpenMasterCategoriesPopup()"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnCancel" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Cancel_close.png" ResourceIDGlobal="@Cancel"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">

	<script type="text/javascript">
			<!--
			
			function OpenMasterCategoriesPopup()
			{
				var popurl="frmPopupContactCategories.aspx";
				winpops=window.open(popurl,"categorywindow","width=450,height=270,resizable=yes");
			}
			
			-->		
	</script>

	<uc1:ContactInfo ID="wucContactInfo" runat="server"></uc1:ContactInfo>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="NavPH" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="CntPH" runat="server">
</asp:Content>

