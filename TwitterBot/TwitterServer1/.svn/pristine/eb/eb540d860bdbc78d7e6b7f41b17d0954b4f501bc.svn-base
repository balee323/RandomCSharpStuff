Public Class ConvertCoins

    Private QCount As Integer = 0
    Private DCount As Integer = 0
    Private NCount As Integer = 0
    Private PCount As Integer = 0


    Public Function ConvertToCoins(DollarValue As Double) As String

        'TODO -- round Initial dollar value (DOnE)

        Dim CoinValue As String = ""

        DollarValue = Math.Round(DollarValue, 2)

        If DollarValue > 100000.0 And DollarValue < 9999999.0 Then
            Return ("Value is large and will take a while to convert.")
        ElseIf DollarValue > 9999999.0 Then
            Return ("Value is too large and will exceed value limits for integer.")

        End If


        While DollarValue >= 0.25
            DollarValue = DollarValue - 0.25
            QCount = QCount + 1
            DollarValue = Math.Round(DollarValue, 2)
        End While

        While DollarValue >= 0.1
            DollarValue = DollarValue - 0.1
            DCount = DCount + 1
            DollarValue = Math.Round(DollarValue, 2)
        End While

        While DollarValue >= 0.05
            DollarValue = DollarValue - 0.05
            NCount = NCount + 1
            DollarValue = Math.Round(DollarValue, 2)
        End While

        While DollarValue >= 0.01
            DollarValue = DollarValue - 0.01
            PCount = PCount + 1
            DollarValue = Math.Round(DollarValue, 2)
        End While

        If DollarValue < 0.01 And DollarValue > 0 Then
            MsgBox("Less than 1 penny remains")
        End If

        CoinValue = "Q:" & QCount.ToString & " D:" & DCount.ToString & " N:" & NCount.ToString & " P:" & PCount.ToString

        Return CoinValue
    End Function



    Public Function CoinToDollarValue(Coins As String) As Double

        Coins = Coins.ToUpper()

        Dim DollarValue As Double = 0.0

        'TODO-- create code to keep coin types together instead of relying on exact order on data entry
        Dim DirtyQuater As String = ""
        Dim DirtyDime As String = ""
        Dim DirtyNickel As String = ""
        Dim DirtyPenny As String = ""



        Dim tempStr(4) As String

        Dim test As Integer = tempStr.Length

        Try
            tempStr = Coins.Split("Q", "D", "N", "P")


            Dim i As Integer = 0
            While i < tempStr.Count
                Dim value As String = tempStr(i)
                tempStr(i) = CleanCoins(value)
                i = i + 1
            End While

            'TODO -- Lack of validation here... consider re-working this. Error will occur if less than 5 elements are poplulated 
            If tempStr.Count < 1 Then
                Return 0.0
            Else
                QCount = CInt(tempStr(1))
                DCount = CInt(tempStr(2))
                NCount = CInt(tempStr(3))
                PCount = CInt(tempStr(4))

                DollarValue = ((0.25) * QCount) + ((0.1) * DCount) + ((0.05) * NCount) + ((0.01) * PCount)
            End If
        Catch ex As Exception


            Return (-1)
            '  Exit Try


        End Try


        Return DollarValue
    End Function

    Private Function CleanCoins(dirtyCoin As String) As String
        Dim cleanCoin As String = ""

        If dirtyCoin = "" Then
            Return ""
        End If


        If dirtyCoin.Substring(0, 1) = ":" Or dirtyCoin.Substring(0, 1) = "" Then

            If dirtyCoin.Length > 1 Then
                dirtyCoin = dirtyCoin.Substring(1, dirtyCoin.Length - 1)
            End If

        End If

        If dirtyCoin.Substring(dirtyCoin.Length) = ":" Or dirtyCoin.Substring(dirtyCoin.Length) = "" Then

            If dirtyCoin.Length > 1 Then
                dirtyCoin = dirtyCoin.Substring(0, dirtyCoin.Length - 1)
            End If


        End If

        If IsNumeric(dirtyCoin) Then
            cleanCoin = dirtyCoin
        Else
            cleanCoin = -1
        End If


        Return cleanCoin
    End Function




End Class
