Namespace UI
    Public Class DockableForm
        Inherits WeifenLuo.WinFormsUI.DockContent

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

            Me.TabText = Me.Text
            Try
                If Not DesignMode Then
                    If Me.MdiParent IsNot Nothing Then
                        Me.Show(CType(Me.MdiParent, DockingMDI).DockPanel, WeifenLuo.WinFormsUI.DockState.Document)
                    End If
                End If
            Catch ex As Exception
            End Try

            MyBase.OnLoad(e)
        End Sub

        Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
            Me.Close()
        End Sub
    End Class
End Namespace
