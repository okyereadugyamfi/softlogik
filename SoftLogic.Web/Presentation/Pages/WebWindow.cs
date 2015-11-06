using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace SoftLogic.Web.Presentation
{
    class WebWindow : WebPage 
    {
        public string WindowID
        {
            get
            {
                object _WindowID = ViewState["WindowID"];
                if (_WindowID != null)
                {
                    return System.Convert.ToString(_WindowID);
                }
                else
                {
                    _WindowID = this.Request.QueryString["winid"];
                    ViewState["WindowID"] = _WindowID;
                    return (string)_WindowID;
                }
            }
            set
            {
                ViewState["WindowID"] = value;
            }
        }
        public string ParentWindowID
        {
            get
            {
                object _WindowID = ViewState["ParentWindowID"];
                if (_WindowID != null)
                {
                    return System.Convert.ToString(_WindowID);
                }
                else
                {
                    _WindowID = this.Request.QueryString["pwinid"];
                    ViewState["ParentWindowID"] = _WindowID;
                    return (string)_WindowID;
                }
            }
            set
            {
                ViewState["ParentWindowID"] = value;
            }
        }

        public void Close()
        { 

        }

        public void Refresh()
        {
 
        }

        
    }
}
