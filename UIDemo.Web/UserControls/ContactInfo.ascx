<%@ Control Language="C#" AutoEventWireup="false" Codebehind="ContactInfo.ascx.cs" Inherits="SMWeb05.UserControls.ContactInfo" %>
<%@ Register Assembly="RadTabStrip.Net2" Namespace="Telerik.WebControls" TagPrefix="radTS" %>

<script type="text/javascript">
<!--
	function ShowAdvancedNameHideBasic()
	{
		document.getElementById('tblrowAdvancedName1').style.display = '';
		document.getElementById('tblrowAdvancedName2').style.display = '';
		document.getElementById('tblrowAdvancedName3').style.display = '';
		document.getElementById('tblrowAdvancedName4').style.display = '';
		document.getElementById('tblrowAdvancedName5').style.display = '';
		document.getElementById('tblrowBasicName').style.display = 'none';
	}
	
	function ShowBasicNameHideAdvanced()
	{
		document.getElementById('tblrowAdvancedName1').style.display = 'none';
		document.getElementById('tblrowAdvancedName2').style.display = 'none';
		document.getElementById('tblrowAdvancedName3').style.display = 'none';
		document.getElementById('tblrowAdvancedName4').style.display = 'none';
		document.getElementById('tblrowAdvancedName5').style.display = 'none';
		document.getElementById('tblrowBasicName').style.display = '';
	}
//-->
</script>
			


<table class="TabStrip">
	<tr>
		<td class="TabStrip" id="trTabStrip" runat="server">
			<radTS:RadTabStrip ID="TabStrip" runat="server" >
				<Tabs>
					<radTS:Tab ID="Tab1" runat="server" Text="#UserControls.ContactInfo_BasicInformation" PageViewID="pvBasicInfo">
					</radTS:Tab>
					<radTS:Tab ID="Tab2" runat="server" Text="#UserControls.ContactInfo_ContactInformation" PageViewID="pvContactInfo">
					</radTS:Tab>
					<radTS:Tab ID="Tab3" runat="server" Text="#UserControls.ContactInfo_CompanyInformation" PageViewID="pvCompanyInfo">
					</radTS:Tab>
					<radTS:Tab ID="Tab4" runat="server" Text="#UserControls.ContactInfo_Categories" PageViewID="pvCategories">
					</radTS:Tab>
				</Tabs>
			</radTS:RadTabStrip>
		</td>
	</tr>
	<tr>
		<td class="TabStripBreak" id="trTabStripBreak" runat="server">
			<SMWC:Spacer runat="server" ID="Spacer1" Height="31" Width="1" />
		</td>
	</tr>
	<tr>
		<td class="InnerPageContent" style="padding-top: 0px;">
			<radTS:RadMultiPage ID="MP1" runat="server">
				<radTS:PageView ID="pvBasicInfo" runat="server">
					<table class="TabStripContent">
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblDisplayAs" runat="server"></asp:Label>
							</td>
							<td colspan="2" class="SettingsSetting">
								<asp:TextBox ID="txtDisplayAs" Columns="25" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr id="tblrowBasicName">
							<td class="SettingsLabel">
								<asp:Label ID="lblFullName" runat="server"></asp:Label>
							</td>
							<td colspan="2" class="SettingsSetting">
								<asp:TextBox ID="txtFullName" Columns="25" runat="server"></asp:TextBox>&nbsp; <a id="lnkAdvancedName" runat="server" onclick="javascript:ShowAdvancedNameHideBasic();" style="text-decoration: underline; cursor: hand;"></a>
							</td>
						</tr>
						<tr id="tblrowAdvancedName1" style="display: none">
							<td class="SettingsLabel">
								<asp:Label ID="lblPersonNameTitle" runat="server"></asp:Label>
							</td>
							<td colspan="2" class="SettingsSetting">
								<asp:TextBox ID="txtPersonNameTitle" Columns="25" runat="server"></asp:TextBox>&nbsp; <a id="lnkBasicName" runat="server" onclick="javascript:ShowBasicNameHideAdvanced();" style="text-decoration: underline; cursor: hand;"></a>
							</td>
						</tr>
						<tr id="tblrowAdvancedName2" style="display: none">
							<td class="SettingsLabel">
								<asp:Label ID="lblFirstName" runat="server"></asp:Label>
							</td>
							<td colspan="2" class="SettingsSetting">
								<asp:TextBox ID="txtFirstName" Columns="25" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr id="tblrowAdvancedName3" style="display: none">
							<td class="SettingsLabel">
								<asp:Label ID="lblMiddleName" runat="server"></asp:Label>
							</td>
							<td colspan="2" class="SettingsSetting">
								<asp:TextBox ID="txtMiddleName" Columns="25" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr id="tblrowAdvancedName4" style="display: none">
							<td class="SettingsLabel">
								<asp:Label ID="lblLastName" runat="server"></asp:Label>
							</td>
							<td colspan="2" class="SettingsSetting">
								<asp:TextBox ID="txtLastName" Columns="25" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr id="tblrowAdvancedName5" style="display: none">
							<td class="SettingsLabel">
								<asp:Label ID="lblPersonNameSuffix" runat="server"></asp:Label>
							</td>
							<td colspan="2" class="SettingsSetting">
								<asp:TextBox ID="txtPersonNameSuffix" Columns="25" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblEmailAddress" runat="server"></asp:Label>
							</td>
							<td colspan="2" class="SettingsSetting">
								<STWC:ValidatedTextBox ID="txtEmailAddress" runat="server" Columns="25" Description="Email Address" CheckIsEmail="True"></STWC:ValidatedTextBox>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblInstantMessenger" runat="server"></asp:Label>
							</td>
							<td colspan="2" class="SettingsSetting">
								<asp:TextBox ID="txtInstantMessenger" Columns="25" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblPersonalWebsite" runat="server"></asp:Label>
							</td>
							<td colspan="2" class="SettingsSetting">
								<asp:TextBox ID="txtWebPage" Columns="25" runat="server">http://</asp:TextBox>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblBirthDate" runat="server"></asp:Label>
							</td>
							<td colspan="2" class="SettingsSetting">
								<SMWC:PopupCalendar runat="server" FormName="aspnetForm" ID="calBirthDate"></SMWC:PopupCalendar>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblAdditionalInfo" runat="server"></asp:Label>
							</td>
							<td colspan="2" class="SettingsSetting">
								<asp:TextBox ID="txtAdditionalInfo" Columns="35" runat="server" Height="40" TextMode="MultiLine"></asp:TextBox>
							</td>
						</tr>
					</table>
				</radTS:PageView>
				<radTS:PageView ID="pvContactInfo" runat="server">
					<table class="TabStripContent">
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblHomePhone" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtHomePhone" Columns="25" runat="server"></asp:TextBox></td>
							<td class="SettingsLabel">
								<asp:Label ID="lblWorkPhone" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtCompanyPhone" Columns="25" runat="server"></asp:TextBox></td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblMobilePhone" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtMobilePhone" Columns="25" runat="server"></asp:TextBox></td>
							<td class="SettingsLabel">
								<asp:Label ID="lblCompanyPager" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtCompanyPager" Columns="25" runat="server"></asp:TextBox></td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblHomeFax" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtHomeFax" Columns="25" runat="server"></asp:TextBox></td>
							<td class="SettingsLabel">
								<asp:Label ID="lblCompanyFax" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtCompanyFax" Columns="25" runat="server"></asp:TextBox></td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblCompanyIpPhone" runat="server"></asp:Label></td>
							<td class="SettingsSetting" colspan="3">
								<asp:TextBox ID="txtCompanyIpPhone" Columns="25" runat="server"></asp:TextBox></td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblHomeCity" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtHomeCity" Columns="25" runat="server"></asp:TextBox></td>
							<td class="SettingsLabel">
								<asp:Label ID="lblHomeState" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtHomeState" Columns="25" runat="server"></asp:TextBox></td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblHomeZip" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtHomeZip" Columns="25" runat="server"></asp:TextBox></td>
							<td class="SettingsLabel">
								<asp:Label ID="lblHomeCountry" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtHomeCountry" Columns="25" runat="server"></asp:TextBox></td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblHomeAddress" runat="server"></asp:Label></td>
							<td class="SettingsSetting" colspan="3">
								<asp:TextBox ID="txtHomeStreet" Columns="35" Height="60" runat="server" TextMode="MultiLine"></asp:TextBox></td>
						</tr>
					</table>
				</radTS:PageView>
				<radTS:PageView ID="pvCompanyInfo" runat="server">
					<table class="TabStripContent">
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblCompanyName" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtCompanyName" Columns="25" runat="server"></asp:TextBox></td>
							<td class="SettingsLabel">
								<asp:Label ID="lblJobTitle" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtJobTitle" Columns="25" runat="server"></asp:TextBox></td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblCompanyDepartment" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtCompanyDepartment" Columns="25" runat="server"></asp:TextBox></td>
							<td class="SettingsLabel">
								<asp:Label ID="lblCompanyOffice" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtCompanyOffice" Columns="25" runat="server"></asp:TextBox></td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblCompanyCity" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtCompanyCity" Columns="25" runat="server"></asp:TextBox></td>
							<td class="SettingsLabel">
								<asp:Label ID="lblCompanyState" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtCompanyState" Columns="25" runat="server"></asp:TextBox></td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblCompanyZip" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtCompanyZip" Columns="25" runat="server"></asp:TextBox></td>
							<td class="SettingsLabel">
								<asp:Label ID="lblCompanyCountry" runat="server"></asp:Label></td>
							<td class="SettingsSetting">
								<asp:TextBox ID="txtCompanyCountry" Columns="25" runat="server"></asp:TextBox></td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblCompanyUrl" runat="server"></asp:Label></td>
							<td class="SettingsSetting" colspan="3">
								<asp:TextBox ID="txtCompanyUrl" Columns="25" runat="server">http://</asp:TextBox></td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label ID="lblCompanyAddress" runat="server"></asp:Label></td>
							<td class="SettingsSetting" colspan="3">
								<asp:TextBox ID="txtCompanyStreet" runat="server" Height="60" Columns="35" TextMode="MultiLine"></asp:TextBox></td>
						</tr>
					</table>
				</radTS:PageView>
				<radTS:PageView ID="pvCategories" runat="server">
					<asp:Table CssClass="TabStripContent" runat="server" ID="tblCategories" Width="80%">
					</asp:Table>
					<asp:TextBox runat="server" ID="txtCategoryCount" Visible="False"></asp:TextBox>
					<asp:TextBox runat="server" ID="txtCategories" Visible="False"></asp:TextBox>
				</radTS:PageView>
			</radTS:RadMultiPage>
			<table cellpadding="1" width="100%" id="tblContactGroupsList" runat="server">
				<tr>
					<td>
						<asp:Panel ID="pnlContactGroups" runat="server">
						</asp:Panel>
						<asp:Label ID="lblNoContactGroupsMessage" runat="server"></asp:Label>
					</td>
				</tr>
			</table>
			<asp:Label ID="lblContactID" Visible="False" runat="server"></asp:Label>
			<asp:Label ID="lblRedirUrl" runat="server" Visible="False"></asp:Label>
			<asp:Literal ID="JavascriptLiteral" runat="server"></asp:Literal>
		</td>
	</tr>
</table>
