<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkup.aspx.cs" Inherits="SMWeb05.About.Checkup" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>SmarterMail Self Diagnostic</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <h1>
            <img align="absMiddle" src="CheckUp.gif">
            SmarterMail Check-Up</h1>
        <hr />
        <h3>
            The results of the check-up are shown below:</h3>
        <asp:Label runat="server" ID="Results">
				<table cellpadding="0" cellspacing="0" border="1" width="90%" align="center" bgcolor="white">
					<tr>
						<td>
							<table cellpadding="5" cellspacing="0" border="0" width="100%" bgcolor="white">
								<tr bgcolor="navy">
									<td colspan="2" bgcolor="navy"><font color="white"><b>Version Checks</b></font></td>
								</tr>
								<tr>
									<td><font color="red">Failed&nbsp;&nbsp;</font></td>
									<td>Microsoft .Net Framework Mapping Test</td>
								</tr>
								<tr>
									<td></td>
									<td>
										Notes: ASP.Net or Microsoft.Net 2.0 is not functioning properly. For more 
										information regarding the Microsoft.Net Framework, see <a href="http://www.microsoft.com/net" target="_blank">
											http://www.microsoft.com/net</a>. To download and install the Microsoft.Net 
										Framework 2.0, use Windows Update.</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
				<h3>All other tests were skipped</h3>
        </asp:Label>
    </form>
</body>
</html>
