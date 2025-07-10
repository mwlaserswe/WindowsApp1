Option Explicit On
Module ariva_de
    Public Function Read_Ariva(WKN As String) As Double
        Dim HtmlCode As String

        Dim WebPage As String
        Dim SearchItem As String
        Dim EndString As String
        Dim AktuellerKurs As String

        WebPage = "https://www.ariva.de/" & WKN
        HtmlCode = GetHTMLCode(WebPage)
        If HtmlCode = ">>>ERROR<<<" Then
            Read_Ariva = -1
            'ReadTodaysSharePrice.L_SharePrice = "Error"
            Exit Function
        End If

        SaveQuelltext(HtmlCode, Application.StartupPath & "\ArivaText.HTML")

        'zuerst TempSearchString extrahieren
        Dim TempSearchString As String
        Dim TempValue As Double
        SearchItem = "<div class=""instrument-header-quote"">"
        EndString = "&nbsp"
        TempSearchString = ExtraxtValue(HtmlCode, SearchItem, EndString)
        TempValue = Zahl(TempSearchString)

        'SWE       'AktuellerKurs extrahieren
        'SWE       SearchItem = TempValue & ".00"
        'SWE       EndString = "</span>"
        'SWE       AktuellerKurs = ExtraxtValue(HtmlCode, SearchItem, EndString)

        Dim dmy As Double
        dmy = TempValue

        'SWE        dmy = Zahl(AktuellerKurs)

        Read_Ariva = dmy

    End Function

End Module
