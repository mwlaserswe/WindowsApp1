﻿Public Class FrmFindBestSMA
    Dim PtArray As Point()
    Dim idx As Integer

    Dim ColorCoord As Color

    Dim DemoBestSD As BestSMA

    Public Structure PicScaling
        Dim ScX As Double
        Dim ScY As Double
        Dim OffX As Double
        Dim OffY As Double
    End Structure

    Dim Sc As PicScaling

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tmp As BestSMA
        tmp = FindBestMultipleSMA(500, 50)
    End Sub


    Private Sub FrmFindBestSMA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sc.ScX = 1
        Sc.ScY = 1
        Sc.OffX = 0
        Sc.OffY = -50   'PictureBox1.Height / 2

        CB_SelectSmaMethod.Items.Add("Best SMA of last year")
        CB_SelectSmaMethod.Items.Add("Smoothed best SMA of last year")
        CB_SelectSmaMethod.Items.Add("Best SMA all time")
        CB_SelectSmaMethod.Items.Add("Smoothed best SMA all time")
        CB_SelectSmaMethod.Items.Add("Best SMA in period")
        CB_SelectSmaMethod.Items.Add("Smoothed best SMA in periode")
        CB_SelectSmaMethod.SelectedIndex = 0
    End Sub

    Private Sub B_FindBestSDSingle_Click(sender As Object, e As EventArgs) Handles B_FindBestSDSingle.Click
        Dim DemoBestSD As BestSMA
        Dim ChartFile As Integer
        Dim Zeile As String
        Dim ChartFilename As String
        Dim ResultString As String

        If CB_SelectSmaMethod.SelectedIndex = 0 Then
            DemoBestSD = FindBestSMA(UBound(ChartArray) - 260, 260)  '260 Entries in HistoryArray is about 1 year. 
        ElseIf CB_SelectSmaMethod.SelectedIndex = 1 Then
            DemoBestSD = FindSmoothedBestSMA(UBound(ChartArray) - 260, 260)  '260 Entries in HistoryArray is about 1 year. 
        ElseIf CB_SelectSmaMethod.SelectedIndex = 2 Then
            DemoBestSD = FindBestSMA(10, 9999)  '260 Entries in HistoryArray is about 1 year. 9999: all
        ElseIf CB_SelectSmaMethod.SelectedIndex = 3 Then
            DemoBestSD = FindSmoothedBestSMA(10, 9999)  '260 Entries in HistoryArray is about 1 year. 9999: all
        ElseIf CB_SelectSmaMethod.SelectedIndex = 4 Then
            'DemoBestSD = FindBestSMA(UBound(ChartArray) - 260, 260)  '260 Entries in HistoryArray is about 1 year. 9999: all
        ElseIf CB_SelectSmaMethod.SelectedIndex = 5 Then
            'DemoBestSD = FindSmoothedBestSMA(UBound(ChartArray) - 260, 260)  '260 Entries in HistoryArray is about 1 year. 9999: all
        End If

        Dim FlyingListBox As FrmFlyingListBox
        Dim ListArray() As String

        ReDim ListArray(0)

        ResultString = "Max1: " & DemoBestSD.AbsMaxPos & "  " & DemoBestSD.AbsMax
        ListArray(0) = ResultString

        PictureBox1.CreateGraphics.Clear(Color.White)
        DrawStartNew(PictureBox1, 0, 1 * 100, Sc, Color.Red)
        DrawLineNew(PictureBox1, 200, 1 * 100, Sc, Color.Red)
        DrawEndNew(PictureBox1, Color.Red)

        DrawStartNew(PictureBox1, 0, DemoBestSD.SMAArry(0) * 100, Sc, Color.Red)
        For i = 1 To 200
            Zeile = i & vbTab & DemoBestSD.SMAArry(i)
            DrawLineNew(PictureBox1, i, DemoBestSD.SMAArry(i) * 100, Sc, Color.Red)
            ReDim Preserve ListArray(i)
            ListArray(i) = Zeile
            ''''PrintLine(ChartFile, Zeile)
        Next i
        DrawEndNew(PictureBox1, Color.Red)

        FlyingListBox = New FrmFlyingListBox
        FlyingListBox.Title = "Write chart array"
        FlyingListBox.Filename = Application.StartupPath & "\BestSMA.txt"
        FlyingListBox.ListArray = ListArray
        FlyingListBox.Show()



    End Sub

    Private Sub DrawStartNew(Pic As PictureBox, X As Single, Y As Single, Sc As PicScaling, LclColor As Color)
        Dim PicX As Single
        Dim PicY As Single

        PicX = (X * Sc.ScX) + Sc.OffX
        PicY = Form1.PicChart.Height - (Y * Sc.ScY) - Sc.OffY

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

    Private Sub DrawLineNew(Pic As PictureBox, X As Single, Y As Single, Sc As PicScaling, LclColor As Color)
        Dim PicX As Single
        Dim PicY As Single

        Dim pt1 As Point

        PicX = (X * Sc.ScX) + Sc.OffX
        PicY = Form1.PicChart.Height - (Y * Sc.ScY) - Sc.OffY

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



    Private Sub DrawEndNew(Pic As PictureBox, LclColor As Color)

        Dim pen1 As New System.Drawing.Pen(LclColor, 1)
        Pic.CreateGraphics.DrawLines(pen1, PtArray)
    End Sub






End Class