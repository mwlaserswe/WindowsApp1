Imports System.Xml

Module WallStreet_de
    Public Function Read_WallStreet_de(WKN As String) As Double
        Dim HtmlCode As String
        Dim ISIN As String

        Dim WebPage As String
        Dim SearchItem As String
        Dim EndString As String
        Dim AktuellerKurs As String

        ISIN = FindIsinInArray(WKN)

        WebPage = "https://www.wallstreet-online.de/aktien/" & ISIN
        HtmlCode = GetHTMLCode(WebPage)
        If HtmlCode = ">>>ERROR<<<" Then
            Read_WallStreet_de = -1
            Exit Function
        End If

        SaveQuelltext(HtmlCode, Application.StartupPath & "\WallStreet.HTML")

        'AktuellerKurs extrahieren
        SearchItem = "data-push=""3;ls;quotes;9193@22;trade"""
        EndString = "</span>"
        AktuellerKurs = ExtraxtValue(HtmlCode, SearchItem, EndString)
        Dim dmy As Double

        dmy = Zahl(AktuellerKurs)

        Read_WallStreet_de = dmy

    End Function
End Module
