Option Explicit On

Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Xml.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Module XmlUtilities

    'Old Style
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
    '/Old Style



    ' Codebook 2010.pdf S-1111-
    Public Sub SerializeToXmlFile(obj As Object, filename As String, encoding As Encoding)
        'XmlSerializer für den Typ des Objekts erzeugen
        Dim serializer As XmlSerializer = New XmlSerializer(obj.GetType())

        'Objekt über ein StreamWriter-Objekt serialisieren
        Using StreamWriter As StreamWriter = New StreamWriter(filename, False, encoding)
            serializer.Serialize(StreamWriter, obj)
        End Using
    End Sub


    Public Function SerializeToXmlString(obj As Object) As String
        ' XmlSerializer für den Typ des Objekts erzeugen
        Dim serializer As XmlSerializer = New XmlSerializer(obj.GetType())
        ' Objekt über einen StringWriter serialisieren
        Using stringWriter As StringWriter = New StringWriter()
            serializer.Serialize(stringWriter, obj)
            ' Das Ergebnis zurückgeben
            SerializeToXmlString = stringWriter.ToString()
        End Using
    End Function


    Public Function DeserializeFromXmlFile(filename As String, objectType As Type, encoding As Encoding) As Object
        ' XmlSerializer für den Typ des Objekts erzeugen
        Dim serializer As XmlSerializer = New XmlSerializer(objectType)
        ' Objekt über ein StreamReader-Objekt serialisieren
        Using streamReader As StreamReader = New StreamReader(filename, encoding)
            DeserializeFromXmlFile = serializer.Deserialize(streamReader)
        End Using
    End Function


    Public Function DeserializeFromXmlString(xmlString As String, objectType As Type) As Object
        ' XmlSerializer für den Typ des Objekts erzeugen
        Dim serializer As XmlSerializer = New XmlSerializer(objectType)
        ' Objekt über ein StreamReader-Objekt deserialisieren
        Using stringReader As StringReader = New StringReader(xmlString)
            DeserializeFromXmlString = serializer.Deserialize(stringReader)
        End Using
    End Function




















    'Old Style
    '''Public Function ReadShareInfo(FileName As String) As ShareInfo
    '''    Dim xmlDoc As New XmlDocument()

    '''    If Not System.IO.File.Exists(FileName) Then
    '''        Exit Function
    '''    End If


    '''    xmlDoc.Load(FileName)
    '''    Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/ShareInfo/General")
    '''    'Dim ID As String = "", WKN As String = "", ISIN As String = ""
    '''    For Each node As XmlNode In nodes
    '''        ReadShareInfo._ID = node.SelectSingleNode("ID").InnerText
    '''        ReadShareInfo._Name = node.SelectSingleNode("Name").InnerText
    '''        ReadShareInfo._WKN = node.SelectSingleNode("WKN").InnerText
    '''        ReadShareInfo._ISIN = node.SelectSingleNode("ISIN").InnerText
    '''    Next
    '''    nodes = xmlDoc.DocumentElement.SelectNodes("/ShareInfo/BestSD")
    '''    'Dim ID As String = "", WKN As String = "", ISIN As String = ""
    '''    For Each node As XmlNode In nodes
    '''        ReadShareInfo._AbsMax = node.SelectSingleNode("AbsMax").InnerText
    '''        ReadShareInfo._AbsMaxPos = node.SelectSingleNode("AbsMaxPos").InnerText
    '''        ReadShareInfo._Minimum = node.SelectSingleNode("Minimum").InnerText
    '''        ReadShareInfo._MinPos = node.SelectSingleNode("MinPos").InnerText
    '''        ReadShareInfo._RightMax = node.SelectSingleNode("RightMax").InnerText
    '''        ReadShareInfo._RightMaxPos = node.SelectSingleNode("RightMaxPos").InnerText
    '''    Next

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
    '''End Function

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
            writer.WriteElementString("ID", ShareItem._ID.ToString)
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
    '/Old Style

End Module
