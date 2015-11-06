<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmPopupUserList.aspx.cs" Inherits="SMWeb05.Main.frmPopupUserList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="OKImageButton" runat="server" ResourceIDGlobal="@OK" ImageFile="Icons/Save.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="CancelTextImageButton" runat="server" ImageFile="Icons/Cancel_close.png" CssClass="ButtonBarImageButton" ResourceIDGlobal="@Cancel"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MPH" runat="server">

	<script type="text/javascript">
		<!--
		function SetChecked(val, chkName) 
		{
			dml = document.forms['aspnetForm'];
			len = dml.elements.length;
			for( var i = 0; i < len; i++) 
			{
				if (dml.elements[i].name!=chkName) 
				{
					dml.elements[i].checked=val;
				}
			}
		}
		function okclick()
		{
			document.aspnetForm.doit.value=true;
			document.aspnetForm.submit();
		}
		// -->
	</script>

	<STWC:HoverGrid ID="HoverGridResults" ShowFooter="true" AllowSorting="True" AutoGenerateColumns="False" runat="server" Width="100%" HG_HoverEnabled="True" HG_StandardSettings="True" HG_HoverMessageResourceKey="@CanNotEditItem" HG_ColumnExclusionIndexes="0,1,2">
		<PagerStyle HorizontalAlign="Right" CssClass="pager" Mode="NumericPages"></PagerStyle>
		<Columns>
			<asp:TemplateColumn>
				<itemstyle horizontalalign="Left" width="10px"></itemstyle>
				<itemtemplate><asp:CheckBox Runat="server" ID="chk1"></asp:CheckBox></itemtemplate>
			</asp:TemplateColumn>
			<asp:BoundColumn DataField="fullName" SortExpression="fullName" HeaderText="@FullName" DataFormatString="&#160;{0}"></asp:BoundColumn>
			<asp:BoundColumn DataField="email" SortExpression="email" HeaderText="@EmailAddress"></asp:BoundColumn>
		</Columns>
	</STWC:HoverGrid>
	<asp:LinkButton Visible="False" runat="server" ID="btnSubmit" CssClass="button">@ok</asp:LinkButton>
	<input type="hidden" name="doit">
</asp:Content>