<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false"
    Codebehind="frmMyStatistics.aspx.cs" Inherits="SMWeb05.Main.frmMyStatistics" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BPH" runat="server">
    <SMWC:SkinTextImageButton ID="GetReportButton" runat="server" CssClass="ButtonBarImageButton"
        ResourceIDGlobal="@GetReport" ImageFile="Icons/GetReport.png"></SMWC:SkinTextImageButton>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MPH" runat="server">
    <table class="SettingsContent">
        <tr>
            <td class="SettingsHeader" colspan="2">
                <STWC:GlobalizedLabel ID="GlobalizedLabel5" ResourceIDGlobal="@ReportSettingsHeader" runat="server" />
            </td>
        </tr><tr>
            <td class="SettingsLabel">
                <STWC:GlobalizedLabel ResourceIDGlobal="@StartDate" ID="Globalizedlabel1" runat="server"></STWC:GlobalizedLabel>
            </td>
            <td class="SettingsSetting">
                <SMWC:PopupCalendar runat="server" ID="calStartDate" FormName="aspnetForm"></SMWC:PopupCalendar>
            </td>
        </tr>
        <tr>
            <td class="SettingsLabel">
                <STWC:GlobalizedLabel ResourceIDGlobal="@EndDate" ID="Globalizedlabel6" runat="server"></STWC:GlobalizedLabel>
            </td>
            <td class="SettingsSetting">
                <SMWC:PopupCalendar runat="server" ID="calEndDate" FormName="aspnetForm"></SMWC:PopupCalendar>
            </td>
        </tr>
    </table>
    <table class="ReportContent">
        <tr>
            <td class="ReportHeader">
                <STWC:GlobalizedLabel ResourceIDPage="Statistics" ID="Globalizedlabel2" runat="server"></STWC:GlobalizedLabel>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="ReportLabel">
                            <STWC:GlobalizedLabel ResourceIDPage="ReceivedMessages" ID="Globalizedlabel3" runat="server"></STWC:GlobalizedLabel>
                        </td>
                        <td class="ReportValue">
                            <asp:Label ID="MessagesReceivedLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ReportLabel">
                            <STWC:GlobalizedLabel ResourceIDPage="SentMessages" ID="Globalizedlabel4" runat="server"></STWC:GlobalizedLabel>
                        </td>
                        <td class="ReportValue">
                            <asp:Label ID="MessagesSentLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ReportLabel">
                            <STWC:GlobalizedLabel ResourceIDPage="SpaceUsed" ID="Globalizedlabel8" runat="server"></STWC:GlobalizedLabel>
                        </td>
                        <td class="ReportValue">
                            <asp:Label ID="SpaceUsedLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ReportLabel">
                            <STWC:GlobalizedLabel Visible="false" ResourceIDPage="JunkFolder" ID="Globalizedlabel11" runat="server"></STWC:GlobalizedLabel>
                        </td>
                        <td class="ReportValue">
                            <asp:Label ID="JunkSpaceUsedLabel" Visible="false" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ReportLabel">
                            <STWC:GlobalizedLabel ResourceIDPage="DeletedFolder" ID="Globalizedlabel12" runat="server"></STWC:GlobalizedLabel>
                        </td>
                        <td class="ReportValue">
                            <asp:Label ID="DeletedSpaceUsedLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
