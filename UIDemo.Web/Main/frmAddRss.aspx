<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmAddRss.aspx.cs" Inherits="SMWeb05.Main.frmAddRss"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="SaveNewFeed" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Save.png" ResourceIDGlobal="@Save" OnClick="SaveNewFeed_Click"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="DeleteImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Cancel_close.png" ResourceIDGlobal="@DeleteCap" OnClick="DeleteImageButton_Click"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="CancelTextImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Cancel_close.png" ResourceIDGlobal="@Cancel"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MPH" runat="server">
	<table class="SettingsContent">
		<tr>
			<td>
				<div class="SettingsNote">
					<STWC:GlobalizedLabel ID="Globalizedlabel4" runat="server" ResourceIDPage="SubFolder"></STWC:GlobalizedLabel>
				</div>
			</td>
		</tr>
	</table>
	<table class="SettingsContent">
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel ID="Globalizedlabel1" runat="server" ResourceIDGlobal="@Name"></STWC:GlobalizedLabel>
			</td>
			<td class="SettingsSetting">
				<asp:TextBox ID="NewFeedName" columns="30" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td class="SettingsLabel">
				<asp:RadioButton ID="RadioNew" runat="server" Visible="False" GroupName="RSSAddFeed" AutoPostBack="False" Text="$NewFeed" Checked="True"></asp:RadioButton><STWC:GlobalizedLabel ID="GLOBALIZEDLABEL6" runat="server" ResourceIDPage="URL" NAME="Globalizedlabel1"></STWC:GlobalizedLabel>
			</td>
			<td class="SettingsSetting">
				<asp:TextBox ID="NewFeedURL" columns="30" runat="server">http://</asp:TextBox>
			</td>
		</tr>
	</table>
</asp:Content>

