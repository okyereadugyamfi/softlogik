using System.Diagnostics;
using System;
using System.Management;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Web.UI.Design;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.CodeDom;
using System.Drawing;


namespace ACSGhana.Web.Framework
{
	namespace UI
	{
		namespace Controls
		{
			
			
			
			/// <summary>
			/// Mimics the Macromedia flash movie "quality" parameter.
			/// </summary>
			public enum FlashMovieQuality
			{
				/// <summary>
				/// [Macromedia Default] Outputs "high" as the value of the quality parameter.
				/// </summary>
				High = 0,
				/// <summary>
				/// Outputs "best" as the value of the "quality" parameter.
				/// </summary>
				Best = 1,
				/// <summary>
				/// Outputs "autolow" as the value of the "quality" parameter.
				/// </summary>
				AutoLow = 2,
				/// <summary>
				/// Outputs "autohigh" as the value of the "quality" parameter.
				/// </summary>
				AutoHigh = 3,
				/// <summary>
				/// Outputs "medium" as the value of the "quality" parameter.
				/// </summary>
				Medium = 4,
				/// <summary>
				/// Outputs "low" as the value of the "quality" parameter.
				/// </summary>
				Low = 5
			}
			/// <summary>
			/// Mimics the Macromedia flash movie "scale" parameter.
			/// </summary>
			public enum FlashMovieScale
			{
				/// <summary>
				/// [Macromedia Default] Does not render the "scale" parameter.
				/// </summary>
				ShowAll = 0,
				/// <summary>
				/// Outputs "noscale" as the value of the "scale" parameter.
				/// </summary>
				NoScale = 1,
				/// <summary>
				/// Outputs "exactfit" as the value of the "scale" parameter.
				/// </summary>
				ExactFit = 2,
				/// <summary>
				/// Outputs "noborder" as the value of the "scale" parameter.
				/// </summary>
				NoBorder = 3
			}
			
			/// <summary>
			/// Mimics the Macromedia flash movie "wmode" parameter.
			/// </summary>
			public enum FlashMovieWindowMode
			{
				/// <summary>
				/// [Macromedia Default] Does not render the "wmode" parameter.
				/// </summary>
				Window = 0,
				/// <summary>
				/// Outputs "opaque" as the value of the "wmode" parameter.
				/// </summary>
				Opaque = 1,
				/// <summary>
				/// Outputs "transparent" as the value of the "wmode" parameter.
				/// </summary>
				Transparent = 2
			}
			/// <summary>
			/// Determins how your control will be rendered to the browser
			/// </summary>
			public enum FlashOutputType
			{
				/// <summary>
				/// Adds version detection script in html output.
				/// </summary>
				ClientScriptVersionDection = 0,
				/// <summary>
				/// Outputs special flash object tag for SWF version detection.
				/// </summary>
				SWFVersionDetection = 1,
				/// <summary>
				/// Ouputs only the html code nessesary to play embed your flash Movie.
				/// </summary>
				FlashOnly = 2,
				/// <summary>
				/// Not currently supported.
				/// </summary>
				FlashOnlyForPocketPC2002 = 3,
				/// <summary>
				/// Not currently supported.
				/// </summary>
				FlashWithAICCTracking = 4,
				/// <summary>
				/// Not currently supported.
				/// </summary>
				FlashWithSCORMTracking = 5,
				/// <summary>
				/// Not currently supported.
				/// </summary>
				FlashWithNamedAnchors = 6
			}
			
			/// <summary>
			/// Mimics the Macromedia flash movie "salign" parameter. Should be implemented in conjunction with FlashVerticalAlignment since
			///  both enumerations make up the full salign parameter for the flash movie.  When used with FlashVerticalAlignment possible values
			///  are (RT R RB T B LT L LB).  If both values are set to "Center" the parameter is not rendered to the browser.
			/// </summary>
			public enum FlashHorizontalAlignment
			{
				/// <summary>
				/// Outputs "L" as the first character in the "salign" parameter.
				/// </summary>
				Left = 0,
				/// <summary>
				/// [Macromedia Default] Does not render as part of the "salign" parameter value.
				/// </summary>
				Center = 1,
				/// <summary>
				/// Outputs "R" as the first character in the "salign" parameter.
				/// </summary>
				Right = 2
			}
			/// <summary>
			/// Mimics the Macromedia flash movie "salign" parameter.  Should be implemented in conjunction with FlashHorizontalAlignment since both
			///  enumerations make up the full salign parameter for the flash movie.  When used with FlashHorizontalAlignment possible values
			///  are (RT R RB T B LT L LB).  If both values are set to "Center" the parameter is not rendered to the browser.
			/// </summary>
			public enum FlashVerticalAlignment
			{
				/// <summary>
				/// Outputs "T" as the second character in the "salign" parameter.
				/// </summary>
				Top = 0,
				/// <summary>
				/// [Macromedia Default] Does not render as part of the "salign" parameter value.
				/// </summary>
				Center = 1,
				/// <summary>
				/// Outputs "B" as the second character in the "salign" parameter.
				/// </summary>
				Bottom = 2
			}
			/// <summary>
			/// Mimics the HTML "align" attribute for the Macromedia flash movie.
			/// </summary>
			public enum FlashHtmlAlignment
			{
				/// <summary>
				/// [Macromedia Default] Outputs empty quotes as the "Align" attribute value.
				/// </summary>
				None = 0,
				/// <summary>
				/// Outputs "top" as the "Align" attribute value.
				/// </summary>
				Top = 1,
				/// <summary>
				/// Outputs "bottom" as the "Align" attribute value.
				/// </summary>
				Bottom = 2,
				/// <summary>
				/// Outputs "left" as the "Align" attribute value.
				/// </summary>
				Left = 3,
				/// <summary>
				/// Outputs "right" as the "Align" attribute value.
				/// </summary>
				Right = 4
			}
			/// <summary>
			/// Mimics the allowScriptAccess attributer to the Macromedia flash movie.
			/// </summary>
			public enum FlashScriptAccessControl
			{
				/// <summary>
				/// Outputs sameDomain as the "allowScriptAccess" parameter.
				/// </summary>
				SameDomain = 0,
				/// <summary>
				/// Outputs never as the "allowScriptAccess" parameter.
				/// </summary>
				Never = 1,
				/// <summary>
				/// Outputs always as the "allowScriptAccess" parameter.
				/// </summary>
				Always = 2
			}
			
			/// <summary>
			/// It is suggested to use this class instead of using the FlashHorizontalAlignment and FlashVerticalAlignment Enumerations directly.
			/// This class is simply a wrapper to organize the flash alignment enumerations and to keep them togeather, which is how they should be implemented.
			/// </summary>
			public class FlashMovieAlignment
			{
				
				
				private FlashHorizontalAlignment _halign;
				private FlashVerticalAlignment _valign;
				
				/// <summary>
				/// Gets or Sets the FlashHorizontalAlignment enumeration.
				/// </summary>
				public FlashHorizontalAlignment HorizontalAlign
				{
					get
					{
						return this._halign;
					}
					set
					{
						this._halign = value;
					}
				}
				
				/// <summary>
				/// Gets or Sets the FlashVerticalAlignment enumeration.
				/// </summary>
				public FlashVerticalAlignment VerticalAlign
				{
					get
					{
						return this._valign;
					}
					set
					{
						this._valign = value;
					}
				}
				
				/// <summary>
				/// Initializes both enumerations to a default value of "Center".
				/// This is in correlation to the Macromedia Flash default publishing settings.
				/// </summary>
				public FlashMovieAlignment()
				{
					this.Initialize(FlashHorizontalAlignment.Center, FlashVerticalAlignment.Center);
				}
				/// <summary>
				/// Defaults the FlashVerticalAlignment enumeration to "Center" and allows you to initialize the class with a specific HorizontalAlign value.
				/// </summary>
				/// <param name="h">The value to initialize the HorizontalAlign property with.</param>
				public FlashMovieAlignment(FlashHorizontalAlignment h)
				{
					this.Initialize(h, FlashVerticalAlignment.Center);
				}
				/// <summary>
				/// Defaults the FlashHorizontalAlignment enumeration to "Center" and allows you to initialize the class with a specific VerticalAlign value.
				/// </summary>
				/// <param name="v">The value to initialize the VerticalAlign property with.</param>
				public FlashMovieAlignment(FlashVerticalAlignment v)
				{
					this.Initialize(FlashHorizontalAlignment.Center, v);
				}
				/// <summary>
				/// Allows you to initialize the class with a specific VerticalAlign and HorizontalAlign value.
				/// </summary>
				/// <param name="h">The value to initialize the HorizontalAlign property with.</param>
				/// <param name="v">The value to initialize the VerticalAlign property with.</param>
				public FlashMovieAlignment(FlashHorizontalAlignment h, FlashVerticalAlignment v)
				{
					this.Initialize(h, v);
				}
				/// <summary>
				/// Sets the private alignment fields during initialization.
				/// </summary>
				/// <param name="h">The value to initialize the HorizontalAlign property with.</param>
				/// <param name="v">The value to initialize the VerticalAlign property with.</param>
				protected void Initialize(FlashHorizontalAlignment h, FlashVerticalAlignment v)
				{
					this._halign = h;
					this._valign = v;
				}
				/// <summary>
				/// Outputs the standard flash alignment format value.
				/// </summary>
				/// <returns>A two character string used to set the flash salign parameter</returns>
				public override string ToString()
				{
					string s = "";
					
					switch (this.HorizontalAlign)
					{
						case FlashHorizontalAlignment.Center:
							s = "";
							break;
						case FlashHorizontalAlignment.Left:
							s = "L";
							break;
						case FlashHorizontalAlignment.Right:
							s = "R";
							break;
					}
					switch (this.VerticalAlign)
					{
						case FlashVerticalAlignment.Center:
							s += "";
							break;
						case FlashVerticalAlignment.Top:
							s += "T";
							break;
						case FlashVerticalAlignment.Bottom:
							s += "B";
							break;
					}
					
					return s;
				}
				
			}
		}
	}
}
