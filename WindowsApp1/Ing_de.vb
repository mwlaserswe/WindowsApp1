Module Ing_de
    Public Function Read_Ing(WKN As String) As Double
        Dim HtmlCode As String
        Dim ISIN As String

        Dim WebPage As String
        Dim SearchItem As String
        Dim EndString As String
        Dim AktuellerKurs As String

        ISIN = FindIsinInArray(WKN)

        WebPage = "https://wertpapiere.ing.de/Investieren/Aktie/" & ISIN
        HtmlCode = GetHTMLCode(WebPage)
        If HtmlCode = ">>>ERROR<<<" Then
            Read_Ing = -1
            'ReadTodaysSharePrice.L_SharePrice = "Error"
            Exit Function
        End If

        SaveQuelltext(HtmlCode, Application.StartupPath & "\Ing.HTML")

        'AktuellerKurs extrahieren
        SearchItem = "data-field=""Rate"""
        EndString = "<meta"
        AktuellerKurs = ExtraxtValue(HtmlCode, SearchItem, EndString)
        Dim dmy As Double

        dmy = Zahl(AktuellerKurs)

        Read_Ing = dmy

    End Function
End Module
