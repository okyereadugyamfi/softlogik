Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TransactionForm
        Inherits RecordForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransactionForm))
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'IconSource
            '
            Me.IconSource.ImageStream = CType(resources.GetObject("IconSource.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.IconSource.Images.SetKeyName(0, "DOC.png")
            '
            'TransactionForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(778, 443)
            Me.Name = "TransactionForm"
            Me.Text = "TransactionForm"
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace

