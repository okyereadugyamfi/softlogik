Imports SoftLogik.Win.SPDataProxy
Imports System.ComponentModel

Namespace UI
    Public Class PaymodeForm

        Protected Overridable Function NewPayMode() As DataRowView
            Return SPPayMode.GetEmptyPayMode().DefaultView.Item(0)
        End Function

        Protected Overrides Sub OnRecordChanged(ByVal e As SPFormRecordUpdateEventArgs)
            MyBase.OnRecordChanged(e)
            Dim recordRow As SPPayModeRow = CType(e.DataRow, SPPayModeRow)
            If recordRow IsNot Nothing Then
                Select Case e.DataState
                    Case SPFormDataStates.[New]
                        SPPayMode.InsertPayMode(recordRow.Name, recordRow.Category, recordRow.BankID, recordRow.Note)
                    Case SPFormDataStates.Edited
                        SPPayMode.UpdatePayMode(recordRow.PayModeID, recordRow.Name, recordRow.Category, recordRow.BankID, recordRow.Note)
                    Case SPFormDataStates.Deleted
                        SPPayMode.DeletePayMode(recordRow.PayModeID)
                End Select

            End If
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

            Try
                ddlCategory.DataSource = SPPayModeCategories.DefaulList
                ddlCategory.DisplayMember = "Name"
                ddlCategory.ValueMember = "Category"
            Catch ex As Exception
            End Try

            MyBase.OnLoad(e)
        End Sub
        Protected Overrides Sub OnRecordBinding(ByVal e As SPFormRecordBindingEventArgs)
            MyBase.OnRecordBinding(e)

            With e.BindingSettings
                .DisplayMember = "Name"
                .ValueMember = "PayModeID"
            End With
            Try
                e.DataSource = SPPayMode.GetPayModes()
                e.BindingSettings.NewRecordProc = AddressOf NewPayMode
            Catch ex As Exception
            End Try

        End Sub

    End Class
End Namespace
