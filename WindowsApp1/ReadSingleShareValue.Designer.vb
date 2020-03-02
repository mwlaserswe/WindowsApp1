<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadSingleShareValue
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
        Me.ReadPeketec = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.T_WKN = New System.Windows.Forms.TextBox()
        Me.L_ISIN = New System.Windows.Forms.TextBox()
        Me.L_WKN = New System.Windows.Forms.TextBox()
        Me.L_SharePrice = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ReadAriva = New System.Windows.Forms.Button()
        Me.ReadBoerseStuttgart = New System.Windows.Forms.Button()
        Me.ReadComdirect = New System.Windows.Forms.Button()
        Me.ReadFinanzNachrichten = New System.Windows.Forms.Button()
        Me.ReadIng = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(38, 538)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 31)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ReadPeketec
        '
        Me.ReadPeketec.Location = New System.Drawing.Point(36, 88)
        Me.ReadPeketec.Name = "ReadPeketec"
        Me.ReadPeketec.Size = New System.Drawing.Size(232, 42)
        Me.ReadPeketec.TabIndex = 1
        Me.ReadPeketec.Text = "Read Peketec"
        Me.ReadPeketec.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(639, 585)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(55, 31)
        Me.TextBox1.TabIndex = 2
        '
        'T_WKN
        '
        Me.T_WKN.Location = New System.Drawing.Point(117, 30)
        Me.T_WKN.Name = "T_WKN"
        Me.T_WKN.Size = New System.Drawing.Size(94, 31)
        Me.T_WKN.TabIndex = 3
        Me.T_WKN.Text = "578560"
        '
        'L_ISIN
        '
        Me.L_ISIN.Location = New System.Drawing.Point(628, 166)
        Me.L_ISIN.Name = "L_ISIN"
        Me.L_ISIN.Size = New System.Drawing.Size(130, 31)
        Me.L_ISIN.TabIndex = 4
        '
        'L_WKN
        '
        Me.L_WKN.Location = New System.Drawing.Point(628, 106)
        Me.L_WKN.Name = "L_WKN"
        Me.L_WKN.Size = New System.Drawing.Size(130, 31)
        Me.L_WKN.TabIndex = 5
        '
        'L_SharePrice
        '
        Me.L_SharePrice.Location = New System.Drawing.Point(628, 50)
        Me.L_SharePrice.Name = "L_SharePrice"
        Me.L_SharePrice.Size = New System.Drawing.Size(130, 31)
        Me.L_SharePrice.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(464, 169)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 25)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "ISIN:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(464, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 25)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "WKN:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(464, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 25)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Aktueller Kurs:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 25)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "WKN:"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(166, 538)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(152, 31)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(137, 585)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(454, 31)
        Me.TextBox2.TabIndex = 13
        Me.TextBox2.Text = "Hello World"
        '
        'ReadAriva
        '
        Me.ReadAriva.Location = New System.Drawing.Point(36, 146)
        Me.ReadAriva.Name = "ReadAriva"
        Me.ReadAriva.Size = New System.Drawing.Size(232, 42)
        Me.ReadAriva.TabIndex = 14
        Me.ReadAriva.Text = "Read Ariva"
        Me.ReadAriva.UseVisualStyleBackColor = True
        '
        'ReadBoerseStuttgart
        '
        Me.ReadBoerseStuttgart.Location = New System.Drawing.Point(36, 205)
        Me.ReadBoerseStuttgart.Name = "ReadBoerseStuttgart"
        Me.ReadBoerseStuttgart.Size = New System.Drawing.Size(232, 42)
        Me.ReadBoerseStuttgart.TabIndex = 15
        Me.ReadBoerseStuttgart.Text = "Read Börse Stuttg."
        Me.ReadBoerseStuttgart.UseVisualStyleBackColor = True
        '
        'ReadComdirect
        '
        Me.ReadComdirect.Location = New System.Drawing.Point(36, 266)
        Me.ReadComdirect.Name = "ReadComdirect"
        Me.ReadComdirect.Size = New System.Drawing.Size(232, 42)
        Me.ReadComdirect.TabIndex = 16
        Me.ReadComdirect.Text = "Read Comdirect"
        Me.ReadComdirect.UseVisualStyleBackColor = True
        '
        'ReadFinanzNachrichten
        '
        Me.ReadFinanzNachrichten.Location = New System.Drawing.Point(36, 326)
        Me.ReadFinanzNachrichten.Name = "ReadFinanzNachrichten"
        Me.ReadFinanzNachrichten.Size = New System.Drawing.Size(232, 42)
        Me.ReadFinanzNachrichten.TabIndex = 17
        Me.ReadFinanzNachrichten.Text = "Read FinanzNachr."
        Me.ReadFinanzNachrichten.UseVisualStyleBackColor = True
        '
        'ReadIng
        '
        Me.ReadIng.Location = New System.Drawing.Point(36, 386)
        Me.ReadIng.Name = "ReadIng"
        Me.ReadIng.Size = New System.Drawing.Size(232, 42)
        Me.ReadIng.TabIndex = 18
        Me.ReadIng.Text = "Read Ing"
        Me.ReadIng.UseVisualStyleBackColor = True
        '
        'ReadSingleShareValue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 647)
        Me.Controls.Add(Me.ReadIng)
        Me.Controls.Add(Me.ReadFinanzNachrichten)
        Me.Controls.Add(Me.ReadComdirect)
        Me.Controls.Add(Me.ReadBoerseStuttgart)
        Me.Controls.Add(Me.ReadAriva)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.L_SharePrice)
        Me.Controls.Add(Me.L_WKN)
        Me.Controls.Add(Me.L_ISIN)
        Me.Controls.Add(Me.T_WKN)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ReadPeketec)
        Me.Controls.Add(Me.Button1)
        Me.Name = "ReadSingleShareValue"
        Me.Text = "Form3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents ReadPeketec As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents T_WKN As TextBox
    Friend WithEvents L_ISIN As TextBox
    Friend WithEvents L_WKN As TextBox
    Friend WithEvents L_SharePrice As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ReadAriva As Button
    Friend WithEvents ReadBoerseStuttgart As Button
    Friend WithEvents ReadComdirect As Button
    Friend WithEvents ReadFinanzNachrichten As Button
    Friend WithEvents ReadIng As Button
End Class
