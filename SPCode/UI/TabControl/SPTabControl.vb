Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace UI
    <ToolboxBitmap(GetType(TabControl))> _
    Public Class SPTabControl : Inherits TabControl

#Region "    Variables "

        Private _DisplayManager As SPTabControlDisplayManager = SPTabControlDisplayManager.Framework

#End Region

#Region "    Properties "

        <System.ComponentModel.DefaultValue(GetType(SPTabControlDisplayManager), "Framework"), System.ComponentModel.Category("Appearance")> _
        Public Property DisplayManager() As SPTabControlDisplayManager
            Get
                Return _DisplayManager
            End Get
            Set(ByVal value As SPTabControlDisplayManager)
                _DisplayManager = value
                If Me._DisplayManager.Equals(SPTabControlDisplayManager.Framework) Then
                    Me.SetStyle(ControlStyles.UserPaint, True)
                    Me.ItemSize = New Size(0, 15)
                    Me.Padding = New Point(9, 0)
                Else
                    Me.ItemSize = New Size(0, 0)
                    Me.Padding = New Point(6, 3)
                    Me.SetStyle(ControlStyles.UserPaint, False)
                End If
            End Set
        End Property

#End Region

#Region "    Constructor "

        Public Sub New()
            MyBase.New()
            If Me._DisplayManager.Equals(SPTabControlDisplayManager.Framework) Then
                Me.SetStyle(ControlStyles.UserPaint, True)
                Me.ItemSize = New Size(0, 15)
                Me.Padding = New Point(9, 0)
            End If
            Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.SetStyle(ControlStyles.ResizeRedraw, True)
            Me.ResizeRedraw = True
        End Sub

#End Region

#Region "    Private Methods "

        Private Function GetPath(ByVal index As Integer) As System.Drawing.Drawing2D.GraphicsPath
            Dim path As New System.Drawing.Drawing2D.GraphicsPath()
            path.Reset()

            Dim rect As Rectangle = Me.GetTabRect(index)

            If index = 0 Then
                path.AddLine(rect.Left + 1, rect.Bottom + 1, rect.Left + rect.Height, rect.Top + 2)
                path.AddLine(rect.Left + rect.Height + 4, rect.Top, rect.Right - 3, rect.Top)
                path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1)
            Else
                If index = Me.SelectedIndex Then
                    path.AddLine(rect.Left + 5 - rect.Height, rect.Bottom + 1, rect.Left + 4, rect.Top + 2)
                    path.AddLine(rect.Left + 8, rect.Top, rect.Right - 3, rect.Top)
                    path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1)
                    path.AddLine(rect.Right - 1, rect.Bottom + 1, rect.Left + 5 - rect.Height, rect.Bottom + 1)
                Else
                    path.AddLine(rect.Left, rect.Top + 6, rect.Left + 4, rect.Top + 2)
                    path.AddLine(rect.Left + 8, rect.Top, rect.Right - 3, rect.Top)
                    path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1)
                    path.AddLine(rect.Right - 1, rect.Bottom + 1, rect.Left, rect.Bottom + 1)
                End If
            End If
            Return path
        End Function

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

            '   Paint the Background
            Me.PaintTransparentBackground(e.Graphics, Me.ClientRectangle)

            '   Paint all the tabs
            If Me.TabCount > 0 Then
                For index As Integer = 0 To Me.TabCount - 1
                    Me.PaintTab(e, index)
                Next
            End If

            '   paint a border round the pagebox
            '   We can't make the border disappear so have to do it like this.
            If Me.TabCount > 0 Then

                Dim borderRect As Rectangle = Me.TabPages(0).Bounds
                If Me.SelectedTab IsNot Nothing Then
                    borderRect = Me.SelectedTab.Bounds
                End If

                borderRect.Inflate(1, 1)
                ControlPaint.DrawBorder(e.Graphics, borderRect, SPThemedColors.ToolBorder, ButtonBorderStyle.Solid)

            End If

            '   repaint the bit where the selected tab is
            Select Case Me.SelectedIndex
                Case -1
                Case 0
                    Dim selrect As Rectangle = Me.GetTabRect(Me.SelectedIndex)
                    Dim selrectRight As Integer = selrect.Right
                    e.Graphics.DrawLine(SystemPens.ControlLightLight, selrect.Left + 2, selrect.Bottom + 1, selrectRight - 2, selrect.Bottom + 1)
                Case Else
                    Dim selrect As Rectangle = Me.GetTabRect(Me.SelectedIndex)
                    Dim selrectRight As Integer = selrect.Right
                    e.Graphics.DrawLine(SystemPens.ControlLightLight, selrect.Left + 6 - selrect.Height, selrect.Bottom + 1, selrectRight - 2, selrect.Bottom + 1)
            End Select

        End Sub

        Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
            If Me.DesignMode Then
                Dim backBrush As New System.Drawing.Drawing2D.LinearGradientBrush(Me.Bounds, SystemColors.ControlLightLight, SystemColors.ControlLight, Drawing2D.LinearGradientMode.Vertical)
                pevent.Graphics.FillRectangle(backBrush, Me.Bounds)
                backBrush.Dispose()
            Else
                Me.PaintTransparentBackground(pevent.Graphics, Me.ClientRectangle)
            End If
        End Sub

        Protected Sub PaintTransparentBackground(ByVal g As Graphics, ByVal clipRect As Rectangle)
            If (Me.Parent IsNot Nothing) Then
                clipRect.Offset(Me.Location)
                Dim e As PaintEventArgs = New PaintEventArgs(g, clipRect)
                Dim state As GraphicsState = g.Save
                g.SmoothingMode = SmoothingMode.HighSpeed
                Try
                    g.TranslateTransform(CType(-Me.Location.X, Single), CType(-Me.Location.Y, Single))
                    Me.InvokePaintBackground(Me.Parent, e)
                    Me.InvokePaint(Me.Parent, e)

                Finally
                    g.Restore(state)
                    clipRect.Offset(-Me.Location.X, -Me.Location.Y)
                End Try
            Else
                Dim backBrush As New System.Drawing.Drawing2D.LinearGradientBrush(Me.Bounds, SystemColors.ControlLightLight, SystemColors.ControlLight, Drawing2D.LinearGradientMode.Vertical)
                g.FillRectangle(backBrush, Me.Bounds)
                backBrush.Dispose()
            End If
        End Sub

        Private Sub PaintTab(ByVal e As System.Windows.Forms.PaintEventArgs, ByVal index As Integer)

            Dim path As System.Drawing.Drawing2D.GraphicsPath = Me.GetPath(index)
            Me.PaintTabBackground(e.Graphics, index, path)
            Me.PaintTabBorder(e.Graphics, index, path)
            Me.PaintTabText(e.Graphics, index)
            Me.PaintTabImage(e.Graphics, index)

        End Sub

        Private Sub PaintTabBackground(ByVal graph As System.Drawing.Graphics, ByVal index As Integer, ByVal path As System.Drawing.Drawing2D.GraphicsPath)
            Dim rect As Rectangle = Me.GetTabRect(index)

            If rect.Height > 1 AndAlso rect.Width > 1 Then
                Dim buttonBrush As System.Drawing.Brush = _
                    New System.Drawing.Drawing2D.LinearGradientBrush( _
                        rect, _
                        SystemColors.ControlLightLight, _
                        SystemColors.ControlLight, _
                        Drawing2D.LinearGradientMode.Vertical)

                If index = Me.SelectedIndex Then
                    buttonBrush = New System.Drawing.SolidBrush(SystemColors.ControlLightLight)
                End If

                graph.FillPath(buttonBrush, path)
                buttonBrush.Dispose()
            End If

        End Sub

        Private Sub PaintTabBorder(ByVal graph As System.Drawing.Graphics, ByVal index As Integer, ByVal path As System.Drawing.Drawing2D.GraphicsPath)
            Dim borderPen As New Pen(SystemColors.ControlDark)
            If index = Me.SelectedIndex Then
                borderPen = New Pen(SPThemedColors.ToolBorder)
            End If

            graph.DrawPath(borderPen, path)
            borderPen.Dispose()
        End Sub

        Private Sub PaintTabImage(ByVal graph As System.Drawing.Graphics, ByVal index As Integer)
            Dim tabImage As Image = Nothing
            If Me.TabPages(index).ImageIndex > -1 AndAlso Me.ImageList IsNot Nothing Then
                tabImage = Me.ImageList.Images(Me.TabPages(index).ImageIndex)
            ElseIf Me.TabPages(index).ImageKey.Trim().Length > 0 AndAlso Me.ImageList IsNot Nothing Then
                tabImage = Me.ImageList.Images(Me.TabPages(index).ImageKey)
            End If
            If tabImage IsNot Nothing Then
                Dim rect As Rectangle = Me.GetTabRect(index)
                graph.DrawImage(tabImage, rect.Right - rect.Height - 4, 4, rect.Height - 2, rect.Height - 2)
            End If
        End Sub

        Private Sub PaintTabText(ByVal graph As System.Drawing.Graphics, ByVal index As Integer)
            Dim rect As Rectangle = Me.GetTabRect(index)
            Dim rect2 As New Rectangle(rect.Left + 8, rect.Top + 1, rect.Width - 6, rect.Height)
            If index = 0 Then rect2 = New Rectangle(rect.Left + rect.Height, rect.Top + 1, rect.Width - rect.Height, rect.Height)

            Dim tabtext As String = Me.TabPages(index).Text

            Dim format As New System.Drawing.StringFormat()
            format.Alignment = StringAlignment.Near
            format.LineAlignment = StringAlignment.Center
            format.Trimming = StringTrimming.EllipsisCharacter

            Dim forebrush As Brush = Nothing

            If Me.TabPages(index).Enabled = False Then
                forebrush = SystemBrushes.ControlDark
            Else
                forebrush = SystemBrushes.ControlText
            End If

            Dim tabFont As Font = Me.Font
            If index = Me.SelectedIndex Then
                tabFont = New Font(Me.Font, FontStyle.Bold)
                If index = 0 Then
                    rect2 = New Rectangle(rect.Left + rect.Height, rect.Top + 1, rect.Width - rect.Height + 5, rect.Height)
                End If
            End If

            graph.DrawString(tabtext, tabFont, forebrush, rect2, format)

        End Sub

#End Region

        Public Enum SPTabControlDisplayManager As Integer
            [Default]
            Framework
        End Enum

        Protected Overrides Sub OnSelecting(ByVal e As System.Windows.Forms.TabControlCancelEventArgs)
            If e.Action = TabControlAction.Selecting _
                AndAlso e.TabPage IsNot Nothing _
                AndAlso e.TabPage.Enabled = False Then

                e.Cancel = True
                If e.TabPageIndex = 0 AndAlso Me.TabPages.Count = 1 Then
                    If Me.TabPages(0).Controls.Count > 0 Then
                        Dim item As Form = TryCast(Me.TabPages(0).Controls(0), Form)
                        If item IsNot Nothing Then item.Close()
                    End If
                    Me.TabPages.RemoveAt(0)
                ElseIf e.TabPageIndex = 0 AndAlso Me.TabPages.Count > 1 Then
                    e.Cancel = False
                End If
            End If
            MyBase.OnSelecting(e)
        End Sub

        Protected Overrides Sub OnSelected(ByVal e As System.Windows.Forms.TabControlEventArgs)
            If e.Action = TabControlAction.Selected _
                AndAlso e.TabPage IsNot Nothing _
                AndAlso e.TabPage.Enabled = False Then

                If Me.TabPages.Count > e.TabPageIndex + 1 Then
                    Me.SelectedIndex = e.TabPageIndex + 1
                ElseIf e.TabPageIndex > 0 Then
                    Me.SelectedIndex = e.TabPageIndex - 1
                End If
            End If
            MyBase.OnSelected(e)
            Me.Invalidate()
        End Sub

    End Class
End Namespace

