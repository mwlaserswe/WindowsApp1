Option Explicit On

Public Class ReadTodaysSharePrice


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
                L_Name.Text = CompanyListArray(i).Name
                L_WKN.Text = CompanyListArray(i).WKN
                L_ISIN.Text = CompanyListArray(i).ISIN

                ReDim arry(0 To 0)
                arry(0) = Read_Peketec(CompanyListArray(i).WKN)
                T_S0.Text = arry(0)
                Application.DoEvents()
                ReDim Preserve arry(0 To UBound(arry) + 1)
                arry(1) = Read_Ariva(CompanyListArray(i).WKN)
                T_S1.Text = arry(1)
                Application.DoEvents()
                ReDim Preserve arry(0 To UBound(arry) + 1)
                arry(2) = Read_BoerseStuttgart(CompanyListArray(i).WKN)
                T_S2.Text = arry(2)
                Application.DoEvents()
                ReDim Preserve arry(0 To UBound(arry) + 1)
                arry(3) = Read_Comdirect(CompanyListArray(i).WKN)
                T_S3.Text = arry(3)
                Application.DoEvents()
                ReDim Preserve arry(0 To UBound(arry) + 1)
                arry(4) = Read_FinanzNachrichten(CompanyListArray(i).WKN)
                T_S4.Text = arry(4)
                Application.DoEvents()

                TodaysSharePrice = GetvalidSharePrice(arry)
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


    Private Sub AppendLineToHistoryFile(WKN As String, CurrentDate As String, SharePrice As String)
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


    Private Sub UpdateHistoryFile(WKN As String, CurrentDate As String, SharePrice As String)
        Dim HistoryFileName As String
        Dim HistoryFile As Integer
        Dim HistoryArray() As HistoryItem
        Dim i As Integer
        Dim Zeile As String
        Dim Delta As Double

        HistoryFileName = Application.StartupPath & "\History\" & WKN & ".txt"
        ReadHistoryFile(HistoryFileName, HistoryArray)

        ' If there is a todays shere value, update if possible...
        If HistoryArray(UBound(HistoryArray)).Datum = FormatDate(CurrentDate) Then
            If SharePrice <> 0 Then
                Delta = Math.Abs(SharePrice - (HistoryArray(UBound(HistoryArray)).Schlusskurs)) / HistoryArray(UBound(HistoryArray)).Schlusskurs

                If Delta > 0.1 Then
                    ListBox2.Items.Add(WKN & ": Delta = " & Delta)
                End If

                HistoryArray(UBound(HistoryArray)).Schlusskurs = SharePrice
            End If
        Else    '... if not, append share value

            ReDim Preserve HistoryArray(0 To UBound(HistoryArray) + 1)
            HistoryArray(UBound(HistoryArray)).Datum = FormatDate(CurrentDate)
            HistoryArray(UBound(HistoryArray)).Schlusskurs = SharePrice
        End If


        WriteHistoryFile(HistoryFileName, HistoryArray)

    End Sub


    Private Sub ReadTodaysSharePrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadCompanyListFile()
    End Sub




    Private Sub C_ReadAllShares_Click(sender As Object, e As EventArgs) Handles C_ReadAllShares.Click
        Dim i As Long
        Dim arry As Double()
        Dim TodaysSharePrice As ShareResult

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

        For Share_Download_idx = 0 To UBound(CompanyListArray)

            i = Share_Download_idx
            L_Name.Text = CompanyListArray(i).Name
            L_WKN.Text = CompanyListArray(i).WKN
            L_ISIN.Text = CompanyListArray(i).ISIN
            T_S0.Text = "--"
            T_S1.Text = "--"
            T_S2.Text = "--"
            T_S3.Text = "--"
            T_S4.Text = "--"
            Application.DoEvents()

            ReDim arry(0 To 0)
            arry(0) = Read_Peketec(CompanyListArray(i).WKN)
            T_S0.Text = arry(0)
            Application.DoEvents()
            ReDim Preserve arry(0 To UBound(arry) + 1)
            arry(1) = Read_Ariva(CompanyListArray(i).WKN)
            T_S1.Text = arry(1)
            Application.DoEvents()
            ReDim Preserve arry(0 To UBound(arry) + 1)
            arry(2) = Read_BoerseStuttgart(CompanyListArray(i).WKN)
            T_S2.Text = arry(2)
            Application.DoEvents()
            ReDim Preserve arry(0 To UBound(arry) + 1)
            arry(3) = Read_Comdirect(CompanyListArray(i).WKN)
            T_S3.Text = arry(3)
            Application.DoEvents()
            ReDim Preserve arry(0 To UBound(arry) + 1)
            arry(4) = Read_FinanzNachrichten(CompanyListArray(i).WKN)
            T_S4.Text = arry(4)
            Application.DoEvents()

            TodaysSharePrice = GetvalidSharePrice(arry)
            L_SharePrice.Text = TodaysSharePrice.Value

            ListBox1.Items.Add(CompanyListArray(i).Name & "  " & CompanyListArray(i).WKN & "  " & TodaysSharePrice.Value)

            If TodaysSharePrice.ErrorString <> "" Then
                ListBox2.Items.Add(CompanyListArray(i).Name & "  " & CompanyListArray(i).WKN & "   Value: " & TodaysSharePrice.Value & "  " & TodaysSharePrice.ErrorString)
            End If
            Application.DoEvents()


            UpdateHistoryFile(CompanyListArray(i).WKN, Now.Date, L_SharePrice.Text)



        Next Share_Download_idx


    End Sub


    Public Sub increase(ByVal a() As Long)
        For j As Integer = 0 To UBound(a)
            a(j) = a(j) + 1
        Next j
    End Sub



End Class