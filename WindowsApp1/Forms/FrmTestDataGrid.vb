﻿Public Class FrmTestDataGrid
    'Private Sub Form1_Load(...) Handles MyBase.Load



    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer



        ' Spalten hinzufügen
        dgv.Columns.Add("spPrimaryKey", "Primary Key")
        dgv.Columns.Add("SpName", "Name")
        dgv.Columns.Add("SpVorname", "Vorname")
        dgv.Columns.Add("SpPersonalnummer",
                        "Personalnummer")
        dgv.Columns.Add("SpGehalt", "Gehalt")
        dgv.Columns.Add("SpGeburtstag", "Geburtstag")

        ' Breite einstellen
        For i = 0 To (dgv.Columns.Count) - 1
            dgv.Columns(i).Width = 75
        Next

        ' Zeilen hinzufügen
        dgv.Rows.Add("1", "Maier", "Hans", 6714, 3500, "15.03.1962")
        dgv.Rows.Add("2", "Schmitz", "Peter", 81343, 3750, "12.04.1958")
        dgv.Rows.Add("3", "Mertens", "Julia", 2297, 3621.5, "30.12.1959")
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        Dim st As String
        Dim z As DataGridViewRow
        Dim RIndex

        st = dgv.CurrentCell.Value
        z = dgv.CurrentRow

        Dim column As Integer = 3
        Dim row As Integer
        row = dgv.CurrentCell.RowIndex

        'Dim value As Object = dgv.Item(column, row).Value
        'Dim value As Object = dgv.CurrentCell.RowIndex
        Dim value As Object = dgv.CurrentRow.Index


        TextBox1.Text = value

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim column As Integer = 2
        Dim row As Integer = 2
        'row = dgv.CurrentCell.RowIndex

        For Each col As DataGridViewColumn In dgv.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        'dgv.Item("SpVorname", row).Value = "Hallo"


    End Sub
End Class