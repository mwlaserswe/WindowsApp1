Option Explicit On
Public Class FrmInfoFiles
    Private Sub B_GenerateInfoFiles_Click(sender As Object, e As EventArgs) Handles B_GenerateInfoFiles.Click
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

    Private Sub B_GenerateSingleInfoFiles_Click(sender As Object, e As EventArgs) Handles B_GenerateSingleInfoFiles.Click
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
End Class