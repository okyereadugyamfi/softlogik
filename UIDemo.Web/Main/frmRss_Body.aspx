<%@ Page Language="C#" AutoEventWireup="false" Codebehind="frmRss_Body.aspx.cs" Inherits="SMWeb05.Main.frmRss_Body" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<table class="SettingsContent">
				<tr>
					<td class="SettingsSettingSingle">
						<div class="RSSTitle">
							<asp:Literal ID="litTitle" runat="server" />
						</div>
						<div class="RSSDesc">
							<asp:Literal ID="litDesc" runat="server" />
						</div>
						<br />
						<div class="RSSSubject">
							<asp:Literal ID="litSub" runat="server" />
						</div>
						<div class="RSSDate">
							<asp:Literal ID="litDate" runat="server" />
						</div>
						<br />
						<div class="RSSArticle">
							<asp:Literal ID="litArticle" runat="server" />
						</div>
					</td>
				</tr>
			</table>
		</div>
	</form>
</body>
</html>
