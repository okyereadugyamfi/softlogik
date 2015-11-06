Namespace Data

#Region "Data Stream Component"
    Public Class SQLDataStore
        Implements ISPDataStore, IDisposable


        Private m_trnTransaction As SqlTransaction
        Private m_conConnection As SqlConnection
        Private disposedValue As Boolean = False        ' To detect redundant calls

        Public Sub New()
            m_conConnection = Nothing
        End Sub
        Public Sub New(ByRef AltConnection As SqlConnection)
            m_conConnection = AltConnection
        End Sub

        Public Function AbortTransaction() As Boolean Implements ISPDataStore.AbortTransaction
            Try
                If m_trnTransaction IsNot Nothing Then
                    m_trnTransaction.Rollback()
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function BeginTransaction() As Boolean Implements ISPDataStore.BeginTransaction
            Try
                If m_trnTransaction Is Nothing Then
                    If m_conConnection Is Nothing Then
                        m_conConnection = New SqlConnection(NewConnection)
                    End If

                    If m_conConnection.State = ConnectionState.Closed Then m_conConnection.Open()
                    m_trnTransaction = m_conConnection.BeginTransaction
                End If

                Return True
            Catch ex As SqlException
                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function CommitTransaction() As Boolean Implements ISPDataStore.CommitTransaction
            Try
                If m_trnTransaction IsNot Nothing Then
                    m_trnTransaction.Commit()
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ExecuteCommand(ByVal ExecuteText As String, Optional ByRef Params As SPDataParamCollection = Nothing) As Object Implements ISPDataStore.ExecuteCommand
            Dim stMatch As StatementPatternType = StatementMatch(ExecuteText.ToUpper)

            Select Case stMatch
                Case StatementPatternType.InsertStatement, _
                StatementPatternType.SelectStatement, _
                StatementPatternType.UpdateStatement, _
                StatementPatternType.DeleteStatement
                    Return ExecuteSQL(ExecuteText, Params, m_conConnection) 'DML Statement

                Case Else
                    Return ExecuteSP(ExecuteText, Params, m_conConnection) 'Stored Procedure
            End Select
        End Function
        Public Function GetReader(ByVal ExecuteText As String, Optional ByRef Params As SPDataParamCollection = Nothing) As IDataReader Implements ISPDataStore.GetReader
            Dim stMatch As StatementPatternType = StatementMatch(ExecuteText.ToUpper)

            Select Case stMatch
                Case StatementPatternType.SelectStatement
                    Return ExecuteSQL_DR(ExecuteText, Params, m_conConnection) 'Select Statement
                Case StatementPatternType.InsertStatement, _
                    StatementPatternType.UpdateStatement, _
                    StatementPatternType.DeleteStatement
                    Throw New Exception("Invalid argument encountered in ExecuteText.")
                Case Else
                    Return ExecuteSP_DR(ExecuteText, Params, m_conConnection) 'Stored Procedure
            End Select
        End Function

        Public Function GetString(ByVal ExecuteText As String, Optional ByRef Params As SPDataParamCollection = Nothing) As String Implements ISPDataStore.GetString
            Dim stMatch As StatementPatternType = StatementMatch(ExecuteText.ToUpper)

            Select Case stMatch
                Case StatementPatternType.SelectStatement
                    'Return ExecuteSQL_Str(ExecuteText, Params, m_conConnection) 'Select Statement
                    Return vbNullString
                Case StatementPatternType.InsertStatement, _
                    StatementPatternType.UpdateStatement, _
                    StatementPatternType.DeleteStatement
                    Throw New Exception("Invalid argument encountered in ExecuteText.")
                Case Else
                    Return ExecuteSP_Str(ExecuteText, Params, m_conConnection) 'Stored Procedure
            End Select
        End Function

        Public Function GetTable(ByVal ExecuteText As String, Optional ByRef Params As SPDataParamCollection = Nothing, Optional ByVal Direct As Boolean = False) As System.Data.DataTable Implements ISPDataStore.GetTable
            Dim stMatch As StatementPatternType = StatementMatch(ExecuteText.ToUpper)

            Select Case stMatch
                Case StatementPatternType.SelectStatement
                    Return ExecuteSQL_DT(ExecuteText, Params, m_conConnection) 'Select Statement
                Case StatementPatternType.InsertStatement, _
                    StatementPatternType.UpdateStatement, _
                    StatementPatternType.DeleteStatement
                    Throw New Exception("Invalid argument encountered in ExecuteText.")
                Case Else
                    Return ExecuteSP_DT(ExecuteText, Params, m_conConnection, Direct) 'Stored Procedure
            End Select
        End Function

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free unmanaged resources when explicitly called
                End If

                m_trnTransaction.Dispose()
                m_trnTransaction = Nothing
                m_conConnection.Dispose()
                m_conConnection = Nothing
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
#End Region

#Region "Support"
    Module DataSupport

        Public Function ExecuteSP_Str(ByVal ExecuteText As String, ByRef Params As SPDataParamCollection, ByRef AltConnection As SqlConnection) As String
            Dim objCmd As SqlCommand = New SqlCommand(ExecuteText, BuildConnection(AltConnection))
            Dim drData As IDataReader
            objCmd.CommandType = CommandType.StoredProcedure

            objCmd.Connection.Open()
            ProcessParams(objCmd, Params) 'Parse Parameters

            Using objCmd
                drData = objCmd.ExecuteReader(CommandBehavior.CloseConnection)
            End Using

            If drData IsNot Nothing Then
                drData.Read()
                Try
                    Return drData.GetString(0)
                Catch ex As Exception
                    Return vbNullString
                End Try
            End If
            Return vbNullString
        End Function

        Public Function ExecuteSP(ByVal ExecuteText As String, ByRef Params As SPDataParamCollection, ByRef AltConnection As SqlConnection) As Object
            Dim objCmd As SqlCommand = New SqlCommand(ExecuteText, BuildConnection(AltConnection))
            objCmd.CommandType = CommandType.StoredProcedure

            objCmd.Connection.Open()
            ProcessParams(objCmd, Params) 'Parse Parameters

            Using objCmd
                Try
                    Return objCmd.ExecuteScalar()
                Catch ex As Exception
                    Throw
                End Try

            End Using

        End Function
        Public Function ExecuteSP_DS(ByVal ExecuteText As String, ByRef Params As SPDataParamCollection, ByRef AltConnection As SqlConnection) As DataSet

            Dim daExecuteSP As SqlDataAdapter = New SqlDataAdapter()
            Dim dsExecuteSP As DataSet = New DataSet
            Dim objCmd As SqlCommand = New SqlCommand(ExecuteText, BuildConnection(AltConnection))

            objCmd.CommandType = CommandType.StoredProcedure

            ProcessParams(objCmd, Params) 'Parse Parameters

            With daExecuteSP
                .SelectCommand = objCmd
                .Fill(dsExecuteSP)
            End With
            Return dsExecuteSP

            daExecuteSP.Dispose()
            daExecuteSP = Nothing
            objCmd.Dispose()
            objCmd = Nothing

        End Function
        Public Function ExecuteSP_DT(ByVal ExecuteText As String, _
        ByRef Params As SPDataParamCollection, _
        ByRef AltConnection As SqlConnection, Optional ByVal Direct As Boolean = False) As DataTable

            Dim dsExecuteSP As DataTable = New DataTable
            Dim objCmd As SqlCommand = New SqlCommand(ExecuteText, BuildConnection(AltConnection))
            Dim taData As SqlDataAdapter = New SqlDataAdapter(objCmd)

            If Direct Then
                objCmd.CommandType = CommandType.Text
                objCmd.CommandText = "SELECT * FROM " & ExecuteText
            Else
                objCmd.CommandType = CommandType.StoredProcedure
            End If

            objCmd.Connection.Open()
            ProcessParams(objCmd, Params) 'Parse Parameters
            taData.Fill(dsExecuteSP)
            objCmd.Connection.Close()
            Return dsExecuteSP

            objCmd.Dispose()
            objCmd = Nothing

        End Function
        Public Function ExecuteSP_DR(ByVal ExecuteText As String, ByRef Params As SPDataParamCollection, ByRef AltConnection As SqlConnection) As SqlDataReader
            Dim objCmd As SqlCommand = New SqlCommand(ExecuteText, BuildConnection(AltConnection))

            objCmd.CommandType = CommandType.StoredProcedure

            objCmd.Connection.Open()
            ProcessParams(objCmd, Params) 'Parse Parameters

            Using objCmd
                Return objCmd.ExecuteReader(CommandBehavior.CloseConnection)
            End Using
        End Function

        Public Function ExecuteSQL(ByVal ExecuteText As String, ByRef Params As SPDataParamCollection, ByRef AltConnection As SqlConnection) As Object
            Dim objCmd As SqlCommand = New SqlCommand(ExecuteText, BuildConnection(AltConnection))

            objCmd.CommandType = CommandType.Text

            ProcessParams(objCmd, Params) 'Parse Parameters

            Return objCmd.ExecuteScalar
            objCmd.Dispose()
            objCmd = Nothing
        End Function
        Public Function ExecuteSQL_DS(ByVal ExecuteText As String, ByRef Params As SPDataParamCollection, ByRef AltConnection As SqlConnection) As DataSet

            Dim daExecuteSP As SqlDataAdapter = New SqlDataAdapter()
            Dim dsExecuteSP As DataSet = New DataSet
            Dim objCmd As SqlCommand = New SqlCommand(ExecuteText, BuildConnection(AltConnection))

            objCmd.CommandType = CommandType.Text

            ProcessParams(objCmd, Params) 'Parse Parameters

            With daExecuteSP
                .SelectCommand = objCmd
                .Fill(dsExecuteSP)
            End With
            Return dsExecuteSP

            daExecuteSP.Dispose()
            daExecuteSP = Nothing
            objCmd.Dispose()
            objCmd = Nothing

        End Function
        Public Function ExecuteSQL_DT(ByVal ExecuteText As String, ByRef Params As SPDataParamCollection, ByRef AltConnection As SqlConnection) As DataTable

            Dim daExecuteSP As SqlDataAdapter = New SqlDataAdapter()
            Dim dsExecuteSP As DataSet = New DataSet
            Dim objCmd As SqlCommand = New SqlCommand(ExecuteText, BuildConnection(AltConnection))

            objCmd.CommandType = CommandType.Text

            ProcessParams(objCmd, Params) 'Parse Parameters

            With daExecuteSP
                .SelectCommand = objCmd
                .Fill(dsExecuteSP)
            End With
            Return dsExecuteSP.Tables(0)

            daExecuteSP.Dispose()
            daExecuteSP = Nothing
            objCmd.Dispose()
            objCmd = Nothing

        End Function

        Public Function ExecuteSQL_DR(ByVal ExecuteText As String, ByRef Params As SPDataParamCollection, ByRef AltConnection As SqlConnection) As SqlDataReader
            Dim objCmd As SqlCommand = New SqlCommand(ExecuteText, BuildConnection(AltConnection))

            objCmd.CommandType = CommandType.Text

            ProcessParams(objCmd, Params) 'Parse Parameters

            objCmd.Connection.Open()
            Using objCmd
                Return objCmd.ExecuteReader(CommandBehavior.CloseConnection)
            End Using

            Return objCmd.ExecuteReader
            objCmd.Dispose()
            objCmd = Nothing
        End Function

#Region "Private Procedures"

        Friend Function NewConnection() As String
            Dim strConnection As String = vbNullString

            Try
                strConnection = My.Settings.DBConnection
            Catch ex As Exception
            End Try


            Return strConnection
        End Function
        Private Function BuildConnection(ByRef AltConnection As SqlConnection) As SqlConnection
            If AltConnection Is Nothing Then
                Return New SqlConnection(NewConnection)
            Else
                Return AltConnection
            End If
        End Function
        Private Function ProcessParams(ByRef SourceCommand As SqlCommand, ByRef SourceParams As SPDataParamCollection) As Boolean
            Dim boolFoundParam As Boolean = False

            Try
                Try
                    If SourceCommand.Connection.State = ConnectionState.Closed Then
                        SourceCommand.Connection.Open()
                    End If
                    SqlCommandBuilder.DeriveParameters(SourceCommand)
                Catch ex As Exception
                End Try

                For Each targetParam As SPDataParam In SourceParams
                    boolFoundParam = False
                    For Each sourceParam As SqlParameter In SourceCommand.Parameters
                        If sourceParam.ParameterName.ToUpper = targetParam.Name.ToUpper Then
                            sourceParam.Value = targetParam.Value
                            boolFoundParam = True
                            Exit For
                        End If
                    Next

                    'if not found in the source list add it
                    If boolFoundParam = False Then
                        SourceCommand.Parameters.Add(targetParam)
                    End If
                Next
            Catch ex As Exception
            End Try

        End Function

#End Region
    End Module

    Module RegExpressions

        Public Enum StatementPatternType
            None = 0
            InsertStatement
            SelectStatement
            UpdateStatement
            DeleteStatement
        End Enum
        'Pattern Matching for Stored Procs & Select Statements
        Public Const PkSelectStatementPattern As String = "^(.*)(\s*)SELECT\s(.*)\sFROM(.*)"
        Public Const PkUpdateStatementPattern As String = "^(.*)(\s*)UPDATE\s(.*)\sSET\s(.*)"
        Public Const PkInsertStatementPattern As String = "^(.*)(\s*)INSERT\s(.*)\sVALUES(\s*)[(](.*)[)]$"
        Public Const PkDeleteStatementPattern As String = "^(.*)(\s*)DELETE\s(.*)\s(.*)"

        Public Function StatementMatch(ByVal Expression As String) As StatementPatternType
            If Regex.Match(Expression, PkInsertStatementPattern).Success Then
                Return StatementPatternType.InsertStatement
            ElseIf Regex.Match(Expression, PkSelectStatementPattern).Success Then
                Return StatementPatternType.InsertStatement
            ElseIf Regex.Match(Expression, PkUpdateStatementPattern).Success Then
                Return StatementPatternType.InsertStatement
            ElseIf Regex.Match(Expression, PkDeleteStatementPattern).Success Then
                Return StatementPatternType.InsertStatement
            Else
                Return StatementPatternType.None
            End If
        End Function

    End Module
#End Region

End Namespace


