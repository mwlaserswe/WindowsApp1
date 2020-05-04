Option Explicit On

Imports System.IO
Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        FrmChartList.Show()
    End Sub

    Private Sub GgggToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GgggToolStripMenuItem.Click
        FrmChartList.Show()
    End Sub

    Private Sub ReadSingleShareValueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadSingleShareValueToolStripMenuItem.Click
        FrmReadSingleShareValue.Show()
    End Sub

    Private Sub SaveWebPageAsHTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveWebPageAsHTMLToolStripMenuItem.Click
        FrmSaveWebpageAsHTML.Show()
    End Sub

    Private Sub ScanWebForWKNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScanWebForWKNToolStripMenuItem.Click
        FrmScanWebForWKN.Show()
    End Sub


    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        FrmReadTodaysSharePrice.Show()
    End Sub

    Private Sub CheckWeekdayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckWeekdayToolStripMenuItem.Click
        FrmServiceCheckWeekDay.Show()
    End Sub

    Private Sub ReadXMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadXMLToolStripMenuItem.Click
        FrmTestReadWriteXML.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        T_InvestmentStart.Text = My.Settings.InvestmentStart


        ' Init DataGridView1 
        DataGridView1.ColumnHeadersVisible = True
        DataGridView1.RowHeadersVisible = False

        ' Spalten hinzufügen
        DataGridView1.Columns.Add(spPrimaryKey, "Key")
        DataGridView1.Columns.Add(spCompany, "Company")
        DataGridView1.Columns.Add(spWKN, "WKN")
        DataGridView1.Columns.Add(spIsin, "ISIN")
        DataGridView1.Columns.Add(spIndex, "Index")
        DataGridView1.Columns.Add(spStatus, "Status")
        DataGridView1.Columns.Add(spAccount, "Account")

        ' Breite einstellen
        DataGridView1.Columns(spPrimaryKey).Width = 30
        DataGridView1.Columns(spCompany).Width = 75
        DataGridView1.Columns(spWKN).Width = 75
        DataGridView1.Columns(spIsin).Width = 110
        DataGridView1.Columns(spIndex).Width = 35
        DataGridView1.Columns(spStatus).Width = 20
        DataGridView1.Columns(spAccount).Width = 20

        'DataGridView1 row = DataGridView.Rows(0)
        '    row.Height = 15


        '''    DataGridView1.Rows = 5
        '''    FG_CompPartial.FixedCols = 1      '1. Column fix
        '''    'FG_CompPartial.FixedRows = 1      '1. Row fix (not used here)

        ' "\ISIN-WKN.txt" -> CompanyListArray()
        CompanyFileToArray(Application.StartupPath & "\ISIN-WKN.txt", CompanyListArray)
        ' Init: CompPartialLstArr = CompanyListArray
        CompanyFileToArray(Application.StartupPath & "\ISIN-WKN.txt", CompPartialLstArr)


        ArrayToFlexFrid(CompanyListArray)



        SMALength = 20
        HS_SMA.Value = SMALength
        T_SMA.Text = SMALength

        GlbScaleX = 1
        GlbScaleY = 1
        ScaleLast.X = GlbScaleX
        ScaleLast.Y = GlbScaleY


        GlbOffX = 1
        GlbOffY = 1
        OffsetLast.X = GlbOffX
        OffsetLast.Y = GlbOffY

        Analyse2.Checked = True

        ComboBox1.Items.Add("Use SMA of TextBox")               'Index 0
        ComboBox1.Items.Add("Use best SMA since 2000")          'Index 1
        ComboBox1.Items.Add("Use best SMA since CORONA")        'Index 2
        ComboBox1.Items.Add("Use best user defined SMA")        'Index 3
        ComboBox1.SelectedIndex = 0

        B_Last3Month_Click(Nothing, Nothing)
        Ch_FitY.Checked = True
    End Sub

    Private Sub GridViewTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GridViewTestToolStripMenuItem.Click
        FrmTestDataGrid.Show()
    End Sub


    '''    Private Sub CompanyFileToArray(CompanyListFilename As String, ByRef CompanyListArray() As ShareItem)
    '''        Dim CompanyListFile As Integer
    '''        Dim Zeile As String
    '''        Dim CompanyListEntities() As String
    '''        Dim idx As Long

    '''        ReDim CompanyListArray(0 To 0)
    '''        '    MyList.Clear
    '''        '    List2.Clear

    '''        On Error GoTo ReadCompanyListFileErr

    '''        'CompanyListFilename = App.Path & "\ISIN-WKN.txt"
    '''        CompanyListFile = FreeFile()
    '''        'Open CompanyListFilename For Input As CompanyListFile
    '''        FileOpen(CompanyListFile, CompanyListFilename, OpenMode.Input)
    '''        ' Close before reopening in another mode.

    '''        idx = 0
    '''        While Not EOF(CompanyListFile)
    '''            Zeile = LineInput(CompanyListFile)
    '''            If Zeile <> "" Then
    '''                'MyList.Items.Add(Zeile)
    '''                SepariereString(Zeile, CompanyListEntities, vbTab)
    '''                CompanyListArray(idx).Name = CompanyListEntities(0)
    '''                CompanyListArray(idx).WKN = CompanyListEntities(1)
    '''                CompanyListArray(idx).ISIN = CompanyListEntities(2)
    '''                If UBound(CompanyListEntities) >= 3 Then
    '''                    CompanyListArray(idx).Index = CompanyListEntities(3)
    '''                End If

    '''                '''            'Search doubbles
    '''                '''            Dim i As Long
    '''                '''            For i = 0 To UBound(CompanyListArray) - 1
    '''                '''                If CompanyListArray(i).WKN = CompanyListArray(idx).WKN Then
    '''                '''                    List2.AddItem Zeile
    '''                '''                End If
    '''                '''            Next i
    '''                idx = idx + 1
    '''                ReDim Preserve CompanyListArray(0 To UBound(CompanyListArray) + 1)
    '''            End If

    '''        End While
    '''        idx = idx - 1
    '''        ReDim Preserve CompanyListArray(0 To UBound(CompanyListArray) - 1)
    '''        FileClose(CompanyListFile)

    '''        Exit Sub
    '''ReadCompanyListFileErr:
    '''        MsgBox(CompanyListFilename & vbCr & Err.Description, , "xxxxx")

    '''    End Sub

    Private Sub ArrayToFlexFrid(ByRef CompanyListArray() As ShareItem)
        Dim idx As Long

        If Not ArrayValid(CompanyListArray) Then
            ' Array ist nicht dimensioniert
            Exit Sub
        End If

        For idx = 0 To UBound(CompanyListArray)
            ' Zeilen hinzufügen
            DataGridView1.Rows.Add(idx, CompanyListArray(idx).Name, CompanyListArray(idx).WKN, CompanyListArray(idx).ISIN, CompanyListArray(idx).Index, "--")
            DataGridView1.Rows(idx).Height = 15
        Next idx
    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Dim Fullpath As String

        Dim column As Object
        Dim row As Integer
        Dim CompanyName As String
        Dim WKN As String
        Dim ISIN As String

        Dim CurrentShareInfo As ShareInfo



        ' DataGridView1.Row is cursor
        row = DataGridView1.CurrentCell.RowIndex
        column = spWKN      ' Point to WKN columnn 1
        WKN = DataGridView1.Item(column, row).Value
        T_CurrWKN.Text = WKN
        Fullpath = Application.StartupPath & "\History\" & WKN & ".txt"
        T_HistoryFileName.Text = Fullpath

        column = spIsin     ' Point to ISIN columnn 2
        ISIN = DataGridView1.Item(column, row).Value
        T_CurrISIN.Text = ISIN

        column = spCompany  ' Point to company name columnn 0
        CompanyName = DataGridView1.Item(column, row).Value
        T_CurrCompName.Text = CompanyName
        ReadHistoryFileToChartArray(Fullpath, CompanyName)

        ''FindBestSD(5000, ListBox1)

        If Ch_FitY.Checked Then
            Dim LastValue As Double
            LastValue = ChartArray(UBound(ChartArray)).Value
            GlbScaleY = 0.7 * PicChart.Height / LastValue
        End If

        CurrentShareInfo = ReadShareInfo(Application.StartupPath & "\HistoryInfo\" & WKN & ".xml")

        Select Case ComboBox1.SelectedIndex
            Case 0
                ' Use SMA of TextBox
                SMALength = T_SMA.Text
            Case 1
                ' Use best SMA since 2000
                SMALength = CurrentShareInfo._AbsMaxPos
                T_SMA.Text = SMALength
                'Case 2
                ' Use best SMA since CORONA
                'Case 3
                ' Use best user defined SMA"
        End Select


        RefreshChart()

        T_CurrAccount.Text = ChartArray(UBound(ChartArray)).Account

    End Sub



    Private Sub RefreshChart()
        PicChart.CreateGraphics.Clear(Color.White)
        SimpleMovingAverage(SMALength)
        If Analyse1.Checked Then
        ElseIf Analyse2.Checked Then
            Analyse_02(T_InvestmentStart.Text, T_StartSharePrice.Text)
        ElseIf Analyse3.Checked Then
            Analyse_03(T_InvestmentStart.Text, T_StartSharePrice.Text)
        ElseIf Analyse4.Checked Then
            Analyse_04(T_InvestmentStart.Text, T_StartSharePrice.Text, 0.104)
        ElseIf Analyse5.Checked Then

        End If
        DispCoordinateSystem(PicChart)
        DisplayChart(PicChart)
        DisplayDate(PicChart, TextBox6)
    End Sub

    Private Sub RefreshDataGrid_Click(sender As Object, e As EventArgs) Handles RefreshDataGrid.Click
        DataGridView1.Rows.Clear()
        ArrayToFlexFrid(CompPartialLstArr)
    End Sub


    Private Sub HS_SD_Scroll(sender As Object, e As ScrollEventArgs) Handles HS_SMA.Scroll
        T_SMA.Text = HS_SMA.Value
        SMALength = HS_SMA.Value

        If Not ArrayValid(ChartArray) Then
            ' Array ist nicht dimensioniert
            Exit Sub
        End If

        'PicChart.Cls
        ''MovingAverage(SdLength)
        'Analyse_02 Form1.T_InvestmentStart, T_StartSharePrice

        RefreshChart()
        T_CurrAccount.Text = ChartArray(UBound(ChartArray)).Account

        ''DispCoordinateSystem(PicChart)
        ''DisplayChart(PicChart)

    End Sub

    Private Sub TransformToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransformToolStripMenuItem.Click
        FrmTestRotateImageExamples.Show()
    End Sub


    Private Sub PicChart_MouseDown(sender As Object, e As MouseEventArgs) Handles PicChart.MouseDown
        MouseDnPos.X = PicChart.PointToClient(MousePosition).X
        MouseDnPos.Y = PicChart.PointToClient(MousePosition).Y

        OffsetCurrent.X = GlbOffX
        OffsetCurrent.Y = GlbOffY



        ScaleCurrent.X = GlbScaleX
        ScaleCurrent.Y = GlbScaleY


        MouseCenterPos = MouseXY
    End Sub


    Private Sub PicChart_MouseMove(sender As Object, e As MouseEventArgs) Handles PicChart.MouseMove

        Dim CursorDate As Date
        Dim Button As MouseButtons
        Dim X As Single
        Dim Y As Single


        Button = MouseButtons
        TextBox2.Text = Button
        X = PicChart.PointToClient(MousePosition).X
        Y = PicChart.PointToClient(MousePosition).Y

        '    Dim MouseX As Single
        '    Dim MouseY As Single

        ' change offset
        If Button = MouseButtons.Left Then
            MyMouseMove.X = X - MouseDnPos.X
            MyMouseMove.Y = -(Y - MouseDnPos.Y)


            GlbOffX = OffsetCurrent.X + MyMouseMove.X
            GlbOffY = OffsetCurrent.Y + MyMouseMove.Y
            '''OffsetLast.X = GlbOffX
            '''OffsetLast.Y = GlbOffY

            RefreshChart()
            T_CurrAccount.Text = ChartArray(UBound(ChartArray)).Account

            'T_Current_Sc_Off.Text = "X current sc: " & ScaleCurrent.X & "   X current off: " & OffsetCurrent.X
            T_Current_Sc_Off.Text = "MyMouseMove.X " & MyMouseMove.X




            ' change scaling
        ElseIf Button = MouseButtons.Right Then
            MyMouseMove.X = X - MouseDnPos.X
            MyMouseMove.Y = -(Y - MouseDnPos.Y)

            ' Scaling eigher X or Y
            If Math.Abs(MyMouseMove.X) > Math.Abs(MyMouseMove.Y) Then
                'GlbScaleX = ScaleCurrent.X + MouseMove.X / 5000
                GlbScaleX = ScaleCurrent.X + (MyMouseMove.X / 500) * (ScaleCurrent.X)
                If GlbScaleX < 0.1 Then
                    GlbScaleX = 0.1
                End If
                ScaleLast.X = GlbScaleX
            Else
                'GlbScaleY = ScaleCurrent.Y + MouseMove.Y / 100
                GlbScaleY = ScaleCurrent.Y + MyMouseMove.Y / 100
                If GlbScaleY < 0.1 Then
                    GlbScaleY = 0.1
                End If
                ScaleLast.Y = GlbScaleY
            End If

            'Intersection of 2 lines: t2 = x (m1 - m2) + t1
            GlbOffX = MouseCenterPos.X * (ScaleCurrent.X - GlbScaleX) + OffsetCurrent.X
            '        GlbOffY = MouseCenterPos.Y * (ScaleCurrent.Y - GlbScaleY) + OffsetCurrent.Y
            OffsetLast.X = GlbOffX

            T_Current_Sc_Off.Text = "X current sc: " & ScaleCurrent.X & "   X current off: " & OffsetCurrent.X
            T_MouseCenter.Text = "X MouseCenterPos: " & MouseCenterPos.X
            '''DoEvents()


            RefreshChart()
            T_CurrAccount.Text = ChartArray(UBound(ChartArray)).Account
        Else
            If GlbScaleX <> 0 And GlbScaleY <> 0 Then

                MouseXY.X = (X - GlbOffX) / GlbScaleX
                MouseXY.Y = (Y - (PicChart.Height - GlbOffY)) / -GlbScaleY
                T_MouseXY.Text = Format(MouseXY.X, "0") & " " & Format(MouseXY.Y, "0")
                '''CursorDate = DateSerial(2000, 1, 1) + CInt(MouseXY.X) - 1
                ' T_CursorDate = CursorDate

                ' Array ist dimensioniert
                If ArrayValid(ChartArray) Then
                    If MouseXY.X <= UBound(ChartArray) And MouseXY.X >= LBound(ChartArray) Then
                        T_CursorDate.Text = ChartArray(MouseXY.X).myDate
                        T_Value.Text = ChartArray(MouseXY.X).Value
                        T_Account.Text = Format(ChartArray(MouseXY.X).Account, "0.00")
                        T_SD1.Text = Format(ChartArray(MouseXY.X).SMA, "0.00")
                    End If
                End If

            End If


            T_X_Sc_Off.Text = "X-Scale: " & GlbScaleX & "   X-Offset: " & GlbOffX
            '        T_Y_Sc_Off.Text = "Y-Scale: " & GlbScaleY & "   Y-Offset: " & GlbOffY
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles T_X_Sc_Off.TextChanged

    End Sub

    Private Sub C_LastYear_Click(sender As Object, e As EventArgs) Handles C_LastYear.Click
        GlbOffY = 0
        GlbScaleY = 1
        ScaleChart(UBound(ChartArray) + 10, 271)
    End Sub
    Private Sub B_Last3Month_Click(sender As Object, e As EventArgs) Handles B_Last3Month.Click
        GlbOffY = 0
        GlbScaleY = 1
        ScaleChart(UBound(ChartArray) + 3, 90)
    End Sub
    Private Sub C_LastMonth_Click(sender As Object, e As EventArgs) Handles C_LastMonth.Click
        GlbOffY = 0
        GlbScaleY = 1
        ScaleChart(UBound(ChartArray) + 1, 22)
    End Sub
    Private Sub C_LaserWeek_Click(sender As Object, e As EventArgs) Handles C_LaserWeek.Click
        GlbOffY = 0
        GlbScaleY = 1
        ScaleChart(UBound(ChartArray) + 1, 5)
    End Sub

    Private Sub C_HomeView_Click(sender As Object, e As EventArgs) Handles C_HomeView.Click
        'GlbScaleX = 1
        GlbScaleY = 1
        'ScaleLast.X = GlbScaleX
        'ScaleLast.Y = GlbScaleY


        'GlbOffX = 0
        GlbOffY = 0
        'OffsetLast.X = GlbOffX
        'OffsetLast.Y = GlbOffY

        'RefreshChart()

        ScaleChart(UBound(ChartArray), UBound(ChartArray))
    End Sub

    Private Sub ScaleChart(idx_End As Double, idx_Length As Double)
        ' Gleichungssystem:
        '     0     = m * idx-Start + t
        ' Pic.Width = m * idx-End   + t
        '
        ' m * idx-Start + t -    0      = 0
        ' m * idx-End   + t - Pic.Width = 0
        '
        ' Gleichungssystem:
        ' A(1, 1) = idx_Start: A(1, 2) = 1: A(1, 3) = 0
        ' A(2, 1) = idx_End:   A(2, 2) = 1: A(2, 3) = Pic.Width
        Dim idx_Start As Double

        idx_Start = idx_End - idx_Length

        A(1, 1) = idx_Start : A(1, 2) = 1 : A(1, 3) = 0
        A(2, 1) = idx_End : A(2, 2) = 1 : A(2, 3) = PicChart.Width

        X = GaussPivot(A, 2)

        GlbScaleX = X(1)
        GlbOffX = X(2)

        RefreshChart()
        T_CurrAccount.Text = ChartArray(UBound(ChartArray)).Account
    End Sub



    Private Sub ReadHistoricFromARIVAdeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadHistoricFromARIVAdeToolStripMenuItem.Click
        FrmReadHistoricFromAriva.Show()
    End Sub


    Private Sub C_BuySell_Click(sender As Object, e As EventArgs) Handles C_BuySell.Click
        Dim Fullpath As String

        Dim column As Object
        Dim row As Integer
        Dim CompanyName As String
        Dim WKN As String
        Dim CurrentShareInfo As ShareInfo

        Dim dmystr As String

        'Check if BUY signal...


        For idx = LBound(CompPartialLstArr) To UBound(CompPartialLstArr)



            'row = idx   ' Point to row    --> this doesn't work if DataGridView is sorted !!   
            column = spWKN   ' Point to WKN columnn 1        
            WKN = CompPartialLstArr(idx).WKN

            'Find row with matching WKN
            For row = LBound(CompPartialLstArr) To UBound(CompPartialLstArr)
                If WKN = DataGridView1.Item(column, row).Value Then
                    Exit For
                End If
            Next

            If WKN <> DataGridView1.Item(column, row).Value Then
                MsgBox("Datagrid and CompPartialArr inconsistent")
                Exit Sub
            End If

            Fullpath = Application.StartupPath & "\History\" & WKN & ".txt"
            T_HistoryFileName.Text = Fullpath

            column = spCompany   ' Point to company name columnn 0
            CompanyName = DataGridView1.Item(column, row).Value
            ReadHistoryFileToChartArray(Fullpath, CompanyName)

            CurrentShareInfo = ReadShareInfo(Application.StartupPath & "\HistoryInfo\" & WKN & ".xml")

            SMALength = CurrentShareInfo._AbsMaxPos
            T_SMA.Text = SMALength


            SimpleMovingAverage(SMALength)
            If Analyse1.Checked Then
            ElseIf Analyse2.Checked Then
                Analyse_02(T_InvestmentStart.Text, T_StartSharePrice.Text)
            ElseIf Analyse3.Checked Then
                Analyse_03(T_InvestmentStart.Text, T_StartSharePrice.Text)
            ElseIf Analyse4.Checked Then
                Analyse_04(T_InvestmentStart.Text, T_StartSharePrice.Text, 10.4)
            ElseIf Analyse5.Checked Then

            End If
            ''DispCoordinateSystem(PicChart)
            ''DisplayChart(PicChart)

            dmystr = ChartArray(UBound(ChartArray)).Trend

            column = spStatus       ' Point to Status columnn 4
            If InStr(ChartArray(UBound(ChartArray)).Trend, "5:wait", CompareMethod.Text) Then
                DataGridView1.Item(column, row).Style.ForeColor = Color.LightGray
                DataGridView1.Item(column, row).Value = "5:wait"
            ElseIf InStr(ChartArray(UBound(ChartArray)).Trend, "10: Rise", CompareMethod.Text) Then
                DataGridView1.Item(column, row).Style.ForeColor = Color.LightGray
                DataGridView1.Item(column, row).Value = "10: Rise"
            ElseIf InStr(ChartArray(UBound(ChartArray)).Trend, "10: wait", CompareMethod.Text) Then
                DataGridView1.Item(column, row).Style.ForeColor = Color.Red
                DataGridView1.Item(column, row).Value = "10: wait"
            ElseIf InStr(ChartArray(UBound(ChartArray)).Trend, "20: Hold", CompareMethod.Text) Then
                DataGridView1.Item(column, row).Style.ForeColor = Color.Red
                DataGridView1.Item(column, row).Value = "20: Hold"
            ElseIf InStr(ChartArray(UBound(ChartArray)).Trend, "20: Rise", CompareMethod.Text) Then
                DataGridView1.Item(column, row).Style.ForeColor = Color.LightGreen
                DataGridView1.Item(column, row).Value = "20: Rise"
            ElseIf InStr(ChartArray(UBound(ChartArray)).Trend, "30: Rise", CompareMethod.Text) Then
                DataGridView1.Item(column, row).Style.ForeColor = Color.Green
                DataGridView1.Item(column, row).Value = "30: Rise"
            ElseIf InStr(ChartArray(UBound(ChartArray)).Trend, "30: Hold", CompareMethod.Text) Then
                DataGridView1.Item(column, row).Style.ForeColor = Color.LightPink
                DataGridView1.Item(column, row).Value = "30: Hold"
            End If

            column = spAccount      ' Point to Account columnn 5
            DataGridView1.Item(column, row).Value = ChartArray(UBound(ChartArray)).Account



            Application.DoEvents()

        Next


    End Sub





    Private Sub C_Investhopping_Click(sender As Object, e As EventArgs) Handles C_Investhopping.Click
        Dim idx As Long
        Dim Fullpath As String
        Dim CompPartialIdx As Long
        Dim HistoryArray() As HistoryItem
        Dim ChartArrayIdx As Long
        Dim InvestmentStart As Long
        Dim Zeile As String
        Dim EarliestInvestStart As Long
        Dim EarliestWKN As String
        Dim EarliestCompany As String
        Dim InvestmentHold As Long
        Dim StartPriceRisePeriode As Double
        Dim Cnt As Long

        InvestmentStart = 200
        StartPriceRisePeriode = T_StartSharePrice.Text

        Do

            EarliestInvestStart = 99999999

            '*** walk all companies in CompPartialLstArr
            For CompPartialIdx = LBound(CompPartialLstArr) To UBound(CompPartialLstArr)

                TextBox4.Text = InvestmentStart

                Zeile = ""

                Fullpath = Application.StartupPath & "\History\" & CompPartialLstArr(CompPartialIdx).WKN & ".txt"
                '        Zeile = CompPartialLstArr(CompPartialIdx).Name

                ReadHistoryFile(Fullpath, HistoryArray)
                SimpleMovingAverage(SMALength)
                Analyse_02(InvestmentStart, 0)
                '*** find earlest investment start point in all companies
                For ChartArrayIdx = InvestmentStart To UBound(ChartArray)
                    If ChartArray(ChartArrayIdx).Trend = "10: Rise" Then
                        Exit For
                    End If
                Next ChartArrayIdx
                '        Zeile = Zeile & " " & ChartArrayIdx

                If ChartArrayIdx < EarliestInvestStart Then
                    EarliestInvestStart = ChartArrayIdx
                    EarliestWKN = CompPartialLstArr(CompPartialIdx).WKN
                    EarliestCompany = CompPartialLstArr(CompPartialIdx).Name
                End If

                '*** earlieset company found
                Zeile = EarliestCompany & " Start: " & EarliestWKN & " " & EarliestInvestStart




            Next CompPartialIdx

            Fullpath = Application.StartupPath & "\History\" & EarliestWKN & ".txt"
            ReadHistoryFile(Fullpath, HistoryArray)
            SimpleMovingAverage(SMALength)
            Analyse_02(InvestmentStart, StartPriceRisePeriode)

            '*** find next HOLD
            For ChartArrayIdx = EarliestInvestStart To UBound(ChartArray)
                If ChartArray(ChartArrayIdx).Trend = "20: Hold" Then
                    InvestmentHold = ChartArrayIdx
                    Exit For
                End If
            Next ChartArrayIdx

            ReDim Preserve AccountArray(0 To UBound(ChartArray))

            ' No-Invest periode
            For idx = InvestmentStart To EarliestInvestStart - 1
                AccountArray(idx).Name = "No Inv."
                AccountArray(idx).Account = -1
            Next idx

            ' Invest periode
            For idx = EarliestInvestStart To InvestmentHold
                AccountArray(idx) = ChartArray(idx)
            Next idx

            '*** prepare next investment start
            StartPriceRisePeriode = ChartArray(InvestmentHold).Account
            InvestmentStart = ChartArrayIdx + 1

            Zeile = EarliestCompany & " Start: " & EarliestWKN & " " & EarliestInvestStart & ";  Stop: " & ChartArrayIdx


            ListBox1.Items.Add(Zeile)

            Cnt = Cnt + 1
            T_HistoryFileName.Text = Cnt

            Application.DoEvents()

        Loop While InvestmentStart < 1000


        WriteAccountFile(Application.StartupPath & "\Account.txt")

    End Sub


    Private Sub Ch_FitY_CheckedChanged(sender As Object, e As EventArgs) Handles Ch_FitY.CheckedChanged
        If Ch_FitY.Checked Then
            Dim LastValue As Double

            LastValue = ChartArray(UBound(ChartArray)).Value
            GlbScaleY = 0.7 * PicChart.Height / LastValue
            RefreshChart()
            T_CurrAccount.Text = ChartArray(UBound(ChartArray)).Account
        End If

    End Sub

    Private Sub InfoFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoFilesToolStripMenuItem.Click
        FrmInfoFiles.Show()
    End Sub


    Private Sub CheckNumberOfRiseInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckNumberOfRiseInToolStripMenuItem.Click
        Dim FlyingListBox As FrmFlyingListBox
        Dim ListArray() As String

        FindRisingInSequenz(ListArray)

        FlyingListBox = New FrmFlyingListBox
        FlyingListBox.Title = "Number of rising share prices in sequence"
        FlyingListBox.Filename = ""
        FlyingListBox.ListArray = ListArray
        FlyingListBox.Show()
    End Sub

    Private Sub HowManyPercentInSequenceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HowManyPercentInSequenceToolStripMenuItem.Click
        Dim FlyingListBox As FrmFlyingListBox
        Dim ListArray() As String

        FindRisingPercentage(ListArray)

        FlyingListBox = New FrmFlyingListBox
        FlyingListBox.Title = "Percentage in sequence"
        FlyingListBox.Filename = ""
        FlyingListBox.ListArray = ListArray
        FlyingListBox.Show()
    End Sub

    Private Sub FindBestSMAInAllListedShares100Times1YearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindBestSMAInAllListedShares100Times1YearToolStripMenuItem.Click
        FrmFindBestSMA.Show()
    End Sub


    Private Sub WriteChartFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WriteChartFileToolStripMenuItem.Click
        Dim idx As Long
        Dim Zeile As String

        Dim FlyingListBox As FrmFlyingListBox
        Dim ListArray() As String

        ReDim ListArray(UBound(ChartArray))

        Zeile = "Idx" & vbTab & "myDate" & vbTab & "Value" & vbTab & "SMA" & vbTab & "Distance" & vbTab & "Account" & vbTab & "Trend"

        ListArray(idx) = Zeile
        For idx = 1 To UBound(ChartArray)
            Zeile = idx _
                & vbTab & ChartArray(idx).myDate _
                & vbTab & Format(ChartArray(idx).Value, "0.00") _
                & vbTab & Format(ChartArray(idx).SMA, "0.00") _
                & vbTab & Format(ChartArray(idx).Distance, "0.0000") _
                & vbTab & Format(ChartArray(idx).Account, "0.00") _
                & vbTab & ChartArray(idx).Trend
            ListArray(idx) = Zeile
        Next idx

        FlyingListBox = New FrmFlyingListBox
        FlyingListBox.Title = "Write chart array"
        FlyingListBox.Filename = Application.StartupPath & "\Chart.txt"
        FlyingListBox.ListArray = ListArray
        FlyingListBox.Show()
    End Sub

    Private Sub RisePriodeStatisticToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RisePriodeStatisticToolStripMenuItem.Click
        Dim FlyingListBox As FrmFlyingListBox
        Dim ListArray() As String

        RiseSatistics(ListArray)

        FlyingListBox = New FrmFlyingListBox
        FlyingListBox.Title = T_CurrCompName.Text & ": Rise periode statisics"
        FlyingListBox.Filename = ""
        FlyingListBox.ListArray = ListArray
        FlyingListBox.Show()
    End Sub

    Private Sub T_InvestmentStart_TextChanged(sender As Object, e As EventArgs) Handles T_InvestmentStart.TextChanged
        My.Settings.InvestmentStart = T_InvestmentStart.Text
        My.Settings.Save()
    End Sub

    Private Sub PicChart_Click(sender As Object, e As EventArgs) Handles PicChart.Click

    End Sub

    Private Sub PicChart_MouseWheel(sender As Object, e As MouseEventArgs) Handles PicChart.MouseWheel

    End Sub


    ''Private Sub CompleteCompanyWKNISINToolStripMenuItem_Click(sender As Object, e As EventArgs)
    ''    Dim InFileName As String
    ''    Dim OutFileName As String

    ''    InFileName = Path.Combine(Application.StartupPath, "ISIN-WKN-TEST.txt")
    ''    OutFileName = Path.Combine(Application.StartupPath, "ISIN-WKN-TEST-COMPLETE.txt")
    ''    CompleteCompWknIsin(InFileName, OutFileName)
    ''End Sub


End Class




