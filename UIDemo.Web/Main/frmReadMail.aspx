<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmReadMail.aspx.cs" Inherits="SMWeb05.Main.frmReadMail" %>

<%@ Register Assembly="RadMenu.Net2" Namespace="Telerik.WebControls" TagPrefix="radM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<div style="display: block; float: left;">
		<SMWC:SkinTextImageButton ID="ReplyImageButton" runat="server" ImageFile="Icons/Reply.png" ResourceIDPage="Reply" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
		<SMWC:SkinTextImageButton ID="ReplyAllImageButton" runat="server" ImageFile="Icons/ReplyAll.png" NavigateURL="frmDomain.aspx" ResourceIDPage="ReplyAll" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
		<SMWC:SkinTextImageButton ID="ForwardImageButton" runat="server" ImageFile="Icons/Forward.png" ResourceIDPage="Forward" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
		<SMWC:SkinTextImageButton ID="SpamImageButton" runat="server" ImageFile="Icons/markSpam.png" ResourceIDPage="ThisIsSpam" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
		<SMWC:SkinTextImageButton ID="DeleteImageButton" runat="server" ImageFile="Icons/trash.png" ResourceIDGlobal="@DeleteCap" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
		<SMWC:SkinTextImageButton ID="PrintImageButton" runat="server" ImageFile="Icons/Print.png" Visible="true" ResourceIDGlobal="@Print" CssClass="ButtonBarImageButton" NavigateURL="javascript:print_iframe('contentframe');"></SMWC:SkinTextImageButton>
	</div>
	<radM:RadMenu ID="MoveMenu" runat="server">
		<Items>
			<radM:RadMenuItem ID="MoveTo" runat="server" Text="@Action" ImageUrl="Images/Icons/MoveTo.png">
				<Items>
				</Items>
			</radM:RadMenuItem>
		</Items>
	</radM:RadMenu>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="BackImageButton" runat="server" ImageFile="Icons/Back.png" ResourceIDGlobal="@Back" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MPH" runat="server">
	<table class="Container">
		<tr>
			<td class="ReadMailFrame">
				<asp:Literal runat="server" ID="BodyPlainTextLiteral"></asp:Literal>
			</td>
		</tr>
	</table>

	<script type="text/javascript">
    var curID='<%=VSMessageIDString %>';
    var origID='<%=VSMessageIDString %>';
    function print_iframe(frame_name) 
    {
        frames[frame_name].BeginPrint();
        var iFrm = window.frames[frame_name];
        if (iFrm) 
        {
            iFrm.focus(); //IE requirement
            iFrm.print();
        }
        frames[frame_name].EndPrint();
    }
    
    function SetID(id)
    {
        curID=id;
    }
    
    function DoNothing()
    {
    
    }
    
    function Move(url)
    {
        
        url=url.replace(origID,curID);
        var ifrm=frames['contentframe'];
        if(ifrm)
        {
            ifrm.location.href=url;
        }
    }
    
    function reply(url)
    {
        url=url.replace(origID,curID);
        location.href=url + "&returnPath=" + escape(location.href).replace(origID,curID);
    }
    
    function Next(url,id)
    {
        curID=id;
        var ifrm=frames['contentframe'];
        if(ifrm)
        {
            ifrm.location.href=url;
        }
    }
	</script>

</asp:Content>

