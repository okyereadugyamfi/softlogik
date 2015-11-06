<%@ Control Language="C#" AutoEventWireup="false" Codebehind="FileUploader.ascx.cs" Inherits="SMWeb05.UserControls.FileUploader" %>
<table class="SettingsContent">
	<tr id="trNote" runat="server">
		<td colspan="2">
			<div class="SettingsNote">
				<asp:Label ID="lblNoteText" runat="server"></asp:Label>
			</div>
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			<asp:Label ID="lblLocalFilePath" runat="server"></asp:Label>
		</td>
		<td class="SettingsSetting">
			<input id="FilePath" type="file" size="50" name="FilePath" runat="server" /><br />
			<asp:Label ID="lblMaxUploadSize" runat="server"></asp:Label>
		</td>
	</tr>
</table>
