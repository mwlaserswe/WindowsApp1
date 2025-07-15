Option Explicit On
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI
Module Irgendwas
    Public Function Read_Irgendwas(Name As String, ShareInfo As ClsXML.ShareInfo) As Double
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
        Dim WebPage As String = "https://wertpapiere.ing.de/investieren/aktienportrait/" & ShareInfo.General.ISIN

        If WebPage = "" Then
            Console.WriteLine("Webseite für Finanzen.net ist nicht der XML-Datei definiert.")
            Read_Irgendwas = -1
            Return Read_Irgendwas
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
        Try
            Return d.FindElement(By.XPath("_ngcontent-ng-c1490613999="))
        Catch ex As NoSuchElementException
            Console.WriteLine("Kurselement nicht gefunden: " & ex.Message)
            Return Nothing
        End Try
    End Function
)



            AktuellerKurs = kursElement.Text
            Dim dmy As Double = Zahl(AktuellerKurs)
            Read_Irgendwas = dmy

        Catch ex As Exception
            Console.WriteLine("Fehler beim Abrufen des Kurses: " & ex.Message)
            Read_Irgendwas = -1
        Finally
            driver.Quit()
        End Try
    End Function

End Module
