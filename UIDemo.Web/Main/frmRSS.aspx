<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmRSS.aspx.cs" Inherits="SMWeb05.Main.frmRSS"  %>

<%@ Register Assembly="RadGrid.Net2" Namespace="Telerik.WebControls" TagPrefix="radG" %>
<%@ Register Assembly="RadMenu.Net2" Namespace="Telerik.WebControls" TagPrefix="radM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="SaveTextImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Add.png" ResourceIDPage="NewFeed" Visible="False"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="EditImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="icons/Settingsgrey.png" ResourceIDPage="EditFeed"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="ForceUpdateButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/refresh.png" ResourceIDPage="ForceUpdate" Visible="False" OnClick="ForceUpdateButton_Click"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="DeleteButtonMain" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Cancel_close.png" ResourceIDPage="DeleteFeed"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="CntPH" runat="server">
	<asp:Label ID="MessageCounterLabel" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="NavPH" runat="server">
	<span id="divPager2"></span><span id="divLoading" style="visibility: hidden">&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Image runat="server" ID="LoadingImage" />
		<STWC:GlobalizedLabel ID="GL1" runat="server" ResourceIDGlobal="@Loading" />
	</span>

	<script type="text/javascript">
		var a = document.getElementById('divPager2');
		var b = document.getElementById('divPager');
		if (a && b)
			a.innerHTML = b.innerHTML;
	
	</script>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MPH" runat="server">

	<script type="text/javascript">
		var RadGrid1;
        function GridCreated()
        {
			RadGrid1 = this;
			var a = document.getElementById('divPager2');
			var b = document.getElementById('divPager');
			if (a && b)
				a.innerHTML = b.innerHTML;
			ViewSelected();
        }
        function RowSelected(rowObject)
        {
			currentRow = rowObject.Index;
			var url = this.GetCellByColumnUniqueName(rowObject,"url").innerHTML + "&msgX=" + escape(location.href);
			var iframe=document.getElementById("ReadMailFrame");
			url = url.replace(/&amp;/gi,"&");
			url = url.replace(/&lt;/gi,"<");
			url = url.replace(/&gt;/gi,">");
			if (iframe==null)
			{
				location.href = url + "&cRow=" + rowObject + "&returnPath=" + escape(location.href);
				return;
			}
			frames['contentframe'].location.href = url;
        }
        function RowDoubleClick(rowObject)
        {
        	var url = this.GetCellByColumnUniqueName(<%= Grid.ClientID %>.MasterTableView.Rows[rowObject],"url").innerHTML;
        	url = url.replace(/frmreadmail_body/i,"frmReadMail");
        	url = url.replace(/&amp;/gi,"&");
        	url = url.replace(/&lt;/gi,"<");
        	url = url.replace(/&gt;/gi,">");
        	location.href = url + "&returnPath=" + escape(location.href);
        }
        function RequestStart()
		{
			document.getElementById("divLoading").style.visibility = "";
		}

		function RequestEnd()
		{
			document.getElementById("divLoading").style.visibility = "hidden";
			var a = document.getElementById('divPager2');
			var b = document.getElementById('divPager');
						
			if (a && b)
				a.innerHTML = b.innerHTML;
			else if (a)
				a.innerHTML = "";
				
			ViewSelected();
		}
        function ViewSelected()
		{
			var rows = RadGrid1.MasterTableView.SelectedRows;
	
			var i = 0;
			for (i = 0; i < rows.length; i++)
			{
				var url = RadGrid1.MasterTableView.GetCellByColumnUniqueName(rows[i],"url").innerHTML + "&msgX=" + escape(location.href);
				url = url.replace(/&amp;/gi,"&");
				url = url.replace(/&lt;/gi,"<");
				url = url.replace(/&gt;/gi,">");
				currentUrl = url;
				break;
			}
			
			if (document.getElementById("ReadMailFrame"))
			{
				if (currentUrl==null)
				{ return; }
				else
					frames['contentframe'].location.href = currentUrl;
			}
		}
	</script>

	<radG:RadGrid ID="Grid" runat="server" EnableAJAX="true" AllowPaging="True" AutoGenerateColumns="false" SkinsPath="~/RadControls/Grid/Skins" OnNeedDataSource="Grid_NeedDataSource" OnPageIndexChanged="Grid_PageIndexChanged" AllowSorting="True" OnDataBound="Grid_DataBound" OnSortCommand="Grid_SortCommand" AllowCustomPaging="True" OnItemDataBound="Grid_ItemDataBound">
		<PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
		<ClientSettings>
			<Selecting AllowRowSelect="True" />
			<ClientEvents OnRequestStart="RequestStart" OnRequestEnd="RequestEnd" OnRowDblClick="RowDoubleClick" OnRowSelected="RowSelected" OnGridCreated="GridCreated" />
		</ClientSettings>
		<MasterTableView AllowCustomPaging="true" Width="100%" BorderWidth="0px" BorderStyle="None" CellPadding="0">
			<Columns>
				<radG:GridTemplateColumn HeaderText="Checkbox" UniqueName="chk">
					<HeaderTemplate>
					</HeaderTemplate>
					<ItemTemplate>
						<SMWC:Spacer ID="SpacerImage1" runat="server" Width="20" Height="1" />
					</ItemTemplate>
				</radG:GridTemplateColumn>
				<radG:GridBoundColumn DataField="NewIcon" UniqueName="NewIcon">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn DataField="Subject" HeaderText="Subject" UniqueName="subject">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn DataField="Date" HeaderText="Date" UniqueName="date">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn DataField="Author" HeaderText="Author" UniqueName="Author">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn DataField="Category" HeaderText="Category" UniqueName="Category">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn Display="False" DataField="new" HeaderText="new" UniqueName="new">
				</radG:GridBoundColumn>
				<radG:GridBoundColumn Display="False" DataField="url" UniqueName="url">
				</radG:GridBoundColumn>
				<radG:GridTemplateColumn HeaderText="Checkbox" UniqueName="chk">
					<HeaderTemplate>
					</HeaderTemplate>
					<ItemTemplate>
						<SMWC:Spacer ID="SpacerImage2" runat="server" Width="20" Height="1" />
					</ItemTemplate>
				</radG:GridTemplateColumn>
			</Columns>
			<ExpandCollapseColumn ButtonType="ImageButton" UniqueName="ExpandColumn" Visible="False">
				<HeaderStyle Width="19px" />
			</ExpandCollapseColumn>
			<RowIndicatorColumn UniqueName="RowIndicator" Visible="False">
				<HeaderStyle Width="20px" />
			</RowIndicatorColumn>
		</MasterTableView>
	</radG:RadGrid>
	<SMWC:Spacer ID="Spacer1" runat="server" Width="1" Height="1" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="M2PH" runat="server">
	<div id="ReadMailFrame" style="height: 100%">
		<asp:Literal runat="server" ID="BodyPlainTextLiteral"></asp:Literal>
	</div>
		<script type="text/javascript">
		if (self.currentUrl)
			frames['contentframe'].location.href = currentUrl;
	</script>
</asp:Content>

