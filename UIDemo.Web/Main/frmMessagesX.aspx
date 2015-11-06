<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" EnableEventValidation="false" AutoEventWireup="false" Codebehind="frmMessagesX.aspx.cs" Inherits="SMWeb05.Main.frmMessagesX" EnableTheming="true" %>

<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="radA" %>
<%@ Register Assembly="RadGrid.Net2" Namespace="Telerik.WebControls" TagPrefix="radG" %>
<%@ Register Assembly="RadMenu.Net2" Namespace="Telerik.WebControls" TagPrefix="radM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<table class="TwoCellButtonBar" style="width: auto;">
		<tr>
			<td style="padding: 0px;">
				<radM:RadMenu EnableViewState="false" ID="MoveMenu" runat="server">
					<Items>
						<radM:RadMenuItem ID="RadMenuItem1" runat="server" Text="@Action" ImageUrl="Images/Icons/Action.png">
							<Items>
								<radM:RadMenuItem ID="RadMenuItem2" runat="server" Text="$Delete" ClientSideCommand="DeleteChecked();">
								</radM:RadMenuItem>
								<radM:RadMenuItem ID="RadMenuItem3" runat="server" Text="$Undelete" ClientSideCommand="UndeleteChecked();">
								</radM:RadMenuItem>
								<radM:RadMenuItem ID="RadMenuItem4" runat="server" Text="$MarkRead" ClientSideCommand="MarkRead();">
								</radM:RadMenuItem>
								<radM:RadMenuItem ID="RadMenuItem5" runat="server" Text="$MarkUnread" ClientSideCommand="UnmarkRead();">
								</radM:RadMenuItem>
								<radM:RadMenuItem ID="RadMenuItem6" runat="server" Text="$MarkSpam" ClientSideCommand="MarkSpam();">
								</radM:RadMenuItem>
								<radM:RadMenuItem ID="RadMenuItem7" runat="server" Text="$UnmarkSpam" ClientSideCommand="UnmarkSpam();">
								</radM:RadMenuItem>
								<radM:RadMenuItem ID="RadMenuItem8" runat="server" Text="$Purge" ClientSideCommand="Purge();">
								</radM:RadMenuItem>
								<radM:RadMenuItem ID="RadMenuItem9" runat="server" Text="$DeleteAll" ClientSideCommand="DeleteAll();">
								</radM:RadMenuItem>
								<radM:RadMenuItem ID="RadMenuItem10" runat="server" Text="$OpenNew" ClientSideCommand="OpenNew();">
								</radM:RadMenuItem>
							</Items>
						</radM:RadMenuItem>
						<radM:RadMenuItem ID="MoveTo" runat="server" Text="@Action" ImageUrl="Images/Icons/MoveTo.png">
							<Items>
							</Items>
						</radM:RadMenuItem>
					</Items>
				</radM:RadMenu>
			</td>
			<td style="padding: 0px;">
				<SMWC:SkinTextImageButton ID="btnShowHideSearchBar" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Search.png" ResourceIDGlobal="@Search" NavigateURL="javascript: SearchToggle()"></SMWC:SkinTextImageButton>
			</td>
		</tr>
	</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<table class="TwoCellButtonBar" style="width: auto" align="right">
		<tr>
			<td class="UsageGraph">
				<asp:Literal ID="UsageGraphLiteral" runat="server"></asp:Literal>
			</td>
			<td style="padding: 0px;">
				<SMWC:SkinTextImageButton ID="RefreshImageButton" runat="server" CssClass="ButtonBarImageButton" ResourceIDGlobal="@Refresh" ImageFile="Icons/Refresh.png" NavigateURL="javascript:DoCommand('Refresh');" />
			</td>
		</tr>
	</table>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="CntPH" runat="server">
	<asp:Label ID="MessageCounterLabel" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="NavPH" runat="server">
	<span id="divPager2"></span><span id="divLoading" style="display: none">
		<asp:Image runat="server" ID="LoadingImage" />
		<STWC:GlobalizedLabel ID="GL1" runat="server" ResourceIDGlobal="@Loading" />
	</span>

	<script type="text/javascript">
		var a = document.getElementById('divPager2');
		var b = document.getElementById('divPager');
		if (a && b)
			a.innerHTML = b.innerHTML;
		else if (a)
			a.innerHTML = "";
	</script>

</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="SPH" runat="server">

	<div class="searchbar" id="trSearchBar" runat="server">
		<STWC:GlobalizedLabel ID="lblSearch" runat="server" ResourceIDGlobal="@Search" />&nbsp;
		<asp:TextBox ID="txtSearchString" onKeyPress="return EnterHandler(event,DoSearch);" runat="server" />&nbsp;
		<asp:DropDownList ID="ddCrit" runat="server" />&nbsp;
		<asp:DropDownList ID="ddFolder" runat="server" />&nbsp; 
		<a class="searchbar" href="#" onclick="javascript: DoSearch();"><STWC:GlobalizedLabel ID="Globalizedlabel1" runat="server" ResourceIDGlobal="@FindNow" />&nbsp;</a>&nbsp;
		<a class="searchbar" href="#" onclick="javascript: DoSearchClear();"><STWC:GlobalizedLabel ID="Globalizedlabel2" runat="server" ResourceIDGlobal="@Clear" />&nbsp;</a>
		<STWC:GlobalizedCheckbox ID="chkNewOnly" runat="server"  ResourceIDPage="NewOnly" />
	</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MPH" runat="server">

	<script type="text/javascript">
		var RadGrid1;
        var isChecked = false;
        var currentRow = 0;
        var autoView = <%= AutoPreviewEnabled %>;
        var trSearchBar = '<%= trSearchBar.ClientID  %>';
        var txtSearchString = '<%= txtSearchString.ClientID  %>';
        var DeleteConfirm = '<%= PageString("DeleteConfirm") %>';
        var PurgeConfirm = '<%= PageString("PurgeConfirm") %>';
        var AtDeleteConfirm = '<%= GlobalString("@DeleteConfirm") %>';
        var GridID = "<%= Grid.UniqueID %>";
        var menu = <%= MoveMenu.ClientID %>;
        var menuCommand = '<%= MoveMenu.ClientID %>.Enable();';
        function cb(e){e.cancelBubble=true;}
        function DoSearchClear()
        {
			document.getElementById('<%= chkNewOnly.ClientID %>').checked = false;
			document.getElementById(txtSearchString).value = '';	
			DoSearch();
        }
        function DoSearch()
        {
			DoCommand("Search " + document.getElementById('<%= chkNewOnly.ClientID %>').checked + ' ' + document.getElementById('<%= ddCrit.ClientID %>').value + ' ' + escape(document.getElementById('<%= ddFolder.ClientID %>').value) + ' ' + document.getElementById('<%= txtSearchString.ClientID  %>').value);
        }

        function print_iframe(frame_name) 
        {
            frames[frame_name].BeginPrint();
            var iFrm = window.frames[frame_name];
            if (iFrm) 
            {
                iFrm.focus(); //IE requirement
                iFrm.print();
            }
            frames[frame_name].EndPrint();
        }

	</script>

	<asp:Literal runat="server" ID="decrementLiteral"></asp:Literal>

	<script type="text/javascript" src="<%= JScript %>"></script>

	<div class="sharebar" id="trShareInfo" runat="server">
		<asp:Literal runat="server" ID="ShareLiteral"></asp:Literal>
	</div>
	<radG:RadGrid ID="Grid" runat="server" EnableAJAX="true" AllowPaging="True" AllowCustomPaging="True" AutoGenerateColumns="false" OnPageIndexChanged="Grid_PageIndexChanged" AllowSorting="True" OnDataBound="Grid_DataBound" OnItemCreated="Grid_ItemCreated" OnSortCommand="Grid_SortCommand" OnItemDataBound="Grid_ItemDataBound" OnItemCommand="Grid_ItemCommand">
		<PagerStyle Mode="NumericPages" />
		<ClientSettings>
			<Selecting AllowRowSelect="True" />
			<ClientEvents OnRequestStart="RequestStart" OnRequestEnd="RequestEnd" OnRowDblClick="RowDoubleClick" OnRowSelected="RowSelected" OnGridCreated="GridCreated" />
		</ClientSettings>
		<MasterTableView DataSourcePersistenceMode="NoPersistence" AllowPaging="true" AllowCustomPaging="true" Width="100%" BorderWidth="0px" BorderStyle="None" CellPadding="0">
			<PagerTemplate>
				<span id="divPager">
					<asp:LinkButton ID="lnkFirst" CommandName="Page" CausesValidation="false" CommandArgument="First" runat="server">First</asp:LinkButton>&nbsp;
					<asp:LinkButton ID="lnkPrevGroup" CommandName="Page" CausesValidation="false" CommandArgument="PrevGroup" runat="server">PrevGroup</asp:LinkButton>&nbsp;
					<asp:LinkButton ID="lnkPrev" CommandName="Page" CausesValidation="false" CommandArgument="Prev" runat="server">Prev</asp:LinkButton>&nbsp; <span id="divPages" runat="server"></span>
					<asp:Literal ID="litOf" runat="server" />&nbsp;
					<asp:LinkButton ID="lnkNext" CommandName="Page" CausesValidation="false" CommandArgument="Next" runat="server">Next</asp:LinkButton>&nbsp;
					<asp:LinkButton ID="lnkNextGroup" CommandName="Page" CausesValidation="false" CommandArgument="Next" runat="server">NextGroup</asp:LinkButton>&nbsp;
					<asp:LinkButton ID="lnkLast" CommandName="Page" CausesValidation="false" CommandArgument="Last" runat="server">Last</asp:LinkButton>&nbsp; </span>
			</PagerTemplate>
			<Columns>
				<radG:GridTemplateColumn UniqueName="blank">
					<HeaderStyle Width="20px" />
					<ItemStyle CssClass="First"></ItemStyle>
					<ItemTemplate>
						&nbsp;</ItemTemplate>
				</radG:GridTemplateColumn>
				<radG:GridTemplateColumn HeaderText="Checkbox" UniqueName="chk">
					<HeaderStyle Width="24px" />
					<HeaderTemplate>
						<input onclick="CheckAll();" type="checkbox">
					</HeaderTemplate>
					<ItemTemplate>
						<input type="checkbox" onclick="cb(event);" />
					</ItemTemplate>
				</radG:GridTemplateColumn>
				<radG:GridBoundColumn DataField="Attachment" UniqueName="Attachment">
					<HeaderStyle Width="14px" />
				</radG:GridBoundColumn>
				<radG:GridBoundColumn DataField="NewIcon" UniqueName="NewIcon">
					<HeaderStyle Width="20px" />
				</radG:GridBoundColumn>
				<radG:GridBoundColumn DataField="From" HeaderText="From" UniqueName="from">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn DataField="To" HeaderText="To" UniqueName="to">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn DataField="Subject" HeaderText="Subject" UniqueName="subject">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn DataField="DateSentFriendly" HeaderText="Date" UniqueName="dateSent">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn DataField="SizeFriendlyString" HeaderText="Size" UniqueName="size">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn DataField="DeleteLink" HeaderText="" UniqueName="deleteLink" HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="right">
				</radG:GridBoundColumn>
				<radG:GridTemplateColumn>
					<HeaderStyle Width="20px" />
					<ItemStyle CssClass="Last"></ItemStyle>
					<ItemTemplate>
						&nbsp;</ItemTemplate>
				</radG:GridTemplateColumn>
				<radG:GridBoundColumn Display="False" DataField="url" UniqueName="url">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn Display="False" DataField="id" UniqueName="id">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn Display="False" DataField="folder" UniqueName="folder">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn Display="False" DataField="owner" UniqueName="owner">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn Display="False" DataField="Deleted" UniqueName="Deleted">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn Display="False" DataField="HasBeenRead" UniqueName="HasBeenRead">
				</radG:GridBoundColumn>
			</Columns>
		</MasterTableView>
	</radG:RadGrid>
	<SMWC:Spacer ID="Spacer1" runat="server" Width="1" Height="1" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="M2PH" runat="server">
	<div id="ReadMailFrame" style="height: 100%">
		<asp:Literal EnableViewState="false" runat="server" ID="BodyPlainTextLiteral"></asp:Literal>
	</div>

	<script type="text/javascript">
		if (self.currentUrl && autoView && frames['contentframe'].location.href=="about:blank")
		{
			SetFrame(self.currentUrl);
			//frames['contentframe'].location.href=currentUrl;
			//enabledragdrop();
		}
	</script>

</asp:Content>

