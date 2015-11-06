Imports System.Reflection
Imports System.ComponentModel

Namespace Reporting

    Public Enum SPReportFilterFieldTypes
        [General]
        [SimpleDate]
        [RangeDate]
        [Memo]
        [Custom]
    End Enum

    Public Enum SPComparisons
        <SPComparisonDescription(" Equals ", "(#1 = #2)")> Equals
        <SPComparisonDescription(" Not Equals ", "(#1 <> #2)")> NotEquals
        <SPComparisonDescription(" Less Than or Equals ", "(#1 =< #2)")> LessThanEquals
        <SPComparisonDescription(" Greater Or Equals ", "(#1 >= #2)")> GreaterThanEquals
        <SPComparisonDescription("Between ", "(BETWEEN #1 AND #2)")> Between
        <SPComparisonDescription(" Not Between ", "(NOT(BETWEEN #1 AND #2))")> NotBetween
        <SPComparisonDescription(" In ", "(IN #1)")> [In]
        <SPComparisonDescription(" Not In ", "(NOT(IN #1))")> [NotIn]
        <SPComparisonDescription(" Like ", "(LIKE #1)")> [Like]
    End Enum

#Region "SPComparison Description Attribute Class"
    <AttributeUsage(AttributeTargets.Field, AllowMultiple:=False)> _
    Public Class SPComparisonDescriptionAttribute
        Inherits System.Attribute

        Private mOperation As String
        Private mDescription As String

        Public Property Operation() As String
            Get
                Return mOperation
            End Get
            Set(ByVal Value As String)
                mOperation = Value
            End Set
        End Property
        Public Property Description() As String
            Get
                Return mDescription
            End Get
            Set(ByVal Value As String)
                mDescription = Value
            End Set
        End Property
        Public Sub New(ByVal Description As String, ByVal Operation As String)
            mOperation = Operation
            mDescription = Description
        End Sub
    End Class


    <Description("Helper Class to Retrieve Extended Enumarator Properties")> _
    Public Class SPComparisonsHelper
        Public Shared Function GetDescription(ByVal obj As Object) As String
            Dim t As Type = obj.GetType
            Dim fInfo As FieldInfo = t.GetField(System.Enum.GetName(t, obj))

            Dim attr As SPComparisonDescriptionAttribute = _
                DirectCast(fInfo.GetCustomAttributes(GetType(SPComparisonDescriptionAttribute), False)(0), _
                SPComparisonDescriptionAttribute)

            Return attr.Description
        End Function
        Public Shared Function GetOperation(ByVal obj As Object, ByVal Operand1 As String, Optional ByVal Operand2 As String = vbNullString) As String
            Dim t As Type = obj.GetType
            Dim fInfo As FieldInfo = t.GetField(System.Enum.GetName(t, obj))

            Dim attr As SPComparisonDescriptionAttribute = _
                DirectCast(fInfo.GetCustomAttributes(GetType(SPComparisonDescriptionAttribute), False)(0), _
                SPComparisonDescriptionAttribute)

            Return attr.Operation.Replace("#1", Operand1).Replace("#2", Operand2)
        End Function

        Public Shared Function GetComparisonDataList(ByVal EnumType As Type) As ArrayList
            Dim items As Array = System.Enum.GetValues(EnumType)

            Dim retItems As New ArrayList

            For Each itm As Object In items
                Dim fInfo As FieldInfo = EnumType.GetField(System.Enum.GetName(EnumType, itm))

                Dim attr As SPComparisonDescriptionAttribute = _
                    DirectCast(fInfo.GetCustomAttributes(GetType(SPComparisonDescriptionAttribute), False)(0), _
                    SPComparisonDescriptionAttribute)
                Dim newItm As New SPReportFilterOperator(attr.Description, DirectCast(itm, SPComparisons))
                retItems.Add(newItm)
            Next

            Return retItems
        End Function
    End Class
#End Region

End Namespace