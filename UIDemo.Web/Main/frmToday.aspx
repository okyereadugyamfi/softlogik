<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" Codebehind="frmToday.aspx.cs" Inherits="SMWeb05.Main.frmToday" AutoEventWireup="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MPH" runat="server">
	<div style="font: 12pt arial; padding-left: 14px; padding-top: 20px;">
		<asp:Literal runat="server" ID="CurrentDateLiteral"></asp:Literal>
	</div>
	<table cellpadding="10" cellspacing="0" border="0" width="100%">
		<tr>
			<td valign="top">
				<table cellpadding="4" cellspacing="0" border="0" width="100%">
					<tr runat="server" id="trCalendar">
						<td colspan="2" class="SettingsHeader">
							<STWC:GlobalizedLabel runat="server" ResourceIDGlobal="@Calendar" /></td>
					</tr>
					<asp:Literal runat="server" ID="CalendarBreakdownLiteral"></asp:Literal>
				</table>
				<br />
				<table cellpadding="4" cellspacing="0" border="0" width="100%">
					<tr>
						<td class="SettingsHeader" colspan="2">
							<STWC:GlobalizedLabel ID="GlobalizedLabel1" runat="server" ResourceIDPage="LatestRSS" /></td>
					</tr>
					<asp:Literal runat="server" ID="RSSLiteral"></asp:Literal>
				</table>
			</td>
			<td valign="top">
				<table cellpadding="4" cellspacing="0" border="0" width="100%">
					<tr>
						<td colspan="2" class="SettingsHeader">
							<STWC:GlobalizedLabel ID="GlobalizedLabel2" runat="server" ResourceIDGlobal="@UnreadMessages" /></td>
					</tr>
					<asp:Literal runat="server" ID="MessagesPlaceholder"></asp:Literal>
				</table>
				<br />
				<table cellpadding="4" cellspacing="0" border="0" width="100%">
					<tr>
						<td colspan="2" class="SettingsHeader">
							<STWC:GlobalizedLabel ID="GlobalizedLabel4" runat="server" ResourceIDPage="DiskSpaceLimits" /></td>
					</tr>
					<asp:Literal runat="server" ID="SpaceUsedPlaceholder"></asp:Literal>
					<tr>
						<td class="SettingsSettingSmallPadRight" colspan="2" align="right" style="text-align: right;">
							<a href="javascript:PurgeJunkEmail()">
								<STWC:GlobalizedLabel runat="server" ResourceIDPage="ClearJunkFolder" /></a></td>
					</tr>
				</table>
				<br />
				<table cellpadding="4" cellspacing="0" border="0" width="100%">
					<tr runat="server" id="trTasks">
						<td colspan="2" class="SettingsHeader">
							<STWC:GlobalizedLabel ID="GlobalizedLabel3" runat="server" ResourceIDGlobal="@Tasks" /></td>
					</tr>
					<asp:Literal runat="server" ID="TasksPlaceholder"></asp:Literal>
				</table>
			</td>
		</tr>
	</table>
</asp:Content>

