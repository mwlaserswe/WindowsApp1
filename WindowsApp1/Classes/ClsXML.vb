Option Explicit On

Imports System.IO
Imports System.Text
Imports System.Xml.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Public Class ClsXML

    Public Class General
        Public ID As String
        Public Name As String
        Public WKN As String
        Public ISIN As String
    End Class

    Public Class WebInfos
        Public FinanzenNetWebPage As String
        Public ArivaHistoricDownloadWebPage As String
        Public PrivateInfos As String
    End Class

    Public Class SMAInfo
        Public AbsMax As String
        Public AbsMaxPos As String
        Public SMAArry As String
    End Class

    Public Class UserDefinitions
        Public UserDefinedSMA As String
    End Class



    Public Class BestSMA
        Public SMA_LastYear As New SMAInfo
        Public SMA_Since2000 As New SMAInfo
        Public SMA_SinceCorona As New SMAInfo
    End Class


    <Serializable()> Public Class ShareInfo
        Public General As New General
        Public WebInfos As New WebInfos
        Public BestSMA As New BestSMA
        Public UserDefinitions As New UserDefinitions
    End Class

End Class
