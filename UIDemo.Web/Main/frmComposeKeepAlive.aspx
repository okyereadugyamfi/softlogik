<%@ Page Language="C#" AutoEventWireup="false" Codebehind="frmComposeKeepAlive.aspx.cs" Inherits="SMWeb05.Main.frmComposeKeepAlive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
	<meta http-equiv="refresh" content="70" />
	<meta http-equiv="expires" content="0" />

	<script type="text/javascript">
		var i = Math.round(100000*Math.random())
		var sURL = unescape(window.location.pathname) + "?r=" + i;
		function doLoad()
		{
			setTimeout("refresh()", 60000);
		}
		function refresh()
		{
			window.location.href = sURL;
		}
	</script>

</head>
<body onload="doLoad()">
	<asp:Label ID="lblContent" runat="Server"></asp:Label>
</body>
</html>
