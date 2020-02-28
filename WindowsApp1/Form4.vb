Option Explicit On

Public Class ServiceCheckWeekDay

    '''Dim FinalArray() As HistoryItem

    Private Sub C_ServiceHistory_Click(sender As Object, e As EventArgs) Handles C_ServiceHistory.Click
        Dim FileName As String
        Dim HistoryArray() As HistoryItem

        For idx = 0 To UBound(CompPartialLstArr)
            ListBox2.Items.Add("**** " & CompPartialLstArr(idx).WKN & " Check date order ****")
            FileName = Application.StartupPath & "\History\" & CompPartialLstArr(idx).WKN & ".txt"
            ReadHistoryFile(FileName, HistoryArray)
            InvertDateOrder(HistoryArray)
            WriteHistoryFile(Application.StartupPath & "\HistoryNew\" & CompPartialLstArr(idx).WKN & ".txt", HistoryArray)
            ServiceHistory(CompPartialLstArr(idx).WKN)
        Next idx
    End Sub

    '''    Private Sub ServiceHistory(WKN As String)
    '''        Dim Fullpath As String
    '''        Dim HistoryFileName As String
    '''        Dim HistoryFile As Integer
    '''        Dim Zeile As String
    '''        Dim HistoryEntities() As String
    '''        Dim HistoryIdx As Long
    '''        Dim TageszahlInDatum As String
    '''        Dim HistoryLine As HistoryItem
    '''        Dim DateIdx As Long
    '''        Dim FinalIdx As Long
    '''        Dim Today As String
    '''        Dim Lastvalue As String

    '''        ReDim FinalArray(0 To 0)

    '''        ListBox2.Items.Clear()
    '''        HistoryFileName = Application.StartupPath & "\HistoryNew\" & WKN & ".txt"
    '''        ListBox2.Items.Add("**** " & WKN & " ****")
    '''        Today = TodayFunction()

    '''        On Error GoTo ReadHistoryFileErr
    '''        HistoryFile = FreeFile()
    '''        FileOpen(HistoryFile, HistoryFileName, OpenMode.Input)

    '''        Lastvalue = 0

    '''        ' Read Headline
    '''        HistoryIdx = 0
    '''        DateIdx = 0
    '''        FinalIdx = 0

    '''        Zeile = LineInput(HistoryFile)

    '''        SepariereString(Zeile, HistoryEntities, ";")
    '''        HistoryLine.Datum = HistoryEntities(0)
    '''        HistoryLine.Erster = HistoryEntities(1)
    '''        HistoryLine.Hoch = HistoryEntities(2)
    '''        HistoryLine.Tief = HistoryEntities(3)
    '''        HistoryLine.Schlusskurs = HistoryEntities(4)
    '''        If UBound(HistoryEntities) > 5 Then
    '''            HistoryLine.Stuecke = HistoryEntities(5)
    '''            HistoryLine.Volumen = HistoryEntities(6)
    '''        End If
    '''        FinalArray(FinalIdx) = HistoryLine

    '''        ReDim Preserve FinalArray(0 To UBound(FinalArray) + 1)
    '''        HistoryIdx = 1
    '''        DateIdx = 1
    '''        FinalIdx = 1

    '''        While Not EOF(HistoryFile) And (TageszahlInDatum <> Today)

    '''            HistoryLine.Datum = ""
    '''            HistoryLine.Erster = ""
    '''            HistoryLine.Hoch = ""
    '''            HistoryLine.Tief = ""
    '''            HistoryLine.Schlusskurs = ""
    '''            HistoryLine.Stuecke = ""
    '''            HistoryLine.Volumen = ""
    '''            HistoryLine.Bemerkung = ""


    '''            Zeile = LineInput(HistoryFile)

    '''            TageszahlInDatum = FormatDate(DateAdd("d", DateIdx - 1, "1.1.2000"))

    '''            SepariereString(Zeile, HistoryEntities, ";")
    '''            HistoryLine.Datum = FormatDate(HistoryEntities(0))
    '''            HistoryLine.Erster = HistoryEntities(1)
    '''            HistoryLine.Hoch = HistoryEntities(2)
    '''            HistoryLine.Tief = HistoryEntities(3)
    '''            HistoryLine.Schlusskurs = HistoryEntities(4)
    '''            If UBound(HistoryEntities) > 5 Then
    '''                HistoryLine.Stuecke = HistoryEntities(5)
    '''                HistoryLine.Volumen = HistoryEntities(6)
    '''            End If

    '''            ' Check missing days
    '''            While (TageszahlInDatum <> HistoryLine.Datum) And (TageszahlInDatum <> Today)
    '''                Dim ds As String

    '''                ds = Weekday(TageszahlInDatum)
    '''                ' No entry for Saturday and Sunday
    '''                If (Weekday(TageszahlInDatum) = 7) Or (Weekday(TageszahlInDatum) = 1) Then

    '''                    ' Normal working day: If line is missing, insert line and take previous value
    '''                Else
    '''                    ListBox2.Items.Add(TageszahlInDatum & "   Inserted ")
    '''                    ReDim Preserve FinalArray(0 To UBound(FinalArray) + 1)
    '''                    FinalArray(FinalIdx).Datum = TageszahlInDatum
    '''                    FinalArray(FinalIdx).Schlusskurs = Lastvalue
    '''                    FinalArray(FinalIdx).Bemerkung = "Inserted"
    '''                    FinalIdx = FinalIdx + 1
    '''                End If

    '''                DateIdx = DateIdx + 1
    '''                TageszahlInDatum = FormatDate(DateAdd("d", DateIdx - 1, "1.1.2000"))
    '''            End While





    '''            ' No entry for Saturday and Sunday
    '''            If (Weekday(HistoryLine.Datum) = 7) Or (Weekday(HistoryLine.Datum) = 1) Then
    '''                ListBox2.Items.Add(TageszahlInDatum & " --> Wochenende")

    '''                ' Normal working day
    '''            Else
    '''                ' If there is a value = 0, replace with last value
    '''                If HistoryLine.Schlusskurs = 0 Then
    '''                    HistoryLine.Schlusskurs = Lastvalue
    '''                    HistoryLine.Bemerkung = "Zero replaced"
    '''                    ListBox2.Items.Add(TageszahlInDatum & " --> Zero replaced")
    '''                End If
    '''                FinalArray(FinalIdx) = HistoryLine
    '''                Lastvalue = HistoryLine.Schlusskurs
    '''                FinalIdx = FinalIdx + 1
    '''                ReDim Preserve FinalArray(0 To UBound(FinalArray) + 1)
    '''            End If

    '''            '        Text2.Text = Zeile

    '''            HistoryIdx = HistoryIdx + 1
    '''            DateIdx = DateIdx + 1

    '''        End While

    '''        ReDim Preserve FinalArray(0 To UBound(FinalArray) - 1)
    '''        FileClose(HistoryFile)


    '''        WriteHistoryFile(Application.StartupPath & "\HistoryService\" & WKN & ".txt", FinalArray)

    '''        Exit Sub
    '''ReadHistoryFileErr:
    '''        MsgBox(HistoryFileName & vbCr & Err.Description, , "xxxxx")

    '''    End Sub


    Private Sub C_TageszahlInDatum_Click(sender As Object, e As EventArgs) Handles C_TageszahlInDatum.Click
        Dim intTag As Integer
        Dim TageszahlInDatum As Date

        intTag = T_DayNumber.Text
        TageszahlInDatum = DateAndTime.DateAdd("d", intTag, "1.1.2000")
        T_DateOut.Text = TageszahlInDatum
    End Sub

    Private Sub C_WeekdayDemo_Click(sender As Object, e As EventArgs) Handles C_WeekdayDemo.Click
        Dim Datum1 As String

        Datum1 = T_DatumIn.Text
        ' ermittelt den Wochentag zu einem Datum. 1 = Sonntag, 2 = Montag,...
        T_Weekday.Text = Weekday(Datum1)
    End Sub




End Class