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
        Me.B_GenerateInfoFiles = New System.Windows.Forms.Button()
        Me.B_GenerateSingleInfoFiles = New System.Windows.Forms.Button()
        Me.T_Search = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'B_GenerateInfoFiles
        '
        Me.B_GenerateInfoFiles.Location = New System.Drawing.Point(728, 67)
        Me.B_GenerateInfoFiles.Name = "B_GenerateInfoFiles"
        Me.B_GenerateInfoFiles.Size = New System.Drawing.Size(281, 53)
        Me.B_GenerateInfoFiles.TabIndex = 0
        Me.B_GenerateInfoFiles.Text = "Generate all Info files"
        Me.B_GenerateInfoFiles.UseVisualStyleBackColor = True
        '
        'B_GenerateSingleInfoFiles
        '
        Me.B_GenerateSingleInfoFiles.Location = New System.Drawing.Point(64, 67)
        Me.B_GenerateSingleInfoFiles.Name = "B_GenerateSingleInfoFiles"
        Me.B_GenerateSingleInfoFiles.Size = New System.Drawing.Size(261, 53)
        Me.B_GenerateSingleInfoFiles.TabIndex = 1
        Me.B_GenerateSingleInfoFiles.Text = "Generate single info file"
        Me.B_GenerateSingleInfoFiles.UseVisualStyleBackColor = True
        '
        'T_Search
        '
        Me.T_Search.Location = New System.Drawing.Point(64, 152)
        Me.T_Search.Name = "T_Search"
        Me.T_Search.Size = New System.Drawing.Size(261, 31)
        Me.T_Search.TabIndex = 2
        Me.T_Search.Text = "Name, ISISN, WKN"
        '
        'FrmInfoFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1149, 627)
        Me.Controls.Add(Me.T_Search)
        Me.Controls.Add(Me.B_GenerateSingleInfoFiles)
        Me.Controls.Add(Me.B_GenerateInfoFiles)
        Me.Name = "FrmInfoFiles"
        Me.Text = "InfoFiles"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents B_GenerateInfoFiles As Button
    Friend WithEvents B_GenerateSingleInfoFiles As Button
    Friend WithEvents T_Search As TextBox
End Class
