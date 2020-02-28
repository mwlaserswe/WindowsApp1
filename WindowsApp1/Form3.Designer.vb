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
        Me.components = New System.ComponentModel.Container()
        Me.C_ReadAllShares = New System.Windows.Forms.Button()
        Me.C_ReadSingleShare = New System.Windows.Forms.Button()
        Me.T_Search = New System.Windows.Forms.TextBox()
        Me.L_Name = New System.Windows.Forms.TextBox()
        Me.L_SharePrice = New System.Windows.Forms.TextBox()
        Me.L_WKN = New System.Windows.Forms.TextBox()
        Me.L_ISIN = New System.Windows.Forms.TextBox()
        Me.L_WebPage = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'C_ReadAllShares
        '
        Me.C_ReadAllShares.Location = New System.Drawing.Point(48, 24)
        Me.C_ReadAllShares.Name = "C_ReadAllShares"
        Me.C_ReadAllShares.Size = New System.Drawing.Size(539, 134)
        Me.C_ReadAllShares.TabIndex = 0
        Me.C_ReadAllShares.Text = "Read all shares"
        Me.C_ReadAllShares.UseVisualStyleBackColor = True
        '
        'C_ReadSingleShare
        '
        Me.C_ReadSingleShare.Location = New System.Drawing.Point(48, 285)
        Me.C_ReadSingleShare.Name = "C_ReadSingleShare"
        Me.C_ReadSingleShare.Size = New System.Drawing.Size(142, 73)
        Me.C_ReadSingleShare.TabIndex = 1
        Me.C_ReadSingleShare.Text = "    Read      single share"
        Me.C_ReadSingleShare.UseVisualStyleBackColor = True
        '
        'T_Search
        '
        Me.T_Search.Location = New System.Drawing.Point(230, 285)
        Me.T_Search.Name = "T_Search"
        Me.T_Search.Size = New System.Drawing.Size(357, 31)
        Me.T_Search.TabIndex = 2
        Me.T_Search.Text = "Name, ISISN, WKN"
        '
        'L_Name
        '
        Me.L_Name.Location = New System.Drawing.Point(345, 367)
        Me.L_Name.Name = "L_Name"
        Me.L_Name.Size = New System.Drawing.Size(242, 31)
        Me.L_Name.TabIndex = 3
        '
        'L_SharePrice
        '
        Me.L_SharePrice.Location = New System.Drawing.Point(345, 409)
        Me.L_SharePrice.Name = "L_SharePrice"
        Me.L_SharePrice.Size = New System.Drawing.Size(242, 31)
        Me.L_SharePrice.TabIndex = 4
        '
        'L_WKN
        '
        Me.L_WKN.Location = New System.Drawing.Point(345, 453)
        Me.L_WKN.Name = "L_WKN"
        Me.L_WKN.Size = New System.Drawing.Size(242, 31)
        Me.L_WKN.TabIndex = 5
        '
        'L_ISIN
        '
        Me.L_ISIN.Location = New System.Drawing.Point(345, 496)
        Me.L_ISIN.Name = "L_ISIN"
        Me.L_ISIN.Size = New System.Drawing.Size(242, 31)
        Me.L_ISIN.TabIndex = 6
        '
        'L_WebPage
        '
        Me.L_WebPage.Location = New System.Drawing.Point(48, 557)
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
        Me.ListBox1.Size = New System.Drawing.Size(489, 579)
        Me.ListBox1.TabIndex = 8
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 25
        Me.ListBox2.Location = New System.Drawing.Point(48, 617)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(1076, 204)
        Me.ListBox2.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(270, 499)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 25)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "ISIN:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(260, 456)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 25)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "WKN:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(175, 412)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 25)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Aktueller Kurs:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(253, 370)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 25)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Name:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ReadTodaysSharePrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1149, 845)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.L_WebPage)
        Me.Controls.Add(Me.L_ISIN)
        Me.Controls.Add(Me.L_WKN)
        Me.Controls.Add(Me.L_SharePrice)
        Me.Controls.Add(Me.L_Name)
        Me.Controls.Add(Me.T_Search)
        Me.Controls.Add(Me.C_ReadSingleShare)
        Me.Controls.Add(Me.C_ReadAllShares)
        Me.Name = "ReadTodaysSharePrice"
        Me.Text = "Form3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C_ReadAllShares As Button
    Friend WithEvents C_ReadSingleShare As Button
    Friend WithEvents T_Search As TextBox
    Friend WithEvents L_Name As TextBox
    Friend WithEvents L_SharePrice As TextBox
    Friend WithEvents L_WKN As TextBox
    Friend WithEvents L_ISIN As TextBox
    Friend WithEvents L_WebPage As TextBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Timer1 As Timer
End Class
