Option Explicit On
Imports System.Runtime.InteropServices
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI

Module BoerseStuttgart
    Public Function Read_BoerseStuttgart(WKN As String) As Double
        'Dim HtmlCode As String

        Dim WebPage As String
        'Dim SearchItem As String
        'Dim EndString As String
        'Dim AktuellerKurs As String

        'WebPage = "https://www.boerse-stuttgart.de/de-de/produkte/aktien/stuttgart/" & WKN
        'HtmlCode = GetHTMLCode(WebPage)
        'If HtmlCode = ">>>ERROR<<<" Then
        '    Read_BoerseStuttgart = -1
        '    'ReadTodaysSharePrice.L_SharePrice = "Error"
        '    Exit Function
        'End If

        'SaveQuelltext(HtmlCode, Application.StartupPath & "\BoerseStuttgartText.HTML")

        ''AktuellerKurs extrahieren
        'SearchItem = " data-animation=""BLOCK"">"
        'EndString = "</span>"
        'AktuellerKurs = ExtraxtValue(HtmlCode, SearchItem, EndString)
        'Dim dmy As Double

        'dmy = Zahl(AktuellerKurs)

        'Read_BoerseStuttgart = dmy

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
        WebPage = "https://www.boerse-stuttgart.de/de-de/produkte/aktien/stuttgart/" & WKN
        driver.Manage().Window.Minimize()
        driver.Navigate().GoToUrl(WebPage)

        Try
            ' Erklärung:


            ' Der HTML-Code:
            ' <h3 Class="text-2xl font-semibold">
            '  <Span></span>
            '  <Span Class="transition-colors ">
            '    <Span Class="">84,8</span>
            '  </span>
            '</h3>

            ' //h3[@class='text-2xl font-semibold']  → sucht das H3-Element
            ' //span[normalize-space()               → sucht den nicht-leeren inneren <span>, also den mit 84,8
            '
            ' Tipp: //span[text()='Geld']/following::h3[1]//span[normalize-space()]
            ' Das sucht nach dem Label "Geld" und nimmt danach das erste <h3> mit dem Kurs.



            Dim wait As New WebDriverWait(driver, TimeSpan.FromSeconds(15))
            Dim kursElement As IWebElement = wait.Until(
                Function(d)
                    Try
                        ' Sucht das H3-Element mit der Klasse "text-2xl font-semibold"
                        ' und dann den inneren <span> mit dem Kurswert.
                        Return d.FindElement(By.XPath("//h3[@class='text-2xl font-semibold']//span[normalize-space()]"))
                    Catch ex As NoSuchElementException
                        Console.WriteLine("Kurselement nicht gefunden: " & ex.Message)
                        Return Nothing
                    End Try
                    Return d.FindElement(By.XPath("//h3[@class='text-2xl font-semibold']//span[normalize-space()]"))
                End Function
            )



            AktuellerKurs = kursElement.Text
            Dim dmy As Double = Zahl(AktuellerKurs)
            Read_BoerseStuttgart = dmy

        Catch ex As Exception
            Console.WriteLine("Fehler beim Abrufen des Kurses: " & ex.Message)
            Read_BoerseStuttgart = -1
        Finally
            driver.Quit()
        End Try

    End Function

End Module
