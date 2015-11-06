Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports System.Windows.Forms.ComponentModel

Namespace UI
    Public Class SPRadioButtonListEditorUI

        Private _RadioItems As SPRadioButtonItemCollection = Nothing

        Friend Sub New(ByVal itemsTarget As SPRadioButtonItemCollection, _
        ByVal editorService As IWindowsFormsEditorService)

            InitializeComponent()

        End Sub

        ' LightShape is the property for which this control provides
        ' a custom user interface in the Properties window.
        Public Property RadioItems() As SPRadioButtonItemCollection

            Get
                Return Me._RadioItems
            End Get

            Set(ByVal Value As SPRadioButtonItemCollection)
                If Me._RadioItems IsNot Value Then
                    Me._RadioItems = Value
                End If
            End Set
        End Property
    End Class
End Namespace


