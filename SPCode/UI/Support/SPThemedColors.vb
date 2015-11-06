Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles
Imports System.Drawing

Namespace UI
    Public Class SPThemedColors

#Region "    Variables and Constants "

        Private Const NormalColor As String = "NormalColor"
        Private Const HomeStead As String = "HomeStead"
        Private Const Metallic As String = "Metallic"
        Private Const NoTheme As String = "NoTheme"

        Private Shared _toolBorder As Color()
#End Region

#Region "    Properties "

        Public Shared ReadOnly Property CurrentThemeIndex() As Integer
            Get
                Return SPThemedColors.GetCurrentThemeIndex
            End Get
        End Property

        Public Shared ReadOnly Property CurrentThemeName() As String
            Get
                Return SPThemedColors.GetCurrentThemeName
            End Get
        End Property

        Public Shared ReadOnly Property ToolBorder() As Color
            Get
                Return SPThemedColors._toolBorder(SPThemedColors.CurrentThemeIndex)
            End Get
        End Property

#End Region

#Region "    Constructors "

        Private Sub New()
        End Sub

        Shared Sub New()
            Dim colorArray1 As Color()
            colorArray1 = New Color() {Color.FromArgb(127, 157, 185), Color.FromArgb(164, 185, 127), Color.FromArgb(165, 172, 178), Color.FromArgb(132, 130, 132)}
            SPThemedColors._toolBorder = colorArray1
        End Sub

#End Region

        Private Shared Function GetCurrentThemeIndex() As Integer
            Dim theme As Integer = ColorScheme.NoTheme

            If VisualStyleInformation.IsSupportedByOS _
                AndAlso VisualStyleInformation.IsEnabledByUser _
                AndAlso Application.RenderWithVisualStyles Then


                Select Case VisualStyleInformation.ColorScheme
                    Case NormalColor
                        theme = ColorScheme.NormalColor
                    Case HomeStead
                        theme = ColorScheme.HomeStead
                    Case Metallic
                        theme = ColorScheme.Metallic
                    Case Else
                        theme = ColorScheme.NoTheme
                End Select
            End If

            Return theme
        End Function

        Private Shared Function GetCurrentThemeName() As String
            Dim theme As String = NoTheme

            If VisualStyleInformation.IsSupportedByOS _
                AndAlso VisualStyleInformation.IsEnabledByUser _
                AndAlso Application.RenderWithVisualStyles Then

                theme = VisualStyleInformation.ColorScheme
            End If

            Return theme
        End Function


        Public Enum ColorScheme
            NormalColor = 0
            HomeStead = 1
            Metallic = 2
            NoTheme = 3
        End Enum

    End Class
End Namespace



