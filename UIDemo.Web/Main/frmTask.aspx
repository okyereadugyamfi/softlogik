<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmTask.aspx.cs" Inherits="SMWeb05.Main.frmTask" Title="Untitled Page" %>

<%@ Register Assembly="RadTabStrip.Net2" Namespace="Telerik.WebControls" TagPrefix="radTS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="SaveTextImageButton" runat="server" ImageFile="Icons/Save.png" CssClass="ButtonBarImageButton" ResourceIDGlobal="@Save"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="btnManageCategories" runat="server" CssClass="ButtonBarImageButton" ImageFile="icons/masterCatagories.png" ResourceIDGlobal="@MasterCategories" NavigateURL="javascript:OpenMasterCategoriesPopup()"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="DeleteImageButton" runat="server" ImageFile="Icons/Cancel_close.png" CssClass="ButtonBarImageButton" ResourceIDGlobal="@DeleteCap"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="CancelTextImageButton" runat="server" ImageFile="Icons/Cancel_close.png" CssClass="ButtonBarImageButton" ResourceIDGlobal="@Cancel" NavigateURL="frmTasks.aspx"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TPH" runat="server">
	<radTS:RadTabStrip ID="TabStrip" runat="server" >
		<Tabs>
			<radTS:Tab ID="Tab1" runat="server" Text="@Options" PageViewID="OptionsTab">
			</radTS:Tab>
			<radTS:Tab ID="Tab2" runat="server" Text="@Categories" PageViewID="CategoriesTab">
			</radTS:Tab>
		</Tabs>
	</radTS:RadTabStrip>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MPH" runat="server">

	<script type="text/javascript">
		<!--
		function OpenMasterCategoriesPopup()
		{
			var popurl="frmPopupContactCategories.aspx";
			winpops=window.open(popurl,"categorywindow","width=450,height=270,resizable=yes");
		}
		// -->
	</script>

	<radTS:RadMultiPage ID="MP1" runat="server">
		<radTS:PageView ID="OptionsTab" runat="server">
			<table class="TabStripContent">
				<tr>
					<td class="SettingsHeader" colspan="2">
						<STWC:GlobalizedLabel ID="Globalizedlabel1" runat="server" ResourceIDGlobal="@BasicInformation" name="Globalizedlabel1"></STWC:GlobalizedLabel>
					</td>
				</tr>
				<tr>
					<td class="SettingsLabelInd">
						<STWC:GlobalizedLabel ID="GLOBALIZEDLABEL2" runat="server" ResourceIDGlobal="@Subject"></STWC:GlobalizedLabel></td>
					<td class="SettingsSetting">
						<asp:TextBox ID="SubjectBox" runat="server" Columns="35"></asp:TextBox></td>
				</tr>
			</table>
			<table class="TabStripContent">
				<tr>
					<td class="SettingsHeader" colspan="2">
						&nbsp;<STWC:GlobalizedLabel ID="Globalizedlabel7" runat="server" ResourceIDPage="DateTimeInformation" name="Globalizedlabel1"></STWC:GlobalizedLabel>
					</td>
				</tr>
				<tr>
					<td class="SettingsLabelInd">
						<STWC:GlobalizedLabel ID="Globalizedlabel6" runat="server" ResourceIDGlobal="@Start"></STWC:GlobalizedLabel>
					</td>
					<td class="SettingsSetting">
						<SMWC:PopupCalendar ID="calStartDate" runat="server" FormName="aspnetForm"></SMWC:PopupCalendar>
						<asp:TextBox ID="DateStartBox" runat="server" Columns="6"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td class="SettingsLabelInd">
						<STWC:GlobalizedLabel ID="Globalizedlabel8" runat="server" ResourceIDPage="DateEnd"></STWC:GlobalizedLabel>
					</td>
					<td class="SettingsSetting">
						<SMWC:PopupCalendar ID="calEndDate" runat="server" FormName="aspnetForm"></SMWC:PopupCalendar>
						<asp:TextBox ID="DateEndBox" runat="server" Columns="6"></asp:TextBox>
					</td>
				</tr>
			</table>
			<table class="TabStripContent">
				<tr>
					<td class="SettingsHeader" colspan="2">
						<STWC:GlobalizedLabel ID="Globalizedlabel9" runat="server" ResourceIDGlobal="@Reminder"></STWC:GlobalizedLabel>
					</td>
				</tr>
				<tr>
					<td class="SettingsLabelInd">
						<STWC:GlobalizedLabel ID="Globalizedlabel11" runat="server" ResourceIDGlobal="@Reminder"></STWC:GlobalizedLabel>
					</td>
					<td class="SettingsSetting">
						<asp:DropDownList ID="ReminderDropDown" runat="server">
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td class="SettingsLabelInd">
						<STWC:GlobalizedLabel ID="Globalizedlabel4" runat="server" ResourceIDPage="Priority"></STWC:GlobalizedLabel></td>
					<td class="SettingsSetting">
						<asp:DropDownList ID="ComboPriority" runat="server">
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td class="SettingsLabelInd">
						<STWC:GlobalizedLabel ID="Globalizedlabel3" runat="server" ResourceIDGlobal="@Status"></STWC:GlobalizedLabel></td>
					<td class="SettingsSetting">
						<asp:DropDownList ID="ComboStatus" runat="server">
						</asp:DropDownList></td>
				</tr>
				<tr>
					<td class="SettingsLabelInd">
						<STWC:GlobalizedLabel ID="Globalizedlabel5" runat="server" ResourceIDGlobal="@PerComplete"></STWC:GlobalizedLabel></td>
					<td class="SettingsSetting">
						<asp:DropDownList ID="ComboPercent" runat="server">
						</asp:DropDownList>
					</td>
				</tr>
			</table>
			<table class="TabStripContent">
				<tr>
					<td class="SettingsHeader" colspan="2">
						<STWC:GlobalizedLabel ID="Globalizedlabel20" runat="server" ResourceIDGlobal="@Description"></STWC:GlobalizedLabel>
					</td>
				</tr>
				<tr>
					<td class="SettingsSettingSingleInd">
						<STWC:ValidatedTextBox ID="DescriptionBox" runat="server" Columns="50" TextMode="MultiLine" Rows="10"></STWC:ValidatedTextBox>
					</td>
				</tr>
			</table>
		</radTS:PageView>
		<radTS:PageView ID="CategoriesTab" runat="server">
			<asp:Table CssClass="TabStripContent" runat="server" ID="tblCategories" Width="80%">
			</asp:Table>
			<asp:TextBox runat="server" ID="txtCategoryCount" Visible="False"></asp:TextBox>
			<asp:TextBox runat="server" ID="txtCategories" Visible="False"></asp:TextBox>
		</radTS:PageView>
	</radTS:RadMultiPage>
</asp:Content>

