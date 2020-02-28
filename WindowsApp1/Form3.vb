Option Explicit On

Public Class ReadTodaysSharePrice


    Dim Share_Download_idx As Long
    Private Sub C_ReadAllShares_Click(sender As Object, e As EventArgs) Handles C_ReadAllShares.Click
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

        Share_Download_idx = LBound(CompanyListArray)
        Timer1.Enabled = True

    End Sub

    Private Sub C_ReadSingleShare_Click(sender As Object, e As EventArgs) Handles C_ReadSingleShare.Click

        Dim arry As Double()
        Dim TodaysSharePrice As ShareResult
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

        Dim i As Long

        For i = LBound(CompanyListArray) To UBound(CompanyListArray)
            Application.DoEvents()
            If InStr(1, CompanyListArray(i).Name, T_Search.Text, vbTextCompare) > 0 _
                Or InStr(1, CompanyListArray(i).WKN, T_Search.Text, vbTextCompare) > 0 _
                Or InStr(1, CompanyListArray(i).ISIN, T_Search.Text, vbTextCompare) _
            Then

                ReDim arry(0 To 0)
                arry(0) = Read_Peketec(CompanyListArray(i).WKN)
                ReDim Preserve arry(0 To UBound(arry) + 1)
                arry(1) = Read_Ariva(CompanyListArray(i).WKN)
                ReDim Preserve arry(0 To UBound(arry) + 1)
                arry(2) = Read_BoerseStuttgart(CompanyListArray(i).WKN)
                ReDim Preserve arry(0 To UBound(arry) + 1)
                arry(3) = Read_Comdirect(CompanyListArray(i).WKN)
                ReDim Preserve arry(0 To UBound(arry) + 1)
                arry(4) = Read_FinanzNachrichten(CompanyListArray(i).WKN)
                TodaysSharePrice = GetvalidSharePrice(arry)

                L_Name.Text = CompanyListArray(i).Name
                L_WKN.Text = CompanyListArray(i).WKN
                L_ISIN.Text = CompanyListArray(i).ISIN
                L_SharePrice.Text = TodaysSharePrice.Value
                If TodaysSharePrice.ErrorString <> "" Then
                    ListBox2.Items.Add(CompanyListArray(i).Name & "  " & CompanyListArray(i).WKN & "   Value: " & TodaysSharePrice.Value & "  " & TodaysSharePrice.ErrorString)
                End If

            End If
        Next i
    End Sub


    Public Sub ReadCompanyListFile()
        Dim CompanyListFilename As String
        Dim CompanyListFile As Integer
        Dim Zeile As String
        Dim CompanyListEntities() As String
        Dim idx As Long

        ReDim CompanyListArray(0 To 0)


        On Error GoTo ReadCompanyListFileErr

        CompanyListFilename = Application.StartupPath & "\ISIN-WKN.txt"
        CompanyListFile = FreeFile()

        FileOpen(CompanyListFile, CompanyListFilename, OpenMode.Input)

        While Not EOF(CompanyListFile)
            Zeile = LineInput(CompanyListFile)
            If Zeile <> "" Then
                '''ListBox2.Items.Add(Zeile)
                SepariereString(Zeile, CompanyListEntities, vbTab)
                idx = UBound(CompanyListArray)
                CompanyListArray(idx).Name = CompanyListEntities(0)
                CompanyListArray(idx).WKN = CompanyListEntities(1)
                CompanyListArray(idx).ISIN = CompanyListEntities(2)

                ''''Search doubbles
                '''Dim i As Long
                '''For i = 0 To UBound(CompanyListArray) - 1
                '''    If CompanyListArray(i).WKN = CompanyListArray(idx).WKN Then
                '''        ListBox2.Items.Add(Zeile)
                '''    End If
                '''Next i

                ReDim Preserve CompanyListArray(0 To UBound(CompanyListArray) + 1)
            End If

        End While
        ReDim Preserve CompanyListArray(0 To UBound(CompanyListArray) - 1)
        FileClose(CompanyListFile)

        Exit Sub
ReadCompanyListFileErr:
        MsgBox(CompanyListFilename & vbCr & Err.Description, , "xxxxx")
    End Sub


    Private Sub WriteHistoryFile(WKN As String, CurrentDate As String, SharePrice As String)
        Dim HistoryFileName As String
        Dim HistoryFile As Integer
        Dim i As Integer
        Dim Zeile As String

        HistoryFileName = Application.StartupPath & "\History\" & WKN & ".txt"

        HistoryFile = FreeFile()
        On Error GoTo OpenError

        FileOpen(HistoryFile, HistoryFileName, OpenMode.Append)

        Dim idx As Long

        Zeile = FormatDate(CurrentDate) & "; ; ; ;" & SharePrice
        PrintLine(HistoryFile, Zeile)
        FileClose(HistoryFile)


        Exit Sub

OpenError:
        MsgBox(HistoryFileName, , "Write error")

    End Sub

    Private Sub ReadTodaysSharePrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadCompanyListFile()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim i As Long
        Dim arry As Double()
        Dim TodaysSharePrice As ShareResult

        i = Share_Download_idx

        ReDim arry(0 To 0)
        arry(0) = Read_Peketec(CompanyListArray(i).WKN)
        ReDim Preserve arry(0 To UBound(arry) + 1)
        arry(1) = Read_Ariva(CompanyListArray(i).WKN)
        ReDim Preserve arry(0 To UBound(arry) + 1)
        arry(2) = Read_BoerseStuttgart(CompanyListArray(i).WKN)
        ReDim Preserve arry(0 To UBound(arry) + 1)
        arry(3) = Read_Comdirect(CompanyListArray(i).WKN)
        ReDim Preserve arry(0 To UBound(arry) + 1)
        arry(4) = Read_FinanzNachrichten(CompanyListArray(i).WKN)

        TodaysSharePrice = GetvalidSharePrice(arry)


        L_Name.Text = CompanyListArray(i).Name
        L_WKN.Text = CompanyListArray(i).WKN
        L_ISIN.Text = CompanyListArray(i).ISIN
        L_SharePrice.Text = TodaysSharePrice.Value
        ListBox1.Items.Add(CompanyListArray(i).Name & "  " & CompanyListArray(i).WKN & "  " & TodaysSharePrice.Value)

        If TodaysSharePrice.ErrorString <> "" Then
            ListBox2.Items.Add(CompanyListArray(i).Name & "  " & CompanyListArray(i).WKN & "   Value: " & TodaysSharePrice.Value & "  " & TodaysSharePrice.ErrorString)
        End If

        WriteHistoryFile(CompanyListArray(i).WKN, Now.Date, L_SharePrice.Text)

        Share_Download_idx = Share_Download_idx + 1

        If Share_Download_idx > UBound(CompanyListArray) Then
            Timer1.Enabled = False
        End If
    End Sub

End Class