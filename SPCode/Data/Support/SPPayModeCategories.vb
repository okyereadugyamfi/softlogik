
Public Class SPPayModeCategories
    Public Shared ReadOnly Property DefaulList() As SPPayModeItem()
        Get
            Dim _DefaultList() As SPPayModeItem = {New SPPayModeItem("Cash", "CASH"), _
                                                    New SPPayModeItem("Credit", "CREDIT"), _
                                                    New SPPayModeItem("Cheque", "CHEQUE"), _
                                                    New SPPayModeItem("On Account", "ACCOUNT"), _
                                                    New SPPayModeItem("Voucher", "VOUCHER"), _
                                                    New SPPayModeItem("Other", "OTHER")}
            Return _DefaultList
        End Get
    End Property


End Class


Public Class SPPayModeItem

    Private _Name As String
    Public ReadOnly Property Name() As String
        Get
            Return _Name
        End Get
    End Property

    Private _Category As String
    Public ReadOnly Property Category() As String
        Get
            Return _Category
        End Get
    End Property

    Friend Sub New(ByVal Name As String, ByVal Category As String)
        Me._Name = Name
        Me._Category = Category
    End Sub
End Class

