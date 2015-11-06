
Imports Microsoft.Win32



Module DSNSupport

    Public Function CreateDSN(ByVal Name As String, ByVal Description As String, _
ByVal ServerName As String, ByVal InitialCatalog As String, _
ByVal UserID As String, ByVal Password As String, ByVal IntegratedSecurity As Boolean, _
    Optional ByVal DriverName As String = "SQL Server") As String
        '---------------------------------------------------------------------------------------
        ' Procedure : Create
        ' DateTime  : 24/11/2005 16:14
        ' Author    : Jefferson O. Adu - Gyamfi
        ' Purpose   :
        '
        ' Returns:
        'String
        '
        '---------------------------------------------------------------------------------------


        Dim strDSNName As String
        Dim strDBName As String
        Dim strDSNDescription As String
        Dim strDriverPath As String
        Dim strDriverName As String
        Dim strLastUser As String
        Dim strPassword As String
        Dim strServer As String
        Dim strRegPath As String

        Dim szProcedureSign As String
1:      szProcedureSign = "CSystemDSN" & "." & "Create()"
#If DEBUGMODE = 1 Then
   #If TRACEMODE = 1 Then
2           Call Err.TraceIn(szProcedureSign)
   #End If
3        On Local Error GoTo Create_Err
#End If
        '>=====User Code Section Begins======

        'Specify the DSN parameters.

4:      strDSNName = Trim$(Name)
5:      strDBName = Trim$(InitialCatalog)
6:      strDSNDescription = Trim$(Description)
7:      strDriverName = Trim$(DriverName)
8:      strDriverPath = CType(Reg.GetValue(RegistryHive.LocalMachine, _
        "SOFTWARE\ODBC\ODBCINST.INI\" & strDriverName, "Driver", ), String)
9:      strLastUser = Trim$(UserID)
10:     strServer = Trim$(ServerName)
11:     strPassword = Trim$(Password)

        'Create the new DSN key.
12:     strRegPath = "SOFTWARE\ODBC\ODBC.INI\" & strDSNName
        'Database
13:     If strDBName <> vbNullString Then
14:         Reg.SetValue(RegistryHive.LocalMachine, strRegPath, "Database", strDBName)
15:     End If
16:     If strDSNDescription <> vbNullString Then
17:         Reg.SetValue(RegistryHive.LocalMachine, strRegPath, "Description", strDSNDescription)
18:     End If

19:     If strDriverPath <> vbNullString Then
20:         Reg.SetValue(RegistryHive.LocalMachine, strRegPath, "Driver", strDriverPath)
21:     End If
22:     If UserID <> vbNullString Then
23:         Reg.SetValue(RegistryHive.LocalMachine, strRegPath, "User ID", UserID)
24:     End If

25:     If strPassword <> vbNullString Then
26:         Reg.SetValue(RegistryHive.LocalMachine, strRegPath, "Password", strPassword)
27:     End If

28:     If strServer <> vbNullString Then
29:         Reg.SetValue(RegistryHive.LocalMachine, strRegPath, "Server", strServer)
30:     End If
31:     If IntegratedSecurity = True Then
32:         Reg.SetValue(RegistryHive.LocalMachine, strRegPath, "Trusted_Connection", _
            IIf(IntegratedSecurity, "Yes", ""))
33:     End If

        'Open ODBC Data Sources key to list the new DSN in the ODBC Manager.
        'Specify the new value.
34:     strRegPath = "SOFTWARE\ODBC\ODBC.INI\" & "ODBC Data Sources\"
35:     Reg.SetValue(RegistryHive.LocalMachine, strRegPath, strDSNName, strDriverName)

36:     Return Name

    End Function
End Module

