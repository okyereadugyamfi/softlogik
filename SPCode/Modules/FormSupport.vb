
Module FormSupport
    Public Sub FormCenter(ByRef frmCurrent As Form)
        Dim intLeft As Integer
        Dim intTop As Integer
        Dim frm As Form

        frm = CType(frmCurrent, Form)
        intLeft = (Screen.PrimaryScreen.Bounds.Width \ 2) - (frmCurrent.Width \ 2)
        intTop = (Screen.PrimaryScreen.Bounds.Height \ 2) - (frmCurrent.Height \ 2)
        With frm
            .Location = New Point(intLeft, intTop)
        End With
    End Sub
    Public Function FormClosingCheck(ByRef frmName As Form) As DialogResult
        If frmName.WindowState = System.Windows.Forms.FormWindowState.Minimized Then
            frmName.WindowState = FormWindowState.Normal
        End If

        frmName.BringToFront()

        ' Ask user what to do with the changes
        Return MessageBox.Show(TextDictionary("MS_DATACHANGED"), frmName.Text, MessageBoxButtons.YesNoCancel)
    End Function
    Public Sub FormCenterChild(ByRef frmCurrent As Form)
        Dim intLeft As Integer
        Dim intTop As Integer
        Dim frm As Form

        frm = CType(frmCurrent, Form)
        intLeft = (Common.MainShell.Width \ 2) - (frmCurrent.Width \ 2)
        intTop = (Common.MainShell.Height \ 2) - (frmCurrent.Height \ 2)
        With frm
            .Location = New Point(intLeft, intTop)
        End With
    End Sub
    Public Function DeleteAsk(ByVal strMsg As String, Optional ByRef strCaption As String = "") As Boolean
        If MsgBox(strMsg, MsgBoxStyle.Question Or MsgBoxStyle.YesNo, IIf(strCaption <> "", strCaption, System.Windows.Forms.Form.ActiveForm.Text)) = MsgBoxResult.Yes Then
            DeleteAsk = True
        Else
            DeleteAsk = False
        End If
    End Function
End Module

