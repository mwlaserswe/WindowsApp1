Imports System.Xml
Imports mshtml
Public Class FrmTestReadWriteXML



    ' Storage of employee data.
    Public _firstName As String
    Public _id As Integer
    Public _lastName As String
    Public _salary As Integer



    Dim wb As New WebBrowser



    Private Sub B_WriteXML_Click_1(sender As Object, e As EventArgs) Handles B_WriteXML.Click
        Dim ShareItem As ShareInfo

        'ShareItem = New ShareInfo(1, L_WKN.Text, L_ISIN.Text)
        ShareItem._ID = 1
        ShareItem._WKN = L_WKN.Text
        ShareItem._ISIN = L_ISIN.Text
        CreateShareInfo(Application.StartupPath & "\XML-Test\" & L_WKN.Text & ".xml", ShareItem)

    End Sub

    Private Sub B_ReadXML_Click_1(sender As Object, e As EventArgs) Handles B_ReadXML.Click
        Dim zeile As ShareInfo
        zeile = ReadShareInfo(Application.StartupPath & "\XML-Test\" & L_WKN.Text & ".xml")
    End Sub

    Private Sub B_AppendXML_Click_1(sender As Object, e As EventArgs) Handles B_AppendXML.Click
        ModifyShareInfo(Application.StartupPath & "\XML-Test\" & L_WKN.Text & ".xml", "/ShareInfo/General", "ISIN", Now)
    End Sub






    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' So kommt man auf den Desktop
        Dim xmlReader As New XmlTextReader(Application.StartupPath & "\employees.xml")
        While xmlReader.Read()
            Select Case xmlReader.NodeType
                Case XmlNodeType.Element
                    ListBox1.Items.Add("<" + xmlReader.Name & ">")
                    Exit Select
                Case XmlNodeType.Text
                    ListBox1.Items.Add(xmlReader.Value)
                    Exit Select
                Case XmlNodeType.EndElement
                    ListBox1.Items.Add("")
                    Exit Select
            End Select
        End While
    End Sub







    '''Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '''    Dim result As Integer = OpenFileDialog1.ShowDialog()
    '''    If result = System.Windows.Forms.DialogResult.Cancel Then Exit Sub
    '''    wb.Navigate(OpenFileDialog1.FileName)



    '''    Dim doc As HtmlDocument = Me.wb.Document
    '''    doc.GetElementById("fakeSpan").InnerHtml = "BAR!"
    '''    ListBox1.Items.Add(wb.DocumentText)
    '''End Sub





    '''Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


    '''    Dim XMLReader As Xml.XmlReader = New Xml.XmlTextReader(My.Computer.FileSystem.SpecialDirectories.Desktop & "\XXXtestYYY.xml")

    '''    With XMLReader

    '''        Do While .Read

    '''            If .NodeType = Xml.XmlNodeType.Element And .Name = "trkpt" Then

    '''                If .AttributeCount > 0 Then

    '''                    While .MoveToNextAttribute

    '''                        If .Name = "lat" Then MsgBox("lat: " & .Value)

    '''                        If .Name = "lon" Then MsgBox("lon:" & .Value)

    '''                    End While

    '''                End If


    '''                'wie ele und time auslesen?


    '''            End If

    '''        Loop

    '''        .Close()

    '''    End With

    '''    '''Dim strMyUrl As String
    '''    '''' url
    '''    '''strMyUrl = "http://www.somplace.com/subfold/xyz/GetInfo.cfm?LOGInUName=JOHN&LINPassword=mypass&username=123457"
    '''    '''Dim reader As XMLReader = XMLReader.Create(strMyUrl)
    '''    '''reader.ReadToFollowing("SUBDETAIL")
    '''    '''reader.MoveToFirstAttribute()
    '''    '''Dim id As String = reader.Value
    '''    '''Debug.Print("SUBDETAIL ID: " + id)
    '''End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        'Public Sub New(ByVal id As Integer, ByVal firstName As String,
        '               ByVal lastName As String, ByVal salary As Integer)
        '    ' Set fields.
        '    Me._id = id
        '    Me._firstName = firstName
        '    Me._lastName = lastName
        '    Me._salary = salary
        'End Sub




        ' Create array of employees.
        Dim employees(2) As ShareInfo
        'employees(0) = New ShareInfo(1, "Prakash", "Rangan")
        'employees(1) = New ShareInfo(5, "Norah", "Miller")
        'employees(2) = New ShareInfo(17, "Cecil", "Walker")

        ' Create XmlWriterSettings.
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True

        ' Create XmlWriter.
        Using writer As XmlWriter = XmlWriter.Create(Application.StartupPath & "\employees.xml", settings)
            ' Begin writing.
            writer.WriteStartDocument()
            writer.WriteStartElement("Employees") ' Root.

            ' Loop over employees in array.
            Dim employee As ShareInfo
            For Each employee In employees
                writer.WriteStartElement("Employee")
                writer.WriteElementString("ID", employee._id.ToString)
                writer.WriteElementString("FirstName", employee._WKN)
                writer.WriteElementString("LastName", employee._ISIN)
                '''writer.WriteElementString("Salary", employee._salary.ToString)
                writer.WriteEndElement()
            Next

            ' End document.
            writer.WriteEndElement()
            writer.WriteEndDocument()
        End Using
    End Sub


    '''Sub Main()
    '''    ' Create an XML reader.
    '''    Using reader As XMLReader = XMLReader.Create("C:\perls.xml")
    '''        While reader.Read()
    '''            ' Check for start elements.
    '''            If reader.IsStartElement() Then

    '''                ' See if perls element or article element.
    '''                If reader.Name = "perls" Then
    '''                    Console.WriteLine("Start <perls> element.")

    '''                ElseIf reader.Name = "article" Then
    '''                    Console.WriteLine("Start <article> element.")
    '''                    ' Get name attribute.
    '''                    Dim attribute As String = reader("name")
    '''                    If attribute IsNot Nothing Then
    '''                        Console.WriteLine("  Has attribute name: {0}", attribute)
    '''                    End If

    '''                    ' Text data.
    '''                    If reader.Read() Then
    '''                        Console.WriteLine("  Text node: {0}", reader.Value.Trim())
    '''                    End If
    '''                End If

    '''            End If
    '''        End While
    '''    End Using
    '''End Sub
End Class
