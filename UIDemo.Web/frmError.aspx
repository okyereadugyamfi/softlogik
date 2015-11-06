<%@ Page Language="C#" AutoEventWireup="false" Codebehind="frmError.aspx.cs" Inherits="SMWeb05.frmError" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<asp:Label runat="server" ID="lblPageName"></asp:Label><br />
			<asp:Label runat="server" ID="lblError"></asp:Label>
			<a class="button" href="javascript:history.back(1)">
				<STWC:GlobalizedLabel ResourceIDGlobal="@Back" ID="Globalizedlabel1" runat="server"></STWC:GlobalizedLabel></a>
		</div>
	</form>
</body>
</html>
