Option Explicit On

Imports System.Net
Imports System.IO
Module Util
    Public Function ExtraxtValue(HtmlString As String, SearchItem As String, EndString As String) As String
        Dim GoogleText As String

        '    Dim SearchItem As String
        '    Dim AktuellerKurs As String
        '    Dim InstrumentId As String
        Dim DmyString As String

        Dim PosStart As Long
        Dim PosEnd As Long

        '    SearchItem = "Aktueller Kurs"
        PosStart = InStr(HtmlString, SearchItem)
        DmyString = Mid$(HtmlString, PosStart + Len(SearchItem), 20)
        If PosStart > 0 Then
            PosStart = PosStart + Len(SearchItem) + 1
            PosEnd = InStr(PosStart, HtmlString, EndString, CompareMethod.Binary)
            If PosStart > 0 Then
                ExtraxtValue = Mid$(HtmlString, PosStart, PosEnd - PosStart)
            End If
        End If

    End Function

    Public Function GetHTMLCode(strURL) As String
        Dim strReturn                   ' As String
        'Dim objHTTP                     ' As MSXML.XMLHTTPRequest

        On Error GoTo AccessError

        '''If Len(strURL) = 0 Then Exit Function
        '''Dim objHTTP = CreateObject("MSXML2.ServerXMLHTTP")
        '''objHTTP.Open("GET", strURL, False)
        '''objHTTP.Send                    'Get it.
        '''strReturn = objHTTP.responseText
        '''objHTTP = Nothing
        '''GetHTMLCode = strReturn
        Dim hreq As HttpWebRequest = CType(HttpWebRequest.Create(strURL), HttpWebRequest)
        Dim hres As HttpWebResponse = CType(hreq.GetResponse(), HttpWebResponse)
        Dim s As Stream = hres.GetResponseStream()
        Dim sr As New StreamReader(s)
        GetHTMLCode = sr.ReadToEnd()

        sr.Close()
        s.Close()

        Exit Function

AccessError:
        GetHTMLCode = ">>>ERROR<<<"
        AccessErrorCnt = AccessErrorCnt + 1
        '    L_ErrorCnt = AccessErrorCnt
        '    Form1.Timer2.Enabled = False
    End Function

    ' Bsp.: Seitenquelltext in Datei speichern
    Public Sub SaveQuelltext(DateiString As String, ByVal sFilename As String)
        Dim f As Integer

        f = FreeFile()
        FileOpen(f, sFilename, OpenMode.Output)
        Print(f, DateiString)
        FileClose(f)
    End Sub



    Public Sub WriteAccountFile(AccountFilename As String)
        ''''        '    Dim AccountFilename As String
        ''''        Dim AccountFile As Integer
        ''''        Dim idx As Long
        ''''        Dim Zeile As String

        ''''        On Error GoTo OpenError

        ''''        '    AccountFilename = App.Path & "\Account.txt"
        ''''        AccountFile = FreeFile()
        ''''        Open AccountFilename For Output As AccountFile

        ''''    For idx = 0 To UBound(AccountArray)
        ''''            Zeile = idx _
        ''''                    & vbTab & FixLen(AccountArray(idx).Date, 10) _
        ''''                    & vbTab & FixLen(AccountArray(idx).Name, 8) _
        ''''                    & vbTab & FixLen(AccountArray(idx).WKN, 6) _
        ''''                    & vbTab & FixLen(Format(AccountArray(idx).Value, "0.00"), 7) _
        ''''                    & vbTab & FixLen(Format(AccountArray(idx).SD, "0.00"), 7) _
        ''''                    & vbTab & FixLen(Format(AccountArray(idx).Distance, "0.000000"), 12) _
        ''''                    & vbTab & FixLen(Format(AccountArray(idx).Account, "0.00"), 7) _
        ''''                    & vbTab & FixLen(AccountArray(idx).Trend, 8)
        ''''            Print #AccountFile, Zeile
        ''''    Next idx

        ''''        Close AccountFile

        ''''    Exit Sub

        ''''OpenError:
        ''''        MsgBox AccountFilename, , "Write error"

    End Sub





    ' FormatDate
    ' Input:  20.12.1965
    ' Output: 1965-12-20
    Public Function FormatDate(DString As String) As String
        Dim DateEntities() As String

        If InStr(DString, "-") Then
            FormatDate = DString
        ElseIf InStr(DString, ".") Then
            SepariereString(DString, DateEntities, ".")
            FormatDate = DateEntities(2) & "-" & DateEntities(1) & "-" & DateEntities(0)
        Else
            FormatDate = "0000-00-00"
        End If
    End Function


    Public Function TodayFunction() As String
        Dim DateTimeString As String
        Dim DateString As String
        Dim SepArray() As String

        DateTimeString = Now
        SepariereString(DateTimeString, SepArray, " ")
        TodayFunction = FormatDate(SepArray(0))
    End Function

    Public Function DownloadHistoricFromArivaFct(WKN As String, ByRef HistoricFomAriva As String, InfoText As TextBox) As Double
        Dim URLstring As String
        Dim HtmlCode As String

        Dim SearchItem As String
        Dim EndString As String

        Dim HTML_Snippet As String
        Dim SecureCode As String
        Dim MaxTime As String

        URLstring = "https://www.ariva.de/" & WKN & "/historische_kurse"
        HtmlCode = GetHTMLCode(URLstring)

        If HtmlCode = ">>>ERROR<<<" Then
            DownloadHistoricFromArivaFct = -1
            Exit Function
        End If

        SaveQuelltext(HtmlCode, Application.StartupPath & "\HTML-Code.HTML")

        'SecureCode extrahieren
        SearchItem = "/quote/historic/historic.csv"
        EndString = "Download"
        HTML_Snippet = ExtraxtValue(HtmlCode, SearchItem, EndString)
        '''T_HTML_Snippet.Text = HTML_Snippet

        SearchItem = """secu"" value="
        EndString = "/>"
        SecureCode = Zahl(ExtraxtValue(HTML_Snippet, SearchItem, EndString))
        '''T_SecureCode.Text = SecureCode
        '''
        InfoText.Text = SecureCode

        'Beispiel infinion: http://www.ariva.de/quote/historic/historic.csv?secu=294&boerse_id=6&clean_split=1&clean_payout=0&clean_bezug=1&min_time=1.1.2000&max_time=20.2.2020&trenner=%3B&go=Download
        'Doku: https://forum.portfolio-performance.info/t/daten-kurs-fundamental-von-ariva-de-importieren/444

        MaxTime = Now.Date
        Dim UrlForHistorcValues As String
        UrlForHistorcValues = "http://www.ariva.de/quote/historic/historic.csv?secu=" & SecureCode & "&boerse_id=6&clean_split=1&clean_payout=0&clean_bezug=1&min_time=1.1.2000&max_time=" & MaxTime & "&trenner=%3B&go=Download"
        HistoricFomAriva = GetHTMLCode(UrlForHistorcValues)

        DownloadHistoricFromArivaFct = 0
    End Function




    Public Function ReadHistoryFile(Filename As String, ByRef HistoryArray() As HistoryItem)
        Dim FileNumber As Integer
        Dim Zeile As String
        Dim idx As Integer
        Dim HistoryEntities() As String
        Dim Pos As Boolean



        On Error GoTo ReadHistoryFileError
        idx = 0
        ReDim HistoryArray(0 To 0)
        FileNumber = FreeFile()
        FileOpen(FileNumber, Filename, OpenMode.Input)
        Zeile = LineInput(FileNumber)

        Pos = InStr(Zeile, "Datum")
        Pos = InStr(Zeile, "Erster")
        Pos = InStr(Zeile, "Hoch")
        Pos = InStr(Zeile, "Tief")
        Pos = InStr(Zeile, "Schlusskurs")


        If InStr(Zeile, "Datum") > 0 And InStr(Zeile, "Erster") > 0 And InStr(Zeile, "Hoch") > 0 And InStr(Zeile, "Tief") > 0 And InStr(Zeile, "Schlusskurs") > 0 And InStr(Zeile, "Stuecke") > 0 And InStr(Zeile, "Volumen") > 0 Then
            SepariereString(Zeile, HistoryEntities, ";")
            HistoryArray(idx).Datum = HistoryEntities(0)
            HistoryArray(idx).Erster = HistoryEntities(1)
            HistoryArray(idx).Hoch = HistoryEntities(2)
            HistoryArray(idx).Tief = HistoryEntities(3)
            HistoryArray(idx).Schlusskurs = HistoryEntities(4)
            If UBound(HistoryEntities) > 5 Then
                HistoryArray(idx).Stuecke = HistoryEntities(5)
            End If
            If UBound(HistoryEntities) > 6 Then
                HistoryArray(idx).Volumen = HistoryEntities(6)
            End If
            If UBound(HistoryEntities) > 7 Then
                HistoryArray(idx).Bemerkung = HistoryEntities(7)
            End If
            ReDim Preserve HistoryArray(0 To UBound(HistoryArray) + 1)
        ElseIf InStr(Zeile, "17.01.2020") > 0 Then      'Hier ist früher ein Fehler unterlaufen
            HistoryArray(idx).Datum = "Datum"
            HistoryArray(idx).Erster = "Erster"
            HistoryArray(idx).Hoch = "Hoch"
            HistoryArray(idx).Tief = "Tief"
            HistoryArray(idx).Schlusskurs = ""
            HistoryArray(idx).Stuecke = "Stuecke"
            HistoryArray(idx).Volumen = "Volumen"
            HistoryArray(idx).Bemerkung = "Bemerkung"
            ReDim Preserve HistoryArray(0 To UBound(HistoryArray) + 1)
        Else
            MsgBox(Filename,, "Formatfehler !")
            ReadHistoryFile = -1
            Exit Function
        End If

        While Not EOF(FileNumber)
            Zeile = LineInput(FileNumber)
            If Zeile <> "" Then
                SepariereString(Zeile, HistoryEntities, ";")
                idx = idx + 1
                HistoryArray(idx).Datum = FormatDate(HistoryEntities(0))
                HistoryArray(idx).Erster = HistoryEntities(1)
                HistoryArray(idx).Hoch = HistoryEntities(2)
                HistoryArray(idx).Tief = HistoryEntities(3)
                HistoryArray(idx).Schlusskurs = HistoryEntities(4)
                If UBound(HistoryEntities) > 5 Then
                    HistoryArray(idx).Stuecke = HistoryEntities(5)
                End If
                If UBound(HistoryEntities) > 5 Then
                    HistoryArray(idx).Volumen = HistoryEntities(6)
                End If
                If UBound(HistoryEntities) > 6 Then
                    HistoryArray(idx).Bemerkung = HistoryEntities(7)
                End If
                ReDim Preserve HistoryArray(0 To UBound(HistoryArray) + 1)
            End If

        End While
        ReDim Preserve HistoryArray(0 To UBound(HistoryArray) - 1)
        FileClose(FileNumber)
        ReadHistoryFile = 0
        Exit Function


ReadHistoryFileError:

        MsgBox(Filename & vbCr & Err.Description, , "xxxxx")
        ReadHistoryFile = -2
    End Function


    Public Function InvertDateOrder(ByRef HistoryArray() As HistoryItem) As Integer
        Dim idx As Integer
        Dim NumberOfDays As Integer
        Dim NextDate As String
        Dim FirstDate As String
        Dim Ascending As Boolean
        Dim Delta As Boolean
        Dim Buffer As HistoryItem
        Dim IdxButtom As Integer
        Dim IdxTop As Integer


        '===== First check, if date is ascending.... =====

        'skip idx=0. That's the headline
        FirstDate = HistoryArray(1).Datum
        NextDate = HistoryArray(2).Datum
        NumberOfDays = DateDiff("d", FirstDate, NextDate)
        Ascending = NumberOfDays > 0

        For idx = 2 To UBound(HistoryArray)
            Delta = DateDiff("d", HistoryArray(idx - 1).Datum, HistoryArray(idx).Datum) > 0

            If DateDiff("d", HistoryArray(idx).Datum, HistoryArray(idx - 1).Datum) Then
                If Delta <> Ascending Then
                    MsgBox(HistoryArray(idx).Datum & ": Date not monotonous ")
                    InvertDateOrder = -1
                    Exit Function
                End If
            End If

        Next idx


        '===== ....if not, invert date order =====
        IdxTop = UBound(HistoryArray)
        If Not Ascending Then
            For IdxButtom = 1 To UBound(HistoryArray) \ 2
                Buffer = HistoryArray(IdxButtom)
                HistoryArray(IdxButtom) = HistoryArray(IdxTop)
                HistoryArray(IdxTop) = Buffer
                IdxTop = IdxTop - 1
            Next
        End If

        InvertDateOrder = 0
    End Function


    Public Sub ServiceHistory(WKN As String)
        Dim FinalArray() As HistoryItem

        Dim Fullpath As String
        Dim HistoryFileName As String
        Dim HistoryFile As Integer
        Dim Zeile As String
        Dim HistoryEntities() As String
        Dim HistoryIdx As Long
        Dim TageszahlInDatum As String
        Dim HistoryLine As HistoryItem
        Dim DateIdx As Long
        Dim FinalIdx As Long
        Dim Today As String
        Dim Lastvalue As String

        ReDim FinalArray(0 To 0)

        '''ListBox2.Items.Clear()
        HistoryFileName = Application.StartupPath & "\HistoryNew\" & WKN & ".txt"
        '''ListBox2.Items.Add("**** " & WKN & " ****")
        Today = TodayFunction()

        On Error GoTo ReadHistoryFileErr
        HistoryFile = FreeFile()
        FileOpen(HistoryFile, HistoryFileName, OpenMode.Input)

        Lastvalue = 0

        ' Read Headline
        HistoryIdx = 0
        DateIdx = 0
        FinalIdx = 0

        Zeile = LineInput(HistoryFile)

        SepariereString(Zeile, HistoryEntities, ";")
        HistoryLine.Datum = HistoryEntities(0)
        HistoryLine.Erster = HistoryEntities(1)
        HistoryLine.Hoch = HistoryEntities(2)
        HistoryLine.Tief = HistoryEntities(3)
        HistoryLine.Schlusskurs = HistoryEntities(4)
        If UBound(HistoryEntities) > 5 Then
            HistoryLine.Stuecke = HistoryEntities(5)
            HistoryLine.Volumen = HistoryEntities(6)
        End If
        FinalArray(FinalIdx) = HistoryLine

        ReDim Preserve FinalArray(0 To UBound(FinalArray) + 1)
        HistoryIdx = 1
        DateIdx = 1
        FinalIdx = 1

        While Not EOF(HistoryFile) And (TageszahlInDatum <> Today)

            HistoryLine.Datum = ""
            HistoryLine.Erster = ""
            HistoryLine.Hoch = ""
            HistoryLine.Tief = ""
            HistoryLine.Schlusskurs = ""
            HistoryLine.Stuecke = ""
            HistoryLine.Volumen = ""
            HistoryLine.Bemerkung = ""


            Zeile = LineInput(HistoryFile)

            TageszahlInDatum = FormatDate(DateAdd("d", DateIdx - 1, "1.1.2000"))

            SepariereString(Zeile, HistoryEntities, ";")
            HistoryLine.Datum = FormatDate(HistoryEntities(0))
            HistoryLine.Erster = HistoryEntities(1)
            HistoryLine.Hoch = HistoryEntities(2)
            HistoryLine.Tief = HistoryEntities(3)
            HistoryLine.Schlusskurs = HistoryEntities(4)
            If UBound(HistoryEntities) > 5 Then
                HistoryLine.Stuecke = HistoryEntities(5)
                HistoryLine.Volumen = HistoryEntities(6)
            End If

            ' Check missing days
            While (TageszahlInDatum <> HistoryLine.Datum) And (TageszahlInDatum <> Today)
                Dim ds As String

                ds = Weekday(TageszahlInDatum)
                ' No entry for Saturday and Sunday
                If (Weekday(TageszahlInDatum) = 7) Or (Weekday(TageszahlInDatum) = 1) Then

                    ' Normal working day: If line is missing, insert line and take previous value
                Else
                    '''ListBox2.Items.Add(TageszahlInDatum & "   Inserted ")
                    ReDim Preserve FinalArray(0 To UBound(FinalArray) + 1)
                    FinalArray(FinalIdx).Datum = TageszahlInDatum
                    FinalArray(FinalIdx).Schlusskurs = Lastvalue
                    FinalArray(FinalIdx).Bemerkung = "Inserted"
                    FinalIdx = FinalIdx + 1
                End If

                DateIdx = DateIdx + 1
                TageszahlInDatum = FormatDate(DateAdd("d", DateIdx - 1, "1.1.2000"))
            End While





            ' No entry for Saturday and Sunday
            If (Weekday(HistoryLine.Datum) = 7) Or (Weekday(HistoryLine.Datum) = 1) Then
                '''ListBox2.Items.Add(TageszahlInDatum & " --> Wochenende")

                ' Normal working day
            Else
                ' If there is a value = 0, replace with last value
                If HistoryLine.Schlusskurs = 0 Then
                    HistoryLine.Schlusskurs = Lastvalue
                    HistoryLine.Bemerkung = "Zero replaced"
                    '''ListBox2.Items.Add(TageszahlInDatum & " --> Zero replaced")
                End If
                FinalArray(FinalIdx) = HistoryLine
                Lastvalue = HistoryLine.Schlusskurs
                FinalIdx = FinalIdx + 1
                ReDim Preserve FinalArray(0 To UBound(FinalArray) + 1)
            End If

            '        Text2.Text = Zeile

            HistoryIdx = HistoryIdx + 1
            DateIdx = DateIdx + 1

        End While

        ReDim Preserve FinalArray(0 To UBound(FinalArray) - 1)
        FileClose(HistoryFile)


        WriteHistoryFile(Application.StartupPath & "\HistoryService\" & WKN & ".txt", FinalArray)

        Exit Sub
ReadHistoryFileErr:
        MsgBox(HistoryFileName & vbCr & Err.Description, , "xxxxx")

    End Sub



    Public Sub WriteHistoryFile(Filename As String, ByRef HistoryArray() As HistoryItem)
        Dim FileNumber As Integer
        Dim idx As Long
        Dim Zeile As String

        On Error GoTo OpenError
        FileNumber = FreeFile()
        FileOpen(FileNumber, Filename, OpenMode.Output)

        For idx = 0 To UBound(HistoryArray)

            '''If idx > 5230 Then
            '''    idx = idx
            '''End If

            Zeile = HistoryArray(idx).Datum _
                & ";" & HistoryArray(idx).Erster _
                & ";" & HistoryArray(idx).Hoch _
                & ";" & HistoryArray(idx).Tief _
                & ";" & HistoryArray(idx).Schlusskurs _
                & ";" & HistoryArray(idx).Stuecke _
                & ";" & HistoryArray(idx).Volumen _
                & ";" & HistoryArray(idx).Bemerkung
            PrintLine(FileNumber, Zeile)
        Next idx

        FileClose(FileNumber)

        Exit Sub

OpenError:
        MsgBox(Filename, , "Write error")
        FileClose(FileNumber)

    End Sub

    Public Function FindIsinInArray(WKN As String) As String
        'Find ISIN
        Dim i As Integer

        FindIsinInArray = "Unknown"

        For i = LBound(CompanyListArray) To UBound(CompanyListArray)
            If CompanyListArray(i).WKN = WKN Then
                FindIsinInArray = CompanyListArray(i).ISIN
                Exit For
            End If
        Next i

    End Function




    Public Function GetvalidSharePrice(arry() As Double) As ShareResult
        Dim i As Integer
        Dim ErrorString As String

        Dim MyMedian As Double

        MyMedian = Median(arry)
        ErrorString = ""
        For i = LBound(arry) To UBound(arry)
            If arry(i) = 0 Then
                ErrorString = ErrorString & "Web[" & i & "]: " & arry(i) & "  "
            ElseIf math.Abs(arry(i) - MyMedian) > (myMedian * 0.01) Then
                ErrorString = ErrorString & "Web[" & i & "]: " & arry(i) & "  "
            End If
        Next

        GetvalidSharePrice.Value = MyMedian
        GetvalidSharePrice.ErrorString = ErrorString
    End Function


    Public Function Median(Array() As Double) As Double
        Dim V1 As Double
        Dim V2 As Double

        BubbleSort(Array)

        If Array.Length Mod 2 = 1 Then
            Median = Array(Array.Length \ 2)
        Else
            V1 = Array(Array.Length \ 2 - 1)
            V2 = Array(Array.Length \ 2)
            Median = (V1 + V2) / 2
        End If

    End Function

End Module
