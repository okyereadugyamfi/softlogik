function EnterHandler(e,func)
{		
	if((document.all?window.event.keyCode:e.which) == 13) 
	{
		func();
		return false;
	}
} 
function BringUpHelp(webpage) 
{
	var url = webpage;
	var hWnd = window.open(url, "smartertoolshelp", "width=750,height=375,toolbar=yes,resizable=yes,scrollbars=yes,location=yes,menubar=yes, status=yes");
	if (hWnd != null) 
	{     
		if (hWnd.opener == null) 
		{ 
			hWnd.opener = self; 
			window.name = "smartertoolshelp"; 
			hWnd.location.href=url; 
		} 
		hWnd.focus();
	}
}

function BringUpSidebarHelp(webpage) 
{
	var url = webpage;
	var hWnd = window.open(url, "smartertoolssidebarhelp", "width=400,height=275,resizable=yes,scrollbars=yes,status=no,toolbar=no");
	if (hWnd != null) 
	{     
		if (hWnd.opener == null) 
		{ 
			hWnd.opener = self; 
			window.name = "smartertoolssidebarhelp"; 
			hWnd.location.href=url; 
		} 
	}
}

function BringUpWindow(webpage) 
{
	var url = webpage;
	var hWnd = window.open(url, "ProgramWindow", "width=300,height=350,resizable=no,scrollbars=yes,status=yes");
	if (hWnd != null) 
	{     
		if (hWnd.opener == null) 
		{	
			hWnd.opener = self; 
			window.name = "home"; 
			hWnd.location.href=url; 
		} 
	}
}

function ShowMenu(url)
{
	var MenuBack;
	if (MenuBack == null || MenuBack.Closed)
	{
		MenuBack = window.open(url, "", "menubar=no,status=no,scrollbars=yes,resizable=no,width=225,height=285,toolbar=no,location=no,directories=no");
	}
	MenuBack.focus()
}

function BringUpWindow_SSVersion(webpage) 
{
	var url = webpage;
	var hWnd = window.open(url, "SmarterTools",	"width=806,height=450,resizable=yes,scrollbars=yes,status=yes,toolbar=yes,location=yes,menubar=yes");
	if (hWnd != null) 
	{     
		if (hWnd.opener == null) 
		{ 
			hWnd.opener = self; 
			window.name = "smartertoolshelp"; 
			hWnd.location.href=url; 
		} 
	}
}

function BringUpComposeWIndow(webpage) 
{
	var url = webpage;
	var hWnd = window.open(url, "Compose", "");
	if (hWnd != null) 
	{     
		if (hWnd.opener == null) 
		{ 
			hWnd.opener = self; 
			window.name = "home"; 
			hWnd.location.href=url; 
		} 
	}
}

function BringUpImpersonationWindow(webpage) 
{
	var url = webpage;
	var hWnd = window.open(url, "newdomainwindow", "");
	if (hWnd != null) 
	{     
		if (hWnd.opener == null) 
		{ 
			hWnd.opener = self; 
			window.name = "home"; 
			hWnd.location.href=url; 
		} 
	}
}

//var disabledmessage="Function Disabled!";
///////////////////////////////////
//function clickIE() {if (document.all) {alert(disabledmessage);return false;}}
//function clickNS(e) {if 
//	(document.layers||(document.getElementById&&!document.all)) {
//if (e.which==2||e.which==3) {alert(disabledmessage);return false;}}}
//if (document.layers) 
//	{document.captureEvents(Event.MOUSEDOWN);document.onmousedown=clickNS;}
//else{document.onmouseup=clickNS;document.oncontextmenu=clickIE;}
//
//document.oncontextmenu=new Function("return false")

function openpopupwotoolbar(popurl, name, lr, tb)
{
	var winpops = window.open(popurl, name, "width="+lr+",height="+tb+",scrollbars,resizable")
	if (winpops != null) 
	{     
		winpops.focus();
	}
}

function BringUpAbout(webpage) 
{
	var url = webpage;
	var hWnd = window.open(url, "SmarterMail_Professional_Edition",	"width=370,height=220,resizable=no,scrollbars=yes,status=no,toolbar=no");
	if (hWnd != null) 
	{     
		if (hWnd.opener == null) 
		{ 
			hWnd.opener = self; 
			window.name = "home"; 
			hWnd.location.href=url; 
		} 
	}
}

function createCookie(name,value,days) {
	if (days) {
		var date = new Date();
		date.setTime(date.getTime()+(days*24*60*60*1000));
		var expires = "; expires="+date.toGMTString();
	}
	else var expires = "";
	document.cookie = name+"="+value+expires+"; path=/";
}

function readCookie(name) {
	var nameEQ = name + "=";
	var ca = document.cookie.split(';');
	for(var i=0;i < ca.length;i++) {
		var c = ca[i];
		while (c.charAt(0)==' ') c = c.substring(1,c.length);
		if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
	}
	return null;
}

function eraseCookie(name) {
	createCookie(name,"",-1);
}