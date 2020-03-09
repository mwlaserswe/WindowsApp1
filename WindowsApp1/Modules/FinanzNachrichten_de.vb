Option Explicit On

Module FinanzNachrichten_de
    Public Function Read_FinanzNachrichten(WKN As String) As Double
        Dim HtmlCode As String
        Dim ISIN As String

        Dim WebPage As String
        Dim SearchItem As String
        Dim EndString As String
        Dim AktuellerKurs As String

        WebPage = "https://www.finanznachrichten.de/aktienkurse-boersen/" & WKN
        HtmlCode = GetHTMLCode(WebPage)
        If HtmlCode = ">>>ERROR<<<" Then
            Read_FinanzNachrichten = -1
            'ReadTodaysSharePrice.L_SharePrice = "Error"
            Exit Function
        End If

        SaveQuelltext(HtmlCode, Application.StartupPath & "\Finanznachrichten.HTML")

        'AktuellerKurs extrahieren
        SearchItem = "data-field=""Rate"""
        EndString = "<meta"
        AktuellerKurs = ExtraxtValue(HtmlCode, SearchItem, EndString)
        Dim dmy As Double

        dmy = Zahl(AktuellerKurs)

        Read_FinanzNachrichten = dmy

    End Function


End Module
