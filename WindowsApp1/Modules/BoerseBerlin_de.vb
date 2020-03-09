Module BoerseBerlin_de
    Public Function Read_BoerseBerlin_de(WKN As String) As Double
        Dim HtmlCode As String
        Dim ISIN As String

        Dim WebPage As String
        Dim SearchItem As String
        Dim EndString As String
        Dim AktuellerKurs As String

        ISIN = FindIsinInArray(WKN)

        WebPage = "https://www.boerse-berlin.de/index.php/Aktien?isin=" & ISIN
        HtmlCode = GetHTMLCode(WebPage)
        If HtmlCode = ">>>ERROR<<<" Then
            Read_BoerseBerlin_de = -1
            Exit Function
        End If

        SaveQuelltext(HtmlCode, Application.StartupPath & "\BoerseBerlin.HTML")

        'AktuellerKurs extrahieren
        SearchItem = "_last"""
        EndString = "</span>"
        AktuellerKurs = ExtraxtValue(HtmlCode, SearchItem, EndString)
        Dim dmy As Double

        dmy = Zahl(AktuellerKurs)

        Read_BoerseBerlin_de = dmy

    End Function
End Module
