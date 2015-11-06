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
    [ToolboxData("<{0}:Spacer runat=server></{0}:Spacer>")]
    public class Spacer : Label
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("1")]
        [Localizable(true)]
        public int Width
        {
            get
            {
                return (int)ViewState["Width"];
            }

            set
            {
                ViewState["Width"] = value;
            }
        }
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("1")]
        [Localizable(true)]
        public int Height
        {
            get
            {
                return (int)ViewState["Height"];
            }

            set
            {
                ViewState["Height"] = value;
            }
        }
        
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.RenderBeginTag("img");
            output.WriteAttribute("src", Page.ClientScript.GetWebResourceUrl(GetType(), "SoftLogic.Web.Presentation.Controls.Resources.1pix.gif"));
            output.WriteStyleAttribute("height", Height.ToString());
            output.WriteStyleAttribute("height", Width.ToString());
            output.RenderEndTag();
        }
    }
}
