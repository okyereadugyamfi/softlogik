<%@ Page Language="C#" AutoEventWireup="true" Codebehind="frmAbout.aspx.cs" Inherits="SMWeb05.About.frmAbout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 10px 20px 10px 20px;">
            <p style="font: 10pt Tahoma, arial; color: #555555;">
                <asp:Literal runat="server" ID="ProductName"></asp:Literal>
                <STWC:GlobalizedLabel ID="Globalizedlabel4" runat="server" ResourceIDPage="Version"></STWC:GlobalizedLabel>
                <asp:Literal runat="server" ID="ProductVersion"></asp:Literal></p>
            <p style="font: 8pt arial; color: #555555;">
                <STWC:GlobalizedLabel ID="GlobalizedLabel1" runat="server" ResourceIDGlobal="@Copyright1"></STWC:GlobalizedLabel>
                <STWC:GlobalizedLabel ID="Globalizedlabel2" runat="server" ResourceIDGlobal="@Copyright2"></STWC:GlobalizedLabel>
            </p>
<%--            <p style="font: 8pt arial; color: #555555; text-align: justify">
                Portions of SmarterMail may use the following components: <strong>Nevron Chart</strong>
                &copy; 1998-2004 Nevron LLC. All rights reserved. <strong>R.a.d.controls</strong>
                &copy; 2002-2006, telerik. All Rights Reserved. <strong>PowerTCP Sockets for .Net</strong>
                &copy; 2003 Dart Communications. All Rights Reserved. <strong>ClamAV/SOSDG</strong>,
                a Windows build of Clam AntiVirus&tm;, maintained by Bri Bruns (bruns@2mbit.com),
                published under the terms of the GNU General Public License version 2 as published
                by the Free Software Foundation. <strong>SpamAssassin</strong> &copy; 2004 Apache Software Foundation (spamassassin.apache.org).
            </p>--%>
            <p style="font: 10pt arial; color: #555555;">
                <a runat="server" id="STLink" target="_blank" href="http://www.smartertools.com">http://www.smartertools.com</a></p>
        </div>
    </form>
</body>
</html>
