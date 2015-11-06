<%@ Page Language="C#" AutoEventWireup="false" Codebehind="frmPopupContactsListInner.aspx.cs" Inherits="SMWeb05.Main.frmPopupContactsListInner" EnableTheming="true"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="frmContactList" name="frmContactList" method="post" runat="server">

		<script type="text/javascript">
			<!--
			function SetChecked(val, chkName) 
				{
					dml = document.forms['frmContactList'];
					len = dml.elements.length;
					for( var i = 0; i < len; i++) 
						if (dml.elements[i].name!=chkName) 
							dml.elements[i].checked=val;
				}
			-->
		</script>

		<STWC:HoverGrid ID="HoverGridResults" AllowSorting="True" AutoGenerateColumns="False" runat="server" Width="100%" HG_HoverEnabled="True" HG_StandardSettings="True" HG_HoverMessageResourceKey="@CanNotEditItem" HG_ColumnExclusionIndexes="0">
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
	</form>
</body>
</html>
