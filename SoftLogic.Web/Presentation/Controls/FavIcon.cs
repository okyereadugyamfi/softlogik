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
    [ToolboxData("<{0}:FavIcon runat=server></{0}:FavIcon>")]
    public class FavIcon : WebControl 
    {
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.RenderBeginTag("link");
            output.Write(" rel=\"icon\" href=\"/favicon.ico\" type=\"image/ico\" ");
            output.RenderEndTag();
        } 
    }
}
