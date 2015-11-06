<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmFolderRename.aspx.cs" Inherits="SMWeb05.Main.frmFolderRename"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="SaveTextImageButton" runat="server" ResourceIDGlobal="@Save" ImageFile="Icons/Save.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="CancelTextImageButton" runat="server" ImageFile="Icons/Cancel_close.png" CssClass="ButtonBarImageButton" ResourceIDGlobal="@Cancel" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">
	<table class="SettingsContent">
		<tr>
			<td>
				<div class="SettingsNote">
					<STWC:GlobalizedLabel ID="Globalizedlabel5" runat="server" ResourceIDPage="NoteBody"></STWC:GlobalizedLabel>
					<STWC:GlobalizedLabel ID="lblRenameSharedWarning" runat="server" ResourceIDPage="RenameSharedWarning"></STWC:GlobalizedLabel>
				</div>
			</td>
		</tr>
	</table>
	<table class="SettingsContent">
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel ResourceIDPage="OldName" ID="Globalizedlabel2" runat="server"></STWC:GlobalizedLabel>
			</td>
			<td class="SettingsSetting">
				<asp:Label runat="server" ID="lblOldFolderName"></asp:Label>
			</td>
		</tr>
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel ResourceIDPage="NewName" ID="Globalizedlabel1" runat="server"></STWC:GlobalizedLabel>
			</td>
			<td class="SettingsSetting">
				<STWC:ValidatedTextBox CssClass="fullw" Description="New Folder Name" ID="txtFolderName" runat="server" Width="100%" CheckInvalidChars="True"></STWC:ValidatedTextBox>
			</td>
		</tr>
	</table>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="NavPH" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="CntPH" runat="server">
</asp:Content>

