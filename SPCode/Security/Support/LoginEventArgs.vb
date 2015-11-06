#Region "Imports directives"
Imports System
Imports System.Threading
Imports System.Security.Principal
Imports System.Diagnostics
Imports System.Reflection
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
#End Region

Namespace Security
    Public Class LoginEventArgs
        Inherits EventArgs

        Private m_Authenticated As Boolean

        Public Sub New(ByVal authenticated As Boolean)
            Me.Authenticated = authenticated
        End Sub

        Public Property Authenticated() As Boolean
            Get
                Return m_Authenticated
            End Get
            Friend Set(ByVal value As Boolean)
                m_Authenticated = value
            End Set
        End Property
    End Class
End Namespace
