<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmSharingPeople.aspx.cs" Inherits="SMWeb05.Main.frmSharingPeople"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnSaveSharing" runat="server" ResourceIDGlobal="@Save" ImageFile="Icons/save.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="btnCancelSharing" runat="server" ResourceIDGlobal="@Cancel" ImageFile="Icons/cancel_close.png" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">

	<script type="text/javascript">
			<!-- 
				function openpopup(cname)
				{
					var popurl="frmPopupUserList.aspx?cname=" + cname;
					winpops=window.open(popurl,"contactwindow","width=450,height=338,scrollbars,resizable=yes")
				}
				
				function updatedisplay()
				{
					if (document.getElementById("<%= radUser.ClientID %>").checked == true)
					{
						document.getElementById("<%= txtUsers.ClientID %>").style.display="";
						document.getElementById("<%= listGroups.ClientID %>").style.display="none";
					}
					else
					{
						document.getElementById("<%= txtUsers.ClientID %>").style.display="none";
						document.getElementById("<%= listGroups.ClientID %>").style.display="";
					}
				
				}
				//-->
	</script>

	<table class="SettingsContent">
		<tr>
			<td class="SettingsHeader" colspan="2">
				<STWC:GlobalizedLabel ID="GlobalizedLabel1" runat="server" ResourceIDPage="ShareWith" />
			</td>
		</tr>
		<tr id="trAddMode" runat="server">
			<td colspan="2">
				<table class="TabStripContent">
					<tr>
						<td class="SettingsLabelInd">
							<asp:RadioButton ID="radUser" onclick="updatedisplay()" GroupName="UserGroup" runat="server" />
							<asp:HyperLink ID="lnkUserPoup" runat="server"></asp:HyperLink>
						</td>
						<td class="SettingsSetting">
							<asp:TextBox ID="txtUsers" Style="display: none" runat="server" Height="90px" TextMode="MultiLine"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="SettingsLabelInd">
							<asp:RadioButton ID="radGroup" onclick="updatedisplay()" GroupName="UserGroup" runat="server" />
							<asp:Label ID="lblDomainGroups" runat="server"></asp:Label>
						</td>
						<td class="SettingsSetting">
							<asp:ListBox ID="listGroups" Style="display: none" runat="server" CssClass="fullw" Height="90px" SelectionMode="Multiple"></asp:ListBox>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr id="trEditMode" runat="server">
			<td class="SettingsLabelInd">
				<asp:Label ID="lblSharedWithTitle" runat="server"></asp:Label>
			</td>
			<td class="SettingsSetting">
				<asp:Label ID="lblSharedWithValue" runat="server"></asp:Label>
			</td>
		</tr>
	</table>
	<table class="TabStripContent">
		<tr>
			<td class="SettingsHeader" colspan="2">
				<STWC:GlobalizedLabel ID="GlobalizedLabel2" runat="server" ResourceIDPage="ShareAccess" />
			</td>
		</tr>
		<tr>
			<td class="SettingsLabelInd">
				<asp:Label ID="lblPermissions" runat="server"></asp:Label>
			</td>
			<td class="SettingsSetting">
				<asp:DropDownList ID="ddPermissions" runat="server">
				</asp:DropDownList>
			</td>
		</tr>
	</table>
</asp:Content>

