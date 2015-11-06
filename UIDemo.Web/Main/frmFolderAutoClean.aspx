<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmFolderAutoClean.aspx.cs" Inherits="SMWeb05.Main.frmFolderAutoClean" %>

<%@ Register Assembly="RadTabStrip.Net2" Namespace="Telerik.WebControls" TagPrefix="radTS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="SaveButton" runat="server" ResourceIDGlobal="@Save" ImageFile="Icons/Save.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="AddTextImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Add.png" ResourceIDGlobal="@AutoCleanAddRule" NavigateURL="frmFolderAutoCleanAdd.aspx" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="CancelTextImageButton" runat="server" ResourceIDGlobal="@Cancel" ImageFile="Icons/Cancel_close.png" CssClass="ButtonBarImageButton" NavigateURL="frmFolders.aspx"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="TPH" runat="server">
	<radTS:RadTabStrip ID="TabStrip" runat="server">
		<Tabs>
			<radTS:Tab ID="Tab1" runat="server" Text="@Options" PageViewID="OptionsTab">
			</radTS:Tab>
			<radTS:Tab ID="Tab2" runat="server" Text="@Folders" PageViewID="SetupTab">
			</radTS:Tab>
		</Tabs>
	</radTS:RadTabStrip>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">
	<radTS:RadMultiPage ID="MP1" runat="server">
		<radTS:PageView ID="OptionsTab" runat="server">
			<table class="TabStripContent">
				<tr>
					<td class="SettingsLabel">
						<STWC:GlobalizedLabel ID="SettingsLockedLabel" runat="server" ResourceIDPage="SettingsLocked" Visible="false" />
					</td>
				</tr>
				<tr>
					<td class="SettingsSettingSingle">
						<asp:RadioButton ID="OverrideOffRadio" runat="server" AutoPostBack="True" GroupName="Override"></asp:RadioButton>
					</td>
				</tr>
				<tr>
					<td class="SettingsSettingSingle">
						<asp:RadioButton ID="OverrideOnRadio" runat="server" AutoPostBack="True" GroupName="Override"></asp:RadioButton>
					</td>
				</tr>
				<tr>
					<td class="SettingsSettingSingle">
						<asp:CheckBox ID="chkAllowUserOverride" runat="server" Text="$AllowUserOverride"></asp:CheckBox>
					</td>
				</tr>
			</table>
			<div id="StaticArea" runat="server">
				<table class="TabStripContent">
					<tr>
						<td class="SettingsHeader" colspan="2">
							<STWC:GlobalizedLabel ID="Globalizedlabel14" runat="server" ResourceIDPage="DefaultSettings" />
						</td>
					</tr>
					<tr>
						<td class="SettingsLabelInd" style="text-decoration: underline">
							<STWC:GlobalizedLabel ID="Globalizedlabel15" runat="server" ResourceIDPage="FolderName" />
						</td>
						<td class="SettingsSetting" style="text-decoration: underline">
							<STWC:GlobalizedLabel ID="Globalizedlabel16" runat="server" ResourceIDPage="AutoCleanSetting" />
						</td>
					</tr>
					<asp:Literal ID="litDefaultRules" runat="server"></asp:Literal>
				</table>
			</div>
		</radTS:PageView>
		<radTS:PageView ID="SetupTab" runat="server">
			<div id="OverrideArea" runat="server">
				<STWC:HoverGrid ID="HoverGridAutoClean" AllowSorting="False" AutoGenerateColumns="False" runat="server" HG_EditURLField="editurl" Width="100%" HG_HoverEnabled="True" HG_StandardSettings="True" HG_ColumnExclusionIndexes="5">
					<Columns>
						<asp:boundcolumn datafield="imgLink">
							<itemstyle wrap="False" horizontalalign="Center" width="16px"></itemstyle>
						</asp:boundcolumn>
						<asp:boundcolumn datafield="Item"></asp:boundcolumn>
						<asp:boundcolumn datafield="Type"></asp:boundcolumn>
						<asp:boundcolumn datafield="More"></asp:boundcolumn>
						<asp:templatecolumn>
							<itemstyle horizontalalign="Right" width="15%"></itemstyle>
							<itemtemplate><%# DataBinder.Eval(Container.DataItem, "DeleteLink") %>&nbsp;</itemtemplate>
						</asp:templatecolumn>
					</Columns>
				</STWC:HoverGrid>
			</div>
		</radTS:PageView>
	</radTS:RadMultiPage>
</asp:Content>

