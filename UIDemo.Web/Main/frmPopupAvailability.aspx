<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmPopupAvailability.aspx.cs" Inherits="SMWeb05.Main.frmPopupAvailability" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="OKImageButton" runat="server" NavigateURL="javascript:window.close();" ResourceIDGlobal="@OK" ImageFile="Icons/Save.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="PreviousDate" runat="server" ImageFile="Icons/previous.png" CssClass="ButtonBarImageButton" ResourceIDPage="PreviousDay"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="NextDate" runat="server" ImageFile="Icons/next.png" CssClass="ButtonBarImageButton" ResourceIDPage="NextDay"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">
	<table class="Container">
		<tr>
			<td class="SettingsHeader">
				<STWC:GlobalizedLabel ID="Globalizedlabel2" runat="server" ResourceIDPage="AvailabilityInformation"></STWC:GlobalizedLabel>
				-
				<asp:Literal ID="DateLiteral" runat="server"></asp:Literal>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Literal ID="ImageLiteral" runat="server"></asp:Literal>
			</td>
		</tr>
	</table>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FPH" runat="server">
</asp:Content>

