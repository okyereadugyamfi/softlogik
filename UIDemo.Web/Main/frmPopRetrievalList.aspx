<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="frmPopRetrievalList.aspx.cs" Inherits="SMWeb05.Main.frmPopRetrievalList" MasterPageFile="~/MasterPages/Dummy.Master"  %>

<%@ Register TagPrefix="SMWC" Namespace="SMWeb05.UserControls" Assembly="SMWeb05" %>
<%@ Register TagPrefix="STWC" Namespace="SmarterTools.Web.Controls" Assembly="SmarterTools.Web" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton runat="server" ID="AddPopRetrievalImageButton" NavigateURL="frmPopRetrievalSettings.aspx" ImageFile="Icons/Add.png" ResourceIDPage="AddPopRetrieval" CssClass="ButtonBarImageButton" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MPH" runat="server">

    <STWC:HoverGrid ID="HoverGridResults" AllowSorting="True" AutoGenerateColumns="False" runat="server" Width="100%" HG_HoverEnabled="True" HG_StandardSettings="True" HG_EditURLField="editURL" HG_ColumnExclusionIndexes="3" PageSize="25">
		<PagerStyle HorizontalAlign="Right" CssClass="datagridheader" Mode="NumericPages"></PagerStyle>
		<Columns>
			<asp:boundcolumn datafield="serverName" headertext="$PopRetrievalAccountName">
				<itemstyle wrap="False"></itemstyle>
			</asp:boundcolumn>
			<asp:boundcolumn datafield="userName" headertext="$PopRetrievalUserName">
				<itemstyle wrap="False"></itemstyle>
			</asp:boundcolumn>
			<asp:boundcolumn visible="False" datafield="editURL">
				<itemstyle wrap="False" horizontalalign="Center"></itemstyle>
			</asp:boundcolumn>
			<asp:boundcolumn datafield="deleteLink">
				<itemstyle wrap="False" horizontalalign="Right" width="15%"></itemstyle>
			</asp:boundcolumn>
		</Columns>
	</STWC:HoverGrid>

</asp:Content>