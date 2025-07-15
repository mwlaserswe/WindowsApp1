Option Explicit On
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI

Module Comdirect_de
    Public Function Read_Comdirect(WKN As String) As Double
        'Dim HtmlCode As String
        Dim ISIN As String

        Dim WebPage As String
        'Dim SearchItem As String
        'Dim EndString As String
        'Dim AktuellerKurs As String

        ISIN = FindIsinInArray(WKN)

        'WebPage = "https://www.comdirect.de/inf/aktien/" & ISIN
        'HtmlCode = GetHTMLCode(WebPage)
        'If HtmlCode = ">>>ERROR<<<" Then
        '    Read_Comdirect = -1
        '    'ReadTodaysSharePrice.L_SharePrice = "Error"
        '    Exit Function
        'End If

        'SaveQuelltext(HtmlCode, Application.StartupPath & "\Comdirect.HTML")

        ''AktuellerKurs extrahieren
        'SearchItem = "<span class=""text-size--xxlarge text-weight--medium"""
        'EndString = "</span>"
        'AktuellerKurs = ExtraxtValue(HtmlCode, SearchItem, EndString)
        'Dim dmy As Double

        'dmy = Zahl(AktuellerKurs)

        'Read_Comdirect = dmy


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
        WebPage = "https://www.comdirect.de/inf/aktien/" & ISIN
        driver.Manage().Window.Minimize()
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
                Return d.FindElement(By.ClassName("realtime-indicator"))
            End Function
      )



            AktuellerKurs = kursElement.Text
            Dim dmy As Double = Zahl(AktuellerKurs)
            Read_Comdirect = dmy

        Catch ex As Exception
            Console.WriteLine("Fehler beim Abrufen des Kurses: " & ex.Message)
            Read_Comdirect = -1
        Finally
            driver.Quit()
        End Try

    End Function

End Module
