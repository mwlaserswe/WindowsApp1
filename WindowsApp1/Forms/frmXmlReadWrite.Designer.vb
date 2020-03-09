<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXmlReadWrite
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.B_AppendXML = New System.Windows.Forms.Button()
        Me.B_ReadXML = New System.Windows.Forms.Button()
        Me.B_WriteXML = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.L_WKN = New System.Windows.Forms.TextBox()
        Me.L_ISIN = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 25
        Me.ListBox1.Location = New System.Drawing.Point(212, 274)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(487, 704)
        Me.ListBox1.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(55, 750)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 72)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Read XML"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(55, 847)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(121, 89)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Write XML"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'B_AppendXML
        '
        Me.B_AppendXML.Location = New System.Drawing.Point(12, 180)
        Me.B_AppendXML.Name = "B_AppendXML"
        Me.B_AppendXML.Size = New System.Drawing.Size(186, 62)
        Me.B_AppendXML.TabIndex = 24
        Me.B_AppendXML.Text = "Append XML"
        Me.B_AppendXML.UseVisualStyleBackColor = True
        '
        'B_ReadXML
        '
        Me.B_ReadXML.Location = New System.Drawing.Point(12, 103)
        Me.B_ReadXML.Name = "B_ReadXML"
        Me.B_ReadXML.Size = New System.Drawing.Size(186, 62)
        Me.B_ReadXML.TabIndex = 23
        Me.B_ReadXML.Text = "Read XML"
        Me.B_ReadXML.UseVisualStyleBackColor = True
        '
        'B_WriteXML
        '
        Me.B_WriteXML.Location = New System.Drawing.Point(12, 33)
        Me.B_WriteXML.Name = "B_WriteXML"
        Me.B_WriteXML.Size = New System.Drawing.Size(186, 54)
        Me.B_WriteXML.TabIndex = 22
        Me.B_WriteXML.Text = "Write XML"
        Me.B_WriteXML.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(239, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 25)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "WKN:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(239, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 25)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "ISIN:"
        '
        'L_WKN
        '
        Me.L_WKN.Location = New System.Drawing.Point(403, 45)
        Me.L_WKN.Name = "L_WKN"
        Me.L_WKN.Size = New System.Drawing.Size(130, 31)
        Me.L_WKN.TabIndex = 26
        Me.L_WKN.Text = "123456"
        '
        'L_ISIN
        '
        Me.L_ISIN.Location = New System.Drawing.Point(403, 79)
        Me.L_ISIN.Name = "L_ISIN"
        Me.L_ISIN.Size = New System.Drawing.Size(130, 31)
        Me.L_ISIN.TabIndex = 25
        Me.L_ISIN.Text = "MyIsin"
        '
        'frmXmlReadWrite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 999)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.L_WKN)
        Me.Controls.Add(Me.L_ISIN)
        Me.Controls.Add(Me.B_AppendXML)
        Me.Controls.Add(Me.B_ReadXML)
        Me.Controls.Add(Me.B_WriteXML)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmXmlReadWrite"
        Me.Text = "Xml Read/Write"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents B_AppendXML As Button
    Friend WithEvents B_ReadXML As Button
    Friend WithEvents B_WriteXML As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents L_WKN As TextBox
    Friend WithEvents L_ISIN As TextBox
End Class
