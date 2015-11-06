<%@ Page EnableEventValidation="False" Language="C#" ValidateRequest="false" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false"
	Codebehind="frmComposeInner.aspx.cs" Inherits="SMWeb05.Main.frmComposeInner" %>

<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="radA" %>
<%@ Register Assembly="RadSpell.Net2" Namespace="Telerik.WebControls" TagPrefix="radS" %>
<%@ Register Assembly="RadEditor.Net2" Namespace="Telerik.WebControls" TagPrefix="radE" %>
<%@ Register Assembly="RadComboBox.Net2" Namespace="Telerik.WebControls" TagPrefix="radC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="SendImagebutton" runat="server" ResourceIDPage="SendButton" ImageFile="Icons/Send.png" CssClass="ButtonBarImageButton">
	</SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="SaveImagebutton" runat="server" ResourceIDPage="SaveAsDraft" ImageFile="Icons/Save.png" CssClass="ButtonBarImageButton">
	</SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="RemoveAttachmentsButton" runat="server" ResourceIDPage="RemoveAttachments" ImageFile="Icons/Cancel_close.png"
		CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="AttachImageButton" runat="server" ResourceIDPage="AddAttachments" ImageFile="Icons/addFiles.png" CssClass="ButtonBarImageButton">
	</SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="UploadFileImageButton" runat="server" ResourceIDGlobal="@Upload" ImageFile="Icons/Upload.png" CssClass="ButtonBarImageButton">
	</SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="BackImageButton" runat="server" ImageFile="Icons/Cancel_close.png" CssClass="ButtonBarImageButton" ResourceIDGlobal="@Cancel">
	</SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="CancelUploadImageButton" runat="server" ResourceIDGlobal="@Cancel" ImageFile="Icons/Cancel_close.png"
		CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">
	<table id="ComposeTable" runat="server" class="ComposeContent">
		<tr id="fromRow" runat="server">
			<td class="ComposeLabel">
				<STWC:GlobalizedLabel ID="Globalizedlabel5" runat="server" ResourceIDGlobal="@From" />
			</td>
			<td class="ComposeField">
				<asp:DropDownList ID="ddFromList" runat="server" />
			</td>
		</tr>
		<tr id="Tr2" runat="server">
			<td class="ComposeLabel">
				<a href="javascript:openpopupto()" tabindex="-1">
					<STWC:GlobalizedLabel ID="Globalizedlabel1" runat="server" ResourceIDGlobal="@To" />
				</a>
			</td>
			<td class="ComposeField">
				<radC:RadComboBox ID="txtTo" Width="100%" runat="server" AllowCustomText="True" EnableLoadOnDemand="True" AutoCompleteSeparator=";"
					OnClientDropDownOpening="CheckOpening" OnClientItemsRequesting="CheckRequesting" OnClientItemsRequested="CheckRequested" OnClientDropDownClosing="CheckClosing">
				</radC:RadComboBox>
			</td>
		</tr>
		<tr id="Tr3" runat="server">
			<td class="ComposeLabel">
				<a href="javascript:openpopupcc()" tabindex="-1">
					<STWC:GlobalizedLabel ID="Globalizedlabel2" runat="server" ResourceIDPage="CC" />
				</a>
			</td>
			<td class="ComposeField">
				<radC:RadComboBox ID="txtCC" Width="100%" runat="server" AllowCustomText="True" EnableLoadOnDemand="True" AutoCompleteSeparator=";"
					OnClientDropDownOpening="CheckOpening" OnClientItemsRequesting="CheckRequesting" OnClientItemsRequested="CheckRequested" OnClientDropDownClosing="CheckClosing">
				</radC:RadComboBox>
			</td>
		</tr>
		<tr>
			<td class="ComposeLabel">
				<a href="javascript:openpopupbcc();" tabindex="-1">
					<STWC:GlobalizedLabel ID="Globalizedlabel3" runat="server" ResourceIDPage="BCC" />
				</a>
			</td>
			<td class="ComposeField">
				<radC:RadComboBox ID="txtBcc" Width="100%" runat="server" AllowCustomText="True" EnableLoadOnDemand="True" AutoCompleteSeparator=";"
					OnClientDropDownOpening="CheckOpening" OnClientItemsRequesting="CheckRequesting" OnClientItemsRequested="CheckRequested" OnClientDropDownClosing="CheckClosing">
				</radC:RadComboBox>
			</td>
		</tr>
		<tr id="Tr4" runat="server">
			<td class="ComposeLabel">
				<STWC:GlobalizedLabel ID="Globalizedlabel4" runat="server" ResourceIDGlobal="@Subject" />
			</td>
			<td class="ComposeField">
				<asp:TextBox ID="txtSubject" runat="server" Width="100%" />
			</td>
		</tr>
		<tr class="alttable" id="Tr5" runat="server">
			<td class="ComposeLabel">
				<STWC:GlobalizedLabel ID="Globalizedlabel9" runat="server" ResourceIDPage="Attachments" />
			</td>
			<td class="ComposeField">
				<asp:Label ID="lblAttachments" runat="server" Visible="true"></asp:Label>
			</td>
		</tr>
	</table>
	<div id="ComposeTable2" runat="server" class="ComposeContent">
		<div class="ComposeBox">
			<asp:TextBox ID="PlainTextBox1" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
		</div>
		<radE:RadEditor EnableDocking="false" EnableEnhancedEdit="false" Width="100%" EnableHtmlIndentation="false" ID="RadText" runat="server" />
	</div>
	<asp:ListBox ID="lstRealAttachments" Visible="False" runat="server"></asp:ListBox>
	<asp:ListBox ID="lstUploaded" Visible="False" runat="server" Width="100%" Rows="5"></asp:ListBox>
	<iframe runat="server" id="keepaliveIFrame" src="frmComposeKeepAlive.aspx" frameborder="0" height="1" width="1" scrolling="no"></iframe>
	<asp:HiddenField ID="hiddenGuid" runat="server" />
	<asp:HiddenField ID="hiddenGuid2" runat="server" />
	<table class="SettingsContent" id="UploadFileTable" runat="server">
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel ID="Globalizedlabel10" runat="server" ResourceIDPage="FilesToUpload">
				</STWC:GlobalizedLabel>
			</td>
			<td class="SettingsSetting">
				<input id="File1" type="file" size="35" name="File1" runat="server">
			</td>
		</tr>
		<tr>
			<td class="SettingsLabel">
			</td>
			<td class="SettingsSetting">
				<input id="File2" type="file" size="35" name="File2" runat="server">
			</td>
		</tr>
		<tr>
			<td class="SettingsLabel">
			</td>
			<td class="SettingsSetting">
				<input id="File3" type="file" size="35" name="File3" runat="server">
			</td>
		</tr>
		<tr>
			<td class="SettingsLabel">
			</td>
			<td class="SettingsSetting">
				<input id="File4" type="file" size="35" name="File4" runat="server">
			</td>
		</tr>
		<tr>
			<td class="SettingsLabel" style="height: 26px">
			</td>
			<td class="SettingsSetting" style="height: 26px">
				<input id="File5" type="file" size="35" name="File5" runat="server">
			</td>
		</tr>
		<tr>
			<td class="SettingsLabel">
			</td>
			<td class="SettingsSetting">
				<STWC:GlobalizedLabel ResourceIDPage="MaxUploadSize" ID="Globalizedlabel8" runat="server" Visible="false" NAME="Globalizedlabel1">
				</STWC:GlobalizedLabel>
			</td>
		</tr>
	</table>

	<script type="text/javascript" src="<%= JScript %>"></script>

	<script type="text/javascript">
		<!--
		var contactPopupTargetCtrl = '<%= txtTo.ClientID %>';
		function openpopupto()
		{
			openpopup('<%= txtTo.ClientID %>_Input');
		}
		function openpopupcc()
		{
			openpopup('<%= txtCC.ClientID %>_Input');
		}
		function openpopupbcc()
		{
			openpopup('<%= txtBcc.ClientID %>_Input');
		}
		
		function openpopup(cname)
		{
			contactPopupTargetCtrl = cname;
			var popurl="frmPopupContactsList.aspx";
			winpops=window.open(popurl,"contactwindow","width=450,height=338,resizable=yes");
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
		

		var ptb = "<%= PlainTextBox1.ClientID %>";
		var ctable = "<%= ComposeTable.ClientID %>";
		var eeditor = "<%= RadText.ClientID %>";
		var etxtTo = "<%= txtTo.ClientID %>_Input";
		var phTo = "<%= txtTo.ClientID %>_DropDown";
		var etxtCC = "<%= txtCC.ClientID %>_Input";
		var phCC = "<%= txtCC.ClientID %>_DropDown";
		var etxtBcc = "<%= txtBcc.ClientID %>_Input";
		var phBcc = "<%= txtBcc.ClientID %>_DropDown";
		var etxtSub = "<%= txtSubject.ClientID %>";
		var ctable2 = "<%=ComposeTable2.ClientID %>";
		var shown="";

			
        function CheckOpening(combobox)
        {
	        var str = combobox.GetText();
	        if (str.length == 0 || (str.length > 0 && str[str.length-1] == ';')) return false;
            return true;
        }
        			
        function CheckRequesting(combobox)
        {
            var str = combobox.GetText();
	        if (str.length == 0 || (str.length > 0 && str[str.length-1] == ';'))
            {
		        SetVis(combobox.DropDownID,"hidden");
		        shown="";
		        combobox.HideDropDown();
                return false;
            }      
        }
        function CheckClosing(combobox)
        {
	        SetVis(combobox.DropDownID,"hidden");
	        shown="";
        }
        function CheckRequested(combobox)
        {
            if (combobox.Items.length == 0)
            {
		        shown="";
		        SetVis(combobox.DropDownID,"hidden");
                combobox.HideDropDown();
            }
            else
            {
		        if (shown!=combobox.DropDownID)
			        combobox.ShowDropDown();
			        shown=combobox.DropDownID;
		        SetVis(combobox.DropDownID,"visible");
            }
        }
        function SetVis(cbox, style)
        {
	        if (style=="hidden")
	        {
		        document.getElementById(cbox).style.display = "none";
		        document.getElementById(cbox+"Placeholder").style.display="none";
	        }
	        else
	        {
		        document.getElementById(cbox).style.display = "";
		        document.getElementById(cbox+"Placeholder").style.display="";
	        }
        	
	        document.getElementById(cbox).style.visibility = style;
	        document.getElementById(cbox+"Placeholder").style.visibility = style;
        }
            
		function ClickOverride() { return false; }
		
		function AttachComboboxes()
		{
            <%= txtTo.ClientID %>.SelectText = ClickOverride;
    		<%= txtCC.ClientID %>.SelectText = ClickOverride;
    		<%= txtBcc.ClientID %>.SelectText = ClickOverride;

    		if (self.<%=RadText.ClientID %>)
    		{
    			var x = <%=RadText.ClientID %>;
				if (x && x.AttachEventHandler) x.AttachEventHandler("onmousedown", ComboBlur);
			}
		}
			
    	function ComboBlur()
		{
		    <%= txtTo.ClientID %>.HideDropDown();
			<%= txtCC.ClientID %>.HideDropDown();
			<%= txtBcc.ClientID %>.HideDropDown();
		}
		AttachComboboxes();

	    var hidden = document.getElementById('<%= hiddenGuid.ClientID %>');
	    var hidden2 = document.getElementById('<%= hiddenGuid2.ClientID %>');
	    hidden2.value = hidden.value;
	    
	    
	    RadComboBox.prototype.hookedGetAjaxUrl = RadComboBox.prototype.GetAjaxUrl;
	    RadComboBox.prototype.GetAjaxUrl = function(a,b,c,d)
	    {
			if (arguments.callee && arguments.callee.caller)
			{
				var e = a.split(';'); e = e[e.length-1];
				return this.hookedGetAjaxUrl(e,e,c,d);
			}
			return this.hookedGetAjaxUrl(a,b,c,d);
	    }
	    RadComboBox.prototype.GetText = function()
	    {
			if (arguments.callee && arguments.callee.caller && arguments.callee.caller == this.OnCallBackResponse)
			{
				var e = this.InputDomElement.value.split(';'); e = e[e.length-1];
				return e;
			}
			return this.InputDomElement.value;
		}
	-->
	</script>

	<style type="text/css">
		iframe#<%= txtTo.ClientID %>_Overlay,
		iframe#<%= txtCC.ClientID %>_Overlay,
		iframe#<%= txtBcc.ClientID %>_Overlay
		{
			display: none !important;
		}
	</style>
</asp:Content>

