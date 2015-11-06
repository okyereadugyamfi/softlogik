//This javascript file allows for the draggable of an item on a web page.

document.onmousemove = MouseMove;
document.onmouseup   = MouseUp;

//The item that is being dragged.
var dragObject  = null;
//The mouse offset within the dragged item.
var mouseOffset = null;


/// <summary>
/// Return the current x and y coordinates of the mouse.
/// </summary>
/// <param name="e">
/// The current event object.
/// </param>
function MouseCoords(ev){
    if(ev.pageX || ev.pageY){
	    return {x:ev.pageX, y:ev.pageY};
    }
    return {
	    x:ev.clientX + document.body.scrollLeft - document.body.clientLeft,
	    y:ev.clientY + document.body.scrollTop  - document.body.clientTop
    };
}


/// <summary>
/// Get the x and y coordinates of the mouse position within the current item.
/// </summary>
/// <param name="target">
/// The item in which to get the offset.
/// </param>
/// <param name="ev">
/// The current event object.
/// </param>
function GetMouseOffset(target, ev){
    ev = ev || window.event;

    var docPos    = GetPosition(target);
    var mousePos  = MouseCoords(ev);
    return {x:mousePos.x - docPos.x, y:mousePos.y - docPos.y};
}


/// <summary>
/// Get the x and y position of the indicated form element.
/// </summary>
/// <param name="e">
/// The element whose position to get.
/// </param>
function GetPosition(e){
    var left = 0;
    var top  = 0;

    while (e.offsetParent){
	    left += e.offsetLeft;
	    top  += e.offsetTop;
	    e     = e.offsetParent;
    }

    left += e.offsetLeft;
    top  += e.offsetTop;

    return {x:left, y:top};
}


/// <summary>
/// This function is attached to the document mousemove event and handles the dragging of any draggable form 
/// element.
/// </summary>
/// <param name="ev">
/// The current event object.
/// </param>
function MouseMove(ev){
    ev           = ev || window.event;
    var mousePos = MouseCoords(ev);

    if(dragObject){
	    dragObject.style.position = 'absolute';
	    dragObject.style.top      = (mousePos.y - mouseOffset.y) + "px";
	    dragObject.style.left     = (mousePos.x - mouseOffset.x) + "px";

	    return false;
    }
}


/// <summary>
/// This function is attached to the document mouseup event and releases any item we may be dragging.
/// element.
/// </summary>
function MouseUp(){
    dragObject = null;
}


/// <summary>
/// Attach a function to the mousedown event of the indicated form element so that it may be dragged.
/// </summary>
/// <param name="item">
/// The form element which should be made draggable.
/// </param>
function MakeDraggable(item){
    if(!item) return;

    item.onmousedown = function(ev){
	    dragObject  = this;
	    mouseOffset = GetMouseOffset(this, ev);
	    return false;
    }
}


/// <summary>
/// Attach a function to the mousedown event of the indicated form element so that it may be dragged and treat
/// it as a handle for dragging another form element.
/// </summary>
/// <param name="handle">
/// The form element which should be treated as the handle on which the onmousedown event handle will be placed.
/// </param>
/// <param name="itemId">
/// The id of the form element which should be dragged.
/// </param>
function MakeDraggableHandle(handle, itemId){

    if((itemId == '') || !handle) return;

    //Attach the mousedown to the handle but indicate that the dragObject is the element with the indicated id.
    handle.onmousedown = function(ev){
        dragObject = document.getElementById(itemId);
	    mouseOffset = GetMouseOffset(dragObject, ev);
	    return false;
    }
}
