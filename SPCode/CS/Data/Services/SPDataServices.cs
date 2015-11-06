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

//Option Strict Off

//#Region "Imports"
//Imports System
//Imports System.Data
//Imports System.Diagnostics
//Imports System.Text
//#End Region ' "Imports"

//Namespace Data.Services
//#Region "Delegates"

//    Public Delegate Function ReaderHandler(Of T)(ByVal reader As IDataReader) As T

//    Public Delegate Function CommandHandler(Of T)(ByVal cmd As IDbCommand) As T

//#End Region ' Delegates

//    ''' <author>Okyere Adu-Gyamfi</author>
//    ''' <date>04.04.2007</date>
//    ''' <summary>
//    ''' Helper class for Data Access
//    ''' </summary>
//    Public Class SPDataService

//        ''' <summary>
//        ''' Simple command executer "design pattern".
//        ''' </summary>
//        ''' <typeparam name="T">The type to return</typeparam>
//        ''' <param name="cmd">The command</param>
//        ''' <param name="handler">The handler which will recieve the open command and handle it (as required)</param>
//        ''' <returns>A generic defined result, according to the handler choice</returns>
//        Public Shared Function ExecuteCommand(Of T)(ByVal cmd As IDbCommand, ByVal handler As CommandHandler(Of T)) As T
//            Try
//                Using conn As IDbConnection = SPDataProviderFactory.CreateConnection()
//                    cmd.Connection = conn

//                    ' Trace the query & parameters - dirty tracer for example purpose only
//                    SPDataTracer.Write(cmd)

//                    conn.Open()

//                    Return handler(cmd)
//                End Using '"using" will close the connection even in case of exception.
//            Catch err As Exception
//                ' Trace the exception into the same log - dirty tracer for example purpose only
//                SPDataTracer.Write(err)

//                Throw WrapException(err)
//            End Try
//        End Function

//        ''' <summary>
//        ''' Simple command executer "design pattern".
//        ''' </summary>
//        ''' <typeparam name="T">The type to return</typeparam>
//        ''' <param name="cmd">The command</param>
//        ''' <param name="handler">The handler which will recieve the open command and handle it (as required)</param>
//        ''' <param name="isCommitable">True if the command(transaction) needs to be commited\rollback; False otherwise.</param>
//        ''' <returns>A generic defined result, according to the handler choice</returns>
//        Public Shared Function ExecuteCommand(Of T)(ByVal cmd As IDbCommand, ByVal handler As CommandHandler(Of T), ByVal isCommitable As Boolean) As T
//            Return ExecuteCommand(Of T)(cmd, handler)
//        End Function


//        ''' <summary>
//        ''' Execute the db command as reader and parse it via the given handler.
//        ''' </summary>
//        ''' <typeparam name="T">The type to return after parsing the reader.</typeparam>
//        ''' <param name="cmd">The command to execute</param>
//        ''' <param name="handler">The handler which will parse the reader</param>
//        ''' <returns>A generic defined result, according to the handler choice</returns>
//        Public Shared Function ExecuteReader(Of T)(ByVal cmd As IDbCommand, ByVal handler As ReaderHandler(Of T)) As T
//            Return SPDataService.ExecuteCommand(Of T)(cmd, AddressOf fReaderHandler)
//        End Function

//        Private Shared Function fReaderHandler(Of T)(ByVal liveCommand As IDbCommand) As T
//            Dim r As IDataReader = CType(liveCommand.ExecuteReader(), System.Data.IDataReader)
//            Return handler.Invoke(r)
//        End Function


//        ''' <summary>
//        ''' Execute the db command in "NonQuery mode".
//        ''' </summary>
//        ''' <param name="cmd">The command to parse</param>
//        ''' <returns>Affected rows number</returns>
//        Public Shared Function ExecuteNonQuery(ByVal cmd As IDbCommand) As Integer
//            Return Data.Services.SPDataService.ExecuteCommand(Of Integer)(cmd, AddressOf fCommandHandlerDelegate)
//        End Function

//        Private Shared Function fCommandHandlerDelegate(ByVal liveCommand As IDbCommand) As Integer
//            Return liveCommand.ExecuteNonQuery()
//        End Function


//        ''' <summary>
//        ''' Execute the db command in "Scalar mode".
//        ''' </summary>
//        ''' <typeparam name="T">The type to return after parsing the reader.</typeparam>
//        ''' <param name="cmd">The command to execute</param>
//        ''' <returns>A geeneric defined result, according to the handler choice</returns>
//        Public Shared Function ExecuteScalar(Of T)(ByVal cmd As IDbCommand) As T
//            'TODO: INSTANT VB TODO TASK: Anonymous methods are not converted by Instant VB:
//			Return DalServices.ExecuteCommand(Of T)(cmd, delegate(IDbCommand liveCommand)
//            Return CType(liveCommand.ExecuteScalar(), T)
//			   )
//        End Function

//        ''' <summary>
//        ''' Wraps the exception with DalException.
//        ''' </summary>
//        ''' <param name="e">The original exception.</param>
//        ''' <returns>DALException which wraps the original exception.</returns>
//        Private Shared Function WrapException(ByVal e As Exception) As DalException
//            Return New DalException(e)
//        End Function

//        ''' <summary>
//        ''' Format a given parameter name according to its provider type.
//        ''' </summary>
//        ''' <param name="provider">The provider type</param>
//        ''' <param name="parameterName">Parameter name</param>
//        ''' <returns>Formatted parameter name</returns>
//        Public Shared Function FormatParameterName(ByVal provider As ProviderType, ByVal parameterName As String) As String
//            ' Cleanup
//            parameterName = parameterName.Replace("@", "").Replace(":", "").Replace("?", "")

//            Select Case provider
//                Case ProviderType.OleDb
//                    Debug.WriteLine("The parameter name """ & parameterName & """ will not be used")
//                    Return "?"
//                Case ProviderType.SqlClient
//                    Return "@" & parameterName
//                Case ProviderType.OracleClient
//                    Return ":" & parameterName

//                Case Else
//                    Throw New ArgumentException("Not supported provider in FormatParameterName method", "provider")
//            End Select
//        End Function
//    End Class
//End Namespace



