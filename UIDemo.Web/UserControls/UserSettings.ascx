<%@ Control Language="C#" AutoEventWireup="false" Codebehind="UserSettings.ascx.cs" Inherits="SMWeb05.UserControls.UserSettings" %>
<%@ Register Assembly="RadTabStrip.Net2" Namespace="Telerik.WebControls" TagPrefix="radTS" %>
<%@ Register Assembly="RadEditor.Net2" Namespace="Telerik.WebControls" TagPrefix="radE" %>
<table class="TabStrip">
	<tr>
		<td class="TabStrip" id="trTabStrip" runat="server">
			<radTS:RadTabStrip ID="TabStrip" runat="server" MultiPageID="MP1">
				<Tabs>
					<radTS:Tab ID="Tab1" runat="server" Text="#UserControls.UserSettings_UserInformation" PageViewID="pvUserInformation">
					</radTS:Tab>
					<radTS:Tab ID="Tab3" runat="server" Text="#UserControls.UserSettings_DisplaySettings" PageViewID="pvDisplaySettings">
					</radTS:Tab>
					<radTS:Tab ID="Tab4" runat="server" Text="#UserControls.UserSettings_ComposeSettings" PageViewID="pvComposeSettings">
					</radTS:Tab>
					<radTS:Tab ID="Tab2" runat="server" Text="#UserControls.UserSettings_Forwarding" PageViewID="pvForwarding">
					</radTS:Tab>
					<radTS:Tab ID="Tab5" runat="server" Text="@Groups" PageViewID="pvUserGroups">
					</radTS:Tab>
					<radTS:Tab ID="Tab6" runat="server" Text="#UserControls.UserSettings_PlusAddressing" PageViewID="pvPlusAddressing">
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
				<radTS:PageView ID="pvUserInformation" runat="server">
					<table class="TabStripContent">
						<tr runat="server" id="trUsername">
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblUsernameLabel"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<STWC:ValidatedTextBox runat="server" Description="UserName" Columns="10" AllowSpaces="False" RegexOptions="None" ID="txtUserName"></STWC:ValidatedTextBox>
								<asp:Label runat="server" ID="lblUsernameDomain" Font-Bold="True"></asp:Label>
							</td>
						</tr>
						<tr runat="server" id="trAuthSelection">
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblAuthType"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="ddAuthType">
								</asp:DropDownList>
							</td>
						</tr>
						<tr runat="server" id="trAuth_SmarterMail_CurrentPassword">
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblCurrentPasswordLabel"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:Label runat="server" ID="lblCurrentPasswordMask">********</asp:Label>
								<asp:Literal Mode="Encode" runat="server" ID="lblCurrentPassword" Visible="False" />
							</td>
						</tr>
						<tr runat="server" id="trAuth_ChangePassword_CurrentPassword">
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblChangePassword_CurrentPassword"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:TextBox runat="server" TextMode="Password" ID="txtChangePassword_CurrentPassword"></asp:TextBox>
							</td>
						</tr>
						<tr runat="server" id="trAuth_Smartermail_NewPassword">
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblNewPassword"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:TextBox runat="server" TextMode="Password" ID="txtNewPassword"></asp:TextBox>
							</td>
						</tr>
						<tr runat="server" id="trAuth_Smartermail_NewPasswordConfirmed">
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblNewPasswordConfirmed"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:TextBox runat="server" TextMode="Password" ID="txtNewPasswordConfirmed"></asp:TextBox>
							</td>
						</tr>
						<tr runat="server" id="trAuth_ActiveDirectory">
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblWindowsDomainName"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:TextBox runat="server" ID="txtWindowsDomainName"></asp:TextBox>
							</td>
						</tr>
						<tr runat="server" id="trDisplayName">
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblDisplayName"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<STWC:ValidatedTextBox runat="server" Description="UserName" Columns="35" AllowSpaces="False" RegexOptions="None" ID="txtDisplayName"></STWC:ValidatedTextBox>
							</td>
						</tr>
						<tr runat="server" id="trReplyToAddress">
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblReplyToAddress"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<STWC:ValidatedTextBox runat="server" Columns="35" RegexOptions="None" ID="txtReplyToAddress"></STWC:ValidatedTextBox>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblTimeZone"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="ddTimeZone">
								</asp:DropDownList>
							</td>
						</tr>
						<tr runat="server" id="trMailboxSize">
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblMailboxSize"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<STWC:ValidatedTextBox runat="server" CheckIsPositiveInt="True" Description="Maximum size" Columns="5" RegexOptions="None" ID="txtMaxMailboxSize"></STWC:ValidatedTextBox>
								&nbsp;
								<asp:Label runat="server" ID="lblMegabyte"></asp:Label>
								<asp:Label runat="server" ID="lblCurrentSize"></asp:Label>
							</td>
						</tr>
						<tr runat="server" id="trDisableUser">
							<td class="SettingsLabel">
								&nbsp;</td>
							<td class="SettingsSetting">
								<asp:CheckBox runat="server" ID="chkDisabled"></asp:CheckBox>
							</td>
						</tr>
						<tr runat="server" id="trDomainAdmin">
							<td class="SettingsLabel">
								&nbsp;</td>
							<td class="SettingsSetting">
								<asp:CheckBox runat="server" ID="chkDomainAdmin"></asp:CheckBox>
							</td>
						</tr>
						<tr runat="server" id="trAuth_Smartermail_LockPassword">
							<td class="SettingsLabel">
								&nbsp;</td>
							<td class="SettingsSetting">
								<asp:CheckBox runat="server" ID="chkLockPassword"></asp:CheckBox>
							</td>
						</tr>
						<tr runat="server" id="trHideUserFromLdap">
							<td class="SettingsLabel">
								&nbsp;</td>
							<td class="SettingsSetting">
								<asp:CheckBox runat="server" ID="chkHideUserFromLdap"></asp:CheckBox>
							</td>
						</tr>
						<tr runat="server" id="trEnablePopRetrieval">
							<td class="SettingsLabel">
								&nbsp;</td>
							<td class="SettingsSetting">
								<asp:CheckBox runat="server" ID="chkEnablePopRetrieval"></asp:CheckBox>
							</td>
						</tr>
						<tr runat="server" id="trDisableGreylisting">
							<td class="SettingsLabel">
								&nbsp</td>
							<td class="SettingsSetting">
								<asp:CheckBox runat="server" ID="chkDisableGreylisting"></asp:CheckBox>
							</td>
						</tr>
					</table>
				</radTS:PageView>
				<radTS:PageView ID="pvForwarding" runat="server">
					<table class="TabStripContent">
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblForwardingAddress"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<STWC:ValidatedTextBox runat="server" Columns="35" RegexOptions="None" ID="txtForwardingAddress"></STWC:ValidatedTextBox>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblSpamForwardingOption"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="ddSpamForwardingOption">
								</asp:DropDownList>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
							</td>
							<td class="SettingsSetting">
								<asp:CheckBox runat="server" ID="chkDeleteMessageOnForward"></asp:CheckBox>
							</td>
						</tr>
					</table>
				</radTS:PageView>
				<radTS:PageView ID="pvPlusAddressing" runat="server">
					<table class="TabStripContent">
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblPlusEnabled"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:CheckBox runat="server" ID="chkPlusEnabled"></asp:CheckBox>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblPlusAction"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="ddPlusAction">
								</asp:DropDownList>
							</td>
						</tr>
					</table>
				</radTS:PageView>
				<radTS:PageView ID="pvDisplaySettings" runat="server">
					<table class="TabStripContent">
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblSortMessagesBy"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="ddSortMessagesBy">
								</asp:DropDownList>
								<asp:CheckBox runat="server" ID="chkSortMessagesDescending"></asp:CheckBox>
							</td>
						</tr>
						<tr style="display: none">
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblSortFoldersBy"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="ddSortFolderBy">
								</asp:DropDownList>
								<asp:CheckBox runat="server" ID="chkSortFoldersDescending"></asp:CheckBox>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<STWC:GlobalizedLabel runat="server" EnableViewState="False" ResourceIDGlobal="UserControls.UserSettings_UseAjax" Auto="False" ID="Globalizedlabel2" />
							</td>
							<td class="SettingsSetting">
								<asp:CheckBox runat="server" ID="chkAjax"></asp:CheckBox>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<STWC:GlobalizedLabel runat="server" EnableViewState="False" ResourceIDGlobal="UserControls.UserSettings_AutoPreview" Auto="False" ID="Globalizedlabel1" />
							</td>
							<td class="SettingsSetting">
								<asp:CheckBox runat="server" ID="chkAutoPreview"></asp:CheckBox>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblMessagesPerPage"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<STWC:ValidatedTextBox runat="server" CheckIsPositiveInt="True" Description="Messages per page" Columns="4" RegexOptions="None" ID="txtMessagesPerPage"></STWC:ValidatedTextBox>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblRefreshRate"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="ddRefreshRate">
								</asp:DropDownList>
								&nbsp;
								<asp:Label runat="server" ID="lblMinutes"></asp:Label>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblDisplayMessagesAs"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="ddDisplayMessagesAs">
								</asp:DropDownList>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblDeletedMessages"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="ddDeletedMessages">
								</asp:DropDownList>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
							</td>
							<td class="SettingsSetting">
								<asp:CheckBox runat="server" ID="chkEnableAnimations"></asp:CheckBox>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
							</td>
							<td class="SettingsSetting">
								<STWC:GlobalizedCheckbox runat="server" ID="chkScrollMenu" ResourceIDGlobal="UserControls.UserSettings_ScrollMenu" />
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<STWC:GlobalizedLabel ID="GlobalizedLabel3" runat="server" ResourceIDGlobal="UserControls.UserSettings_StartupPage" />
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="StartupPageList">
								</asp:DropDownList>
							</td>
						</tr>
						<tr id="trSkin" runat="server">
							<td class="SettingsLabel">
								<STWC:GlobalizedLabel runat="server" ResourceIDGlobal="@Skin" EnableViewState="False" Auto="False" ID="lblSkins" />
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="lstSkins">
								</asp:DropDownList>
							</td>
						</tr>
					</table>
				</radTS:PageView>
				<radTS:PageView ID="pvComposeSettings" runat="server">
					<table class="TabStripContent">
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblSpellCheckDictionary"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="ddSpellCheckDictionary">
								</asp:DropDownList>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblComposeAs"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="ddComposeAs">
								</asp:DropDownList>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblTextEncoding"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="ddTextEncoding">
								</asp:DropDownList>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblForwardingMethod"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="ddForwardingMethod">
								</asp:DropDownList>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblReplyHeaderType"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:DropDownList runat="server" ID="ddReplyHeaderType">
								</asp:DropDownList>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblReplyIndicator"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<asp:TextBox runat="server" Columns="4" ID="txtReplyIndicator"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								&nbsp;</td>
							<td class="SettingsSetting">
								<asp:CheckBox runat="server" ID="chkEmbedReplies"></asp:CheckBox>
							</td>
						</tr>
						<tr>
							<td class="SettingsLabel">
								&nbsp;</td>
							<td class="SettingsSetting">
								<asp:CheckBox runat="server" ID="chkSaveSentItems"></asp:CheckBox>
							</td>
						</tr>
						<tr runat="server" id="trSignature">
							<td class="SettingsLabel">
								<asp:Label runat="server" ID="lblSignature"></asp:Label>
							</td>
							<td class="SettingsSetting">
								<radE:RadEditor runat="server" ID="RadText" Width="50%" Height="250px">
								</radE:RadEditor>
								<div class="ComposeBox">
									<asp:TextBox ID="PlainText" runat="server" TextMode="MultiLine" Width="70%" Columns="80"></asp:TextBox>
								</div>
							</td>
						</tr>
					</table>
				</radTS:PageView>
				<radTS:PageView ID="pvUserGroups" runat="server">
					<table class="TabStripContent">
						<tr>
							<td class="SettingsSettingSingle">
								<asp:Panel runat="server" ID="pnlUserGroups">
								</asp:Panel>
								<asp:Label runat="server" ID="lblNoUserGroupsMessage"></asp:Label>
							</td>
						</tr>
					</table>
				</radTS:PageView>
			</radTS:RadMultiPage>
		</td>
	</tr>
</table>
