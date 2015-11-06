<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmMyInfo.aspx.cs" Inherits="SMWeb05.Main.frmMyInfo"  %>

<%@ Register TagPrefix="uc1" TagName="ContactInfo" Src="../UserControls/ContactInfo.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnSave" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Save.png" ResourceIDGlobal="@Save" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">
	<uc1:ContactInfo ID="wucContactInfo" runat="server"></uc1:ContactInfo>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="NavPH" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="CntPH" runat="server">
</asp:Content>

