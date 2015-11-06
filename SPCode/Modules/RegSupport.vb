
Imports Microsoft.Win32

Module RegSupport

    Private m_objReg As CSPRegistry

    Public ReadOnly Property Reg() As CSPRegistry
        Get
            If IsNothing(m_objReg) Then
                m_objReg = New CSPRegistry
            End If
            Return m_objReg
        End Get
    End Property

End Module

Public Class CSPRegistry
#Region "Public Procedures"
    Public Function SetValue(ByRef KeyRoot As Microsoft.Win32.RegistryHive, _
    ByVal KeyPath As String, ByVal KeyName As String, ByVal Value As Object, _
    Optional ByVal RemoteMachine As String = vbNullString) As Boolean
        Dim objKey As RegistryKey

        Try
            objKey = OpenKey(KeyRoot, KeyName, RemoteMachine)
            objKey.SetValue(KeyName, Value)
            objKey.Close()
        Catch ex As Exception

        End Try

        Return True
    End Function
    Public Function GetValue(ByRef Key As Microsoft.Win32.RegistryHive, _
ByVal KeyPath As String, ByVal Name As String, Optional ByVal DefaultValue As Object = Nothing, _
Optional ByVal RemoteMachine As String = vbNullString) As Object
        Dim objKey As RegistryKey, objValue As Object = Nothing

        Try
            Select Case Key
                Case RegistryHive.ClassesRoot
                    objKey = Registry.ClassesRoot.OpenSubKey(KeyPath, True)
                Case RegistryHive.LocalMachine
                    objKey = Registry.LocalMachine.OpenSubKey(KeyPath, True)
                Case RegistryHive.CurrentUser
                    objKey = Registry.CurrentUser.OpenSubKey(KeyPath, True)
                Case Else
                    objKey = RegistryKey.OpenRemoteBaseKey(Key, _
                    RemoteMachine).OpenSubKey(KeyPath, True)
            End Select

            objKey.GetValue(Name)
            objKey.Close()
        Catch ex As Exception

        End Try

        Return CType(objValue, String)
    End Function

    Public Function KeyExists(ByRef KeyRoot As RegistryHive, _
    ByRef KeyName As String, Optional ByVal RemoteMachine As String = vbNullString) As Boolean

        Return Not (OpenKey(KeyRoot, KeyName, RemoteMachine) Is Nothing)
    End Function
    Public Function ValueExists(ByRef KeyRoot As RegistryHive, _
ByRef KeyName As String, ByVal ValueName As String, _
 Optional ByVal RemoteMachine As String = vbNullString) As Boolean
        Dim objKey As RegistryKey = OpenKey(KeyRoot, KeyName, RemoteMachine)

        Return (objKey.GetValue(ValueName) Is Nothing)
    End Function
#End Region

#Region "Private Procedures"
    Private Function OpenKey(ByRef Key As Microsoft.Win32.RegistryHive, _
    ByVal KeyPath As String, ByVal Name As String, _
    Optional ByVal RemoteMachine As String = vbNullString) As RegistryKey

        Dim objKey As RegistryKey

        Try

            Select Case Key
                Case RegistryHive.ClassesRoot
                    objKey = Registry.ClassesRoot.OpenSubKey(KeyPath, True)
                Case RegistryHive.LocalMachine
                    objKey = Registry.LocalMachine.OpenSubKey(KeyPath, True)
                Case RegistryHive.CurrentUser
                    objKey = Registry.CurrentUser.OpenSubKey(KeyPath, True)
                Case Else
                    objKey = RegistryKey.OpenRemoteBaseKey(Key, _
                    RemoteMachine).OpenSubKey(KeyPath, True)
            End Select

            Return objKey
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
#End Region
End Class

