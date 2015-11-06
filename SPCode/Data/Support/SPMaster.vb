Public Class SPMaster


    Public Shared Function GetMasterDetail(ByVal MasterID As Long) As SPDataProxy.SPMasterDataTable
        Dim data As SPDataProxy.SPMasterDataTable
        Using dataCmd As New SPDataProxyTableAdapters.taSPMaster
            data = dataCmd.GetMaster(MasterID)
        End Using

        Return data
    End Function

    Public Shared Function GetMaster(ByVal TypeID As String) As SPDataProxy.SPMasterDataTable
        Dim data As SPDataProxy.SPMasterDataTable
        Using dataCmd As New SPDataProxyTableAdapters.taSPMaster
            data = dataCmd.GetMasterLookup(TypeID)
        End Using

        Return data
    End Function
    Public Shared Function GetEmptyMaster(ByVal TypeID As String) As SPDataProxy.SPMasterDataTable
        Dim data As SPDataProxy.SPMasterDataTable
        Using dataCmd As New SPDataProxyTableAdapters.taSPMaster
            data = dataCmd.GetEmptyMaster(TypeID)
        End Using

        Return data
    End Function
    Public Shared Function InsertMaster(ByVal Name As String, ByVal Note As String, ByVal TypeID As String) As Integer
        Dim retval As Integer
        Using dataCmd As New SPDataProxyTableAdapters.taSPMaster
            retval = dataCmd.Insert(Name, Note, TypeID)
        End Using

        Return retval
    End Function
    Public Shared Function UpdateMaster(ByVal MasterID As Long, ByVal Name As String, ByVal Note As String) As Integer
        Dim retval As Integer
        Using dataCmd As New SPDataProxyTableAdapters.taSPMaster
            retval = dataCmd.Update(MasterID, Name, Note)
        End Using

        Return retval
    End Function
    Public Shared Function DeleteMaster(ByVal MasterID As Long) As Integer
        Dim retval As Integer
        Using dataCmd As New SPDataProxyTableAdapters.taSPMaster
            retval = dataCmd.Delete(MasterID)
        End Using

        Return retval
    End Function

End Class
