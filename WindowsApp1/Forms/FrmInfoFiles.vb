Option Explicit On

Imports System.IO
Imports System.Text
Imports System.Xml.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Public Class FrmInfoFiles

    Private Sub B_GenerateAllInfoFiles_Click(sender As Object, e As EventArgs) Handles B_GenerateAllInfoFiles.Click
        Dim ShareInfo As New ClsXML.ShareInfo

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

            ListBox1.Items.Add(Company.Name)
            WriteBestSMAofSingleShare(Company, ShareInfo)

            Application.DoEvents()
        Next


    End Sub


    Private Sub WriteBestSMAofSingleShare(Company As ShareItem, ShareInfo As ClsXML.ShareInfo)
        Dim DemoBestSD As BestSMA
        Dim FullpathHistory As String
        Dim FullpathInfo As String
        Dim SMAArry As String

        FullpathHistory = Path.Combine(Application.StartupPath, "History", Company.WKN & ".txt")
        ReadHistoryFileToChartArray(FullpathHistory, "")

        FullpathInfo = Path.Combine(Application.StartupPath & "HistoryInfo", Company.WKN & ".XML")
        If File.Exists(FullpathInfo) Then
            ShareInfo = DeserializeFromXmlFile(FullpathInfo, ShareInfo.GetType(), Encoding.UTF8)
        Else
            ShareInfo.General.ID = "0"
            ShareInfo.General.Name = Company.Name
            ShareInfo.General.WKN = Company.WKN
            ShareInfo.General.ISIN = Company.ISIN
        End If


        'Last year
        DemoBestSD = FindBestSMA(UBound(ChartArray) - 260, 260)  '260 Entries in HistoryArray is about 1 year.
        ShareInfo.BestSD.SMA_OneYear.AbsMax = DemoBestSD.AbsMax
        ShareInfo.BestSD.SMA_OneYear.AbsMaxPos = DemoBestSD.AbsMaxPos
        SMAArry = ""
        For Each Element In DemoBestSD.SMAArry
            SMAArry = SMAArry & Format(Element, "0.000") & " "
        Next
        ShareInfo.BestSD.SMA_OneYear.SMAArry = SMAArry

        'Since 2000
        DemoBestSD = FindBestSMA(10, 9999)  '260 Entries in HistoryArray is about 1 year. 9999: all
        ShareInfo.BestSD.SMA_Since2000.AbsMax = DemoBestSD.AbsMax
        ShareInfo.BestSD.SMA_Since2000.AbsMaxPos = DemoBestSD.AbsMaxPos
        SMAArry = ""
        For Each Element In DemoBestSD.SMAArry
            SMAArry = SMAArry & Format(Element, "0.000") & " "
        Next
        ShareInfo.BestSD.SMA_Since2000.SMAArry = SMAArry

        'Since Corona
        DemoBestSD = FindBestSMA(5254, 9999)  'Corona starts 10.02.2020
        ShareInfo.BestSD.SMA_SinceCorona.AbsMax = DemoBestSD.AbsMax
        ShareInfo.BestSD.SMA_SinceCorona.AbsMaxPos = DemoBestSD.AbsMaxPos
        SMAArry = ""
        For Each Element In DemoBestSD.SMAArry
            SMAArry = SMAArry & Format(Element, "0.000") & " "
        Next
        ShareInfo.BestSD.SMA_SinceCorona.SMAArry = SMAArry

        If File.Exists(FullpathInfo) Then
            ' Object in XML-datei schreiben
            SerializeToXmlFile(ShareInfo, FullpathInfo, Encoding.UTF8)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ShareInfo As New ClsXML.ShareInfo
        Dim XML_Filename As String

        ShareInfo.General.ID = "0"
        ShareInfo.General.Name = "Volkswagen(VW) St."
        ShareInfo.General.WKN = "766400"
        ShareInfo.General.ISIN = "DE0007664005"

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
            End If

        Next i

    End Sub



    Private Sub B_GenerateSingleInfoFiles_Click_1(sender As Object, e As EventArgs) Handles B_GenerateSingleInfoFiles.Click
        Dim ShareInfo As New ClsXML.ShareInfo
        Dim Company As ShareItem
        Dim Fullpath As String
        Dim i As Long

        For i = LBound(CompanyListArray) To UBound(CompanyListArray)
            Application.DoEvents()
            If InStr(1, CompanyListArray(i).Name, T_Search.Text, vbTextCompare) > 0 _
                Or InStr(1, CompanyListArray(i).WKN, T_Search.Text, vbTextCompare) > 0 _
                Or InStr(1, CompanyListArray(i).ISIN, T_Search.Text, vbTextCompare) _
            Then
                Company = CompanyListArray(i)
                ListBox1.Items.Add(Company.Name)
                WriteBestSMAofSingleShare(Company, ShareInfo)

            End If

        Next i

    End Sub




End Class