using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftLogic.Web.Presentation.Controls
{
    [ToolboxData("<{0}:LoggedInAs runat=server></{0}:LoggedInAs>")]
    public class LoggedInAs : WebControl
    {
        
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.RenderBeginTag ("div");
            output.WriteStyleAttribute("height", Height.ToString());
            output.WriteStyleAttribute("height", Width.ToString());
            output.RenderEndTag();
        }
    }
}
