<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmContentFilters.aspx.cs" Inherits="SMWeb05.Main.frmContentFilters"  %>

<%@ Register Assembly="RadTreeView.Net2" Namespace="Telerik.WebControls" TagPrefix="radT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<div id="divView" runat="server">
		<SMWC:SkinTextImageButton ID="AddRuleImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Add.png" ResourceIDPage="AddRule" NavigateURL="frmContentFilters.aspx?add=true"></SMWC:SkinTextImageButton>
		<SMWC:SkinTextImageButton ID="DeleteAllImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/trash.png" ResourceIDGlobal="@DeleteAll"></SMWC:SkinTextImageButton>
	</div>
	<div id="divAdd" runat="server">
		<SMWC:SkinTextImageButton ID="BackImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/previous.png" ResourceIDGlobal="@Back"></SMWC:SkinTextImageButton>
		<SMWC:SkinTextImageButton ID="NextImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/next.png" ResourceIDGlobal="@Next"></SMWC:SkinTextImageButton>
		<SMWC:SkinTextImageButton ID="SaveTextImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/save.png" ResourceIDGlobal="@Save"></SMWC:SkinTextImageButton>
	</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<div id="cnlAdd" runat="server">
		<SMWC:SkinTextImageButton ID="CancelImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Cancel_close.png" NavigateURL="frmContentFilters.aspx" ResourceIDGlobal="@Cancel"></SMWC:SkinTextImageButton>
	</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">
	<asp:Literal ID="DeleteAllLiteral" runat="server"></asp:Literal>
	<div id="tblView" runat="server">
		<STWC:HoverGrid ID="HoverGridResults" runat="server" AllowSorting="True" AutoGenerateColumns="False" Width="100%" HG_HoverEnabled="True" HG_StandardSettings="True" HG_EditURLField="EditURL" HG_ColumnExclusionIndexes="0,3">
			<PagerStyle CssClass="pager" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
			<Columns>
				<asp:BOUNDCOLUMN DataField="NavLinks"></asp:BOUNDCOLUMN>
				<asp:BOUNDCOLUMN DataField="Rule"></asp:BOUNDCOLUMN>
				<asp:BOUNDCOLUMN DataField="Action"></asp:BOUNDCOLUMN>
				<asp:BOUNDCOLUMN DataField="DeleteLink">
					<itemstyle horizontalalign="Right"></itemstyle>
				</asp:BOUNDCOLUMN>
			</Columns>
		</STWC:HoverGrid>
	</div>
	<div id="tblAdd" runat="server">
		<table class="SettingsContent" id="TablePickFilters" runat="server">
			<tr>
				<td class="SettingsSettingSingle">
					<radT:RadTreeView ID="RadTV" runat="server">
					</radT:RadTreeView>
				</td>
			</tr>
		</table>
		<table class="SettingsContent" id="TableDetails" runat="server" visible="false">
			<tr>
				<td class="SettingsSettingSingle">
					<asp:RadioButton ID="GroupTypeAnd" runat="server" Text="$FilterTypeAnd" GroupName="filtertypegroup" Checked="True"></asp:RadioButton>
				</td>
			</tr>
			<tr>
				<td class="SettingsSettingSingle">
					<asp:RadioButton ID="GroupTypeOr" runat="server" Text="$FilterTypeOr" GroupName="filtertypegroup"></asp:RadioButton>
				</td>
			</tr>
			<tr>
				<td class="SettingsSettingSingle">
					<asp:CheckBox ID="AllowWildcards" runat="server"></asp:CheckBox>
				</td>
			</tr>
		</table>
		<table class="TabStripContent" id="TableDetails2" runat="server" visible="false">
			<tr id="DetailHeaderFrom" runat="server">
				<td class="SettingsHeader" colspan="2">
					<STWC:GlobalizedLabel ID="Globalizedlabel3" runat="server" ResourceIDPage="FromAddress" />
				</td>
			</tr>
			<tr id="DetailFromAddress" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel18" runat="server" ResourceIDPage="FromAddresses" /><br />
					<STWC:GlobalizedLabel ID="Globalizedlabel4" runat="server" ResourceIDGlobal="@OnePerLine" /></td>
				<td class="SettingsSetting">
					<p>
						<asp:DropDownList ID="ddFromAddress" runat="server">
						</asp:DropDownList><br />
						<asp:TextBox ID="txtFromAddresses" runat="server" Rows="8" Columns="35" TextMode="MultiLine" Wrap="False"></asp:TextBox></p>
				</td>
			</tr>
			<tr id="DetailFromDomain" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel19" runat="server" ResourceIDPage="FromDomains" /><br />
					<STWC:GlobalizedLabel ID="Globalizedlabel5" runat="server" ResourceIDGlobal="@OnePerLine" /></td>
				<td class="SettingsSetting">
					<p>
						<asp:DropDownList ID="ddFromDomain" runat="server">
						</asp:DropDownList><br />
						<asp:TextBox ID="txtFromDomains" runat="server" Rows="8" Columns="35" TextMode="MultiLine" Wrap="False"></asp:TextBox></p>
				</td>
			</tr>
			<tr id="DetailFromTrustedSender" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel62" runat="server" ResourceIDPage="FromTrustedSender" /></td>
				<td class="SettingsSetting">
				</td>
			</tr>
			<tr id="DetailHeaderWords" runat="server">
				<td class="SettingsHeader" colspan="2">
					<STWC:GlobalizedLabel ID="Globalizedlabel20" runat="server" ResourceIDPage="ContainsWordsOrPhrases" />
				</td>
			</tr>
			<tr id="DetailWordsInSubject" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel21" runat="server" ResourceIDGlobal="@Subject" /><br />
					<STWC:GlobalizedLabel ID="Globalizedlabel6" runat="server" ResourceIDGlobal="@OnePerLine" /></td>
				<td class="SettingsSetting">
					<asp:DropDownList ID="ddContainsWordsInSubject" runat="server">
					</asp:DropDownList><br />
					<asp:TextBox ID="txtWordsInSubject" runat="server" Rows="8" Columns="35" TextMode="MultiLine" Wrap="False"></asp:TextBox>
				</td>
			</tr>
			<tr id="DetailWordsInBody" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel22" runat="server" ResourceIDPage="BodyText" /><br />
					<STWC:GlobalizedLabel ID="Globalizedlabel7" runat="server" ResourceIDGlobal="@OnePerLine" /></td>
				<td class="SettingsSetting">
					<asp:DropDownList ID="ddContainsWordsInBody" runat="server">
					</asp:DropDownList><br />
					<asp:TextBox ID="txtWordsInBody" runat="server" Rows="8" Columns="35" TextMode="MultiLine" Wrap="False"></asp:TextBox>
				</td>
			</tr>
			<tr id="DetailWordsInSubjectOrBody" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel23" runat="server" ResourceIDPage="SubjectOrBodyText" /><br />
					<STWC:GlobalizedLabel ID="Globalizedlabel9" runat="server" ResourceIDGlobal="@OnePerLine" />
				</td>
				<td class="SettingsSetting">
					<asp:DropDownList ID="ddContainsWordsInSubjectOrBody" runat="server">
					</asp:DropDownList><br />
					<asp:TextBox ID="txtWordsInSubjectOrBody" runat="server" Rows="8" Columns="35" TextMode="MultiLine" Wrap="False"></asp:TextBox>
				</td>
			</tr>
			<tr id="DetailWordsInFrom" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel24" runat="server" ResourceIDPage="FromAddress" /><br />
					<STWC:GlobalizedLabel ID="Globalizedlabel10" runat="server" ResourceIDGlobal="@OnePerLine" /></td>
				<td class="SettingsSetting">
					<asp:DropDownList ID="ddContainsWordsInFromAddress" runat="server">
					</asp:DropDownList><br />
					<asp:TextBox ID="txtWordsInFrom" runat="server" Rows="8" Columns="35" TextMode="MultiLine" Wrap="False"></asp:TextBox>
				</td>
			</tr>
			<tr id="DetailWordsInTo" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel25" runat="server" ResourceIDPage="ToAddress" /><br />
					<STWC:GlobalizedLabel ID="Globalizedlabel11" runat="server" ResourceIDGlobal="@OnePerLine" />
				</td>
				<td class="SettingsSetting">
					<asp:DropDownList ID="ddContainsWordsInToAddress" runat="server">
					</asp:DropDownList><br />
					<asp:TextBox ID="txtWordsInTo" runat="server" Rows="8" Columns="35" TextMode="MultiLine" Wrap="False"></asp:TextBox>
				</td>
			</tr>
			<tr id="DetailWordsInHeaders" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel26" runat="server" ResourceIDPage="EmailHeaders" /><br />
					<STWC:GlobalizedLabel ID="Globalizedlabel12" runat="server" ResourceIDGlobal="@OnePerLine" /></td>
				<td class="SettingsSetting">
					<asp:DropDownList ID="ddContainsWordsInHeaders" runat="server">
					</asp:DropDownList><br />
					<asp:TextBox ID="txtWordsInHeaders" runat="server" Rows="8" Columns="35" TextMode="MultiLine" Wrap="False"></asp:TextBox>
				</td>
			</tr>
			<tr id="DetailWordsInMessage" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel27" runat="server" ResourceIDPage="AnywhereInMessage" /><br />
					<STWC:GlobalizedLabel ID="Globalizedlabel13" runat="server" ResourceIDGlobal="@OnePerLine" /></td>
				<td class="SettingsSetting">
					<asp:DropDownList ID="ddContainsWordsInMessage" runat="server">
					</asp:DropDownList><br />
					<asp:TextBox ID="txtWordsInMessage" runat="server" Rows="8" Columns="35" TextMode="MultiLine" Wrap="False"></asp:TextBox>
				</td>
			</tr>
			<tr id="DetailHeaderTo" runat="server">
				<td class="SettingsHeader" colspan="2">
					<STWC:GlobalizedLabel ID="Globalizedlabel28" runat="server" ResourceIDPage="ToAddress" />
				</td>
			</tr>
			<tr id="DetailToAddress" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel30" runat="server" ResourceIDPage="ToAddresses" /><br />
					<STWC:GlobalizedLabel ID="Globalizedlabel14" runat="server" ResourceIDGlobal="@OnePerLine" />
				</td>
				<td class="SettingsSetting">
					<asp:DropDownList ID="ddToAddress" runat="server">
					</asp:DropDownList><br />
					<asp:TextBox ID="txtToAddress" runat="server" Rows="8" Columns="35" TextMode="MultiLine" Wrap="False"></asp:TextBox>
				</td>
			</tr>
			<tr id="DetailToDomain" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel29" runat="server" ResourceIDPage="ToDomains" /><br />
					<STWC:GlobalizedLabel ID="Globalizedlabel15" runat="server" ResourceIDGlobal="@OnePerLine" />
				</td>
				<td class="SettingsSetting">
					<asp:DropDownList ID="ddToDomain" runat="server">
					</asp:DropDownList><br />
					<asp:TextBox ID="txtToDomain" runat="server" Rows="8" Columns="35" TextMode="MultiLine" Wrap="False"></asp:TextBox>
				</td>
			</tr>
			<tr id="DetailToMe" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel31" runat="server" ResourceIDPage="OnlyToMe" />
				</td>
				<td class="SettingsSetting">
				</td>
			</tr>
			<tr id="DetailMyNameInTo" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel32" runat="server" ResourceIDPage="MyAddressInToField" />
				</td>
				<td class="SettingsSetting">
				</td>
			</tr>
			<tr id="DetailMyNameNotInTo" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel33" runat="server" ResourceIDPage="MyAddressNotInToField" />
				</td>
				<td class="SettingsSetting">
				</td>
			</tr>
			<tr id="DetailMyNameInToOrCC" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel34" runat="server" ResourceIDPage="MyAddressInToOrCCField" />
				</td>
				<td class="SettingsSetting">
				</td>
			</tr>
			<tr id="DetailHeaderAtt" runat="server">
				<td class="SettingsHeader" colspan="2">
					<STWC:GlobalizedLabel ID="Globalizedlabel35" runat="server" ResourceIDPage="Attachments" />
				</td>
			</tr>
			<tr id="DetailAttHas" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel36" runat="server" ResourceIDPage="HasAnyAttachment" />
				</td>
				<td class="SettingsSetting">
				</td>
			</tr>
			<tr id="DetailAttFilename" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel37" runat="server" ResourceIDPage="SpecificFilenames" /><br />
					<STWC:GlobalizedLabel ID="Globalizedlabel16" runat="server" ResourceIDGlobal="@OnePerLine" />
				</td>
				<td class="SettingsSetting">
					<asp:DropDownList ID="ddAttFilename" runat="server">
					</asp:DropDownList><br />
					<asp:TextBox ID="txtAttFilename" runat="server" Rows="8" Columns="35" TextMode="MultiLine" Wrap="False"></asp:TextBox>
				</td>
			</tr>
			<tr id="DetailAttExtension" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel38" runat="server" ResourceIDPage="SpecificExtensions" /><br />
					<STWC:GlobalizedLabel ID="Globalizedlabel17" runat="server" ResourceIDGlobal="@OnePerLine" />
				</td>
				<td class="SettingsSetting">
					<asp:DropDownList ID="ddAttExtension" runat="server">
					</asp:DropDownList><br />
					<asp:TextBox ID="txtAttExtension" runat="server" Rows="8" Columns="35" TextMode="MultiLine" Wrap="False"></asp:TextBox>
				</td>
			</tr>
			<tr id="DetailAttSize" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel39" runat="server" ResourceIDPage="OverSpecificSize" />
				</td>
				<td class="SettingsSetting">
					<asp:TextBox ID="txtAttSize" runat="server"></asp:TextBox>KB</td>
			</tr>
			<tr id="DetailHeaderOther" runat="server">
				<td class="SettingsHeader" colspan="2">
					<STWC:GlobalizedLabel ID="Globalizedlabel40" runat="server" ResourceIDPage="Other" />
				</td>
			</tr>
			<tr id="DetailPriorityHigh" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel41" runat="server" ResourceIDPage="HighPriority" />
				</td>
				<td class="SettingsSetting">
				</td>
			</tr>
			<tr id="DetailPriorityNormal" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel42" runat="server" ResourceIDPage="NormalPriority" />
				</td>
				<td class="SettingsSetting">
				</td>
			</tr>
			<tr id="DetailPriorityLow" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel43" runat="server" ResourceIDPage="LowPriority" />
				</td>
				<td class="SettingsSetting">
				</td>
			</tr>
			<tr id="DetailAutomatedMessage" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel44" runat="server" ResourceIDPage="AutomatedMessage" />
				</td>
				<td class="SettingsSetting">
				</td>
			</tr>
			<tr id="DetailMessageSizeOver" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel45" runat="server" ResourceIDPage="MessageOverSize" />
				</td>
				<td class="SettingsSetting">
					<asp:TextBox ID="txtMessageSizeOver" runat="server"></asp:TextBox><STWC:GlobalizedLabel ID="Globalizedlabel58" runat="server" ResourceIDGlobal="@KB" />
				</td>
			</tr>
			<tr id="DetailMessageSizeUnder" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel59" runat="server" ResourceIDPage="MessageUnderSize" />
				</td>
				<td class="SettingsSetting">
					<asp:TextBox ID="txtMessageSizeUnder" runat="server"></asp:TextBox><STWC:GlobalizedLabel ID="Globalizedlabel60" runat="server" ResourceIDGlobal="@Bytes" />
				</td>
			</tr>
			<tr id="DetailDateRange" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel46" runat="server" ResourceIDPage="ReceivedInDateRange" />
				</td>
				<td class="SettingsSetting">
					<SMWC:PopupCalendar ID="calDateRangeStart" runat="server" FormName="Form1"></SMWC:PopupCalendar>
					&nbsp;-
					<SMWC:PopupCalendar ID="calDateRangeStop" runat="server" FormName="Form1"></SMWC:PopupCalendar>
				</td>
			</tr>
			<tr id="DetailSendingServerIP" valign="top" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel47" runat="server" ResourceIDPage="SendingServerIPs" /></td>
				<td class="SettingsSetting">
					<STWC:GlobalizedLabel ID="Globalizedlabel49" runat="server" ResourceIDPage="IPFormat" /><br />
					<asp:TextBox ID="txtSendingServerIP" runat="server" Rows="8" Columns="35" TextMode="MultiLine" Wrap="False"></asp:TextBox></td>
			</tr>
			<tr id="DetailSpamWeight" runat="server">
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel48" runat="server" ResourceIDPage="SpamWeightHigherThan" /></td>
				<td class="SettingsSetting">
					<asp:DropDownList ID="lstSpamWeight" runat="server">
					</asp:DropDownList></td>
			</tr>
		</table>
		<table class="SettingsContent" id="TableAction" runat="server">
			<tr>
				<td class="SettingsHeader" colspan="2">
					<STWC:GlobalizedLabel ID="Globalizedlabel1" runat="server" ResourceIDGlobal="@Rule" />
				</td>
			</tr>
			<tr>
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel51" runat="server" ResourceIDPage="RuleName" /></td>
				<td class="SettingsSetting">
					<asp:TextBox ID="txtRuleName" runat="server"></asp:TextBox></td>
			</tr>
			<tr>
				<td class="SettingsLabelInd">
					<STWC:GlobalizedLabel ID="Globalizedlabel52" runat="server" ResourceIDGlobal="@Rule" />
				</td>
				<td class="SettingsSetting">
					<asp:Label ID="RuleFriendlyText" runat="server"></asp:Label><br />
				</td>
			</tr>
			<tr>
				<td class="SettingsHeader" colspan="2">
					<STWC:GlobalizedLabel ID="Globalizedlabel53" runat="server" ResourceIDGlobal="@Actions" />
				</td>
			</tr>
			<tr>
				<td class="SettingsSettingSingleInd" colspan="2">
					<asp:CheckBox ID="chkActionDelete" runat="server" Text="$DeleteMessage"></asp:CheckBox>
				</td>
			</tr>
			<tr id="trBounce" runat="server">
				<td class="SettingsSettingSingleInd" colspan="2">
					<asp:CheckBox ID="chkActionBounce" runat="server" Text="$BounceMessage"></asp:CheckBox>
				</td>
			</tr>
			<tr id="MoveRow1" runat="server">
				<td class="SettingsSettingSingleInd" colspan="2">
					<asp:CheckBox ID="chkActionMove" runat="server" Text="$MoveToFolder"></asp:CheckBox>
				</td>
			</tr>
			<tr id="MoveRow2" runat="server">
				<td class="SettingsLabelInd">
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<STWC:GlobalizedLabel ID="Globalizedlabel54" runat="server" ResourceIDPage="Folder" />
				</td>
				<td class="SettingsSetting">
					<asp:DropDownList ID="FolderList" runat="server">
					</asp:DropDownList>
				</td>
			</tr>
			<tr id="trMoveToFolder1" runat="server">
				<td class="SettingsSettingSingleInd" colspan="2">
					<asp:CheckBox ID="chkMoveToFolder" runat="server" Text="$MoveToFolder"></asp:CheckBox>
				</td>
			</tr>
			<tr id="trMoveToFolder2" runat="server">
				<td class="SettingsLabelInd">
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<STWC:GlobalizedLabel ID="Globalizedlabel61" runat="server" ResourceIDPage="Folder" />
				</td>
				<td class="SettingsSetting">
					<asp:TextBox ID="txtMoveToFolder" runat="server" Text=""></asp:TextBox></td>
			</tr>
			<tr>
				<td class="SettingsSettingSingleInd" colspan="2">
					<asp:CheckBox ID="chkActionPrefixSubject" runat="server" Text="$PrefixSubject"></asp:CheckBox>
				</td>
			</tr>
			<tr>
				<td class="SettingsLabelInd">
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<STWC:GlobalizedLabel ID="Globalizedlabel55" runat="server" ResourceIDPage="Comment" />
				</td>
				<td class="SettingsSetting">
					<asp:TextBox ID="txtSubjectPrefix" runat="server" Text=""></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="SettingsSettingSingleInd" colspan="2">
					<asp:CheckBox ID="chkActionEmbedHeader" runat="server" Text="$EmbedHeader"></asp:CheckBox>
				</td>
			</tr>
			<tr>
				<td class="SettingsLabelInd">
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<STWC:GlobalizedLabel ID="Globalizedlabel56" runat="server" ResourceIDPage="Header" />
				</td>
				<td class="SettingsSetting">
					<asp:TextBox ID="txtActionHeader" runat="server" Text=""></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="SettingsSettingSingleInd" colspan="2">
					<asp:CheckBox ID="chkActionCopy" runat="server" Text="$CopyMessage"></asp:CheckBox>
				</td>
			</tr>
			<tr>
				<td class="SettingsLabelInd">
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<STWC:GlobalizedLabel ID="Globalizedlabel63" runat="server" ResourceIDPage="Email" />
				</td>
				<td class="SettingsSetting">
					<asp:TextBox ID="txtActionCopyAddress" runat="server" Text=""></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="SettingsSettingSingleInd" colspan="2">
					<asp:CheckBox ID="txtActionForward" runat="server" Text="$RerouteMessage"></asp:CheckBox>
				</td>
			</tr>
			<tr>
				<td class="SettingsLabelInd">
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<STWC:GlobalizedLabel ID="Globalizedlabel57" runat="server" ResourceIDPage="Email" />
				</td>
				<td class="SettingsSetting">
					<asp:TextBox ID="txtActionForwardAddress" runat="server" Text=""></asp:TextBox>
				</td>
			</tr>
		</table>
	</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="NavPH" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="CntPH" runat="server">
</asp:Content>

