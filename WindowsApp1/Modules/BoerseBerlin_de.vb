Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI

Module BoerseBerlin_de
    Public Function Read_BoerseBerlin_de(WKN As String) As Double
        'Dim HtmlCode As String
        Dim ISIN As String

        Dim WebPage As String
        'Dim SearchItem As String
        'Dim EndString As String
        'Dim AktuellerKurs As String

        ISIN = FindIsinInArray(WKN)

        'WebPage = "https://www.boerse-berlin.de/index.php/Aktien?isin=" & ISIN
        'HtmlCode = GetHTMLCode(WebPage)
        'If HtmlCode = ">>>ERROR<<<" Then
        '    Read_BoerseBerlin_de = -1
        '    Exit Function
        'End If

        'SaveQuelltext(HtmlCode, Application.StartupPath & "\BoerseBerlin.HTML")

        ''AktuellerKurs extrahieren
        'SearchItem = "_last"""
        'EndString = "</span>"
        'AktuellerKurs = ExtraxtValue(HtmlCode, SearchItem, EndString)
        'Dim dmy As Double

        'dmy = Zahl(AktuellerKurs)

        'Read_BoerseBerlin_de = dmy

        'End Function
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

        Try
            'Dim WebPage As String = "https://www.finanzen.net/aktien/msci-aktie"
            'Dim WebPage As String = "https://www.finanzen.net/aktien/allianz-aktie"
            WebPage = "https://www.boerse-berlin.de/index.php/Aktien?isin=" & ISIN
            driver.Manage().Window.Minimize()
            driver.Navigate().GoToUrl(WebPage)

            'Du kannst In Selenium einen XPath mit Wildcard oder Teilvergleich verwenden,
            'um den Wert auch dann zu finden, wenn sich die ID ändert,
            'z.B.id_175136222_last → irgendeine andere ID die mit id_ beginnt und mit _last am Ende.


            Dim wait As New WebDriverWait(driver, TimeSpan.FromSeconds(15))
            Dim kursElement As IWebElement = wait.Until(
            Function(d)
                'Return d.FindElement(By.ClassName("id_175136222_last"))
                'Return d.FindElement(By.XPath("//span[contains(@class, '_last')]"))
                Return d.FindElement(By.XPath("//span[contains(@class, '_last')]"))
            End Function
      )



            AktuellerKurs = kursElement.Text
            Dim dmy As Double = Zahl(AktuellerKurs)
            Read_BoerseBerlin_de = dmy

        Catch ex As Exception
            Console.WriteLine("Fehler beim Abrufen des Kurses: " & ex.Message)
            Read_BoerseBerlin_de = -1
        Finally
            driver.Quit()
        End Try
    End Function
End Module
