Option Explicit On

Public Class FrmFlyingListBoxList

    Public Title As String
    Public InputList As List(Of String)
    Public Filename As String

    Dim LclFileName As String

    Private Sub FrmFlyingListBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = Title

        L_FileName.Text = IO.Path.GetFileName(Filename)
        ListBox1.Items.Clear()
        ListBox1.Width = Me.Width - 30
        ListBox1.Height = Me.Height - 100

        B_OpenInNotepad.Enabled = False

        For i = 0 To InputList.Count - 1
            ListBox1.Items.Add(InputList(i))
        Next

    End Sub

    Private Sub FrmFlyingListBox_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim A As Integer
        ListBox1.Width = Me.Width - 30
        ListBox1.Height = Me.Height - 100
    End Sub

    Private Sub B_Save_Click(sender As Object, e As EventArgs) Handles B_Save.Click
        Dim ListFile As Integer

        If Filename = "" Then
            'SaveFileDialog1.CheckFileExists = False
            SaveFileDialog1.ShowDialog()
            LclFileName = SaveFileDialog1.FileName
            If SaveFileDialog1.FileName = "" Then
                Exit Sub
            End If
        Else
            LclFileName = Filename
        End If

        L_FileName.Text = IO.Path.GetFileName(LclFileName)

        ListFile = FreeFile()
        FileOpen(ListFile, LclFileName, OpenMode.Output)

        For i = 0 To InputList.Count - 1
            PrintLine(ListFile, InputList(i))
        Next i

        FileClose(ListFile)

        B_OpenInNotepad.Enabled = True

    End Sub

    Private Sub B_OpenInNotepad_Click(sender As Object, e As EventArgs) Handles B_OpenInNotepad.Click
        Dim myPath As String = "Notepad++.exe"
        Dim pr As New Process

        pr.StartInfo.FileName = myPath
        pr.StartInfo.Arguments = """" & LclFileName & """"
        pr.Start()
    End Sub

End Class