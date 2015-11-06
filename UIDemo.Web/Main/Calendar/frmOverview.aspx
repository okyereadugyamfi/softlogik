<%@ Page Language="C#" MasterPageFile="~/MasterPages/Dummy.Master" AutoEventWireup="false" Codebehind="frmOverview.aspx.cs" Inherits="SMWeb05.Main.Calendar.frmOverview"  %>

<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="radA" %>
<%@ Register Assembly="RadCalendar.Net2" Namespace="Telerik.WebControls" TagPrefix="radCln" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BPH" runat="server">
	<SMWC:SkinTextImageButton ID="AddEventButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/newAppointment.png" ResourceIDPage="AddEvent" />
	<SMWC:SkinTextImageButton ID="OutlookButton" runat="server" CssClass="ButtonBarImageButton" ImageFile="Icons/AddOutlook.png" ResourceIDGlobal="@AddToOutlook" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BrPH" runat="server">
	<SMWC:SkinTextImageButton ID="PreviousImageButton" runat="server" ImageFile="Icons/previous.png" ResourceIDGlobal="@Previous" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
	<SMWC:SkinTextImageButton ID="NextImageButton" runat="server" ImageFile="Icons/next.png" ResourceIDGlobal="@Next" CssClass="ButtonBarImageButton"></SMWC:SkinTextImageButton>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MPH" runat="server">
  
	<script type="text/javascript">
	    DeleteOldSelectedDates = function(e)
	    {   
	        var calendar = <%= Calendar2.ClientID %>;	        
	        var target = FindTarget(e);  
	
			if (target.id.indexOf("_cs") > -1)
            {           
				ClearAll();
                
                var colnum = -1;
                
                var tableRows = target.parentNode.parentNode.getElementsByTagName("tr");
                for(var j=0; j<tableRows.length; j++)
				{
					var rowCells = tableRows[j].getElementsByTagName("td");
	                if (colnum==-1)
	                {
						for(var i=0; i<rowCells.length; i++)
						{
							if(rowCells[i]==target)             
							{
								colnum=i;
							}
						}
					}
					else
					{
						var date = GetDateFromID(rowCells[colnum].DayId);   
						calendar.SelectDate(date);
					
					}
                }
            }    
			
		    if (target.id.indexOf("_rs") > -1)
            {           
				ClearAll();
                var rowCells = target.parentNode.getElementsByTagName("td");
                
                for(var i=0; i<rowCells.length; i++)
                {
                    if(rowCells[i].DayId)             
                    {
                        var date = GetDateFromID(rowCells[i].DayId);                        
                        calendar.SelectDate(date);
                    }
                }
            }     
            if (target.id.indexOf("_vs") > -1)
            {           
				ClearAll();
				var select = false;
                
                var tableRows = target.parentNode.parentNode.getElementsByTagName("tr");
                for(var j=0; j<tableRows.length; j++)
				{
					var rowCells = tableRows[j].getElementsByTagName("td");
	                
					for(var i=0; i<rowCells.length; i++)
					{
						if(rowCells[i].DayId)             
						{
							var date = GetDateFromID(rowCells[i].DayId);
							if (date[2]==1)
								select=!select;
							if (select==true)
								calendar.SelectDate(date);
						}
					}
                }
            }   
                   	        
	    }
	    
	    ClearAll = function(e)
        {
            var calendar = <%= Calendar2.ClientID %>;            
            calendar.UnselectDates(calendar.GetSelectedDates());
        }
        
        AddEvent = function()
        {
            var calendar = document.getElementById("<%= Calendar2.ClientID %>");
            if (typeof(calendar.addEventListener)!= "undefined")
	        {
		        calendar.addEventListener("click", DeleteOldSelectedDates, false);
	        }
	        else if (calendar.attachEvent)
	        {
		        calendar.attachEvent("onclick", DeleteOldSelectedDates);
	        }
        }
        
        FindTarget = function(e) 
        { 
            var target; 
            if (e && e.target) //other browsers
            { 
                target = e.target; 
            } 
            else if (window.event && window.event.srcElement) //IE
            { 
                target = window.event.srcElement; 
            }
            
            if (!target) 
            { 
                return null; 
            } 
            
            while (target != null)
            {      
                if (target.tagName.toLowerCase() == 'td')
                {
                    break;
                }                
                target = target.parentNode;                
            }
            
            if (target.tagName.toLowerCase() != 'td')
            { 
                return null; 
            }             
            return target;
        }
          
        GetDateFromID = function(ID)
        {
            var name = ID.split("_");
            var date = [parseInt(name[5]), parseInt(name[6]), parseInt(name[7])];
            return date;
        }        
	</script>

	<script type="text/javascript">
				function OpenPopup(type,name,shareowner,calname)
				{
					var popurl="../frmPopupAddToOutlook.aspx?type=" + type + "&name=" + name + "&shareowner=" + shareowner + "&calname=" + calname;
					winpops=window.open(popurl,"popupwindow","width=475,height=297,scrollbars,resizable=yes")
				}
	</script>

	<div id="trShareInfo" runat="server" class="sharebar">
		<asp:Literal runat="server" ID="ShareLiteral"></asp:Literal>
	</div>
	<table class="CalendarTable">
		<tr>
			<td class="CalendarLeft">
				<table class="CalendarTable">
					<tr runat="server" id="dayView">
						<td class="CalendarDay">
							<asp:Literal runat="server" ID="dayLiteral"></asp:Literal>
						</td>
					</tr>
					<tr runat="server" id="multiDaysView">
						<td class="CalendarMultiDay">
							<asp:Repeater runat="server" ID="multiDaysRepeater">
								<HeaderTemplate>
									<table class="CalMultiDay">
								</HeaderTemplate>
								<ItemTemplate>
									<tbody>
										<tr valign="top">
											<td class="CalMultiDayLeft">
												<%# DataBinder.Eval(Container.DataItem, "dayOfWeek") %>
												<br>
												<%# DataBinder.Eval(Container.DataItem, "day") %>
											</td>
											<td class="CalMultiDayRight">
												<%# DataBinder.Eval(Container.DataItem, "events") %>
											</td>
										</tr>
								</ItemTemplate>
								<FooterTemplate>
									</TBODY> </TABLE>
								</FooterTemplate>
							</asp:Repeater>
						</td>
					</tr>
					<tr runat="server" id="monthView">
						<td class="CalendarMonth">
							<radCln:RadCalendar ID="MainCalendar" runat="server" EnableRowSelectors="False" EnableColumnSelectors="False" EnableNavigation="False" EnableMultiSelect="False" OnDayRender="MainCalendar_DayRender" AutoPostBackOnDayClick="false">
							</radCln:RadCalendar>
						</td>
					</tr>
				</table>
			</td>
			<td class="CalendarRight">
				<table class="RightTable" id="tblDate" runat="server">
					<tr runat="server" id="tblDateMonth">
					</tr>
					<tr id="RowCal" runat="server">
						<td colspan="5" class="RightCalendar" align="center">
							<radCln:RadCalendar ID="Calendar2" runat="server" OperationType="Server" EnableColumnSelectors="true" AutoPostBackOnDayClick="true" OnSelectionChanged="Calendar2_SelectionChanged" EnableViewSelector="true" OnDefaultViewChanged="Calendar2_DefaultViewChanged" OnDayRender="Calendar2_DayRender">
								<ClientEvents OnDateClick="ClearAll" OnLoad="AddEvent" />
							</radCln:RadCalendar>
						</td>
					</tr>
					<tr runat="server" id="tblDateYear">
					</tr>
				</table>
				<br />
				<table class="RightTable" id="RowCalTable2" runat="server">
					<tr runat="server" id="tblDateMonth2">
					</tr>
					<tr id="RowCal2" runat="server">
						<td colspan="3" class="RightCalendar" align="center">
							<radCln:RadCalendar ID="RightCalendar2" runat="server" PresentationType="Preview" EnableRowSelectors="False" EnableNavigation="False" EnableMultiSelect="False" OnDayRender="RightCalendar2_DayRender" ShowOtherMonthsDays="False">
							</radCln:RadCalendar>
						</td>
					</tr>
				</table>
				<br />
				<table class="RightTable" id="LegendTable" runat="server">
					<tr>
						<td class="RightTable" colspan="2">
							<STWC:GlobalizedLabel ID="Globalizedlabel6" runat="server" ResourceIDPage="Legend">
							</STWC:GlobalizedLabel>
						</td>
					</tr>
					<tr>
						<td class="LegendLeft">
							<asp:Image runat="server" ID="monthSelectImage"></asp:Image></td>
						<td class="LegendRight">
							<STWC:GlobalizedLabel ID="Globalizedlabel1" runat="server" ResourceIDPage="LegendMonthSelect">
							</STWC:GlobalizedLabel></td>
					</tr>
					<tr>
						<td class="LegendLeft">
							<asp:Image runat="server" ID="weekSelectImage"></asp:Image></td>
						<td class="LegendRight">
							<STWC:GlobalizedLabel ID="Globalizedlabel2" runat="server" ResourceIDPage="LegendWeekSelect">
							</STWC:GlobalizedLabel></td>
					</tr>
					<tr>
						<td class="LegendLeft">
							<div class="CalDay">
								##
							</div>
						</td>
						<td class="LegendRight">
							<STWC:GlobalizedLabel ID="Globalizedlabel3" runat="server" ResourceIDPage="LegendNoEvents">
							</STWC:GlobalizedLabel></td>
					</tr>
					<tr>
						<td class="LegendLeft">
							<div class="CalDayBold">
								##</div>
						</td>
						<td class="LegendRight">
							<STWC:GlobalizedLabel ID="Globalizedlabel4" runat="server" name="Globalizedlabel4" ResourceIDPage="LegendEvents">
							</STWC:GlobalizedLabel></td>
					</tr>
					<tr>
						<td class="LegendLeft">
							<div class="CalDayToday">
								##</div>
						</td>
						<td class="LegendRight">
							<STWC:GlobalizedLabel ID="Globalizedlabel5" runat="server" name="Globalizedlabel5" ResourceIDPage="LegendToday">
							</STWC:GlobalizedLabel></td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</asp:Content>

