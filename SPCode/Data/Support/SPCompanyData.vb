Imports System.IO
Imports System.Drawing.Imaging
Imports SoftLogik.Win.SPDataProxyTableAdapters

Public Class SPCompanyData
    Public Shared Function GetCompanies() As SPDataProxy.SPCompanyDataTable
        Dim data As SPDataProxy.SPCompanyDataTable
        Using dataCmd As New SPDataProxyTableAdapters.taSPCompany
            data = dataCmd.GetCompanies()
        End Using

        Return data
    End Function
    Public Shared Function GetEmptyRecord() As SPDataProxy.SPCompanyDataTable
        Dim data As SPDataProxy.SPCompanyDataTable
        Using dataCmd As New SPDataProxyTableAdapters.taSPCompany
            data = dataCmd.GetEmptyCompany()
        End Using

        Return data
    End Function

    Public Shared Function InsertCompany(ByVal Name As String, _
    ByVal PhoneList As String, ByVal EmailAddress As String, ByVal Address1 As String, _
    ByVal Address2 As String, ByVal Logo() As Byte, ByVal Motto As String, ByVal CustomNote As String) As Integer
        Using companyAdapter As New taSPCompany
            Return companyAdapter.Insert(Name, PhoneList, EmailAddress, Address1, Address2, Logo, Motto, CustomNote)
        End Using
    End Function
    Public Shared Function UpdateCompany(ByVal CompanyID As Long, ByVal Name As String, _
    ByVal PhoneList As String, ByVal EmailAddress As String, ByVal Address1 As String, _
    ByVal Address2 As String, ByVal Logo() As Byte, ByVal Motto As String, ByVal CustomNote As String) As Integer
        Using companyAdapter As New taSPCompany
            Return companyAdapter.Update(CompanyID, Name, PhoneList, EmailAddress, Address1, Address2, Logo, Motto, CustomNote)
        End Using
    End Function
    Public Shared Function DeleteCompany(ByVal CompanyID As Long) As Integer
        Using companyAdapter As New taSPCompany
            Return companyAdapter.Delete(CompanyID)
        End Using
    End Function
End Class
