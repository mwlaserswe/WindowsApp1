<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadTodaysSharePrice
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
        Me.L_WebPage = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.L_ISIN = New System.Windows.Forms.TextBox()
        Me.L_WKN = New System.Windows.Forms.TextBox()
        Me.L_SharePrice = New System.Windows.Forms.TextBox()
        Me.L_Name = New System.Windows.Forms.TextBox()
        Me.T_Search = New System.Windows.Forms.TextBox()
        Me.C_ReadSingleShare = New System.Windows.Forms.Button()
        Me.T_S1 = New System.Windows.Forms.TextBox()
        Me.T_S2 = New System.Windows.Forms.TextBox()
        Me.T_S3 = New System.Windows.Forms.TextBox()
        Me.T_S4 = New System.Windows.Forms.TextBox()
        Me.T_S0 = New System.Windows.Forms.TextBox()
        Me.C_ReadAllShares = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'L_WebPage
        '
        Me.L_WebPage.Location = New System.Drawing.Point(48, 788)
        Me.L_WebPage.Name = "L_WebPage"
        Me.L_WebPage.Size = New System.Drawing.Size(539, 31)
        Me.L_WebPage.TabIndex = 7
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 25
        Me.ListBox1.Location = New System.Drawing.Point(635, 24)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(489, 804)
        Me.ListBox1.TabIndex = 8
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 25
        Me.ListBox2.Location = New System.Drawing.Point(48, 840)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(1076, 204)
        Me.ListBox2.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(76, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 25)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 254)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 25)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Akt. Kurs:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(83, 298)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 25)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "WKN:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(93, 341)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 25)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "ISIN:"
        '
        'L_ISIN
        '
        Me.L_ISIN.Location = New System.Drawing.Point(168, 338)
        Me.L_ISIN.Name = "L_ISIN"
        Me.L_ISIN.Size = New System.Drawing.Size(242, 31)
        Me.L_ISIN.TabIndex = 29
        '
        'L_WKN
        '
        Me.L_WKN.Location = New System.Drawing.Point(168, 295)
        Me.L_WKN.Name = "L_WKN"
        Me.L_WKN.Size = New System.Drawing.Size(242, 31)
        Me.L_WKN.TabIndex = 28
        '
        'L_SharePrice
        '
        Me.L_SharePrice.Location = New System.Drawing.Point(168, 251)
        Me.L_SharePrice.Name = "L_SharePrice"
        Me.L_SharePrice.Size = New System.Drawing.Size(242, 31)
        Me.L_SharePrice.TabIndex = 27
        '
        'L_Name
        '
        Me.L_Name.Location = New System.Drawing.Point(168, 209)
        Me.L_Name.Name = "L_Name"
        Me.L_Name.Size = New System.Drawing.Size(242, 31)
        Me.L_Name.TabIndex = 26
        '
        'T_Search
        '
        Me.T_Search.Location = New System.Drawing.Point(217, 668)
        Me.T_Search.Name = "T_Search"
        Me.T_Search.Size = New System.Drawing.Size(357, 31)
        Me.T_Search.TabIndex = 25
        Me.T_Search.Text = "Name, ISISN, WKN"
        '
        'C_ReadSingleShare
        '
        Me.C_ReadSingleShare.Location = New System.Drawing.Point(48, 637)
        Me.C_ReadSingleShare.Name = "C_ReadSingleShare"
        Me.C_ReadSingleShare.Size = New System.Drawing.Size(142, 73)
        Me.C_ReadSingleShare.TabIndex = 24
        Me.C_ReadSingleShare.Text = "    Read      single share"
        Me.C_ReadSingleShare.UseVisualStyleBackColor = True
        '
        'T_S1
        '
        Me.T_S1.Location = New System.Drawing.Point(512, 257)
        Me.T_S1.Name = "T_S1"
        Me.T_S1.Size = New System.Drawing.Size(75, 31)
        Me.T_S1.TabIndex = 34
        '
        'T_S2
        '
        Me.T_S2.Location = New System.Drawing.Point(512, 299)
        Me.T_S2.Name = "T_S2"
        Me.T_S2.Size = New System.Drawing.Size(75, 31)
        Me.T_S2.TabIndex = 35
        '
        'T_S3
        '
        Me.T_S3.Location = New System.Drawing.Point(512, 343)
        Me.T_S3.Name = "T_S3"
        Me.T_S3.Size = New System.Drawing.Size(75, 31)
        Me.T_S3.TabIndex = 36
        '
        'T_S4
        '
        Me.T_S4.Location = New System.Drawing.Point(512, 386)
        Me.T_S4.Name = "T_S4"
        Me.T_S4.Size = New System.Drawing.Size(75, 31)
        Me.T_S4.TabIndex = 37
        '
        'T_S0
        '
        Me.T_S0.Location = New System.Drawing.Point(512, 209)
        Me.T_S0.Name = "T_S0"
        Me.T_S0.Size = New System.Drawing.Size(75, 31)
        Me.T_S0.TabIndex = 40
        '
        'C_ReadAllShares
        '
        Me.C_ReadAllShares.Location = New System.Drawing.Point(48, 24)
        Me.C_ReadAllShares.Name = "C_ReadAllShares"
        Me.C_ReadAllShares.Size = New System.Drawing.Size(539, 136)
        Me.C_ReadAllShares.TabIndex = 41
        Me.C_ReadAllShares.Text = "Read all shares"
        Me.C_ReadAllShares.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(48, 457)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 41)
        Me.Button2.TabIndex = 42
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ReadTodaysSharePrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1138, 1079)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.C_ReadAllShares)
        Me.Controls.Add(Me.T_S0)
        Me.Controls.Add(Me.T_S4)
        Me.Controls.Add(Me.T_S3)
        Me.Controls.Add(Me.T_S2)
        Me.Controls.Add(Me.T_S1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.L_ISIN)
        Me.Controls.Add(Me.L_WKN)
        Me.Controls.Add(Me.L_SharePrice)
        Me.Controls.Add(Me.L_Name)
        Me.Controls.Add(Me.T_Search)
        Me.Controls.Add(Me.C_ReadSingleShare)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.L_WebPage)
        Me.Name = "ReadTodaysSharePrice"
        Me.Text = "Form3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents L_WebPage As TextBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents L_ISIN As TextBox
    Friend WithEvents L_WKN As TextBox
    Friend WithEvents L_SharePrice As TextBox
    Friend WithEvents L_Name As TextBox
    Friend WithEvents T_Search As TextBox
    Friend WithEvents C_ReadSingleShare As Button
    Friend WithEvents T_S1 As TextBox
    Friend WithEvents T_S2 As TextBox
    Friend WithEvents T_S3 As TextBox
    Friend WithEvents T_S4 As TextBox
    Friend WithEvents T_S0 As TextBox
    Friend WithEvents C_ReadAllShares As Button
    Friend WithEvents Button2 As Button
End Class
