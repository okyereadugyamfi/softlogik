#Region "Imports directives"

Imports System
Imports System.Drawing
Imports System.ComponentModel

#End Region

Namespace Security
    <ToolboxBitmap(GetType(WSLoginControl), "LoginControl.bmp")> _
    Partial Public Class WSLoginControl
        Inherits SPLoginControl
        Protected Overrides Function GetUserManager() As IUserManager
            Return New UserManager()
        End Function
    End Class
End Namespace
