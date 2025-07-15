Option Explicit On
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI

Module finanzen_net

    'Public Function Read_Peketec(WKN As String) As Double
    '    Dim HtmlCode As String

    '    Dim WebPage As String
    '    Dim SearchItem As String
    '    Dim AktuellerKurs As String
    '    Dim InstrumentId As String
    '    Dim ISIN As String



    '    Dim PosStart As Long
    '    Dim PosEnd As Long
    '    Dim EndString As String

    '    Dim options As New ChromeOptions()
    '    options.AddArgument("--whitelisted-ips=")
    '    options.AddArgument("--headless") ' Headless-Modus aktivieren
    '    'options.AddArgument("--disable-gpu") ' (optional, für Kompatibilität)



    '    ' ChromeDriver-Instanz starten
    '    Dim driver As New ChromeDriver(options)

    '    ' Webseite öffnen
    '    'WebPage = "https://www.consorsbank.de/web/Suche/Wertpapier/Alle-Ergebnisse/Aktien?searchQuery=" & WKN
    '    WebPage = "https://www.finanzen.net/aktien/msci-aktie"
    '    driver.Navigate().GoToUrl(WebPage)

    '    ' Warte, bis der Link sichtbar ist (empfohlen)
    '    Dim wait As New OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10))
    '    Dim kursElement As IWebElement = wait.Until(
    '        Function(d)
    '            Return d.FindElement(By.ClassName("snapshot__value"))
    '        End Function
    '    )

    '    ' Wert extrahieren
    '    AktuellerKurs = kursElement.Text ' ergibt z.B. "485,00"






    '    ''WebPage = "https://peketec.de/portal/charts/show/key/" & WKN
    '    'HtmlCode = GetHTMLCode(WebPage)
    '    'If HtmlCode = ">>>ERROR<<<" Then
    '    '    Read_Peketec = -1
    '    '    'ReadTodaysSharePrice.L_SharePrice = "Error"
    '    '    Exit Function
    '    'End If

    '    ''    SaveQuelltext HtmlCode, App.Path & "\GoogleText.HTML"

    '    'AktuellerKurs extrahieren
    '    SearchItem = "<div class=""rtlast"">"
    '    EndString = "</div>"
    '    AktuellerKurs = ExtraxtValue(HtmlCode, SearchItem, EndString)
    '    Dim dmy As Double
    '    dmy = Zahl(AktuellerKurs)

    '    Read_Peketec = dmy

    '    'ReadTodaysSharePrice.L_WebPage = WebPage
    '    'ReadTodaysSharePrice.L_SharePrice = dmy
    '    '    L_WKN = WKN
    '    '    L_ISIN = ISIN



    '    'Read_Peketec = 0

    'End Function

    Public Function Read_Finanzen(Name As String, ShareInfo As ClsXML.ShareInfo) As Double
        Dim AktuellerKurs As String

        Dim options As New ChromeOptions()
        'options.AddArgument("--headless")
        'options.AddArgument("--disable-gpu")
        'options.AddArgument("--no-sandbox")
        'options.AddArgument("--disable-dev-shm-usage")
        'options.AddArgument("--window-size=1920,1080")

        options.AddExcludedArgument("enable-automation") ' Entfernt "Chrome is being controlled by automated software"
        options.AddAdditionalOption("useAutomationExtension", False)

        options.AddArgument("--disable-blink-features=AutomationControlled") ' Versteckt navigator.webdriver
        options.AddArgument("--no-sandbox")
        options.AddArgument("--disable-gpu")
        options.AddArgument("--disable-infobars")
        options.AddArgument("--window-size=1920,1080")

        Dim service As ChromeDriverService = ChromeDriverService.CreateDefaultService()
        service.HideCommandPromptWindow = True ' unterbindet das Konsolenfenster
        Dim driver As New ChromeDriver(service, options)

        'Dim WebPage As String = "https://www.finanzen.net/aktien/msci-aktie"
        'Dim WebPage As String = "https://www.finanzen.net/aktien/allianz-aktie"
        'Dim WebPage As String = "https://www.finanzen.net/aktien/" & Name & "-aktie"
        Dim WebPage As String = ShareInfo.WebInfos.FinanzenNetWebPage

        If WebPage = "" Then
            Console.WriteLine("Webseite für Finanzen.net ist nicht der XML-Datei definiert.")
            Read_Finanzen = -1
            Return Read_Finanzen
        End If

        'driver.Manage().Window.Minimize()
        driver.Navigate().GoToUrl(WebPage)

        Try
            'Dim wait As New WebDriverWait(driver, TimeSpan.FromSeconds(15))
            'Dim kursElement As IWebElement = wait.Until(
            'Function(d)
            '    Return d.FindElement(By.XPath("//div[contains(@Class,'snapshot__value')]"))
            'End Function
            Dim wait As New WebDriverWait(driver, TimeSpan.FromSeconds(15))
            Dim kursElement As IWebElement = wait.Until(
            Function(d)
                Return d.FindElement(By.ClassName("snapshot__value"))
            End Function
      )



            AktuellerKurs = kursElement.Text
            Dim dmy As Double = Zahl(AktuellerKurs)
            Read_Finanzen = dmy

        Catch ex As Exception
            Console.WriteLine("Fehler beim Abrufen des Kurses: " & ex.Message)
            Read_Finanzen = -1
        Finally
            driver.Quit()
        End Try
    End Function

End Module
