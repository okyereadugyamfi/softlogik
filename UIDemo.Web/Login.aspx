<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="false" AutoEventWireup="false" Codebehind="Login.aspx.cs" Inherits="SMWeb05.Login" MasterPageFile="~/MasterPages/Dummy.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PH" runat="server">
	<table class="LoginContent">
		<tr>
			<td style="padding-right: 6px">
				<STWC:GlobalizedLabel ResourceIDPage="FullEmail" ID="Glbl1" runat="server" />
				<STWC:GlobalizedLabel ResourceIDPage="Example" ID="Glbl2" runat="server" />
				<br />
				<asp:TextBox ID="txtUserName" runat="server" Style="width: 100%" />
			</td>
		</tr>
		<tr>
			<td style="padding-right: 6px">
				<STWC:GlobalizedLabel ResourceIDGlobal="@Password" ID="Glbl3" runat="server" /><br />
				<asp:TextBox ID="txtPassword" runat="server" Style="width: 100%" TextMode="Password" />
			</td>
		</tr>
		<tr>
			<td>
				<STWC:GlobalizedLabel ResourceIDPage="Language" ID="Glbl4" runat="server" /><br />
				<asp:DropDownList runat="server" ID="LanguageList" AutoPostBack="True" OnSelectedIndexChanged="LanguageList_SelectedIndexChanged" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:CheckBox ID="chkAutoLogin" runat="server" Text="$RememberMe" />
			</td>
		</tr>
		<tr>
			<td align="right">
				<asp:ImageButton runat="server" AlternateText=" " ID="btnEnterClick" ImageUrl="s.gif" TabIndex="-1" Width="1" Height="1" OnClick="btnEnterClick_Click" />
				<SMWC:SkinTextImageButton ID="LoginImageButton" runat="server" ResourceIDPage="Login" CssClass="LoginImageButton" ImageFile="Icons/Lock.png" OnClick="LoginImageButton_Click" />
				&nbsp;&nbsp;&nbsp;&nbsp;
				<SMWC:SkinTextImageButton ID="HelpImageButton" runat="server" ResourceIDPage="Help" CssClass="LoginImageButton" ImageFile="Icons/HelpWhite.png" NavigateTarget="helpwindow" NavigateURL="http://www.smartertools.com/Help/SmarterMail/Pro/v4/Default.aspx?page=Login.aspx" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label runat="server" ID="TheError" CssClass="TipTextLoginFailure" />
			</td>
		</tr>
	</table>
</asp:Content>

