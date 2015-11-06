Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class NavigatorForm
        Inherits DockableForm

        'Form overrides dispose to clean up the component list.
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

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim NavigateBarTheme1 As MT.Common.Controls.OutlookStyleNavigateBar.NavigateBarTheme = New MT.Common.Controls.OutlookStyleNavigateBar.NavigateBarTheme
            Me.AppNavigation = New MT.Common.Controls.OutlookStyleNavigateBar.NavigateBar
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'AppNavigation
            '
            Me.AppNavigation.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.AppNavigation.CollapsibleScreenWidth = 120
            Me.AppNavigation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.AppNavigation.IsShowCollapsibleScreen = True
            Me.AppNavigation.Location = New System.Drawing.Point(0, 0)
            Me.AppNavigation.MinimumSize = New System.Drawing.Size(22, 100)
            Me.AppNavigation.Name = "AppNavigation"
            Me.AppNavigation.NavigateBarButtonHeight = 32
            Me.AppNavigation.NavigateBarDisplayedButtonCount = 0
            Me.AppNavigation.NavigateBarPaintAngle = 90.0!
            Me.AppNavigation.SaveAndRestoreSettings = True
            Me.AppNavigation.SelectedButton = Nothing
            Me.AppNavigation.Size = New System.Drawing.Size(277, 427)
            Me.AppNavigation.TabIndex = 1
            NavigateBarTheme1.DarkColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(224, Byte), Integer))
            NavigateBarTheme1.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
            NavigateBarTheme1.LightColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(252, Byte), Integer))
            NavigateBarTheme1.MouseOverDarkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(136, Byte), Integer))
            NavigateBarTheme1.MouseOverLightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(222, Byte), Integer))
            NavigateBarTheme1.SelectedDarkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(154, Byte), Integer))
            NavigateBarTheme1.SelectedLightColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(62, Byte), Integer))
            Me.AppNavigation.Theme = NavigateBarTheme1
            '
            'NavigatorForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(277, 427)
            Me.Controls.Add(Me.AppNavigation)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "NavigatorForm"
            Me.Text = "NavigatorForm"
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Protected Friend WithEvents AppNavigation As MT.Common.Controls.OutlookStyleNavigateBar.NavigateBar
    End Class
End Namespace

