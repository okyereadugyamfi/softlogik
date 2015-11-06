if (window.attachEvent)
{
	window.attachEvent("onresize", ActualUserResize);
	window.attachEvent("onload", ActualUserResize);
}

if (window.addEventListener)
{
	window.addEventListener("resize", ActualUserResize, true);			
	window.addEventListener("load", ActualUserResize, true);		
}
function ActualUserResize()
{
	if (self.ActualSplitResize)
		ActualSplitResize();
		
	var LIA = document.getElementById('LoggedInAs');
	var LB = document.getElementById('LeftBar');
	var Container = document.getElementById('Container');
	var form = document.getElementById('aspnetForm');
	var CB = document.getElementById('MenuBar');
	var IC = document.getElementById('InnerContent');
	var SC = document.getElementById('Scrollable');
	
	var documentObj = document.documentElement;
	if (window.opera || (document.all && !(document.compatMode && document.compatMode == "CSS1Compat"))) documentObj = document.body;
	
	var pageSize = parseInt(documentObj.clientHeight);
	var adjustment = CB.offsetHeight + 12;
	var size = pageSize - adjustment;

	var LBsize = size - LIA.clientHeight;
	var scrollSize = 0;
	if (SC)
		scrollSize = size - GetScrollableSize(documentObj);
	
	
	if (LB && LBsize>0) 
		LB.style.height = LBsize + "px";
		
	if (IC && size>0) 
		IC.style.height = size + "px";
		
	if (SC && scrollSize>0) 
		SC.style.height = scrollSize + "px";
		
	if (Container && size>0) 
		Container.style.height = size + "px";
		
	if (form) 
		form.style.height = pageSize + "px";


	if (self.ExpandItem)
		ExpandItem();
		
	if (!document.readyState) document.readyState = "complete";
}


