<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFindBestSMA
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CB_SelectSmaMethod = New System.Windows.Forms.ComboBox()
        Me.B_FindBestSMASingle = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.B_DisplaySMA = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(25, 72)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(191, 79)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(25, 248)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(173, 73)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CB_SelectSmaMethod
        '
        Me.CB_SelectSmaMethod.FormattingEnabled = True
        Me.CB_SelectSmaMethod.Location = New System.Drawing.Point(536, 96)
        Me.CB_SelectSmaMethod.Name = "CB_SelectSmaMethod"
        Me.CB_SelectSmaMethod.Size = New System.Drawing.Size(293, 33)
        Me.CB_SelectSmaMethod.TabIndex = 59
        '
        'B_FindBestSMASingle
        '
        Me.B_FindBestSMASingle.Location = New System.Drawing.Point(536, 23)
        Me.B_FindBestSMASingle.Name = "B_FindBestSMASingle"
        Me.B_FindBestSMASingle.Size = New System.Drawing.Size(245, 47)
        Me.B_FindBestSMASingle.TabIndex = 58
        Me.B_FindBestSMASingle.Text = "Find best SMA single"
        Me.B_FindBestSMASingle.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(536, 169)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(500, 326)
        Me.PictureBox1.TabIndex = 60
        Me.PictureBox1.TabStop = False
        '
        'B_DisplaySMA
        '
        Me.B_DisplaySMA.Location = New System.Drawing.Point(270, 183)
        Me.B_DisplaySMA.Name = "B_DisplaySMA"
        Me.B_DisplaySMA.Size = New System.Drawing.Size(245, 73)
        Me.B_DisplaySMA.TabIndex = 61
        Me.B_DisplaySMA.Text = "Display SMA of current chart"
        Me.B_DisplaySMA.UseVisualStyleBackColor = True
        '
        'FrmFindBestSMA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1089, 533)
        Me.Controls.Add(Me.B_DisplaySMA)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CB_SelectSmaMethod)
        Me.Controls.Add(Me.B_FindBestSMASingle)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrmFindBestSMA"
        Me.Text = "Find Best SAM"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents CB_SelectSmaMethod As ComboBox
    Friend WithEvents B_FindBestSMASingle As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents B_DisplaySMA As Button
End Class
