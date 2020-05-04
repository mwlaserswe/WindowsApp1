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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.T_Search = New System.Windows.Forms.TextBox()
        Me.B_GenerateSingleInfoFiles = New System.Windows.Forms.Button()
        Me.B_GenerateInfoFiles = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.T_Search1 = New System.Windows.Forms.TextBox()
        Me.T_Info1 = New System.Windows.Forms.TextBox()
        Me.T_Info2 = New System.Windows.Forms.TextBox()
        Me.T_Info3 = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.T_Search)
        Me.GroupBox1.Controls.Add(Me.B_GenerateSingleInfoFiles)
        Me.GroupBox1.Controls.Add(Me.B_GenerateInfoFiles)
        Me.GroupBox1.Location = New System.Drawing.Point(54, 382)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(657, 211)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Old Style"
        '
        'T_Search
        '
        Me.T_Search.Location = New System.Drawing.Point(40, 147)
        Me.T_Search.Name = "T_Search"
        Me.T_Search.Size = New System.Drawing.Size(261, 31)
        Me.T_Search.TabIndex = 5
        Me.T_Search.Text = "Name, ISISN, WKN"
        '
        'B_GenerateSingleInfoFiles
        '
        Me.B_GenerateSingleInfoFiles.Location = New System.Drawing.Point(40, 65)
        Me.B_GenerateSingleInfoFiles.Name = "B_GenerateSingleInfoFiles"
        Me.B_GenerateSingleInfoFiles.Size = New System.Drawing.Size(261, 53)
        Me.B_GenerateSingleInfoFiles.TabIndex = 4
        Me.B_GenerateSingleInfoFiles.Text = "Generate single info file"
        Me.B_GenerateSingleInfoFiles.UseVisualStyleBackColor = True
        '
        'B_GenerateInfoFiles
        '
        Me.B_GenerateInfoFiles.Location = New System.Drawing.Point(357, 65)
        Me.B_GenerateInfoFiles.Name = "B_GenerateInfoFiles"
        Me.B_GenerateInfoFiles.Size = New System.Drawing.Size(281, 53)
        Me.B_GenerateInfoFiles.TabIndex = 3
        Me.B_GenerateInfoFiles.Text = "Generate all Info files"
        Me.B_GenerateInfoFiles.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(82, 58)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(248, 77)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(82, 175)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(248, 79)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'T_Search1
        '
        Me.T_Search1.Location = New System.Drawing.Point(358, 175)
        Me.T_Search1.Name = "T_Search1"
        Me.T_Search1.Size = New System.Drawing.Size(261, 31)
        Me.T_Search1.TabIndex = 6
        Me.T_Search1.Text = "Name, ISISN, WKN"
        '
        'T_Info1
        '
        Me.T_Info1.Location = New System.Drawing.Point(358, 212)
        Me.T_Info1.Name = "T_Info1"
        Me.T_Info1.Size = New System.Drawing.Size(261, 31)
        Me.T_Info1.TabIndex = 7
        '
        'T_Info2
        '
        Me.T_Info2.Location = New System.Drawing.Point(358, 249)
        Me.T_Info2.Name = "T_Info2"
        Me.T_Info2.Size = New System.Drawing.Size(261, 31)
        Me.T_Info2.TabIndex = 8
        '
        'T_Info3
        '
        Me.T_Info3.Location = New System.Drawing.Point(358, 286)
        Me.T_Info3.Name = "T_Info3"
        Me.T_Info3.Size = New System.Drawing.Size(261, 31)
        Me.T_Info3.TabIndex = 9
        '
        'FrmInfoFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1149, 627)
        Me.Controls.Add(Me.T_Info3)
        Me.Controls.Add(Me.T_Info2)
        Me.Controls.Add(Me.T_Info1)
        Me.Controls.Add(Me.T_Search1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmInfoFiles"
        Me.Text = "InfoFiles"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents T_Search As TextBox
    Friend WithEvents B_GenerateSingleInfoFiles As Button
    Friend WithEvents B_GenerateInfoFiles As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents T_Search1 As TextBox
    Friend WithEvents T_Info1 As TextBox
    Friend WithEvents T_Info2 As TextBox
    Friend WithEvents T_Info3 As TextBox
End Class
