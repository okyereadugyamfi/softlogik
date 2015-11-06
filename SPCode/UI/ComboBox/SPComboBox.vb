Namespace UI
    Public Class SPComboBox
        Inherits ComboBox

        Private m_strLookupText As String = "<New...>"
        Private m_intLookupIndex As Integer

        Public Event Populate(ByVal sender As Object, ByVal evt As SPComboBoxEventArgs)
        Public Event Lookup(ByVal sender As Object, ByVal evt As SPComboBoxEventArgs)


        Public Property LookupText() As String
            Get
                Return m_strLookupText
            End Get
            Set(ByVal value As String)
                m_strLookupText = value
            End Set
        End Property
        Public Property LookupIndex() As Integer
            Get
                Return m_intLookupIndex
            End Get
            Set(ByVal value As Integer)
                m_intLookupIndex = value
            End Set
        End Property

        Protected Overrides Sub OnSelectedValueChanged(ByVal e As System.EventArgs)
            MyBase.OnSelectedValueChanged(e)

            If Me.SelectedIndex = LookupIndex Then
                RaiseEvent Lookup(Me, New SPComboBoxEventArgs)
            End If
        End Sub


    End Class

    Public Class SPComboBoxEventArgs
        Inherits EventArgs

        Private m_objData As Object

        Public Property Data() As Object
            Get
                Return m_objData
            End Get
            Set(ByVal value As Object)
                m_objData = value
            End Set
        End Property
    End Class
End Namespace



