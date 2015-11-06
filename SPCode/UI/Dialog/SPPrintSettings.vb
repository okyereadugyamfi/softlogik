Namespace UI
    Public Class SPPrintSettings


    End Class
    Public Module PrintSupport

        Private m_PrintSettings As SPPrintSettings = New SPPrintSettings

        Public Function ChoosePrinter() As Boolean
            m_PrintSettings.MyPrintDialog.ShowDialog()
        End Function
    End Module
End Namespace





