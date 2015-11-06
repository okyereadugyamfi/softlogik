'#Region "Imports"
'Imports System
'Imports System.Collections.Generic
'Imports System.Text
'Imports System.Runtime.Serialization
'Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
'Imports System.Data.SqlClient
'Imports System.Data.OleDb
'Imports System.Diagnostics
'#End Region ' "Imports"

'Namespace Data.Services
'    ''' <summary>
'    ''' Data access layer exception.
'    ''' </summary>
'    Public Class SPDataException
'        Inherits BaseApplicationException
'        Public Sub New()
'            MyBase.New()
'            Initialize()
'        End Sub

'        Public Sub New(ByVal message As String)
'            MyBase.New(message)
'            Initialize()
'        End Sub

'        Public Sub New(ByVal message As String, ByVal e As Exception)
'            MyBase.New(message, e)
'            Initialize()
'        End Sub

'        Public Sub New(ByVal e As Exception)
'            MyBase.New(GeneralErrorMessage, e)
'            Initialize()
'        End Sub

'        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
'            MyBase.New(info, context)
'        End Sub

'        Protected Shared ReadOnly Property GeneralErrorMessage() As String
'            Get
'                Return "Error: Unkonwn error in the data access layer."
'            End Get
'        End Property

'        Protected Sub Initialize()
'            If TypeOf Me.InnerException Is SqlException Then
'                SetClientErrorDescription(ProviderType.SqlClient, (CType(Me.InnerException, SqlException)).Number)
'            ElseIf TypeOf Me.InnerException Is OleDbException Then
'                SetClientErrorDescription(ProviderType.OleDb, (CType(Me.InnerException, OleDbException)).ErrorCode)
'            End If
'            'else if (this.InnerException is OracleException)
'            'SetErrorNumber(ProviderType.OracleClient, ((OracleException)this.InnerException).Number);
'        End Sub

'        ''' <summary>
'        ''' Gets or sets the error number.
'        ''' </summary>
'        ''' <value>The error number.</value>
'        Public Sub SetClientErrorDescription(ByVal provider As ProviderType, ByVal errorNumber As Integer)
'            ' Set the client error description by the given error number.
'            Select Case provider
'                Case ProviderType.SqlClient
'                    Select Case errorNumber
'                        Case 17, 4060, 18456
'                            ClientErrorDescription = "Error: Cann't connect to Database"

'                        Case 547
'                            ClientErrorDescription = "Error: Your request wasn't complete because the chosen row is connected(foreign-key) to another row in the system."

'                        Case 2601, 2627
'                            ClientErrorDescription = "Error: Your request wasn't complete because the record is already exists in the system."

'                        Case Else
'                            ClientErrorDescription = GeneralErrorMessage
'                    End Select

'                Case Else
'                    Debug.Fail("This provider(" & provider.ToString() & ") isn't supported yet")
'                    ClientErrorDescription = GeneralErrorMessage
'            End Select
'        End Sub
'    End Class
'End Namespace

