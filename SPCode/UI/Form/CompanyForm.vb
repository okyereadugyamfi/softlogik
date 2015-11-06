Imports SoftLogik.Win.SPDataProxy
Imports SoftLogik.Win.SPDataProxyTableAdapters

Namespace UI
    Public Class CompanyForm

        Private _NewRecordEmptyItem As DataRowView = Nothing

        Protected Overridable Function NewCompany() As DataRowView
            Return SPCompanyData.GetEmptyRecord().DefaultView.Item(0)
        End Function

        Private Sub CompanyForm_RecordBinding(ByVal sender As Object, ByVal e As SPFormRecordBindingEventArgs) Handles Me.RecordBinding

            With e.BindingSettings
                .DisplayMember = "Name"
                .ValueMember = "CompanyID"
            End With

            Try
                e.DataSource = SPCompanyData.GetCompanies()
                e.BindingSettings.NewRecordProc = AddressOf NewCompany
            Catch ex As Exception
            End Try
        End Sub

        Private Sub CompanyForm_RecordUpdated(ByVal sender As Object, ByVal e As SPFormRecordUpdateEventArgs) Handles Me.RecordChanged
            Dim recordRow As SPCompanyRow = CType(e.DataRow, SPCompanyRow)
            If recordRow IsNot Nothing Then
                Select Case e.DataState
                    Case SPFormDataStates.[New]
                        SPCompanyData.InsertCompany(recordRow.Name, recordRow.PhoneList, _
                        recordRow.EmailAddress, recordRow.Address1, recordRow.Address2, recordRow.Logo, _
                        recordRow.Motto, recordRow.CustomNote)
                    Case SPFormDataStates.Edited
                        SPCompanyData.UpdateCompany(recordRow.CompanyID, recordRow.Name, recordRow.PhoneList, _
                        recordRow.EmailAddress, recordRow.Address1, recordRow.Address2, recordRow.Logo, _
                        recordRow.Motto, recordRow.CustomNote)
                    Case SPFormDataStates.Deleted
                        SPCompanyData.DeleteCompany(recordRow.CompanyID)
                End Select

            End If
        End Sub

        Private Sub btnChangePhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePhoto.Click

            Try
                Logo.Image = Image.FromFile(SPFileDialog.ShowDialog(SPFileDialog.FileDialogTypes.Picture))
                txtName.Text &= " " : txtName.Text = txtName.Text.TrimEnd
            Catch ex As Exception
            End Try
        End Sub

        Private Sub btnClearPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPhoto.Click
            Logo.Image = Nothing
            txtName.Text &= " " : txtName.Text = txtName.Text.TrimEnd
        End Sub

        Private Sub Logo_BackgroundImageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Logo.BackgroundImageChanged

        End Sub

        Private Sub Logo_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles Logo.Invalidated

        End Sub


    End Class
End Namespace


