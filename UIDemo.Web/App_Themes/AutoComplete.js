function AutoComplete(theTextBox, theDivBox, theFunction)
{
	this.theTextBox = theTextBox;
	this.theDivBox = theDivBox;
	this.theFunction = theFunction;
	
	theTextBox.AutoComplete = this;
	theTextBox.onkeypress = AutoComplete.prototype.onKeyPress;
	theTextBox.onkeyup = AutoComplete.prototype.onTextChange;
	theTextBox.onblur = AutoComplete.prototype.onTextBlur;
}

AutoComplete.prototype.onTextBlur = function()
{
	this.AutoComplete.onblur();
}

AutoComplete.prototype.onblur = function()
{
	var d = this.theDivBox;
	
	while ( d.hasChildNodes() )
		d.removeChild(d.firstChild);
	d.innerHTML = "";
	d.style.visibility = "hidden";
}

AutoComplete.prototype.onTextChange = function(e)
{
	if (e==null)
		e=event;
		
	if ((e.keyCode && e.keyCode==13)||
		(e.which && e.which==13))
	{
		var d = this.AutoComplete.theDivBox;
		if (d==null || d.firstChild==null)
			return;
		this.AutoComplete.theTextBox.value = d.firstChild.innerHTML;
		
		while ( d.hasChildNodes() )
			d.removeChild(d.firstChild);
		d.innerHTML = "";
		d.style.visibility = "hidden";
		return;
	}
	
	this.AutoComplete.onchange();
}

AutoComplete.prototype.onKeyPress = function(e)
{
	if (e==null)
		e=event;
		
	if ((e.keyCode && e.keyCode==13)||
		(e.which && e.which==13))
	{
		return false;
	}
}

AutoComplete.prototype.onDivMouseDown = function()
{
	this.AutoComplete.theTextBox.value = this.innerHTML;
}

AutoComplete.prototype.onDivMouseOver = function()
{
	this.className = "AutoCompleteHighlight";
}

AutoComplete.prototype.onDivMouseOut = function()
{
	this.className = "AutoCompleteNormal";
}

AutoComplete.prototype.onchange = function()
{
	var txt = this.theTextBox.value;
	this.theFunction(txt,AutoComplete.prototype.onAjaxComplete,this);
}

AutoComplete.prototype.onAjaxComplete = function(aStr,theClass)
{
	if (aStr.length>0 && aStr[0]!="")
	{
		while ( theClass.theDivBox.hasChildNodes() )
			theClass.theDivBox.removeChild(theClass.theDivBox.firstChild);
			
		var i, n = aStr.length;
	
		for ( i = 0; i < n; i++ )
		{
			var oDiv = document.createElement('div');
			theClass.theDivBox.appendChild(oDiv);
			oDiv.innerHTML = aStr[i];
			oDiv.className = "AutoCompleteNormal";
			oDiv.onmousedown = theClass.theTextBox.AutoComplete.onDivMouseDown;
			oDiv.onmouseover = theClass.theTextBox.AutoComplete.onDivMouseOver;
			oDiv.onmouseout = theClass.theTextBox.AutoComplete.onDivMouseOut;
			oDiv.AutoComplete = theClass;			
		}
		theClass.theDivBox.style.visibility = "visible";
	}
	else
	{
		theClass.theDivBox.innerHTML = "";
		theClass.theDivBox.style.visibility = "hidden";
	}
}
