<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmMappedFolders.aspx.cs" Inherits="SMWeb05.Main.Sharing.frmMappedFolders"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnAttach" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/addShare_User.png" ResourceIDPage="AttachToFolder" NavigateURL="frmMyShares.aspx"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MPH" runat="server">
	<STWC:HoverGrid ID="dgMappedFolders" runat="server" HG_EditURLField="editURL" HG_ColumnExclusionIndexes="3" HG_StandardSettings="True" HG_HoverEnabled="True" Width="100%" AutoGenerateColumns="False" AllowSorting="True" >
		<PagerStyle HorizontalAlign="Right" CssClass="pager" Mode="NumericPages"></PagerStyle>
		<Columns>
			<asp:BoundColumn DataField="icon">
				<headerstyle width="1%" />
			</asp:BoundColumn>
			<asp:BoundColumn DataField="FriendlyName"></asp:BoundColumn>
			<asp:BoundColumn DataField="ResourceType"></asp:BoundColumn>
			<asp:BoundColumn DataField="Access"></asp:BoundColumn>
			<asp:BoundColumn DataField="RenameLink"></asp:BoundColumn>
			<asp:BoundColumn DataField="DeleteLink"></asp:BoundColumn>
			<asp:BoundColumn Visible="False" DataField="OwnerUsername"></asp:BoundColumn>
			<asp:BoundColumn Visible="False" DataField="OriginalName"></asp:BoundColumn>
		</Columns>
	</STWC:HoverGrid>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="NavPH" runat="server">
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="CntPH" runat="server">
</asp:Content>

