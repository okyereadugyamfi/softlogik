<%@ Control Language="C#" AutoEventWireup="false" Codebehind="SearchBar.ascx.cs" Inherits="SMWeb05.UserControls.PanelBarTemplates.SearchBar" %>
<div class="SideSearchBar">
	<asp:TextBox onKeyPress="return keyHandler(event);" ID="txtSearch" runat="server" Style="width: 186px"></asp:TextBox><br />
	<asp:DropDownList ID="ddType" runat="server">
	</asp:DropDownList>
	<SMWC:SkinTextImageButton ID="SearchButton" runat="server" CssClass="SidebarImageButton" ImageFile="Icons/Search.png" ResourceIDGlobal="@Search" NavigateURL="javascript:DoSideBarSearch()"></SMWC:SkinTextImageButton>

	<script type="text/javascript">
		function keyHandler(e)
		{
			var pressedKey;
			if(document.all) 
			{
				e = window.event;
				pressedKey = e.keyCode;
			}
			else
				pressedKey = e.which;
				
			if(pressedKey == 13) 
			{
				DoSideBarSearch();
				return false;
			}
		} 
			
		function DoSideBarSearch()
		{
			var type = document.getElementById("<%= ddType.ClientID %>").value;
			var page = 'SystemAdmin/frmDomains.aspx';
			if (type == 1)
				page = 'Systemadmin/Reports/frmDomainAliasReport.aspx';
			page = '<%= ThePath %>' + page + '?search=' + document.getElementById("<%= txtSearch.ClientID %>").value;
			location.href = page;
			return true;
		}
		
	</script>

</div>
