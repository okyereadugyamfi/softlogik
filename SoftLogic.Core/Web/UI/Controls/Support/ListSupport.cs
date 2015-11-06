using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace SoftLogik.Web.UI.Controls.Support
{
    public sealed class ListSupport
    {
        public void SelectItem(ref ListControl WebCtl, object Value)
        {
            try
            {

                if (WebCtl != null)
                {
                    ListItem lItem = WebCtl.Items.FindByValue(System.Convert.ToString(Value));

                    if (lItem != null)
                    {
                        WebCtl.SelectedIndex = WebCtl.Items.IndexOf(lItem);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void SelectItemByText(ref ListControl WebCtl, string Value)
        {
            try
            {

                if (WebCtl != null)
                {
                    ListItem lItem = WebCtl.Items.FindByText(System.Convert.ToString(Value));

                    if (lItem != null)
                    {
                        WebCtl.SelectedIndex = WebCtl.Items.IndexOf(lItem);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
