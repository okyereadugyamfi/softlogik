Namespace UI
    Public NotInheritable Class SplashForm

        Private _SplashImage As Image

        Public WriteOnly Property SplashImage() As Image
            Set(ByVal value As Image)
                _SplashImage = value
            End Set
        End Property
        'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
        '  of the Project Designer ("Properties" under the "Project" menu).


        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            'Set up the dialog text at runtime according to the application's assembly information.  

            'Application title
            If My.Application.Info.Title <> "" Then
                ApplicationTitle.Text = My.Application.Info.Title
            Else
                'If the application title is missing, use the application name, without the extension
                ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
            End If

            'Format the version information using the text set into the Version control at design time as the
            '  formatting string.  This allows for effective localization if desired.
            '  Build and revision information could be included by using the following code and changing the 
            '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
            '  String.Format() in Help for more information.
            '
            '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

            Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

            'Copyright info
            Copyright.Text = My.Application.Info.Copyright
        End Sub
        Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
            If _SplashImage IsNot Nothing Then
                e.Graphics.DrawImage(_SplashImage, New Rectangle(0, 0, Me.Width, Me.Height))
            Else
                MyBase.OnPaintBackground(e)
            End If
        End Sub
    End Class
End Namespace

