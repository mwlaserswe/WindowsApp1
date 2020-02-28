Imports System.Xml
Imports mshtml
Public Class XMLReader








    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' So kommt man auf den Desktop
        Dim xmlReader As New XmlTextReader(My.Computer.FileSystem.SpecialDirectories.Desktop & "\XXXtestYYY.txt")
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





    Dim wb As New WebBrowser

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim result As Integer = OpenFileDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.Cancel Then Exit Sub
        wb.Navigate(OpenFileDialog1.FileName)



        Dim doc As HtmlDocument = Me.wb.Document
        doc.GetElementById("fakeSpan").InnerHtml = "BAR!"
        ListBox1.Items.Add(wb.DocumentText)
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) 

    End Sub
End Class