Namespace UI
    Public Module SPDataFormats

        Public Sub CurrencyFormat(ByVal sender As Object, ByVal e As ConvertEventArgs)
            If TypeOf e.Value Is System.DBNull Then
                Return
            End If

            e.Value = (Convert.ToDouble(e.Value)).ToString("C")
        End Sub

        Public Sub PercentFormat(ByVal sender As Object, ByVal e As ConvertEventArgs)
            If TypeOf e.Value Is System.DBNull Then
                Return
            End If

            Dim percentValue As Double = Convert.ToDouble(e.Value)
            percentValue = percentValue / 100
            e.Value = percentValue.ToString("P0")
        End Sub

        Public Sub DateFormat(ByVal sender As Object, ByVal e As ConvertEventArgs)
            If TypeOf e.Value Is System.DBNull Then
                Return
            End If

            e.Value = Convert.ToDateTime(e.Value).ToShortDateString()
        End Sub
    End Module
End Namespace

