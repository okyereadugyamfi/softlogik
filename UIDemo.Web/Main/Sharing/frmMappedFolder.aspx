<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmMappedFolder.aspx.cs" Inherits="SMWeb05.Main.Sharing.frmMappedFolder"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnConnect" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/save.png" ResourceIDGlobal="@Save" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnCancel" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/cancel_close.png" ResourceIDGlobal="@Cancel" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MPH" runat="server">
	<table class="SettingsContent">
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel ID="lblFolderTypeLabel" runat="server" ResourceIDGlobal="@Resource"></STWC:GlobalizedLabel></td>
			<td class="SettingsSetting">
				<asp:Label ID="lblFolderType" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel ID="lblFolderUsernameLabel" runat="server" ResourceIDGlobal="@User"></STWC:GlobalizedLabel></td>
			<td class="SettingsSetting">
				<asp:Label ID="lblFolderUsername" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel ID="lblFolderOriginalNameLabel" runat="server" ResourceIDGlobal="@Folder"></STWC:GlobalizedLabel></td>
			<td class="SettingsSetting">
				<asp:Label ID="lblFolderOriginalName" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel ID="lblFolderAccessLabel" runat="server" ResourceIDPage="FolderAccess"></STWC:GlobalizedLabel></td>
			<td class="SettingsSetting">
				<asp:Label ID="lblFolderAccess" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel ID="lblFolderFriendlyNameLabel" runat="server" ResourceIDGlobal="@FriendlyName"></STWC:GlobalizedLabel></td>
			<td class="SettingsSetting">
				<asp:TextBox ID="txtFolderFriendlyName" runat="server" CssClass="fullw"></asp:TextBox></td>
		</tr>
	</table>
</asp:Content>

