<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmContacts.aspx.cs" Inherits="SMWeb05.Main.frmContacts"  %>

<%@ Register Assembly="RadMenu.Net2" Namespace="Telerik.WebControls" TagPrefix="radM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<radM:RadMenu EnableViewState="False" ID="ActionsMenu" runat="server" OnItemClick="RadMenu1_ItemClick">
		<Items>
			<radM:RadMenuItem runat="server" Text="@Action" ImageUrl="Images/Icons/action.png">
				<Items>
					<radM:RadMenuItem id="menuDelete" runat="server" Text="#MENU_Contacts_Delete" ClientSideCommand="DeleteAllConfirm();" Value="Delete">
					</radM:RadMenuItem>
					<radM:RadMenuItem id="menuImport" runat="server" Text="#MENU_Contacts_Import" Value="Import">
					</radM:RadMenuItem>
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
	<SMWC:SkinTextImageButton ID="AddContactLabel" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/AddContact.png" ResourceIDGlobal="@AddContact"></SMWC:SkinTextImageButton>
	
	<SMWC:SkinTextImageButton ID="OutlookButton" runat="server" ResourceIDGlobal="@AddToOutlook" ImageFile="Icons/AddOutlook.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="btnShowHideSearchBar" runat="server" ImageFile="Icons/Search.png" CssClass="ButtonBarImageButton" ResourceIDGlobal="@Search" NavigateURL="javascript: void(0)"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<asp:DropDownList runat="server" ID="lstCategories" AutoPostBack="True">
	</asp:DropDownList>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">
	<asp:Literal ID="DeleteLiteral" runat="server"></asp:Literal>

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
		<asp:TextBox ID="txtSearchString" runat="server"></asp:TextBox>&nbsp;<asp:DropDownList ID="ddSearchType" runat="server" />
		<SMWC:SkinTextImageButton ID="btnGo" Visible="false" runat="server" ImageFile="Icons/Search.png" CssClass="ButtonBarImageButton" ResourceIDGlobal="@Go"></SMWC:SkinTextImageButton>
		&nbsp;<a class="searchbar" href="#" onclick="javascript: __doPostBack('<%= btnGo.UniqueID %>','');">
			<STWC:GlobalizedLabel ID="Globalizedlabel1" runat="server" ResourceIDGlobal="@FindNow"></STWC:GlobalizedLabel>&nbsp;</a>
	</div>
	<div class="sharebar" id="trShareInfo" runat="server">
		<asp:Literal runat="server" ID="ShareLiteral"></asp:Literal>
	</div>
	<STWC:HoverGrid ID="HoverGridMain" EnableViewState="false" OnPageIndexChanged="Grid_PageIndexChanged" AllowSorting="True" AutoGenerateColumns="False" runat="server" Width="100%" HG_HoverEnabled="True" ShowFooter="false" HG_StandardSettings="True" HG_ColumnExclusionIndexes="0,3,4" HG_EditURLField="editURL">
		<Columns>
			<asp:BoundColumn DataField="Checkboxes">
				<headerstyle width="1" wrap="false"></headerstyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="fullName" SortExpression="fullName" HeaderText="@FullName">
				<headerstyle wrap="false"></headerstyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="Email"></asp:BoundColumn>
			<asp:TemplateColumn>
				<itemstyle wrap="False" horizontalalign="Right" width="1%"></itemstyle>
				<itemtemplate><%# DataBinder.Eval(Container.DataItem, "newemaillink") %>&nbsp;</itemtemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn>
				<itemstyle horizontalalign="Right" width="1%"></itemstyle>
				<itemtemplate><%# DataBinder.Eval(Container.DataItem, "deletelink") %>&nbsp;</itemtemplate>
				<footerstyle wrap="False"></footerstyle>
			</asp:TemplateColumn>
		</Columns>
	</STWC:HoverGrid>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="NavPH" runat="server">
	<asp:Label ID="NavigationLabel" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="CntPH" runat="server">
	<asp:Label ID="CounterLabel" runat="server"></asp:Label>
</asp:Content>

