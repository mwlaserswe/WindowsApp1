Option Explicit On
Module GlobalVariables
    Public Structure ChartItem
        Dim myDate As String
        Dim Name As String
        Dim WKN As String
        Dim Value As Double
        Dim SMA As Double
        Dim Distance As Double          ' Distance to moving average
        Dim StartSharePrice As Double   ' Einstiegskurs
        Dim Account As Double
        Dim Trend As String
        Dim State As Integer

    End Structure

    Public Structure ShareItem
        Dim myDate As String
        Dim Time As String
        'Dim Company As String
        Dim Name As String
        Dim WKN As String
        Dim ISIN As String
        Dim Index As String
    End Structure

    Public Structure HistoryItem
        Dim Datum As String
        Dim Erster As String
        Dim Hoch As String
        Dim Tief As String
        Dim Schlusskurs As String
        Dim Stuecke As String
        Dim Volumen As String
        Dim Bemerkung As String
    End Structure


    Public Structure ShareResult
        Dim Value As Double
        Dim ErrorString As String
    End Structure


    Public Structure MousePos
        Dim X As Double
        Dim Y As Double
    End Structure

    Public Structure BestSMA
        Dim AbsMax As Double
        Dim AbsMaxPos As Integer

        Dim SMAArry() As Double
    End Structure

    '=== Alias for DataGridView

    Public Const spPrimaryKey = "spPrimaryKey"
    Public Const spCompany = "spCompany"
    Public Const spWKN = "spWKN"
    Public Const spIsin = "spIsin"
    Public Const spIndex = "spIndex"
    Public Const spStatus = "spStatus"
    Public Const spAccount = "spAccount"
    Public Const spSMA = "spSMA"

    '=== Visualisieung ===
    Public GlbScaleX As Single
    Public GlbScaleY As Single
    Public GlbOffX As Single
    Public GlbOffY As Single

    Public GlbPicOffX As Double
    Public GlbPicOffY As Double

    'Public currentX As Single
    'Public currentY As Single


    Public ChartFilename As String

    Public ChartArray() As ChartItem

    Public GlbShareInfo As New ClsXML.ShareInfo

    Public MouseDnPos As MousePos
    Public MouseUpPos As MousePos
    Public MyMouseMove As MousePos
    Public OffsetCurrent As MousePos
    Public OffsetLast As MousePos
    Public ScaleCurrent As MousePos
    Public ScaleLast As MousePos
    Public MouseCenterPos As MousePos
    Public MouseXY As MousePos

    '=== Analyse ===
    Public SMALength As Long
    Public Percentage As Double
    'Public SharePrice As Double
    'Public Rise As Boolean
    Public StartSharePrice As Double    ' Einstiegskurs
    Public StartEuro As Double
    Public StartAccount As Double


    Public WKS_Download_idx As Long
    Public DownloadPause As Long
    Public WknReadCount As Long
    Public DelayTime As Long
    Public AccessErrorCnt As Long
    Public AccessCnt As Long

    Public glbBand As Double

    '=== today's share price ===
    Public CompanyListArray() As ShareItem
    Public CompPartialLstArr() As ShareItem

    Public AccountArray() As ChartItem

End Module
