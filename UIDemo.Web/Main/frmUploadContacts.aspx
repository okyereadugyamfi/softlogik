<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmUploadContacts.aspx.cs" Inherits="SMWeb05.Main.frmUploadContacts"  %>

<%@ Register TagPrefix="uc1" TagName="FileUploader" Src="../UserControls/FileUploader.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnOK" runat="server" ResourceIDGlobal="@OK" ImageFile="Icons/OK.png" CssClass="ButtonBarImageButton" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnCancel" runat="server" ResourceIDGlobal="@Cancel" ImageFile="Icons/Cancel_close.png" CssClass="ButtonBarImageButton" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">
	<uc1:FileUploader ID="Uploader" runat="server"></uc1:FileUploader>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="NavPH" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="CntPH" runat="server">
</asp:Content>

