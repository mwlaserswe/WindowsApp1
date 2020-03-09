<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChartList
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
        Me.ListCompelete = New System.Windows.Forms.ListBox()
        Me.ListPartial = New System.Windows.Forms.ListBox()
        Me.C_MoveToPartialList = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ListCompelete
        '
        Me.ListCompelete.FormattingEnabled = True
        Me.ListCompelete.ItemHeight = 25
        Me.ListCompelete.Location = New System.Drawing.Point(38, 41)
        Me.ListCompelete.Name = "ListCompelete"
        Me.ListCompelete.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListCompelete.Size = New System.Drawing.Size(299, 379)
        Me.ListCompelete.TabIndex = 0
        '
        'ListPartial
        '
        Me.ListPartial.FormattingEnabled = True
        Me.ListPartial.ItemHeight = 25
        Me.ListPartial.Location = New System.Drawing.Point(474, 41)
        Me.ListPartial.Name = "ListPartial"
        Me.ListPartial.Size = New System.Drawing.Size(291, 379)
        Me.ListPartial.TabIndex = 1
        '
        'C_MoveToPartialList
        '
        Me.C_MoveToPartialList.Location = New System.Drawing.Point(375, 124)
        Me.C_MoveToPartialList.Name = "C_MoveToPartialList"
        Me.C_MoveToPartialList.Size = New System.Drawing.Size(75, 43)
        Me.C_MoveToPartialList.TabIndex = 2
        Me.C_MoveToPartialList.Text = ">>>"
        Me.C_MoveToPartialList.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(350, 197)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 31)
        Me.TextBox1.TabIndex = 3
        '
        'ChartList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.C_MoveToPartialList)
        Me.Controls.Add(Me.ListPartial)
        Me.Controls.Add(Me.ListCompelete)
        Me.Name = "ChartList"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListCompelete As ListBox
    Friend WithEvents ListPartial As ListBox
    Friend WithEvents C_MoveToPartialList As Button
    Friend WithEvents TextBox1 As TextBox
End Class
