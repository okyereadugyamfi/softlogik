<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmFolderAutoCleanAdd.aspx.cs" Inherits="SMWeb05.Main.frmFolderAutoCleanAdd" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="SaveTextImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Save.png" ResourceIDGlobal="@Save" OnClick="SaveTextImageButton_Click" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="CancelTextImageButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/Cancel_close.png" ResourceIDGlobal="@Cancel" NavigateURL="frmFolderAutoClean.aspx?view=true" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">

	<script type="text/javascript">
		function UpdateType()
		{
			if (document.getElementById("<%= radSize.ClientID %>").checked==true)
			{
				document.getElementById("trSize1").style.display = "";
				document.getElementById("trSize2").style.display = "";
				document.getElementById("trDate").style.display = "none";
			}
			else
			{
				document.getElementById("trSize1").style.display = "none";
				document.getElementById("trSize2").style.display = "none";
				document.getElementById("trDate").style.display = "";
			}
		}
	</script>

	<table class="SettingsContent">
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel runat="server" ResourceIDGlobal="@Folder" ID="Globalizedlabel16" />
			</td>
			<td class="SettingsSetting">
				<asp:DropDownList ID="ddFolder" runat="server" />
			</td>
		</tr>
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel runat="server" ResourceIDGlobal="@EnableAutoClean" ID="Globalizedlabel4" /></td>
			<td class="SettingsSetting">
				<STWC:GlobalizedCheckbox runat="server" ID="chkEnable" ResourceIDGlobal="@Enabled"></STWC:GlobalizedCheckbox>
			</td>
		</tr>
		<tr>
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel runat="server" ResourceIDGlobal="@Type" ID="Globalizedlabel6" />
			</td>
			<td class="SettingsSetting">
				<STWC:GlobalizedRadioButton ID="radSize" runat="server" GroupName="cleanType" onclick="UpdateType()" Checked="true" ResourceIDGlobal="@Size" />
				<STWC:GlobalizedRadioButton ID="radDate" runat="server" GroupName="cleanType" onclick="UpdateType()" ResourceIDGlobal="@Date" />

			</td>
		</tr>
		<tr id="trDate" style="display: none">
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel runat="server" ResourceIDGlobal="@AutoCleanDate" ID="Globalizedlabel3" /></td>
			<td class="SettingsSetting">
				<asp:TextBox ID="txtDays" runat="server" Columns="3"></asp:TextBox>&nbsp;
				<STWC:GlobalizedLabel runat="server" ResourceIDGlobal="@Days" ID="Globalizedlabel5" />
			</td>
		</tr>
		<tr id="trSize1">
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel runat="server" ResourceIDGlobal="@SizeBeforeClean" ID="Globalizedlabel1" /></td>
			<td class="SettingsSetting">
				<asp:TextBox ID="txtBefore" runat="server" Columns="2"></asp:TextBox>&nbsp;
				<STWC:GlobalizedLabel runat="server" ResourceIDGlobal="@MB" ID="Globalizedlabel13" />
			</td>
		</tr>
		<tr id="trSize2">
			<td class="SettingsLabel">
				<STWC:GlobalizedLabel runat="server" ResourceIDGlobal="@GoalSize" ID="Globalizedlabel2" />
			</td>
			<td class="SettingsSetting">
				<asp:TextBox ID="txtAfter" runat="server" Columns="2"></asp:TextBox>&nbsp;
				<STWC:GlobalizedLabel runat="server" ResourceIDGlobal="@MB" ID="Globalizedlabel9" />
			</td>
		</tr>
	</table>

	<script type="text/javascript">
		UpdateType();
	</script>

</asp:Content>

