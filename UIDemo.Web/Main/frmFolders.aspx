<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmFolders.aspx.cs" Inherits="SMWeb05.Main.frmFolders"  %>

<asp:Content ID="Content2" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="AddImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/NewFolder.png" NavigateURL="frmFolder.aspx" ResourceIDPage="NewFolder"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="PropogateImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/trash.png" NavigateURL="frmFolderAutoClean.aspx" ResourceIDGlobal="@FolderAutoClean"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MPH" runat="server">
	<STWC:HoverGrid ID="HoverGridResults" runat="server" AutoGenerateColumns="False" Width="100%" HG_HoverEnabled="True" HG_StandardSettings="True" HG_ColumnExclusionIndexes="0,1,2,3,4,5,6,7">
		<PagerStyle HorizontalAlign="Right" CssClass="pager" Mode="NumericPages"></PagerStyle>
		<Columns>
			<asp:boundcolumn visible="False" datafield="name">
				<headerstyle horizontalalign="Center" verticalalign="Bottom"></headerstyle>
			</asp:boundcolumn>
			<asp:boundcolumn datafield="Image">
				<headerstyle width="16" verticalalign="Bottom"></headerstyle>
			</asp:boundcolumn>
			<asp:boundcolumn datafield="Folder" sortexpression="Name" headertext="$Folder">
				<headerstyle verticalalign="Bottom"></headerstyle>
			</asp:boundcolumn>
			<asp:boundcolumn datafield="ItemCount" headertext="$Items">
				<headerstyle horizontalalign="Right"></headerstyle>
				<itemstyle wrap="False" horizontalalign="Right"></itemstyle>
			</asp:boundcolumn>
			<asp:boundcolumn datafield="Size" sortexpression="Size" headertext="$Size">
				<headerstyle horizontalalign="Right" verticalalign="Bottom"></headerstyle>
				<itemstyle wrap="False" horizontalalign="Right"></itemstyle>
			</asp:boundcolumn>
			<asp:boundcolumn datafield="RenameLink">
				<headerstyle></headerstyle>
				<itemstyle wrap="False" horizontalalign="Right"></itemstyle>
			</asp:boundcolumn>
			<asp:boundcolumn datafield="SharingLink">
				<headerstyle></headerstyle>
				<itemstyle wrap="False" horizontalalign="Right"></itemstyle>
			</asp:boundcolumn>
			<asp:boundcolumn datafield="DeleteLink">
				<headerstyle></headerstyle>
				<itemstyle wrap="False" horizontalalign="Right"></itemstyle>
			</asp:boundcolumn>
		</Columns>
	</STWC:HoverGrid>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="NavPH" runat="server">
	<asp:Label ID="NavigationLabel" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CntPH" runat="server">
	<asp:Label ID="CounterLabel" runat="server"></asp:Label>
</asp:Content>

