<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmContactMapping.aspx.cs" Inherits="SMWeb05.Main.frmContactMapping"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnContinue" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Next.png" ResourceIDGlobal="@Next"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">
<div id="tdMapFieldsContainer" runat="server"></div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="NavPH" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="CntPH" runat="server">
</asp:Content>

