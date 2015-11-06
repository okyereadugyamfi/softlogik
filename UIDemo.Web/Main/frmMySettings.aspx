<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmMySettings.aspx.cs" Inherits="SMWeb05.Main.frmMySettings" %>

<%@ Register TagPrefix="uc1" TagName="UserSettings" Src="../UserControls/UserSettings.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnSave" runat="server" ResourceIDGlobal="@Save" ImageFile="Icons/Save.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="btnShowPassword" runat="server" ImageFile="Icons/Login.gif" CssClass="ButtonBarImageButton" ResourceIDPage="PWShow"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MPH" runat="server">
	<uc1:UserSettings ID="wucUserSettings" runat="server"></uc1:UserSettings><br />
</asp:Content>

