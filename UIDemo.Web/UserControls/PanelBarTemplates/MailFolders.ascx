<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="MailFolders.ascx.cs" Inherits="SMWeb05.UserControls.PanelBarTemplates.MailFolders" %>

<%@ Register Assembly="RadTreeView.Net2" Namespace="Telerik.WebControls" TagPrefix="radT" %>

<script type="text/javascript">
	var toggleActions="";
	createCookie('TreeToggleActions',"",1);
	function AfterClientToggle(node)
	{
		toggleActions += node.Value + '*';
		createCookie('TreeToggleActions',toggleActions,1);
	}
</script>

<radT:RadTreeView EnableViewState="false" ID="MailTV" runat="server" AfterClientToggle="AfterClientToggle" />
