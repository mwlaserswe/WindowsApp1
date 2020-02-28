Option Explicit On

Public Class ReadHistoricFromAriva
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

        'Diectory: \History_download_from_ARIVA


        Application.DoEvents()


    End Sub



    Private Sub B_ReadAllFiles_Click(sender As Object, e As EventArgs) Handles B_ReadAllFiles.Click
        Dim FileName As String
        Dim HistoryArray() As HistoryItem
        Dim HistoricFromAriva As String
        Dim WKN As String
        Dim result As Double

        For idx = 0 To UBound(CompPartialLstArr)

            Application.DoEvents()

            WKN = CompPartialLstArr(idx).WKN
            FileName = Application.StartupPath & "\History_download_from_ARIVA\" & WKN & ".txt"


            ' Check if Option "Don't download existing files" is active
            If Not (Ch_1_Rd.Checked And System.IO.File.Exists(FileName)) Then

                ' Download historic files from  ARIVA.de to array "HistoricFomAriva()"
                If Ch_1_Rd.Checked Then
                    result = DownloadHistoricFromArivaFct(WKN, HistoricFromAriva, T_HTML_Snippet)
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
                ' Save array "HistoricFomAriva()" to "\History_download_from_ARIVA\123456.txt"
                WriteHistoryFile(Application.StartupPath & "\HistoryNew\" & CompPartialLstArr(idx).WKN & ".txt", HistoryArray)
            End If

            If Ch_4_Serv.Checked Then
                ServiceHistory(CompPartialLstArr(idx).WKN)
            End If


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


End Class