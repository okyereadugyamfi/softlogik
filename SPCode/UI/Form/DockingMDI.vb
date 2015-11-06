Imports System.Windows.Forms
Imports WeifenLuo.WinFormsUI

Namespace UI
    Public Class DockingMDI
        Private sourceReloadContentFunc As ReloadContent
        Private m_boolCanExit As Boolean = False
        Protected oDefaultRenderer As New ToolStripProfessionalRenderer(New PropertyGridEx.CustomColorScheme)

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            ToolStripManager.Renderer = oDefaultRenderer
            If Not DesignMode Then
                Dim configFile As String = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config")

                ' Set DockPanel properties
                DockPanel.ActiveAutoHideContent = Nothing
                DockPanel.Parent = Me
                SoftLogik.Win.UI.Docking.Extender.SetSchema(DockPanel, SoftLogik.Win.UI.Docking.Extender.Schema.FromBase)

                DockPanel.SuspendLayout(True)
                If System.IO.File.Exists(configFile) Then
                    Try
                        DockPanel.LoadFromXml(configFile, AddressOf prReloadContent)
                    Catch ex As Exception
                    End Try

                End If
                DockPanel.ResumeLayout(True, True)

                Me.Text = My.Application.Info.Title
            End If
            MyBase.OnLoad(e)
        End Sub

        Public Property ReloadContentFunction() As ReloadContent
            Get
                Return sourceReloadContentFunc
            End Get
            Set(ByVal value As ReloadContent)
                sourceReloadContentFunc = value
            End Set
        End Property

        Private Function prReloadContent(ByVal persistString As String) As IDockContent
            If ReloadContentFunction IsNot Nothing Then
                Return ReloadContentFunction.Invoke(persistString)
            Else
                Return Nothing
            End If
        End Function
        Protected Overrides Sub OnFormClosing(ByVal e As System.Windows.Forms.FormClosingEventArgs)
            'MyBase.OnFormClosing(e)
            'If Not e.Cancel Then
            If Not m_boolCanExit Then
                If Not (MessageBox.Show("Are you sure, you want to exit?", Me.Text, MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                    e.Cancel = True
                Else
                    Dim configFile As String = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config")
                    DockPanel.SaveAsXml(configFile)


                    Do While DockPanel.Contents.Count > 0
                        On Error Resume Next
                        Dim dc As DockContent = CType(DockPanel.Contents(0), DockContent)
                        If dc IsNot Me Then
                            dc.Close()
                        End If
                    Loop
                End If
            End If
            'End If
        End Sub

        Public Delegate Function ReloadContent(ByVal persistString As String) As IDockContent

    End Class
End Namespace

