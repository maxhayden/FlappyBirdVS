Public Class bird

    'GLOBAL VARIALBES
    Dim Gravity As Double = 0.03
    Dim velocity As Double
    'public variables
    Public Y As Double = 250
    Public X As Integer = 150


    Public Sub Move()

        'JUMP
        velocity = -1.5

    End Sub

    Public Sub Draw(g As Graphics)

        'DRAW BIRD
        g.FillRectangle(Brushes.Yellow, New RectangleF(New Point(X, Y), New Size(20, 20)))

    End Sub

    Public Function Update() As Double

        velocity += Gravity
        Y += velocity
        'LIMIT BIRD TO SCREEN
        If Y < 0 Then
            Y = 0
            velocity = 0
        End If

        If Y >= 450 Then
            Y = 450
            velocity = 0
        End If

        Return Y

    End Function

    Public Sub Dead()

        'MAKES BIRD FALL UPON CRASHING
        velocity += 0.07
        Y += velocity

    End Sub

    Public Sub NoJump()

        velocity = +1.5

    End Sub

End Class
