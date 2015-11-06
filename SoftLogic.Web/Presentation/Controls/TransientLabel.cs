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
    public enum ResourceLocations : int
    { 
        PageLevel,
        GlobalLevel
    }
    [ToolboxData("<{0}:TransientLabel runat=server></{0}:TransientLabel>")]
    public class TransientLabel : Label
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ResourceID
        {
            get
            {
                String s = (String)ViewState["ResourceID"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["ResourceID"] = value;
            }
        }
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public ResourceLocations Location
        {
            get
            {
                ResourceLocations l = (ResourceLocations)ViewState["Location"];
                return l;
            }

            set
            {
                ViewState["ResourceID"] = value;
            }
        }
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(ResourceID);
        }
    }
}
