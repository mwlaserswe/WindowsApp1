Option Explicit On

Imports System.IO
Imports System.Text
Imports System.Xml.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Public Class FrmInfoFiles

    Private Sub B_GenerateInfoFiles_Click(sender As Object, e As EventArgs)
        Dim Content As ShareInfo
        Dim DemoBestSD As BestSMA
        Dim Fullpath As String

        If MsgBox("All Info-Files will be overwritten!", MsgBoxStyle.OkCancel) = vbCancel Then
            Exit Sub
        End If

        For Each Company As ShareItem In CompPartialLstArr
            'Find Company.Name
            For i = LBound(CompanyListArray) To UBound(CompanyListArray)
                If CompanyListArray(i).WKN = Company.WKN Then
                    Company.Name = CompanyListArray(i).Name
                    Exit For
                End If
            Next i

            Content._ID = 0
            Content._Name = Company.Name
            Content._WKN = Company.WKN
            Content._ISIN = Company.ISIN

            Fullpath = Application.StartupPath & "\History\" & Company.WKN & ".txt"
            ReadHistoryFileToChartArray(Fullpath, Company.Name)

            DemoBestSD = Chart.FindBestSMA(500, 9999)  '260 Entries in HistoryArray is about 1 year. 9999: all
            Content._AbsMax = DemoBestSD.AbsMax
            Content._AbsMaxPos = DemoBestSD.AbsMaxPos

            CreateShareInfo(Application.StartupPath & "\HistoryInfo\" & Company.WKN & ".xml", Content)

            Application.DoEvents()
        Next


    End Sub

    Private Sub B_GenerateSingleInfoFiles_Click(sender As Object, e As EventArgs)
        Dim Company As ShareItem
        Dim Content As ShareInfo
        Dim DemoBestSD As BestSMA
        Dim Fullpath As String
        Dim i As Long
        Dim WKN As String


        For i = LBound(CompanyListArray) To UBound(CompanyListArray)
            Application.DoEvents()
            If InStr(1, CompanyListArray(i).Name, T_Search.Text, vbTextCompare) > 0 _
                Or InStr(1, CompanyListArray(i).WKN, T_Search.Text, vbTextCompare) > 0 _
                Or InStr(1, CompanyListArray(i).ISIN, T_Search.Text, vbTextCompare) _
            Then

                Company = CompanyListArray(i)
                Fullpath = Application.StartupPath & "\History\" & Company.WKN & ".txt"
                ReadHistoryFileToChartArray(Fullpath, Company.Name)

                DemoBestSD = Chart.FindBestSMA(500, 9999)  '260 Entries in HistoryArray is about 1 year. 9999: all
                Content._AbsMax = DemoBestSD.AbsMax
                Content._AbsMaxPos = DemoBestSD.AbsMaxPos

            End If

        Next i
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ShareInfo As New ClsXML.ShareInfo
        Dim XML_Filename As String

        ShareInfo.General.ID = "0"
        ShareInfo.General.Name = "Volkswagen(VW) St."
        ShareInfo.General.WKN = "766400"
        ShareInfo.General.ISIN = "DE0007664005"

        ShareInfo.BestSD.AbsMax = 2.2
        ShareInfo.BestSD.AbsMaxPos = 8
        ShareInfo.BestSD.Minimum = 3.8
        ShareInfo.BestSD.MinPos = 185
        ShareInfo.BestSD.RightMax = 4
        ShareInfo.BestSD.RightMaxPos = 123

        XML_Filename = Path.Combine(Application.StartupPath, "TEST_INFO_FILE.XML")
        ' Object in XML-datei schreiben
        SerializeToXmlFile(ShareInfo, XML_Filename, Encoding.UTF8)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ShareInfo As New ClsXML.ShareInfo
        Dim Company As ShareItem
        Dim Fullpath As String
        Dim i As Long

        For i = LBound(CompanyListArray) To UBound(CompanyListArray)
            Application.DoEvents()
            If InStr(1, CompanyListArray(i).Name, T_Search1.Text, vbTextCompare) > 0 _
                Or InStr(1, CompanyListArray(i).WKN, T_Search1.Text, vbTextCompare) > 0 _
                Or InStr(1, CompanyListArray(i).ISIN, T_Search1.Text, vbTextCompare) _
            Then
                Company = CompanyListArray(i)
                Fullpath = Path.Combine(Application.StartupPath, "HistoryInfo", Company.WKN & ".XML")

                ShareInfo = DeserializeFromXmlFile(Fullpath, ShareInfo.GetType(), Encoding.UTF8)

                T_Info1.Text = ShareInfo.General.WKN
                T_Info2.Text = ShareInfo.General.ISIN
                T_Info3.Text = ShareInfo.BestSD.AbsMax

                T_Info3.Text = ShareInfo.BestSD.AbsMaxPos
                T_Info3.Text = ShareInfo.BestSD.Minimum
                T_Info3.Text = ShareInfo.BestSD.MinPos
                T_Info3.Text = ShareInfo.BestSD.RightMax
                T_Info3.Text = ShareInfo.BestSD.RightMaxPos



            End If

        Next i

    End Sub

End Class