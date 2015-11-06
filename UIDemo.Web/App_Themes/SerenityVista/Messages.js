var currentUrl=null;
var refresh = 0;
var callback=null;
var requesting = false;
function SetupAutoCallback(param)
{
	refresh=param;
	window.clearTimeout(callback);
	if (refresh>=60000)	callback=window.setTimeout("AutoCallback();",refresh);
}
function AutoCallback()
{
	DoCommand("Refresh");
	window.clearTimeout(callback);
	callback=window.setTimeout("AutoCallback();",refresh);
}

		
function GridCreated()
{
	RadGrid1 = this;
	ViewSelected();
}
function CheckAll()
{ 
	isChecked = !isChecked;

	var checkboxes = RadGrid1.MasterTableView.Control.getElementsByTagName("INPUT");
	var index;

	for(index = 0; index < checkboxes.length; index++)
	{
		if(isChecked)
		{
			checkboxes[index].checked = true;
		}  
		else
		{
			checkboxes[index].checked = false;
		}
	}
}
function OpenNew()
{
	var rows = RadGrid1.MasterTableView.Rows;
	var i = 0;
	for (i = 0; i < rows.length; i++)
	{
	    var check = RadGrid1.MasterTableView.GetCellByColumnUniqueName(rows[i],"chk").getElementsByTagName("INPUT");
        if (check[0].checked)
        {	
			var url = RadGrid1.MasterTableView.GetCellByColumnUniqueName(rows[i],"url").innerHTML;
			url = url.replace(/frmreadmail_body/i,"frmReadMail");
			url = url.replace(/&amp;/gi,"&");
			url = url.replace(/&lt;/gi,"<");
			url = url.replace(/&gt;/gi,">");
			window.open(url,'','');
			
		}
	}

}
function UndeleteChecked()
{
	DoCommand("UndeleteChecked " + GetSelectedIDs());
}
function MarkRead()
{
	DoCommand("MarkRead " + GetSelectedIDs());
}
function UnmarkRead()
{
	DoCommand("UnmarkRead " + GetSelectedIDs());
}
function MarkSpam()
{
	DoCommand("MarkSpam " + GetSelectedIDs());
}
function UnmarkSpam()
{
	DoCommand("UnmarkSpam " + GetSelectedIDs());
}
function SearchToggle()
{
	if (document.getElementById(trSearchBar).style.display == 'none') 
	{
		if (document.getElementById('contentframe'))
		{
			document.getElementById('contentframe').style.height = (5) + "px";
			document.getElementById('PreviewArea').style.height = (5) + "px";
			document.getElementById('MessagesPreview').style.height = (5) + "px";
		}
		else
			document.getElementById('Scrollable').style.height = (document.getElementById('Scrollable').offsetHeight - 36) + "px"
		
		document.getElementById(trSearchBar).style.display = '';	
	}
	else 
	{
		document.getElementById(trSearchBar).style.display = 'none';
					
		if (document.getElementById(txtSearchString).value!='')
		{
			document.getElementById(txtSearchString).value = '';	
			DoSearch();
		}
	}
	
	ActualUserResize();
}

function DeleteChecked()
{
	var sel = GetSelectedIDs();
	if (sel.length==0)
	{
		CloseMenu();
		return;
	}
	if (confirm(DeleteConfirm))
		DoCommand("DeleteChecked " + sel);
}
function Purge()
{
	if (confirm(PurgeConfirm))
		DoCommand("Purge");
}
function DeleteAll()
{
	if (confirm(AtDeleteConfirm))
		DoCommand("DeleteAll");
}
function DoCommand(cmd)
{
	if (requesting)
		return;
	
	RadGrid1.AsyncRequest(GridID, cmd, GridID);
	CloseMenu();
	window.clearTimeout(callback);
	if (refresh>=60000)	
		callback=window.setTimeout("AutoCallback();",refresh)
}
function CloseMenu()
{
	menu.Disable();
	for (var i=0; i<menu.AllItems.length; i++)
	{
		menu.AllItems[i].Close();
	}
	window.setTimeout(menuCommand,500);
	isChecked = false; 
}
function DM(id)
{
	if (requesting)
		return;
	RadGrid1.AsyncRequest(GridID, "Delete " + id, GridID);
	CloseMenu();
}

function GetSelectedIDs()
{
	var IDs="";
	var rows = RadGrid1.MasterTableView.Rows;
	var i = 0;
	for (i = 0; i < rows.length; i++)
	{
	    var check = RadGrid1.MasterTableView.GetCellByColumnUniqueName(rows[i],"chk").getElementsByTagName("INPUT");
        if (check[0].checked)
        {
			IDs = IDs + 
			RadGrid1.MasterTableView.GetCellByColumnUniqueName(rows[i],"id").innerHTML + "*" + 
			unescape(RadGrid1.MasterTableView.GetCellByColumnUniqueName(rows[i],"folder").innerHTML) + "*" + 
			unescape(RadGrid1.MasterTableView.GetCellByColumnUniqueName(rows[i],"owner").innerHTML) + "|";
		}
	}
	return IDs;
}
function ViewSelected()
{
	var rows = RadGrid1.MasterTableView.SelectedRows;
	currentUrl = null;
	var i = 0;
	for (i = 0; i < rows.length; i++)
	{
		var url = RadGrid1.MasterTableView.GetCellByColumnUniqueName(rows[i],"url").innerHTML +"&markUnread=false&msgX=" + escape(location.href);
		url = url.replace(/&amp;/gi,"&");
		url = url.replace(/&lt;/gi,"<");
		url = url.replace(/&gt;/gi,">");
		currentUrl = url;
		break;
	}
	
	if (document.getElementById("ReadMailFrame"))
	{
		if (currentUrl==null && autoView==true)
			 SetFrame("javascript:'';");
		else if (autoView == true)
			SetFrame(currentUrl);
	}
}
var curFrameUrl = null;
function SetFrame(newUrl)
{
	var mID = newUrl.indexOf("messageid=");
	var mID2 = -1;
	if (curFrameUrl != null)
		mID2 = curFrameUrl.indexOf("messageid=");
	if (mID != -1 && mID2 != -1)
	{
		var aID = newUrl.indexOf("&", mID);
		if (newUrl.substr(mID,aID-mID) == curFrameUrl.substr(mID2, aID-mID))
			return;
	}	
	frames['contentframe'].location.href = newUrl;
	curFrameUrl = newUrl;
}
function RequestStart()
{
	requesting = true;
	document.getElementById("divPager2").style.display = "none";
	document.getElementById("divLoading").style.display = "";
}

function RequestEnd()
{
	requesting = false;
	document.getElementById("divLoading").style.display = "none";
	document.getElementById("divPager2").style.display = "";
	
	var a = document.getElementById('divPager2');
	var b = document.getElementById('divPager');
	if (a && b)
		a.innerHTML = b.innerHTML;
	else if (a)
		a.innerHTML = "";
}
function RowSelected(rowObject)
{
	currentRow = rowObject.Index;
	var url = this.GetCellByColumnUniqueName(rowObject,"url").innerHTML + "&cRow=" + currentRow + "&msgX=" + escape(location.href);

	if (rowObject.Control.className=="GridAltRowUnread_Grid SelectedRow_Grid")
	{
		var icon = this.GetCellByColumnUniqueName(rowObject,"NewIcon").innerHTML;
		if (icon.toLowerCase() == "<img src=\"/app_themes/serenityvista/images/misc/unread.gif\">")
			this.GetCellByColumnUniqueName(rowObject,"NewIcon").innerHTML = "<img src=\"/App_Themes/SerenityVista/Images/Misc/Read.gif\">";
			
		rowObject.Control.className="GridAltRow_Grid SelectedRow_Grid";
		DecrementUnread();
		curFrameUrl = null;
	}
	if (rowObject.Control.className=="GridRowUnread_Grid SelectedRow_Grid")
	{
		var icon = this.GetCellByColumnUniqueName(rowObject,"NewIcon").innerHTML;
		if (icon.toLowerCase() == "<img src=\"/app_themes/serenityvista/images/misc/unread.gif\">")
			this.GetCellByColumnUniqueName(rowObject,"NewIcon").innerHTML = "<img src=\"/App_Themes/SerenityVista/Images/Misc/Read.gif\">";
			
		rowObject.Control.className="GridRow_Grid SelectedRow_Grid";	
		DecrementUnread();
		curFrameUrl = null;
	}
	
	var iframe=document.getElementById("ReadMailFrame");
	url = url.replace(/&amp;/gi,"&");
	url = url.replace(/&lt;/gi,"<");
	url = url.replace(/&gt;/gi,">");
	
	if (iframe==null)
	{
		url = this.GetCellByColumnUniqueName(RadGrid1.MasterTableView.Rows[currentRow],"url").innerHTML;
        url = url.replace(/frmreadmail_body/i,"frmReadMail");
        url = url.replace(/&amp;/gi,"&");
        url = url.replace(/&lt;/gi,"<");
        url = url.replace(/&gt;/gi,">");
        location.href = url + "&cRow=" + currentRow + "&returnPath=" + escape(location.href);
        return;
	}
	SetFrame(url);
	
}
function RowDoubleClick(rowObject)
{
	var url = this.GetCellByColumnUniqueName(RadGrid1.MasterTableView.Rows[rowObject],"url").innerHTML;
	url = url.replace(/frmreadmail_body/i,"frmReadMail");
	url = url.replace(/&amp;/gi,"&");
	url = url.replace(/&lt;/gi,"<");
	url = url.replace(/&gt;/gi,">");
	location.href = url + "&cRow=" + rowObject + "&returnPath=" + escape(location.href);
}
function MoveMenu(folder)
{
	var IDs=GetSelectedIDs();
	RadGrid1.AsyncRequest(GridID, "Move \"" + folder + "\" " + IDs, GridID);
	CloseMenu();
}