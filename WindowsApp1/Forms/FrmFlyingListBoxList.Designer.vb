<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFlyingListBoxList
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
        Me.B_OpenInNotepad = New System.Windows.Forms.Button()
        Me.L_FileName = New System.Windows.Forms.Label()
        Me.B_Save = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'B_OpenInNotepad
        '
        Me.B_OpenInNotepad.Location = New System.Drawing.Point(8, 10)
        Me.B_OpenInNotepad.Name = "B_OpenInNotepad"
        Me.B_OpenInNotepad.Size = New System.Drawing.Size(147, 58)
        Me.B_OpenInNotepad.TabIndex = 7
        Me.B_OpenInNotepad.Text = "Notepad++"
        Me.B_OpenInNotepad.UseVisualStyleBackColor = True
        '
        'L_FileName
        '
        Me.L_FileName.AutoSize = True
        Me.L_FileName.Location = New System.Drawing.Point(340, 27)
        Me.L_FileName.Name = "L_FileName"
        Me.L_FileName.Size = New System.Drawing.Size(26, 25)
        Me.L_FileName.TabIndex = 6
        Me.L_FileName.Text = "--"
        '
        'B_Save
        '
        Me.B_Save.Location = New System.Drawing.Point(171, 10)
        Me.B_Save.Name = "B_Save"
        Me.B_Save.Size = New System.Drawing.Size(147, 58)
        Me.B_Save.TabIndex = 5
        Me.B_Save.Text = "Save"
        Me.B_Save.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 25
        Me.ListBox1.Location = New System.Drawing.Point(6, 87)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(788, 354)
        Me.ListBox1.TabIndex = 4
        '
        'FrmFlyingListBoxList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.B_OpenInNotepad)
        Me.Controls.Add(Me.L_FileName)
        Me.Controls.Add(Me.B_Save)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "FrmFlyingListBoxList"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents B_OpenInNotepad As Button
    Friend WithEvents L_FileName As Label
    Friend WithEvents B_Save As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
