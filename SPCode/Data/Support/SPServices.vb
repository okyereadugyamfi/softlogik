Imports SoftLogik.Win.SPDataProxy
Imports SoftLogik.Win.SPDataProxyTableAdapters

Public Class SPServices

    Public Shared Function GenerateAutoID(ByVal Prefix As String) As String
        Dim data As SPAutoIdDataTable, retData As SPAutoIdRow
        Using dataCmd As New taSPAutoId
            data = dataCmd.GetAutoID(Prefix, Now)
        End Using
        retData = CType(data.Rows(0), SPAutoIdRow)
        Return retData.NewID
    End Function

End Class
