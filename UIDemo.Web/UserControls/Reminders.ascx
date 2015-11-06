<%@ Control Language="C#" AutoEventWireup="false" Codebehind="Reminders.ascx.cs" Inherits="SMWeb05.UserControls.Reminders" %>

<script type="text/javascript">
	function SetHiddenField(UID)
	{
		document.getElementById('<%= EvtUID.ClientID %>').value=UID;
	}
</script>

<asp:Literal ID="Literal1" runat="server"></asp:Literal>
<SMWC:SkinTextImageButton ID="DismissAllButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Save.gif" ResourceIDGlobal="@Save" Visible="False"></SMWC:SkinTextImageButton>
<asp:TextBox ID="EvtUID" runat="server" Style="display: none"></asp:TextBox>