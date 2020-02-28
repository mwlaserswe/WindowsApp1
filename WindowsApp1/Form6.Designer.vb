<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SaveWebpageAsHTML
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.T_URL = New System.Windows.Forms.TextBox()
        Me.C_SavePageToFile = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.T_WKN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_HTML_Snippet = New System.Windows.Forms.TextBox()
        Me.T_SecureCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(49, 64)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(558, 31)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = " Save Web page to ""HTML-Code.HTML"""
        '
        'T_URL
        '
        Me.T_URL.Location = New System.Drawing.Point(49, 154)
        Me.T_URL.Name = "T_URL"
        Me.T_URL.Size = New System.Drawing.Size(1249, 31)
        Me.T_URL.TabIndex = 1
        Me.T_URL.Text = "https://www.ariva.de/bmw-aktie/historische_kurse"
        '
        'C_SavePageToFile
        '
        Me.C_SavePageToFile.Location = New System.Drawing.Point(738, 43)
        Me.C_SavePageToFile.Name = "C_SavePageToFile"
        Me.C_SavePageToFile.Size = New System.Drawing.Size(199, 72)
        Me.C_SavePageToFile.TabIndex = 2
        Me.C_SavePageToFile.Text = "Save Page To File"
        Me.C_SavePageToFile.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1059, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(239, 72)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Show file in Notepad++"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(229, 359)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(979, 47)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Read historic from ARIVA.DE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(0, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'T_WKN
        '
        Me.T_WKN.Location = New System.Drawing.Point(229, 284)
        Me.T_WKN.Name = "T_WKN"
        Me.T_WKN.Size = New System.Drawing.Size(133, 31)
        Me.T_WKN.TabIndex = 6
        Me.T_WKN.Text = "623100"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(137, 290)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "WKN:"
        '
        'T_HTML_Snippet
        '
        Me.T_HTML_Snippet.Location = New System.Drawing.Point(229, 428)
        Me.T_HTML_Snippet.Name = "T_HTML_Snippet"
        Me.T_HTML_Snippet.Size = New System.Drawing.Size(1145, 31)
        Me.T_HTML_Snippet.TabIndex = 8
        '
        'T_SecureCode
        '
        Me.T_SecureCode.Location = New System.Drawing.Point(229, 491)
        Me.T_SecureCode.Name = "T_SecureCode"
        Me.T_SecureCode.Size = New System.Drawing.Size(100, 31)
        Me.T_SecureCode.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(67, 494)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 25)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Secure Code"
        '
        'SaveWebpageAsHTML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1495, 1010)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_SecureCode)
        Me.Controls.Add(Me.T_HTML_Snippet)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.T_WKN)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.C_SavePageToFile)
        Me.Controls.Add(Me.T_URL)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "SaveWebpageAsHTML"
        Me.Text = "Form6"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents T_URL As TextBox
    Friend WithEvents C_SavePageToFile As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents T_WKN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents T_HTML_Snippet As TextBox
    Friend WithEvents T_SecureCode As TextBox
    Friend WithEvents Label2 As Label
End Class
