<%@ Page Language="C#" AutoEventWireup="false" Codebehind="frmReadMail_Body.aspx.cs" Inherits="SMWeb05.Main.frmReadMail_Body" %>

<?xml version="1.0" encoding="utf-8" ?>
<!-- ... -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Untitled Page</title>
	<base target="_blank" />
</head>
<body class="ReadMailContent">
	<form class="ReadMailContent" id="form1" runat="server">

		<script type="text/javascript" src="<%= JScript %>"></script>
		<asp:Literal ID="ScriptLiteral" runat="server" />
		<table id="ReadMailHeader" class="InnerReadMailContent">
			<tr>
				<td class="ReadMailLeft">
					<table class="ReadMailLeft">
						<tr>
							<td class="ReadMailLabel">
								<STWC:GlobalizedLabel ID="Globalizedlabel1" runat="server" ResourceIDGlobal="Main.frmReadMail_Body_From" />
							</td>
							<td class="ReadMailField">
								<asp:Literal ID="Literal1" runat="server" />
								<asp:Label ID="lblFrom" runat="server" />
							</td>
						</tr>
						<tr id="rowTo" runat="server">
							<td class="ReadMailLabel">
								<STWC:GlobalizedLabel ID="Globalizedlabel3" runat="server" ResourceIDGlobal="Main.frmReadMail_Body_To" />
							</td>
							<td class="ReadMailField">
								<asp:Label ID="lblTo" runat="server" />
							</td>
						</tr>
						<tr id="rowCC" runat="server">
							<td class="ReadMailLabel">
								<STWC:GlobalizedLabel ID="Globalizedlabel6" runat="server" ResourceIDGlobal="Main.frmReadMail_Body_CC" />
							</td>
							<td class="ReadMailField">
								<asp:Label ID="lblCC" runat="server" />
							</td>
						</tr>
						<tr class="alttable" id="rowSubject" valign="top" runat="server">
							<td class="ReadMailLabel">
								<STWC:GlobalizedLabel ID="Globalizedlabel7" runat="server" ResourceIDGlobal="Main.frmReadMail_Body_Subject" />
							</td>
							<td class="ReadMailField">
								<asp:Label ID="lblSubject" runat="server" />
							</td>
						</tr>
						<tr class="alttable" id="rowAttachments" valign="top" runat="server">
							<td class="ReadMailLabel">
								<STWC:GlobalizedLabel ID="Globalizedlabel8" runat="server" ResourceIDGlobal="Main.frmReadMail_Body_Attachments" /></td>
							<td class="ReadMailField" style="white-space: normal">
								<asp:Label ID="lblAttachments" runat="server" />
							</td>
						</tr>
					</table>
				</td>
				<td class="ReadMailRight">
					<div class="ReadMailIcons">
						<div id="divPrevNext" runat="server">
							<SMWC:SkinTextImageButton ID="PreviousImageButton" runat="server" ImageFile="Icons/previous.png" ResourceIDGlobal="@Previous" CssClass="ReadMailImageButton"></SMWC:SkinTextImageButton>
							<SMWC:SkinTextImageButton ID="NextImageButton" runat="server" ImageFile="Icons/next.png" ResourceIDGlobal="@NextPadded" CssClass="ReadMailImageButton"></SMWC:SkinTextImageButton>
						</div>
						<div id="divActions" visible="false" runat="server">
							<SMWC:SkinTextImageButton ID="PrintImageButton" runat="server" ImageFile="Icons/Print.png" ResourceIDGlobal="@Print" CssClass="ReadMailImageButton" NavigateTarget="_parent" NavigateURL="javascript:print_iframe('contentframe');"></SMWC:SkinTextImageButton>
							<SMWC:SkinTextImageButton ID="ReplyImageButton" runat="server" ImageFile="Icons/Reply.png" ResourceIDPage="Reply" CssClass="ReadMailImageButton"></SMWC:SkinTextImageButton>
							<SMWC:SkinTextImageButton ID="ReplyAllImageButton" runat="server" ImageFile="Icons/ReplyAll.png" NavigateURL="frmDomain.aspx" ResourceIDPage="ReplyAll" CssClass="ReadMailImageButton"></SMWC:SkinTextImageButton>
							<SMWC:SkinTextImageButton ID="ForwardImageButton" runat="server" ImageFile="Icons/Forward.png" ResourceIDPage="Forward" CssClass="ReadMailImageButton"></SMWC:SkinTextImageButton>
						</div>
					</div>
					<div class="ReadMailDate">
						<span class="ReadMailLabelDate">
							<STWC:GlobalizedLabel ID="Globalizedlabel2" runat="server" ResourceIDGlobal="Main.frmReadMail_Body_Date" />
						</span>
						<asp:Label ID="lblDate" runat="server"></asp:Label>
					</div>
					<div class="ReadMailView">
						<asp:Label ID="lblView" runat="server"></asp:Label>
					</div>
				</td>
			</tr>
			<tr id="DangerousScriptsRemoved" runat="server" visible="false">
				<td class="ReadMailDangerousField" colspan="2">
					<asp:Label ID="ShowDangerousScriptsLink" runat="server" EnableViewState="false"></asp:Label>
				</td>
			</tr>
		</table>
		<div id="PrintMailContent" class="PrintMailContent"></div>
		<div id="ReadMailContent" class="ReadMailContent">
			<div class="ReadMailContent2">



				<%=FooterContent %>
				<div class="InvitationBox" id="VCalendarArea" visible="false" runat="server">
					<table class="InvitationBox">
						<tr>
							<td class="TopPanelMenuLeft">
								<div class="TopPanelMenuText">
									<asp:Label ID="EventAboutLabel" runat="server"></asp:Label>
								</div>
							</td>
							<td class="TopPanelMenuRight">
								<SMWC:Spacer ID="Spacer0" runat="server" Width="67" Height="1" />
							</td>
						</tr>
						<tr class="ButtonBar">
							<td colspan="2" class="ButtonBar">
								<table class="TwoCellButtonBar">
									<tr>
										<td class="ButtonBarLeft">
											<SMWC:SkinTextImageButton ID="AcceptImageButton" runat="server" ResourceIDPage="Accept" ImageFile="Icons/OK.png" CssClass="ButtonBarImageButton" NavigateTarget="_self"></SMWC:SkinTextImageButton>
											<SMWC:SkinTextImageButton ID="DeclineImageButton" runat="server" ResourceIDPage="Decline" ImageFile="Icons/Cancel_close.png" CssClass="ButtonBarImageButton" NavigateTarget="_self"></SMWC:SkinTextImageButton>
											<SMWC:SkinTextImageButton ID="CalendarImageButton" runat="server" ResourceIDPage="Details" ImageFile="Tree/Calendar.gif" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
										</td>
										<td class="ButtonBarRight">
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td colspan="2" class="InvitationBox">
								<table class="SettingsContent">
									<tr>
										<td class="SettingsLabel">
											<STWC:GlobalizedLabel ID="Globalizedlabel5" runat="server" ResourceIDGlobal="@Subject" /></td>
										<td class="SettingsSetting">
											<asp:Label ID="EventSubjectLabel" runat="server"></asp:Label></td>
									</tr>
									<tr>
										<td class="SettingsLabel">
											<STWC:GlobalizedLabel ID="Globalizedlabel9" runat="server" ResourceIDPage="Attendees" /></td>
										<td class="SettingsSetting">
											<asp:Label ID="EventAttendeesLabel" runat="server"></asp:Label></td>
									</tr>
									<tr>
										<td class="SettingsLabel">
											<STWC:GlobalizedLabel ID="Globalizedlabel10" runat="server" ResourceIDPage="When" /></td>
										<td class="SettingsSetting">
											<asp:Label ID="EventWhenLabel" runat="server"></asp:Label></td>
									</tr>
									<tr>
										<td class="SettingsLabel">
											<STWC:GlobalizedLabel ID="Where" runat="server" ResourceIDPage="Where" /></td>
										<td class="SettingsSetting">
											<asp:Label ID="EventWhereLabel" runat="server"></asp:Label></td>
									</tr>
									<tr>
										<td colspan="2" class="SettingsSettingSingle">
											<br />
											<asp:Label ID="DescriptionLabel" runat="server"></asp:Label></td>
									</tr>
									<tr>
										<td colspan="2" class="SettingsSetting">
											&nbsp;</td>
									</tr>
									<tr>
										<td colspan="2" class="SettingsSetting">
											<div id="AlreadyAcceptedArea" runat="server">
												<asp:Label ID="AcceptedLabel" runat="server"></asp:Label>
											</div>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</div>
			</div>
		</div>
		<script type="text/javascript">
			ActualResize();
		</script>
	</form>
</body>
</html>
