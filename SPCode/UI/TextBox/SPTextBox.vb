Imports System.ComponentModel
Imports System.Globalization
Imports System.Threading

Namespace UI
    Public Class SPTextBox

#Region "Enumerations"
        Public Enum TextStyleEnum
            General
            Numeric
            Alphabetic
            Accounting
            EmailAddress
            Phone
        End Enum
#End Region
#Region "Members"
        Private m_enmTextStyle As TextStyleEnum
        Private m_strFormatString As String
        Private m_boolMinusSign As Boolean
        Private m_boolPeriod As Boolean
        Private m_boolTrimSpaces As Boolean

        '** Storage for property settings
        Private m_boolHighlight As Boolean
        Private m_boolThousandsSeparator As Boolean

        '** Locale aware keystrokes
        Private mtDecimal As String
        Private mtMinus As String
        Private mtSeparator As String

        '** String Constants
        Private Const mtLOWER_A As String = "a"
        Private Const mtUPPER_A As String = "A"
        Private Const mtLOWER_Z As String = "z"
        Private Const mtUPPER_Z As String = "Z"
        Private Const mtZERO As String = "0"
        Private Const mtNINE As String = "9"
        Private Const mtDASH As String = "-"
        Private Const mtLEFT_PAREN As String = "("
        Private Const mtRIGHT_PAREN As String = ")"
        Private Const mtSPACE As String = " "

        '** Integer Constants
        Private Const miKEY_BACKSPACE As Integer = 8
        Private Const miKEY_ENTER As Integer = 13

        '** Flow control and cultural sensitivity
        Private mbIgnoreKeystroke As Boolean = False
        Private meLastKeystroke As KeyPressed


        Private Enum KeyPressed
            NumberPadDecimal = 0
            SpaceBar = 1
            NothingSpecial = 2
        End Enum
#End Region
#Region "Constructor"
        Public Sub New()
            '---------------------------------------------------------------------------------
            ' Default settings for boolean properties
            '---------------------------------------------------------------------------------
            m_boolPeriod = True
            m_boolHighlight = True
            m_boolMinusSign = True
            m_boolThousandsSeparator = True
            m_boolTrimSpaces = False

            '---------------------------------------------------------------------------------
            ' Set the characters to be used for the locale aware minus sign, thousands 
            ' separator and decimal point
            '---------------------------------------------------------------------------------
            Dim ci As New CultureInfo(Thread.CurrentThread.CurrentCulture.ToString)
            With ci.NumberFormat
                mtDecimal = .NumberDecimalSeparator
                mtSeparator = .NumberGroupSeparator
                mtMinus = .NegativeSign
            End With
            ci = Nothing

        End Sub
#End Region
#Region "Public Properties"
        <Description("Returns or Sets the Style of Text in the TextBox")> _
        Public Property TextStyle() As TextStyleEnum
            Get
                Return m_enmTextStyle
            End Get
            Set(ByVal value As TextStyleEnum)
                m_enmTextStyle = value
            End Set
        End Property
        <Description("Returns or Sets the Formatting String of the TextBox")> _
        Public Property FormatString() As String
            Get
                Return m_strFormatString
            End Get
            Set(ByVal value As String)
                m_strFormatString = value
            End Set
        End Property
        <Description("Returns or Sets whether or not a minus sign is " & _
                     "accepted in the first character position when the" & _
                     " TextStyle property is set to Numeric")> _
        Public Property MinusSign() As Boolean
            Get
                Return m_boolMinusSign
            End Get
            Set(ByVal value As Boolean)
                m_boolMinusSign = value
            End Set
        End Property
        <Description("Returns or Sets whether or not a period is " & _
                     "accepted in the TextBox when the " & _
                     " TextStyle property is set to Numeric")> _
        Public Property Period() As Boolean
            Get
                Return m_boolPeriod
            End Get
            Set(ByVal value As Boolean)
                m_boolPeriod = value
            End Set
        End Property
        <Description("Return or Sets whether or not leading and trailing " & _
                  "spaces are removed from the Text when the TextBox loses the focus")> _
     Public Property TrimSpaces() As Boolean
            Get
                TrimSpaces = m_boolTrimSpaces
            End Get

            Set(ByVal Value As Boolean)
                m_boolTrimSpaces = Value
            End Set

        End Property
        <Description("Return or Sets whether or not text in the TextBox " & _
                  "is higlighted when the TextBox gets focus")> _
        Public Property Highlight() As Boolean
            Get
                Return m_boolHighlight
            End Get
            Set(ByVal value As Boolean)
                m_boolHighlight = value
            End Set
        End Property
        <Description("")> _
        Public Property ThousandsSeparator() As Boolean
            Get
                Return m_boolThousandsSeparator
            End Get
            Set(ByVal value As Boolean)
                m_boolThousandsSeparator = value
            End Set
        End Property
#End Region
#Region " SPTextBox Events "
        Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
            MyBase.OnGotFocus(e)
            With Me
                If m_boolHighlight Then
                    '** Highlight any text and place the cursor at the end of that text
                    .SelectionStart = 0
                    .SelectionLength = .Text.Length
                Else
                    '** Place the cursor at the end of any text without highlighting
                    .SelectionLength = 0
                    .SelectionStart = .Text.Length
                End If
            End With

        End Sub
        Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
            MyBase.OnKeyDown(e)
            '---------------------------------------------------------------------------------
            ' Detect when the decimal point on the keypad, or the space bar is pressed
            '---------------------------------------------------------------------------------
            Select Case e.KeyCode.ToString.ToLower
                Case "decimal" : meLastKeystroke = KeyPressed.NumberPadDecimal
                Case "space" : meLastKeystroke = KeyPressed.SpaceBar
                Case Else : meLastKeystroke = KeyPressed.NothingSpecial
            End Select

        End Sub
        Protected Overrides Sub OnKeypress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
            MyBase.OnKeyPress(e)
            Select Case Asc(e.KeyChar)
                Case miKEY_BACKSPACE, _
                     miKEY_ENTER
                    'Navigation or edit keystroke ... fall through
                Case Else
                    'Test all other characters
                    Select Case m_enmTextStyle
                        Case TextStyleEnum.General
                            'All keystrokes are allowed ... fall through
                        Case TextStyleEnum.Alphabetic
                            AllowLettersOnly(e)
                        Case TextStyleEnum.Numeric, TextStyleEnum.Accounting
                            AllowNumbersOnly(e)
                        Case TextStyleEnum.Phone
                            AllowPhoneChar(e)
                    End Select
            End Select

        End Sub
        Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
            MyBase.OnLeave(e)
            If m_boolTrimSpaces Then
                'Remove all leading and trailing spaces from the text
                Me.Text = Me.Text.Trim
            End If

        End Sub
        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
            MyBase.OnTextChanged(e)

            FormatText()
        End Sub
#End Region
#Region " Procedures "
        Private Sub AllowLettersOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs)
            '---------------------------------------------------------------------------------
            ' Accept a-z, A-Z, and space
            '---------------------------------------------------------------------------------
            '     Date          Developer                      Comments          
            '  ---------- -------------------- -----------------------------------------------
            '  09/12/2005 G Gilbert            Original code
            '---------------------------------------------------------------------------------

            With e
                If (.KeyChar >= mtLOWER_A And .KeyChar <= mtLOWER_Z) _
                OrElse (.KeyChar >= mtUPPER_A And .KeyChar <= mtUPPER_Z) _
                OrElse .KeyChar = mtSPACE Then
                    '** The keystroke is allowed ... fall through
                Else
                    '** The keystroke is not allowed ... dump it
                    DumpKeystroke(e)
                End If
            End With

        End Sub
        Private Sub AllowNumbersOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs)
            '---------------------------------------------------------------------------------
            ' Accept 0-9 plus allowed number related special characters (minus sign, decimal
            ' point, thousands separator)
            '---------------------------------------------------------------------------------
            '     Date          Developer                      Comments          
            '  ---------- -------------------- -----------------------------------------------
            '  09/12/2005 G Gilbert            Original code
            '  04/27/2006 G Gilbert            Added correct handling of a decimal keystroke
            '                                       on the number pad when the decimal is
            '                                       something other than a period; and the
            '                                       space bar when the thousands separator
            '                                       is a space
            '---------------------------------------------------------------------------------

            '---------------------------------------------------------------------------------
            ' If a substitute keystroke was sent below, ignore it
            '---------------------------------------------------------------------------------
            If mbIgnoreKeystroke Then
                mbIgnoreKeystroke = False
                Exit Sub
            End If

            '---------------------------------------------------------------------------------
            ' When the decimal point on the number pad is pressed, ensure the keystroke
            ' is interpreted correctly per the region settings. Also ensure that the space
            ' bar can be used for a thousands separator when called for by the region setting.
            '---------------------------------------------------------------------------------
            Dim sendChar As Boolean
            Dim keystroke As String

            '** Default to neither a decimal or the space bar
            keystroke = e.KeyChar
            sendChar = False

            '** Override the default with a culturally correct decimal or space
            Select Case meLastKeystroke
                Case KeyPressed.NumberPadDecimal
                    '** Convert the number pad decimal point to the culturally correct
                    '** character
                    keystroke = mtDecimal
                    sendChar = True
                Case KeyPressed.SpaceBar
                    '** When the thousands separator is a space, convert the space bar
                    '** character (ASCII 32) to the culturally correct character (ASCII 160)
                    If Asc(mtSeparator) = 160 Then
                        keystroke = mtSeparator
                        sendChar = True
                    End If
            End Select

            '---------------------------------------------------------------------------------
            ' Determine whether or not the keystroke can be accepted
            '---------------------------------------------------------------------------------
            Dim KeyRejected As Boolean = False
            Select Case keystroke

                Case mtMinus
                    If m_boolMinusSign Then
                        '** The insertion cursor must be at the start of the text
                        If Me.SelectionStart > 0 Then
                            '** The minus sign would not be the first character
                            KeyRejected = True
                        End If
                    Else
                        '** A minus sign is not allowed
                        KeyRejected = True
                    End If

                Case mtDecimal
                    If m_boolPeriod Then
                        If Me.Text.IndexOf(CType(mtDecimal, Char)) > -1 Then
                            '** Only one decimal point is permitted
                            KeyRejected = True
                        Else
                            '** This is the first decimal point entered. Check if
                            '** the character is to be changed to the one that 
                            '** agrees with the region setting.
                            If sendChar Then
                                '** Dump the keystroke entered by the user
                                DumpKeystroke(e, False)
                                '** Prevent this Sub from processing the keystroke
                                '** being substituted
                                mbIgnoreKeystroke = True
                                '** Send the culturally correct substitute character
                                SendKeys.Send(mtDecimal)
                            End If
                        End If
                    Else
                        '** A decimal point is not allowed
                        KeyRejected = True
                    End If

                Case mtSeparator
                    If m_boolThousandsSeparator Then
                        '** Check if the character is to be changed to the one 
                        '** that agrees with the region setting
                        If sendChar Then
                            '** Dump the keystroke entered by the user
                            DumpKeystroke(e, False)
                            '** Prevent this Sub from processing the keystroke
                            '** being substituted
                            mbIgnoreKeystroke = True
                            '** Send the culturally correct substitute character
                            SendKeys.Send(mtSeparator)
                        End If
                    Else
                        '** Thousands separators are not allowed
                        KeyRejected = True
                    End If

                Case Else
                    '** Check for numbers
                    If e.KeyChar < mtZERO _
                    OrElse e.KeyChar > mtNINE Then
                        '** The keystroke is not allowed
                        KeyRejected = True
                    End If

            End Select

            If KeyRejected Then
                '** The keystroke is not allowed ... dump it
                DumpKeystroke(e)
            End If

        End Sub
        Private Sub AllowNoSpecialChar(ByVal e As System.Windows.Forms.KeyPressEventArgs)
            '---------------------------------------------------------------------------------
            ' Accept a-z, A-Z, 0-9, and space
            '---------------------------------------------------------------------------------
            '     Date          Developer                      Comments          
            '  ---------- -------------------- -----------------------------------------------
            '  09/12/2005 G Gilbert            Original code
            '---------------------------------------------------------------------------------

            With e
                If (.KeyChar >= mtLOWER_A And .KeyChar <= mtLOWER_Z) _
                OrElse (.KeyChar >= mtUPPER_A And .KeyChar <= mtUPPER_Z) _
                OrElse (.KeyChar >= mtZERO And .KeyChar <= mtNINE) _
                OrElse .KeyChar = mtSPACE Then
                    '** The keystroke is allowed ... fall through
                Else
                    '** The keystroke is not allowed ... dump it
                    DumpKeystroke(e)
                End If
            End With

        End Sub
        Private Sub AllowPhoneChar(ByVal e As System.Windows.Forms.KeyPressEventArgs)
            '---------------------------------------------------------------------------------
            ' Allow 0-9, -, (), and space
            '---------------------------------------------------------------------------------
            '     Date          Developer                      Comments          
            '  ---------- -------------------- -----------------------------------------------
            '  09/12/2005 G Gilbert            Original code
            '---------------------------------------------------------------------------------

            With e
                If (.KeyChar >= mtZERO And .KeyChar <= mtNINE) _
                OrElse .KeyChar = mtDASH _
                OrElse .KeyChar = mtLEFT_PAREN _
                OrElse .KeyChar = mtRIGHT_PAREN _
                OrElse .KeyChar = mtSPACE Then
                    '** The keystroke is allowed ... fall through
                Else
                    '** The keystroke is not allowed ... dump it
                    DumpKeystroke(e)
                End If
            End With

        End Sub
        Private Sub DumpKeystroke(ByVal e As System.Windows.Forms.KeyPressEventArgs, _
                                  Optional ByVal soundBeep As Boolean = True)
            e.Handled = True
            If soundBeep Then
                Beep()
            End If

        End Sub
        Private Sub FormatText()
            Me.Font = New Font(Me.Font, FontStyle.Regular)
            Me.ForeColor = SystemColors.ControlText

            Select Case TextStyle
                Case TextStyleEnum.General
                    Me.TextAlign = HorizontalAlignment.Left
                Case TextStyleEnum.Alphabetic
                    Me.TextAlign = HorizontalAlignment.Left
                Case TextStyleEnum.Accounting
                    Me.TextAlign = HorizontalAlignment.Right
                    Me.Text = Format(Me.Text, My.Settings.MoneyFormat)
                Case TextStyleEnum.Numeric
                Case TextStyleEnum.Phone
                Case TextStyleEnum.EmailAddress
                    Me.TextAlign = HorizontalAlignment.Left
                    If IsValidEmail(Me.Text) Then
                        Dim newFont As Font = CType(Me.Font.Clone, Font)
                        Me.Font = New Font(newFont, FontStyle.Underline)
                        Me.ForeColor = SystemColors.HotTrack
                        newFont.Dispose()
                    End If
                Case Else

            End Select
        End Sub
#End Region

    End Class
End Namespace

