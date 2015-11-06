// (c) Copyright Omar AL Zabir.
// All other rights reserved.

Type.registerNamespace('CustomDragDrop');

CustomDragDrop.CustomFloatingBehavior = function(element) {
    CustomDragDrop.CustomFloatingBehavior.initializeBase(this,[element]);
    
    var _handle;
    var _location;
    var _dragStartLocation;
    var _DragHandleIDValue;
    
    var _mouseDownHandler = Function.createDelegate(this, mouseDownHandler);
    
    this.get_DragHandleID = function()
    {
        return this._DragHandleIDValue;
    }
    
    this.set_DragHandleID = function(value)
    {
        this._DragHandleIDValue = value;
    }
    
    this.add_move = function(handler) {
        this.get_events().addHandler('move', handler);
    }
    
    this.remove_move = function(handler) {
        this.get_events().removeHandler('move', handler);
    }
    
    this.get_handle = function() {
        return _handle;
    }
    this.set_handle = function(value) {
        if (_handle != null) {
            $removeHandler(_handle, "mousedown", _mouseDownHandler);                        
        }
    
        _handle = value;
        $addHandler(_handle, "mousedown", _mouseDownHandler);                
    }
    
    this.get_location = function() {
        return _location;
    }
    this.set_location = function(value) {
        if (_location != value) {
            _location = value;
            if (this.get_isInitialized()) {                
                
                Sys.UI.DomElement.setLocation(this.get_element(), _location.x, _location.y);
            }
            this.raisePropertyChanged('location');
        }
    }
    
    this.initialize = function() {
        CustomDragDrop.CustomFloatingBehavior.callBaseMethod(this, 'initialize');

        // Set the handle and initialize dragging
        this.set_handle( $get( this.get_DragHandleID() ) );
    }
    
    this.dispose = function() {
        if (_handle && _mouseDownHandler) {
            $removeHandler(_handle, "mousedown", _mouseDownHandler);
        }
        _mouseDownHandler = null;
        CustomDragDrop.CustomFloatingBehavior.callBaseMethod(this, 'dispose');
    }
    
    this.checkCanDrag = function(element) {
        var undraggableTagNames = ["input", "button", "select", "textarea", "label"];
        var tagName = element.tagName;
        
        if ((tagName.toLowerCase() == "a") && (element.href != null) && (element.href.length > 0)) {
            return false;
        }
        if (Array.indexOf(undraggableTagNames, tagName.toLowerCase()) > -1) {
            return false;
        }
        return true;
    }

    
    function mouseDownHandler(ev) {
        window._event = ev;
        var el = this.get_element();
        
        if (!this.checkCanDrag(ev.target)) return;
        
        // Get the location before making the element absolute
        _location = Sys.UI.DomElement.getLocation(el);

        // Make the element absolute 
        el.style.width = el.offsetWidth + "px";
        el.style.height = el.offsetHeight + "px";            
        Sys.UI.DomElement.setLocation(el, _location.x, _location.y);               
        
        _dragStartLocation = Sys.UI.DomElement.getLocation(el);        
        
        ev.preventDefault();
        
        this.startDragDrop(el);
        
        // Hack for restoring position to static
        el.originalPosition = "static";
        el.originalZIndex = el.style.zIndex;
        el.style.zIndex = "60000";
    }
    
    // Type get_dataType()
    this.get_dragDataType = function() {
        return "_CustomFloatingItem";
    }
    
    // Object get_data(Context)
    this.getDragData = function(context) {
        return { item : this.get_element(), handle : this.get_handle() } ;
    }
    
    // DragMode get_dragMode()
    this.get_dragMode = function() {
        return AjaxControlToolkit.DragMode.Move;
    }
    
    // void onDragStart()
    this.onDragStart = function() { }
    
    // void onDrag()
    this.onDrag = function() { }
    
    // void onDragEnd(Canceled)
    this.onDragEnd = function(canceled) {
        if (!canceled) {
            var handler = this.get_events().getHandler('move');
            if(handler) {
                var cancelArgs = new Sys.CancelEventArgs();
                handler(this, cancelArgs);
                canceled = cancelArgs.get_cancel();
            }            
        }
        
        var el = this.get_element();
        el.style.width = el.style.height = el.style.left = el.style.top = "";
        el.style.zIndex = el.originalZIndex;
        
        if (canceled) {
            // Restore the position of the control.
            //Sys.UI.DomElement.setLocation(el, _dragStartLocation.x, _dragStartLocation.y);            
        }
        else {
            var location = Sys.UI.DomElement.getLocation(el);
            _location = location.x + ',' + location.y;
            this.raisePropertyChanged('location');
        }
    }
    
    this.startDragDrop = function(dragVisual) {
        AjaxControlToolkit.DragDropManager.startDragDrop(this, dragVisual, null);
    }
    
    this.get_dropTargetElement = function() {
        return document.body;
    }
    
    // bool canDrop(DragMode, DataType, Data)
    this.canDrop = function(dragMode, dataType, data) {
        return (dataType == "_CustomFloatingItem");
    }

}
//CustomDragDrop.CustomFloatingBehavior.descriptor = {
//    properties: [   {name: "profileProperty", type: String},
//                    {name: "profileComponent", type: Object},
//                    {name: "dragData", type: Object, readOnly: true},
//                    {name: "dragDataType", type: String, readOnly: true},
//                    {name: "dragMode", type: AjaxControlToolkit.DragMode, readOnly: true},
//                    {name: "dropTargetElement", type: Object, readOnly: true},
//                    {name: "handle", type: Sys.UI.DomElement},
//                    {name: "location", type: String} ],
//    events: [   {name: "move"} ]
//}
CustomDragDrop.CustomFloatingBehavior.registerClass('CustomDragDrop.CustomFloatingBehavior', AjaxControlToolkit.BehaviorBase, AjaxControlToolkit.IDragSource, /* AjaxControlToolkit.IDropTarget, */ Sys.IDisposable);

