Option Explicit On

Public Class SaveWebpageAsHTML
    Private Sub C_SavePageToFile_Click(sender As Object, e As EventArgs) Handles C_SavePageToFile.Click
        Dim HtmlCode As String
        HtmlCode = GetHTMLCode(T_URL.Text)
        SaveQuelltext(HtmlCode, Application.StartupPath & "\HTML-Code.HTML")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim myPath As String = "Notepad++.exe"

        Dim pr As New Process

        pr.StartInfo.FileName = myPath

        pr.StartInfo.Arguments = """" & Application.StartupPath & "\HTML-Code.HTML" & """"

        pr.Start()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim HistoricFomAriva As String
        Dim WKN As String
        Dim result As Double

        WKN = T_WKN.Text

        'Diectory: \History_download_from_ARIVA


        Application.DoEvents()

        result = DownloadHistoricFromArivaFct(WKN, HistoricFomAriva, T_HTML_Snippet)
        If result < 0 Then
            MsgBox("Problem beim Download der Kurse von: " & WKN)
            Exit Sub
        End If
        SaveQuelltext(HistoricFomAriva, Application.StartupPath & "\History_download_from_ARIVA\" & WKN & ".txt")
    End Sub


    '''Public Function ReadHistoricFromAriva(WKN As String, ByRef HistoricFomAriva As String) As Double
    '''    Dim URLstring As String
    '''    Dim HtmlCode As String

    '''    Dim SearchItem As String
    '''    Dim EndString As String

    '''    Dim HTML_Snippet As String
    '''    Dim SecureCode As String
    '''    Dim MaxTime As String

    '''    URLstring = "https://www.ariva.de/" & WKN & "/historische_kurse"
    '''    HtmlCode = GetHTMLCode(URLstring)

    '''    If HtmlCode = ">>>ERROR<<<" Then
    '''        ReadHistoricFromAriva = -1
    '''        Exit Function
    '''    End If

    '''    SaveQuelltext(HtmlCode, Application.StartupPath & "\HTML-Code.HTML")

    '''    'SecureCode extrahieren
    '''    SearchItem = "/quote/historic/historic.csv"
    '''    EndString = "Download"
    '''    HTML_Snippet = ExtraxtValue(HtmlCode, SearchItem, EndString)
    '''    T_HTML_Snippet.Text = HTML_Snippet

    '''    SearchItem = """secu"" value="
    '''    EndString = "/>"
    '''    SecureCode = Zahl(ExtraxtValue(HTML_Snippet, SearchItem, EndString))
    '''    T_SecureCode.Text = SecureCode

    '''    'Beispiel infinion: http://www.ariva.de/quote/historic/historic.csv?secu=294&boerse_id=6&clean_split=1&clean_payout=0&clean_bezug=1&min_time=1.1.2000&max_time=20.2.2020&trenner=%3B&go=Download
    '''    'Doku: https://forum.portfolio-performance.info/t/daten-kurs-fundamental-von-ariva-de-importieren/444

    '''    MaxTime = Now.Date
    '''    Dim UrlForHistorcValues As String
    '''    UrlForHistorcValues = "http://www.ariva.de/quote/historic/historic.csv?secu=" & 294 & "&boerse_id=6&clean_split=1&clean_payout=0&clean_bezug=1&min_time=1.1.2000&max_time=" & MaxTime & "&trenner=%3B&go=Download"
    '''    HistoricFomAriva = GetHTMLCode(UrlForHistorcValues)

    '''End Function


End Class