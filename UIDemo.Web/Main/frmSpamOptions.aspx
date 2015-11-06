<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmSpamOptions.aspx.cs" Inherits="SMWeb05.Main.frmSpamOptions"  %>

<%@ Register Assembly="RadTabStrip.Net2" Namespace="Telerik.WebControls" TagPrefix="radTS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="SaveImageButton" runat="server" ResourceIDGlobal="@Save" ImageFile="Icons/Save.png" CssClass="ButtonBarImageButton" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="TPH" runat="server">
	<radTS:RadTabStrip ID="TabStrip" runat="server" >
		<Tabs>
			<radTS:Tab ID="Tab1" runat="server" Text="@Options" PageViewID="OptionsTab">
			</radTS:Tab>
			<radTS:Tab ID="Tab2" runat="server" Text="@Actions" PageViewID="SetupTab">
			</radTS:Tab>
			<radTS:Tab ID="Tab3" runat="server" Text="$TrustedSenders" PageViewID="TrustedTab">
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
			</table>
			<div id="StaticArea" runat="server">
				<table class="TabStripContent">
					<tr>
						<td class="SettingsHeader" colspan="2">
							<STWC:GlobalizedLabel ID="Globalizedlabel6" runat="server" ResourceIDPage="DefaultSettings" />
						</td>
					</tr>
					<tr>
						<td class="SettingsLabelInd" style="text-decoration: underline">
							<STWC:GlobalizedLabel ID="Globalizedlabel7" runat="server" ResourceIDPage="ProbabilityOfSpam" />
						</td>
						<td class="SettingsSetting" style="text-decoration: underline">
							<STWC:GlobalizedLabel ID="Globalizedlabel8" runat="server" ResourceIDGlobal="@Action" />
						</td>
					</tr>
					<tr>
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel9" runat="server" ResourceIDPage="LowShort" />
						</td>
						<td class="SettingsSetting">
							<asp:Label ID="LowStaticLabel" runat="server"></asp:Label>
						</td>
					</tr>
					<tr>
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel10" runat="server" ResourceIDPage="MediumShort" />
						</td>
						<td class="SettingsSetting">
							<asp:Label ID="MedStaticLabel" runat="server"></asp:Label>
						</td>
					</tr>
					<tr>
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel11" runat="server" ResourceIDPage="HighShort" />
						</td>
						<td class="SettingsSetting">
							<asp:Label ID="HighStaticLabel" runat="server"></asp:Label>
						</td>
					</tr>
				</table>
			</div>
		</radTS:PageView>
		<radTS:PageView ID="SetupTab" runat="server">
			<div id="OverrideUserArea" runat="server">
				<table class="TabStripContent">
					<tr>
						<td class="SettingsHeader" colspan="2">
							<STWC:GlobalizedLabel ID="Globalizedlabel12" runat="server" ResourceIDPage="Low" />
						</td>
					</tr>
					<tr>
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel15" runat="server" ResourceIDGlobal="@Action" />
						</td>
						<td class="SettingsSetting">
							<asp:DropDownList ID="UserActionLow" runat="server" AutoPostBack="True" />
						</td>
					</tr>
					<tr id="UserTextLowRow" runat="server">
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel26" runat="server" ResourceIDPage="Text" />
						</td>
						<td class="SettingsSetting">
							<asp:TextBox ID="UserTextLow" runat="server" Columns="35"></asp:TextBox>
						</td>
					</tr>
				</table>
				<table class="TabStripContent">
					<tr>
						<td class="SettingsHeader" colspan="2">
							<STWC:GlobalizedLabel ID="Globalizedlabel13" runat="server" ResourceIDPage="Medium" />
						</td>
					</tr>
					<tr>
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel16" runat="server" ResourceIDGlobal="@Action" />
						</td>
						<td class="SettingsSetting">
							<asp:DropDownList ID="UserActionMed" runat="server" AutoPostBack="True">
							</asp:DropDownList></td>
					</tr>
					<tr id="UserTextMedRow" runat="server">
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel25" runat="server" ResourceIDPage="Text" />
						</td>
						<td class="SettingsSetting">
							<asp:TextBox ID="UserTextMed" runat="server" Columns="35"></asp:TextBox>
						</td>
					</tr>
				</table>
				<table class="TabStripContent">
					<tr>
						<td class="SettingsHeader" colspan="2">
							<STWC:GlobalizedLabel ID="Globalizedlabel14" runat="server" ResourceIDPage="High" />
						</td>
					</tr>
					<tr>
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel17" runat="server" ResourceIDGlobal="@Action" />
						</td>
						<td class="SettingsSetting">
							<asp:DropDownList ID="UserActionHigh" runat="server" AutoPostBack="True" />
						</td>
					</tr>
					<tr id="UserTextHighRow" runat="server">
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel24" runat="server" ResourceIDPage="Text" />
						</td>
						<td class="SettingsSetting">
							<asp:TextBox ID="UserTextHigh" runat="server" Columns="35"></asp:TextBox>
						</td>
					</tr>
				</table>
			</div>
			<div id="OverrideDomainArea" runat="server">
				<table class="TabStripContent" id="tblDecludeHeader" runat="server">
					<tr>
						<td class="SettingsHeader" colspan="2">
							<STWC:GlobalizedLabel ID="Globalizedlabel40" runat="server" ResourceIDGlobal="@Declude" />
						</td>
					</tr>
					<tr>
						<td colspan="2">
							<asp:Label ID="DecludeLabel" runat="server"></asp:Label>
						</td>
					</tr>
				</table>
				<table class="TabStripContent" id="tblSAHeader" runat="server">
					<tr>
						<td class="SettingsHeader" colspan="2">
							<STWC:GlobalizedLabel ID="Globalizedlabel30" runat="server" ResourceIDGlobal="@SpamAssassin" />
						</td>
					</tr>
					<tr>
						<td colspan="2" class="SettingsSettingSingleInd">
							<asp:Label ID="SALabel" runat="server"></asp:Label>
						</td>
					</tr>
				</table>
				<table class="TabStripContent">
					<tr>
						<td class="SettingsHeader">
							<STWC:GlobalizedLabel ID="Globalizedlabel5" runat="server" ResourceIDPage="CurrentWeights" />
						</td>
					</tr>
				</table>
				<STWC:HoverGrid ID="Hovergrid1" runat="server" Width="100%" HG_StandardSettings="True" HG_HoverEnabled="True" HG_EditURLField="editURL" AutoGenerateColumns="False" AllowSorting="True">
					<PagerStyle HorizontalAlign="Right" CssClass="datagridheader" Mode="NumericPages"></PagerStyle>
					<Columns>
						<asp:BoundColumn DataField="SpamCheck" HeaderText="@SpamCheck">
							<itemstyle wrap="False"></itemstyle>
						</asp:BoundColumn>
						<asp:TemplateColumn>
							<headerstyle horizontalalign="Center"></headerstyle>
							<itemstyle horizontalalign="Center"></itemstyle>
							<itemtemplate>
								<input type="text" size="2" width="30" name='<%# DataBinder.Eval(Container.DataItem, "InputName") %>' id='<%# DataBinder.Eval(Container.DataItem, "InputName") %>' value='<%# DataBinder.Eval(Container.DataItem, "Weight") %>' />
							</itemtemplate>
						</asp:TemplateColumn>
					</Columns>
				</STWC:HoverGrid><br />
				<table class="TabStripContent">
					<tr>
						<td class="SettingsHeader" colspan="2">
							<STWC:GlobalizedLabel ID="Globalizedlabel1" runat="server" ResourceIDPage="Low" />
						</td>
					</tr>
					<tr>
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel27" runat="server" ResourceIDGlobal="@Weight" />
						</td>
						<td class="SettingsSetting">
							<asp:TextBox ID="WeightLow" runat="server" Columns="2"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel18" runat="server" ResourceIDGlobal="@Action" />
						</td>
						<td class="SettingsSetting">
							<asp:DropDownList ID="DropDownListLow" runat="server" AutoPostBack="True">
							</asp:DropDownList>
						</td>
					</tr>
					<tr id="SubjectTextLowRow" runat="server">
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel23" runat="server" ResourceIDPage="Text" />
						</td>
						<td class="SettingsSetting">
							<asp:TextBox ID="TextBoxLow" runat="server" Columns="35"></asp:TextBox>
						</td>
					</tr>
				</table>
				<br />
				<table class="TabStripContent">
					<tr>
						<td class="SettingsHeader" colspan="2">
							<STWC:GlobalizedLabel ID="Globalizedlabel2" runat="server" ResourceIDPage="Medium" />
						</td>
					</tr>
					<tr>
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel28" runat="server" ResourceIDGlobal="@Weight" />
						</td>
						<td class="SettingsSetting">
							<asp:TextBox ID="WeightMedium" runat="server" Columns="2"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel19" runat="server" ResourceIDGlobal="@Action" />
						</td>
						<td class="SettingsSetting">
							<asp:DropDownList ID="DropdownlistMedium" runat="server" AutoPostBack="True">
							</asp:DropDownList>
						</td>
					</tr>
					<tr id="SubjectTextMediumRow" runat="server">
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel22" runat="server" ResourceIDPage="Text" />
						</td>
						<td class="SettingsSetting">
							<asp:TextBox ID="TextBoxMed" runat="server" Columns="35"></asp:TextBox>
						</td>
					</tr>
				</table>
				<br />
				<table class="TabStripContent">
					<tr>
						<td class="SettingsHeader" colspan="2">
							<STWC:GlobalizedLabel ID="Globalizedlabel3" runat="server" ResourceIDPage="High" />
						</td>
					</tr>
					<tr>
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel29" runat="server" ResourceIDGlobal="@Weight" />
						</td>
						<td class="SettingsSetting">
							<asp:TextBox ID="WeightHigh" runat="server" Columns="2"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel20" runat="server" ResourceIDGlobal="@Action" />
						</td>
						<td class="SettingsSetting">
							<asp:DropDownList ID="DropdownlistHigh" runat="server" AutoPostBack="True">
							</asp:DropDownList>
						</td>
					</tr>
					<tr id="SubjectTextHighRow" runat="server">
						<td class="SettingsLabelInd">
							<STWC:GlobalizedLabel ID="Globalizedlabel21" runat="server" ResourceIDPage="Text" />
						</td>
						<td class="SettingsSetting">
							<asp:TextBox ID="TextBoxHigh" runat="server" Columns="35"></asp:TextBox>
						</td>
					</tr>
				</table>
			</div>
			<br />
		</radTS:PageView>
		<radTS:PageView ID="TrustedTab" runat="server">
			<div id="UserWhitelistArea" runat="server">
				<table class="TabStripContent">
					<tr>
						<td class="SettingsNote">
							<STWC:GlobalizedLabel ID="Globalizedlabel31" runat="server" ResourceIDPage="TrustedSendersDesc" /><br />
							<STWC:GlobalizedLabel ID="Globalizedlabel32" runat="server" ResourceIDPage="EnterOnePerLine" />
						</td>
					</tr>
					<tr>
						<td class="SettingsSettingSingle">
							<asp:TextBox ID="txtTrustedSenders" runat="server" Columns="50" TextMode="MultiLine" Rows="8"></asp:TextBox>
						</td>
					</tr>
				</table>
			</div>
		</radTS:PageView>
	</radTS:RadMultiPage>
</asp:Content>

