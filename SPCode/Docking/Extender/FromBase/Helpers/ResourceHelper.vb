' *****************************************************************************
' 
'  Copyright 2004, Weifen Luo
'  All rights reserved. The software and associated documentation 
'  supplied hereunder are the proprietary information of Weifen Luo
'  and are supplied subject to licence terms.
' 
'  WinFormsUI Library Version 1.0
' *****************************************************************************
Imports System
Imports System.Drawing
Imports System.Reflection
Imports System.Resources
Imports System.Windows.Forms
Imports WeifenLuo.WinFormsUI
Namespace UI.Docking
    Friend Class ResourceHelper
        Private Shared m_resourceManager As ResourceManager
        Shared Sub New()
            m_resourceManager = New ResourceManager("Strings", GetType(ResourceHelper).Assembly)
        End Sub
        Public Shared Function LoadBitmap(ByVal name As String) As Bitmap
            Dim assembly As Assembly = GetType(DockPanel).Assembly
            Dim fullNamePrefix As String = "WeifenLuo.WinFormsUI.Resources."
            Return New Bitmap(assembly.GetManifestResourceStream(fullNamePrefix & name))
        End Function
        Public Shared Function LoadExtenderBitmap(ByVal name As String) As Bitmap
            On Error Resume Next
            Dim outBitmap As Bitmap = CType(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("SoftLogik.Win." & name)), Bitmap)
            Return outBitmap
        End Function
        Public Shared Function GetString(ByVal name As String) As String
            On Error Resume Next
            Return m_resourceManager.GetString(name)
        End Function
    End Class
End Namespace
