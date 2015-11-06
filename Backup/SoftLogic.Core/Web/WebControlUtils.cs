using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace Newtonsoft.Utilities.Web
{
	public static class WebControlUtils
	{
		public static void AddAttributesWithoutID<T>(T control, Action<T> action) where T : Control
		{
			string tempID = control.ID;
			control.ID = null;

			action(control);

			control.ID = tempID;
		}

		public static void AddAttributesWithoutID(Control control, Action<HtmlTextWriter> addAttributes, HtmlTextWriter writer)
		{
			string tempID = control.ID;
			control.ID = null;

			addAttributes(writer);

			control.ID = tempID;
		}
	}
}
