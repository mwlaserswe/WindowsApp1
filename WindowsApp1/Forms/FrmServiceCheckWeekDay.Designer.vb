<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmServiceCheckWeekDay
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
        Me.C_ServiceHistory = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.C_WeekdayDemo = New System.Windows.Forms.Button()
        Me.C_TageszahlInDatum = New System.Windows.Forms.Button()
        Me.T_DateOut = New System.Windows.Forms.TextBox()
        Me.T_DayNumber = New System.Windows.Forms.TextBox()
        Me.T_Weekday = New System.Windows.Forms.TextBox()
        Me.T_DatumIn = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'C_ServiceHistory
        '
        Me.C_ServiceHistory.Location = New System.Drawing.Point(21, 90)
        Me.C_ServiceHistory.Name = "C_ServiceHistory"
        Me.C_ServiceHistory.Size = New System.Drawing.Size(111, 90)
        Me.C_ServiceHistory.TabIndex = 0
        Me.C_ServiceHistory.Text = "Service History"
        Me.C_ServiceHistory.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(166, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(352, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "- falsches Datumsformat korrigieren"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(166, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(290, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "- fehlende Einträge ergänzen"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 25
        Me.ListBox1.Location = New System.Drawing.Point(539, 52)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(257, 404)
        Me.ListBox1.TabIndex = 3
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 25
        Me.ListBox2.Location = New System.Drawing.Point(819, 52)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(253, 404)
        Me.ListBox2.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.T_DatumIn)
        Me.GroupBox1.Controls.Add(Me.T_Weekday)
        Me.GroupBox1.Controls.Add(Me.T_DayNumber)
        Me.GroupBox1.Controls.Add(Me.T_DateOut)
        Me.GroupBox1.Controls.Add(Me.C_TageszahlInDatum)
        Me.GroupBox1.Controls.Add(Me.C_WeekdayDemo)
        Me.GroupBox1.Location = New System.Drawing.Point(58, 535)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(462, 296)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Demo"
        '
        'C_WeekdayDemo
        '
        Me.C_WeekdayDemo.Location = New System.Drawing.Point(19, 46)
        Me.C_WeekdayDemo.Name = "C_WeekdayDemo"
        Me.C_WeekdayDemo.Size = New System.Drawing.Size(125, 76)
        Me.C_WeekdayDemo.TabIndex = 0
        Me.C_WeekdayDemo.Text = "Weekday Demo"
        Me.C_WeekdayDemo.UseVisualStyleBackColor = True
        '
        'C_TageszahlInDatum
        '
        Me.C_TageszahlInDatum.Location = New System.Drawing.Point(19, 174)
        Me.C_TageszahlInDatum.Name = "C_TageszahlInDatum"
        Me.C_TageszahlInDatum.Size = New System.Drawing.Size(141, 88)
        Me.C_TageszahlInDatum.TabIndex = 7
        Me.C_TageszahlInDatum.Text = "Tageszahl ab 01.01.2000 in Datum"
        Me.C_TageszahlInDatum.UseVisualStyleBackColor = True
        '
        'T_DateOut
        '
        Me.T_DateOut.Location = New System.Drawing.Point(201, 231)
        Me.T_DateOut.Name = "T_DateOut"
        Me.T_DateOut.Size = New System.Drawing.Size(206, 31)
        Me.T_DateOut.TabIndex = 8
        '
        'T_DayNumber
        '
        Me.T_DayNumber.Location = New System.Drawing.Point(201, 174)
        Me.T_DayNumber.Name = "T_DayNumber"
        Me.T_DayNumber.Size = New System.Drawing.Size(100, 31)
        Me.T_DayNumber.TabIndex = 9
        Me.T_DayNumber.Text = "375"
        '
        'T_Weekday
        '
        Me.T_Weekday.Location = New System.Drawing.Point(369, 91)
        Me.T_Weekday.Name = "T_Weekday"
        Me.T_Weekday.Size = New System.Drawing.Size(49, 31)
        Me.T_Weekday.TabIndex = 10
        '
        'T_DatumIn
        '
        Me.T_DatumIn.Location = New System.Drawing.Point(201, 46)
        Me.T_DatumIn.Name = "T_DatumIn"
        Me.T_DatumIn.Size = New System.Drawing.Size(217, 31)
        Me.T_DatumIn.TabIndex = 11
        Me.T_DatumIn.Text = "22.02.2020"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(196, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(156, 25)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Wochentag-Nr."
        '
        'ServiceCheckWeekDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1150, 893)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.C_ServiceHistory)
        Me.Name = "ServiceCheckWeekDay"
        Me.Text = "Form4"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C_ServiceHistory As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents T_DatumIn As TextBox
    Friend WithEvents T_Weekday As TextBox
    Friend WithEvents T_DayNumber As TextBox
    Friend WithEvents T_DateOut As TextBox
    Friend WithEvents C_TageszahlInDatum As Button
    Friend WithEvents C_WeekdayDemo As Button
End Class
