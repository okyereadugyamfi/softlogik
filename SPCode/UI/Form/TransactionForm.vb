Namespace UI
    Public Class TransactionForm

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            If Not DesignMode Then
                OnNewRecord()
            End If
        End Sub
    End Class
End Namespace
