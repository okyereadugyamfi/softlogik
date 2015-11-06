#Region "Imports directives"
Imports System
Imports System.Drawing
#End Region

Namespace Security
    <ToolboxBitmap(GetType(AspNetLoginControl), "LoginControl.bmp")> _
    Public Class AspNetLoginControl
        Inherits SPLoginControl

        Protected Overrides Function GetUserManager() As IUserManager
            Return New AspNetUserManager()
        End Function
    End Class
End Namespace
