using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using SoftLogik.Text;

[ToolboxBitmap(typeof(TextBox))]
public partial class DomainTextBox 
{

#region Enumerations
	public enum TextStyleEnum: int
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
	private char mtDecimal;
	private char mtMinus;
	private char mtSeparator;

	//** String Constants
	private const char mtLOWER_A = 'a';
    private const char mtUPPER_A = 'A';
    private const char mtLOWER_Z = 'z';
    private const char mtUPPER_Z = 'Z';
    private const char mtZERO = '0';
    private const char mtNINE = '9';
    private const char mtDASH = '-';
    private const char mtLEFT_PAREN = '(';
    private const char mtRIGHT_PAREN = ')';
    private const char mtACE = ' ';

	//** Integer Constants
	private const int miKEY_BACKACE = 8;
	private const int miKEY_ENTER = 13;

	//** Flow control and cultural sensitivity
	private bool mbIgnoreKeystroke = false;
	private KeyPressed meLastKeystroke;


	private enum KeyPressed: int
	{
		NumberPadDecimal = 0,
		SpaceBar = 1,
		NothingSpecial = 2
	}
#endregion
#region Constructor
	public DomainTextBox()
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
		mtDecimal = ci.NumberFormat.NumberDecimalSeparator.ToCharArray()[0] ;
        mtSeparator = ci.NumberFormat.NumberGroupSeparator.ToCharArray()[0];
        mtMinus = ci.NumberFormat.NegativeSign.ToCharArray()[0];
		ci = null;

	}
#endregion
#region Public Properties
	[Description("Returns or Sets the Style of Text in the TextBox")]
	public TextStyleEnum TextStyle
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
	[Description("Returns or Sets the Formatting String of the TextBox")]
	public string FormatString
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
	[Description("Returns or Sets whether or not a minus sign is " + "accepted in the first character position when the" + " TextStyle property is set to Numeric")]
	public bool MinusSign
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
	[Description("Returns or Sets whether or not a period is " + "accepted in the TextBox when the " + " TextStyle property is set to Numeric")]
	public bool Period
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
	[Description("Return or Sets whether or not leading and trailing " + "spaces are removed from the Text when the TextBox loses the focus")]
	public bool TrimSpaces
	{
		get
		{
			return m_boolTrimSpaces;
		}

		set
		{
			m_boolTrimSpaces = value;
		}

	}
	[Description("Return or Sets whether or not text in the TextBox " + "is higlighted when the TextBox gets focus")]
	public bool Highlight
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
	[Description("Seperator for thousand figures")]
	public bool ThousandsSeparator
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
#region  TextBox Events 
	protected override void OnGotFocus(System.EventArgs e)
	{
		base.OnGotFocus(e);
		if (m_boolHighlight)
		{
				//** Highlight any text and place the cursor at the end of that text
			this.SelectionStart = 0;
			this.SelectionLength = this.Text.Length;
		}
		else
		{
				//** Place the cursor at the end of any text without highlighting
			this.SelectionLength = 0;
			this.SelectionStart = this.Text.Length;
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
	protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
	{
		base.OnKeyPress(e);
		if ((System.Convert.ToInt32(e.KeyChar) == miKEY_BACKACE) || (System.Convert.ToInt32(e.KeyChar) == miKEY_ENTER))
		{
				//Navigation or edit keystroke ... fall through
		}
		else
		{
				//Test all other characters
				switch(m_enmTextStyle)
				{
						//All keystrokes are allowed ... fall through
                    case TextStyleEnum.General:
                        break; 
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

		if ((e.KeyChar >= mtLOWER_A  & e.KeyChar <= mtLOWER_Z ) || (e.KeyChar >= mtUPPER_A  & e.KeyChar <= mtUPPER_Z) || e.KeyChar == mtACE)
		{
				//** The keystroke is allowed ... fall through
		}
		else
		{
				//** The keystroke is not allowed ... dump it
			DumpKeystroke(e);
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
		// Added correct handling of a decimal keystroke
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
		bool sendChar = false;
		char keystroke;

		//** Default to neither a decimal or the space bar
		keystroke = e.KeyChar;
		sendChar = false;

		//** Override the default with a culturally correct decimal or space
		switch(meLastKeystroke)
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
				if (System.Convert.ToInt32(mtSeparator) == 160)
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
        if(keystroke == mtMinus)
        {
          
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
        }
        else if(keystroke == mtDecimal)
        {
                if (m_boolPeriod)
                {
                    if (this.Text.IndexOf(mtDecimal) > -1)
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
                            SendKeys.Send( mtDecimal.ToString ());
                        }
                    }
                }
                else
                {
                    //** A decimal point is not allowed
                    KeyRejected = true;
                }
        }
        else if(keystroke  == mtSeparator)
            {
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
                        SendKeys.Send(mtSeparator.ToString());
                    }
                }
                else
                {
                    //** Thousands separators are not allowed
                    KeyRejected = true;
                }
            }
            else
            {
                //** Check for numbers
                if (e.KeyChar < mtZERO || e.KeyChar > mtNINE)
                {
                    //** The keystroke is not allowed
                    KeyRejected = true;
                }
        }

        if (KeyRejected)
        {
            //** The keystroke is not allowed ... dump it
            DumpKeystroke(e);
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

		if ((e.KeyChar >= mtLOWER_A & e.KeyChar <= mtLOWER_Z) || (e.KeyChar >= mtUPPER_A & e.KeyChar <= mtUPPER_Z) || (e.KeyChar >= mtZERO & e.KeyChar <= mtNINE) || e.KeyChar == mtACE)
		{
				//** The keystroke is allowed ... fall through
		}
		else
		{
				//** The keystroke is not allowed ... dump it
			DumpKeystroke(e);
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

		if ((e.KeyChar >= mtZERO & e.KeyChar <= mtNINE) || e.KeyChar == mtDASH || e.KeyChar == mtLEFT_PAREN || e.KeyChar == mtRIGHT_PAREN || e.KeyChar == mtACE)
		{
				//** The keystroke is allowed ... fall through
		}
		else
		{
				//** The keystroke is not allowed ... dump it
			DumpKeystroke(e);
		}

	}

	private void DumpKeystroke(System.Windows.Forms.KeyPressEventArgs e)
	{
		DumpKeystroke(e, true);
	}

	private void DumpKeystroke(System.Windows.Forms.KeyPressEventArgs e, bool soundBeep)
	{
		e.Handled = true;
		if (soundBeep)
		{
			System.Console.Beep();
		}

	}
	private void FormatText()
	{
		this.Font = new Font(this.Font, FontStyle.Regular);
		this.ForeColor = SystemColors.ControlText;

		switch(TextStyle)
		{
            case TextStyleEnum.General:
				this.TextAlign = HorizontalAlignment.Left;
		        break;
            case TextStyleEnum.Alphabetic:
				this.TextAlign = HorizontalAlignment.Left;
                break;
		    case TextStyleEnum.Accounting:
				this.TextAlign = HorizontalAlignment.Right;
				this.Text = string.Format(this.Text, SoftLogik.Properties.Resources.MoneyFormat);
		        break;
            case TextStyleEnum.Numeric:
		        break;
		    case TextStyleEnum.Phone:
                break;
            case TextStyleEnum.EmailAddress:
				this.TextAlign = HorizontalAlignment.Left;
				if (Validation.IsEmail(this.Text))
				{
                    using (Font newFont = (Font)(this.Font.Clone()))
                    {
					    this.Font = new Font(newFont, FontStyle.Underline);
					    this.ForeColor = SystemColors.HotTrack;
                    }
				}
                break;
	    }
    }
#endregion

}
