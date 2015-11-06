Namespace Security
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SPLoginControl
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer
        Private WithEvents m_UserNameLabel As System.Windows.Forms.Label
        Private WithEvents m_PasswordLabel As System.Windows.Forms.Label
        Private WithEvents m_ErrorProvider As System.Windows.Forms.ErrorProvider
        Private WithEvents m_LogInButton As System.Windows.Forms.Button
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SPLoginControl))
            Me.m_UserNameLabel = New System.Windows.Forms.Label
            Me.m_PasswordLabel = New System.Windows.Forms.Label
            Me.m_ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.m_LogInButton = New System.Windows.Forms.Button
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
            Me.m_PasswordBox = New System.Windows.Forms.TextBox
            Me.m_UserNameBox = New System.Windows.Forms.TextBox
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'm_UserNameLabel
            '
            resources.ApplyResources(Me.m_UserNameLabel, "m_UserNameLabel")
            Me.m_UserNameLabel.Name = "m_UserNameLabel"
            '
            'm_PasswordLabel
            '
            resources.ApplyResources(Me.m_PasswordLabel, "m_PasswordLabel")
            Me.m_PasswordLabel.Name = "m_PasswordLabel"
            '
            'm_ErrorProvider
            '
            Me.m_ErrorProvider.ContainerControl = Me
            '
            'm_LogInButton
            '
            resources.ApplyResources(Me.m_LogInButton, "m_LogInButton")
            Me.m_LogInButton.Name = "m_LogInButton"
            '
            'TableLayoutPanel1
            '
            resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
            Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.m_LogInButton, 1, 1)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            '
            'TableLayoutPanel2
            '
            resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
            Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.m_PasswordLabel, 0, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.m_UserNameBox, 1, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.m_PasswordBox, 1, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.m_UserNameLabel, 0, 0)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            '
            'm_PasswordBox
            '
            resources.ApplyResources(Me.m_PasswordBox, "m_PasswordBox")
            Me.m_PasswordBox.Name = "m_PasswordBox"
            '
            'm_UserNameBox
            '
            resources.ApplyResources(Me.m_UserNameBox, "m_UserNameBox")
            Me.m_UserNameBox.Name = "m_UserNameBox"
            '
            'SPLoginControl
            '
            resources.ApplyResources(Me, "$this")
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.DoubleBuffered = True
            Me.Name = "SPLoginControl"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents m_UserNameBox As System.Windows.Forms.TextBox
        Private WithEvents m_PasswordBox As System.Windows.Forms.TextBox

    End Class
End Namespace

