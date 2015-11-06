Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Diagnostics

Namespace Data.Services
    Friend Class SPDataTracer
        Private Shared ReadOnly tracerSwitch As TraceSwitch

        Private Sub New()
        End Sub
        Shared Sub New()
            tracerSwitch = New TraceSwitch("TraceSwitch", "application trace switch")
        End Sub

        Public Shared Sub Write(ByVal cmd As IDbCommand)
            If tracerSwitch.Level >= TraceLevel.Verbose Then
                Trace.WriteLine(GetCommandDescription(cmd))
            End If
        End Sub

        Public Shared Sub Write(ByVal err As Exception)
            If tracerSwitch.Level >= TraceLevel.Error Then
                Trace.WriteLine(GetExceptionDescription(err))
            End If
        End Sub

        Private Shared Function GetCommandDescription(ByVal cmd As IDbCommand) As String
            Dim sb As StringBuilder = New StringBuilder(300)

            sb.Append(Constants.vbCrLf)
            sb.Append("-- CommandText: " & Constants.vbCrLf)
            sb.Append(cmd.CommandText & Constants.vbCrLf)
            sb.Append("-- CommandType: " & Constants.vbCrLf)
            sb.Append(cmd.CommandType.ToString() & Constants.vbCrLf)
            sb.Append("-- Parameters: " & Constants.vbCrLf)

            Dim i As Integer = 0
            Do While i < cmd.Parameters.Count
                Dim parmater As IDataParameter = CType(cmd.Parameters(i), IDataParameter)
                sb.Append(i & ". Name: " & parmater.ParameterName & ", Value: " & parmater.Value.ToString & ", Type: " & parmater.DbType & ", Direction: " & parmater.Direction & "." & Constants.vbCrLf)
                i += 1
            Loop

            sb.Append(Constants.vbCrLf)
            Return sb.ToString()
        End Function

        Private Shared Function GetExceptionDescription(ByVal e As Exception) As String
            Dim sb As StringBuilder = New StringBuilder(200)

            sb.Append("Error: " & e.Message).Append(Constants.vbCrLf)
            sb.Append("Type: " & e.GetType().FullName).Append(Constants.vbCrLf)
            sb.Append("Source: " & e.Source).Append(Constants.vbCrLf)
            sb.Append("Target: " & e.TargetSite.ToString).Append(Constants.vbCrLf)
            sb.Append("Stack: " & e.StackTrace).Append(Constants.vbCrLf)

            e = e.InnerException
            Do While Not e Is Nothing
                sb.Append(" ---------- Inner Exception: ---------- ").Append(Constants.vbCrLf)
                sb.Append(GetExceptionDescription(e))
                e = e.InnerException
            Loop

            Return sb.ToString()
        End Function
    End Class
End Namespace

