<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmMyShares.aspx.cs" Inherits="SMWeb05.Main.Sharing.frmMyShares"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnShowHideSearchBar" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Search.gif" ResourceIDGlobal="@Search" NavigateURL="javascript: void(0)"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnCancel" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/back.png" ResourceIDGlobal="@Back"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MPH" runat="server">
	<div class="searchbar" runat="server" id="trSearchBar">
		<STWC:GlobalizedLabel ID="lblSearch" runat="server" ResourceIDGlobal="@Search" />&nbsp;
		<asp:TextBox ID="txtSearchString" runat="server"></asp:TextBox>&nbsp;<asp:DropDownList ID="ddSearchType" runat="server" />
		<SMWC:SkinTextImageButton ID="btnGo" Visible="false" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Search.gif" ResourceIDGlobal="@Go" />&nbsp;
		<a class="searchbar" href="#" onclick="javascript: __doPostBack('<%= btnGo.UniqueID %>','');">
			<STWC:GlobalizedLabel ID="Globalizedlabel1" runat="server" ResourceIDGlobal="@FindNow" />&nbsp;</a>
	</div>
	
	<STWC:HoverGrid ID="dgMappedFolders" runat="server" HG_EditURLField="editURL" HG_ColumnExclusionIndexes="3" HG_StandardSettings="True" HG_HoverEnabled="True" Width="100%" AutoGenerateColumns="False" AllowSorting="True" HG_HoverMessageResourceKey="@CanNotEditItem">
		<PagerStyle HorizontalAlign="Right" CssClass="pager" Mode="NumericPages"></PagerStyle>
		<Columns>
			<asp:BoundColumn DataField="icon">
				<headerstyle wrap="False" width="1%"></headerstyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="Owner">
				<headerstyle wrap="False"></headerstyle>
				<itemstyle wrap="False"></itemstyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="ResourceName">
				<headerstyle wrap="False"></headerstyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="ResourceType">
				<headerstyle wrap="False"></headerstyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="AttachLink">
				<headerstyle wrap="False"></headerstyle>
				<itemstyle horizontalalign="Right"></itemstyle>
			</asp:BoundColumn>
			<asp:BoundColumn Visible="False" DataField="FriendlyName">
				<headerstyle wrap="False"></headerstyle>
			</asp:BoundColumn>
			<asp:BoundColumn Visible="False" DataField="Access">
				<headerstyle wrap="False"></headerstyle>
			</asp:BoundColumn>
		</Columns>
	</STWC:HoverGrid>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="NavPH" runat="server">
	<asp:Label ID="NavigationLabel" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="CntPH" runat="server">
	<asp:Label ID="CounterLabel" runat="server"></asp:Label>
</asp:Content>

