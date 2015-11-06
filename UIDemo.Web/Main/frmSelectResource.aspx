<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="true" Codebehind="frmSelectResource.aspx.cs" Inherits="SMWeb05.Main.frmSelectResource" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
<SMWC:SkinTextImageButton ID="btnSave" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Next.png" ResourceIDGlobal="@Next" OnClick="btnSave_Click"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MPH" runat="server">
	<table class="SettingsContent">
		<tr>
			<td class="SettingsHeader" colspan="2">
				<STWC:GlobalizedLabel ID="GlobalizedLabel1" runat="server" ResourceIDPage="ItemsToShare" />
			</td>
		</tr>
		<tr>
			<td id="tdContacts" runat="server" class="SettingsSettingSingleInd">
				<STWC:GlobalizedRadioButton ID="radContacts" GroupName="ItemToShare" runat="server" ResourceIDPage="MyContacts" />
			</td>
		</tr>
		<tr>
			<td id="tdCalendars" runat="server" class="SettingsSettingSingleInd">
				<STWC:GlobalizedRadioButton ID="radCals" GroupName="ItemToShare" runat="server" ResourceIDPage="MyCalendar" />
			</td>
		</tr>
		<tr>
			<td id="tdTasks" runat="server" class="SettingsSettingSingleInd">
				<STWC:GlobalizedRadioButton ID="radTasks" GroupName="ItemToShare" runat="server" ResourceIDPage="MyTasks" />
			</td>
		</tr>
		<tr>
			<td id="tdNotes" runat="server" class="SettingsSettingSingleInd">
				<STWC:GlobalizedRadioButton ID="radNotes" GroupName="ItemToShare" runat="server" ResourceIDPage="MyNotes" />
			</td>
		</tr>
		<tr>
			<td id="tdFolders" runat="server" class="SettingsSettingSingleInd">
				<STWC:GlobalizedRadioButton ID="radFolders" GroupName="ItemToShare" runat="server" ResourceIDPage="Folder" />&nbsp;
				<asp:DropDownList ID="ddFolders" runat="server" />
			</td>
		</tr>
	</table>
</asp:Content>

