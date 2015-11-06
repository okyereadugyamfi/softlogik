<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmMySharedResources.aspx.cs" Inherits="SMWeb05.Main.frmMySharedResources" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnAddShare" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/addshare_user.png" ResourceIDGlobal="@AddShare" OnClick="btnAddShare_Click"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MPH" runat="server">
	<STWC:HoverGrid ID="dgMyShares" runat="server" HG_EditURLField="editURL" HG_ColumnExclusionIndexes="5" HG_StandardSettings="True" HG_HoverEnabled="True" Width="100%" AutoGenerateColumns="False">
		<PagerStyle HorizontalAlign="Right" CssClass="pager" Mode="NumericPages"></PagerStyle>
		<Columns>
			<asp:BoundColumn DataField="Image">
				<headerstyle wrap="False" width="1%"></headerstyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="Name"></asp:BoundColumn>
			<asp:BoundColumn DataField="Resource"></asp:BoundColumn>
			<asp:BoundColumn DataField="RemoveLink">
				<itemstyle horizontalalign="Right"></itemstyle>
			</asp:BoundColumn>
		</Columns>
	</STWC:HoverGrid>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="NavPH" runat="server">
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="CntPH" runat="server">
</asp:Content>

