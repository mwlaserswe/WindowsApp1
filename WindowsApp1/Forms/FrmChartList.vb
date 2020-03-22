
Public Class FrmChartList
    Dim CompanyEntry As String
    Dim CompanyIndex As Long

    Private Sub C_MoveToPartialList_Click(sender As Object, e As EventArgs) Handles C_MoveToPartialList.Click
        Dim k As Long
        Dim CompanyEntry As String
        Dim count As Long

        'For k = 0 To ListCompelete.Items.Count - 1
        '    If ListCompelete.SelectedItem(k) <> "" Then
        '        CompanyEntry = ListCompelete.SelectedItem(k)
        '        ' ... do something
        '        ListPartial.Items.Add(CompanyEntry)
        '        'ListCompelete.SelectedItem(k) = False
        '        ListCompelete.SelectedItem(k) = ""
        '    End If
        'Next

        count = ListCompelete.SelectedItems.Count
        For k = 0 To ListCompelete.SelectedItems.Count - 1
            CompanyEntry = ListCompelete.SelectedItems(k)
            ' ... do something
            ListPartial.Items.Add(CompanyEntry)
            ''ListCompelete.SelectedItem(k) = False
            'ListCompelete.SelectedItem(k) = ""
        Next
        ListCompelete.ClearSelected()

    End Sub

    Private Sub ChartList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadCompanyListFile(ListCompelete)
        CompanyIndex = -1       ' -1 means no list item selected
        ListCompelete.SelectionMode = SelectionMode.MultiExtended
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim k As Long
        Dim CompanyEntry As String

        ListPartial.Items.Clear()
        For k = 0 To ListCompelete.Items.Count - 1
            CompanyEntry = ListCompelete.Items.Item(k)

            If InStr(1, CompanyEntry, TextBox1.Text, vbTextCompare) <> 0 Then
                ListPartial.Items.Add(CompanyEntry)
            End If
        Next

    End Sub


    Private Sub ChartList_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

        Dim Zeile As String
        Dim CompanyListEntities() As String
        Dim idx As Long

        ReDim CompPartialLstArr(0 To 0)

        For idx = 0 To ListPartial.Items.Count - 1
            Zeile = ListPartial.Items.Item(idx)
            SepariereString(Zeile, CompanyListEntities, vbTab)
            CompPartialLstArr(idx).Name = CompanyListEntities(0)
            CompPartialLstArr(idx).WKN = CompanyListEntities(1)
            CompPartialLstArr(idx).ISIN = CompanyListEntities(2)

            ReDim Preserve CompPartialLstArr(0 To UBound(CompPartialLstArr) + 1)
        Next idx

        ReDim Preserve CompPartialLstArr(0 To UBound(CompPartialLstArr) - 1)


    End Sub
End Class