Module Analysis_04
    '=====================================================================
    '                       Analyse_04
    ' Einstieg: Im Gegensatz zu Analye_01 wird zuerst gewartet, bis
    '           bis der Kurs von unten durch den GS sticht.
    ' Wenn der Kurs von unten durch den SMA sticht, wird gekauft.
    ' Wenn der Kurs um x% gestiegen ist, wird verkauft
    ' Wenn der Kurs von oben unter den SMA fällt, wird auch verkauft.
    ' InvestmentStart: Der Index im History file
    ' StartAccount: Die Investitionssumme
    '=====================================================================
    Public Sub Analyse_04(InvestmentStart As Integer, StartAccount As Double, PercentageLimit As Double)
        Dim idx As Integer
        Dim State As Integer
        Dim CostFactor As Double
        Dim Percentage As Double

        CostFactor = 0.9926
        '    CostFactor = 0.991

        idx = 0
        State = 0

        If Not ArrayValid(ChartArray) Then
            ' Array ist nicht dimensioniert
            Exit Sub
        End If

        While idx <= UBound(ChartArray)
            Select Case State
                Case 0
                    ' no investment before InvestmentStart
                    If idx >= InvestmentStart Then
                        ChartArray(idx).Account = 0
                        ChartArray(idx).Trend = "0"
                        State = 5
                    Else
                        ChartArray(idx).Account = 0
                        ChartArray(idx).Trend = "0"
                    End If

                Case 5
                    ' share price under GD now
                    If ChartArray(idx).Distance <= 0 Then
                        ChartArray(idx).Account = 0
                        ChartArray(idx).Trend = "5:wait"
                        State = 10
                        ' wait until share price under GD
                    Else
                        ChartArray(idx).Account = 0
                        ChartArray(idx).Trend = "5: wait"
                    End If
                Case 10
                    ' wait until share price is over GD again the first time
                    '*** buy now
                    If ChartArray(idx).Distance > 0 Then
                        StartSharePrice = ChartArray(idx).Value
                        ChartArray(idx).Account = (ChartArray(idx).Value / StartSharePrice) * StartAccount
                        ' Remove transfer costs
                        ChartArray(idx).Account = ChartArray(idx).Account * CostFactor
                        ChartArray(idx).Trend = "10: Rise"
                        State = 20
                    Else
                        ChartArray(idx).Account = 0
                        ChartArray(idx).Trend = "10: wait"
                    End If
                Case 20
                    Percentage = (ChartArray(idx).Value - StartSharePrice) / StartSharePrice

                    ' if share price falls under GD again
                    If ChartArray(idx).Distance <= 0 Then
                        ChartArray(idx).Account = (ChartArray(idx).Value / StartSharePrice) * StartAccount
                        ' Remove transfer costs
                        ChartArray(idx).Account = ChartArray(idx).Account * CostFactor
                        ChartArray(idx).Trend = "20: Hold"
                        State = 30
                        'PercentageLimit is reached
                    ElseIf Percentage > PercentageLimit Then
                        ChartArray(idx).Trend = "25: Hold"
                        ChartArray(idx).Account = ChartArray(idx - 1).Account * CostFactor
                        State = 25
                    Else
                        ' share price stays over GD
                        ChartArray(idx).Trend = "20: Rise"
                        ChartArray(idx).Account = (ChartArray(idx).Value / StartSharePrice) * StartAccount
                    End If
                Case 25
                    ' if share price falls under GD again
                    ChartArray(idx).Trend = "25: Wait"
                    ChartArray(idx).Account = ChartArray(idx - 1).Account

                    If ChartArray(idx).Distance <= 0 Then
                        State = 30
                    End If
                Case 30
                    ' if share price raised over GD again
                    If ChartArray(idx).Distance > 0 Then
                        ChartArray(idx).Trend = "30: Rise"
                        '                    ChartArray(idx).Account = ChartArray(idx).Value / StartSharePrice * StartAccount
                        StartSharePrice = ChartArray(idx).Value
                        ChartArray(idx).Account = ChartArray(idx - 1).Account * CostFactor
                        StartAccount = ChartArray(idx).Account
                        State = 20
                    Else
                        ' share price stays under GD
                        ChartArray(idx).Trend = "30: Hold"
                        ChartArray(idx).Account = ChartArray(idx - 1).Account
                    End If

            End Select

            idx = idx + 1
        End While

    End Sub


    Public Sub FindBestA04()
        Dim Account As Double
        Dim AccountMax As Double
        Dim Pos_i As Integer
        Dim Percentage_j As Double
        Dim j1 As Double

        Dim MyList As New List(Of String)
        Dim Zeile As String

        For i = 0 To 200
            Zeile = i & ": "
            For j = 0.02 To 0.5 Step 0.02
                SimpleMovingAverage(i)
                Analyse_04(5000, 1, j)
                Account = ChartArray(UBound(ChartArray)).Account
                Zeile = Zeile & Format(Account, "0.00") & " "
                If Account > AccountMax Then
                    AccountMax = Account
                    Pos_i = i
                    Percentage_j = j
                End If
            Next
            MyList.Add(Zeile)
        Next

        Zeile = "Max: " & AccountMax & "   SMA: " & Pos_i & "   %: " & Percentage_j
        MyList.Add(Zeile)

        Dim FlyingListBox As FrmFlyingListBoxList

        FlyingListBox = New FrmFlyingListBoxList
        FlyingListBox.Title = "Analysis 04"
        FlyingListBox.Filename = "Test.txt"
        FlyingListBox.InputList = MyList
        FlyingListBox.Show()


    End Sub





End Module
