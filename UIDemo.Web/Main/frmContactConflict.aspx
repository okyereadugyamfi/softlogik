<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmContactConflict.aspx.cs" Inherits="SMWeb05.Main.frmContactConflict" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">

	<script type="text/javascript">
		function ShowToolTip(txt)
		{
			document.getElementById('QuickViewDiv').style.display = '';
			document.getElementById('QuickViewDiv').innerHTML = txt;
		}
		function HideToolTip(txt)
		{
			document.getElementById('QuickViewDiv').style.display = "none";
			document.getElementById('QuickViewDiv').innerHTML = '';
		}
	</script>

	<table class="SettingsContent">
		<tr>
			<td colspan="2">
				<div class="SettingsNote">
					<asp:Label ID="lblConflictNote" runat="server"></asp:Label>
				</div>
			</td>
		</tr>
		<tr>
			<td class="SettingsSettingSingle">
				<SMWC:SkinTextImageButton ID="btnAddNewContact" runat="server" ResourceIDPage="AddNewContact" CssClass="ButtonBarImageButton" ImageFile="icons/addcontact.png"></SMWC:SkinTextImageButton>
				<br />
				<br />
				<SMWC:SkinTextImageButton ID="btnReplaceExistingContact" runat="server" ResourceIDPage="ReplaceExistingContact" CssClass="ButtonBarImageButton" ImageFile="icons/addcontact.png"></SMWC:SkinTextImageButton>
				&nbsp;
				<asp:DropDownList ID="ddlSimilarContacts" runat="server">
				</asp:DropDownList><br />
				<br />
				<SMWC:SkinTextImageButton ID="btnSkipThisContact" runat="server" ResourceIDPage="SkipThisContact" CssClass="ButtonBarImageButton" ImageFile="icons/addcontact.png"></SMWC:SkinTextImageButton>
			</td>
		</tr>
	</table>
	<table class="SettingsContent">
		<tr>
			<td class="SettingsHeader" colspan="2">
				<STWC:GlobalizedLabel ID="lblNewContactTitle" runat="server" ResourceIDPage="NewContactTitle"></STWC:GlobalizedLabel>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Table CssClass="TabStripContent" ID="tblNewContact" runat="server">
				</asp:Table>
			</td>
			<td style="width: 300px;" class="SettingsSetting">
				<div id="QuickViewDiv" style="display: none; position: absolute; background-color:LightYellow; border: solid 1px black;">
				</div>
			</td>
		</tr>
	</table>
	<table class="SettingsContent">
		<tr>
			<td class="SettingsHeader">
				<STWC:GlobalizedLabel ID="lblCloseMatches" runat="server" ResourceIDPage="CloseMatches"></STWC:GlobalizedLabel>
			</td>
		</tr>
		<tr>
			<td>
				<STWC:HoverGrid ID="dgCloseMatches" runat="server" AllowSorting="True" AutoGenerateColumns="False" Width="100%" HG_HoverEnabled="True" HG_StandardSettings="True" HG_ColumnExclusionIndexes="0,1,2,3,4" HG_EditURLField="editURL">
					<Columns>
						<asp:boundcolumn datafield="Index">
							<headerstyle width="1%"></headerstyle>
						</asp:boundcolumn>
						<asp:boundcolumn datafield="QuickViewImage">
							<headerstyle width="1%"></headerstyle>
						</asp:boundcolumn>
						<asp:boundcolumn datafield="Name"></asp:boundcolumn>
						<asp:boundcolumn datafield="Email"></asp:boundcolumn>
						<asp:boundcolumn visible="False" datafield="ID"></asp:boundcolumn>
					</Columns>
				</STWC:HoverGrid>
			</td>
		</tr>
	</table>
</asp:Content>

