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
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:PageTitle runat=server></{0}:PageTitle>")]
    public class PageTitle : Literal 
    {
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            base.RenderControl(writer);
        }
    }
}
