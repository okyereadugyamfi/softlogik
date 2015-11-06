using System.Text.RegularExpressions;
using System.Diagnostics;
using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI;
using Microsoft.Win32;
using WeifenLuo;

//#Region "Imports"
//Imports System
//Imports System.Reflection
//Imports System.Data
//Imports System.Data.OleDb
//Imports System.Data.SqlClient
//Imports System.Configuration
//#End Region 'Imports

//Namespace Data.Services
//    ''' <summary>
//    ''' The collection of ADO.NET data providers that are supported by <see ref="ProviderFactory"/>.
//    ''' </summary>
//    Public Enum ProviderType
//        ''' <summary>
//        ''' The OLE DB (<see cref="System.Data.OleDb"/>) .NET data provider.
//        ''' </summary>
//        OleDb = 0
//        ''' <summary>
//        ''' The SQL Server (<see cref="System.Data.SqlClient"/>) .NET data provider.
//        ''' </summary>
//        SqlClient = 1
//        ''' <summary>
//        ''' The Oracle Data Provider for .NET (ODP.NET).
//        ''' </summary>
//        OracleClient = 2
//    End Enum

//    ''' <summary>
//    ''' The <b>ProviderFactory</b> class abstracts ADO.NET relational data providers through creator methods which return.
//    ''' the underlying <see cref="System.Data"/> interface.
//    ''' </summary>
//    ''' <remarks>
//    ''' This code was inspired by "Design an Effective Data-Access Architecture" by Dan Fox (.netmagazine, vol. 2, no. 7)
//    ''' </remarks>
//    Public Class SPDataProviderFactory

//#Region "Shared Members"
//        Private Shared _connectionTypes As Type() = New Type() {GetType(OleDbConnection), GetType(SqlConnection)}
//        Private Shared _commandTypes As Type() = New Type() {GetType(OleDbCommand), GetType(SqlCommand)}
//        Private Shared _dataAdapterTypes As Type() = New Type() {GetType(OleDbDataAdapter), GetType(SqlDataAdapter)}
//        Private Shared _dataParameterTypes As Type() = New Type() {GetType(OleDbParameter), GetType(SqlParameter)}
//        Private Shared _connectionString As String
//        Private Shared _provider As ProviderType

//#End Region

//#Region "Constructors"
//        Private Sub New()
//        End Sub

//        Shared Sub New()
//            _connectionString = ConfigurationManager.ConnectionStrings("DBConnection").ConnectionString
//            _provider = CType(System.Enum.Parse(GetType(ProviderType), ConfigurationManager.AppSettings("DataProvider")), ProviderType)
//        End Sub

//#End Region

//#Region "Properties"
//        Public Shared Property Provider() As ProviderType
//            Get
//                Return _provider
//            End Get
//            Set(ByVal value As ProviderType)
//                _provider = value
//            End Set
//        End Property

//#End Region ' Properties

//#Region "Methods"
//#Region "IDbConnection methods"

//        Public Shared Function CreateConnection() As IDbConnection
//            Dim conn As IDbConnection = Nothing
//            Dim args As Object() = {_connectionString}
//            Try
//                conn = CType(Activator.CreateInstance(_connectionTypes(CInt(Fix(_provider))), args), IDbConnection)
//            Catch e As TargetInvocationException
//                Throw New SystemException(e.InnerException.Message, e.InnerException)
//            End Try
//            Return conn
//        End Function

//#End Region

//#Region "IDbCommand methods"

//        Public Shared Function CreateCommand() As IDbCommand
//            Dim cmd As IDbCommand = Nothing
//            Try
//                cmd = CType(Activator.CreateInstance(_commandTypes(CInt(Fix(_provider)))), IDbCommand)
//            Catch e As TargetInvocationException
//                Throw New SystemException(e.InnerException.Message, e.InnerException)
//            End Try
//            Return cmd
//        End Function

//        Public Shared Function CreateCommand(ByVal cmdText As String) As IDbCommand
//            Dim cmd As IDbCommand = Nothing
//            Dim args As Object() = {cmdText}
//            Try
//                cmd = CType(Activator.CreateInstance(_commandTypes(CInt(Fix(_provider))), args), IDbCommand)
//            Catch e As TargetInvocationException
//                Throw New SystemException(e.InnerException.Message, e.InnerException)
//            End Try
//            Return cmd
//        End Function

//        Public Shared Function CreateCommand(ByVal cmdText As String, ByVal connection As IDbConnection) As IDbCommand
//            Dim cmd As IDbCommand = Nothing
//            Dim args As Object() = {cmdText, connection}
//            Try
//                cmd = CType(Activator.CreateInstance(_commandTypes(CInt(Fix(_provider))), args), IDbCommand)
//            Catch e As TargetInvocationException
//                Throw New SystemException(e.InnerException.Message, e.InnerException)
//            End Try
//            Return cmd
//        End Function

//        Public Shared Function CreateCommand(ByVal cmdText As String, ByVal connection As IDbConnection, ByVal transaction As IDbTransaction) As IDbCommand
//            Dim cmd As IDbCommand = Nothing
//            Dim args As Object() = {cmdText, connection, transaction}
//            Try
//                cmd = CType(Activator.CreateInstance(_commandTypes(CInt(Fix(_provider))), args), IDbCommand)
//            Catch e As TargetInvocationException
//                Throw New SystemException(e.InnerException.Message, e.InnerException)
//            End Try
//            Return cmd
//        End Function

//#End Region

//#Region "IDbDataParameter methods"

//        Public Shared Function CreateDataParameter() As IDbDataParameter
//            Dim param As IDbDataParameter = Nothing
//            Try
//                param = CType(Activator.CreateInstance(_dataParameterTypes(CInt(Fix(_provider)))), IDbDataParameter)
//            Catch e As TargetInvocationException
//                Throw New SystemException(e.InnerException.Message, e.InnerException)
//            End Try
//            Return param
//        End Function

//        Public Shared Function CreateDataParameter(ByVal parameterName As String, ByVal value As Object) As IDbDataParameter
//            Dim param As IDbDataParameter = Nothing
//            Dim args As Object() = {Data.Services.SPDataService.FormatParameterName(_provider, parameterName), value}
//            Try
//                param = CType(Activator.CreateInstance(_dataParameterTypes(CInt(Fix(_provider))), args), IDbDataParameter)
//            Catch e As TargetInvocationException
//                Throw New SystemException(e.InnerException.Message, e.InnerException)
//            End Try
//            Return param
//        End Function

//        Public Shared Function CreateDataParameter(ByVal parameterName As String, ByVal dataType As DbType) As IDbDataParameter
//            Dim param As IDbDataParameter = CreateDataParameter()
//            If Not param Is Nothing Then
//                param.ParameterName = Data.Services.SPDataService.FormatParameterName(_provider, parameterName)
//                param.DbType = dataType
//            End If
//            Return param
//        End Function

//        Public Shared Function CreateDataParameter(ByVal parameterName As String, ByVal dataType As DbType, ByVal size As Integer) As IDbDataParameter
//            Dim param As IDbDataParameter = CreateDataParameter()
//            If Not param Is Nothing Then
//                param.ParameterName = Data.Services.SPDataService.FormatParameterName(_provider, parameterName)
//                param.DbType = dataType
//                param.Size = size
//            End If
//            Return param
//        End Function

//        Public Shared Function CreateDataParameter(ByVal parameterName As String, ByVal dataType As DbType, ByVal size As Integer, ByVal sourceColumn As String) As IDbDataParameter
//            Dim param As IDbDataParameter = CreateDataParameter()
//            If Not param Is Nothing Then
//                param.ParameterName = Data.Services.SPDataService.FormatParameterName(_provider, parameterName)
//                param.DbType = dataType
//                param.Size = size
//                param.SourceColumn = sourceColumn
//            End If
//            Return param
//        End Function

//#End Region

//#End Region
//    End Class
//End Namespace


