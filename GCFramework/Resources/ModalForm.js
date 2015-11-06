/// <summary>
/// Close a modal form when the close window icon in the upper right is pressed.
/// </summary>
/// <param name="closeCommandId">
/// This is the id of the control that should be clicked to close the modal form.
/// </param>
function ModalFormClose(closeCommandId)
{
    var closeCommand = document.getElementById(closeCommandId);
    
    if (closeCommand != null)
    {
        //IE and Mozilla must be handled differently.
        if (closeCommand.click)
        {
            //IE simply supports a click method which we can call on the closeCommand.
            closeCommand.click();
        }
        else
        {
            var evt = closeCommand.ownerDocument.createEvent("MouseEvents");
            evt.initMouseEvent('click', true, true, closeCommand.ownerDocument.defaultView, 1, 0, 0, 0, 0, false, false, false, false, 0, null);
            closeCommand.dispatchEvent(evt);         
        }
    }
}
