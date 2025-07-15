Option Explicit On

Imports System.IO
Imports System.Text
Imports System.Xml.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Public Class FrmInfoFiles

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
        Dim BestSMA As BestSMA
        Dim FullpathHistory As String
        Dim FullpathInfo As String
        Dim SMAArry As String

        FullpathHistory = Path.Combine(Application.StartupPath, "History", Company.WKN & ".txt")
        ReadHistoryFileToChartArray(FullpathHistory, "")

        FullpathInfo = Path.Combine(Application.StartupPath, "HistoryInfo", Company.WKN & ".XML")
        If File.Exists(FullpathInfo) Then
            ShareInfo = DeserializeFromXmlFile(FullpathInfo, ShareInfo.GetType(), Encoding.UTF8)
        Else
            ShareInfo.General.ID = "0"
            ShareInfo.General.Name = Company.Name
            ShareInfo.General.WKN = Company.WKN
            ShareInfo.General.ISIN = Company.ISIN
        End If


        'Last year
        BestSMA = FindBestSMA(UBound(ChartArray) - 260, 260)  '260 Entries in HistoryArray is about 1 year.
        ShareInfo.BestSMA.SMA_LastYear.AbsMax = BestSMA.AbsMax
        ShareInfo.BestSMA.SMA_LastYear.AbsMaxPos = BestSMA.AbsMaxPos
        SMAArry = ""
        For Each Element In BestSMA.SMAArry
            SMAArry = SMAArry & Format(Element, "0.000") & " "
        Next
        ShareInfo.BestSMA.SMA_LastYear.SMAArry = SMAArry

        'Since 2000
        BestSMA = FindBestSMA(10, 9999)  '260 Entries in HistoryArray is about 1 year. 9999: all
        ShareInfo.BestSMA.SMA_Since2000.AbsMax = BestSMA.AbsMax
        ShareInfo.BestSMA.SMA_Since2000.AbsMaxPos = BestSMA.AbsMaxPos
        SMAArry = ""
        For Each Element In BestSMA.SMAArry
            SMAArry = SMAArry & Format(Element, "0.000") & " "
        Next
        ShareInfo.BestSMA.SMA_Since2000.SMAArry = SMAArry

        'Since Corona
        BestSMA = FindBestSMA(5254, 9999)  'Corona starts 10.02.2020
        ShareInfo.BestSMA.SMA_SinceCorona.AbsMax = BestSMA.AbsMax
        ShareInfo.BestSMA.SMA_SinceCorona.AbsMaxPos = BestSMA.AbsMaxPos
        SMAArry = ""
        For Each Element In BestSMA.SMAArry
            SMAArry = SMAArry & Format(Element, "0.000") & " "
        Next
        ShareInfo.BestSMA.SMA_SinceCorona.SMAArry = SMAArry

        ' Object in XML-datei schreiben
        SerializeToXmlFile(ShareInfo, FullpathInfo, Encoding.UTF8)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ShareInfo As New ClsXML.ShareInfo
        Dim XML_Filename As String

        ShareInfo.General.ID = "0"
        ShareInfo.General.Name = "Volkswagen(VW) St."
        ShareInfo.General.WKN = "766400"
        ShareInfo.General.ISIN = "DE0007664005"

        ShareInfo.WebInfos.FinanzenNetWebPage = "https://www.finanzen.net/aktien/Volkswagen_vz-aktie"
        ShareInfo.WebInfos.ArivaHistoricDownloadWebPage = "https://www.ariva.de/aktien/volkswagen-ag-vz-aktie/kurse/historische-kurse"

        ShareInfo.UserDefinitions.UserDefinedSMA = "1234"


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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ShareInfo As New ClsXML.ShareInfo
        Dim Company As ShareItem
        Dim XML_Filename As String
        Dim i As Long

        If CompPartialLstArr Is Nothing Then
            MsgBox("Bitte zuerst Firmen in ChartArray legen...")
            Exit Sub
        End If

        For i = LBound(CompPartialLstArr) To UBound(CompPartialLstArr)
            Application.DoEvents()


            XML_Filename = Path.Combine(Application.StartupPath, "HistoryInfo", CompPartialLstArr(i).WKN & ".XML")

            If File.Exists(XML_Filename) Then
                ShareInfo = DeserializeFromXmlFile(XML_Filename, ShareInfo.GetType(), Encoding.UTF8)
            Else
                ShareInfo.General.ID = "0"
                ShareInfo.General.Name = CompPartialLstArr(i).Name
                ShareInfo.General.WKN = CompPartialLstArr(i).WKN
                ShareInfo.General.ISIN = CompPartialLstArr(i).ISIN
            End If

            T_Info1.Text = ShareInfo.General.WKN
            T_Info2.Text = ShareInfo.General.ISIN

            ShareInfo.WebInfos.FinanzenNetWebPage = "https://www.finanzen.net/aktien/" & CompPartialLstArr(i).Name & "-aktie"

            SerializeToXmlFile(ShareInfo, XML_Filename, Encoding.UTF8)
        Next i

    End Sub

    Private Sub FrmInfoFiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Long

        L_NoOfFiles.Text = CompPartialLstArr.Length

        ListBox1.Items.Clear()

        For i = LBound(CompPartialLstArr) To UBound(CompPartialLstArr)
            ListBox1.Items.Add(CompPartialLstArr(i).Name)
        Next i
    End Sub

    Private Sub FrmInfoFiles_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus

    End Sub

    Private Sub FrmInfoFiles_MouseHover(sender As Object, e As EventArgs) Handles Me.MouseHover
        Dim i As Long

        L_NoOfFiles.Text = CompPartialLstArr.Length

        ListBox1.Items.Clear()

        For i = LBound(CompPartialLstArr) To UBound(CompPartialLstArr)
            ListBox1.Items.Add(CompPartialLstArr(i).Name)
        Next i

    End Sub
End Class