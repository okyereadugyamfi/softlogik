<%@ Control Language="C#" AutoEventWireup="false" Codebehind="ReportItem.ascx.cs" Inherits="SMWeb05.UserControls.ReportItem" %>
<table class="TabStripContent">
	<tr>
		<td class="SettingsLabel">
			<STWC:GlobalizedLabel runat="server" ResourceIDPage="ChartName" ID="Globalizedlabel1" />
		</td>
		<td class="SettingsSetting">
			<asp:TextBox runat="server" Rows="1" Columns="25" ID="txtChart1Name"></asp:TextBox>
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			<STWC:GlobalizedLabel runat="server" ResourceIDPage="TimeOffset" ID="Globalizedlabel2" />
		</td>
		<td class="SettingsSetting">
			<asp:TextBox runat="server" Rows="1" Columns="3" ID="txtChart1TimeOffset"></asp:TextBox>&nbsp;
			<asp:DropDownList runat="server" ID="ddChart1OffsetType" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			<STWC:GlobalizedLabel runat="server" ResourceIDPage="TimeSpan" ID="Globalizedlabel3" />
		</td>
		<td class="SettingsSetting">
			<asp:DropDownList runat="server" ID="ddChart1TimeSpan" />
		</td>
	</tr>
</table>
<table class="TabStripContentSmall">
	<tr>
		<td class="SettingsLabel">
			<STWC:GlobalizedLabel runat="server" ResourceIDPage="ReportItems" ID="Globalizedlabel4" />
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1CPU" ResourceIDPage="CPU" />
		</td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1CPUColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1Memory" ResourceIDPage="Memory" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1MemoryColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1SMTP" ResourceIDPage="SMTP" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1SMTPColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1POP" ResourceIDPage="POP" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1POPColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1IMAP" ResourceIDPage="IMAP" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1IMAPColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1Delivery" ResourceIDPage="Delivery" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1DeliveryColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1POPRet" ResourceIDPage="POPRetrieval" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1POPRetColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1SpoolCount" ResourceIDPage="SpoolCount" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1SpoolCountColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1SpamCount" ResourceIDPage="SpamCount" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1SpamCountColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1VirusCount" ResourceIDPage="VirusCount" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1VirusCountColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1LocalMessages" ResourceIDPage="LocalMessages" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1LocalMessagesColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1RemoteMessages" ResourceIDPage="RemoteMessages" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1RemoteMessagesColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1TotalMessages" ResourceIDPage="TotalMessages" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1TotalMessagesColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1OnlineUsers" ResourceIDPage="OnlineUsers" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1OnlineUsersColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1BlockedPOP" ResourceIDPage="BlockedPOP" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1BlockedPOPColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1BlockedSMTP" ResourceIDPage="BlockedSMTP" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1BlockedSMTPColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1BlockedIMAP" ResourceIDPage="BlockedIMAP" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1BlockedIMAPColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1BlockedPOPIP" ResourceIDPage="BlockedPOPIP" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1BlockedPOPIPColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1BlockedSMTPIP" ResourceIDPage="BlockedSMTPIP" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1BlockedSMTPIPColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1BlockedIMAPIP" ResourceIDPage="BlockedIMAPIP" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1BlockedIMAPIPColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1SpamHigh" ResourceIDPage="SpamHigh" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1SpamHighColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1SpamMed" ResourceIDPage="SpamMed" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1SpamMedColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1SpamLow" ResourceIDPage="SpamLow" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1SpamLowColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1GreyListBlock" ResourceIDPage="GreylistBlocked" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1GreyListBlockColor" />
		</td>
	</tr>
	<tr>
		<td class="SettingsLabel">
			&nbsp;
		</td>
		<td class="SettingsSetting">
			<STWC:GlobalizedCheckbox runat="server" ID="chkChart1GreyListAllow" ResourceIDPage="GreylistAllowed" /></td>
		<td>
			<asp:DropDownList runat="server" ID="chkChart1GreyListAllowColor" />
		</td>
	</tr>
</table>
