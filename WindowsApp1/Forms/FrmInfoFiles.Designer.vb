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
        Me.SuspendLayout()
        '
        'B_GenerateInfoFiles
        '
        Me.B_GenerateInfoFiles.Location = New System.Drawing.Point(45, 57)
        Me.B_GenerateInfoFiles.Name = "B_GenerateInfoFiles"
        Me.B_GenerateInfoFiles.Size = New System.Drawing.Size(281, 53)
        Me.B_GenerateInfoFiles.TabIndex = 0
        Me.B_GenerateInfoFiles.Text = "Generate new Info Files"
        Me.B_GenerateInfoFiles.UseVisualStyleBackColor = True
        '
        'FrmInfoFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1149, 627)
        Me.Controls.Add(Me.B_GenerateInfoFiles)
        Me.Name = "FrmInfoFiles"
        Me.Text = "InfoFiles"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents B_GenerateInfoFiles As Button
End Class
