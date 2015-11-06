Imports System.ComponentModel

Namespace Reporting
#Region "Report Filter Classes"
    Public Class SPReportFilter

        Private _Type As SPReportFilterFieldTypes = SPReportFilterFieldTypes.General
        Private _DisplayMember As String = String.Empty
        Private _ValueMember As String = String.Empty
        Private _Operation As String = String.Empty
        Private _OperationText As String = String.Empty
        Private _Value As Object = Nothing

#Region "Properties"
        Protected Friend ReadOnly Property [Type]() As SPReportFilterFieldTypes
            Get
                Return _Type
            End Get
        End Property
        Protected Friend Property Operation() As String
            Get
                Return _Operation
            End Get
            Set(ByVal value As String)
                _Operation = value
            End Set
        End Property
        Public Property OperationText() As String
            Get
                Return _OperationText
            End Get
            Set(ByVal value As String)
                _OperationText = value
            End Set
        End Property
        Public Property DisplayMember() As String
            Get
                Return _DisplayMember
            End Get
            Set(ByVal value As String)
                _DisplayMember = value
            End Set
        End Property
        Public Property ValueMember() As String
            Get
                Return _ValueMember
            End Get
            Set(ByVal value As String)
                _ValueMember = value
            End Set
        End Property
        Protected Friend Property Value() As Object
            Get
                Return _Value
            End Get
            Set(ByVal value As Object)
                _Value = value
            End Set
        End Property
#End Region

        Public Sub New(ByVal DisplayMember As String, ByVal ValueMember As String, ByVal [Type] As SPReportFilterFieldTypes)
            Me._DisplayMember = DisplayMember
            Me._ValueMember = ValueMember
            Me._Type = [Type]
        End Sub

        Public Overrides Function ToString() As String
            Return Me._Operation.Replace("#ValueMember#", Me._ValueMember)
        End Function

        Public Function ToFormattedString() As String
            Return Me._OperationText.Replace("#DisplayMember#", Me._DisplayMember)
        End Function
    End Class

    <DataObject()> _
    Public Class SPReportFilterCollection
        Inherits List(Of SPReportFilter)


        Public Overloads Function Add(ByVal DisplayMember As String, ByVal ValueMember As String, ByVal [Type] As SPReportFilterFieldTypes) As SPReportFilter
            Dim newItem As SPReportFilter = New SPReportFilter(DisplayMember, ValueMember, [Type])
            Try
                Me.Add(newItem)
            Catch ex As Exception
            End Try
            Return newItem
        End Function
        Default Public Overloads ReadOnly Property Item(ByVal DisplayMember As String) As SPReportFilter
            Get
                For Each itm As SPReportFilter In Me
                    If itm.DisplayMember = DisplayMember Then
                        Return itm
                    End If
                Next

                Return Nothing
            End Get
        End Property
        Public Overloads Sub Remove(ByVal DisplayMember As String)
            On Error Resume Next
            Me.Remove(Me.Item(DisplayMember))
        End Sub

        Public Overrides Function ToString() As String
            Dim strFilterQuery As String = vbNullString

            For Each qry As SPReportFilter In Me
                strFilterQuery &= qry.ToString
                strFilterQuery &= " AND "
            Next qry

            If strFilterQuery.Trim.EndsWith("AND") Then
                strFilterQuery = Mid$(Trim$(strFilterQuery), 1, Len(Trim$(strFilterQuery)) - 3)
            End If

            Return strFilterQuery
        End Function

    End Class

#End Region

#Region "Report Group Classes"
    <Description("Specify a Grouping used in a Report.")> _
    Public Class SPReportGrouping

        Private _DisplayMember As String = String.Empty
        Private _ValueMember As String = String.Empty

        Public Property DisplayMember() As String
            Get
                Return _DisplayMember
            End Get
            Set(ByVal value As String)
                _DisplayMember = value
            End Set
        End Property


        Public Sub New(ByVal DisplayMember As String, ByVal ValueMember As String)
            Me._DisplayMember = DisplayMember
            Me._ValueMember = ValueMember
        End Sub

    End Class
    <Description("Specify a List of Groupings used in a Report.")> _
    Public Class SPReportGroupingCollection
        Inherits List(Of SPReportGrouping)

        Public Overloads Function Add(ByVal DisplayMember As String, ByVal ValueMember As String) As SPReportGrouping
            Dim newItem As New SPReportGrouping(DisplayMember, ValueMember)
            Try
                Me.Add(newItem)
            Catch ex As Exception
            End Try
            Return newItem
        End Function
        Default Public Overloads ReadOnly Property Item(ByVal DisplayMember As String) As SPReportGrouping
            Get
                For Each itm As SPReportGrouping In Me
                    If itm.DisplayMember = DisplayMember Then
                        Return itm
                    End If
                Next

                Return Nothing
            End Get
        End Property

        Public Overloads Sub Remove(ByVal DisplayMember As String)
            On Error Resume Next
            Me.Remove(Me.Item(DisplayMember))
        End Sub

    End Class
#End Region

#Region "Report Parameter Classes"
    Public Class SPReportParameter

        Private _Name As String = String.Empty
        Private _Value As Object = Nothing

        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        Public Property Value() As Object
            Get
                Return _Value
            End Get
            Set(ByVal value As Object)
                _Value = value
            End Set
        End Property

        Public Sub New(ByVal Name As String, ByVal Value As Object)
            Me._Name = Name
            Me._Value = Value
        End Sub

    End Class
    Public Class SPReportParameterCollection
        Inherits List(Of SPReportParameter)

        Public Overloads Function Add(ByVal Name As String, ByVal Value As Object) As SPReportParameter
            Dim newItem As New SPReportParameter(Name, Value)
            Try
                Me.Add(newItem)
            Catch ex As Exception
            End Try
            Return newItem
        End Function

        Default Public Overloads ReadOnly Property Item(ByVal Name As String) As SPReportParameter
            Get
                For Each itm As SPReportParameter In Me
                    If itm.Name = Name Then
                        Return itm
                    End If
                Next

                Return Nothing
            End Get
        End Property
        Public Overloads Sub Remove(ByVal Name As String)
            On Error Resume Next
            Me.Remove(Me.Item(Name))
        End Sub
    End Class
#End Region


#Region "Report Filter Operator Classes"
    Public Class SPReportFilterOperator

        Private _Name As String = String.Empty
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Private _Value As SPComparisons = SPComparisons.Equals

        Public Property Value() As SPComparisons
            Get
                Return _Value
            End Get
            Set(ByVal value As SPComparisons)
                _Value = value
            End Set
        End Property

        Public Sub New()

        End Sub

        Public Sub New(ByVal Name As String, ByVal Value As SPComparisons)
            Me._Name = Name
            Me._Value = Value
        End Sub
    End Class
#End Region
End Namespace


