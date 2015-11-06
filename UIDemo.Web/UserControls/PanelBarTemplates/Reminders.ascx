<%@ Control Language="C#" AutoEventWireup="false" Codebehind="Reminders.ascx.cs" Inherits="SMWeb05.UserControls.PanelBarTemplates.Reminders" %>
<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="radA" %>
<%@ Register Assembly="RadMenu.Net2" Namespace="Telerik.WebControls" TagPrefix="radM" %>
<div class="Reminders">
	<radA:RadAjaxManager ID="RadAjaxManager1" runat="server">
		<AjaxSettings>
			<radA:AjaxSetting AjaxControlID="RMenu">
				<UpdatedControls>
					<radA:AjaxUpdatedControl ControlID="Literal1" />
				</UpdatedControls>
			</radA:AjaxSetting>
		</AjaxSettings>
	</radA:RadAjaxManager>
		<radM:RadMenu ID="RMenu" runat="server" IsContext="True" ContextMenuElementID="None" Flow="Vertical" EnableViewState="False" OnItemClick="ManageMenu_ItemClick">
			<Items>
				<radM:RadMenuItem runat="server" Text="@Dismiss" Value="Dismiss">
				</radM:RadMenuItem>
				<radM:RadMenuItem runat="server" Text="@Snooze" Value="Snooze">
					<Items>
						<radM:RadMenuItem ID="RadMenuItem1" runat="server" Text="@15Minutes" Value="Snooze15">
						</radM:RadMenuItem>
						<radM:RadMenuItem ID="RadMenuItem2" runat="server" Text="@30Minutes" Value="Snooze30">
						</radM:RadMenuItem>
						<radM:RadMenuItem ID="RadMenuItem3" runat="server" Text="@1Hour" Value="Snooze60">
						</radM:RadMenuItem>
						<radM:RadMenuItem ID="RadMenuItem4" runat="server" Text="@2Hours" Value="Snooze120">
						</radM:RadMenuItem>
						<radM:RadMenuItem ID="RadMenuItem5" runat="server" Text="@6Hours" Value="Snooze720">
						</radM:RadMenuItem>
						<radM:RadMenuItem ID="RadMenuItem6" runat="server" Text="@1Day" Value="Snooze1440">
						</radM:RadMenuItem>
					</Items>
				</radM:RadMenuItem>
				<radM:RadMenuItem runat="server" IsSeparator="True">
				</radM:RadMenuItem>
				<radM:RadMenuItem runat="server" Text="@DismissAll" Value="DismissAll">
				</radM:RadMenuItem>
			</Items>
		</radM:RadMenu>

		<script type="text/javascript">
			function SetHiddenField(UID)
			{
				document.getElementById('<%= EvtUID.ClientID %>').value=UID;
			}
			function ShowRemMenu(e)
			{
				var menu = <%= RMenu.ClientID %>;
				menu.Show(e);
		        
				e.cancelBubble = true;
		        
				if (e.stopPropagation)
				{
					e.stopPropagation();
				}
			}
		</script>

		<asp:Label ID="Literal1" runat="server"></asp:Label>
		<asp:TextBox ID="EvtUID" runat="server" Style="display: none"></asp:TextBox>
</div>
