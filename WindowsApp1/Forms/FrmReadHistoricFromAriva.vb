Option Explicit On

Imports System.IO
Public Class FrmReadHistoricFromAriva

    Dim CompListNew() As ShareItem


    Private Sub ReadHistoricFromAriva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Ch_0_Exist.Checked = My.Settings.Ch_0_Exist
        Ch_1_Rd.Checked = My.Settings.Ch_1_Rd
        Ch_2_Inv.Checked = My.Settings.Ch_2_Inv
        Ch_4_Serv.Checked = My.Settings.Ch_4_Serv
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim HistoricFomAriva As String
        Dim WKN As String
        Dim result As Double

        WKN = T_WKN.Text

        'Diectory: \01_History_download_from_ARIVA
        SingleReadFromAriva(WKN)

    End Sub

    Private Sub B_ReadAllFiles_Click(sender As Object, e As EventArgs) Handles B_ReadAllFiles.Click
        Dim WKN As String

        ListBox1.Items.Clear()

        For idx = 0 To UBound(CompListNew)

            Application.DoEvents()
            ListBox1.Items.Add(CompListNew(idx).Name)
            WKN = CompPartialLstArr(idx).WKN
            SingleReadFromAriva(WKN)

        Next idx

    End Sub


    Private Sub Ch_0_Exist_CheckedChanged(sender As Object, e As EventArgs) Handles Ch_0_Exist.CheckedChanged
        My.Settings.Ch_0_Exist = Ch_0_Exist.Checked
        My.Settings.Save()

    End Sub


    Private Sub Ch_1_Rd_CheckedChanged(sender As Object, e As EventArgs) Handles Ch_1_Rd.CheckedChanged
        My.Settings.Ch_1_Rd = Ch_1_Rd.Checked
        My.Settings.Save()
    End Sub


    Private Sub Ch_2_Inv_CheckedChanged(sender As Object, e As EventArgs) Handles Ch_2_Inv.CheckedChanged
        My.Settings.Ch_2_Inv = Ch_2_Inv.Checked
        My.Settings.Save()

    End Sub


    Private Sub Ch_4_Serv_CheckedChanged(sender As Object, e As EventArgs) Handles Ch_4_Serv.CheckedChanged
        My.Settings.Ch_4_Serv = Ch_4_Serv.Checked
        My.Settings.Save()

    End Sub


    Private Sub SingleReadFromAriva(WKN As String)
        Dim FileName As String
        Dim HistoryArray() As HistoryItem
        Dim HistoricFromAriva As String
        Dim result As Double

        FileName = Application.StartupPath & "\01_History_download_from_ARIVA\" & WKN & ".txt"


        ' Check if Option "Don't download existing files" is active
        ' Ch_1_Rd  Exists  |  download
        '      0      0    |     1
        '      0      1    |     1
        '      1      0    |     1
        '      1      1    |     0

        Dim ex As Boolean
        ex = System.IO.File.Exists(FileName)

        If Not (Ch_0_Exist.Checked And System.IO.File.Exists(FileName)) Then

            ' Download historic files from  ARIVA.de to array "HistoricFomAriva()"
            If Ch_1_Rd.Checked Then
                result = DownloadHistoricFromArivaFct(WKN, HistoricFromAriva, T_SecureCode)
                If result < 0 Then
                    MsgBox("Problem beim Download der Kurse von: " & WKN)
                    Exit Sub
                End If
                SaveQuelltext(HistoricFromAriva, FileName)
            End If

        End If

        Application.DoEvents()

        ' Files from ARIVA.de normaly starts with the latest date
        If Ch_2_Inv.Checked Then
            ReadHistoryFile(FileName, HistoryArray)
            InvertDateOrder(HistoryArray)
        End If

        Application.DoEvents()

        If Ch_1_Rd.Checked Or Ch_2_Inv.Checked Then
            ' Save array "HistoricFomAriva()" to "\01_History_download_from_ARIVA\123456.txt"
            WriteHistoryFile(Application.StartupPath & "\02_HistoryNew\" & WKN & ".txt", HistoryArray)
        End If

        If Ch_4_Serv.Checked Then
            ServiceHistory(WKN)
        End If

    End Sub


    Private Sub B_ReadFile_Click(sender As Object, e As EventArgs) Handles B_ReadFile.Click
        CompanyFileToArray(Application.StartupPath & "\ISIN-WKN-New.txt", CompListNew)
        CompanyArrayToListbox(ListBox1, CompListNew)
    End Sub


    Private Sub CompanyArrayToListbox(ListBox As ListBox, CompanyListArray() As ShareItem)
        Dim Zeile As String

        For i = LBound(CompanyListArray) To UBound(CompanyListArray)
            Zeile = CompanyListArray(i).Name _
                    & "    " & CompanyListArray(i).WKN _
                    & "    " & CompanyListArray(i).ISIN _
                    & "    " & CompanyListArray(i).Index

            ListBox.Items.Add(Zeile)
        Next
    End Sub

    Private Sub B_CompleteCompanyWKNISIN_Click(sender As Object, e As EventArgs) Handles B_CompleteCompanyWKNISIN.Click
        Dim InFileName As String
        Dim OutFileName As String
        Dim OutFilePath As String
        Dim OutFileFullPath As String




        Dim result As Integer = OpenFileDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        If OpenFileDialog1.FileName = "" Then
            Exit Sub
        End If
        InFileName = OpenFileDialog1.FileName

        OutFilePath = Path.GetDirectoryName(InFileName)
        OutFileName = Path.GetFileNameWithoutExtension(InFileName) & "-COMPLETE.txt"

        'InFileName = Path.Combine(Application.StartupPath, "ISIN-WKN-TEST.txt")
        OutFileName = Path.Combine(OutFilePath, OutFileName)
        CompleteCompWknIsin(InFileName, OutFileName)
    End Sub
End Class