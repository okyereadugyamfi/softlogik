Public Class SPPayMode
    Public Shared Function GetPayMode(ByVal PayModeID As Long) As SPDataProxy.SPPayModeDataTable
        Dim data As SPDataProxy.SPPayModeDataTable
        Using dataCmd As New SPDataProxyTableAdapters.taSPPayMode
            data = dataCmd.GetPayMode(PayModeID)
        End Using

        Return data
    End Function
    Public Shared Function GetPayModes() As SPDataProxy.SPPayModeDataTable
        Dim data As SPDataProxy.SPPayModeDataTable
        Using dataCmd As New SPDataProxyTableAdapters.taSPPayMode
            data = dataCmd.GetPayModes()
        End Using

        Return data
    End Function
    Public Shared Function GetEmptyPayMode() As SPDataProxy.SPPayModeDataTable
        Dim data As SPDataProxy.SPPayModeDataTable
        Using dataCmd As New SPDataProxyTableAdapters.taSPPayMode
            data = dataCmd.GetEmptyPayMode()
        End Using

        Return data
    End Function
    Public Shared Function InsertPayMode(ByVal Name As String, ByVal Category As String, ByVal BankId As Long, ByVal Note As String) As Integer
        Dim retval As Integer
        Using dataCmd As New SPDataProxyTableAdapters.taSPPayMode
            retval = dataCmd.Insert(Name, Category, BankID, Note)
        End Using

        Return retval
    End Function
    Public Shared Function UpdatePayMode(ByVal PayModeID As Long, ByVal Name As String, ByVal Category As String, ByVal BankId As Long, ByVal Note As String) As Integer
        Dim retval As Integer
        Using dataCmd As New SPDataProxyTableAdapters.taSPPayMode
            retval = dataCmd.Update(PayModeID, Name, Category, BankId, Note)
        End Using

        Return retval
    End Function
    Public Shared Function DeletePayMode(ByVal PayModeID As Long) As Integer
        Dim retval As Integer
        Using dataCmd As New SPDataProxyTableAdapters.taSPPayMode
            retval = dataCmd.Delete(PayModeID)
        End Using

        Return retval
    End Function

End Class
