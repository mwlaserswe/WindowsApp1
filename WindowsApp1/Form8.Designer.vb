<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadHistoricFromAriva
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T_SecureCode = New System.Windows.Forms.TextBox()
        Me.T_HTML_Snippet = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_WKN = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Ch_1_Rd = New System.Windows.Forms.CheckBox()
        Me.Ch_2_Inv = New System.Windows.Forms.CheckBox()
        Me.Ch_4_Serv = New System.Windows.Forms.CheckBox()
        Me.B_ReadAllFiles = New System.Windows.Forms.Button()
        Me.Ch_0_Exist = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(62, 500)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 25)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Secure Code"
        '
        'T_SecureCode
        '
        Me.T_SecureCode.Location = New System.Drawing.Point(224, 497)
        Me.T_SecureCode.Name = "T_SecureCode"
        Me.T_SecureCode.Size = New System.Drawing.Size(100, 31)
        Me.T_SecureCode.TabIndex = 16
        '
        'T_HTML_Snippet
        '
        Me.T_HTML_Snippet.Location = New System.Drawing.Point(224, 434)
        Me.T_HTML_Snippet.Name = "T_HTML_Snippet"
        Me.T_HTML_Snippet.Size = New System.Drawing.Size(1145, 31)
        Me.T_HTML_Snippet.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(132, 296)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 25)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "WKN:"
        '
        'T_WKN
        '
        Me.T_WKN.Location = New System.Drawing.Point(224, 290)
        Me.T_WKN.Name = "T_WKN"
        Me.T_WKN.Size = New System.Drawing.Size(133, 31)
        Me.T_WKN.TabIndex = 13
        Me.T_WKN.Text = "623100"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(224, 365)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(979, 47)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Read single historic file from ARIVA.DE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Ch_1_Rd
        '
        Me.Ch_1_Rd.AutoSize = True
        Me.Ch_1_Rd.Location = New System.Drawing.Point(78, 82)
        Me.Ch_1_Rd.Name = "Ch_1_Rd"
        Me.Ch_1_Rd.Size = New System.Drawing.Size(728, 29)
        Me.Ch_1_Rd.TabIndex = 18
        Me.Ch_1_Rd.Text = "Download from ARIVA.de and save to ""\History_download_from_ARIVA"""
        Me.Ch_1_Rd.UseVisualStyleBackColor = True
        '
        'Ch_2_Inv
        '
        Me.Ch_2_Inv.AutoSize = True
        Me.Ch_2_Inv.Location = New System.Drawing.Point(78, 117)
        Me.Ch_2_Inv.Name = "Ch_2_Inv"
        Me.Ch_2_Inv.Size = New System.Drawing.Size(539, 29)
        Me.Ch_2_Inv.TabIndex = 19
        Me.Ch_2_Inv.Text = "Invert order if nescessary and save to ""\HistoryNew"""
        Me.Ch_2_Inv.UseVisualStyleBackColor = True
        '
        'Ch_4_Serv
        '
        Me.Ch_4_Serv.AutoSize = True
        Me.Ch_4_Serv.Location = New System.Drawing.Point(78, 152)
        Me.Ch_4_Serv.Name = "Ch_4_Serv"
        Me.Ch_4_Serv.Size = New System.Drawing.Size(411, 29)
        Me.Ch_4_Serv.TabIndex = 21
        Me.Ch_4_Serv.Text = "Service files. Save to ""\HistoryService"""
        Me.Ch_4_Serv.UseVisualStyleBackColor = True
        '
        'B_ReadAllFiles
        '
        Me.B_ReadAllFiles.Location = New System.Drawing.Point(78, 222)
        Me.B_ReadAllFiles.Name = "B_ReadAllFiles"
        Me.B_ReadAllFiles.Size = New System.Drawing.Size(979, 47)
        Me.B_ReadAllFiles.TabIndex = 22
        Me.B_ReadAllFiles.Text = "Read all historic files from ARIVA.DE"
        Me.B_ReadAllFiles.UseVisualStyleBackColor = True
        '
        'Ch_0_Exist
        '
        Me.Ch_0_Exist.AutoSize = True
        Me.Ch_0_Exist.Location = New System.Drawing.Point(78, 47)
        Me.Ch_0_Exist.Name = "Ch_0_Exist"
        Me.Ch_0_Exist.Size = New System.Drawing.Size(316, 29)
        Me.Ch_0_Exist.TabIndex = 23
        Me.Ch_0_Exist.Text = "Don't download existing files"
        Me.Ch_0_Exist.UseVisualStyleBackColor = True
        '
        'ReadHistoricFromAriva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1486, 848)
        Me.Controls.Add(Me.Ch_0_Exist)
        Me.Controls.Add(Me.B_ReadAllFiles)
        Me.Controls.Add(Me.Ch_4_Serv)
        Me.Controls.Add(Me.Ch_2_Inv)
        Me.Controls.Add(Me.Ch_1_Rd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_SecureCode)
        Me.Controls.Add(Me.T_HTML_Snippet)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.T_WKN)
        Me.Controls.Add(Me.Button2)
        Me.Name = "ReadHistoricFromAriva"
        Me.Text = "Form8"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents T_SecureCode As TextBox
    Friend WithEvents T_HTML_Snippet As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents T_WKN As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Ch_1_Rd As CheckBox
    Friend WithEvents Ch_2_Inv As CheckBox
    Friend WithEvents Ch_4_Serv As CheckBox
    Friend WithEvents B_ReadAllFiles As Button
    Friend WithEvents Ch_0_Exist As CheckBox
End Class
