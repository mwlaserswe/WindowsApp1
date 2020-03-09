Option Explicit On
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


    Public Sub DisplayChart(Pic As PictureBox)

        Dim idx As Long
        Dim Rise As Integer
        Dim RiseOld As Integer




        DisplayTestPattern(Pic)





        'idx 0 is the head line
        idx = 1

        '''If (0 / 1) + (Not Not ChartArray) = 0 Then
        '''    ' Array ist nicht nicht dimensioniert
        '''    Exit Sub
        '''End If


        '==== Draw share charts ====

        DrawStart(Pic, CDbl(idx), ChartArray(idx).Value, ColorCoord)
        For idx = 1 To UBound(ChartArray)
            DrawLine(Pic, CDbl(idx), ChartArray(idx).Value, ColorCoord)
        Next idx
        DrawEnd(Pic, ColorCoord)


        '==== Draw SD ====

        'idx 0 is the head line
        idx = 1
        RiseOld = -1
        Dim DistanceColor As Color

        'The nextpart starts with DrawEnd. Color must be empty. Otherwise the previous lines will we overwritten
        DistanceColor = Color.Empty


        For idx = 1 To UBound(ChartArray)
            If ChartArray(idx).Distance > 0 Then
                Rise = 1
            Else
                Rise = 2
            End If
            If Rise = RiseOld Then
                ' Same color: Just append point to array
                If Rise = 1 Then
                    DistanceColor = Color.Green
                Else
                    DistanceColor = Color.Blue
                End If

                DrawLine(Pic, CDbl(idx), ChartArray(idx).SD, DistanceColor)

            Else
                ' Different color: End current line. Start new line 
                DrawLine(Pic, CDbl(idx), ChartArray(idx).SD, DistanceColor)
                DrawEnd(Pic, DistanceColor)
                DrawStart(Pic, CDbl(idx), ChartArray(idx).SD, DistanceColor)
                If Rise = 1 Then
                    DistanceColor = Color.Green
                Else
                    DistanceColor = Color.Blue
                End If

                DrawLine(Pic, CDbl(idx), ChartArray(idx).SD, DistanceColor)
            End If

            RiseOld = Rise

        Next idx
        DrawEnd(Pic, DistanceColor)


        '==== Draw account ====
        idx = 1
        DrawStart(Pic, CDbl(idx), ChartArray(idx).Value, Color.Black)
        For idx = 1 To UBound(ChartArray)
            DrawLine(Pic, CDbl(idx), ChartArray(idx).Account, Color.Black)
        Next idx
        DrawEnd(Pic, Color.Black)


    End Sub

    Public Sub MovingAverage(Length As Long)
        Dim idx As Long
        Dim i As Long
        Dim Sum As Double
        Dim Average As Double
        Dim Distance As Double
        Static LastDistance As Double

        'If (0 / 1) + (Not Not ChartArray) = 0 Then
        '    ' Array ist nicht nicht dimensioniert
        '    Exit Sub
        'End If


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
            ChartArray(idx).SD = Average
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
            ChartArray(idx).SD = Average

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
    ' Wenn der Kurs von unten durch den GD sticht, wird gekauft.
    ' Wenn der Kurs von oben unter den GD fällt, wird verkauft.
    ' InvestmentStart: Der Index im History file
    ' StartAccount: Die Investitionssumme
    '=====================================================================
    Public Sub Analyse_02(InvestmentStart As Integer, StartAccount As Double)
        Dim idx As Integer
        Dim State As Integer
        Dim CostFactor As Double

        CostFactor = 0.9926
        '    CostFactor = 0.991

        idx = 0
        State = 0

        'If (0 / 1) + (Not Not ChartArray) = 0 Then
        '    ' Array ist nicht nicht dimensioniert
        '    Exit Sub
        'End If

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
                    ' if share price falls under GD again
                    If ChartArray(idx).Distance <= 0 Then
                        ChartArray(idx).Trend = "20: Hold"
                        ChartArray(idx).Account = ChartArray(idx - 1).Account * CostFactor
                        State = 30
                        ' share price stays over GD
                    Else
                        ChartArray(idx).Trend = "20: Rise"
                        ChartArray(idx).Account = (ChartArray(idx).Value / StartSharePrice) * StartAccount
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
    '                       Analyse_03
    ' Einstieg: Im Gegensatz zu Analye_01 wird zuerst gewartet, bis
    '           bis der Kurs von unten durch den GS sticht.
    ' Wenn der Kurs von unten durch den GD sticht, wird gekauft.
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

        'If (0 / 1) + (Not Not ChartArray) = 0 Then
        '    ' Array ist nicht nicht dimensioniert
        '    Exit Sub
        'End If

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
        'Pic.CreateGraphics.DrawEllipse(pen1, pt1.X, pt1.Y, 10, 10)

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


    Public Function FindBestSD(InvestmentStart As Integer, InvestDuration As Integer) As BestSD
        Dim SdArray(200) As Double

        Dim AbsMax As Double
        Dim AbsMaxPos As Integer
        Dim RightMax As Double
        Dim RightMaxPos As Integer
        Dim Minimum As Double
        Dim MinPos As Integer


        'Get final accont for each SD
        For i = 1 To 200
            MovingAverage(i)
            Analyse_02(InvestmentStart, 1)
            If (InvestmentStart + InvestDuration) > UBound(ChartArray) Then
                SdArray(i) = ChartArray(UBound(ChartArray)).Account
            Else
                SdArray(i) = ChartArray(InvestmentStart + InvestDuration).Account
            End If
        Next i

        ReDim FindBestSD.SdArry(200)
        FindBestSD.SdArry = SdArray

        'Find AbsMax
        AbsMax = 0
        For i = 1 To 200
            If SdArray(i) > AbsMax Then
                AbsMaxPos = i
                AbsMax = SdArray(i)
            End If
        Next

        'Find Minimum
        Minimum = 1.0E+99
        For i = AbsMaxPos To 200
            If SdArray(i) < Minimum And FindMaxRight(SdArray, i) Then
                MinPos = i
                Minimum = SdArray(i)
            End If
        Next

        'Find RightMax
        RightMax = 0
        For i = MinPos To 200
            If SdArray(i) > RightMax Then
                RightMaxPos = i
                RightMax = SdArray(i)
            End If
        Next

        FindBestSD.AbsMax = AbsMax
        FindBestSD.AbsMaxPos = AbsMaxPos
        FindBestSD.RightMax = RightMax
        FindBestSD.RightMaxPos = RightMaxPos
        FindBestSD.Minimum = Minimum
        FindBestSD.MinPos = MinPos



        ''''Write to ListBox and file
        '''On Error GoTo OpenError

        '''ChartFilename = Application.StartupPath & "\BestSD.txt"
        '''ChartFile = FreeFile()
        '''FileOpen(ChartFile, ChartFilename, OpenMode.Output)
        '''ListBox.Items.Clear()

        '''ResultString = "Max1: " & AbsMaxPos & "  " & SdArray(AbsMaxPos)
        '''ListBox.Items.Add(ResultString)
        '''PrintLine(ChartFile, ResultString)

        '''ResultString = "Min: " & MinPos & "  " & SdArray(MinPos)
        '''ListBox.Items.Add(ResultString)
        '''PrintLine(ChartFile, ResultString)

        '''ResultString = "Max2: " & RightMaxPos & "  " & SdArray(RightMaxPos)
        '''ListBox.Items.Add(ResultString)
        '''PrintLine(ChartFile, ResultString)

        '''For i = 1 To 200
        '''    Zeile = i & vbTab & SdArray(i)
        '''    ListBox.Items.Add(Zeile)
        '''    PrintLine(ChartFile, Zeile)
        '''Next i

        '''FileClose(ChartFile)

        Exit Function

        '''OpenError:
        '''        MsgBox(ChartFilename, , "Write error")
        '''        FileClose(ChartFile)
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

End Module
