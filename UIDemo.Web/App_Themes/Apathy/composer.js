var resizeMe2 = function(e)
{
	window.setTimeout("resizeMe()", 10);
}

var resizeMe = function()
{
	if (!e)
		var e = window.event;
		
	var documentObj = document.documentElement;
	if (window.opera || (document.all && !(document.compatMode && document.compatMode == "CSS1Compat")))
		documentObj = document.body;

	var table = document.getElementById(ctable);
	if (table==null)
		return;

	var scroll = document.getElementById('Scrollable');
	var size = parseInt(documentObj.clientHeight) - GetScrollableSize(documentObj) - table.clientHeight - 100;
	if (size < 300)
		size = 300;
	var sizew = documentObj.clientWidth - 255;

	if (self.GetRadEditor)
	{
		var editor = GetRadEditor(eeditor);
		if (editor)
			editor.SetSize("100%", size);
		document.getElementById(ctable2).style.width = (sizew) + "px";
	}
	else
	{
		document.getElementById(ptb).style.width = (sizew - 10) + "px";
		document.getElementById(ptb).style.height = (size) + "px";
	}
		
	var comboSize = sizew - 84;
	
	document.getElementById(etxtTo).style.width = comboSize + "px";
	document.getElementById(phTo).style.width = (comboSize+16) + "px";
	document.getElementById(phTo+"Placeholder").style.width = (comboSize+16) + "px";
	
	document.getElementById(etxtCC).style.width = comboSize + "px";
	document.getElementById(phCC).style.width = (comboSize+16) + "px";
	document.getElementById(phCC+"Placeholder").style.width = (comboSize+16) + "px";
	
	document.getElementById(etxtBcc).style.width = comboSize + "px";
	document.getElementById(phBcc).style.width = (comboSize+16) + "px";
	document.getElementById(phBcc+"Placeholder").style.width = (comboSize+16) + "px";
	
	document.getElementById(etxtSub).style.width = (comboSize+17) + "px";

}

if (window.attachEvent)
{
	window.attachEvent("onresize", resizeMe2);
	window.attachEvent("onload", resizeMe2);
}

if (window.addEventListener)
{
	window.addEventListener("resize", resizeMe2, true);			
	window.addEventListener("load", resizeMe2, true);		
}