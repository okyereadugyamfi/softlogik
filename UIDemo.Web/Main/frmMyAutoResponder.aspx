<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" ValidateRequest="false" AutoEventWireup="false" Codebehind="frmMyAutoResponder.aspx.cs" Inherits="SMWeb05.Main.frmMyAutoResponder"  %>

<%@ Register Assembly="RadTabStrip.Net2" Namespace="Telerik.WebControls" TagPrefix="radTS" %>
<%@ Register Assembly="RadSpell.Net2" Namespace="Telerik.WebControls" TagPrefix="radS" %>
<%@ Register Assembly="RadEditor.Net2" Namespace="Telerik.WebControls" TagPrefix="radE" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="SaveTextImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Save.png" ResourceIDGlobal="@Save" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TPH" runat="server">
	<radTS:RadTabStrip ID="TabStrip" runat="server" >
		<Tabs>
			<radTS:Tab ID="Tab1" runat="server" Text="@Options" PageViewID="OptionsTab">
			</radTS:Tab>
			<radTS:Tab ID="Tab2" runat="server" Text="$AutoResponderMessage" PageViewID="SetupTab">
			</radTS:Tab>
		</Tabs>
	</radTS:RadTabStrip>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MPH" runat="server">
	<radTS:RadMultiPage ID="MP1" runat="server">
		<radTS:PageView ID="OptionsTab" runat="server">
			<table class="TabStripContent">
				<tr>
					<td class="SettingsSettingSingle">
						<asp:CheckBox ID="chkEnabled" AutoPostBack="True" Text="$EnableAutoResponder" runat="server" />
					</td>
				</tr>
				<tr>
					<td class="SettingsSettingSingle">
						<asp:Label runat="server" ID="lblAutoRespondOnDirectMailOnly" Visible="False" />
						<asp:CheckBox ID="chkAutoRespondOnDirectMailOnly" runat="server" Text="$AutoRespondOnDirectMailOnly" />
					</td>
				</tr>
				<tr>
					<td class="SettingsSettingSingle">
						<asp:Label runat="server" ID="lblAutoResponseNote" Visible="False" />
						<asp:CheckBox ID="chkLimit" runat="server" Text="$LimitResponsesOnceDaily" />
					</td>
				</tr>
			</table>
		</radTS:PageView>
		<radTS:PageView ID="SetupTab" runat="server">
			<table class="TabStripContent">
				<tr>
					<td class="SettingsLabel">
						<STWC:GlobalizedLabel ID="Globalizedlabel3" runat="server" ResourceIDGlobal="@Subject" />
					</td>
					<td class="SettingsSetting">
						<asp:TextBox ID="txtSubject" Columns="50" runat="server" />
					</td>
				</tr>
				<tr>
					<td class="SettingsLabel">
						<STWC:GlobalizedLabel ID="Globalizedlabel1" runat="server" ResourceIDGlobal="@Options" />
					</td>
					<td class="SettingsSetting">
						<asp:RadioButton ID="RadioHTML" runat="server" Text="$HTML" Checked="True" GroupName="HTMLSelect" AutoPostBack="True" />
						<asp:RadioButton ID="RadioText" runat="server" Text="@PlainText" GroupName="HTMLSelect" AutoPostBack="True" />
					</td>
				</tr>
			</table>
			<table class="TabStripContent">
				<tr>
					<td class="SettingsSettingSingle">
						<asp:TextBox ID="txtBody" runat="server" Rows="6" Columns="70" TextMode="MultiLine"></asp:TextBox>
						<radE:RadEditor ID="RadAutoResponse" runat="server" Width="100%"  ShowSubmitCancelButtons="False" StripAbsoluteAnchorPaths="False" EnableContextMenus="False" EnableDocking="False" EnableEnhancedEdit="False">
						</radE:RadEditor>
					</td>
				</tr>
			</table>
		</radTS:PageView>
	</radTS:RadMultiPage>
</asp:Content>

