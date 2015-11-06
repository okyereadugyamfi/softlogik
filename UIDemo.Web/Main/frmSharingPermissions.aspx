<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmSharingPermissions.aspx.cs" Inherits="SMWeb05.Main.frmSharingPermissions"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnAddUser" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/add.png" ResourceIDPage="AddPermissions"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="btnAddGroup" Visible="false" runat="server" ResourceIDPage="AddGroup" CssClass="ButtonBarImageButton" ImageFile="Icons/add.png"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnBack" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/back.png" ResourceIDGlobal="@Back"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">
	<STWC:HoverGrid ID="dgPermissions" runat="server" HG_EditURLField="editURL" HG_ColumnExclusionIndexes="5" HG_StandardSettings="True" HG_HoverEnabled="True" Width="100%" AutoGenerateColumns="False">
		<PagerStyle HorizontalAlign="Right" CssClass="pager" Mode="NumericPages"></PagerStyle>
		<Columns>
			<asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
			<asp:BoundColumn Visible="False" DataField="Type"></asp:BoundColumn>
			<asp:BoundColumn DataField="Image">
				<headerstyle wrap="False" width="1%"></headerstyle>
				<itemstyle wrap="False"></itemstyle>
				<footerstyle wrap="False"></footerstyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="Name"></asp:BoundColumn>
			<asp:BoundColumn DataField="Permission"></asp:BoundColumn>
			<asp:BoundColumn DataField="RemoveLink">
				<itemstyle horizontalalign="Right"></itemstyle>
			</asp:BoundColumn>
		</Columns>
	</STWC:HoverGrid>
</asp:Content>

