
''' <summary>
''' Type of File Parsing
''' </summary>
Public Enum FileParseEnum
    ParseFileOnly
    ParsePathOnly
    ParseDriveOnly
    ParseExtensionOnly
End Enum

    Module FileSupport

        Public Function ParsePath(ByVal strPath As String, _
    ByVal lngPart As FileParseEnum) As String
            ' This procedure takes a file path and returns
            ' either the path, file, drive, or file extension portion,
            ' depending on which constant was passed in.

            Dim lngPos As Integer
            Dim strPart As String = vbNullString
            Dim blnIncludesFile As Boolean

            ' Check that this is a file path.
            ' Find the last path separator.
            lngPos = InStrRev(strPath, "\")
            ' Determine whether portion of string after last backslash
            ' contains a period.
            blnIncludesFile = InStrRev(strPath, ".") > lngPos

            If lngPos > 0 Then
                Select Case lngPart
                    ' Return file name.
                    Case FileParseEnum.ParseFileOnly
                        If blnIncludesFile Then
                            strPart = Right$(strPath, Len(strPath) - lngPos)
                        Else
                            strPart = ""
                        End If
                        ' Return path.
                    Case FileParseEnum.ParsePathOnly
                        If blnIncludesFile Then
                            strPart = Left$(strPath, lngPos)
                        Else
                            strPart = strPath
                        End If
                        ' Return drive.
                    Case FileParseEnum.ParseDriveOnly
                        strPart = Left$(strPath, 3)
                        ' Return file extension.
                    Case FileParseEnum.ParseExtensionOnly
                        If blnIncludesFile Then
                            ' Take three characters after period.
                            strPart = Mid(strPath, InStrRev(strPath, ".") + 1, 3)
                        Else
                            strPart = ""
                        End If
                    Case Else
                        strPart = ""
                End Select
            End If
            ParsePath = strPart

ParsePath_End:
            Exit Function

        End Function

    End Module

