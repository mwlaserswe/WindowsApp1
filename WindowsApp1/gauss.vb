Option Explicit On

Module gauss

    Public A(2, 3) As Double
    Public X(2) As Double
    Dim n As Integer


    Public Sub Init()
        n = 2
        A(1, 1) = 4000 : A(1, 2) = 1 : A(1, 3) = 100
        A(2, 1) = 5000 : A(2, 2) = 1 : A(2, 3) = 10000

        '  n = 2
        '  A(1, 1) = 2: A(1, 2) = -1: A(1, 3) = -1
        '  A(2, 1) = -3: A(2, 2) = -1: A(2, 3) = -6

        '  n = 3
        '  A(1, 1) = 4: A(1, 2) = 1: A(1, 3) = 1: A(1, 4) = -17
        '  A(2, 1) = 11: A(2, 2) = -6: A(2, 3) = 1: A(2, 4) = -157
        '  A(3, 1) = -3: A(3, 2) = -6: A(3, 3) = 1: A(3, 4) = -45






    End Sub

    ' Achtung Arrays sind nicht 0-based
    Public Function GaussPivot(A(,) As Double, n As Integer) As Double()

        Dim Pivotelement As Double
        Dim Pivotzeile As Integer
        Dim H As Double
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim s As Double

        Dim X() As Double

        ReDim X(0 To n)
        ReDim GaussPivot(0 To n)


        ' 1. Schritt Gesamtelimination
        For k = 1 To n - 1

            Pivotelement = 0
            Pivotzeile = k

            'Pivotelement suchen
            For i = k To n
                If Math.Abs(A(i, k)) > Pivotelement Then
                    Pivotelement = Math.Abs(A(i, k))
                    Pivotzeile = i
                End If
            Next i

            ' wenn k=i, Pivotelement bereits richtig
            If k <> Pivotzeile Then
                ' Zeilen vertauschen
                For j = k To n + 1
                    H = A(k, j)
                    A(k, j) = A(Pivotzeile, j)
                    A(Pivotzeile, j) = H
                Next j
            End If

            If A(k, k) = 0 Then
                MsgBox("Gleichungssystem unlösbar")
                Exit Function
            End If

            ' Elimination auf Stufe k
            For i = k + 1 To n
                s = A(i, k) / A(k, k)
                For j = k To n + 1
                    A(i, j) = A(i, j) - s * A(k, j)
                Next j
                A(i, k) = 0 'Reine Optik: untere Dreiecksmatrix ist Null
            Next i
        Next k

        '  DisplayMatrix

        ' 2. Schritt rückwärts einsetzen
        If A(n, n) <> 0 Then
            X(n) = A(n, n + 1) / A(n, n)
        Else
            'z.B zwei parallele Geraden
            MsgBox("Gleichungssystem unlösbar")
            Exit Function
        End If

        For i = n - 1 To 1 Step -1

            s = A(i, n + 1)

            For j = i + 1 To n
                s = s - A(i, j) * X(j)
            Next j

            X(i) = s / A(i, i)

        Next i

        GaussPivot = X

    End Function

    Private Sub DisplayMatrix()
        '''Dim i As Integer
        ''''  Format(X, "00.00")
        '''For i = 1 To n + 1
        '''    Label1(i) = Format(A(1, i), "0.000")
        '''Next i

        '''For i = 1 To n + 1
        '''    Label2(i) = Format(A(2, i), "0.000")
        '''Next i

        '''For i = 1 To n + 1
        '''    Label3(i) = Format(A(3, i), "0.000")
        '''Next i
    End Sub




End Module
