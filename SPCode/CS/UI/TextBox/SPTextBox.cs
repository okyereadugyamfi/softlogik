using System.Text.RegularExpressions;
using System.Diagnostics;
using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI;
using Microsoft.Win32;
using WeifenLuo;
using System.ComponentModel;
using System.Globalization;
using System.Threading;


namespace SoftLogik.Win
{
	namespace UI
	{
		public partial class SPTextBox
		{
			
			
			#region Enumerations
			public enum TextStyleEnum
			{
				General,
				Numeric,
				Alphabetic,
				Accounting,
				EmailAddress,
				Phone
			}
			#endregion
			#region Members
			private TextStyleEnum m_enmTextStyle;
			private string m_strFormatString;
			private bool m_boolMinusSign;
			private bool m_boolPeriod;
			private bool m_boolTrimSpaces;
			
			//** Storage for property settings
			private bool m_boolHighlight;
			private bool m_boolThousandsSeparator;
			
			//** Locale aware keystrokes
			private string mtDecimal;
			private string mtMinus;
			private string mtSeparator;
			
			//** String Constants
			private const string mtLOWER_A = "a";
			private const string mtUPPER_A = "A";
			private const string mtLOWER_Z = "z";
			private const string mtUPPER_Z = "Z";
			private const string mtZERO = "0";
			private const string mtNINE = "9";
			private const string mtDASH = "-";
			private const string mtLEFT_PAREN = "(";
			private const string mtRIGHT_PAREN = ")";
			private const string mtSPACE = " ";
			
			//** Integer Constants
			private const int miKEY_BACKSPACE = 8;
			private const int miKEY_ENTER = 13;
			
			//** Flow control and cultural sensitivity
			private bool mbIgnoreKeystroke = false;
			private KeyPressed meLastKeystroke;
			
			
			private enum KeyPressed
			{
				NumberPadDecimal = 0,
				SpaceBar = 1,
				NothingSpecial = 2
			}
			#endregion
			#region Constructor
			public SPTextBox()
			{
				//---------------------------------------------------------------------------------
				// Default settings for boolean properties
				//---------------------------------------------------------------------------------
				m_boolPeriod = true;
				m_boolHighlight = true;
				m_boolMinusSign = true;
				m_boolThousandsSeparator = true;
				m_boolTrimSpaces = false;
				
				//---------------------------------------------------------------------------------
				// Set the characters to be used for the locale aware minus sign, thousands
				// separator and decimal point
				//---------------------------------------------------------------------------------
				CultureInfo ci = new CultureInfo(Thread.CurrentThread.CurrentCulture.ToString());
				mtDecimal = ci.NumberFormat.NumberDecimalSeparator;
				mtSeparator = ci.NumberFormat.NumberGroupSeparator;
				mtMinus = ci.NumberFormat.NegativeSign;
				ci = null;
				
			}
			#endregion
			#region Public Properties
			[Description("Returns or Sets the Style of Text in the TextBox")]public TextStyleEnum TextStyle
			{
				get
				{
					return m_enmTextStyle;
				}
				set
				{
					m_enmTextStyle = value;
				}
			}
			[Description("Returns or Sets the Formatting String of the TextBox")]public string FormatString
			{
				get
				{
					return m_strFormatString;
				}
				set
				{
					m_strFormatString = value;
				}
			}
			[Description("Returns or Sets whether or not a minus sign is " + "accepted in the first character position when the" + " TextStyle property is set to Numeric")]public bool MinusSign
			{
				get
				{
					return m_boolMinusSign;
				}
				set
				{
					m_boolMinusSign = value;
				}
			}
			[Description("Returns or Sets whether or not a period is " + "accepted in the TextBox when the " + " TextStyle property is set to Numeric")]public bool Period
			{
				get
				{
					return m_boolPeriod;
				}
				set
				{
					m_boolPeriod = value;
				}
			}
			[Description("Return or Sets whether or not leading and trailing " + "spaces are removed from the Text when the TextBox loses the focus")]public bool TrimSpaces
			{
				get
				{
					bool returnValue;
					returnValue = m_boolTrimSpaces;
					return returnValue;
				}
				
				set
				{
					m_boolTrimSpaces = value;
				}
				
			}
			[Description("Return or Sets whether or not text in the TextBox " + "is higlighted when the TextBox gets focus")]public bool Highlight
			{
				get
				{
					return m_boolHighlight;
				}
				set
				{
					m_boolHighlight = value;
				}
			}
			[Description("")]public bool ThousandsSeparator
			{
				get
				{
					return m_boolThousandsSeparator;
				}
				set
				{
					m_boolThousandsSeparator = value;
				}
			}
			#endregion
			#region  SPTextBox Events
			protected override void OnGotFocus(System.EventArgs e)
			{
				base.OnGotFocus(e);
				SPTextBox with_1 = this;
				if (m_boolHighlight)
				{
					//** Highlight any text and place the cursor at the end of that text
					with_1.SelectionStart = 0;
					with_1.SelectionLength = with_1.Text.Length;
				}
				else
				{
					//** Place the cursor at the end of any text without highlighting
					with_1.SelectionLength = 0;
					with_1.SelectionStart = with_1.Text.Length;
				}
				
			}
			protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
			{
				base.OnKeyDown(e);
				//---------------------------------------------------------------------------------
				// Detect when the decimal point on the keypad, or the space bar is pressed
				//---------------------------------------------------------------------------------
				switch (e.KeyCode.ToString().ToLower())
				{
					case "decimal":
						
						meLastKeystroke = KeyPressed.NumberPadDecimal;
						break;
					case "space":
						
						meLastKeystroke = KeyPressed.SpaceBar;
						break;
					default:
						
						meLastKeystroke = KeyPressed.NothingSpecial;
						break;
				}
				
			}
			protected override void OnKeypress(System.Windows.Forms.KeyPressEventArgs e)
			{
				base.OnKeyPress(e);
				switch (Strings.Asc(e.KeyChar))
				{
					case miKEY_BACKSPACE:
					case miKEY_ENTER:
						break;
						//Navigation or edit keystroke ... fall through
					default:
						//Test all other characters
						switch (m_enmTextStyle)
						{
							case TextStyleEnum.General:
								break;
								//All keystrokes are allowed ... fall through
							case TextStyleEnum.Alphabetic:
								AllowLettersOnly(e);
								break;
							case TextStyleEnum.Numeric:
							case TextStyleEnum.Accounting:
								AllowNumbersOnly(e);
								break;
							case TextStyleEnum.Phone:
								AllowPhoneChar(e);
								break;
						}
						break;
				}
				
			}
			protected override void OnLeave(System.EventArgs e)
			{
				base.OnLeave(e);
				if (m_boolTrimSpaces)
				{
					//Remove all leading and trailing spaces from the text
					this.Text = this.Text.Trim();
				}
				
			}
			protected override void OnTextChanged(System.EventArgs e)
			{
				base.OnTextChanged(e);
				
				FormatText();
			}
			#endregion
			#region  Procedures
			private void AllowLettersOnly(System.Windows.Forms.KeyPressEventArgs e)
			{
				//---------------------------------------------------------------------------------
				// Accept a-z, A-Z, and space
				//---------------------------------------------------------------------------------
				//     Date          Developer                      Comments
				//  ---------- -------------------- -----------------------------------------------
				//  09/12/2005 G Gilbert            Original code
				//---------------------------------------------------------------------------------
				
				System.Windows.Forms.KeyPressEventArgs with_1 = e;
				if ((with_1.KeyChar >= mtLOWER_A && with_1.KeyChar <= mtLOWER_Z) || (with_1.KeyChar >= mtUPPER_A && with_1.KeyChar <= mtUPPER_Z) || with_1.KeyChar == mtSPACE)
				{
					//** The keystroke is allowed ... fall through
				}
				else
				{
					//** The keystroke is not allowed ... dump it
					DumpKeystroke(e, true);
				}
				
			}
			private void AllowNumbersOnly(System.Windows.Forms.KeyPressEventArgs e)
			{
				//---------------------------------------------------------------------------------
				// Accept 0-9 plus allowed number related special characters (minus sign, decimal
				// point, thousands separator)
				//---------------------------------------------------------------------------------
				//     Date          Developer                      Comments
				//  ---------- -------------------- -----------------------------------------------
				//  09/12/2005 G Gilbert            Original code
				//  04/27/2006 G Gilbert            Added correct handling of a decimal keystroke
				//                                       on the number pad when the decimal is
				//                                       something other than a period; and the
				//                                       space bar when the thousands separator
				//                                       is a space
				//---------------------------------------------------------------------------------
				
				//---------------------------------------------------------------------------------
				// If a substitute keystroke was sent below, ignore it
				//---------------------------------------------------------------------------------
				if (mbIgnoreKeystroke)
				{
					mbIgnoreKeystroke = false;
					return;
				}
				
				//---------------------------------------------------------------------------------
				// When the decimal point on the number pad is pressed, ensure the keystroke
				// is interpreted correctly per the region settings. Also ensure that the space
				// bar can be used for a thousands separator when called for by the region setting.
				//---------------------------------------------------------------------------------
				bool sendChar;
				string keystroke;
				
				//** Default to neither a decimal or the space bar
				keystroke = e.KeyChar;
				sendChar = false;
				
				//** Override the default with a culturally correct decimal or space
				switch (meLastKeystroke)
				{
					case KeyPressed.NumberPadDecimal:
						//** Convert the number pad decimal point to the culturally correct
						//** character
						keystroke = mtDecimal;
						sendChar = true;
						break;
					case KeyPressed.SpaceBar:
						//** When the thousands separator is a space, convert the space bar
						//** character (ASCII 32) to the culturally correct character (ASCII 160)
						if (Strings.Asc(mtSeparator) == 160)
						{
							keystroke = mtSeparator;
							sendChar = true;
						}
						break;
				}
				
				//---------------------------------------------------------------------------------
				// Determine whether or not the keystroke can be accepted
				//---------------------------------------------------------------------------------
				bool KeyRejected = false;
				switch (keystroke)
				{
					
					case mtMinus:
						if (m_boolMinusSign)
						{
							//** The insertion cursor must be at the start of the text
							if (this.SelectionStart > 0)
							{
								//** The minus sign would not be the first character
								KeyRejected = true;
							}
						}
						else
						{
							//** A minus sign is not allowed
							KeyRejected = true;
						}
						break;
						
					case mtDecimal:
						if (m_boolPeriod)
						{
							if (this.Text.IndexOf(System.Convert.ToChar(mtDecimal)) > - 1)
							{
								//** Only one decimal point is permitted
								KeyRejected = true;
							}
							else
							{
								//** This is the first decimal point entered. Check if
								//** the character is to be changed to the one that
								//** agrees with the region setting.
								if (sendChar)
								{
									//** Dump the keystroke entered by the user
									DumpKeystroke(e, false);
									//** Prevent this Sub from processing the keystroke
									//** being substituted
									mbIgnoreKeystroke = true;
									//** Send the culturally correct substitute character
									SendKeys.Send(mtDecimal);
								}
							}
						}
						else
						{
							//** A decimal point is not allowed
							KeyRejected = true;
						}
						break;
						
					case mtSeparator:
						if (m_boolThousandsSeparator)
						{
							//** Check if the character is to be changed to the one
							//** that agrees with the region setting
							if (sendChar)
							{
								//** Dump the keystroke entered by the user
								DumpKeystroke(e, false);
								//** Prevent this Sub from processing the keystroke
								//** being substituted
								mbIgnoreKeystroke = true;
								//** Send the culturally correct substitute character
								SendKeys.Send(mtSeparator);
							}
						}
						else
						{
							//** Thousands separators are not allowed
							KeyRejected = true;
						}
						break;
						
					default:
						//** Check for numbers
						if (e.KeyChar < mtZERO || e.KeyChar > mtNINE)
						{
							//** The keystroke is not allowed
							KeyRejected = true;
						}
						break;
						
				}
				
				if (KeyRejected)
				{
					//** The keystroke is not allowed ... dump it
					DumpKeystroke(e, true);
				}
				
			}
			private void AllowNoSpecialChar(System.Windows.Forms.KeyPressEventArgs e)
			{
				//---------------------------------------------------------------------------------
				// Accept a-z, A-Z, 0-9, and space
				//---------------------------------------------------------------------------------
				//     Date          Developer                      Comments
				//  ---------- -------------------- -----------------------------------------------
				//  09/12/2005 G Gilbert            Original code
				//---------------------------------------------------------------------------------
				
				System.Windows.Forms.KeyPressEventArgs with_1 = e;
				if ((with_1.KeyChar >= mtLOWER_A && with_1.KeyChar <= mtLOWER_Z) || (with_1.KeyChar >= mtUPPER_A && with_1.KeyChar <= mtUPPER_Z) || (with_1.KeyChar >= mtZERO && with_1.KeyChar <= mtNINE) || with_1.KeyChar == mtSPACE)
				{
					//** The keystroke is allowed ... fall through
				}
				else
				{
					//** The keystroke is not allowed ... dump it
					DumpKeystroke(e, true);
				}
				
			}
			private void AllowPhoneChar(System.Windows.Forms.KeyPressEventArgs e)
			{
				//---------------------------------------------------------------------------------
				// Allow 0-9, -, (), and space
				//---------------------------------------------------------------------------------
				//     Date          Developer                      Comments
				//  ---------- -------------------- -----------------------------------------------
				//  09/12/2005 G Gilbert            Original code
				//---------------------------------------------------------------------------------
				
				System.Windows.Forms.KeyPressEventArgs with_1 = e;
				if ((with_1.KeyChar >= mtZERO && with_1.KeyChar <= mtNINE) || with_1.KeyChar == mtDASH || with_1.KeyChar == mtLEFT_PAREN || with_1.KeyChar == mtRIGHT_PAREN || with_1.KeyChar == mtSPACE)
				{
					//** The keystroke is allowed ... fall through
				}
				else
				{
					//** The keystroke is not allowed ... dump it
					DumpKeystroke(e, true);
				}
				
			}
			private void DumpKeystroke(System.Windows.Forms.KeyPressEventArgs e, bool soundBeep)
			{
				e.Handled = true;
				if (soundBeep)
				{
					Interaction.Beep();
				}
				
			}
			private void FormatText()
			{
				this.Font = new Font(this.Font, FontStyle.Regular);
				this.ForeColor = SystemColors.ControlText;
				
				switch (TextStyle)
				{
					case TextStyleEnum.General:
						this.TextAlign = HorizontalAlignment.Left;
						break;
					case TextStyleEnum.Alphabetic:
						this.TextAlign = HorizontalAlignment.Left;
						break;
					case TextStyleEnum.Accounting:
						this.TextAlign = HorizontalAlignment.Right;
						this.Text = Strings.Format(this.Text, My.Settings.Default.MoneyFormat);
						break;
					case TextStyleEnum.Numeric:
						break;
					case TextStyleEnum.Phone:
						break;
					case TextStyleEnum.EmailAddress:
						this.TextAlign = HorizontalAlignment.Left;
						if (StringSupport.IsValidEmail(this.Text))
						{
							Font newFont = (Font) (this.Font.Clone());
							this.Font = new Font(newFont, FontStyle.Underline);
							this.ForeColor = SystemColors.HotTrack;
							newFont.Dispose();
						}
						break;
					default:
						break;
						
				}
			}
			#endregion
			
		}
	}
	
	
}
