//if (window.attachEvent)
//{
//	window.attachEvent("onresize", function () { window.setTimeout(ActualSplitResize, 5) } );
//	window.attachEvent("onload", ActualSplitResize);
//}

//if (window.addEventListener)
//{
//	window.addEventListener("resize", ActualSplitResize, true);			
//	window.addEventListener("load", ActualSplitResize, true);		
//}


var sper = readCookie('SMailSplitSize');
var percent = parseInt(sper);
if (percent.toString() == "NaN")
	percent = 0;

function ActualSplitResize()
{
	var body = document.getElementById('GridArea');
	var bodydiv = document.getElementById('GridAreaDiv');
	var body2div = document.getElementById('PreviewArea');
	var body2 = document.getElementById('MessagesPreview');
	var pager = document.getElementById('MessagesPager');
	var search = document.getElementById('SearchRow');
	var iframe = document.getElementById('contentframe');
	var menu = document.getElementById('MenuBar');
	var panel = document.getElementById('TopPanel');
	var button = document.getElementById('ButtonBar');
	
	var documentObj = document.documentElement;
	if (window.opera || (document.all && !(document.compatMode && document.compatMode == "CSS1Compat")))
		documentObj = document.body;
	
	var size = parseInt(documentObj.clientHeight) - 17;
	if (pager)
		size = size - pager.offsetHeight;
	if (button)
		size = size - button.offsetHeight;
	if (panel)
		size = size - panel.offsetHeight;
	if (menu)
		size = size - menu.offsetHeight;
	if (search)
		size = size - search.offsetHeight;
		
	if (percent<=1)
		percent = size * 0.5;
		
	var topsize = percent;

	if (topsize > size - 50)
		topsize = size - 50;
		
	var bottomsize = size - topsize +1;

	if (bottomsize>0)
	{
		if (iframe!=null)
			iframe.style.height = bottomsize + "px";
		body2div.style.height = bottomsize + "px";
		body2.style.height = bottomsize + "px";
	}
	if (topsize>0)
	{
		bodydiv.style.height = topsize + "px";
		body.style.height = topsize + "px";
	}
		
}



setDocumentOnmouse();
function setDocumentOnmouse(){
    window.document.onmouseup = splitMouseUp;
    if(document.all) 
		document.onmousemove = splitMouseMove; 
    else if(document.layers)
		window.onmousemove = splitMouseMove;
    else 
		window.document.onmousemove = splitMouseMove; 
}

var dragging=false;
var startx=0;
var starty=0;
var originalpercent=0.5;
function splitMouseDown(evt)
{
	if (evt==null)
		evt=event;
		evt.cancelBubble=true;
	dragging=true;
	startx = evt.screenX;
	starty = evt.screenY;
	originalpercent = percent;
	
	
    if(document.all) 
		frames['contentframe'].document.onmousemove = splitMouseMove; 
    else if(document.layers)
		frames['contentframe'].onmousemove = splitMouseMove;
    else 
		frames['contentframe'].document.onmousemove = splitMouseMove; 
		
		frames['contentframe'].document.onmouseup = splitMouseUp;

}

function splitMouseMove(evt)
{
	if (dragging==false)
		return;
		dragging=false;
	if (evt==null)
		evt=event;
	if (evt==null)
		evt=frames['contentframe'].event;
	var documentObj = document.documentElement;
	if (window.opera || (document.all && !(document.compatMode && document.compatMode == "CSS1Compat")))
		documentObj = document.body;

	var pager = document.getElementById('MessagesPager');
	var size = parseInt(documentObj.clientHeight) - 112;
	if (pager)
		size = parseInt(documentObj.clientHeight) - pager.offsetHeight - 88;

	var curx = evt.screenX - startx;
	var cury = evt.screenY - starty;
	percent = originalpercent + cury;
		
	if (percent < 100)
		percent = 100;
	if (percent > size - 50)
		percent = size - 50;
	
	createCookie('SMailSplitSize',percent.toString(),30);
	
	ActualSplitResize();
	if (frames['contentframe'].ActualResize!=null)
		frames['contentframe'].ActualResize();
	
	if (document.body.focus)
		document.body.focus();
	dragging=true;
	return false;
}

function splitMouseUp(evt)
{
	if (evt==null)
		evt=event;
	dragging=false;
}
