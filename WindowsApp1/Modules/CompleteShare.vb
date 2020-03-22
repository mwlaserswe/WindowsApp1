Imports System.IO

Module CompleteShare
    Public Function ReadCompleteShareInfo(COPM_WKN_ISIN As String) As ShareItem
        Dim HtmlCode As String

        Dim WebPage As String
        Dim SearchItem As String
        Dim EndString As String
        Dim WKN As String
        Dim ISIN As String
        Dim Company As String

        WebPage = "https://www.ariva.de/" & COPM_WKN_ISIN
        HtmlCode = GetHTMLCode(WebPage)
        If HtmlCode = ">>>ERROR<<<" Then
            ReadCompleteShareInfo.WKN = "Error"
            ReadCompleteShareInfo.ISIN = "Error"
            ReadCompleteShareInfo.Name = "Error"
            'ReadTodaysSharePrice.L_SharePrice = "Error"
            Exit Function
        End If

        SaveQuelltext(HtmlCode, Path.Combine(Application.StartupPath, "CompleteShareInfo.HTML"))

        'zuerst TempSearchString extrahieren
        Dim TempSearchString As String

        SearchItem = "<div class=""verlauf snapshotInfo"">"
        EndString = "<div>Typ:"
        TempSearchString = ExtraxtValue(HtmlCode, SearchItem, EndString)
        'TempValue = Zahl(TempSearchString)

        'Aktuelle WKN extrahieren
        SearchItem = "WKN:"
        EndString = " "
        WKN = ExtraxtValue(TempSearchString, SearchItem, EndString)
        Dim dmy As Double

        'Aktuelle ISIN extrahieren
        SearchItem = "ISIN:"
        EndString = " "
        ISIN = ExtraxtValue(TempSearchString, SearchItem, EndString)

        ReadCompleteShareInfo.WKN = WKN
        ReadCompleteShareInfo.ISIN = ISIN

    End Function
End Module
