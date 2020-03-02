<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.PicChart = New System.Windows.Forms.PictureBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GgggToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadFromWEBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadHistoricFromARIVAdeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScanWebForWKNToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveWebPageAsHTMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadSingleShareValueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadXMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridViewTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransformToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckWeekdayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.T_HistoryFileName = New System.Windows.Forms.TextBox()
        Me.RefreshDataGrid = New System.Windows.Forms.Button()
        Me.HS_SD = New System.Windows.Forms.HScrollBar()
        Me.T_SD = New System.Windows.Forms.TextBox()
        Me.T_InvestmentStart = New System.Windows.Forms.TextBox()
        Me.T_StartSharePrice = New System.Windows.Forms.TextBox()
        Me.T_MouseXY = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.T_SD1 = New System.Windows.Forms.TextBox()
        Me.T_Account = New System.Windows.Forms.TextBox()
        Me.T_Value = New System.Windows.Forms.TextBox()
        Me.T_CursorDate = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.T_X_Sc_Off = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.T_Current_Sc_Off = New System.Windows.Forms.TextBox()
        Me.T_MouseCenter = New System.Windows.Forms.TextBox()
        Me.C_HomeView = New System.Windows.Forms.Button()
        Me.C_LaserWeek = New System.Windows.Forms.Button()
        Me.C_LastMonth = New System.Windows.Forms.Button()
        Me.C_LastYear = New System.Windows.Forms.Button()
        Me.C_WriteChartFile = New System.Windows.Forms.Button()
        Me.C_BuySell = New System.Windows.Forms.Button()
        Me.Analyse1 = New System.Windows.Forms.RadioButton()
        Me.Analyse2 = New System.Windows.Forms.RadioButton()
        Me.Analyse3 = New System.Windows.Forms.RadioButton()
        Me.Analyse4 = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.C_Investhopping = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Ch_FitY = New System.Windows.Forms.CheckBox()
        CType(Me.PicChart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1700, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 25
        Me.ListBox1.Location = New System.Drawing.Point(1353, 18)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(226, 229)
        Me.ListBox1.TabIndex = 2
        '
        'PicChart
        '
        Me.PicChart.Location = New System.Drawing.Point(60, 395)
        Me.PicChart.Name = "PicChart"
        Me.PicChart.Size = New System.Drawing.Size(1584, 356)
        Me.PicChart.TabIndex = 3
        Me.PicChart.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(32, 53)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 82
        Me.DataGridView1.RowTemplate.Height = 33
        Me.DataGridView1.Size = New System.Drawing.Size(894, 293)
        Me.DataGridView1.TabIndex = 4
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem, Me.GgggToolStripMenuItem, Me.ToolStripMenuItem1, Me.ReadFromWEBToolStripMenuItem, Me.WebToolStripMenuItem, Me.ServiceToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1848, 48)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(176, 44)
        Me.MenuToolStripMenuItem.Text = "Display Chart"
        '
        'GgggToolStripMenuItem
        '
        Me.GgggToolStripMenuItem.Name = "GgggToolStripMenuItem"
        Me.GgggToolStripMenuItem.Size = New System.Drawing.Size(134, 44)
        Me.GgggToolStripMenuItem.Text = "Chart List"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(271, 44)
        Me.ToolStripMenuItem1.Text = "ReadTodaysSharePrice"
        '
        'ReadFromWEBToolStripMenuItem
        '
        Me.ReadFromWEBToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReadHistoricFromARIVAdeToolStripMenuItem})
        Me.ReadFromWEBToolStripMenuItem.Name = "ReadFromWEBToolStripMenuItem"
        Me.ReadFromWEBToolStripMenuItem.Size = New System.Drawing.Size(200, 44)
        Me.ReadFromWEBToolStripMenuItem.Text = "Read from WEB"
        '
        'ReadHistoricFromARIVAdeToolStripMenuItem
        '
        Me.ReadHistoricFromARIVAdeToolStripMenuItem.Name = "ReadHistoricFromARIVAdeToolStripMenuItem"
        Me.ReadHistoricFromARIVAdeToolStripMenuItem.Size = New System.Drawing.Size(446, 44)
        Me.ReadHistoricFromARIVAdeToolStripMenuItem.Text = "Read historic from ARIVA.de"
        '
        'WebToolStripMenuItem
        '
        Me.WebToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScanWebForWKNToolStripMenuItem, Me.SaveWebPageAsHTMLToolStripMenuItem, Me.ReadSingleShareValueToolStripMenuItem, Me.ReadXMLToolStripMenuItem, Me.GridViewTestToolStripMenuItem, Me.TransformToolStripMenuItem})
        Me.WebToolStripMenuItem.Name = "WebToolStripMenuItem"
        Me.WebToolStripMenuItem.Size = New System.Drawing.Size(148, 44)
        Me.WebToolStripMenuItem.Text = "Web / Test"
        '
        'ScanWebForWKNToolStripMenuItem
        '
        Me.ScanWebForWKNToolStripMenuItem.Name = "ScanWebForWKNToolStripMenuItem"
        Me.ScanWebForWKNToolStripMenuItem.Size = New System.Drawing.Size(413, 44)
        Me.ScanWebForWKNToolStripMenuItem.Text = "Scan Web for WKN"
        '
        'SaveWebPageAsHTMLToolStripMenuItem
        '
        Me.SaveWebPageAsHTMLToolStripMenuItem.Name = "SaveWebPageAsHTMLToolStripMenuItem"
        Me.SaveWebPageAsHTMLToolStripMenuItem.Size = New System.Drawing.Size(413, 44)
        Me.SaveWebPageAsHTMLToolStripMenuItem.Text = "Save Web page as HTML"
        '
        'ReadSingleShareValueToolStripMenuItem
        '
        Me.ReadSingleShareValueToolStripMenuItem.Name = "ReadSingleShareValueToolStripMenuItem"
        Me.ReadSingleShareValueToolStripMenuItem.Size = New System.Drawing.Size(413, 44)
        Me.ReadSingleShareValueToolStripMenuItem.Text = "Read single share value"
        '
        'ReadXMLToolStripMenuItem
        '
        Me.ReadXMLToolStripMenuItem.Name = "ReadXMLToolStripMenuItem"
        Me.ReadXMLToolStripMenuItem.Size = New System.Drawing.Size(413, 44)
        Me.ReadXMLToolStripMenuItem.Text = "Read XML"
        '
        'GridViewTestToolStripMenuItem
        '
        Me.GridViewTestToolStripMenuItem.Name = "GridViewTestToolStripMenuItem"
        Me.GridViewTestToolStripMenuItem.Size = New System.Drawing.Size(413, 44)
        Me.GridViewTestToolStripMenuItem.Text = "GridView Test"
        '
        'TransformToolStripMenuItem
        '
        Me.TransformToolStripMenuItem.Name = "TransformToolStripMenuItem"
        Me.TransformToolStripMenuItem.Size = New System.Drawing.Size(413, 44)
        Me.TransformToolStripMenuItem.Text = "Transform PictureBox"
        '
        'ServiceToolStripMenuItem
        '
        Me.ServiceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckWeekdayToolStripMenuItem})
        Me.ServiceToolStripMenuItem.Name = "ServiceToolStripMenuItem"
        Me.ServiceToolStripMenuItem.Size = New System.Drawing.Size(111, 44)
        Me.ServiceToolStripMenuItem.Text = "Service"
        '
        'CheckWeekdayToolStripMenuItem
        '
        Me.CheckWeekdayToolStripMenuItem.Name = "CheckWeekdayToolStripMenuItem"
        Me.CheckWeekdayToolStripMenuItem.Size = New System.Drawing.Size(318, 44)
        Me.CheckWeekdayToolStripMenuItem.Text = "Check Weekday"
        '
        'T_HistoryFileName
        '
        Me.T_HistoryFileName.Location = New System.Drawing.Point(32, 352)
        Me.T_HistoryFileName.Name = "T_HistoryFileName"
        Me.T_HistoryFileName.Size = New System.Drawing.Size(894, 31)
        Me.T_HistoryFileName.TabIndex = 9
        '
        'RefreshDataGrid
        '
        Me.RefreshDataGrid.Location = New System.Drawing.Point(943, 53)
        Me.RefreshDataGrid.Name = "RefreshDataGrid"
        Me.RefreshDataGrid.Size = New System.Drawing.Size(111, 39)
        Me.RefreshDataGrid.TabIndex = 11
        Me.RefreshDataGrid.Text = "Refresh"
        Me.RefreshDataGrid.UseVisualStyleBackColor = True
        '
        'HS_SD
        '
        Me.HS_SD.Location = New System.Drawing.Point(32, 821)
        Me.HS_SD.Maximum = 300
        Me.HS_SD.Minimum = 1
        Me.HS_SD.Name = "HS_SD"
        Me.HS_SD.Size = New System.Drawing.Size(434, 34)
        Me.HS_SD.TabIndex = 12
        Me.HS_SD.Value = 1
        '
        'T_SD
        '
        Me.T_SD.Location = New System.Drawing.Point(530, 821)
        Me.T_SD.Name = "T_SD"
        Me.T_SD.Size = New System.Drawing.Size(100, 31)
        Me.T_SD.TabIndex = 13
        '
        'T_InvestmentStart
        '
        Me.T_InvestmentStart.Location = New System.Drawing.Point(863, 821)
        Me.T_InvestmentStart.Name = "T_InvestmentStart"
        Me.T_InvestmentStart.Size = New System.Drawing.Size(100, 31)
        Me.T_InvestmentStart.TabIndex = 14
        Me.T_InvestmentStart.Text = "200"
        '
        'T_StartSharePrice
        '
        Me.T_StartSharePrice.Location = New System.Drawing.Point(1221, 821)
        Me.T_StartSharePrice.Name = "T_StartSharePrice"
        Me.T_StartSharePrice.Size = New System.Drawing.Size(100, 31)
        Me.T_StartSharePrice.TabIndex = 15
        Me.T_StartSharePrice.Text = "10"
        '
        'T_MouseXY
        '
        Me.T_MouseXY.Location = New System.Drawing.Point(32, 760)
        Me.T_MouseXY.Name = "T_MouseXY"
        Me.T_MouseXY.Size = New System.Drawing.Size(100, 31)
        Me.T_MouseXY.TabIndex = 16
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1102, 760)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 31)
        Me.TextBox1.TabIndex = 17
        '
        'T_SD1
        '
        Me.T_SD1.Location = New System.Drawing.Point(796, 760)
        Me.T_SD1.Name = "T_SD1"
        Me.T_SD1.Size = New System.Drawing.Size(100, 31)
        Me.T_SD1.TabIndex = 18
        '
        'T_Account
        '
        Me.T_Account.Location = New System.Drawing.Point(619, 760)
        Me.T_Account.Name = "T_Account"
        Me.T_Account.Size = New System.Drawing.Size(100, 31)
        Me.T_Account.TabIndex = 19
        '
        'T_Value
        '
        Me.T_Value.Location = New System.Drawing.Point(389, 760)
        Me.T_Value.Name = "T_Value"
        Me.T_Value.Size = New System.Drawing.Size(100, 31)
        Me.T_Value.TabIndex = 20
        '
        'T_CursorDate
        '
        Me.T_CursorDate.Location = New System.Drawing.Point(138, 760)
        Me.T_CursorDate.Name = "T_CursorDate"
        Me.T_CursorDate.Size = New System.Drawing.Size(128, 31)
        Me.T_CursorDate.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1010, 824)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(205, 25)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Start Share Price [€]"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(680, 824)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(157, 25)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Inverment Start"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(481, 824)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 25)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "GD"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1010, 763)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 25)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Label5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(743, 763)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 25)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "SD:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(517, 763)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 25)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Account:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(310, 763)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 25)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Value:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(1393, 757)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 31)
        Me.TextBox2.TabIndex = 29
        '
        'T_X_Sc_Off
        '
        Me.T_X_Sc_Off.Location = New System.Drawing.Point(1030, 334)
        Me.T_X_Sc_Off.Name = "T_X_Sc_Off"
        Me.T_X_Sc_Off.Size = New System.Drawing.Size(501, 31)
        Me.T_X_Sc_Off.TabIndex = 30
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(1504, 760)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 31)
        Me.TextBox3.TabIndex = 31
        '
        'T_Current_Sc_Off
        '
        Me.T_Current_Sc_Off.Location = New System.Drawing.Point(1030, 297)
        Me.T_Current_Sc_Off.Name = "T_Current_Sc_Off"
        Me.T_Current_Sc_Off.Size = New System.Drawing.Size(501, 31)
        Me.T_Current_Sc_Off.TabIndex = 32
        '
        'T_MouseCenter
        '
        Me.T_MouseCenter.Location = New System.Drawing.Point(1030, 258)
        Me.T_MouseCenter.Name = "T_MouseCenter"
        Me.T_MouseCenter.Size = New System.Drawing.Size(501, 31)
        Me.T_MouseCenter.TabIndex = 33
        '
        'C_HomeView
        '
        Me.C_HomeView.Location = New System.Drawing.Point(1607, 292)
        Me.C_HomeView.Name = "C_HomeView"
        Me.C_HomeView.Size = New System.Drawing.Size(139, 36)
        Me.C_HomeView.TabIndex = 34
        Me.C_HomeView.Text = "Home View"
        Me.C_HomeView.UseVisualStyleBackColor = True
        '
        'C_LaserWeek
        '
        Me.C_LaserWeek.Location = New System.Drawing.Point(1607, 248)
        Me.C_LaserWeek.Name = "C_LaserWeek"
        Me.C_LaserWeek.Size = New System.Drawing.Size(139, 32)
        Me.C_LaserWeek.TabIndex = 35
        Me.C_LaserWeek.Text = "Last Week"
        Me.C_LaserWeek.UseVisualStyleBackColor = True
        '
        'C_LastMonth
        '
        Me.C_LastMonth.Location = New System.Drawing.Point(1607, 203)
        Me.C_LastMonth.Name = "C_LastMonth"
        Me.C_LastMonth.Size = New System.Drawing.Size(139, 39)
        Me.C_LastMonth.TabIndex = 36
        Me.C_LastMonth.Text = "Last Month"
        Me.C_LastMonth.UseVisualStyleBackColor = True
        '
        'C_LastYear
        '
        Me.C_LastYear.Location = New System.Drawing.Point(1607, 162)
        Me.C_LastYear.Name = "C_LastYear"
        Me.C_LastYear.Size = New System.Drawing.Size(139, 35)
        Me.C_LastYear.TabIndex = 37
        Me.C_LastYear.Text = "Last Year"
        Me.C_LastYear.UseVisualStyleBackColor = True
        '
        'C_WriteChartFile
        '
        Me.C_WriteChartFile.Location = New System.Drawing.Point(1140, 189)
        Me.C_WriteChartFile.Name = "C_WriteChartFile"
        Me.C_WriteChartFile.Size = New System.Drawing.Size(181, 53)
        Me.C_WriteChartFile.TabIndex = 38
        Me.C_WriteChartFile.Text = "Write Chart File"
        Me.C_WriteChartFile.UseVisualStyleBackColor = True
        '
        'C_BuySell
        '
        Me.C_BuySell.Location = New System.Drawing.Point(943, 98)
        Me.C_BuySell.Name = "C_BuySell"
        Me.C_BuySell.Size = New System.Drawing.Size(144, 55)
        Me.C_BuySell.TabIndex = 39
        Me.C_BuySell.Text = "Buy or Sell ?"
        Me.C_BuySell.UseVisualStyleBackColor = True
        '
        'Analyse1
        '
        Me.Analyse1.AutoSize = True
        Me.Analyse1.Location = New System.Drawing.Point(1665, 383)
        Me.Analyse1.Name = "Analyse1"
        Me.Analyse1.Size = New System.Drawing.Size(138, 29)
        Me.Analyse1.TabIndex = 40
        Me.Analyse1.TabStop = True
        Me.Analyse1.Text = "Analyse 1"
        Me.Analyse1.UseVisualStyleBackColor = True
        '
        'Analyse2
        '
        Me.Analyse2.AutoSize = True
        Me.Analyse2.Location = New System.Drawing.Point(1665, 428)
        Me.Analyse2.Name = "Analyse2"
        Me.Analyse2.Size = New System.Drawing.Size(138, 29)
        Me.Analyse2.TabIndex = 41
        Me.Analyse2.TabStop = True
        Me.Analyse2.Text = "Analyse 2"
        Me.Analyse2.UseVisualStyleBackColor = True
        '
        'Analyse3
        '
        Me.Analyse3.AutoSize = True
        Me.Analyse3.Location = New System.Drawing.Point(1665, 477)
        Me.Analyse3.Name = "Analyse3"
        Me.Analyse3.Size = New System.Drawing.Size(138, 29)
        Me.Analyse3.TabIndex = 42
        Me.Analyse3.TabStop = True
        Me.Analyse3.Text = "Analyse 3"
        Me.Analyse3.UseVisualStyleBackColor = True
        '
        'Analyse4
        '
        Me.Analyse4.AutoSize = True
        Me.Analyse4.Location = New System.Drawing.Point(1665, 521)
        Me.Analyse4.Name = "Analyse4"
        Me.Analyse4.Size = New System.Drawing.Size(138, 29)
        Me.Analyse4.TabIndex = 43
        Me.Analyse4.TabStop = True
        Me.Analyse4.Text = "Analyse 4"
        Me.Analyse4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(943, 168)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 112)
        Me.Button1.TabIndex = 44
        Me.Button1.Text = "Check numers of rise in sequenz"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'C_Investhopping
        '
        Me.C_Investhopping.Location = New System.Drawing.Point(1117, 98)
        Me.C_Investhopping.Name = "C_Investhopping"
        Me.C_Investhopping.Size = New System.Drawing.Size(168, 55)
        Me.C_Investhopping.TabIndex = 45
        Me.C_Investhopping.Text = "Invest Hopping"
        Me.C_Investhopping.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(1607, 95)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 31)
        Me.TextBox4.TabIndex = 46
        '
        'Ch_FitY
        '
        Me.Ch_FitY.AutoSize = True
        Me.Ch_FitY.Location = New System.Drawing.Point(1665, 580)
        Me.Ch_FitY.Name = "Ch_FitY"
        Me.Ch_FitY.Size = New System.Drawing.Size(89, 29)
        Me.Ch_FitY.TabIndex = 47
        Me.Ch_FitY.Text = "Fit Y"
        Me.Ch_FitY.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1848, 878)
        Me.Controls.Add(Me.Ch_FitY)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.C_Investhopping)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Analyse4)
        Me.Controls.Add(Me.Analyse3)
        Me.Controls.Add(Me.Analyse2)
        Me.Controls.Add(Me.Analyse1)
        Me.Controls.Add(Me.C_BuySell)
        Me.Controls.Add(Me.C_WriteChartFile)
        Me.Controls.Add(Me.C_LastYear)
        Me.Controls.Add(Me.C_LastMonth)
        Me.Controls.Add(Me.C_LaserWeek)
        Me.Controls.Add(Me.C_HomeView)
        Me.Controls.Add(Me.T_MouseCenter)
        Me.Controls.Add(Me.T_Current_Sc_Off)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.T_X_Sc_Off)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_CursorDate)
        Me.Controls.Add(Me.T_Value)
        Me.Controls.Add(Me.T_Account)
        Me.Controls.Add(Me.T_SD1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.T_MouseXY)
        Me.Controls.Add(Me.T_StartSharePrice)
        Me.Controls.Add(Me.T_InvestmentStart)
        Me.Controls.Add(Me.T_SD)
        Me.Controls.Add(Me.HS_SD)
        Me.Controls.Add(Me.RefreshDataGrid)
        Me.Controls.Add(Me.T_HistoryFileName)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.PicChart)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PicChart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents PicChart As PictureBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GgggToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WebToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ScanWebForWKNToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveWebPageAsHTMLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ServiceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReadSingleShareValueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CheckWeekdayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReadXMLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridViewTestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents T_HistoryFileName As TextBox
    Friend WithEvents RefreshDataGrid As Button
    Friend WithEvents HS_SD As HScrollBar
    Friend WithEvents T_SD As TextBox
    Friend WithEvents T_InvestmentStart As TextBox
    Friend WithEvents T_StartSharePrice As TextBox
    Friend WithEvents TransformToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents T_MouseXY As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents T_SD1 As TextBox
    Friend WithEvents T_Account As TextBox
    Friend WithEvents T_Value As TextBox
    Friend WithEvents T_CursorDate As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents T_X_Sc_Off As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents T_Current_Sc_Off As TextBox
    Friend WithEvents T_MouseCenter As TextBox
    Friend WithEvents C_HomeView As Button
    Friend WithEvents C_LaserWeek As Button
    Friend WithEvents C_LastMonth As Button
    Friend WithEvents C_LastYear As Button
    Friend WithEvents ReadFromWEBToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReadHistoricFromARIVAdeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents C_WriteChartFile As Button
    Friend WithEvents C_BuySell As Button
    Friend WithEvents Analyse1 As RadioButton
    Friend WithEvents Analyse2 As RadioButton
    Friend WithEvents Analyse3 As RadioButton
    Friend WithEvents Analyse4 As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents C_Investhopping As Button
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Ch_FitY As CheckBox
End Class
