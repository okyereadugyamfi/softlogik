<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmFolder.aspx.cs" Inherits="SMWeb05.Main.frmFolder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="SaveTextImageButton" runat="server" ResourceIDGlobal="@Save" ImageFile="Icons/Save.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="CancelTextImageButton" runat="server" NavigateURL="frmFolders.aspx" ImageFile="Icons/Cancel_close.png" CssClass="ButtonBarImageButton" ResourceIDGlobal="@Cancel"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">

	<script type="text/javascript">
	function SaveFolder()
	{
		__doPostBack('<%= SaveTextImageButton.UniqueID %>','');
	}
	</script>

	<table class="SettingsContent">
		<tr>
			<td>
				<div class="SettingsNote">
					<STWC:GlobalizedLabel ID="Globalizedlabel5" runat="server" ResourceIDPage="NoteBody"></STWC:GlobalizedLabel>
				</div>
			</td>
		</tr>
	</table>
	<table class="SettingsContent">
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel ResourceIDPage="FolderName" ID="Globalizedlabel1" runat="server"></STWC:GlobalizedLabel>
			</td>
			<td class="SettingsSetting">
				<STWC:ValidatedTextBox ID="txtFolderName" onKeyPress="return EnterHandler(event,SaveFolder);" Description="Folder Name" runat="server" Columns="30" CheckInvalidChars="True"></STWC:ValidatedTextBox>
			</td>
		</tr>
	</table>
</asp:Content>

