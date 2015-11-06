<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmPopupAddToOutlook.aspx.cs" Inherits="SMWeb05.Main.frmPopupAddToOutlook" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="OKImageButton" runat="server" ResourceIDGlobal="@OK" ImageFile="Icons/Save.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="CancelTextImageButton" runat="server" ImageFile="Icons/Cancel_close.png" CssClass="ButtonBarImageButton" ResourceIDGlobal="@Cancel"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MPH" runat="server">
	<table class="SettingsContent">
		<tr>
			<td class="SettingsHeader">
				<STWC:GlobalizedLabel ID="Globalizedlabel2" runat="server" name="Globalizedlabel1" ResourceIDPage="OutlookInformation"></STWC:GlobalizedLabel>
			</td>
		</tr>
		<tr>
			<td class="SettingsSettingSingle">
				<STWC:GlobalizedLabel runat="server" ResourceIDPage="AddExplanation" EnableViewState="False" Auto="False" ID="Globalizedlabel38"></STWC:GlobalizedLabel>
			</td>
		</tr>
	</table>
</asp:Content>

