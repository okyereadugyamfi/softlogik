
Namespace UI
    Public Class SPFileDialog

        Public Enum FileDialogTypes As Integer
            General = 0
            Picture
            OfficeDocument
            Video
            Audio

        End Enum

        Public Shared Function ShowDialog(ByVal FileType As FileDialogTypes) As String

            Try
                Using myFileDialog As New OpenFileDialog
                    With myFileDialog
                        .Filter = GetFilters(FileType)
                        If .ShowDialog() = DialogResult.OK Then
                            Return .FileName
                        End If
                    End With

                End Using

            Catch ex As Exception
            End Try
            Return Nothing
        End Function
        Public Shared Function ShowMultiDialog(ByVal FileType As FileDialogTypes) As String()

            Try
                Using myFileDialog As New OpenFileDialog
                    With myFileDialog
                        If .ShowDialog() = DialogResult.OK Then
                            Return .FileNames
                        End If
                    End With

                End Using

            Catch ex As Exception
            End Try
            Return Nothing
        End Function

        Private Shared Function GetFilters(ByVal filetype As FileDialogTypes) As String
            Select Case filetype
                Case FileDialogTypes.Picture
                    Return "All Picture Files(*.jpeg,*.jpe,*.jpg,*.gif,*.png,*.bmp,*.wmf,*.ico)|*.jpeg;*.jpe;*.jpg;*.gif;*.png;*.bmp;*.wmf;*.ico|JPEG Files(*.jpg,*.jpe,*.jpeg)|*.jpg;*.jpe;*.jpeg"
                Case Else
                    Return "All Files(*.*)|*.*"
            End Select

            Return Nothing
        End Function
    End Class
End Namespace

