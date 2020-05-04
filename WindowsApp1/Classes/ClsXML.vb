Option Explicit On

Imports System.IO
Imports System.Text
Imports System.Xml.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Public Class ClsXML
    '<Serializable()> Public Class ClsShareInfo
    '    Public ID As String
    '    Public WKN As String
    '    Public Name As String
    '    Public ISIN As String
    '    Public AbsMax As Double
    '    Public AbsMaxPos As Integer
    '    Public Minimum As Double
    '    Public MinPos As Integer
    '    Public RightMax As Double
    '    Public RightMaxPos As Integer
    'End Class

    '''<Serializable()> Public Class General
    '''    Public ID As String
    '''    Public WKN As String
    '''    Public Name As String
    '''    Public ISIN As String
    '''End Class
    '''<Serializable()> Public Class BestSD
    '''    Public AbsMax As Double
    '''    Public AbsMaxPos As Integer
    '''    Public Minimum As Double
    '''    Public MinPos As Integer
    '''    Public RightMax As Double
    '''    Public RightMaxPos As Integer
    '''End Class
    '''<Serializable()> Public Class ShareInfo
    '''    Public General As General
    '''    Public BestSD As BestSD
    '''End Class

    Public Class General
        Public ID As String
        Public Name As String
        Public WKN As String
        Public ISIN As String
    End Class

    Public Class BestSD
        Public AbsMax As String
        Public AbsMaxPos As String
        Public Minimum As String
        Public MinPos As String
        Public RightMax As String
        Public RightMaxPos As String
    End Class

    <Serializable()> Public Class ShareInfo
        Public General As New General
        Public BestSD As New BestSD


    End Class




    End Class
