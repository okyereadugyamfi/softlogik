<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmTasks.aspx.cs" Inherits="SMWeb05.Main.frmTasks"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="NewTaskImageButton" runat="server" ResourceIDPage="NewTask" ImageFile="Icons/Add.png" CssClass="ButtonBarImageButton" NavigateURL="frmTask.aspx?newtask=true"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<asp:DropDownList runat="server" ID="lstCategories" AutoPostBack="True">
	</asp:DropDownList>
	<SMWC:Spacer runat="server" Width="25"></SMWC:Spacer>
	<asp:DropDownList runat="server" ID="ddStatus" AutoPostBack="True">
	</asp:DropDownList>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">
	<div id="trShareInfo" runat="server" class="sharebar">
		<asp:Literal runat="server" ID="ShareLiteral"></asp:Literal>
	</div>
	<STWC:HoverGrid ID="HoverGridResults" runat="server" AllowSorting="True" AutoGenerateColumns="False" Width="100%" HG_HoverEnabled="True" HG_StandardSettings="True" HG_ColumnExclusionIndexes="7" HG_EditURLField="url" EnableViewState="False">
		<PagerStyle Visible="False"></PagerStyle>
		<Columns>
			<asp:BoundColumn Visible="False" DataField="id" HeaderText="$ID"></asp:BoundColumn>
			<asp:BoundColumn DataField="CheckboxControls">
				<itemstyle horizontalalign="Right" width="10px"></itemstyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="subject" SortExpression="subject" HeaderText="@Subject"></asp:BoundColumn>
			<asp:BoundColumn DataField="status" SortExpression="status" HeaderText="@Status">
				<headerstyle horizontalalign="Center"></headerstyle>
				<itemstyle horizontalalign="Center"></itemstyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="datestring" SortExpression="date" HeaderText="$Date">
				<headerstyle horizontalalign="Center"></headerstyle>
				<itemstyle horizontalalign="Center"></itemstyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="percent" SortExpression="percent" HeaderText="$PerComplete">
				<headerstyle horizontalalign="Center"></headerstyle>
				<itemstyle horizontalalign="Center"></itemstyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="priority" SortExpression="priority" HeaderText="$Priority">
				<headerstyle horizontalalign="Center"></headerstyle>
				<itemstyle horizontalalign="Center"></itemstyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="deleteLink" SortExpression="action" HeaderText="">
				<headerstyle horizontalalign="right"></headerstyle>
				<itemstyle horizontalalign="right"></itemstyle>
			</asp:BoundColumn>
		</Columns>
	</STWC:HoverGrid>
</asp:Content>

