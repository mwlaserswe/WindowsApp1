Public Class Form1

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        ChartList.Show()
    End Sub

    Private Sub GgggToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GgggToolStripMenuItem.Click
        ChartList.Show()
    End Sub

    Private Sub ReadSingleShareValueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadSingleShareValueToolStripMenuItem.Click
        ReadSingleShareValue.Show()
    End Sub

    Private Sub SaveWebPageAsHTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveWebPageAsHTMLToolStripMenuItem.Click
        SaveWebpageAsHTML.Show()
    End Sub

    Private Sub ScanWebForWKNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScanWebForWKNToolStripMenuItem.Click
        ScanWebForWKN.Show()
    End Sub


    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        ReadTodaysSharePrice.Show()
    End Sub

    Private Sub CheckWeekdayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckWeekdayToolStripMenuItem.Click
        ServiceCheckWeekDay.Show()
    End Sub

    Private Sub ReadXMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadXMLToolStripMenuItem.Click
        XMLReader.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Init DataGridView1 

        ' Spalten hinzufügen
        DataGridView1.Columns.Add("spCompany", "Company")
        DataGridView1.Columns.Add("spWKN", "WKN")
        DataGridView1.Columns.Add("spIsin", "ISIN")
        DataGridView1.Columns.Add("spIndex", "Index")
        DataGridView1.Columns.Add("spStatus", "Status")

        ' Breite einstellen
        '''For i = 0 To (DataGridView1.Columns.Count) - 1
        '''    DataGridView1.Columns(i).Width = 75
        '''Next
        DataGridView1.Columns(0).Width = 75
        DataGridView1.Columns(1).Width = 75
        DataGridView1.Columns(2).Width = 110
        DataGridView1.Columns(3).Width = 35
        DataGridView1.Columns(4).Width = 20

        'DataGridView1 row = DataGridView.Rows(0)
        '    row.Height = 15


        '''    DataGridView1.Rows = 5
        '''    FG_CompPartial.FixedCols = 1      '1. Column fix
        '''    'FG_CompPartial.FixedRows = 1      '1. Row fix (not used here)

        ' "\ISIN-WKN.txt" -> CompanyListArray()
        CompanyFileToArray(Application.StartupPath & "\ISIN-WKN.txt", CompanyListArray)

        ArrayToFlexFrid(CompanyListArray)



        SdLength = 20
        HS_SD.Value = SdLength
        GlbScaleX = 1
        GlbScaleY = 1
        ScaleLast.X = GlbScaleX
        ScaleLast.Y = GlbScaleY


        GlbOffX = 1
        GlbOffY = 1
        OffsetLast.X = GlbOffX
        OffsetLast.Y = GlbOffY

    End Sub

    Private Sub GridViewTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GridViewTestToolStripMenuItem.Click
        Form7.Show()
    End Sub


    Private Sub CompanyFileToArray(CompanyListFilename As String, ByRef CompanyListArray() As ShareItem)
        Dim CompanyListFile As Integer
        Dim Zeile As String
        Dim CompanyListEntities() As String
        Dim idx As Long

        ReDim CompanyListArray(0 To 0)
        '    MyList.Clear
        '    List2.Clear

        On Error GoTo ReadCompanyListFileErr

        'CompanyListFilename = App.Path & "\ISIN-WKN.txt"
        CompanyListFile = FreeFile()
        'Open CompanyListFilename For Input As CompanyListFile
        FileOpen(CompanyListFile, CompanyListFilename, OpenMode.Input)
        ' Close before reopening in another mode.

        While Not EOF(CompanyListFile)
            Zeile = LineInput(CompanyListFile)
            If Zeile <> "" Then
                'MyList.Items.Add(Zeile)
                SepariereString(Zeile, CompanyListEntities, vbTab)
                idx = UBound(CompanyListArray)
                CompanyListArray(idx).Name = CompanyListEntities(0)
                CompanyListArray(idx).WKN = CompanyListEntities(1)
                CompanyListArray(idx).ISIN = CompanyListEntities(2)
                If UBound(CompanyListEntities) >= 3 Then
                    CompanyListArray(idx).Index = CompanyListEntities(3)
                End If

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

    Private Sub ArrayToFlexFrid(ByRef CompanyListArray() As ShareItem)
        Dim idx As Long

        Dim sTest As String

        '''If (0 / 1) + (Not Not CompanyListArray) = 0 Then
        '''    ' Array ist nicht nicht dimensioniert
        '''    Exit Sub
        '''End If


        For idx = 0 To UBound(CompanyListArray)


            ' Zeilen hinzufügen
            DataGridView1.Rows.Add(CompanyListArray(idx).Name, CompanyListArray(idx).WKN, CompanyListArray(idx).ISIN, CompanyListArray(idx).Index, "--")
            DataGridView1.Rows(idx).Height = 15


        Next idx
    End Sub


    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Dim Fullpath As String

        Dim column As Integer
        Dim row As Integer
        Dim CompanyName As String
        Dim WKN As String



        ' DataGridView1.Row is cursor
        row = DataGridView1.CurrentCell.RowIndex
        column = 1  ' Point to WKN columnn
        WKN = DataGridView1.Item(column, row).Value
        Fullpath = Application.StartupPath & "\History\" & WKN & ".txt"
        T_HistoryFileName.Text = Fullpath

        column = 0  ' Point to company name columnn
        CompanyName = DataGridView1.Item(column, row).Value
        ReadHistoryFileToChartArray(Fullpath, CompanyName)

        RefreshChart()

    End Sub



    Private Sub RefreshChart()
        PicChart.CreateGraphics.Clear(Color.White)
        MovingAverage(SdLength)
        Analyse_02(T_InvestmentStart.Text, T_StartSharePrice.Text)
        DispCoordinateSystem(PicChart)
        DisplayChart(PicChart)
    End Sub

    Private Sub RefreshDataGrid_Click(sender As Object, e As EventArgs) Handles RefreshDataGrid.Click
        DataGridView1.Rows.Clear()
        ArrayToFlexFrid(CompPartialLstArr)
    End Sub


    Private Sub HS_SD_Scroll(sender As Object, e As ScrollEventArgs) Handles HS_SD.Scroll
        T_SD.Text = HS_SD.Value
        SdLength = HS_SD.Value

        '''If (0 / 1) + (Not Not ChartArray) = 0 Then
        '''    ' Array ist nicht nicht dimensioniert
        '''    Exit Sub
        '''End If


        'PicChart.Cls
        ''MovingAverage(SdLength)
        'Analyse_02 Form1.T_InvestmentStart, T_StartSharePrice

        RefreshChart()

        ''DispCoordinateSystem(PicChart)
        ''DisplayChart(PicChart)

    End Sub

    Private Sub TransformToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransformToolStripMenuItem.Click
        RotateImageExamples.Show()
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
        Else
            If GlbScaleX <> 0 And GlbScaleY <> 0 Then

                MouseXY.X = (X - GlbOffX) / GlbScaleX
                MouseXY.Y = (Y - (PicChart.Height - GlbOffY)) / -GlbScaleY
                T_MouseXY.Text = Format(MouseXY.X, "0") & " " & Format(MouseXY.Y, "0")
                '''CursorDate = DateSerial(2000, 1, 1) + CInt(MouseXY.X) - 1
                ' T_CursorDate = CursorDate

                ' Array ist nicht nicht dimensioniert
                '''If (0 / 1) + (Not Not ChartArray) <> 0 Then
                If MouseXY.X <= UBound(ChartArray) And MouseXY.X >= LBound(ChartArray) Then
                    T_CursorDate.Text = ChartArray(MouseXY.X).myDate
                    T_Value.Text = ChartArray(MouseXY.X).Value
                    T_Account.Text = Format(ChartArray(MouseXY.X).Account, "0.00")
                    T_SD1.Text = Format(ChartArray(MouseXY.X).SD, "0.00")
                End If
                '''End If

            End If


            T_X_Sc_Off.Text = "X-Scale: " & GlbScaleX & "   X-Offset: " & GlbOffX
            '        T_Y_Sc_Off.Text = "Y-Scale: " & GlbScaleY & "   Y-Offset: " & GlbOffY
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles T_X_Sc_Off.TextChanged

    End Sub

    Private Sub C_LastYear_Click(sender As Object, e As EventArgs) Handles C_LastYear.Click
        ScaleChart(UBound(ChartArray), 261)
    End Sub
    Private Sub C_LastMonth_Click(sender As Object, e As EventArgs) Handles C_LastMonth.Click
        ScaleChart(UBound(ChartArray), 22)
    End Sub
    Private Sub C_LaserWeek_Click(sender As Object, e As EventArgs) Handles C_LaserWeek.Click
        ScaleChart(UBound(ChartArray), 5)
    End Sub

    Private Sub C_HomeView_Click(sender As Object, e As EventArgs) Handles C_HomeView.Click
        'GlbScaleX = 1
        GlbScaleY = 1
        'ScaleLast.X = GlbScaleX
        ScaleLast.Y = GlbScaleY


        'GlbOffX = 0
        GlbOffY = 0
        'OffsetLast.X = GlbOffX
        OffsetLast.Y = GlbOffY

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
    End Sub



    Private Sub ReadHistoricFromARIVAdeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadHistoricFromARIVAdeToolStripMenuItem.Click
        ReadHistoricFromAriva.Show()
    End Sub
End Class




