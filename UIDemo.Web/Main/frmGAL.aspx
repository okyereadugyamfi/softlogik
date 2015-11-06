<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmGAL.aspx.cs" Inherits="SMWeb05.Main.frmGAL"  %>

<%@ Register Assembly="RadMenu.Net2" Namespace="Telerik.WebControls" TagPrefix="radM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<radM:RadMenu EnableViewState="False" ID="ActionsMenu" runat="server" OnItemClick="RadMenu1_ItemClick">
		<Items>
			<radM:RadMenuItem runat="server" Text="@Action" ImageUrl="Images/Icons/action.png">
				<Items>
					<radM:RadMenuItem runat="server" Text="#MENU_Contacts_ExportAll" Value="ExportAll">
					</radM:RadMenuItem>
					<radM:RadMenuItem runat="server" Text="#MENU_Contacts_Export" Value="Export">
					</radM:RadMenuItem>
					<radM:RadMenuItem runat="server" Text="#MENU_Contacts_NewMessage" Value="NewMessage">
					</radM:RadMenuItem>
				</Items>
			</radM:RadMenuItem>
		</Items>
	</radM:RadMenu>
	<SMWC:SkinTextImageButton ID="OutlookButton" runat="server" ResourceIDGlobal="@AddToOutlook" ImageFile="Icons/Upload.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="btnShowHideSearchBar" runat="server" ImageFile="Icons/Search.png" CssClass="ButtonBarImageButton" ResourceIDGlobal="@Search" NavigateURL="javascript: void(0)"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">

	<script type="text/javascript">
		<!--
		function OpenPopup(type,name,shareowner,calname)
		{
			var popurl="frmPopupAddToOutlook.aspx?type=" + type + "&name=" + name + "&shareowner=" + shareowner + "&calname=" + calname;
			winpops=window.open(popurl,"popupwindow","width=450,height=197,scrollbars,resizable=yes")
		}
		-->
	</script>

	<div class="searchbar" id="trSearchBar" runat="server">
		<STWC:GlobalizedLabel ID="lblSearch" runat="server" ResourceIDGlobal="@Search"></STWC:GlobalizedLabel>&nbsp;
		<asp:TextBox ID="txtSearchString" runat="server"></asp:TextBox>
		&nbsp;<asp:DropDownList ID="ddSearchType" runat="server" />
		<SMWC:SkinTextImageButton ID="btnGo" Visible="false" runat="server" ImageFile="Icons/Search.png" CssClass="ButtonBarImageButton" ResourceIDGlobal="@Go"></SMWC:SkinTextImageButton>
		<a class="searchbar" href="#" onclick="javascript: __doPostBack('<%= btnGo.UniqueID %>','');">
			<STWC:GlobalizedLabel ID="Globalizedlabel1" runat="server" ResourceIDGlobal="@FindNow"></STWC:GlobalizedLabel>&nbsp;</a>
	</div>
	<div class="sharebar" id="trShareInfo" runat="server">
		<asp:Literal runat="server" ID="ShareLiteral"></asp:Literal>
	</div>
	<STWC:HoverGrid ID="HoverGridMain" runat="server" HG_EditURLField="editURL" HG_ColumnExclusionIndexes="0,3,4" HG_StandardSettings="True" HG_HoverEnabled="True" Width="100%" AutoGenerateColumns="False" AllowSorting="True">
		<PagerStyle HorizontalAlign="Right" CssClass="pager" Mode="NumericPages"></PagerStyle>
		<Columns>
			<asp:BoundColumn DataField="Checkboxes">
				<headerstyle width="1%"></headerstyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="fullName" SortExpression="fullName" HeaderText="@FullName"></asp:BoundColumn>
			<asp:BoundColumn DataField="Email"></asp:BoundColumn>
			<asp:TemplateColumn>
				<itemstyle wrap="False" horizontalalign="Right" width="1%"></itemstyle>
				<itemtemplate><%# DataBinder.Eval(Container.DataItem, "newemaillink") %>&nbsp;</itemtemplate>
			</asp:TemplateColumn>
		</Columns>
	</STWC:HoverGrid>
</asp:Content>

