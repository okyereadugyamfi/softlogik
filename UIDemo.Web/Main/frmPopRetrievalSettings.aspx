<%@ Page Language="C#" AutoEventWireup="false" Codebehind="frmPopRetrievalSettings.aspx.cs" Inherits="SMWeb05.Main.frmPopRetrievalSettings" MasterPageFile="~/MasterPages/Dummy.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="SaveTextImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Save.png" ResourceIDGlobal="@Save" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnCancel" runat="server" ResourceIDGlobal="@Cancel" ImageFile="Icons/Cancel_close.png" CssClass="ButtonBarImageButton" NavigateURL="frmPopRetrievalList.aspx" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MPH" runat="server">
	<table class="SettingsContent" runat="server" id="tblPopRetrievalSettings">
		<tr>
			<td class="SettingsHeader" colspan="2">
				<STWC:GlobalizedLabel ID="Globalizedlabel15" runat="server" ResourceIDGlobal="@Options" />
			</td>
		</tr>
		<tr>
			<td>
				&nbsp;</td>
		</tr>
		<tr>
			<td class="SettingsLabelInd">
				<STWC:GlobalizedLabel ID="Globalizedlabel1" runat="server" ResourceIDPage="ServerAddress" />
			</td>
			<td class="SettingsSetting">
				<asp:TextBox runat="server" ID="txtServerAddress" Columns="30"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td class="SettingsLabelInd">
				<STWC:GlobalizedLabel ID="Globalizedlabel3" runat="server" ResourceIDGlobal="@Port" />
			</td>
			<td class="SettingsSetting">
				<asp:TextBox runat="server" ID="txtPort" Columns="5" Text="110"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td class="SettingsLabelInd">
				<STWC:GlobalizedLabel ID="Globalizedlabel2" runat="server" ResourceIDGlobal="@Username" />
			</td>
			<td class="SettingsSetting">
				<asp:TextBox runat="server" ID="txtUserName" Columns="30"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td class="SettingsLabelInd">
				<STWC:GlobalizedLabel ID="Globalizedlabel4" runat="server" />
			</td>
			<td class="SettingsSetting">
				<asp:TextBox runat="server" ID="txtPassword" Columns="30" TextMode="Password"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td class="SettingsLabelInd">
				<STWC:GlobalizedLabel runat="server" ResourceIDGlobal="@Options" EnableViewState="False" Auto="False" ID="Globalizedlabel5" />
			</td>
			<td class="SettingsSetting">
				<asp:CheckBox runat="server" ID="chkApopAuthentication" Text="$UseApopAuthentication"></asp:CheckBox>
			</td>
		</tr>
		<tr>
			<td class="SettingsLabelInd">
			</td>
			<td class="SettingsSetting">
				<asp:CheckBox runat="server" ID="chkLeaveMessageOnServer" Text="$LeaveMessageOnServer"></asp:CheckBox>
			</td>
		</tr>
		<tr>
			<td class="SettingsLabelInd">
			</td>
			<td class="SettingsSetting">
				<STWC:GlobalizedCheckbox runat="server" ID="chkUseSSL" ResourceIDPage="UseSSL" />
			</td>
		</tr>
		<tr>
			<td>
				&nbsp;</td>
		</tr>
		<tr>
			<td class="SettingsLabelInd">
				<STWC:GlobalizedLabel ID="GlobalizedLabel6" runat="server" ResourceIDPage="DownloadToFolder" />
			</td>
			<td class="SettingsSetting">
				<asp:DropDownList ID="lstFolders" runat="server" />
			</td>
		</tr>
	</table>
</asp:Content>

