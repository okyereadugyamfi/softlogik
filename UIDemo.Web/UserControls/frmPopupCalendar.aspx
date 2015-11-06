<%@ Page Language="C#" AutoEventWireup="false" Codebehind="frmPopupCalendar.aspx.cs" Inherits="SMWeb05.UserControls.frmPopupCalendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>Untitled Page</title>
</head>
<body onload="focus();">
    <form id="Form1" method="post" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" width="100%" height="100%" class="calpage">
            <tr valign="top">
                <td>
                    <table width="100%" cellpadding="2" cellspacing="0" border="0" class="caltop">
                        <tr>
                            <td colspan="3" height="5">
                            </td>
                        </tr>
                        <tr valign="baseline">
                            <td align="left">
                                <asp:Label ID="lblPrevMonth" runat="server"><<</asp:Label></td>
                            <td align="center">
                                <asp:Label ID="Label1" Style="" runat="server" CssClass="caltop">Month, Year</asp:Label></td>
                            <td align="right">
                                <asp:Label ID="lblNextMonth" Style="" runat="server">>></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="3" height="5">
                            </td>
                        </tr>
                    </table>
                    <asp:Table ID="Table2" EnableViewState="false" runat="server" Width="100%" CssClass="calframe"
                        CellPadding="0" CellSpacing="0">
                        <asp:TableRow>
                            <asp:TableCell Width="35px" Text="Sun" CssClass="calweekday"></asp:TableCell>
                            <asp:TableCell Width="35px" Text="Mon" CssClass="calweekday"></asp:TableCell>
                            <asp:TableCell Width="35px" Text="Tue" CssClass="calweekday"></asp:TableCell>
                            <asp:TableCell Width="35px" Text="Wed" CssClass="calweekday"></asp:TableCell>
                            <asp:TableCell Width="35px" Text="Thu" CssClass="calweekday"></asp:TableCell>
                            <asp:TableCell Width="35px" Text="Fri" CssClass="calweekday"></asp:TableCell>
                            <asp:TableCell Width="35px" Text="Sat" CssClass="calweekday"></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow VerticalAlign="Middle">
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow VerticalAlign="Middle">
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow VerticalAlign="Middle">
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow VerticalAlign="Middle">
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow VerticalAlign="Middle">
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow VerticalAlign="Middle">
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Middle" Width="35px" CssClass="calday"></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
