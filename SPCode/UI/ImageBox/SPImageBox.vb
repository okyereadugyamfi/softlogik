Namespace UI
    ''' <summary>
    ''' Summary description for dbImageBox.
    ''' </summary>
    Public Class SPImageBox
        Inherits System.Windows.Forms.PictureBox
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing
        Private m_ImagePath As String

        '		public delegate void ImgEventHandler (object s);
        '		public event ImgEventHandler ImagePathChanged;

        Public Sub New()
            ' This call is required by the Windows.Forms Form Designer.
            InitializeComponent()

            ' TODO: Add any initialization after the InitComponent call
        End Sub

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not components Is Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub
#Region "Component Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
        End Sub
#End Region

        Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
            ' TODO: Add custom paint code here

            ' Calling the base class OnPaint
            MyBase.OnPaint(pe)
        End Sub

        Public Property ImagePath() As String
            Get
                Return Me.m_ImagePath
            End Get
            Set(ByVal value As String)
                If value <> Me.m_ImagePath Then
                    Me.m_ImagePath = value
                    If System.IO.File.Exists(value) Then
                        UpdateImage()
                    Else
                        Me.Image = Nothing
                    End If
                    '					ImagePathChanged(this);
                End If
            End Set
        End Property

        Public Sub UpdateImage()
            Try
                Me.Image = Image.FromFile(ImagePath)
            Catch e As System.Exception
                MessageBox.Show(e.Message)
                Me.Image = Nothing
            End Try
        End Sub

    End Class
End Namespace
