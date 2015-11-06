<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmEvent.aspx.cs" Inherits="SMWeb05.Main.Calendar.frmEvent" Title="Untitled Page" %>

<%@ Register Assembly="RadTabStrip.Net2" Namespace="Telerik.WebControls" TagPrefix="radTS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="SaveTextImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Save.png" ResourceIDGlobal="@Save"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="InviteAttendeesButton" runat="server" ResourceIDPage="InviteAttendees" CssClass="ButtonBarImageButton" ImageFile="Icons/Send.png"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="btnManageCategories" runat="server" NavigateURL="javascript:OpenMasterCategoriesPopup()" ImageFile="icons/masterCatagories.png" ResourceIDGlobal="@MasterCategories" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="DeleteImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Cancel_close.png" ResourceIDGlobal="@DeleteCap"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="CancelTextImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Cancel_close.png" ResourceIDGlobal="@Cancel"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TPH" runat="server">
	<radTS:RadTabStrip ID="TabStrip" runat="server">
		<Tabs>
			<radTS:Tab ID="Tab1" runat="server" Text="$Event" PageViewID="OptionsTab">
			</radTS:Tab>
			<radTS:Tab ID="Tab2" runat="server" Text="$RecurringInformation" PageViewID="RecurTab">
			</radTS:Tab>
			<radTS:Tab ID="Tab3" runat="server" Text="@Categories" PageViewID="pvCategories">
			</radTS:Tab>
		</Tabs>
	</radTS:RadTabStrip>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MPH" runat="server">

	<script type="text/javascript">
		<!--
		var contactPopupTargetCtrl = "<%= InviteBox.ClientID %>";
		function openpopup(cname)
		{
			contactPopupTargetCtrl = cname;
			var popurl="../frmPopupContactsList.aspx";
			winpops=window.open(popurl,"contactwindow","width=450,height=338,resizable=yes");
		}

		function OpenMasterCategoriesPopup()
		{
			var popurl="../frmPopupContactCategories.aspx";
			winpops=window.open(popurl,"categorywindow","width=450,height=270,resizable=yes");
		}
		
		function openpopupto()
		{
			openpopup('<%= InviteBox.ClientID %>');
		}
		
		function UpdateContactPopupTarget(stringToAdd)
		{
			currentCtrlVal = eval("document.getElementById('"+contactPopupTargetCtrl+"').value;");
			
			var newCtrlVal = "";
			if (currentCtrlVal.length == 0)
				newCtrlVal = stringToAdd;
			else
				newCtrlVal = FormatLeftAddressStr(currentCtrlVal)+stringToAdd;
		
			var evalStr = "document.getElementById('"+contactPopupTargetCtrl+"').value = '"+newCtrlVal+"';";
			eval(evalStr);
		}
		function FormatLeftAddressStr(val1)
		{
			var firstNonSpaceIndex = GetFirstNonSpaceIndex(val1);
		
			if (firstNonSpaceIndex == -1)
				return "";
			
			var firstNonSpaceChar = val1.charAt(firstNonSpaceIndex);
			if (firstNonSpaceChar == ';')
				return val1.substring(0,firstNonSpaceIndex+1)+" ";
		
			return val1.substring(0,firstNonSpaceIndex+1)+"; ";
		}
		
		function GetFirstNonSpaceIndex(val1)
		{
			if (val1.length == 0)
				return -1;
							
			var currentIndex = val1.length - 1;
			var exit = false;
			while (!exit)
			{
				var currentChar = val1.charAt(currentIndex);
				if (currentChar != ' ')
					return currentIndex;
				
				currentIndex = currentIndex - 1;
				if (currentIndex == -1)
					return -1;
			}
			
			return -1;
		}
		
		function DoAvailability(cname)
		{
			var popurl="../frmPopupAvailability.aspx?date=" + document.getElementById('ctl00_ctl00_PH_MPH_ctl00_ctl00_PH_MPH_calStartDate_txtDate').value + "&users=" + document.getElementById('<%= InviteBox.ClientID %>').value.replace(/\n/g,";").replace(/\r/g,";");
			winpops=window.open(popurl,"availabilitywindow","width=800,height=300,scrollbars,resizable=yes")

		}
		function EmailToggle()
		{
			if (document.getElementById('<%= RadioEmailMe.ClientID%>').checked==true) 
				document.getElementById('<%= txtEmailMe.ClientID%>').style.display = '';
			else 
				document.getElementById('<%= txtEmailMe.ClientID%>').style.display = 'none';
		}
		-->
	</script>

	<radTS:RadMultiPage ID="MP1" runat="server">
		<radTS:PageView ID="OptionsTab" runat="server">
			<table class="TabStripContent">
				<tr>
					<td class="SettingsHeader" colspan="2">
						<STWC:GlobalizedLabel ID="Globalizedlabel1" runat="server" ResourceIDGlobal="@BasicInformation"></STWC:GlobalizedLabel>
					</td>
				</tr>
				<tr>
					<td class="SettingsLabelInd">
						<STWC:GlobalizedLabel ID="GLOBALIZEDLABEL2" runat="server" ResourceIDGlobal="@Subject"></STWC:GlobalizedLabel>
					</td>
					<td class="SettingsSetting">
						<asp:TextBox ID="SubjectBox" Columns="50" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td class="SettingsLabelInd">
						<STWC:GlobalizedLabel ID="GLOBALIZEDLABEL4" runat="server" ResourceIDPage="Location"></STWC:GlobalizedLabel>
					</td>
					<td class="SettingsSetting">
						<asp:TextBox ID="LocationBox" Columns="50" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr id="InviteRow" runat="server">
					<td class="SettingsLabelInd">
						<asp:HyperLink ID="lnkAttendees" runat="server"></asp:HyperLink><br />
						<br />
						<asp:HyperLink ID="lnkAvail" runat="server"></asp:HyperLink>
					</td>
					<td class="SettingsSetting">
						<asp:TextBox ID="InviteBox" runat="server" TextMode="MultiLine" Columns="40" Rows="3"></asp:TextBox>
					</td>
				</tr>
			</table>
			<table class="TabStripContent">
				<tr>
					<td class="SettingsHeader" colspan="2">
						<STWC:GlobalizedLabel ID="Globalizedlabel7" runat="server" ResourceIDPage="DateTimeInformation"></STWC:GlobalizedLabel>
					</td>
				</tr>
				<tr>
					<td class="SettingsLabelInd">
						<STWC:GlobalizedLabel ID="Globalizedlabel5" runat="server" ResourceIDGlobal="@Start"></STWC:GlobalizedLabel></td>
					<td class="SettingsSetting">
						<SMWC:PopupCalendar runat="server" ID="calStartDate" FormName="aspnetForm"></SMWC:PopupCalendar>
						<asp:TextBox ID="DateStartBox" runat="server" Columns="6"></asp:TextBox>
						<asp:CheckBox ID="chkAllDay" Text="$AllDayEvent" runat="server" AutoPostBack="True"></asp:CheckBox>
					</td>
				</tr>
				<tr>
					<td class="SettingsLabelInd">
						<STWC:GlobalizedLabel ID="Globalizedlabel6" runat="server" ResourceIDPage="DateEnd"></STWC:GlobalizedLabel></td>
					<td class="SettingsSetting">
						<SMWC:PopupCalendar runat="server" ID="calEndDate" FormName="aspnetForm"></SMWC:PopupCalendar>
						<asp:TextBox ID="DateEndBox" runat="server" Columns="6"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td class="SettingsLabelInd">
						<STWC:GlobalizedLabel ID="Globalizedlabel9" runat="server" ResourceIDGlobal="@Reminder"></STWC:GlobalizedLabel>
					</td>
					<td class="SettingsSetting">
						<asp:DropDownList ID="ReminderDropDown" runat="server">
						</asp:DropDownList>&nbsp;
						<asp:CheckBox ID="RadioEmailMe" onclick="javascript: EmailToggle();" runat="server" Text="$EmailMe"></asp:CheckBox><br />
						<asp:TextBox ID="txtEmailMe" Style="display: none" Columns="45" runat="server"></asp:TextBox>
					</td>
				</tr>
			</table>
			<table class="TabStripContent">
				<tr>
					<td class="SettingsHeader">
						<STWC:GlobalizedLabel ID="Globalizedlabel18" runat="server" ResourceIDGlobal="@Description"></STWC:GlobalizedLabel>
					</td>
				</tr>
				<tr>
					<td class="SettingsSettingSingleInd">
						<STWC:ValidatedTextBox ID="DescriptionBox" runat="server" Rows="8" Columns="45" TextMode="MultiLine"></STWC:ValidatedTextBox>
					</td>
				</tr>
			</table>
		</radTS:PageView>
		<radTS:PageView ID="RecurTab" runat="server">
			<div id="RecurrenceArea" runat="server">
				<table class="TabStripContent">
					<tr>
						<td id="FreqCol" class="SettingsLabel">
							<asp:RadioButton ID="RadioOnce" runat="server" Text="$OneTime" AutoPostBack="True" GroupName="Recur" Checked="True"></asp:RadioButton>
							<asp:Literal ID="Literal4" runat="server"></asp:Literal>
							<asp:RadioButton ID="RadioDaily" runat="server" Text="$Daily" AutoPostBack="True" GroupName="Recur"></asp:RadioButton>
							<asp:Literal ID="Literal3" runat="server"></asp:Literal>
							<asp:RadioButton ID="RadioWeekly" runat="server" Text="$Weekly" AutoPostBack="True" GroupName="Recur"></asp:RadioButton>
							<asp:Literal ID="Literal1" runat="server"></asp:Literal>
							<asp:RadioButton ID="RadioMonthly" runat="server" Text="$Monthly" AutoPostBack="True" GroupName="Recur"></asp:RadioButton>
							<asp:Literal ID="Literal2" runat="server"></asp:Literal>
							<asp:RadioButton ID="RadioYearly" runat="server" Text="$Yearly" AutoPostBack="True" GroupName="Recur"></asp:RadioButton>
						</td>
						<td class="SettingsSetting">
							<div id="DailyArea" runat="server">
								<asp:RadioButton ID="RadioEveryXDays" runat="server" Text="$Every" GroupName="Daily" Checked="True"></asp:RadioButton>&nbsp;
								<asp:TextBox ID="EveryXDaysBox" runat="server" Columns="2">1</asp:TextBox>&nbsp;
								<STWC:GlobalizedLabel ID="Globalizedlabel12" runat="server" ResourceIDPage="Days"></STWC:GlobalizedLabel><br />
								<asp:RadioButton ID="RadioEveryWeekDay" runat="server" Text="$EveryWeekday" GroupName="Daily"></asp:RadioButton><br />
							</div>
							<div id="WeeklyArea" runat="server">
								<STWC:GlobalizedLabel ID="Globalizedlabel13" runat="server" ResourceIDPage="Every"></STWC:GlobalizedLabel>&nbsp;
								<asp:TextBox ID="EveryXWeeksBox" runat="server" Columns="2">1</asp:TextBox>&nbsp;
								<STWC:GlobalizedLabel ID="Globalizedlabel14" runat="server" ResourceIDPage="Weeks"></STWC:GlobalizedLabel>:<br />
								<table cellpadding="0" width="100%">
									<tr>
										<td width="25%" class="SettingsBase">
											<asp:CheckBox ID="chkSunday" Text="$Sunday" runat="server"></asp:CheckBox></td>
										<td width="25%" class="SettingsBase">
											<asp:CheckBox ID="chkMonday" Text="$Monday" runat="server"></asp:CheckBox></td>
										<td width="25%" class="SettingsBase">
											<asp:CheckBox ID="chkTuesday" Text="$Tuesday" runat="server"></asp:CheckBox></td>
										<td width="25%" class="SettingsBase">
											<asp:CheckBox ID="chkWednesday" Text="$Wednesday" runat="server"></asp:CheckBox></td>
									</tr>
									<tr>
										<td width="25%" class="SettingsBase">
											<asp:CheckBox ID="chkThursday" Text="$Thursday" runat="server"></asp:CheckBox></td>
										<td width="25%" class="SettingsBase">
											<asp:CheckBox ID="chkFriday" Text="$Friday" runat="server"></asp:CheckBox></td>
										<td width="25%" class="SettingsBase">
											<asp:CheckBox ID="chkSaturday" Text="$Saturday" runat="server"></asp:CheckBox></td>
										<td>
											&nbsp;</td>
									</tr>
								</table>
							</div>
							<div id="MonthlyArea" runat="server">
								<STWC:GlobalizedLabel ID="Globalizedlabel15" runat="server" ResourceIDPage="Every"></STWC:GlobalizedLabel>&nbsp;
								<asp:TextBox ID="EveryXMonthsBox" runat="server" Columns="2">1</asp:TextBox>&nbsp;
								<STWC:GlobalizedLabel ID="Globalizedlabel16" runat="server" ResourceIDPage="Months"></STWC:GlobalizedLabel>:<br />
								<asp:RadioButton ID="RadioMonthDay" runat="server" Text="$Day" GroupName="Monthly" Checked="True"></asp:RadioButton>&nbsp;
								<asp:TextBox ID="MonthDayBox" runat="server" Columns="2">1</asp:TextBox><br />
								<asp:RadioButton ID="RadioXthDay" runat="server" Text="$The" GroupName="Monthly"></asp:RadioButton>&nbsp;
								<asp:DropDownList ID="ComboMonthlyXth" runat="server">
								</asp:DropDownList>
								<asp:DropDownList ID="ComboMonthlyDay" runat="server">
								</asp:DropDownList>
							</div>
							<div id="YearlyArea" runat="server">
								<asp:RadioButton ID="RadioYearlyDay" runat="server" Text="$Every" GroupName="Yearly" Checked="True"></asp:RadioButton>&nbsp;
								<asp:DropDownList ID="ComboMonth" runat="server">
								</asp:DropDownList>
								<asp:TextBox ID="YearlyDayBox" runat="server" Columns="2">1</asp:TextBox><br />
								<asp:RadioButton ID="RadioYearlyXthDay" runat="server" Text="$The" GroupName="Yearly"></asp:RadioButton>&nbsp;
								<asp:DropDownList ID="ComboYearlyXth" runat="server">
								</asp:DropDownList>
								<asp:DropDownList ID="ComboYearlyDay" runat="server">
								</asp:DropDownList>&nbsp;
								<STWC:GlobalizedLabel ID="Globalizedlabel17" runat="server" ResourceIDPage="Of"></STWC:GlobalizedLabel>&nbsp;
								<asp:DropDownList ID="ComboYearlyMonth" runat="server">
								</asp:DropDownList>
							</div>
							<div id="UntilArea" runat="server">
								<br />
								<asp:RadioButton ID="UntilForever" runat="server" Text="$Forever" GroupName="UntilGroup" Checked="True"></asp:RadioButton><br />
								<asp:RadioButton ID="UntilCount" runat="server" Text="$EndAfter" GroupName="UntilGroup"></asp:RadioButton>&nbsp;
								<asp:TextBox ID="OccurenceBox" runat="server" Columns="2">10</asp:TextBox>&nbsp;
								<STWC:GlobalizedLabel ID="Globalizedlabel19" runat="server" ResourceIDPage="occurrences"></STWC:GlobalizedLabel><br />
								<asp:RadioButton ID="UntilDate" runat="server" Text="$EndBy" GroupName="UntilGroup"></asp:RadioButton>&nbsp;
								<SMWC:PopupCalendar runat="server" ID="EndByDate" FormName="aspnetForm"></SMWC:PopupCalendar>
							</div>
						</td>
					</tr>
				</table>
			</div>
		</radTS:PageView>
		<radTS:PageView ID="pvCategories" runat="server">
			<asp:Table runat="server" ID="tblCategories" CssClass="SettingsContent" />
			<asp:TextBox runat="server" ID="txtCategoryCount" Visible="False" />
			<asp:TextBox runat="server" ID="txtCategories" Visible="False" />
		</radTS:PageView>
	</radTS:RadMultiPage>
</asp:Content>

