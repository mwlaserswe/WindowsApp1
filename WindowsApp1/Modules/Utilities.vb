Option Explicit On

'''Class Employee
'''    Public Sub New(ByVal id As Integer, ByVal firstName As String,
'''                       ByVal lastName As String, ByVal salary As Integer)
'''        ' Set fields.
'''        Me._id = id
'''        Me._firstName = firstName
'''        Me._lastName = lastName
'''        Me._salary = salary
'''    End Sub

'''    ' Storage of employee data.
'''    Public _firstName As String
'''    Public _id As Integer
'''    Public _lastName As String
'''    Public _salary As Integer
'''End Class


Module Utilities
    Public Function Zahl(Txt As String) As Double
        ' Wandelt die Zahl in einem String in eine Zahl um
        ' dabei werden "," in "." umgewandelt und alle Zeichen
        ' die nicht passen in Leerzeichen gewandelt
        ' 22.07.2002 Exponent möglich
        '            wenn keine Ziffern vorhanden sind, wird Err.number = 1 gesetzt
        Dim i As Integer
        Dim s As String
        Dim noVorz As Boolean, noKomma As Boolean, noExpo As Boolean, haveDigits As Boolean
        s = ""
        For i = 1 To Len(Txt)
            Select Case Mid(Txt, i, 1)
                Case "+", "-"
                    If Not noVorz Then
                        s = s + Mid(Txt, i, 1)
                        noVorz = True
                    Else
                        Exit For
                    End If
                Case ",", "."
                    If Not noKomma Then
                        s = s + "."
                        noKomma = True
                        noVorz = True
                    Else
                        Exit For
                    End If
                Case "0" To "9"
                    s = s + Mid(Txt, i, 1)
                    noVorz = True
                    haveDigits = True
                Case "&"
                    s = s + Mid(Txt, i, 2)
                    noVorz = True
                Case "E", "e"
                    If Not noExpo Then
                        s = s + Mid(Txt, i, 1)
                        noVorz = False
                        noKomma = True
                        noExpo = True
                    Else
                        Exit For
                    End If
                Case " "
                Case Else
                    If haveDigits Then Exit For
            End Select
        Next i
        If Not haveDigits Then
            Err.Number = 1
            Err.Description = "Zahl set to 0. No Digits in String"
        End If
        Zahl = Val(s)
    End Function


    Public Sub SepariereString(Zeile As String, ByRef WortArray() As String, Delimiter As String)
        Dim Pos1 As Long
        Dim Pos2 As Long
        Dim AnzahlWorte As Long               'Anzahl der Worte der Zeile

        ReDim WortArray(0 To 0)                         'WortArray löschen
        AnzahlWorte = 0
        Pos2 = 0

        If Delimiter = " " Then Zeile = Trim(Zeile)

        Zeile = Trim(Zeile)
        Do
            Pos1 = Pos2

            'Trennzeichen [CR]: [LF] werden überlesen
            If Delimiter = vbCr Then
                If Mid(Zeile, Pos1 + 1, 1) = vbLf Then
                    Pos1 = Pos1 + 1                             'LF übergehen
                End If
            End If

            'Trennzeichen [Space]: [Space] werden überlesen
            If Delimiter = " " Then
                Do While Mid(Zeile, Pos1 + 1, 1) = " "
                    Pos1 = Pos1 + 1                             'Space übergehen
                Loop
            End If

            Pos2 = InStr(Pos1 + 1, Zeile, Delimiter, CompareMethod.Binary)      'nach Trennzeichen suchen
            If Pos2 > 0 Then                              'noch ein Trennzeichen in der Zeile
                WortArray(AnzahlWorte) = Mid(Zeile, Pos1 + 1, Pos2 - Pos1 - 1)
                ReDim Preserve WortArray(0 To UBound(WortArray) + 1)
                AnzahlWorte = AnzahlWorte + 1
            Else                                          'kein Trennzeichen mehr vorhanden
                WortArray(AnzahlWorte) = Mid(Zeile, Pos1 + 1)
            End If
        Loop While Pos2 > 0
    End Sub


    Public Sub BubbleSort(Numlist As Double())
        'Dim Numlist() As Integer = {23435, 1, 433, 5234}
        'here you can use any numbers in any order
        Dim Count As Integer = 0
        Dim Swapvalue As Double
        For ii = 0 To Numlist.Length - 2
            For i = 0 To Numlist.Length - 2
                Count += 1
                If Numlist(i) > Numlist(i + 1) Then
                    Swapvalue = Numlist(i)
                    Numlist(i) = Numlist(i + 1)
                    Numlist(i + 1) = Swapvalue
                End If
            Next
        Next

    End Sub

    Public Function FixLen(s1 As String, le As Long) As String
        Dim i As Long
        Dim s2 As String

        If Len(s1) < le Then
            For i = Len(s1) To le - 1
                s2 = s2 + " "
            Next i
            FixLen = s1 + s2
        ElseIf Len(s1) > le Then
            FixLen = Mid(s1, 1, le)
        Else
            FixLen = s1
        End If


    End Function
End Module
