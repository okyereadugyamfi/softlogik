<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmNote.aspx.cs" Inherits="SMWeb05.Main.frmNote"  %>

<%@ Register Assembly="RadTabStrip.Net2" Namespace="Telerik.WebControls" TagPrefix="radTS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnSave" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Save.png" ResourceIDGlobal="@Save"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="btnManageCategories" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/masterCatagories.png" ResourceIDGlobal="@MasterCategories" NavigateURL="javascript:OpenMasterCategoriesPopup()"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnCancel" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Cancel_close.png" ResourceIDGlobal="@Cancel"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="TPH" runat="server">
	<radTS:RadTabStrip ID="TabStrip" runat="server" >
		<Tabs>
			<radTS:Tab ID="Tab1" runat="server" Text="@Options" PageViewID="OptionsTab">
			</radTS:Tab>
			<radTS:Tab ID="Tab2" runat="server" Text="@Categories" PageViewID="CategoriesTab">
			</radTS:Tab>
		</Tabs>
	</radTS:RadTabStrip>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">

	<script type="text/javascript">
		<!--
		
		function OpenMasterCategoriesPopup()
		{
			var popurl="frmPopupContactCategories.aspx";
			winpops=window.open(popurl,"categorywindow","width=450,height=270,resizable=yes");
		}
		
		-->		
	</script>

	<radTS:RadMultiPage ID="MP1" runat="server">
		<radTS:PageView ID="OptionsTab" runat="server">
			<table class="TabStripContent">
				<tr>
					<td class="SettingsHeader" colspan="2">
						<STWC:GlobalizedLabel ID="Globalizedlabel12" runat="server" ResourceIDGlobal="@BasicInformation" />
					</td>
				</tr>
				<tr>
					<td class="SettingsLabelInd">
						<STWC:GlobalizedLabel ID="Globalizedlabel3" runat="server" ResourceIDGlobal="@Color" />
					</td>
					<td class="SettingsContent">
						<asp:DropDownList runat="server" ID="lstColors">
						</asp:DropDownList>
					</td>
				</tr>
			</table>
			<table class="TabStripContent">
				<tr>
					<td class="SettingsHeader">
						<STWC:GlobalizedLabel ID="Globalizedlabel1" runat="server" ResourceIDGlobal="@Note" />
					</td>
				</tr>
				<tr>
					<td class="SettingsSettingSingleInd">
						<asp:TextBox ID="txtNote" runat="server" columns="50" TextMode="MultiLine" Rows="10"></asp:TextBox>
					</td>
				</tr>
			</table>
		</radTS:PageView>
		<radTS:PageView ID="CategoriesTab" runat="server">
			<asp:Table cssclass="TabStripContent" runat="server" ID="tblCategories" Width="80%">
			</asp:Table>
			<asp:TextBox runat="server" ID="txtCategoryCount" Visible="False"></asp:TextBox>
			<asp:TextBox runat="server" ID="txtCategories" Visible="False"></asp:TextBox>
		</radTS:PageView>
	</radTS:RadMultiPage>
</asp:Content>

