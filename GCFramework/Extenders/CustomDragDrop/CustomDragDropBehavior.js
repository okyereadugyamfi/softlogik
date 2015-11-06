// (c) Copyright Omar AL Zabir.
// All other rights reserved.

Type.registerNamespace('CustomDragDrop');

CustomDragDrop.CustomDragDropBehavior = function(element) {

    CustomDragDrop.CustomDragDropBehavior.initializeBase(this, [element]);
    
    this._DragItemClassValue = null;    
    this._DragItemHandleClassValue = null;
    this._DropCueIDValue = null;
    this._dropCallbackFunctionValue = null;
    
    this._dropCue = null;
    
    this._dropCallbackFunction = null;
    
    this._floatingBehaviors = [];
}

CustomDragDrop.CustomDragDropBehavior.prototype = {
    
    initialize : function() {
        CustomDragDrop.CustomDragDropBehavior.callBaseMethod(this, 'initialize');
        // Register ourselves as a drop target.
        AjaxControlToolkit.DragDropManager.registerDropTarget(this); 
        
        //this._initializeDraggableItems();
        
        this._dropCue = $get(this.get_DropCueID());
    },
    
    dispose : function() {
        AjaxControlToolkit.DragDropManager.unregisterDropTarget(this);
        
        //this._clearFloatingBehaviors();
        
        CustomDragDrop.CustomDragDropBehavior.callBaseMethod(this, 'dispose');
    },
    
    _clearFloatingBehaviors : function()
    {
        while( this._floatingBehaviors.length > 0 )
        {
            var behavior = this._floatingBehaviors.pop();            
            behavior.dispose();
        }
    },
    
    _findChildByClass : function(item, className)
    {
        // First check all immediate child items
        var child = item.firstChild;
        while( child != null )
        {
            if( child.className == className ) return child;
            child = child.nextSibling;
        }
        
        // Not found, recursively check all child items
        child = item.firstChild;
        while( child != null )
        {
            var found = this._findChildByClass( child, className );
            if( found != null ) return found;
            child = child.nextSibling;
        }
    },
    
    // Find all items with the drag item class and make each item
    // draggable        
    /*_initializeDraggableItems : function() 
    {
        this._clearFloatingBehaviors();
        
        var el = this.get_element();
        
        var child = el.firstChild;
        while( child != null )
        {
            if( child.className == this._DragItemClassValue && child != this._dropCue)
            {
                var handle = this._findChildByClass(child, this._DragItemHandleClassValue);
                if( handle )
                {
                    // make the item draggable by adding floating behaviour to it
                    var floatingBehavior = $create( CustomDragDrop.CustomFloatingBehavior, {'name':'CustomFloatingBehavior'}, {}, {}, child );
                    floatingBehavior.set_handle(handle);
                    
                    Array.add( this._floatingBehaviors, floatingBehavior );
                }
            }            
            child = child.nextSibling;
        }
    },*/
    
    get_DropCallbackFunction : function()
    {
        return this._dropCallbackFunctionValue;
    },
    
    set_DropCallbackFunction : function(value)
    {
        this._dropCallbackFunctionValue = value;
        this._dropCallbackFunction = eval(value);
    },
    
    get_DragItemClass : function()
    {
        return this._DragItemClassValue;
    },
    
    set_DragItemClass : function(value)
    {
        this._DragItemClassValue = value;
    },
    
    get_DropCueID : function()
    {
        return this._DropCueIDValue;
    },
    
    set_DropCueID : function(value)
    {
        this._DropCueIDValue = value;
    },
    
    get_DragItemHandleClass : function()
    {
        return this._DragItemHandleClassValue;
    },
    
    set_DragItemHandleClass : function(value)
    {
        this._DragItemHandleClassValue = value;
    },
    
    getDescriptor : function() {
        var td = CustomDragDrop.CustomDragDropBehavior.callBaseMethod(this, 'getDescriptor');
        return td;
    },

    // IDropTarget members.
    get_dropTargetElement : function() {
        return this.get_element();
    },
    
    drop : function(dragMode, type, data) { 
        this._hideDropCue(data);
        this._placeItem(data);
    },
    
    canDrop : function(dragMode, dataType) {
        return true;
    },
    
    onDragEnterTarget : function(dragMode, type, data) {
        //DEBUG debug.trace("onDragEnterTarget");
        this._showDropCue(data);    
    },
    
    onDragLeaveTarget : function(dragMode, type, data) {
        this._hideDropCue(data);
    },
    
    onDragInTarget : function(dragMode, type, data) {
        //DEBUG debug.trace("onDragInTarget");
        this._repositionDropCue(data);
    },
    
    _findItemAt : function(x,y, item)
    {
        var el = this.get_element();
        
        var child = el.firstChild;
        while( child != null )
        {
            if( child.className == this._DragItemClassValue && child != this._dropCue && child != item )
            {
                var pos = Sys.UI.DomElement.getLocation(child);
                
                if( y <= pos.y )
                {
                    //DEBUG debug.trace( y + ' <= ' + pos.y );
                    return child;
                }
            }
            child = child.nextSibling;
        }
        
        return null;
    },
    
    _showDropCue : function(data)
    {        
        this._repositionDropCue(data);
        
        this._dropCue.style.display = "block";
        this._dropCue.style.visibility = "visible";
        
        var bounds = Sys.UI.DomElement.getBounds(data.item);
        
        if( this._dropCue.style.height == "" )
            this._dropCue.style.height = bounds.height.toString() + "px"; // TODO: Make it same as the drag item
        
    },
    
    _hideDropCue : function(data)
    {
        this._dropCue.style.display = "none";
        this._dropCue.style.visibility = "hidden";        
    },
    
    _repositionDropCue : function(data)
    {
        var location = Sys.UI.DomElement.getLocation(data.item);
        //DEBUG debug.trace('x:' + location.x + ' y:' + location.y);
        var nearestChild = this._findItemAt(location.x, location.y, data.item);
        
        var el = this.get_element();        
            
        if( null == nearestChild )
        {
            if( el.lastChild != this._dropCue )
            {
                el.removeChild(this._dropCue);
                el.appendChild(this._dropCue);
            }
        }
        else
        {
            if( nearestChild.previousSibling != this._dropCue )
            {
                el.removeChild(this._dropCue);
                el.insertBefore(this._dropCue, nearestChild);            
            }            
        }
    },
    
    _placeItem : function(data)
    {
        var el = this.get_element();
                
        data.item.parentNode.removeChild( data.item );
        el.insertBefore( data.item, this._dropCue );
        
        // Find the position of the dropped item
        var position = 0;
        var item = el.firstChild;
        while( item != data.item )
        {  
            if( item.className == this._DragItemClassValue ) position++; 
            item = item.nextSibling; 
        }
        this._raiseDropEvent( /* Container */ el, /* droped item */ data.item, /* position */ position );
    },
    
    _raiseDropEvent : function( container, droppedItem, position )
    {
        if( typeof this._dropCallbackFunction == "function" )
            this._dropCallbackFunction( container, droppedItem, position );
    }
}

CustomDragDrop.CustomDragDropBehavior.registerClass('CustomDragDrop.CustomDragDropBehavior', 
AjaxControlToolkit.BehaviorBase, 
AjaxControlToolkit.IDragSource, 
AjaxControlToolkit.IDropTarget, 
Sys.IDisposable);


