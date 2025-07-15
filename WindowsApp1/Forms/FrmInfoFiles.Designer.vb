<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfoFiles
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.T_Search1 = New System.Windows.Forms.TextBox()
        Me.T_Info1 = New System.Windows.Forms.TextBox()
        Me.T_Info2 = New System.Windows.Forms.TextBox()
        Me.T_Info3 = New System.Windows.Forms.TextBox()
        Me.B_GenerateSingleInfoFiles = New System.Windows.Forms.Button()
        Me.T_Search = New System.Windows.Forms.TextBox()
        Me.B_GenerateAllInfoFiles = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.L_NoOfFiles = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 26)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(331, 112)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "schreibe TEST_INFO_FILE.XML (Volkswagen VZ)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(16, 157)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(331, 98)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Einzelnes History.XML lesen"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'T_Search1
        '
        Me.T_Search1.Location = New System.Drawing.Point(383, 156)
        Me.T_Search1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.T_Search1.Name = "T_Search1"
        Me.T_Search1.Size = New System.Drawing.Size(347, 38)
        Me.T_Search1.TabIndex = 6
        Me.T_Search1.Text = "Name, ISISN, WKN"
        '
        'T_Info1
        '
        Me.T_Info1.Location = New System.Drawing.Point(383, 202)
        Me.T_Info1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.T_Info1.Name = "T_Info1"
        Me.T_Info1.Size = New System.Drawing.Size(347, 38)
        Me.T_Info1.TabIndex = 7
        '
        'T_Info2
        '
        Me.T_Info2.Location = New System.Drawing.Point(383, 248)
        Me.T_Info2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.T_Info2.Name = "T_Info2"
        Me.T_Info2.Size = New System.Drawing.Size(347, 38)
        Me.T_Info2.TabIndex = 8
        '
        'T_Info3
        '
        Me.T_Info3.Location = New System.Drawing.Point(383, 294)
        Me.T_Info3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.T_Info3.Name = "T_Info3"
        Me.T_Info3.Size = New System.Drawing.Size(347, 38)
        Me.T_Info3.TabIndex = 9
        '
        'B_GenerateSingleInfoFiles
        '
        Me.B_GenerateSingleInfoFiles.Location = New System.Drawing.Point(972, 263)
        Me.B_GenerateSingleInfoFiles.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.B_GenerateSingleInfoFiles.Name = "B_GenerateSingleInfoFiles"
        Me.B_GenerateSingleInfoFiles.Size = New System.Drawing.Size(348, 66)
        Me.B_GenerateSingleInfoFiles.TabIndex = 11
        Me.B_GenerateSingleInfoFiles.Text = "Generate single info file"
        Me.B_GenerateSingleInfoFiles.UseVisualStyleBackColor = True
        '
        'T_Search
        '
        Me.T_Search.Location = New System.Drawing.Point(972, 355)
        Me.T_Search.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.T_Search.Name = "T_Search"
        Me.T_Search.Size = New System.Drawing.Size(347, 38)
        Me.T_Search.TabIndex = 12
        Me.T_Search.Text = "Name, ISISN, WKN"
        '
        'B_GenerateAllInfoFiles
        '
        Me.B_GenerateAllInfoFiles.Location = New System.Drawing.Point(972, 72)
        Me.B_GenerateAllInfoFiles.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.B_GenerateAllInfoFiles.Name = "B_GenerateAllInfoFiles"
        Me.B_GenerateAllInfoFiles.Size = New System.Drawing.Size(375, 66)
        Me.B_GenerateAllInfoFiles.TabIndex = 13
        Me.B_GenerateAllInfoFiles.Text = "Generate all Info files"
        Me.B_GenerateAllInfoFiles.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 31
        Me.ListBox1.Location = New System.Drawing.Point(1448, 40)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(644, 686)
        Me.ListBox1.TabIndex = 14
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(16, 355)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(328, 89)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Erzeuge Finanzen_Net Webpage"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'L_NoOfFiles
        '
        Me.L_NoOfFiles.AutoSize = True
        Me.L_NoOfFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_NoOfFiles.Location = New System.Drawing.Point(388, 384)
        Me.L_NoOfFiles.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.L_NoOfFiles.Name = "L_NoOfFiles"
        Me.L_NoOfFiles.Size = New System.Drawing.Size(103, 34)
        Me.L_NoOfFiles.TabIndex = 16
        Me.L_NoOfFiles.Text = "Label1"
        '
        'FrmInfoFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2132, 777)
        Me.Controls.Add(Me.L_NoOfFiles)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.B_GenerateAllInfoFiles)
        Me.Controls.Add(Me.T_Search)
        Me.Controls.Add(Me.B_GenerateSingleInfoFiles)
        Me.Controls.Add(Me.T_Info3)
        Me.Controls.Add(Me.T_Info2)
        Me.Controls.Add(Me.T_Info1)
        Me.Controls.Add(Me.T_Search1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmInfoFiles"
        Me.Text = "InfoFiles"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents T_Search1 As TextBox
    Friend WithEvents T_Info1 As TextBox
    Friend WithEvents T_Info2 As TextBox
    Friend WithEvents T_Info3 As TextBox
    Friend WithEvents B_GenerateSingleInfoFiles As Button
    Friend WithEvents T_Search As TextBox
    Friend WithEvents B_GenerateAllInfoFiles As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Button3 As Button
    Friend WithEvents L_NoOfFiles As Label
End Class
