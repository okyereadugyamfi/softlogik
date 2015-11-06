<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmNotes.aspx.cs" Inherits="SMWeb05.Main.frmNotes"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnAddNote" runat="server" ResourceIDPage="AddNote" CssClass="ButtonBarImageButton" ImageFile="Icons/Add.png" NavigateURL="frmNote.aspx?ret=1"></SMWC:SkinTextImageButton>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<asp:DropDownList runat="server" ID="lstCategories" AutoPostBack="True">
	</asp:DropDownList>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">
	<div id="trShareInfo" runat="server" class="sharebar">
		<asp:Literal runat="server" ID="ltrlShareInfo"></asp:Literal>
	</div>
	<STWC:HoverGrid ID="HoverGridResults" AllowSorting="True" AutoGenerateColumns="False" runat="server" Width="100%" HG_HoverEnabled="True" HG_StandardSettings="True" HG_ColumnExclusionIndexes="3" HG_EditURLField="url">
		<PagerStyle Visible="False"></PagerStyle>
		<Columns>
			<asp:BoundColumn DataField="color">
				<headerstyle width="40px"></headerstyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="text"></asp:BoundColumn>
			<asp:BoundColumn DataField="date"></asp:BoundColumn>
			<asp:BoundColumn DataField="delete">
				<itemstyle horizontalalign="Right"></itemstyle>
			</asp:BoundColumn>
		</Columns>
	</STWC:HoverGrid>
</asp:Content>

