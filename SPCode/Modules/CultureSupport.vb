
Imports System.Text.RegularExpressions


Module CultureSupport

    Public Enum TextReturnTypeEnum
        PureString
        RawString
    End Enum

    Private m_dctLanguageDictionary As Hashtable

    Public Property LanguageDictionary() As System.Collections.Hashtable
        Get
            Return m_dctLanguageDictionary
        End Get
        Set(ByVal Value As System.Collections.Hashtable)
            m_dctLanguageDictionary = Value
        End Set
    End Property
    Public Function TextDictionary(ByVal TextID As String, Optional ByRef ParseType As TextReturnTypeEnum = TextReturnTypeEnum.PureString) As String
        Try
            Select Case ParseType
                Case TextReturnTypeEnum.PureString
                    Return DeleteChar(CStr(LanguageDictionary(TextID.Trim)))
                Case TextReturnTypeEnum.RawString
                    Return CStr(LanguageDictionary(TextID.Trim))
            End Select
        Catch ex As Exception

        End Try

        Return vbNullString
    End Function
End Module

Module DateSupport
    Public Function DateCheck(ByRef strValue As String) As Boolean
        DateCheck = True ' Assume True
        If strValue <> "" Then
            If Not IsDate(strValue) Then
                Return False
            End If
        End If
    End Function

End Module

Module StringSupport
    Public Function Substitute(ByRef sString As String, ByRef sFind As String, ByRef sReplace As String) As String
        ' Substitutes string sReplace in place of string sFind in sString
        Dim lEnd, lStart, lFindLength As Integer
        Dim sNewString As String

1:      sNewString = ""
2:      lFindLength = Len(sFind)
3:      lStart = 1
4:      lEnd = InStr(lStart, sString, sFind)
5:      Do While lEnd > 0
6:          sNewString = sNewString & Mid(sString, lStart, lEnd - lStart) & sReplace
7:          lStart = lEnd + lFindLength
8:          lEnd = InStr(lStart, sString, sFind)
9:      Loop
10:     Substitute = sNewString & Mid(sString, lStart)
    End Function
    Public Function RemoveAmpersands(ByRef strString As String) As String
        ' Removes the ampersands in the specified string.
1:      RemoveAmpersands = Substitute(strString, "&", "")
    End Function
    Public Function NullTruncate(ByVal strText As String) As String
        ' Returns the specified string truncated at the first null character
        Dim lLen As Integer

1:      lLen = InStr(strText, Chr(0))
2:      If lLen < 1 Then
3:          Return strText
4:      Else
5:          Return Left(strText, lLen - 1)
6:      End If
    End Function
    Public Function ResolveResString(ByVal resID As Short, ByVal ParamArray varReplacements() As Object) As String
        '-----------------------------------------------------------
        ' FUNCTION: ResolveResString
        ' Reads resource and replaces given macros with given values
        '
        ' Example, given a resource number 14:
        '    "Could not read '|1' in drive |2"
        '   The call
        '     ResolveResString(14, "|1", "TXTFILE.TXT", "|2", "A:")
        '   would return the string
        '     "Could not read 'TXTFILE.TXT' in drive A:"
        '
        ' IN: [resID] - resource identifier
        '     [varReplacements] - pairs of macro/replacement value
        '-----------------------------------------------------------
        '
        Dim intMacro As Integer
        Dim strResString As String = vbNullString

1:      'strResString = VB6.LoadResString(resID)

        ' For each macro/value pair passed in...
2:      Dim strMacro As String
        Dim strValue As String
        Dim intPos As Integer
        For intMacro = 0 To varReplacements.Length Step 2

3:          'UPGRADE_WARNING: Couldn't resolve default property of object varReplacements(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            strMacro = varReplacements(intMacro).ToString
4:          On Error GoTo MismatchedPairs
5:          'UPGRADE_WARNING: Couldn't resolve default property of object varReplacements(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            strValue = varReplacements(intMacro + 1).ToString
6:          On Error GoTo 0

            ' Replace all occurrences of strMacro with strValue
7:          Do
8:              intPos = InStr(strResString, strMacro)
9:              If intPos > 0 Then
10:                 strResString = Left(strResString, intPos - 1) & strValue & Right(strResString, Len(strResString) - Len(strMacro) - intPos + 1)
11:             End If
12:         Loop Until intPos = 0
13:     Next intMacro

14:     ResolveResString = strResString

15:     Exit Function

MismatchedPairs:
16:     Resume Next
    End Function
    Public Function DeleteChar(ByVal SourceString As String, Optional ByVal SourceCharacters As String = "&,:") As String
        '-------------------------------------------------------------------------------
        '
        ' DeleteChar - Function to delete a specified char in a passed string
        '              The characters might be separated by a comma ','
        '
        ' Parameters:
        '    srField2String - I:   (String) holds the string to be processed
        '    srcChar   - I:   (String)holds the characters to remove from string
        '
        ' Returns:
        '   String
        '
        ' Comments:
        '   None.
        '
        '-------------------------------------------------------------------------------

        Const PkComma As String = ","

        Dim astrSource() As String
        Dim finalString As String
        Dim asrcSplitChar() As String

        If SourceString = vbNullString Then
            DeleteChar = vbNullString
            Exit Function
        End If

        'Extract the characters to delete from source string
        asrcSplitChar = Split(SourceCharacters, PkComma, , CompareMethod.Binary)

        'Exit if no characters to delete
        If asrcSplitChar.Length = 0 Then
            DeleteChar = SourceString
            Exit Function
        End If

        finalString = SourceString
        'Loop through the characters and delete each from source string
        For Each strChar As String In asrcSplitChar
            astrSource = Split(finalString, strChar, , CompareMethod.Binary)
            finalString = Join(astrSource, vbNullString)
        Next


        DeleteChar = finalString
    End Function

    Public Function ValidateEmail(ByVal Expression As String) As Boolean
        Dim arrstrEmail() As String
        Dim idOk As Boolean

        Try
            arrstrEmail = Split(Expression, "@")
            If arrstrEmail.Length > 0 Then
                idOk = (arrstrEmail(arrstrEmail.Length) Like "*.*") And _
                (arrstrEmail(0) <> vbNullString) And _
                (Len(arrstrEmail(UBound(arrstrEmail))) > 3)
            End If
        Catch ex As Exception

        End Try
        Return idOk
    End Function

    Public Function IsAlphabet(ByVal strExp As String) As Boolean
        Return Regex.IsMatch(strExp, "^[a-zA-Z]+$")
    End Function

    Public Function IsValidEmail(ByVal strExp As String) As Boolean
        Return Regex.IsMatch(strExp, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")
    End Function

    Public Function IsValidTime(ByVal strExp As String) As Boolean
        Return Regex.IsMatch(strExp, "(([01]+[\d]+)/(2[0-3])):[0-5]+[0-9]+")
    End Function

End Module

