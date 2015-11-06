Namespace UI
    Public Class SPPreview

    End Class
    Public Module SPDefaultPreview
        Private m_objSPPreview As SPPreview = New SPPreview

        Public ReadOnly Property SPPreview() As SPPreview
            Get
                Return m_objSPPreview
            End Get
        End Property
    End Module
End Namespace




