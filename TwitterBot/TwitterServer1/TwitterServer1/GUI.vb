Public Class GUI


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click



        If IsNumeric(TxtBoxEntry.Text) Then
            ConvertToCoins()
        Else
            ConvertToCash()
        End If



    End Sub


    Private Sub ConvertToCoins()

        Dim Convert As New ConvertCoins()

        Dim Value As String = TxtBoxEntry.Text




        If IsNumeric(Value) Then
            TxtBoxResult.Text = Convert.ConvertToCoins(CDbl(TxtBoxEntry.Text))
        Else
            MsgBox("Value is not numeric")
            Exit Sub
        End If



    End Sub

    Private Sub ConvertToCash()
        Dim Convert As New ConvertCoins()

        Dim Value As String = TxtBoxEntry.Text

        TxtBoxResult.Text = Convert.CoinToDollarValue(Value)


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        '  Dim TWservice As New TwitterService()

        '  TWservice.SendDirectMSG()




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        '   Dim TWservice As New TwitterService()


        '  TWservice.getPin()

    End Sub
End Class