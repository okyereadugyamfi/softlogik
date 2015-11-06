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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections.Specialized;


[assembly:TagPrefix("ACSGhana.Web.Framework.UI.Controls", "portal")]
namespace ACSGhana.Web.Framework
{
	namespace UI
	{
		namespace Controls
		{
			
			[ToolboxData("<{0}:FlashMovie runat=server></{0}:FlashMovie>"), Description("Flash Movie Control."), DefaultProperty("MovieName")]public class FlashMovie : System.Web.UI.Control, INamingContainer
			{
				
				
				#region Control Constructor and Initilization
				
				/// <summary>
				/// Flash Movie Control.
				/// </summary>
				public FlashMovie()
				{
					//Initialize default values for prperties
					this.InitializeControl();
					//Make sure all child controls have been created
					this.EnsureChildControls();
				}
				
				/// <summary>
				/// Initializes the default values for members.
				/// </summary>
				protected void InitializeControl()
				{
					
					this._fsCommandScriptUrl = string.Empty;
					this._mname = string.Empty;
					this._mautoplay = true;
					this._mquality = FlashMovieQuality.High;
					this._mautoloop = true;
					this._mwmode = FlashMovieWindowMode.Window;
					this._mscale = FlashMovieScale.ShowAll;
					this._mflashAlign = new FlashMovieAlignment(FlashHorizontalAlignment.Center, FlashVerticalAlignment.Center);
					this._mhtmlalign = FlashHtmlAlignment.None;
					this._moutputtype = FlashOutputType.FlashOnly;
					this._mmenu = true;
					this._mdevicefont = false;
					this._mbgcolor = System.Drawing.Color.White;
					this._mwidth = "550";
					this._mheight = "400";
					this._mLiveConnect = false;
					this._mvariables = new System.Collections.Specialized.NameValueCollection();
					this.PostRenderNoScriptContent = string.Empty;
					this.PostRenderNoFlashContent = string.Empty;
					this._mnoflash = new System.Web.UI.WebControls.PlaceHolder();
					this._mnoscript = new System.Web.UI.WebControls.PlaceHolder();
					this._mmajorversion = 7;
					this._mmajorrevision = 0;
					this._mminorversion = 0;
					this._mminorrevision = 0;
					this._mscriptaccesscontrol = FlashScriptAccessControl.SameDomain;
					this._mdetectionalturl = string.Empty;
					this._mdetectioncontenturl = string.Empty;
					this._mallowflashautoinstall = false;
				}
				
				/// <summary>
				/// Creates the PlaceHolders responsible for containing the controls used in the noscript and noflash rendering methods.
				/// </summary>
				protected override void CreateChildControls()
				{
					
					//Create the PlaceHolder that will contain the controls to be rendered
					//as the noscript content in case javascript is not enabled and plugin
					//detection is on.
					this._mnoscript = new System.Web.UI.WebControls.PlaceHolder();
					this._mnoscript.ID = FlashMovie.NOSCRIPT_CONTAINERID;
					this.Controls.Add(this._mnoscript);
					
					//Create the PlaceHolder that will contain the controls to be rendered
					//as the content if the flash plugin was not found or disabled in the
					//client browser.  These controls reside in a javascript else{} block
					//and are wrapped around a document.write(''); JS Statement.
					this._mnoflash = new System.Web.UI.WebControls.PlaceHolder();
					this._mnoflash.ID = FlashMovie.NOFLASH_CONTAINERID;
					this.Controls.Add(this._mnoflash);
					
					
					base.CreateChildControls();
				}
				#endregion
				#region  Control Attributes
				/// <summary>
				///
				/// </summary>
				private int _mmajorversion;
				/// <summary>
				///
				/// </summary>
				private int _mmajorrevision;
				/// <summary>
				///
				/// </summary>
				private int _mminorversion;
				/// <summary>
				///
				/// </summary>
				private int _mminorrevision;
				/// <summary>
				///
				/// </summary>
				private string _fsCommandScriptUrl;
				/// <summary>
				///
				/// </summary>
				private FlashScriptAccessControl _mscriptaccesscontrol;
				/// <summary>
				///
				/// </summary>
				private string _mdetectionalturl;
				/// <summary>
				///
				/// </summary>
				private string _mdetectioncontenturl;
				/// <summary>
				///
				/// </summary>
				private bool _mallowflashautoinstall;
				/// <summary>
				///
				/// </summary>
				private string _mname;
				/// <summary>
				///
				/// </summary>
				private bool _mautoplay;
				/// <summary>
				///
				/// </summary>
				private FlashMovieQuality _mquality;
				/// <summary>
				///
				/// </summary>
				private bool _mautoloop;
				/// <summary>
				///
				/// </summary>
				private FlashMovieWindowMode _mwmode;
				/// <summary>
				///
				/// </summary>
				private FlashMovieScale _mscale;
				/// <summary>
				///
				/// </summary>
				private FlashMovieAlignment _mflashAlign;
				/// <summary>
				///
				/// </summary>
				private FlashHtmlAlignment _mhtmlalign;
				/// <summary>
				///
				/// </summary>
				private FlashOutputType _moutputtype;
				/// <summary>
				///
				/// </summary>
				private bool _mmenu;
				/// <summary>
				///
				/// </summary>
				private bool _mdevicefont;
				/// <summary>
				///
				/// </summary>
				private System.Drawing.Color _mbgcolor;
				/// <summary>
				///
				/// </summary>
				private string _mwidth;
				/// <summary>
				///
				/// </summary>
				private string _mheight;
				/// <summary>
				///
				/// </summary>
				private bool _mLiveConnect;
				/// <summary>
				///
				/// </summary>
				private System.Collections.Specialized.NameValueCollection _mvariables;
				/// <summary>
				///
				/// </summary>
				private System.Web.UI.WebControls.PlaceHolder _mnoscript;
				/// <summary>
				///
				/// </summary>
				private System.Web.UI.WebControls.PlaceHolder _mnoflash;
				/// <summary>
				/// The raw HTML content that has been captured after the NoScriptContainer has rendered
				/// </summary>
				protected string PostRenderNoScriptContent;
				/// <summary>
				/// The raw HTML content that has been captured after the NoFlashContainer has rendered
				/// </summary>
				protected string PostRenderNoFlashContent;
				#endregion
				
				#region Control Constants
				private const string MIME_TYPE = "application/x-shockwave-flash";
				private const string PLUGINS_PAGE = "http://www.macromedia.com/go/getflashplayer";
				private const string PLUGINS_PAGE_SSL = "https://www.macromedia.com/go/getflashplayer";
				private const string DETECTION_PLUGINS_PAGE = "http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash";
				private const string DETECTION_PLUGINS_PAGE_SSL = "https://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash";
				private const string SCRIPT_VERSION = "javascript1.1";
				private const string CLASS_ID = "clsid:d27cdb6e-ae6d-11cf-96b8-444553540000";
				private const string CODE_BASE_URL = "http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab";
				private const string CODE_BASE_URL_SSL = "https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab";
				private const string NOSCRIPT_CONTAINERID = "NoScriptContainer";
				private const string NOFLASH_CONTAINERID = "NoFlashContainer";
				#endregion
				
				#region Control Properties
				
				/// <summary>
				/// Gets or sets the major version of the flash plugin to use.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(7), Description("Determines which flash plugin is needed to play the movie.  The first of four numbers that make up the plugin\'s codebase."), Category("Plugin Version")]public int MajorPluginVersion
				{
					get
					{
						return this._mmajorversion;
					}
					set
					{
						this._mmajorversion = value;
					}
				}
				
				/// <summary>
				/// Gets or sets the major version revision of the flash plugin to use.  The second of four numbers that make up the plugin's codebase.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(0), Description("Determines which flash plugin is needed to play the movie.  The second of four numbers that make up the plugin\'s codebase."), Category("Plugin Version")]public int MajorPluginVersionRevision
				{
					get
					{
						return this._mmajorrevision;
					}
					set
					{
						this._mmajorrevision = value;
					}
				}
				/// <summary>
				/// Gets or sets the minor version of the flash plugin to use.  The third of four numbers that make up the plugin's codebase.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(0), Description("Determines which flash plugin is needed to play the movie."), Category("Plugin Version")]public int MinorPluginVersion
				{
					get
					{
						return this._mminorversion;
					}
					set
					{
						this._mminorversion = value;
					}
				}
				/// <summary>
				/// Gets or sets the minor version revision of the flash plugin to use.  The fourth of four numbers that make up the plugin's codebase.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(0), Description("Determines which flash plugin is needed to play the movie. The fourth of four numbers that make up the plugin\'s codebase."), Category("Plugin Version")]public int MinorPluginVersionRevision
				{
					get
					{
						return this._mminorrevision;
					}
					set
					{
						this._mminorrevision = value;
					}
				}
				/// <summary>
				/// Gets or sets the flash movie parameter responsible for allowing script access to the movie.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(typeof(FlashScriptAccessControl), "SameDomain"), Description("Determines the allowed script access to the movie"), Category("Movie Control")]public FlashScriptAccessControl ScriptAccessControl
				{
					get
					{
						return this._mscriptaccesscontrol;
					}
					set
					{
						this._mscriptaccesscontrol = value;
					}
				}
				
				/// <summary>
				/// Gets or Sets the url of a JavaScript .js file to include in the webpage.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(""), Description("Gets or Sets the url of a JavaScript .js file to include in the webpage."), Category("Movie Control"), Editor("System.Web.UI.Design.UrlEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))]public string FSCommandScriptUrl
				{
					get
					{
						return this._fsCommandScriptUrl;
					}
					set
					{
						this._fsCommandScriptUrl = value;
					}
				}
				/// <summary>
				/// Gets or sets the alternate webpage to redirect to if SWF detection does not detect the flash plugin.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(""), Description("Determines the alternate web page to redirect to if SWF detection does not detect the flash plugin."), Category("SWF Detection"), Editor("System.Web.UI.Design.UrlEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))]public string SWF_DetectionAltUrl
				{
					get
					{
						if (this.FlashOutputType == FlashOutputType.SWFVersionDetection)
						{
							return this._mdetectionalturl;
						}
						else
						{
							return "";
						}
					}
					set
					{
						this._mdetectionalturl = value;
					}
				}
				/// <summary>
				/// Gets or sets the content webpage to redirect to if SWF detection detects that the flash plugin is installed.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(""), Description("Determines the content web page to redirect to if SWF detection detects that the flash plugin is installed."), Category("SWF Detection"), Editor("System.Web.UI.Design.UrlEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))]public string SWF_DetectionContentUrl
				{
					get
					{
						if (this.FlashOutputType == FlashOutputType.SWFVersionDetection)
						{
							return this._mdetectioncontenturl;
						}
						else
						{
							return "";
						}
					}
					set
					{
						this._mdetectioncontenturl = value;
					}
				}
				/// <summary>
				/// Gets or sets the flash movie variable used to auto install the plugin.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(typeof(FlashScriptAccessControl), "SameDomain"), Description("Determines if the plugin should be auto installed."), Category("SWF Detection")]public bool AllowFlashAutoInstall
				{
					get
					{
						return this._mallowflashautoinstall;
					}
					set
					{
						this._mallowflashautoinstall = value;
					}
				}
				/// <summary>
				/// The virtual path to the flash movie.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(""), Description("The virtual path to your flash movie."), Category("Flash Control"), Editor("System.Web.UI.Design.UrlEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))]public string MovieName
				{
					get
					{
						return this._mname;
					}
					set
					{
						this._mname = value;
					}
				}
				
				/// <summary>
				/// Gets or sets the flash movie parameter responsible for auto-starting your movie.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(true), Description("Determines whether or not your flash movie will automatically start at runtime."), Category("Movie Control")]public bool AutoPlay
				{
					get
					{
						return this._mautoplay;
					}
					set
					{
						this._mautoplay = value;
					}
				}
				/// <summary>
				/// Gets or sets the flash movie parameter responsible for looping your movie.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(true), Description("Determines whether or not the flash movie will automatically loop infinitely."), Category("Movie Control")]public bool AutoLoop
				{
					get
					{
						return this._mautoloop;
					}
					set
					{
						this._mautoloop = value;
					}
				}
				
				/// <summary>
				/// Gets or sets the flash movie parameter responsible for setting the quality of your movie.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(typeof(FlashMovieQuality), "High"), Description("Determines the quality setting to use with your flash movie."), Category("Apperance")]public FlashMovieQuality MovieQuality
				{
					get
					{
						return this._mquality;
					}
					set
					{
						this._mquality = value;
					}
				}
				
				/// <summary>
				/// Gets or sets the flash movie parameter responsible for setting the window mode of your movie.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(typeof(FlashMovieWindowMode), "Window"), Description("Determines the window mode of your flash movie."), Category("Apperance")]public FlashMovieWindowMode WindowMode
				{
					get
					{
						return this._mwmode;
					}
					set
					{
						this._mwmode = value;
					}
				}
				
				/// <summary>
				/// Gets or sets the flash movie parameter responsible for setting the scale of your movie.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(typeof(FlashMovieScale), "ShowAll"), Description("Determines the scale mode of the flash movie."), Category("Apperance")]public FlashMovieScale MovieScale
				{
					get
					{
						return this._mscale;
					}
					set
					{
						this._mscale = value;
					}
				}
				
				/// <summary>
				/// Gets or sets the flash horizontal alignment for your movie.
				/// Used in conjunction with the FlashVerticalAlignment property to form the flash "salign" parameter.
				/// </summary>
				[Browsable(true), Bindable(false), Description("Determines the flash horizontal alignment setting for use in the salign parameter."), Category("Alignment")]public FlashHorizontalAlignment FlashHorizontalAlignment
				{
					get
					{
						return this._mflashAlign.HorizontalAlign;
					}
					set
					{
						this._mflashAlign.HorizontalAlign = value;
					}
				}
				
				/// <summary>
				/// Gets or sets the flash vertical alignment for your movie.
				/// Used in conjunction with the FlashHorizontalAlignment property to form the flash "salign" parameter.
				/// </summary>
				[Browsable(true), Bindable(false), Description("Determines the flash vertical alignment setting for use in the salign parameter."), Category("Alignment")]public FlashVerticalAlignment FlashVerticalAlignment
				{
					get
					{
						return this._mflashAlign.VerticalAlign;
					}
					set
					{
						this._mflashAlign.VerticalAlign = value;
					}
				}
				
				/// <summary>
				/// Gets the value to be used in the flash salign parameter from both the FlashHorizontalAlignment and FlashVerticalAlignment properties.
				/// </summary>
				[Browsable(false)]protected string FlashAlignment
				{
					get
					{
						return this._mflashAlign.ToString();
					}
				}
				/// <summary>
				/// Gets or sets the html alignment for your flash movie.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(typeof(FlashHtmlAlignment), "None"), Description("Determines the html alignment of your flash movie."), Category("Alignment")]public FlashHtmlAlignment HtmlAlignment
				{
					get
					{
						return this._mhtmlalign;
					}
					set
					{
						this._mhtmlalign = value;
					}
				}
				
				/// <summary>
				/// Gets or sets the flash output type to use when rendering the FlashMovie control to the browser.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(typeof(FlashOutputType), "FlashOnly"), Description("Determines the output type to use when rendering the FlashMovie control to the browser."), Category("Movie Control")]public FlashOutputType FlashOutputType
				{
					get
					{
						return this._moutputtype;
					}
					set
					{
						this._moutputtype = value;
					}
				}
				/// <summary>
				/// Gets or sets the flash movie parameter responsible for setting the menu mode of your flash movie.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(true), Description("Determines the menu mode of your flash movie."), Category("Movie Control")]public bool ShowMenu
				{
					get
					{
						return this._mmenu;
					}
					set
					{
						this._mmenu = value;
					}
				}
				
				/// <summary>
				/// Gets or sets the flash movie parameter responsible for enabling or disabling device fonts in your movie.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(false), Description("Determines if your flash movie will use device fonts."), Category("Apperance")]public bool UseDeviceFonts
				{
					get
					{
						return this._mdevicefont;
					}
					set
					{
						this._mdevicefont = value;
					}
				}
				
				/// <summary>
				/// Gets or sets the background color of your flash movie.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(typeof(System.Drawing.Color), "#ffffff"), Description("Determines the background color of your flash movie."), Category("Apperance")]public Color MovieBGColor
				{
					get
					{
						return this._mbgcolor;
					}
					set
					{
						this._mbgcolor = value;
					}
				}
				
				/// <summary>
				/// Gets or sets the width of your flash movie.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue("550"), Description("Determines the width of your flash movie."), Category("Apperance")]public string MovieWidth
				{
					get
					{
						return this._mwidth;
					}
					set
					{
						this._mwidth = value;
					}
				}
				
				/// <summary>
				/// Gets or sets the height of your flash movie.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue("400"), Description("Determines the height of your flash movie."), Category("Apperance")]public string MovieHeight
				{
					get
					{
						return this._mheight;
					}
					set
					{
						this._mheight = value;
					}
				}
				/// <summary>
				/// Gets or sets the html embed element's swLiveConnect parameter.
				/// </summary>
				[Browsable(true), Bindable(false), DefaultValue(false), Description("Sets the html embed element\'s swLiveConnect parameter."), Category("Movie Control")]public bool LiveConnect
				{
					get
					{
						return this._mLiveConnect;
					}
					set
					{
						this._mLiveConnect = value;
					}
				}
				
				/// <summary>
				/// Gets or sets the NameValueCollection used to pass variables to the flash movie through the querystring.
				/// </summary>
				[Browsable(false)]public NameValueCollection MovieVariables
				{
					get
					{
						return this._mvariables;
					}
					set
					{
						this._mvariables = value;
					}
				}
				
				/// <summary>
				/// Gets or sets the PlaceHolder responsible for containing the controls that will be rendered as the html noscript
				/// content if javascript is disabled on the client browser.  This is only relevent if the FlashMovie controls output
				///  type is set to one of the version detection enumeration members.
				/// </summary>
				[Browsable(false)]public PlaceHolder NoScriptContainer
				{
					get
					{
						return this._mnoscript;
					}
					set
					{
						this._mnoscript = value;
					}
				}
				
				/// <summary>
				/// Gets or sets the PlaceHolder responsible for containing the controls that will be rendered as the javascript
				/// content if no flash plugin was detected on the client browser.  This is only relevent if the FlashMovie controls output
				///  type is set to one of the version detection enumeration members.
				/// </summary>
				[Browsable(false)]public PlaceHolder NoFlashContainer
				{
					get
					{
						return this._mnoflash;
					}
					set
					{
						this._mnoflash = value;
					}
				}
				
				/// <summary>
				/// Gets the mimetype of the flash plugin.
				/// </summary>
				[Browsable(true), Bindable(false), ReadOnly(true), Description("The mime type that the flash plugin uses."), Category("Constants")]public string FlashMimeType
				{
					get
					{
						return FlashMovie.MIME_TYPE;
					}
				}
				
				/// <summary>
				/// Gets the CLASSID of the flash plugin.
				/// </summary>
				[Browsable(true), Bindable(false), ReadOnly(true), Description("The classid of the flash plugin."), Category("Constants")]public string FlashClassID
				{
					get
					{
						return FlashMovie.CLASS_ID;
					}
				}
				
				/// <summary>
				/// Gets the CodeBase Url used as the codebase parameter to the flash object.
				/// </summary>
				[Browsable(true), Bindable(false), ReadOnly(true), Description("The codebase url used in the codebase parameter to the flash object."), Category("Constants")]public string FlashCodeBase
				{
					get
					{
						if (System.Web.HttpContext.Current.Request.IsSecureConnection || this.MovieName.IndexOf("https") == 0)
						{
							return FlashMovie.CODE_BASE_URL_SSL + "#version=" + this.VersionString;
						}
						else
						{
							return FlashMovie.CODE_BASE_URL + "#version=" + this.VersionString;
						}
					}
				}
				/// <summary>
				/// Gets the flash plugins webpage url that is used in the embed element.
				/// </summary>
				[Browsable(true), Bindable(false), ReadOnly(true), Description("The url of the flash plugins page used in the html embed element."), Category("Constants")]public string FlashPluginsPage
				{
					get
					{
						if (System.Web.HttpContext.Current.Request.IsSecureConnection || this.MovieName.IndexOf("https") == 0)
						{
							return FlashMovie.PLUGINS_PAGE_SSL;
						}
						else
						{
							return FlashMovie.PLUGINS_PAGE;
						}
					}
				}
				
				/// <summary>
				/// Gets the flash plugins webpage url that is used with SWF version detection.
				/// </summary>
				[Browsable(true), Bindable(false), ReadOnly(true), Description("The url of the flash plugins page used with SWF version detection."), Category("Constants")]public string DetectionPluginsPage
				{
					get
					{
						if (System.Web.HttpContext.Current.Request.IsSecureConnection || this.MovieName.IndexOf("https") == 0)
						{
							return FlashMovie.DETECTION_PLUGINS_PAGE_SSL;
						}
						else
						{
							return FlashMovie.DETECTION_PLUGINS_PAGE;
						}
					}
				}
				/// <summary>
				/// Gets the javascript version used to detect the falsh plugin version.
				/// </summary>
				[Browsable(true), Bindable(false), ReadOnly(true), Description("The javascript version used to detect the flash plugin version."), Category("Constants")]public string ClientScriptVersion
				{
					get
					{
						return FlashMovie.SCRIPT_VERSION;
					}
				}
				
				/// <summary>
				/// Gets the full version string of the plugin.  Used in the plugins codebase.
				/// </summary>
				[Browsable(false)]public string VersionString
				{
					get
					{
						return this.MajorPluginVersion + "," + this.MajorPluginVersionRevision + "," + this.MinorPluginVersion + "," + this.MinorPluginVersionRevision;
					}
				}
				
				
				#endregion
				
				#region Control Render Methods
				/// <summary>
				/// Captures and supresses the porting of the rendered content of the noscript and noflash containers to the HtmlTextWriter.
				/// </summary>
				/// <param name="writer">The HtmlTextWriter to render content to.</param>
				protected override void RenderChildren(HtmlTextWriter writer)
				{
					
					//Loop through controls to find the NoScript and NoFlash placeholders
					//Content of these controls is stored and suppressed from the HtmlTextWriter
					//For further modifications
					foreach (System.Web.UI.Control c in this.Controls)
					{
						StringWriter sw = new StringWriter();
						HtmlTextWriter htw = new HtmlTextWriter(sw);
						
						c.RenderControl(htw);
						StringBuilder sb = sw.GetStringBuilder();
						
						if (c.ID == (FlashMovie.NOFLASH_CONTAINERID))
						{
							this.PostRenderNoFlashContent = sb.ToString();
						}
						else if (c.ID == (FlashMovie.NOSCRIPT_CONTAINERID))
						{
							this.PostRenderNoScriptContent = sb.ToString();
						}
					}
					
					
				}
				
				/// <summary>
				/// Renders the FlashMovie Control
				/// </summary>
				/// <param name="writer">The HtmlTextWriter to render content to.</param>
				protected override void Render(HtmlTextWriter writer)
				{
					//Calls RenderChildren to make sure NoScript and NoFlash Content is captured.
					this.RenderChildren(writer);
					
					//Render out the script tag used to include the FSCommand functions is nessesary
					if (this.FSCommandScriptUrl != string.Empty)
					{
						writer.WriteLine("<script language=\"javascript\" src=\"{0}\"></script>", this.FSCommandScriptUrl);
					}
					
					//Initiate the flash output method
					switch (this.FlashOutputType)
					{
						case FlashOutputType.ClientScriptVersionDection:
							this.RenderPluginDetectionScript(writer);
							break;
						case FlashOutputType.SWFVersionDetection:
							this.RenderSWFDetectionScript(writer);
							break;
						case FlashOutputType.FlashOnly:
							this.RenderFlashOnlyScript(writer);
							break;
						default:
							this.RenderFlashOnlyScript(writer);
							break;
					}
					
					//Suppressed so that Render children is not called twice.
					//base.Render (writer);
				}
				/// <summary>
				/// Renders the flash movie parameters to the html object tag.
				/// </summary>
				/// <param name="writer">The HtmlTextWriter to render content to.</param>
				protected virtual void RenderFlashObjectParameters(HtmlTextWriter writer)
				{
					
					writer.Write("<PARAM NAME=movie VALUE=\"" + this.MovieName);
					this.RenderFlashMovieVariables(writer);
					writer.Write("\"> ");
					
					//
					//Only set parameters that are not set to the flash plugin default value
					//
					if (this.AutoPlay == false)
					{
						writer.Write("<PARAM NAME=play VALUE=" + this.AutoPlay.ToString().ToLower() + " /> ");
					}
					if (this.AutoLoop == false)
					{
						writer.Write("<PARAM NAME=loop VALUE=" + this.AutoLoop.ToString().ToLower() + " /> ");
					}
					if (this.ShowMenu == false)
					{
						writer.Write("<PARAM NAME=menu VALUE=" + this.ShowMenu.ToString().ToLower() + " /> ");
					}
					if (this.MovieScale != FlashMovieScale.ShowAll)
					{
						writer.Write("<PARAM NAME=scale VALUE=" + this.MovieScale.ToString().ToLower() + " /> ");
					}
					if (this.WindowMode != FlashMovieWindowMode.Window)
					{
						writer.Write("<PARAM NAME=wmode VALUE=" + this.WindowMode.ToString().ToLower() + " /> ");
					}
					if (this.UseDeviceFonts == true)
					{
						writer.Write("<PARAM NAME=devicefont VALUE=" + this.UseDeviceFonts.ToString().ToLower() + " /> ");
					}
					if (this.FlashAlignment.ToString() != "")
					{
						writer.Write("<PARAM NAME=salign VALUE=" + this.FlashAlignment.ToString() + " /> ");
					}
					
					
					writer.Write("<PARAM NAME=quality VALUE=" + this.MovieQuality.ToString() + "/> ");
					writer.Write("<PARAM NAME=bgcolor VALUE=#" + this.MovieBGColor.ToArgb().ToString("x").Substring(2) + "/> ");
					writer.Write("<PARAM NAME=\"allowScriptAccess\" value=\"" + this.ScriptAccessControl + "\" />");
					
					
				}
				/// <summary>
				/// Renders the flash movie parameters to the html embed tag.
				/// </summary>
				/// <param name="writer">The HtmlTextWriter to render content to.</param>
				protected virtual void RenderFlashEmbedParameters(HtmlTextWriter writer)
				{
					
					//
					//Only set parameters that are not set to the flash plugin default value
					//
					if (this.AutoPlay == false)
					{
						writer.Write("play=\"" + this.AutoPlay.ToString().ToLower() + "\" ");
					}
					if (this.AutoLoop == false)
					{
						writer.Write("loop=\"" + this.AutoLoop.ToString().ToLower() + "\" ");
					}
					if (this.ShowMenu == false)
					{
						writer.Write("menu=\"" + this.ShowMenu.ToString().ToLower() + "\" ");
					}
					if (this.MovieScale != FlashMovieScale.ShowAll)
					{
						writer.Write("scale=\"" + this.MovieScale.ToString().ToLower() + "\" ");
					}
					if (this.WindowMode != FlashMovieWindowMode.Window)
					{
						writer.Write("wmode=\"" + this.WindowMode.ToString().ToLower() + "\" ");
					}
					if (this.UseDeviceFonts == true)
					{
						writer.Write("devicefont=\"" + this.UseDeviceFonts.ToString().ToLower() + "\" ");
					}
					if (this.FlashAlignment.ToString() != "")
					{
						writer.Write("salign=\"" + this.FlashAlignment.ToString() + "\" ");
					}
					
					writer.Write("quality=\"" + this.MovieQuality.ToString().ToLower() + "\" ");
					writer.Write("bgcolor=\"#" + this.MovieBGColor.ToArgb().ToString("x").Substring(2) + "\" ");
					writer.Write("allowScriptAccess=\"" + this.ScriptAccessControl + "\" ");
				}
				/// <summary>
				/// Renders the NameValueCollection of flash movie variables into querystring form.
				/// </summary>
				/// <param name="writer">The HtmlTextWriter to render content to.</param>
				protected virtual void RenderFlashMovieVariables(HtmlTextWriter writer)
				{
					if (this.MovieVariables.Count > 0)
					{
						string varString = "";
						//Start querystring begining
						writer.Write("?");
						
						foreach (string s in this.MovieVariables.Keys)
						{
							//writes key name value pair
							varString += s + "=" + this.MovieVariables[s] + "&";
						}
						
						//strip off last ampersand
						varString = varString.Remove(varString.Length - 1, 1);
						writer.Write(varString);
					}
				}
				/// <summary>
				/// If plugin version detection is enabled this method is called to invoke the rendering of the FlashMovie control.
				/// </summary>
				protected void RenderPluginDetectionScript(HtmlTextWriter writer)
				{
					
					//No movie UI is available during client script detection
					//because of the javascript code.  So if the state is in
					//design mode the FlashOnlyScript method will be rendered to give
					//the user some UI to view.
					if ((this.Site != null) && (this.Site.DesignMode == true))
					{
						this.RenderFlashOnlyScript(writer);
					}
					else
					{
						//Open client script
						writer.WriteLine("<SCRIPT LANGUAGE=JavaScript1.1>");
						writer.WriteLine("<!--");
						
						//Render plugin detection and movie display handlers
						this.RenderPluginDetectionDeclaration(writer, this.MajorPluginVersion);
						this.RenderPluginDetectionBlock(writer);
						this.RenderContentDisplayBlock(writer);
						
						//Close client script
						writer.WriteLine("//-->");
						writer.WriteLine("</SCRIPT>");
						
						//Render NoScript content
						writer.WriteLine("<NOSCRIPT>");
						writer.Write(this.PostRenderNoScriptContent);
						writer.WriteLine("</NOSCRIPT>");
					}
				}
				/// <summary>
				/// If FlashOnly output method is set this method is called to invoke the rendering of the FlashMovie control.
				/// </summary>
				/// <param name="writer">The HtmlTextWriter to render content to.</param>
				protected void RenderFlashOnlyScript(HtmlTextWriter writer)
				{
					//Start html object tag
					writer.WriteLine("<OBJECT classid=\"" + FlashMovie.CLASS_ID + "\"");
					writer.WriteLine("codebase=\"" + this.FlashCodeBase + "\"");
					
					writer.Write("WIDTH=\"" + this.MovieWidth + "\" HEIGHT=\"" + this.MovieHeight + "\" ");
					writer.Write("id=\"" + this.ID + "\" ALIGN=\"" + this.HtmlAlignment.ToString().ToLower() + "\">");
					this.RenderFlashObjectParameters(writer);
					
					//Start html embed tag
					writer.Write("<EMBED src=\"" + this.MovieName);
					this.RenderFlashMovieVariables(writer);
					writer.Write("\" ");
					
					this.RenderFlashEmbedParameters(writer);
					
					writer.Write("WIDTH=\"" + this.MovieWidth + "\" HEIGHT=\"" + this.MovieHeight + "\" ");
					writer.WriteLine("id=\"" + this.ID + "\" ALIGN=\"" + this.HtmlAlignment.ToString().ToLower() + "\"");
					
					writer.Write("TYPE=\"" + FlashMovie.MIME_TYPE + "\" ");
					writer.WriteLine("PLUGINSPAGE=\"" + FlashMovie.PLUGINS_PAGE + "\"></EMBED>");
					
					writer.WriteLine("</OBJECT>");
				}
				
				/// <summary>
				/// If SWF Detection in output method is set this method is called to invoke the rendering of the FlashMovie control.
				/// </summary>
				/// <param name="writer"></param>
				protected void RenderSWFDetectionScript(HtmlTextWriter writer)
				{
					
					this.MovieVariables.Add("contentVersion", Convert.ToString(this.MajorPluginVersion));
					this.MovieVariables.Add("contentMajorRevision", "0");
					this.MovieVariables.Add("contentMinorRevision", Convert.ToString(this.MinorPluginVersion));
					this.MovieVariables.Add("allowFlashAutoInstall", this.AllowFlashAutoInstall.ToString());
					
					
					//Hides output from designer.
					//Problems with redirection taking place made designer
					//a little quirky.
					if ((this.Site != null) && (this.Site.DesignMode == true))
					{
					}
					else
					{
						this.MovieVariables.Add("flashContentURL", this.SWF_DetectionContentUrl);
						this.MovieVariables.Add("altContentURL", this.SWF_DetectionAltUrl);
					}
					
					
					
					writer.Write("<object classid=\"" + this.FlashClassID + "\" ");
					writer.Write("codebase=\"" + FlashMovie.CODE_BASE_URL + "\" ");
					writer.WriteLine("width=\"" + this.MovieWidth + "\" height=\"" + this.MovieHeight + "\">");
					
					this.RenderFlashObjectParameters(writer);
					
					//Start html embed tag
					writer.Write("<EMBED src=\"" + this.MovieName);
					this.RenderFlashMovieVariables(writer);
					writer.Write("\" ");
					
					this.RenderFlashEmbedParameters(writer);
					writer.Write("WIDTH=\"" + this.MovieWidth + "\" HEIGHT=\"" + this.MovieHeight + "\" ");
					
					writer.Write("TYPE=\"" + FlashMovie.MIME_TYPE + "\" ");
					writer.WriteLine("PLUGINSPAGE=\"" + FlashMovie.DETECTION_PLUGINS_PAGE + "\"></EMBED>");
					
					writer.WriteLine("</OBJECT>");
				}
				
				#endregion
				
				#region Helper Methods For Rendering Flash Movie In Detection Mode
				/// <summary>
				/// Renders the client script variable initilization and sets the plugin client script variable
				/// </summary>
				/// <param name="writer">If plugin version detection is enabled this method is called to invoke the rendering of the FlashMovie control.</param>
				/// <param name="version">The version number being used for plugin detection.</param>
				protected virtual void RenderPluginDetectionDeclaration(HtmlTextWriter writer, int version)
				{
					writer.WriteLine("var MM_contentVersion = " + version + ";");
					writer.WriteLine("var plugin = (navigator.mimeTypes && navigator.mimeTypes[\"" + FlashMovie.MIME_TYPE + "\"]) ?");
					writer.WriteLine("navigator.mimeTypes[\"" + FlashMovie.MIME_TYPE + "\"].enabledPlugin : 0;");
				}
				
				/// <summary>
				/// Renders the client script that detects if the flash plugin is available
				/// </summary>
				protected virtual void RenderPluginDetectionBlock(HtmlTextWriter writer)
				{
					writer.WriteLine("if ( plugin ) {");
					writer.WriteLine("var words = navigator.plugins[\"Shockwave Flash\"].description.split(\" \");");
					writer.WriteLine("for (var i = 0; i < words.length; ++i)");
					writer.WriteLine("{");
					writer.WriteLine("if (isNaN(parseInt(words[i])))");
					writer.WriteLine("continue;");
					writer.WriteLine("var MM_PluginVersion = words[i];");
					writer.WriteLine("}");
					writer.WriteLine("var MM_FlashCanPlay = MM_PluginVersion >= MM_contentVersion;");
					writer.WriteLine("}");
					writer.WriteLine("else if (navigator.userAgent && navigator.userAgent.indexOf(\"MSIE\")>=0");
					writer.WriteLine("&& (navigator.appVersion.indexOf(\"Win\") != -1)) {");
					writer.WriteLine("document.write(\'<SCR\' + \'IPT LANGUAGE=VBScript\\> \\n\');");
					writer.WriteLine("document.write(\'on error resume next \\n\');");
					writer.Write("document.write(\'MM_FlashCanPlay = ( IsObject(CreateObject(\"ShockwaveFlash.ShockwaveFlash.\" & MM_contentVersion)))");
					writer.WriteLine("\\n\');");
					writer.WriteLine("document.write(\'</SCR\' + \'IPT\\> \\n\');");
					writer.WriteLine("}");
				}
				/// <summary>
				/// Renders the client script and content used to display the flash movie.
				/// </summary>
				/// <param name="writer">The HtmlTextWriter to render content to.</param>
				protected virtual void RenderFlashCanPlayBlock(HtmlTextWriter writer)
				{
					writer.WriteLine("document.write(\'<OBJECT classid=\"" + FlashMovie.CLASS_ID + "\"\');");
					writer.WriteLine("document.write(\'  codebase=\"" + this.FlashCodeBase + "\" \');");
					writer.Write("document.write(\' ");
					writer.Write("ID=\"" + this.ID + "\" WIDTH=\"" + this.MovieWidth + "\" ");
					writer.WriteLine("HEIGHT=\"" + this.MovieHeight + "\" ALIGN=\"" + this.HtmlAlignment.ToString().ToLower() + "\">\');");
					
					writer.Write("document.write(\' ");
					this.RenderFlashObjectParameters(writer);
					writer.WriteLine("  \');");
					
					
					writer.Write("document.write(\' <EMBED src=\"" + this.MovieName);
					this.RenderFlashMovieVariables(writer);
					writer.Write("\" ");
					
					this.RenderFlashEmbedParameters(writer);
					writer.WriteLine("  \');");
					
					writer.Write("document.write(\' swLiveConnect=" + this.LiveConnect.ToString().ToUpper() + " ");
					writer.Write("WIDTH=\"" + this.MovieWidth + "\" HEIGHT=\"" + this.MovieHeight + "\" ");
					writer.Write("NAME=\"" + this.MovieName);
					this.RenderFlashMovieVariables(writer);
					writer.WriteLine("\" ALIGN=\"" + this.HtmlAlignment.ToString().ToLower() + "\"\');");
					writer.WriteLine("document.write(\' TYPE=\"" + this.FlashMimeType + "\" PLUGINSPAGE=\"" + this.FlashPluginsPage + "\">\');");
					writer.WriteLine("document.write(\' </EMBED>\');");
					
					
					writer.WriteLine("document.write(\' </OBJECT>\');");
				}
				
				/// <summary>
				/// Renders the client script and content used if the flash plugin is unavailable.
				/// </summary>
				/// <param name="writer">The HtmlTextWriter to render content to.</param>
				protected void RenderFlashCanNotPlayBlock(HtmlTextWriter writer)
				{
					
					if (this._mnoflash.HasControls())
					{
						string line = "";
						
						StringReader sr = new StringReader(this.PostRenderNoFlashContent.Replace("\\", "\\\\").Replace("\'", "\\\'"));
						line = sr.ReadLine();
						while (line != null)
						{
							writer.Write("document.write(\'");
							writer.Write(line);
							writer.WriteLine("\');");
							line = sr.ReadLine();
						}
					}
					
				}
				
				/// <summary>
				/// Renders the top level client script used to display content to the browser.
				/// </summary>
				/// <param name="writer">The HtmlTextWriter to render content to.</param>
				protected virtual void RenderContentDisplayBlock(HtmlTextWriter writer)
				{
					writer.WriteLine("if ( MM_FlashCanPlay ) {");
					this.RenderFlashCanPlayBlock(writer);
					writer.WriteLine("} else{");
					this.RenderFlashCanNotPlayBlock(writer);
					writer.WriteLine("}");
				}
				
				#endregion
				#region ViewState Methods
				
				/// <summary>
				///
				/// </summary>
				/// <returns></returns>
				protected override object SaveViewState()
				{
					// Get the base state object
					object baseState = base.SaveViewState();
					
					// Create the array to hold all stated data
					object[] allStates = new object[27]();
					
					// Set the first index of the state array to the base state
					allStates[0] = baseState;
					
					allStates[1] = this.AllowFlashAutoInstall;
					allStates[2] = this.AutoLoop;
					allStates[3] = this.AutoPlay;
					allStates[4] = this.FlashHorizontalAlignment;
					allStates[5] = this.FlashOutputType;
					allStates[6] = this.FlashVerticalAlignment;
					allStates[7] = this.FSCommandScriptUrl;
					allStates[8] = this.HtmlAlignment;
					allStates[9] = this.LiveConnect;
					allStates[10] = this.MajorPluginVersion;
					allStates[11] = this.MajorPluginVersionRevision;
					allStates[12] = this.MinorPluginVersion;
					allStates[13] = this.MinorPluginVersionRevision;
					allStates[14] = this.MovieBGColor;
					allStates[15] = this.MovieHeight;
					allStates[16] = this.MovieName;
					allStates[17] = this.MovieQuality;
					allStates[18] = this.MovieScale;
					allStates[19] = this.MovieVariables;
					allStates[20] = this.MovieWidth;
					allStates[21] = this.ScriptAccessControl;
					allStates[22] = this.ShowMenu;
					allStates[23] = this.SWF_DetectionAltUrl;
					allStates[24] = this.SWF_DetectionContentUrl;
					allStates[25] = this.UseDeviceFonts;
					allStates[26] = this.WindowMode;
					
					return allStates;
				}
				
				/// <summary>
				///
				/// </summary>
				protected override void LoadViewState(object savedState)
				{
					if (savedState != null)
					{
						// Load State from the array of objects that was saved at SavedViewState.
						object[] baseState = (object[]) savedState;
						
						if (! baseState[0] == null)
						{
							base.LoadViewState(baseState[0]);
						}
						
						if (! baseState[1] == null)
						{
							this.AllowFlashAutoInstall = System.Convert.ToBoolean(baseState[1]);
						}
						
						if (! baseState[2] == null)
						{
							this.AutoLoop = System.Convert.ToBoolean(baseState[2]);
						}
						
						if (! baseState[3] == null)
						{
							this.AutoPlay = System.Convert.ToBoolean(baseState[3]);
						}
						
						if (! baseState[4] == null)
						{
							this.FlashHorizontalAlignment = (FlashHorizontalAlignment) (baseState[4]);
						}
						
						if (! baseState[5] == null)
						{
							this.FlashOutputType = (FlashOutputType) (baseState[5]);
						}
						
						if (! baseState[6] == null)
						{
							this.FlashVerticalAlignment = (FlashVerticalAlignment) (baseState[6]);
						}
						
						if (! baseState[7] == null)
						{
							this.FSCommandScriptUrl = baseState[7].ToString();
						}
						
						if (! baseState[8] == null)
						{
							this.HtmlAlignment = (FlashHtmlAlignment) (baseState[8]);
						}
						
						if (! baseState[9] == null)
						{
							this.LiveConnect = System.Convert.ToBoolean(baseState[9]);
						}
						
						if (! baseState[10] == null)
						{
							this.MajorPluginVersion = System.Convert.ToInt32(Conversion.Fix(baseState[10]));
						}
						
						if (! baseState[11] == null)
						{
							this.MajorPluginVersionRevision = System.Convert.ToInt32(Conversion.Fix(baseState[11]));
						}
						
						if (! baseState[12] == null)
						{
							this.MinorPluginVersion = System.Convert.ToInt32(Conversion.Fix(baseState[12]));
						}
						
						if (! baseState[13] == null)
						{
							this.MinorPluginVersionRevision = System.Convert.ToInt32(Conversion.Fix(baseState[13]));
						}
						
						if (! baseState[14] == null)
						{
							this.MovieBGColor = (Color) (baseState[14]);
						}
						
						if (! baseState[15] == null)
						{
							this.MovieHeight = baseState[15].ToString();
						}
						
						if (! baseState[16] == null)
						{
							this.MovieName = baseState[16].ToString();
						}
						
						if (! baseState[17] == null)
						{
							this.MovieQuality = (FlashMovieQuality) (baseState[17]);
						}
						
						if (! baseState[18] == null)
						{
							this.MovieScale = (FlashMovieScale) (baseState[18]);
						}
						
						if (! baseState[19] == null)
						{
							this.MovieVariables = (NameValueCollection) (baseState[19]);
						}
						
						if (! baseState[20] == null)
						{
							this.MovieWidth = baseState[20].ToString();
						}
						
						if (! baseState[21] == null)
						{
							this.ScriptAccessControl = (FlashScriptAccessControl) (baseState[21]);
						}
						
						if (! baseState[22] == null)
						{
							this.ShowMenu = System.Convert.ToBoolean(baseState[22]);
						}
						
						if (! baseState[23] == null)
						{
							this.SWF_DetectionAltUrl = baseState[23].ToString();
						}
						
						if (! baseState[24] == null)
						{
							this.SWF_DetectionContentUrl = baseState[24].ToString();
						}
						
						if (! baseState[25] == null)
						{
							this.UseDeviceFonts = System.Convert.ToBoolean(baseState[25]);
						}
						
						if (! baseState[26] == null)
						{
							this.WindowMode = (FlashMovieWindowMode) (baseState[26]);
						}
						
					}
				}
				
				
				#endregion
				
			}
			
		}
	}
}
