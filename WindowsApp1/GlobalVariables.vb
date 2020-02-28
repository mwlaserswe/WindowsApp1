Module GlobalVariables
    Public Structure ChartItem
        Dim myDate As String
        Dim Name As String
        Dim WKN As String
        Dim Value As Double
        Dim SD As Double
        Dim Distance As Double      ' Distance to moving average
        Dim Account As Double
        Dim Trend As String

    End Structure

    Public Structure ShareItem
        Dim myDate As String
        Dim Time As String
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
    Public SdLength As Long
    'Public SharePrice As Double
    'Public Rise As Boolean
    Public StartSharePrice As Double
    Public StartEuro As Double
    Public StartAccount As Double


    Public WKS_Download_idx As Long
    Public DownloadPause As Long
    Public WknReadCount As Long
    Public DelayTime As Long
    Public AccessErrorCnt As Long
    Public AccessCnt As Long

    '=== today's share price ===
    Public CompanyListArray() As ShareItem
    Public CompPartialLstArr() As ShareItem

    Public AccountArray() As ChartItem

End Module
