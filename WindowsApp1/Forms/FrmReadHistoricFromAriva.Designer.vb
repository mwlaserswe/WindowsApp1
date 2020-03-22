<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReadHistoricFromAriva
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_WKN = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Ch_1_Rd = New System.Windows.Forms.CheckBox()
        Me.Ch_2_Inv = New System.Windows.Forms.CheckBox()
        Me.Ch_4_Serv = New System.Windows.Forms.CheckBox()
        Me.B_ReadAllFiles = New System.Windows.Forms.Button()
        Me.Ch_0_Exist = New System.Windows.Forms.CheckBox()
        Me.B_ReadFile = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.B_CompleteCompanyWKNISIN = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 1145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 25)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Secure Code"
        '
        'T_SecureCode
        '
        Me.T_SecureCode.Location = New System.Drawing.Point(187, 1142)
        Me.T_SecureCode.Name = "T_SecureCode"
        Me.T_SecureCode.Size = New System.Drawing.Size(117, 31)
        Me.T_SecureCode.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 1019)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 25)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "WKN:"
        '
        'T_WKN
        '
        Me.T_WKN.Location = New System.Drawing.Point(187, 1016)
        Me.T_WKN.Name = "T_WKN"
        Me.T_WKN.Size = New System.Drawing.Size(133, 31)
        Me.T_WKN.TabIndex = 13
        Me.T_WKN.Text = "623100"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(41, 1066)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(764, 40)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Read single historic file from ARIVA.DE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Ch_1_Rd
        '
        Me.Ch_1_Rd.AutoSize = True
        Me.Ch_1_Rd.Location = New System.Drawing.Point(41, 340)
        Me.Ch_1_Rd.Name = "Ch_1_Rd"
        Me.Ch_1_Rd.Size = New System.Drawing.Size(764, 29)
        Me.Ch_1_Rd.TabIndex = 18
        Me.Ch_1_Rd.Text = "Download from ARIVA.de and save to ""\01_History_download_from_ARIVA"""
        Me.Ch_1_Rd.UseVisualStyleBackColor = True
        '
        'Ch_2_Inv
        '
        Me.Ch_2_Inv.AutoSize = True
        Me.Ch_2_Inv.Location = New System.Drawing.Point(41, 375)
        Me.Ch_2_Inv.Name = "Ch_2_Inv"
        Me.Ch_2_Inv.Size = New System.Drawing.Size(575, 29)
        Me.Ch_2_Inv.TabIndex = 19
        Me.Ch_2_Inv.Text = "Invert order if nescessary and save to ""\02_HistoryNew"""
        Me.Ch_2_Inv.UseVisualStyleBackColor = True
        '
        'Ch_4_Serv
        '
        Me.Ch_4_Serv.AutoSize = True
        Me.Ch_4_Serv.Location = New System.Drawing.Point(41, 410)
        Me.Ch_4_Serv.Name = "Ch_4_Serv"
        Me.Ch_4_Serv.Size = New System.Drawing.Size(447, 29)
        Me.Ch_4_Serv.TabIndex = 21
        Me.Ch_4_Serv.Text = "Service files. Save to ""\03_HistoryService"""
        Me.Ch_4_Serv.UseVisualStyleBackColor = True
        '
        'B_ReadAllFiles
        '
        Me.B_ReadAllFiles.Location = New System.Drawing.Point(41, 856)
        Me.B_ReadAllFiles.Name = "B_ReadAllFiles"
        Me.B_ReadAllFiles.Size = New System.Drawing.Size(764, 40)
        Me.B_ReadAllFiles.TabIndex = 22
        Me.B_ReadAllFiles.Text = "Read all historic files from ARIVA.DE"
        Me.B_ReadAllFiles.UseVisualStyleBackColor = True
        '
        'Ch_0_Exist
        '
        Me.Ch_0_Exist.AutoSize = True
        Me.Ch_0_Exist.Location = New System.Drawing.Point(41, 305)
        Me.Ch_0_Exist.Name = "Ch_0_Exist"
        Me.Ch_0_Exist.Size = New System.Drawing.Size(316, 29)
        Me.Ch_0_Exist.TabIndex = 23
        Me.Ch_0_Exist.Text = "Don't download existing files"
        Me.Ch_0_Exist.UseVisualStyleBackColor = True
        '
        'B_ReadFile
        '
        Me.B_ReadFile.Location = New System.Drawing.Point(41, 459)
        Me.B_ReadFile.Name = "B_ReadFile"
        Me.B_ReadFile.Size = New System.Drawing.Size(764, 40)
        Me.B_ReadFile.TabIndex = 24
        Me.B_ReadFile.Text = "Read File ""ISIN-WKN-New.txt"""
        Me.B_ReadFile.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 25
        Me.ListBox1.Location = New System.Drawing.Point(41, 525)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(764, 304)
        Me.ListBox1.TabIndex = 25
        '
        'B_CompleteCompanyWKNISIN
        '
        Me.B_CompleteCompanyWKNISIN.Location = New System.Drawing.Point(41, 74)
        Me.B_CompleteCompanyWKNISIN.Name = "B_CompleteCompanyWKNISIN"
        Me.B_CompleteCompanyWKNISIN.Size = New System.Drawing.Size(764, 40)
        Me.B_CompleteCompanyWKNISIN.TabIndex = 26
        Me.B_CompleteCompanyWKNISIN.Text = "Complete Company, WKN, ISIN"
        Me.B_CompleteCompanyWKNISIN.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FrmReadHistoricFromAriva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1221, 1221)
        Me.Controls.Add(Me.B_CompleteCompanyWKNISIN)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.B_ReadFile)
        Me.Controls.Add(Me.Ch_0_Exist)
        Me.Controls.Add(Me.B_ReadAllFiles)
        Me.Controls.Add(Me.Ch_4_Serv)
        Me.Controls.Add(Me.Ch_2_Inv)
        Me.Controls.Add(Me.Ch_1_Rd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_SecureCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.T_WKN)
        Me.Controls.Add(Me.Button2)
        Me.Name = "FrmReadHistoricFromAriva"
        Me.Text = "Read Historic From Ariva"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents T_SecureCode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents T_WKN As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Ch_1_Rd As CheckBox
    Friend WithEvents Ch_2_Inv As CheckBox
    Friend WithEvents Ch_4_Serv As CheckBox
    Friend WithEvents B_ReadAllFiles As Button
    Friend WithEvents Ch_0_Exist As CheckBox
    Friend WithEvents B_ReadFile As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents B_CompleteCompanyWKNISIN As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
