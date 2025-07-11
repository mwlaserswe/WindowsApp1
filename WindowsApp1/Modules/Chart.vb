﻿Option Explicit On
Module Chart
    Dim PtArray As Point()
    Dim idx As Integer

    Dim ColorCoord As Color

    Public Sub DispCoordinateSystem(Pic As PictureBox)

        Dim mx As Single
        Dim my As Double
        Dim ex As Double
        Dim ey As Double

        ColorCoord = Color.Red

        '    mx = GlbCx * GlbScaleX
        '    my = GlbCY * -GlbScaleY

        '    GlbOffX = 100
        '    GlbOffY = 100
        'Draw Axis

        Dim pen1 As New System.Drawing.Pen(Color.Red, 1)
        'Pic.CreateGraphics.DrawLine(pen1, 0, 0, 100, 100)
        '''Pic.CreateGraphics.DrawLine(pen1, GlbOffX, Pic.Height - GlbOffY, GlbOffX + 27000, Pic.Height - GlbOffY)
        '''Pic.CreateGraphics.DrawLine(pen1, GlbOffX, Pic.Height - GlbOffY, GlbOffX, Pic.Height - (GlbOffY + 2000))
        '''
        DrawStart(Pic, 0, Pic.Height, ColorCoord)
        DrawLine(Pic, 0, 0, ColorCoord)
        DrawLine(Pic, Pic.Width, 0, ColorCoord)
        DrawEnd(Pic, ColorCoord)



    End Sub



    ''End Sub
    Public Sub ReadHistoryFileToChartArray(HistoryFileName As String, CompanyName As String)
        Dim ChartFile As Integer
        Dim Zeile As String
        Dim ChartEntities() As String
        Dim idx As Long

        ReDim ChartArray(0 To 0)

        On Error GoTo ReadHistoryFileErr

        ChartFile = FreeFile()
        FileOpen(ChartFile, HistoryFileName, OpenMode.Input)

        While Not EOF(ChartFile)
            Zeile = LineInput(ChartFile)
            SepariereString(Zeile, ChartEntities, ";")
            idx = UBound(ChartArray)
            ChartArray(idx).myDate = ChartEntities(0)
            ChartArray(idx).Value = Zahl(ChartEntities(4))
            ChartArray(idx).WKN = IO.Path.GetFileNameWithoutExtension(HistoryFileName)
            ChartArray(idx).Name = CompanyName

            ReDim Preserve ChartArray(0 To UBound(ChartArray) + 1)
        End While

        ReDim Preserve ChartArray(0 To UBound(ChartArray) - 1)

        FileClose(ChartFile)

        Exit Sub
ReadHistoryFileErr:
        MsgBox(HistoryFileName & vbCr & Err.Description, , "xxxxx")
    End Sub

    Public Sub WriteChartArrayToCsv()
        Dim CsvFileName As String
        Dim CsvFile As Integer
        Dim idx As Long
        On Error GoTo WriteChartArrayToCsvErr

        CsvFileName = Application.StartupPath & "\ChartArray.csv"

        CsvFile = FreeFile()
        FileOpen(CsvFile, CsvFileName, OpenMode.Output)

        ' Kopfzeile schreiben
        PrintLine(CsvFile, "idx;myDate;WKN;Name;Value;SMA;Einstiegspreis;Distance;Account;Trend")

        For idx = LBound(ChartArray) To UBound(ChartArray)
            PrintLine(CsvFile,
                idx & ";" &
                ChartArray(idx).myDate & ";" &
                ChartArray(idx).WKN & ";" &
                ChartArray(idx).Name & ";" &
                ChartArray(idx).Value & ";" &
                ChartArray(idx).SMA & ";" &
                ChartArray(idx).StartSharePrice & ";" &
                ChartArray(idx).Distance & ";" &
                ChartArray(idx).Account & ";" &
                ChartArray(idx).Trend)
        Next

        FileClose(CsvFile)
        Exit Sub

WriteChartArrayToCsvErr:
        MsgBox(CsvFileName & vbCr & Err.Description, , "Fehler beim Schreiben der CSV-Datei")
    End Sub





    Public Sub DisplayChart(Pic As PictureBox)

        Dim idx As Long
        Dim Rise As Integer
        Dim RiseOld As Integer

        DisplayTestPattern(Pic)

        'idx 0 is the head line
        idx = 1

        If Not ArrayValid(ChartArray) Then
            ' Array ist nicht dimensioniert
            Exit Sub
        End If

        '==== Draw share charts ====

        DrawStart(Pic, CDbl(idx), ChartArray(idx).Value, ColorCoord)
        For idx = 1 To UBound(ChartArray)
            DrawLine(Pic, CDbl(idx), ChartArray(idx).Value, ColorCoord)
        Next idx
        DrawEnd(Pic, ColorCoord)


        'SWE        '==== Draw SMA ====
        'SWE
        'SWE        'idx 0 is the head line
        'SWE        idx = 1
        'SWE        RiseOld = -1
        'SWE        Dim DistanceColor As Color
        'SWE
        'SWE        'The nextpart starts with DrawEnd. Color must be empty. Otherwise the previous lines will we overwritten
        'SWE        DistanceColor = Color.Empty
        'SWE
        'SWE
        'SWE        For idx = 1 To UBound(ChartArray)
        'SWE            If ChartArray(idx).Distance > 0 Then
        'SWE                Rise = 1
        'SWE            Else
        'SWE                Rise = 2
        'SWE            End If
        'SWE            If Rise = RiseOld Then
        'SWE                ' Same color: Just append point to array
        'SWE                If Rise = 1 Then
        'SWE                    DistanceColor = Color.Green
        'SWE                Else
        'SWE                    DistanceColor = Color.Blue
        'SWE                End If
        'SWE
        'SWE                DrawLine(Pic, CDbl(idx), ChartArray(idx).SMA, DistanceColor)
        'SWE
        'SWE            Else
        'SWE                ' Different color: End current line. Start new line 
        'SWE                DrawLine(Pic, CDbl(idx), ChartArray(idx).SMA, DistanceColor)
        'SWE                DrawEnd(Pic, DistanceColor)
        'SWE                DrawStart(Pic, CDbl(idx), ChartArray(idx).SMA, DistanceColor)
        'SWE                If Rise = 1 Then
        'SWE                    DistanceColor = Color.Green
        'SWE                Else
        'SWE                    DistanceColor = Color.Blue
        'SWE                End If
        'SWE
        'SWE                DrawLine(Pic, CDbl(idx), ChartArray(idx).SMA, DistanceColor)
        'SWE            End If
        'SWE
        'SWE            RiseOld = Rise
        'SWE
        'SWE        Next idx
        'SWE        DrawEnd(Pic, DistanceColor)


        '==== Draw SMA ====

        'idx 0 is the head line
        idx = 1
        RiseOld = -1
        Dim DistanceColor As Color

        'The nextpart starts with DrawEnd. Color must be empty. Otherwise the previous lines will we overwritten
        DistanceColor = Color.Empty


        For idx = 1 To UBound(ChartArray)
            If InStr(ChartArray(idx).Trend, "Rise", CompareMethod.Text) > 0 Then
                Rise = 1
            Else
                Rise = 2
            End If
            If Rise = RiseOld Then
                ' Same color: Just append point to array
                If InStr(ChartArray(idx).Trend, "Rise", CompareMethod.Text) > 0 Then
                    DistanceColor = Color.Green
                Else
                    DistanceColor = Color.Blue
                End If

                DrawLine(Pic, CDbl(idx), ChartArray(idx).SMA, DistanceColor)

            Else

                ' Different color: End current line. Start new line 
                DrawLine(Pic, CDbl(idx), ChartArray(idx).SMA, DistanceColor)
                DrawEnd(Pic, DistanceColor)

                If Rise = 1 Then
                    DistanceColor = Color.Green
                Else
                    DistanceColor = Color.Blue
                End If

                DrawCircle(Pic, CDbl(idx), ChartArray(idx).SMA, DistanceColor)

                DrawStart(Pic, CDbl(idx), ChartArray(idx).SMA, DistanceColor)
                'If Rise = 1 Then
                '    DistanceColor = Color.Green
                'Else
                '    DistanceColor = Color.Blue
                'End If

                DrawLine(Pic, CDbl(idx), ChartArray(idx).SMA, DistanceColor)
            End If

            RiseOld = Rise

        Next idx
        DrawEnd(Pic, DistanceColor)


        '==== Draw SMA minus 10 % ====
        Dim Band As Double
        Band = glbBand ' x% Band  

        idx = 1
        DrawStart(Pic, CDbl(idx), ChartArray(idx).SMA * (1 - Band), Color.LightGray)
        For idx = 1 To UBound(ChartArray)
            DrawLine(Pic, CDbl(idx), ChartArray(idx).SMA * (1 - Band), Color.LightGray)
        Next idx
        DrawEnd(Pic, Color.LightGray)

        '==== Draw SMA plus 10 % ====
        idx = 1
        DrawStart(Pic, CDbl(idx), ChartArray(idx).SMA * (1 + Band), Color.LightGray)
        For idx = 1 To UBound(ChartArray)
            DrawLine(Pic, CDbl(idx), ChartArray(idx).SMA * (1 + Band), Color.LightGray)
        Next idx
        DrawEnd(Pic, Color.LightGray)



        '==== Draw account ====
        idx = 1
        DrawStart(Pic, CDbl(idx), ChartArray(idx).Value, Color.Black)
        For idx = 1 To UBound(ChartArray)
            DrawLine(Pic, CDbl(idx), ChartArray(idx).Account, Color.Black)
        Next idx
        DrawEnd(Pic, Color.Black)


    End Sub

    Public Sub DisplayDate(Pic As PictureBox, Txt As TextBox)
        Dim NewYear() As Integer
        Dim OldYear As Integer
        Dim NewMonth() As Integer
        Dim OldMonth As Integer

        ReDim NewYear(0)
        ReDim NewMonth(0)

        For i = 1 To UBound(ChartArray)
            If Year(ChartArray(i).myDate) <> OldYear Then
                NewYear(UBound(NewYear)) = i
                OldYear = Year(ChartArray(i).myDate)
                ReDim Preserve NewYear(UBound(NewYear) + 1)
            End If

            If Month(ChartArray(i).myDate) <> OldMonth Then
                NewMonth(UBound(NewMonth)) = i
                OldMonth = Month(ChartArray(i).myDate)
                ReDim Preserve NewMonth(UBound(NewMonth) + 1)
            End If

        Next

        ReDim Preserve NewYear(UBound(NewYear) - 1)
        ReDim Preserve NewMonth(UBound(NewMonth) - 1)




        '================== Den linken und rechten Rand der PictureBox in Idx des ChartArrays umrechnen    ===================
        Dim Xleft
        Dim Xright
        Dim ChartArrayIdxLeft
        Dim ChartArrayIdxRight

        Xleft = 0
        Xright = Pic.Width

        ChartArrayIdxLeft = (Xleft - GlbOffX) / GlbScaleX
        ChartArrayIdxRight = (Xright - GlbOffX) / GlbScaleX
        'MouseXY.Y = (Y - (Pic.Height - GlbOffY)) / -GlbScaleY
        Txt.Text = "Left: " & ChartArrayIdxLeft & "    Right: " & ChartArrayIdxRight
        '============================================== Ende    ==============================================================


        If (ChartArrayIdxRight - ChartArrayIdxLeft) > 1000 Then
            For i = 0 To UBound(NewYear)
                DrawStart(Pic, NewYear(i), 0, Color.LightGray)
                DrawLine(Pic, NewYear(i), 200, Color.LightGray)
                DrawEnd(Pic, Color.LightGray)
            Next
        ElseIf (ChartArrayIdxRight - ChartArrayIdxLeft) > 25 Then
            For i = 0 To UBound(NewMonth)
                DrawStart(Pic, NewMonth(i), 0, Color.LightGray)
                DrawLine(Pic, NewMonth(i), 200, Color.LightGray)
                DrawEnd(Pic, Color.LightGray)
            Next
        Else
            For i = 0 To UBound(ChartArray)
                DrawStart(Pic, i, 0, Color.LightGray)
                DrawLine(Pic, i, 200, Color.LightGray)
                DrawEnd(Pic, Color.LightGray)
            Next
        End If



    End Sub

    Public Sub SimpleMovingAverage(Length As Long)
        Dim idx As Long
        Dim i As Long
        Dim Sum As Double
        Dim Average As Double
        Dim Distance As Double
        'SWE        Static LastDistance As Double
        Dim LastDistance As Double

        If Not ArrayValid(ChartArray) Then
            ' Array ist nicht dimensioniert
            Exit Sub
        End If

        If UBound(ChartArray) <= Length Then
            Exit Sub
        End If


        If Length = 0 Then
            Length = 1
        End If

        idx = 1
        Sum = 0
        While idx < Length
            Sum = Sum + ChartArray(idx).Value
            Average = Sum / idx
            ChartArray(idx).SMA = Average
            If ChartArray(idx).Value <> 0 Then
                Distance = (ChartArray(idx).Value - Average) / ChartArray(idx).Value
            Else
                Distance = 0
            End If
            ChartArray(idx).Distance = Distance
            idx = idx + 1
        End While

        For idx = Length To UBound(ChartArray)
            Sum = 0
            For i = idx - Length + 1 To idx
                Sum = Sum + ChartArray(i).Value
            Next i
            Average = Sum / Length
            ChartArray(idx).SMA = Average

            ' Share prises in history files sometimes are zero
            ' Just avoid division by zero
            If ChartArray(idx).Value = 0 Then
                Distance = LastDistance
            Else
                Distance = (ChartArray(idx).Value - Average) / ChartArray(idx).Value
            End If
            ChartArray(idx).Distance = Distance
            LastDistance = Distance
        Next idx
    End Sub




    '=====================================================================
    '                       Analyse_02
    ' Einstieg: Im Gegensatz zu Analye_01 wird zuerst gewartet, bis
    '           bis der Kurs von unten durch den GS sticht.
    ' Wenn der Kurs von unten durch den SMA sticht, wird gekauft.
    ' Wenn der Kurs von oben unter den SMA fällt, wird verkauft.
    ' InvestmentStart: Der Index im History file
    ' StartAccount: Die Investitionssumme
    '=====================================================================
    Public Sub Analyse_02(InvestmentStart As Integer, StartAccount As Double)
        Dim idx As Integer
        Dim State As Integer
        Dim CostFactor As Double

        'CostFactor = 1
        CostFactor = 0.9926
        '    CostFactor = 0.991

        idx = 0
        State = 0

        If Not ArrayValid(ChartArray) Then
            ' Array ist nicht dimensioniert
            Exit Sub
        End If

        While idx <= UBound(ChartArray)

            ChartArray(idx).State = State

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
                    ' if share price falls under GD again
                    If ChartArray(idx).Distance <= 0 Then
                        ChartArray(idx).Account = (ChartArray(idx).Value / StartSharePrice) * StartAccount
                        ' Remove transfer costs
                        ChartArray(idx).Account = ChartArray(idx).Account * CostFactor
                        ChartArray(idx).Trend = "20: Hold"
                        State = 30
                        ' share price stays over GD
                    Else
                        ChartArray(idx).Trend = "20: Rise"
                        ChartArray(idx).Account = (ChartArray(idx).Value / StartSharePrice) * StartAccount
                    End If
                Case 30
                    ' if share price raised over GD again
                    If ChartArray(idx).Distance > 0 Then
                        '                    ChartArray(idx).Account = ChartArray(idx).Value / StartSharePrice * StartAccount
                        StartSharePrice = ChartArray(idx).Value
                        ChartArray(idx).Account = ChartArray(idx - 1).Account * CostFactor
                        StartAccount = ChartArray(idx).Account
                        ChartArray(idx).Trend = "30: Rise"
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




    '=====================================================================
    '                       Analyse_03
    ' Einstieg: Im Gegensatz zu Analye_01 wird zuerst gewartet, bis
    '           bis der Kurs von unten durch den SMA sticht.
    ' Wenn der Kurs von unten durch den SMA sticht, wird gekauft.
    ' Wenn die Aktie fällt, wird sofort verkauft
    ' InvestmentStart: Der Index im History file
    ' StartAccount: Die Investitionssumme
    '=====================================================================
    Public Sub Analyse_03(InvestmentStart As Long, StartAccount As Double)
        Dim idx As Long
        Dim State As Integer
        Dim CostFactor As Double

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
                    ' if share price is lower than yesterday
                    If ChartArray(idx).Value < ChartArray(idx - 1).Value Then
                        ChartArray(idx).Trend = "20: Hold"
                        ChartArray(idx).Account = ChartArray(idx - 1).Account * CostFactor
                        State = 25
                        ' share price stays over GD
                    Else
                        ChartArray(idx).Trend = "20: Rise"
                        ChartArray(idx).Account = (ChartArray(idx).Value / StartSharePrice) * StartAccount
                    End If
                Case 25
                    ' wait until share price under GD
                    If ChartArray(idx).Distance < 0 Then
                        ChartArray(idx).Trend = "30: Hold"
                        ChartArray(idx).Account = ChartArray(idx - 1).Account
                        State = 30
                    Else
                        ' share price under GD now
                        ChartArray(idx).Trend = "30: Hold"
                        ChartArray(idx).Account = ChartArray(idx - 1).Account
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


    '=====================================================================
    '                       Analyse_05
    ' 
    '=====================================================================
    Public Sub Analyse_05(InvestmentStart As Integer, StartAccount As Double)
        Dim idx As Integer
        Dim State As Integer
        Dim CostFactor As Double

        'CostFactor = 1
        CostFactor = 0.98
        '    CostFactor = 0.991

        idx = 0
        State = 0

        If Not ArrayValid(ChartArray) Then
            ' Array ist nicht dimensioniert
            Exit Sub
        End If

        While idx <= UBound(ChartArray)

            If idx = 5250 Then
                Dim a As Integer
                a = idx
            End If


            Select Case State
                Case 0
                    ' no investment before InvestmentStart
                    If idx >= InvestmentStart Then
                        ChartArray(idx).StartSharePrice = 0
                        ChartArray(idx).Account = 0
                        ChartArray(idx).Trend = "0"
                        State = 5
                    Else
                        ChartArray(idx).StartSharePrice = 0
                        ChartArray(idx).Account = 0
                        ChartArray(idx).Trend = "0"
                    End If

                Case 5
                    ' Kurs anfänglich ist unter dem GD -> zum normalen Ablauf
                    If ChartArray(idx).Distance <= 0 Then
                        ChartArray(idx).StartSharePrice = 0
                        ChartArray(idx).Account = 0
                        ChartArray(idx).Trend = "5:wait"
                        State = 10

                        ' Der Kurs ist über dem GD
                        ' erst mal warten, bis der Kurs unter den GD fällt
                    Else
                        ChartArray(idx).StartSharePrice = 0
                        ChartArray(idx).Account = 0
                        ChartArray(idx).Trend = "5: wait"
                    End If
                Case 10
                    ' wait until share price is over GD again the first time
                    '*** buy now
                    If ChartArray(idx).Distance > 0 Then
                        ChartArray(idx).StartSharePrice = ChartArray(idx).Value     'Einstiegskurs
                        ChartArray(idx).Account = (ChartArray(idx).Value / ChartArray(idx).StartSharePrice) * StartAccount
                        ' Transaktionskosten
                        ChartArray(idx).Account = ChartArray(idx).Account * CostFactor
                        ChartArray(idx).Trend = "10: Rise"
                        State = 20

                        ' Kurs ist unter dem GD -> erst mal warten
                    Else
                        ChartArray(idx).StartSharePrice = 0
                        ChartArray(idx).Account = 0
                        ChartArray(idx).Trend = "10: wait"
                    End If
                Case 20
                    ' Hier ist die Aktie gekauft
                    ChartArray(idx).StartSharePrice = ChartArray(idx - 1).StartSharePrice

                    ' Das Verkaufskriterium ist, dass der Kurs unter GD - x% fällt
                    If ChartArray(idx).Distance <= -glbBand Then
                        ChartArray(idx).Account = (ChartArray(idx).Value / ChartArray(idx).StartSharePrice) * StartAccount
                        ' Transaktionskosten
                        ChartArray(idx).Account = ChartArray(idx).Account * CostFactor
                        ChartArray(idx).Trend = "20: Hold"
                        State = 30

                        ' share price stays over GD
                    Else
                        ChartArray(idx).Account = (ChartArray(idx).Value / ChartArray(idx).StartSharePrice) * StartAccount
                        ChartArray(idx).Trend = "20: Rise"
                    End If
                Case 30
                    ' Hier hat man gerade keine Aktien

                    ' if share price raised over GD again
                    If ChartArray(idx).Distance > 0 Then
                        '                    ChartArray(idx).Account = ChartArray(idx).Value / StartSharePrice * StartAccount
                        ChartArray(idx).StartSharePrice = ChartArray(idx).Value

                        ' Transaktionskosten
                        ChartArray(idx).Account = ChartArray(idx - 1).Account * CostFactor
                        StartAccount = ChartArray(idx).Account
                        ChartArray(idx).Trend = "30: Rise"
                        State = 20
                    Else
                        ' share price stays under GD
                        ChartArray(idx).StartSharePrice = 0
                        ChartArray(idx).Account = ChartArray(idx - 1).Account
                        ChartArray(idx).Trend = "30: Hold"
                    End If

            End Select

            idx = idx + 1
        End While

    End Sub

    '=====================================================================
    '                       Analyse_06
    ' 
    '=====================================================================
    Public Sub Analyse_06(InvestmentStart As Integer, StartAccount As Double)
        Dim idx As Integer
        Dim State As Integer
        Dim CostFactor As Double

        'CostFactor = 1
        CostFactor = 0.98
        '    CostFactor = 0.991

        idx = 0
        State = 0

        If Not ArrayValid(ChartArray) Then
            ' Array ist nicht dimensioniert
            Exit Sub
        End If

        While idx <= UBound(ChartArray)

            If idx = 5250 Then
                Dim a As Integer
                a = idx
            End If


            Select Case State
                Case 0
                    ' no investment before InvestmentStart
                    If idx >= InvestmentStart Then
                        ChartArray(idx).StartSharePrice = 0
                        ChartArray(idx).Account = 0
                        ChartArray(idx).Trend = "0"
                        State = 5
                    Else
                        ChartArray(idx).StartSharePrice = 0
                        ChartArray(idx).Account = 0
                        ChartArray(idx).Trend = "0"
                    End If

                Case 5
                    ' Kurs anfänglich ist unter dem GD -> zum normalen Ablauf
                    If ChartArray(idx).Distance <= 0 Then
                        ChartArray(idx).StartSharePrice = 0
                        ChartArray(idx).Account = 0
                        ChartArray(idx).Trend = "5:wait"
                        State = 10

                        ' Der Kurs ist über dem GD
                        ' erst mal warten, bis der Kurs unter den GD fällt
                    Else
                        ChartArray(idx).StartSharePrice = 0
                        ChartArray(idx).Account = 0
                        ChartArray(idx).Trend = "5: wait"
                    End If
                Case 10
                    ' wait until share price is over GD again the first time
                    '*** buy now
                    If ChartArray(idx).Distance > 0 Then
                        ChartArray(idx).StartSharePrice = ChartArray(idx).Value     'Einstiegskurs
                        ChartArray(idx).Account = (ChartArray(idx).Value / ChartArray(idx).StartSharePrice) * StartAccount
                        ' Transaktionskosten
                        ChartArray(idx).Account = ChartArray(idx).Account * CostFactor
                        ChartArray(idx).Trend = "10: Rise"
                        State = 20

                        ' Kurs ist unter dem GD -> erst mal warten
                    Else
                        ChartArray(idx).StartSharePrice = 0
                        ChartArray(idx).Account = 0
                        ChartArray(idx).Trend = "10: wait"
                    End If
                Case 20
                    ' Hier ist die Aktie gekauft
                    ChartArray(idx).StartSharePrice = ChartArray(idx - 1).StartSharePrice

                    ' Das Verkaufskriterium ist, dass der Kurs unter GD - x% fällt
                    If ChartArray(idx).Distance <= -glbBand Then
                        ChartArray(idx).Account = (ChartArray(idx).Value / ChartArray(idx).StartSharePrice) * StartAccount
                        ' Transaktionskosten
                        ChartArray(idx).Account = ChartArray(idx).Account * CostFactor
                        ChartArray(idx).Trend = "20: Hold"
                        State = 30

                        ' share price stays over GD
                    Else
                        ChartArray(idx).Account = (ChartArray(idx).Value / ChartArray(idx).StartSharePrice) * StartAccount
                        ChartArray(idx).Trend = "20: Rise"
                    End If
                Case 30
                    ' Hier hat man gerade keine Aktien

                    ' Das Kaufskriterium ist, dass der Kurs unter GD - x% fällt
                    If ChartArray(idx).Distance > glbBand Then
                        '                    ChartArray(idx).Account = ChartArray(idx).Value / StartSharePrice * StartAccount
                        ChartArray(idx).StartSharePrice = ChartArray(idx).Value

                        ' Transaktionskosten
                        ChartArray(idx).Account = ChartArray(idx - 1).Account * CostFactor
                        StartAccount = ChartArray(idx).Account
                        ChartArray(idx).Trend = "30: Rise"
                        State = 20
                    Else
                        ' share price stays under GD
                        ChartArray(idx).StartSharePrice = 0
                        ChartArray(idx).Account = ChartArray(idx - 1).Account
                        ChartArray(idx).Trend = "30: Hold"
                    End If

            End Select

            idx = idx + 1
        End While

    End Sub

    Public Sub DrawStart(Pic As PictureBox, X As Single, Y As Single, LclColor As Color)
        Dim PicX As Single
        Dim PicY As Single

        PicX = (X * GlbScaleX) + GlbOffX
        PicY = Form1.PicChart.Height - (Y * GlbScaleY) - GlbOffY

        If PicX > Form1.PicChart.Width + 100 Then
            PicX = Form1.PicChart.Width + 100
        End If

        If PicX < -100 Then
            PicX = -100
        End If

        If PicY > Form1.PicChart.Height + 100 Then
            PicY = Form1.PicChart.Height + 100
        End If

        If PicY < -100 Then
            PicY = -100
        End If

        idx = 0
        ReDim PtArray(0 To 0)


        PtArray(idx).X = PicX
        PtArray(idx).Y = PicY
        idx = idx + 1


    End Sub

    Public Sub DrawLine(Pic As PictureBox, X As Single, Y As Single, LclColor As Color)
        Dim PicX As Single
        Dim PicY As Single

        Dim pt1 As Point

        PicX = (X * GlbScaleX) + GlbOffX
        PicY = Form1.PicChart.Height - (Y * GlbScaleY) - GlbOffY

        If PicX > Form1.PicChart.Width + 100 Then
            PicX = Form1.PicChart.Width + 100
        End If

        If PicX < -100 Then
            PicX = -100
        End If

        If PicY > Form1.PicChart.Height + 100 Then
            PicY = Form1.PicChart.Height + 100
        End If

        If PicY < -100 Then
            PicY = -100
        End If


        pt1.X = PicX
        pt1.Y = PicY

        ReDim Preserve PtArray(0 To idx)

        PtArray(idx) = pt1

        'Test circle 
        'Dim pen1 As New System.Drawing.Pen(LclColor, 1)
        'Pic.CreateGraphics.DrawEllipse(pen1, pt1.X - 5, pt1.Y - 5, 10, 10)

        idx = idx + 1

    End Sub

    Public Sub DrawCircle(Pic As PictureBox, X As Single, Y As Single, LclColor As Color)
        Dim PicX As Single
        Dim PicY As Single

        Dim pt1 As Point
        Dim Radius As Integer

        Radius = 2

        PicX = (X * GlbScaleX) + GlbOffX
        PicY = Form1.PicChart.Height - (Y * GlbScaleY) - GlbOffY

        If PicX > Form1.PicChart.Width + 100 Then
            PicX = Form1.PicChart.Width + 100
        End If

        If PicX < -100 Then
            PicX = -100
        End If

        If PicY > Form1.PicChart.Height + 100 Then
            PicY = Form1.PicChart.Height + 100
        End If

        If PicY < -100 Then
            PicY = -100
        End If


        pt1.X = PicX
        pt1.Y = PicY



        'Draw circle 
        Dim pen1 As New System.Drawing.Pen(LclColor, 1)
        Pic.CreateGraphics.DrawEllipse(pen1, pt1.X - Radius, pt1.Y - Radius, Radius * 2, Radius * 2)
        Pic.CreateGraphics.FillEllipse(New SolidBrush(LclColor), pt1.X - Radius, pt1.Y - Radius, Radius * 2, Radius * 2)

        idx = idx + 1

    End Sub

    Public Sub DrawEnd(Pic As PictureBox, LclColor As Color)

        Dim pen1 As New System.Drawing.Pen(LclColor, 1)
        Pic.CreateGraphics.DrawLines(pen1, PtArray)
    End Sub




    Public Sub DisplayTestPattern(pic As PictureBox)
        Dim DistanceColor As Color

        DistanceColor = Color.Blue
        DrawStart(pic, 0, 0, DistanceColor)
        DrawLine(pic, 0, 100, DistanceColor)
        DrawLine(pic, 200, 100, DistanceColor)
        DrawLine(pic, 200, 0, DistanceColor)
        DrawLine(pic, 0, 0, DistanceColor)
        DrawEnd(pic, DistanceColor)


        DrawStart(pic, 0, 0, DistanceColor)
        DrawLine(pic, 200, 100, DistanceColor)
        DrawEnd(pic, DistanceColor)

        DrawStart(pic, 0, 100, DistanceColor)
        DrawLine(pic, 200, 0, DistanceColor)
        DrawEnd(pic, DistanceColor)

        pic.CreateGraphics.DrawString("Mein Text...", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, 10, 10)

    End Sub

    Sub ReadCompanyListFile(MyList As ListBox)
        Dim CompanyListFilename As String
        Dim CompanyListFile As Integer
        Dim Zeile As String
        Dim CompanyListEntities() As String
        Dim idx As Long

        ReDim CompanyListArray(0 To 0)
        MyList.Items.Clear()
        '    List2.Clear

        On Error GoTo ReadCompanyListFileErr

        CompanyListFilename = Application.StartupPath & "\ISIN-WKN.txt"
        CompanyListFile = FreeFile()
        'Open CompanyListFilename For Input As CompanyListFile
        FileOpen(CompanyListFile, CompanyListFilename, OpenMode.Input)
        ' Close before reopening in another mode.

        While Not EOF(CompanyListFile)
            Zeile = LineInput(CompanyListFile)
            If Zeile <> "" Then
                MyList.Items.Add(Zeile)
                SepariereString(Zeile, CompanyListEntities, vbTab)
                idx = UBound(CompanyListArray)
                CompanyListArray(idx).Name = CompanyListEntities(0)
                CompanyListArray(idx).WKN = CompanyListEntities(1)
                CompanyListArray(idx).ISIN = CompanyListEntities(2)

                '''            'Search doubbles
                '''            Dim i As Long
                '''            For i = 0 To UBound(CompanyListArray) - 1
                '''                If CompanyListArray(i).WKN = CompanyListArray(idx).WKN Then
                '''                    List2.AddItem Zeile
                '''                End If
                '''            Next i

                ReDim Preserve CompanyListArray(0 To UBound(CompanyListArray) + 1)
            End If

        End While
        ReDim Preserve CompanyListArray(0 To UBound(CompanyListArray) - 1)
        FileClose(CompanyListFile)

        Exit Sub
ReadCompanyListFileErr:
        MsgBox(CompanyListFilename & vbCr & Err.Description, , "xxxxx")
    End Sub


    Public Function FindBestSMA(InvestmentStart As Integer, InvestDuration As Integer) As BestSMA
        Dim SMAArray(200) As Double

        Dim AbsMax As Double
        Dim AbsMaxPos As Integer

        'Get final accont for each SMA
        For i = 1 To 200
            SimpleMovingAverage(i)
            Analyse_02(InvestmentStart, 1)
            If (InvestmentStart + InvestDuration) > UBound(ChartArray) Then
                SMAArray(i) = ChartArray(UBound(ChartArray)).Account
            Else
                SMAArray(i) = ChartArray(InvestmentStart + InvestDuration).Account
            End If
        Next i

        ReDim FindBestSMA.SMAArry(200)
        FindBestSMA.SMAArry = SMAArray

        'Find AbsMax
        AbsMax = 0
        For i = 1 To 200
            If SMAArray(i) > AbsMax Then
                AbsMaxPos = i
                AbsMax = SMAArray(i)
            End If
        Next

        FindBestSMA.AbsMax = AbsMax
        FindBestSMA.AbsMaxPos = AbsMaxPos

    End Function

    Public Function FindSmoothedBestSMA(InvestmentStart As Integer, InvestDuration As Integer) As BestSMA
        Dim SMAArray(200) As Double
        Dim TmpArray(200) As Double

        Dim AbsMax As Double
        Dim AbsMaxPos As Integer


        'Get final accont for each SMA
        For i = 1 To 200
            SimpleMovingAverage(i)
            Analyse_02(InvestmentStart, 1)
            If (InvestmentStart + InvestDuration) > UBound(ChartArray) Then
                SMAArray(i) = ChartArray(UBound(ChartArray)).Account
            Else
                SMAArray(i) = ChartArray(InvestmentStart + InvestDuration).Account
            End If
        Next i

        For i = 2 To 199
            TmpArray(i) = (SMAArray(i - 1) + SMAArray(i) + SMAArray(i + 1)) / 3
        Next

        ReDim FindSmoothedBestSMA.SMAArry(200)
        FindSmoothedBestSMA.SMAArry = TmpArray

        'Find AbsMax
        AbsMax = 0
        For i = 1 To 200
            If TmpArray(i) > AbsMax Then
                AbsMaxPos = i
                AbsMax = TmpArray(i)
            End If
        Next

        FindSmoothedBestSMA.AbsMax = AbsMax
        FindSmoothedBestSMA.AbsMaxPos = AbsMaxPos

    End Function

    Private Function FindMaxRight(Arry() As Double, Pos As Integer) As Boolean
        'Is there another maximum at the right side of Pos?
        Dim Lclpos As Integer
        Dim LocMax As Double

        FindMaxRight = False
        LocMax = Arry(Pos)
        For Lclpos = Pos To Arry.Length - 1
            If Arry(Lclpos) > LocMax Then
                FindMaxRight = True
                Exit Function
            End If
        Next
    End Function




    Public Sub FindRisingInSequenz(ByRef ListArray() As String)
        Dim idx As Integer
        Dim RiseArray() As Integer
        Dim Rise As Boolean
        Dim RiseCnt As Integer
        Dim Risemax As Integer
        Dim Zeile As String

        ReDim RiseArray(0)

        For idx = LBound(ChartArray) + 1 To UBound(ChartArray)
            If ChartArray(idx).Value > ChartArray(idx - 1).Value Then
                If Not Rise Then
                    RiseCnt = 0
                End If
                Rise = True
                RiseCnt = RiseCnt + 1
            Else
                If Rise Then
                    If RiseCnt > Risemax Then
                        Risemax = RiseCnt
                        ReDim Preserve RiseArray(0 To Risemax)
                    End If
                    RiseArray(RiseCnt) = RiseArray(RiseCnt) + 1
                    Rise = False
                End If
            End If
        Next

        ReDim ListArray(UBound(RiseArray))

        For idx = LBound(RiseArray) To UBound(RiseArray)
            Zeile = idx & " days is sequenz:" & vbTab & RiseArray(idx)
            ListArray(idx) = Zeile
        Next
    End Sub

    Public Sub FindRisingPercentage(ByRef ListArray() As String)
        Dim idx As Integer
        Dim RiseArray() As Integer
        Dim Rise As Boolean
        Dim RiseCnt As Integer
        Dim Risemax As Integer
        Dim Zeile As String
        Dim PercentageArray() As Integer
        Dim ReferenceValue As Double
        Dim RisePercentage As Double
        Dim PercentageIdx As Integer
        Dim PercentageIdxMax As Double

        ReDim RiseArray(0)
        ReDim PercentageArray(0)

        For idx = 2 To UBound(ChartArray)
            If ChartArray(idx).Value > ChartArray(idx - 1).Value Then
                If Not Rise Then
                    RiseCnt = 0
                    ReferenceValue = ChartArray(idx - 1).Value
                End If
                Rise = True
                RisePercentage = (ChartArray(idx).Value - ReferenceValue) / ReferenceValue
                PercentageIdx = CInt(RisePercentage * 1000)   ' [ % * 10 ]
                RiseCnt = RiseCnt + 1
            Else
                If Rise Then
                    If RiseCnt > Risemax Then
                        Risemax = RiseCnt
                        ReDim Preserve RiseArray(0 To Risemax)
                    End If

                    If PercentageIdx > PercentageIdxMax Then
                        PercentageIdxMax = PercentageIdx
                        ReDim Preserve PercentageArray(0 To PercentageIdxMax)
                    End If
                    PercentageArray(PercentageIdx) = PercentageArray(PercentageIdx) + 1


                    RiseArray(RiseCnt) = RiseArray(RiseCnt) + 1
                    Rise = False
                End If
            End If
        Next

        ReDim ListArray(0)

        Dim AccumulatedNumber As Integer
        Dim Costs As Integer
        Costs = 20   ' Costs: 20 means 2.0% buy and sell

        idx = 0
        For i = 0 To UBound(PercentageArray)
            If PercentageArray(i) > 0 Then
                AccumulatedNumber = 0
                For k = i To UBound(PercentageArray)
                    AccumulatedNumber = AccumulatedNumber + PercentageArray(k)
                Next
                Zeile = i / 10 & " %:" & vbTab & PercentageArray(i) & vbTab & "Accu: " & AccumulatedNumber & vbTab & "Account: " & (i - Costs) * AccumulatedNumber
                ListArray(idx) = Zeile
                ReDim Preserve ListArray(UBound(ListArray) + 1)
                idx = idx + 1
            End If
        Next
        ReDim Preserve ListArray(UBound(ListArray) - 1)

    End Sub


    Public Function FindBestMultipleSMA(InvestmentStart As Integer, InvestDuration As Integer) As BestSMA
        Dim DemoBestSMA As BestSMA
        Dim ChartFile As Integer
        Dim Zeile As String
        Dim ChartFilename As String
        Dim ResultString As String
        Dim ListArray() As String
        Dim ListIdx As Integer

        'Write to ListBox and file
        '''On Error GoTo OpenError


        ChartFilename = Application.StartupPath & "\BestSMA " & Form1.T_CurrCompName.Text & " " & Form1.T_CurrWKN.Text & ".txt"
        ChartFile = FreeFile()
        FileOpen(ChartFile, ChartFilename, OpenMode.Output)
        ListIdx = 0
        Form1.ListBox1.Items.Clear()

        Zeile = FixLen("", 70) & vbTab
        For i = 1 To 200
            Zeile = Zeile + CStr(i) & vbTab
        Next i
        Form1.ListBox1.Items.Add(Zeile)
        PrintLine(ChartFile, Zeile)

        ListIdx = 0
        ReDim ListArray(ListIdx)
        ListArray(ListIdx) = Zeile





        For i = 500 To 5000 Step 50


            DemoBestSMA = FindBestSMA(i, 260)  '260 Entries in HistoryArray is about 1 year 

            Zeile = CStr(i) & " "
            ResultString = "Max1: " & DemoBestSMA.AbsMaxPos & "  " & Format(DemoBestSMA.AbsMax, "0.000")
            Zeile = Zeile + ResultString & "   "

            For j = 1 To 200
                Zeile = Zeile + Format(DemoBestSMA.SMAArry(j), "0.000") & vbTab
            Next j
            Form1.ListBox1.Items.Add(Zeile)

            PrintLine(ChartFile, Zeile)

            ListIdx = ListIdx + 1
            ReDim Preserve ListArray(ListIdx)
            ListArray(ListIdx) = Zeile

            Application.DoEvents()
        Next i

        FileClose(ChartFile)

        Dim FlyingListBox As FrmFlyingListBox

        FlyingListBox = New FrmFlyingListBox
        FlyingListBox.Title = "Percentage in sequence"
        FlyingListBox.Filename = ""
        FlyingListBox.ListArray = ListArray
        FlyingListBox.Show()



        ''''        Exit Sub

        ''''OpenError:
        ''''        MsgBox(ChartFilename, , "Write error")
        ''''        FileClose(ChartFile)
    End Function

    Public Sub RiseSatistics(ByRef ListArray() As String)
        Dim idx As Integer
        Dim Rise As Boolean
        Dim RiseValueMax As Double
        Dim Zeile As String
        Dim PercentageArray() As Integer
        Dim ReferenceValue As Double
        Dim RisePercentage As Double
        Dim PercentageIdx As Integer
        Dim PercentageIdxMax As Double
        ReDim PercentageArray(0)

        For idx = 2 To UBound(ChartArray)

            ' Check rise periode only
            If InStr(ChartArray(idx).Trend, "Rise", CompareMethod.Text) Then
                If Not Rise Then
                    RiseValueMax = ChartArray(idx).Value
                    ReferenceValue = ChartArray(idx).Value
                End If
                Rise = True
                'RisePercentage = (ChartArray(idx).Value - ReferenceValue) / ReferenceValue
                'PercentageIdx = CInt(RisePercentage * 1000)   ' [ % * 10 ]
                If ChartArray(idx).Value > RiseValueMax Then
                    RiseValueMax = ChartArray(idx).Value
                End If

            Else
                If Rise Then

                    RisePercentage = (RiseValueMax - ReferenceValue) / ReferenceValue
                    PercentageIdx = CInt(RisePercentage * 1000)   ' [ % * 10 ]

                    'Percentage could be negative. Negative index is not allowed
                    If PercentageIdx < 0 Then
                        PercentageIdx = 0
                    End If

                    If PercentageIdx > PercentageIdxMax Then
                        PercentageIdxMax = PercentageIdx
                        ReDim Preserve PercentageArray(0 To PercentageIdxMax)
                    End If
                    PercentageArray(PercentageIdx) = PercentageArray(PercentageIdx) + 1

                    Rise = False
                End If
            End If
        Next

        ReDim ListArray(0)

        Dim AccumulatedNumber As Integer
        Dim Costs As Integer
        Costs = 20   ' Costs: 20 means 2.0% buy and sell

        idx = 0
        For i = 0 To UBound(PercentageArray)
            If PercentageArray(i) > 0 Then
                AccumulatedNumber = 0
                For k = i To UBound(PercentageArray)
                    AccumulatedNumber = AccumulatedNumber + PercentageArray(k)
                Next
                Zeile = i / 10 & " %:" & vbTab & PercentageArray(i) & vbTab & "Accu: " & AccumulatedNumber & vbTab & "Account: " & (i - Costs) * AccumulatedNumber
                ListArray(idx) = Zeile
                ReDim Preserve ListArray(UBound(ListArray) + 1)
                idx = idx + 1
            End If
        Next
        ReDim Preserve ListArray(UBound(ListArray) - 1)
    End Sub



End Module
