Imports SoftLogik.Win.SPDataProxy
Imports System.ComponentModel

Namespace UI
    Public Class MasterForm

        Private _TypeID As String = String.Empty
        Private _NewRecordEmptyItem As DataRowView = Nothing

        Public Property TypeID() As String
            Get
                Return _TypeID
            End Get
            Set(ByVal value As String)
                _TypeID = value
            End Set
        End Property

        Protected Overridable Function NewMaster() As DataRowView
            Return SPMaster.GetEmptyMaster(TypeID).DefaultView.Item(0)
        End Function

        Protected Overrides Sub OnRecordChanged(ByVal e As SPFormRecordUpdateEventArgs)
            MyBase.OnRecordChanged(e)
            Dim recordRow As SPMasterRow = CType(e.DataRow, SPMasterRow)
            If recordRow IsNot Nothing Then
                Select Case e.DataState
                    Case SPFormDataStates.[New]
                        SPMaster.InsertMaster(recordRow.Name, recordRow.Note, TypeID)
                    Case SPFormDataStates.Edited
                        SPMaster.UpdateMaster(recordRow.MasterID, recordRow.Name, recordRow.Note)
                    Case SPFormDataStates.Deleted
                        SPMaster.DeleteMaster(recordRow.MasterID)
                End Select

            End If
        End Sub

        Protected Overrides Sub OnRecordBinding(ByVal e As SPFormRecordBindingEventArgs)
            MyBase.OnRecordBinding(e)
            If String.IsNullOrEmpty(TypeID) = False Then
                With e.BindingSettings
                    .DisplayMember = "Name"
                    .ValueMember = "MasterID"
                End With
                Try
                    e.DataSource = SPMaster.GetMaster(TypeID)
                    e.BindingSettings.NewRecordProc = AddressOf NewMaster
                Catch ex As Exception
                End Try
            End If


        End Sub


    End Class
End Namespace

