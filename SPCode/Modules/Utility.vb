Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Text
Imports System.Collections
Imports System.Xml
Imports System.Xml.Serialization

''' <summary>
''' Summary description for Utility
''' </summary>
Public Class Utility

    Public Shared Function ParseString(ByVal sVal As String, ByVal startTag As String, ByVal EndTag As String) As String
        Dim sIn As String = sVal
        Dim sOut As String = ""
        Dim tagStart As Integer = sIn.ToLower().IndexOf(startTag.ToLower())

        Try
            sIn = sIn.Remove(0, tagStart)
            sIn = sIn.Replace(startTag, "")
            Dim tagEnd As Integer = sIn.ToLower().IndexOf(EndTag.ToLower())

            Dim sName As String = sIn.Substring(0, tagEnd)

            sOut = sName
        Catch
        End Try
        Return sOut
    End Function
  ''' <summary>
  ''' Returns the Xml representation of object-specific data as a string
  ''' </summary>
  ''' <returns></returns>
  Public Shared Function ObjectToXML(ByVal type As Type, ByVal obby As Object) As String
	'Create the serializer
	Dim ser As XmlSerializer = New XmlSerializer(type)
	Using stm As System.IO.MemoryStream = New System.IO.MemoryStream()

	  'serialize to a memory stream
	  ser.Serialize(stm, obby)

	  'reset to beginning so we can read it.  
	  stm.Position = 0
	  'Convert a string. 
	  Using stmReader As System.IO.StreamReader = New System.IO.StreamReader(stm)
		Dim xmlData As String = stmReader.ReadToEnd()
		Return xmlData
	  End Using
	End Using

  End Function

  Public Shared Function XmlToObject(ByVal type As Type, ByVal xml As String) As Object
	Dim oOut As Object = Nothing
        'hydrate based on private string var
        If xml IsNot Nothing Then
            If xml.Length > 0 Then
                Try
                    Dim serializer As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(type)
                    Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
                    sb.Append(xml)
                    Dim sReader As System.IO.StringReader = New System.IO.StringReader(xml)
                    oOut = serializer.Deserialize(sReader)
                    sb = Nothing
                    sReader.Close()
                Catch ex As Exception
                End Try

            End If
        End If

        Return oOut
  End Function
  ''' <summary>
  ''' This method will examine the current URL for use of https. If https:// isn't present, 
  ''' the page will reset itself to the secure url. This does NOT happen for localhost.
  ''' </summary>
    Public Shared Sub TestForSSL()

        'this is the current url 
        Dim currentUrl As System.Uri = System.Web.HttpContext.Current.Request.Url
        'don't redirect if this is localhost
        If (Not currentUrl.IsLoopback) Then
            If (Not currentUrl.Scheme.Equals("https", StringComparison.CurrentCultureIgnoreCase)) Then
                '//show a warning
                '//System.Web.HttpContext.Current.Response.Write("<div style='height:30px; border:1px red solid;background-color:#ffffcc; font-weight:bold'>SSL is NOT enabled for this page which is a critical security issue. Please enable SSL on this page.</div>");
                '//build the secure uri
                Dim secureUrlBuilder As System.UriBuilder = New UriBuilder(currentUrl)
                secureUrlBuilder.Scheme = "https"
                secureUrlBuilder.Port = -1
                'redirect and end the response.  
                System.Web.HttpContext.Current.Response.Redirect(secureUrlBuilder.Uri.ToString(), True)
                'System.Web.HttpContext.Current.Response.Status = "301 Moved Permanently";
                'System.Web.HttpContext.Current.Response.AddHeader("Location", secureUrlBuilder.Uri.ToString());
            End If


        End If
    End Sub

  ''' <summary>
  ''' Returns an SSL-enabled URL
  ''' </summary>
  ''' <returns></returns>
  Public Shared Function GetSecureRoot() As String
	'this is the current url 
	Dim siteUrl As String = Utility.GetSiteRoot()
	If (Not siteUrl.ToLower().StartsWith("https://")) Then
	  siteUrl = siteUrl.Replace("http:", "https:")
	End If
	Return siteUrl
  End Function

  ''' <summary>
  ''' Returns a regular URL
  ''' </summary>
  ''' <returns></returns>
  Public Shared Function GetNonSSLRoot() As String
	'this is the current url 
	Return Utility.GetSiteRoot()

  End Function
  ''' <summary>
  ''' Rewrites an internal url like Product.aspx?id=1 to a nicely formatted URL 
  ''' that can be used for site navigation. These rules are simple; if you want to
  ''' do more complex rewriting, UrlRewriter.NET is a very nice option.
  ''' </summary>
  ''' <param name="pageTo">This is a page where the request is going</param>
  ''' <param name="paramValue">The querystring param value, usually the ID</param>
  ''' <returns></returns>
  Public Shared Function GetRewriterUrl(ByVal pageTo As String, ByVal paramValue As String, ByVal extendedQString As String) As String
	Dim sOut As String = ""
	Try
	  paramValue = paramValue.ToLower().Replace(" ", "")
	  If extendedQString <> String.Empty Then
		extendedQString = "?" & extendedQString
	  End If

	Catch

	End Try
	If pageTo.ToLower().Contains("catalog") Then
	  'for the catalog, the name is passed along as a page
	  sOut = Utility.GetSiteRoot() & "/catalog/" & paramValue & ".aspx" & extendedQString
	ElseIf pageTo.ToLower().Contains("product") Then
	  'for the product, the sku is passed along
	  sOut = Utility.GetSiteRoot() & "/product/" & paramValue & ".aspx" & extendedQString

	End If
	Return sOut
  End Function

  Public Shared Function ParseCamelToProper(ByVal sIn As String) As String

	Dim letters As Char() = sIn.ToCharArray()
	Dim sOut As String = ""
	For Each c As Char In letters
	  If c.ToString() <> c.ToString().ToLower() Then
		'it's uppercase, add a space
		sOut &= " " & c.ToString()
	  Else
		sOut &= c.ToString()

	  End If
	Next c
	Return sOut
  End Function

  Public Shared Function MaskCreditCard(ByVal cardNumber As String) As String
	If String.IsNullOrEmpty(cardNumber) Then
	  Return String.Empty
	End If
	Dim lastFour As String = "XXXX"
	If cardNumber.Length > 4 Then
	  'get the last 4 digits
	  lastFour = cardNumber.Substring(cardNumber.Length - 4, 4)
	Else

	End If
	Dim ccNumReplaced As String = ""
	Dim i As Integer = 0
	Do While i < cardNumber.Length - 4
	  ccNumReplaced &= "X"
		i += 1
	Loop
	ccNumReplaced &= lastFour
	Return ccNumReplaced
  End Function

  Public Shared Function StringToEnum(ByVal t As Type, ByVal Value As String) As Object
	Dim oOut As Object = Nothing
	For Each fi As System.Reflection.FieldInfo In t.GetFields()
	  If fi.Name.ToLower() = Value.ToLower() Then
		oOut = fi.GetValue(Nothing)
	  End If
	Next fi
	Return oOut
  End Function

  Public Shared Function GetRandomString() As String
	Dim builder As StringBuilder = New StringBuilder()
	builder.Append(RandomString(4, False))
	builder.Append(RandomInt(1000, 9999))
	builder.Append(RandomString(2, False))
	Return builder.ToString()
  End Function
  Private Shared Function RandomInt(ByVal min As Integer, ByVal max As Integer) As Integer
	Dim random As Random = New Random()
	Return random.Next(min, max)
  End Function
  Private Shared Function RandomString(ByVal size As Integer, ByVal lowerCase As Boolean) As String
	Dim builder As StringBuilder = New StringBuilder()
	Dim random As Random = New Random()
	Dim ch As Char
	Dim i As Integer = 0
	Do While i < size
	  ch = Convert.ToChar(Convert.ToInt32(26 * random.NextDouble() + 65))
	  builder.Append(ch)
		i += 1
	Loop
	If lowerCase Then
	  Return builder.ToString().ToLower()
	End If
	Return builder.ToString()
  End Function
  Public Shared Function GetSiteRoot() As String
	Dim Port As String = System.Web.HttpContext.Current.Request.ServerVariables("SERVER_PORT")
	If Port Is Nothing OrElse Port = "80" OrElse Port = "443" Then
	  Port = ""
	Else
	  Port = ":" & Port
	End If

	Dim Protocol As String = System.Web.HttpContext.Current.Request.ServerVariables("SERVER_PORT_SECURE")
	If Protocol Is Nothing OrElse Protocol = "0" Then
	  Protocol = "http://"
	Else
	  Protocol = "https://"
	End If

	Dim appPath As String = System.Web.HttpContext.Current.Request.ApplicationPath
	If appPath = "/" Then
	  appPath = ""
	End If

	Dim sOut As String = Protocol & System.Web.HttpContext.Current.Request.ServerVariables("SERVER_NAME") & Port & appPath
	Return sOut
  End Function

  Public Shared Function GetParameter(ByVal sParam As String) As String

	If Not System.Web.HttpContext.Current.Request.QueryString(sParam) Is Nothing Then
	  Return System.Web.HttpContext.Current.Request(sParam).ToString()
	Else
	  Return ""
	End If

    End Function
    Public Shared Function GetUrlFromQueryString(ByVal UrlParam As String) As String
        If Not System.Web.HttpContext.Current.Request.QueryString(UrlParam) Is Nothing Then
            Dim excludeParam As String = System.Web.HttpContext.Current.Request(UrlParam).ToString()
            Dim sbNewQuery As String = excludeParam & "?"
            For Each paramValue As String In System.Web.HttpContext.Current.Request.QueryString
                If paramValue <> excludeParam Then
                    sbNewQuery = String.Concat(sbNewQuery, paramValue, "&")
                End If
            Next
            Return sbNewQuery.TrimEnd("&"c)
        Else
            Return ""
        End If
    End Function
    Public Shared Function GetUrlFromQueryString(ByVal UrlParam As String, ByVal Context As System.Web.HttpContext) As String
        If Not Context.Request.QueryString(UrlParam) Is Nothing Then
            Dim excludeParam As String = Context.Request(UrlParam).ToString()
            Dim sbNewQuery As String = excludeParam & "?"
            For Each paramValue As String In Context.Request.QueryString
                If paramValue <> excludeParam Then
                    sbNewQuery = String.Concat(sbNewQuery, paramValue, "&")
                End If
            Next
            Return sbNewQuery.TrimEnd("&"c)
        Else
            Return ""
        End If
    End Function
    Public Shared Function GetIntParameter(ByVal sParam As String) As Integer
        Dim iOut As Integer = 0
        If Not System.Web.HttpContext.Current.Request.QueryString(sParam) Is Nothing Then
            Dim sOut As String = System.Web.HttpContext.Current.Request(sParam).ToString()
            If (Not String.IsNullOrEmpty(sOut)) Then
                Integer.TryParse(sOut, iOut)
            End If
        End If
        Return iOut
    End Function
    Public Shared Function ShortenText(ByVal sIn As Object, ByVal length As Integer) As String
        Dim sOut As String = sIn.ToString()
        If sOut.Length > length Then
            sOut = sOut.Substring(0, length) & " ..."
        End If
        Return sOut

    End Function
    Public Shared Sub LoadDropDown(ByVal ddl As DropDownList, ByVal collection As ICollection, ByVal textField As String, ByVal valueField As String, ByVal initialSelection As String)
        ddl.DataSource = collection
        ddl.DataTextField = textField
        ddl.DataValueField = valueField
        ddl.DataBind()

        ddl.SelectedValue = initialSelection
    End Sub
    Public Shared Sub LoadListItems(ByVal list As System.Web.UI.WebControls.ListItemCollection, ByVal tblBind As DataTable, ByVal tblVals As DataTable, ByVal textField As String, ByVal valField As String)
        Dim l As ListItem
        Dim i As Integer = 0
        Do While i < tblBind.Rows.Count
            l = New ListItem(tblBind.Rows(i)(textField).ToString(), tblBind.Rows(i)(valField).ToString())

            Dim dr As DataRow
            Dim x As Integer = 0
            Do While x < tblVals.Rows.Count
                dr = tblVals.Rows(x)
                If dr(valField).ToString().ToLower().Equals(l.Value.ToLower()) Then
                    l.Selected = True
                End If
                x += 1
            Loop
            list.Add(l)
            i += 1
        Loop


    End Sub
    Public Shared Sub LoadListItems(ByVal list As System.Web.UI.WebControls.ListItemCollection, ByVal rdr As IDataReader, ByVal textField As String, ByVal valField As String, ByVal selectedValue As String, ByVal closeReader As Boolean)
        Dim l As ListItem
        Dim sText As String = ""
        Dim sVal As String = ""
        list.Clear()

        Do While rdr.Read()

            sText = rdr(textField).ToString()
            sVal = rdr(valField).ToString()

            l = New ListItem(sText, sVal)
            If selectedValue <> String.Empty Then
                If selectedValue.ToLower() = sVal.ToLower() Then
                    l.Selected = True
                End If
            End If
            list.Add(l)
        Loop
        If closeReader Then
            rdr.Close()
        End If

    End Sub



    Public Shared Function GetFileText(ByVal virtualPath As String) As String
        'Read from file
        Dim sr As StreamReader = Nothing
        Try
            sr = New StreamReader(System.Web.HttpContext.Current.Server.MapPath(virtualPath))
        Catch
            sr = New StreamReader(virtualPath)

        End Try
        Dim strOut As String = sr.ReadToEnd()
        sr.Close()
        Return strOut
    End Function
    ''' <summary>
    ''' Updates the text in a file with the passed in values
    ''' </summary>
    ''' <param name="AbsoluteFilePath"></param>
    ''' <param name="LookFor"></param>
    ''' <param name="ReplaceWith"></param>
    Public Shared Sub UpdateFileText(ByVal AbsoluteFilePath As String, ByVal LookFor As String, ByVal ReplaceWith As String)
        Dim sIn As String = GetFileText(AbsoluteFilePath)
        Dim sOut As String = sIn.Replace(LookFor, ReplaceWith)
        WriteToFile(AbsoluteFilePath, sOut)
    End Sub
    ''' <summary>
    ''' Writes out a file
    ''' </summary>
    ''' <param name="AbsoluteFilePath"></param>
    ''' <param name="fileText"></param>
    Public Shared Sub WriteToFile(ByVal AbsoluteFilePath As String, ByVal fileText As String)
        Dim sw As StreamWriter = New StreamWriter(AbsoluteFilePath, False)
        sw.Write(fileText)
        sw.Close()

    End Sub
    Public Shared Sub SetListSelection(ByVal lc As System.Web.UI.WebControls.ListItemCollection, ByVal Selection As String)

        Dim i As Integer = 0
        Do While i < lc.Count
            If lc(i).Value = Selection Then
                lc(i).Selected = True
                Exit Do
            End If

            i += 1
        Loop
    End Sub


    Public Shared Function GetUserName() As String

        Dim sUserName As String = ""
        If HttpContext.Current.User.Identity.IsAuthenticated Then
            sUserName = HttpContext.Current.User.Identity.Name
        Else

            'we'll tag them with an anon userName until they register
            If Not HttpContext.Current.Request.Cookies("shopperID") Is Nothing Then
                sUserName = HttpContext.Current.Request.Cookies("shopperID").Value
            Else

                'if we have never seen them, return the current anonymous ID for the user
                sUserName = HttpContext.Current.Profile.UserName
            End If
        End If
        HttpContext.Current.Response.Cookies("shopperID").Value = sUserName
        HttpContext.Current.Response.Cookies("shopperID").Expires = DateTime.Today.AddDays(365)
        Return sUserName
    End Function

#Region "Formatting bits"
#Region "IsNullOrEmpty"

    Public Shared Function IsNullOrEmpty(ByVal text As String) As Boolean
        If text Is Nothing OrElse (Not text Is Nothing AndAlso text.Length = 0) Then
            Return True
        End If

        Return False
    End Function

#End Region

#Region "CheckStringLength"

    Public Shared Function CheckStringLength(ByVal stringToCheck As String, ByVal maxLength As Integer) As String
        Dim checkedString As String = Nothing

        If stringToCheck.Length <= maxLength Then
            Return stringToCheck
        End If

        ' If the string to check is longer than maxLength 
        ' and has no whitespace we need to trim it down.
        If (stringToCheck.Length > maxLength) AndAlso (stringToCheck.IndexOf(" ") = -1) Then
            checkedString = stringToCheck.Substring(0, maxLength) & "..."
        ElseIf stringToCheck.Length > 0 Then
            Dim words As String()
            Dim expectedWhitespace As Integer = CType(stringToCheck.Length / 8, Integer)

            ' How much whitespace is there?
            words = stringToCheck.Split(" "c)

            checkedString = stringToCheck.Substring(0, maxLength) & "..."
        Else
            checkedString = stringToCheck
        End If

        Return checkedString
    End Function

#End Region

#Region "FormatDate"

    Public Shared Function FormatDate(ByVal theDate As DateTime) As String
        Return FormatDate(theDate, False, Nothing)
    End Function

    Public Shared Function FormatDate(ByVal theDate As DateTime, ByVal showTime As Boolean) As String
        Return FormatDate(theDate, showTime, Nothing)
    End Function

    Public Shared Function FormatDate(ByVal theDate As DateTime, ByVal showTime As Boolean, ByVal pattern As String) As String
        Dim defaultDatePattern As String = "MMMM d, yyyy"
        Dim defaultTimePattern As String = "hh:mm tt"

        If pattern Is Nothing Then
            If showTime Then
                pattern = defaultDatePattern & " " & defaultTimePattern
            Else
                pattern = defaultDatePattern
            End If
        End If

        Return theDate.ToString(pattern)
    End Function

#End Region

#Region "UserIsAuthenticated"

    Public Shared Function UserIsAuthenticated() As Boolean
        Dim context As HttpContext = HttpContext.Current

        If Not context.User Is Nothing AndAlso Not context.User.Identity Is Nothing AndAlso (Not Utility.IsNullOrEmpty(context.User.Identity.Name)) Then
            Return True
        End If

        Return False
    End Function

#End Region

#Region "StripHTML"

    Public Shared Function StripHTML(ByVal htmlString As String) As String
        Return StripHTML(htmlString, "", True)
    End Function

    Public Shared Function StripHTML(ByVal htmlString As String, ByVal htmlPlaceHolder As String) As String
        Return StripHTML(htmlString, htmlPlaceHolder, True)
    End Function

    Public Shared Function StripHTML(ByVal htmlString As String, ByVal htmlPlaceHolder As String, ByVal stripExcessSpaces As Boolean) As String
        Dim pattern As String = "<(.|\n)*?>"
        Dim sOut As String = System.Text.RegularExpressions.Regex.Replace(htmlString, pattern, htmlPlaceHolder)
        sOut = sOut.Replace("&nbsp;", "")
        sOut = sOut.Replace("&amp;", "&")

        If stripExcessSpaces Then
            ' If there is excess whitespace, this will remove
            ' like "THE      WORD".
            Dim delim As Char() = {" "c}
            Dim lines As String() = sOut.Split(delim, StringSplitOptions.RemoveEmptyEntries)

            sOut = ""
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            For Each s As String In lines
                sb.Append(s)
                sb.Append(" ")
            Next s
            Return sb.ToString().Trim()
        Else
            Return sOut
        End If

    End Function

#End Region

#Region "ToggleHtmlBR"

    Public Shared Function ToggleHtmlBR(ByVal text As String, ByVal isOn As Boolean) As String
        Dim outS As String = ""

        If isOn Then
            outS = text.Replace(Constants.vbLf, "<br />")
        Else
            ' TODO: do this with via regex
            '
            outS = text.Replace("<br />", Constants.vbLf)
            outS = text.Replace("<br>", Constants.vbLf)
            outS = text.Replace("<br >", Constants.vbLf)
        End If

        Return outS
    End Function

#End Region

#End Region

End Class
