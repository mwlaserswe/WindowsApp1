Option Explicit On

Module Comdirect_de
    Public Function Read_Comdirect(WKN As String) As Double
        Dim HtmlCode As String
        Dim ISIN As String

        Dim WebPage As String
        Dim SearchItem As String
        Dim EndString As String
        Dim AktuellerKurs As String

        'Find ISIN
        Dim i As Integer

        ISIN = FindIsinInArray(WKN)

        WebPage = "https://www.comdirect.de/inf/aktien/" & ISIN
        HtmlCode = GetHTMLCode(WebPage)
        If HtmlCode = ">>>ERROR<<<" Then
            Read_Comdirect = -1
            'ReadTodaysSharePrice.L_SharePrice = "Error"
            Exit Function
        End If

        SaveQuelltext(HtmlCode, Application.StartupPath & "\Comdirect.HTML")

        'AktuellerKurs extrahieren
        SearchItem = "<span class=""text-size--xxlarge text-weight--medium"""
        EndString = "</span>"
        AktuellerKurs = ExtraxtValue(HtmlCode, SearchItem, EndString)
        Dim dmy As Double

        dmy = Zahl(AktuellerKurs)

        Read_Comdirect = dmy

    End Function

End Module
