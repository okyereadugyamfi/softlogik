Imports System
Imports WeifenLuo.WinFormsUI
Imports System.Drawing
Imports System.Drawing.Drawing2D
Namespace UI.Docking
    Public Class DockPaneStripOverride
        Inherits DockPaneStripVS2003
        Protected Friend Sub New(ByVal pane As DockPane)
            MyBase.New(pane)
            BackColor = SystemColors.ControlLight
        End Sub
    End Class
End Namespace
