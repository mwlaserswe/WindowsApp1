Option Explicit On

Imports System.Xml

Module XmlUtilities
    Public Structure ShareInfo
        Public _ID As String
        Public _WKN As String
        Public _Name As String
        Public _ISIN As String
        Public _AbsMax As Double
        Public _AbsMaxPos As Integer
        Public _Minimum As Double
        Public _MinPos As Integer
        Public _RightMax As Double
        Public _RightMaxPos As Integer
    End Structure


    '''' Storage of employee data.
    '''Public _firstName As String
    '''Public _id As Integer
    '''Public _lastName As String
    '''Public _salary As Integer

    Public Function ReadShareInfo(FileName As String) As ShareInfo
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(FileName)
        Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/ShareInfo/General")
        'Dim ID As String = "", WKN As String = "", ISIN As String = ""
        For Each node As XmlNode In nodes
            ReadShareInfo._ID = node.SelectSingleNode("ID").InnerText
            ReadShareInfo._Name = node.SelectSingleNode("Name").InnerText
            ReadShareInfo._WKN = node.SelectSingleNode("WKN").InnerText
            ReadShareInfo._ISIN = node.SelectSingleNode("ISIN").InnerText
        Next
        nodes = xmlDoc.DocumentElement.SelectNodes("/ShareInfo/BestSD")
        'Dim ID As String = "", WKN As String = "", ISIN As String = ""
        For Each node As XmlNode In nodes
            ReadShareInfo._AbsMax = node.SelectSingleNode("AbsMax").InnerText
            ReadShareInfo._AbsMaxPos = node.SelectSingleNode("AbsMaxPos").InnerText
            ReadShareInfo._Minimum = node.SelectSingleNode("Minimum").InnerText
            ReadShareInfo._MinPos = node.SelectSingleNode("MinPos").InnerText
            ReadShareInfo._RightMax = node.SelectSingleNode("RightMax").InnerText
            ReadShareInfo._RightMaxPos = node.SelectSingleNode("RightMaxPos").InnerText
        Next

        '''Dim Zeile As String

        '''' So kommt man auf den Desktop
        '''Dim xmlReader As New XmlTextReader(FileName)
        '''While xmlReader.Read()
        '''    Select Case xmlReader.NodeType
        '''        Case XmlNodeType.Element
        '''            Zeile = ("<" + xmlReader.Name & ">")
        '''            Exit Select
        '''        Case XmlNodeType.Text
        '''            Zeile = (xmlReader.Value)
        '''            Exit Select
        '''        Case XmlNodeType.EndElement
        '''            Zeile = ("")
        '''            Exit Select
        '''    End Select
        '''End While
    End Function

    Public Sub ReadShareInfo_2(FileName As String)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(FileName)
        Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/Table/Product")
        Dim pID As String = "", pName As String = "", pPrice As String = ""
        For Each node As XmlNode In nodes
            pID = node.SelectSingleNode("Product_id").InnerText
            pName = node.SelectSingleNode("Product_name").InnerText
            pPrice = node.SelectSingleNode("Product_price").InnerText
            MessageBox.Show(pID & " " & pName & " " & pPrice)
        Next
    End Sub

    Public Sub CreateShareInfo(FileName As String, ShareItem As ShareInfo)
        ' Create XmlWriterSettings.
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True
        settings.NewLineOnAttributes = True

        ' Create XmlWriter.
        Using writer As XmlWriter = XmlWriter.Create(FileName, settings)
            ' Begin writing.
            writer.WriteStartDocument()
            writer.WriteStartElement("ShareInfo") ' Root.

            ' Loop over employees in array.
            ''Dim employee As ShareInfo
            ''For Each employee In ShareItem
            writer.WriteStartElement("General")
            writer.WriteElementString("ID", ShareItem._id.ToString)
            writer.WriteElementString("Name", ShareItem._Name)
            writer.WriteElementString("WKN", ShareItem._WKN)
            writer.WriteElementString("ISIN", ShareItem._ISIN)
            writer.WriteEndElement()

            writer.WriteStartElement("BestSD")
            writer.WriteElementString("AbsMax", ShareItem._AbsMax)
            writer.WriteElementString("AbsMaxPos", ShareItem._AbsMaxPos)
            writer.WriteElementString("Minimum", ShareItem._Minimum)
            writer.WriteElementString("MinPos", ShareItem._MinPos)
            writer.WriteElementString("RightMax", ShareItem._RightMax)
            writer.WriteElementString("RightMaxPos", ShareItem._RightMaxPos)
            writer.WriteEndElement()
            ''Next

            ' End document.
            writer.WriteEndElement()
            writer.WriteEndDocument()
        End Using
    End Sub




    Public Sub ModifyShareInfo(FileName As String, ElementPath As String, Element As String, Content As String)
        Dim doc As System.Xml.XmlDocument
        Dim editor, editor2 As System.Xml.XPath.XPathNavigator
        Dim writer As System.Xml.XmlWriter

        doc = New System.Xml.XmlDocument
        doc.Load(FileName)

        For Each editor In doc.CreateNavigator.Select(ElementPath)      ' z.B ("/ShareInfo/General")
            editor2 = editor.SelectSingleNode(Element)                  ' z.B ("ISIN")
            If Not IsNothing(editor2) Then
                editor2.DeleteSelf()
            End If

            writer = editor.AppendChild()
            ''writer.WriteStartElement("ShareInfo")
            writer.WriteElementString(Element, Content)                 ' z.B ("ISIN", "DE123456")

            ''das sieht dann so aus: <Test au_lname="A" au_fname="bcdef" />
            ''writer.WriteStartElement("Test")
            ''writer.WriteAttributeString("au_lname", "A")
            ''writer.WriteAttributeString("au_fname", "bcdef")
            writer.Close()
        Next

        '''For Each editor In doc.CreateNavigator.Select("/pubs/titles[authors/@au_lname='Green']")
        '''    editor2 = editor.SelectSingleNode("authors[@au_lname!='Green']")
        '''    If Not IsNothing(editor2) Then
        '''        editor2.DeleteSelf()
        '''    End If

        '''    writer = editor.AppendChild()
        '''    writer.WriteStartElement("authors")
        '''    writer.WriteAttributeString("au_lname", "A")
        '''    writer.WriteAttributeString("au_fname", "B")
        '''    writer.Close()
        '''Next

        doc.Save(FileName)
    End Sub

End Module
