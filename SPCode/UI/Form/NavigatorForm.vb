Namespace UI
    Public Class NavigatorForm

        Public Event NavigationChanged(ByVal sender As Object, ByVal e As SPNavigatorFormOptionsChangedEventArgs)

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            If Not DesignMode Then
                Me.DockState = WeifenLuo.WinFormsUI.DockState.DockLeft
                AddHandler AppNavigation.OnNavigateBarButtonSelected, AddressOf OnNavigateBarButtonSelected
            End If
        End Sub


        Protected Overridable Sub OnNavigateBarButtonSelected(ByVal tNavigationButton As MT.Common.Controls.OutlookStyleNavigateBar.NavigateBarButton)
            RaiseEvent NavigationChanged(Me, New SPNavigatorFormOptionsChangedEventArgs(tNavigationButton))
        End Sub

    End Class

    Public Class SPNavigatorFormOptionsChangedEventArgs
        Inherits EventArgs

        Private _navButton As MT.Common.Controls.OutlookStyleNavigateBar.NavigateBarButton

        Public ReadOnly Property SelectedBar() As MT.Common.Controls.OutlookStyleNavigateBar.NavigateBarButton
            Get
                Return _navButton
            End Get
        End Property

        Public Sub New(ByVal NavButton As MT.Common.Controls.OutlookStyleNavigateBar.NavigateBarButton)
            _navButton = NavButton
        End Sub
    End Class
End Namespace
