
'rotate/scale image using coordinate geometry or matrix transforms
'Option Strict On

Public Class FrmRotateImageExamples
    Dim bm_rusty As Bitmap = Image.FromFile("d:\kl.jpg")  'replace this path with your own image path
    Dim Rotation As Single = 0
    Dim ScaleFactor As Single = 1

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        If RadioButton1.Checked Then
            'draw using manual coordinate calculations
            Dim cx As Double = Me.ClientSize.Width / 2
            Dim cy As Double = Me.ClientSize.Height / 2

            'center in form and scale
            Dim corners(2) As PointF
            corners(0) = New PointF(CSng(cx - (ScaleFactor * bm_rusty.Width / 2)), CSng(cy - (ScaleFactor * bm_rusty.Height / 2)))
            corners(1) = New PointF(CSng(cx + (ScaleFactor * bm_rusty.Width / 2)), CSng(cy - (ScaleFactor * bm_rusty.Height / 2)))
            corners(2) = New PointF(CSng(cx - (ScaleFactor * bm_rusty.Width / 2)), CSng(cy + (ScaleFactor * bm_rusty.Height / 2)))

            'rotate
            Dim X As Double
            For i = 0 To 2
                X = corners(i).X
                corners(i).X = CSng(corners(i).X * Math.Cos(Rotation) + corners(i).Y * Math.Sin(Rotation))
                corners(i).Y = CSng((corners(i).Y * Math.Cos(Rotation)) - (X * Math.Sin(Rotation)))
            Next i

            'translate back to center
            Dim newcx As Double = corners(2).X + (corners(1).X - corners(2).X) / 2
            Dim newcy As Double = corners(2).Y + (corners(1).Y - corners(2).Y) / 2

            For i = 0 To 2
                corners(i).X = CSng(corners(i).X + (cx - newcx))
                corners(i).Y = CSng(corners(i).Y + (cy - newcy))
            Next i

            e.Graphics.Clear(Color.White)
            e.Graphics.DrawImage(bm_rusty, corners)

        Else
            'draw with matrix transform methods
            With e.Graphics
                .Clear(Color.Black)

                'apply the scaling and rotate the image about the center of the window
                .ScaleTransform(ScaleFactor, ScaleFactor)
                'translate origin coordinate from upper left of form to center for rotation
                .TranslateTransform(.VisibleClipBounds.Width / 2, .VisibleClipBounds.Height / 2)
                'rotate the image about its center
                .RotateTransform(CSng(Rotation * -57.3))
                'draw the image with its upperleft corner located half distance from the center point
                .DrawImage(bm_rusty, CInt(-bm_rusty.Width / 2), CInt(-bm_rusty.Height / 2))

            End With
        End If
    End Sub

    Private Sub Buttons_Click_1(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click

        Select Case CType(sender, Button).Text
            Case "Rotate"
                Rotation = CSng(Rotation + (Math.PI / 6))
            Case "Zoom In"
                ScaleFactor = CSng(ScaleFactor + 0.2)
                If ScaleFactor > 2 Then ScaleFactor = 2
            Case "Zoom Out"
                ScaleFactor = CSng(ScaleFactor - 0.2)
                If ScaleFactor < 0.2 Then ScaleFactor = 0.2
        End Select

        Me.Invalidate()

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        Me.Invalidate()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DoubleBuffered = True
        RadioButton1.Checked = True
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Invalidate()
    End Sub
End Class
