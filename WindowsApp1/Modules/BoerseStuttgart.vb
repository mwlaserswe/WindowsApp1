Option Explicit On
Module BoerseStuttgart
    Public Function Read_BoerseStuttgart(WKN As String) As Double
        Dim HtmlCode As String

        Dim WebPage As String
        Dim SearchItem As String
        Dim EndString As String
        Dim AktuellerKurs As String

        WebPage = "https://www.boerse-stuttgart.de/de-de/produkte/aktien/stuttgart/" & WKN
        HtmlCode = GetHTMLCode(WebPage)
        If HtmlCode = ">>>ERROR<<<" Then
            Read_BoerseStuttgart = -1
            'ReadTodaysSharePrice.L_SharePrice = "Error"
            Exit Function
        End If

        SaveQuelltext(HtmlCode, Application.StartupPath & "\BoerseStuttgartText.HTML")

        'AktuellerKurs extrahieren
        SearchItem = "<span class="
        EndString = "</span>"
        AktuellerKurs = ExtraxtValue(HtmlCode, SearchItem, EndString)
        Dim dmy As Double

        dmy = Zahl(AktuellerKurs)

        Read_BoerseStuttgart = dmy

    End Function

End Module
