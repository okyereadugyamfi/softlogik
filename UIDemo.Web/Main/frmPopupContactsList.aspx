<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmPopupContactsList.aspx.cs" Inherits="SMWeb05.Main.frmPopupContactsList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="OKImageButton" runat="server" ResourceIDGlobal="@OK" ImageFile="Icons/Save.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="CancelTextImageButton" runat="server" ImageFile="Icons/Cancel_close.png" CssClass="ButtonBarImageButton" ResourceIDGlobal="@Cancel"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MPH" runat="server">

	<script type="text/javascript">
		<!--
		function okclick()
		{
			frames['contactListFrame'].document.getElementById('frmContactList').doit.value=true;
			frames['contactListFrame'].document.getElementById('frmContactList').submit();
		}
		-->
	</script>

	<table class="Container">
		<tr>
			<td class="Container">
				<iframe runat="server" name="contactListFrame" id="contactListFrame" src="frmPopupContactsListInner.aspx?contactList=mycontacts" frameborder="0" style="width: 100%; height: 100%;" width="100%" height="100%" scrolling="yes"></iframe>
			</td>
		</tr>
	</table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FPH" runat="server">
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	<STWC:GlobalizedLabel runat="server" ResourceIDPage="ContactLists" EnableViewState="False" Auto="False" ID="Globalizedlabel2" name="Globalizedlabel2">
	</STWC:GlobalizedLabel>
	<asp:DropDownList runat="server" ID="cmboContactLists" AutoPostBack="True">
	</asp:DropDownList>
</asp:Content>

