Imports System.Net
Imports System.IO
Public Class ReadSingleShareValue

    Private Sub ReadAriva_Click(sender As Object, e As EventArgs) Handles ReadAriva.Click
        L_SharePrice.Text = "--"
        L_SharePrice.Text = Read_Ariva(T_WKN.Text)
    End Sub
    Private Sub ReadPeketec_Click(sender As Object, e As EventArgs) Handles ReadPeketec.Click
        L_SharePrice.Text = "--"
        L_SharePrice.Text = Read_Peketec(T_WKN.Text)
    End Sub
    Private Sub ReadBoerseStuttgart_Click(sender As Object, e As EventArgs) Handles ReadBoerseStuttgart.Click
        L_SharePrice.Text = "--"
        L_SharePrice.Text = Read_BoerseStuttgart(T_WKN.Text)
    End Sub
    Private Sub ReadComdirect_Click(sender As Object, e As EventArgs) Handles ReadComdirect.Click
        L_SharePrice.Text = "--"
        L_SharePrice.Text = Read_Comdirect(T_WKN.Text)
    End Sub

    Private Sub ReadFinanzNachrichten_Click(sender As Object, e As EventArgs) Handles ReadFinanzNachrichten.Click
        L_SharePrice.Text = "--"
        L_SharePrice.Text = Read_FinanzNachrichten(T_WKN.Text)
    End Sub

    Private Sub ReadIng_Click(sender As Object, e As EventArgs) Handles ReadIng.Click
        L_SharePrice.Text = "--"
        L_SharePrice.Text = Read_Ing(T_WKN.Text)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim GoogleText As String
        '    Dim Von As String
        '    Dim Nach As String
        '    Dim Zeit As String
        '    Dim Stunden As String
        '    Dim Minuten As String
        '    Dim KM As String

        Dim WebPage As String
        Dim SearchItem As String
        Dim AktuellerKurs As String
        Dim InstrumentId As String
        Dim WKN As String
        Dim ISIN As String
        '    Dim DmyString As String



        Dim PosStart As Long
        Dim PosEnd As Long
        Dim EndString As String

        '''    WebPage = "https://www.finanzen.net/aktien/bmw-aktie"
        '''    GoogleText = GetHTMLCode(WebPage)
        '''    'oder https://tradingdesk.finanzen.net/aktie/DE0005190003'

        '''    SaveQuelltext GoogleText, App.Path & "\GoogleText.HTML"

        ''''AktuellerKurs extrahieren
        '''    SearchItem = "Aktueller Kurs"
        '''    EndString = Chr$(34)
        '''    AktuellerKurs = ExtraxtValue(GoogleText, SearchItem, EndString)

        '''    'InstrumentId extrahieren
        '''    SearchItem = "instrument-id"
        '''    EndString = Chr$(34)
        '''    InstrumentId = ExtraxtValue(GoogleText, SearchItem, EndString)


        '''    'WSK extrahieren
        '''    SearchItem = "WKN:"
        '''    EndString = "/"
        '''    WKN = ExtraxtValue(InstrumentId, SearchItem, EndString)
        '''    'ISIN extrahieren
        '''    SearchItem = "ISIN:"
        '''    EndString = "</span>"
        '''    ISIN = ExtraxtValue(InstrumentId, SearchItem, EndString)
        '''    '''    L_WebPage = WebPage
        '''    L_SharePrice = AktuellerKurs
        '''    L_WKN = WKN
        '''    L_ISIN = ISIN


        '''    WebPage = "https://www.finanzen.net/aktien/Basler-aktie"
        '''    GoogleText = GetHTMLCode(WebPage)
        '''    'oder https://tradingdesk.finanzen.net/aktie/DE0005190003'

        '''    SaveQuelltext GoogleText, App.Path & "\GoogleText.HTML"



        ''''AktuellerKurs extrahieren
        '''    SearchItem = "Aktueller Kurs"
        '''    EndString = Chr$(34)
        '''    AktuellerKurs = ExtraxtValue(GoogleText, SearchItem, EndString)

        '''    'InstrumentId extrahieren
        '''    SearchItem = "instrument-id"
        '''    EndString = Chr$(34)
        '''    InstrumentId = ExtraxtValue(GoogleText, SearchItem, EndString)


        '''    'WSK extrahieren
        '''    SearchItem = "WKN:"
        '''    EndString = "/"
        '''    WKN = ExtraxtValue(InstrumentId, SearchItem, EndString)
        '''    'ISIN extrahieren
        '''    SearchItem = "ISIN:"
        '''    EndString = "</span>"
        '''    ISIN = ExtraxtValue(InstrumentId, SearchItem, EndString)
        '''    '''    L_WebPage = WebPage
        '''    L_SharePrice = AktuellerKurs
        '''    L_WKN = WKN
        '''    L_ISIN = ISIN



        '''    GoogleText = GetHTMLCode("https://www.finanzen.net/aktien/deutschland-aktien-realtimekurse")
        '''    'oder https://tradingdesk.finanzen.net/aktie/DE0005190003'

        '''    SaveQuelltext GoogleText, App.Path & "\GoogleText.txt"

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim hreq As HttpWebRequest = CType(HttpWebRequest.Create("https://www.finanzen.net/aktien/bmw-aktie"), HttpWebRequest)
        Dim hres As HttpWebResponse = CType(hreq.GetResponse(), HttpWebResponse)
        Dim s As Stream = hres.GetResponseStream()
        Dim sr As New StreamReader(s)
        Dim html As String = sr.ReadToEnd()

        sr.Close()
        s.Close()

        ' So kommt man auf den Desktop
        File.WriteAllText(My.Computer.FileSystem.SpecialDirectories.Desktop & "\XXXtestYYY.txt", html)
    End Sub

    Private Function AcceptCert(ByVal sender As Object, ByVal cert As System.Security.Cryptography.X509Certificates.X509Certificate,
                                ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain,
                                ByVal errors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function

    Private Sub ReadSingleShareValue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim a
        a = 1
        TextBox2.Text = My.Settings.Textbox_Settings
    End Sub

    Private Sub ReadSingleShareValue_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        My.Settings.Textbox_Settings = TextBox2.Text

        My.Settings.Save()
    End Sub


End Class