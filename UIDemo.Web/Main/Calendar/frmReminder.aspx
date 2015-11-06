<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmReminder.aspx.cs" Inherits="SMWeb05.Main.Calendar.frmReminder" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="DismissImageButton" runat="server" ResourceIDPage="Dismiss" NavigateTarget="_self" ImageFile="Icons/trash.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="BackImageButton" runat="server" ResourceIDGlobal="@Back" NavigateTarget="_self" ImageFile="Icons/back.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MPH" runat="server">
	<table class="SettingsContent">
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel ID="Globalizedlabel5" runat="server" ResourceIDGlobal="@Subject"></STWC:GlobalizedLabel>
			</td>
			<td class="SettingsSetting">
				<asp:Label ID="EventSubjectLabel" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel ID="Globalizedlabel9" runat="server" ResourceIDPage="Attendees"></STWC:GlobalizedLabel>
			</td>
			<td class="SettingsSetting">
				<asp:Label ID="EventAttendeesLabel" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel ID="Globalizedlabel10" runat="server" ResourceIDPage="When"></STWC:GlobalizedLabel>
			</td>
			<td class="SettingsSetting">
				<asp:Label ID="EventWhenLabel" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel ID="Where" runat="server" ResourceIDPage="Where"></STWC:GlobalizedLabel>
			</td>
			<td class="SettingsSetting">
				<asp:Label ID="EventWhereLabel" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td class="SettingsSettingSingle" colspan="2">
				<br />
				<asp:Label ID="DescriptionLabel" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td class="SettingsSettingSingle" colspan="2">
			<br />
			<br />
				<asp:DropDownList ID="SnoozeDropDown" runat="server" />
				<SMWC:IconBarSeparator ID="IconBarSeparator1" runat="server"></SMWC:IconBarSeparator>
				<SMWC:SkinTextImageButton ID="SnoozeButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="icons/alias.gif" ResourceIDPage="Snooze"></SMWC:SkinTextImageButton>
			</td>
		</tr>
	</table>
</asp:Content>

