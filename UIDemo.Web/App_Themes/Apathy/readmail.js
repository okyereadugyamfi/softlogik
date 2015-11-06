if (window.attachEvent)
{
	window.attachEvent("onresize", ActualResize);
	window.attachEvent("onload", ActualResize);
}

if (window.addEventListener)
{
	window.addEventListener("resize", ActualResize, true);			
	window.addEventListener("load", ActualResize, true);		
}

function BeginPrint()
{
	var body=document.getElementById('PrintMailContent');
	var body2=document.getElementById('ReadMailContent');
	body.innerHTML = body2.innerHTML;
}

function EndPrint()
{
}

function ActualResize()
{
	var body = document.getElementById('ReadMailContent');
	var header = document.getElementById('ReadMailHeader');
	var intCompensate = header.offsetHeight;
	var documentObj = document.documentElement;
	if (window.opera || (document.all && !(document.compatMode && document.compatMode == "CSS1Compat")))
	{
		documentObj = document.body;
	}
	
	if (body && header)
	{
		var newHeight = (parseInt(documentObj.clientHeight) - intCompensate);
		if (newHeight>0)
		body.style.height = newHeight + "px";
		body.style.width = (parseInt(documentObj.clientWidth)) + "px";
	}
	
	if (!document.readyState)
	{
		document.readyState = "complete";
	}
}