Public Class Obsticle

    'GLOBAL VARIABLES
    Dim intRand As Integer
    'public variables
    Public X As Integer
    Public yTop As Integer = intRand
    Public yBot As Integer = intRand + 150

    Public Function update() As Integer

        Dim intspeed As Double = 1
        'MOVES WALLS
        X = X - intspeed

        Return X

    End Function

    Public Sub Draw(g As Graphics)


        'DRAW WALLS
        'top
        g.FillRectangle(Brushes.Green, New RectangleF(New Point(X, 0), New Size(25, intRand)))
        'bottom
        g.FillRectangle(Brushes.Green, New RectangleF(New Point(X, intRand + 150), New Size(25, 500)))

    End Sub

    Public Function NewWalls() As Integer

        'CREATES A NEW WALL AND ADDS SCORE
        Static intScore As Integer = 0

        If X <= -35 Then
            X = 380

            intRand = Randomwall()
        End If

        If X = 110 Then
            intScore += 10
        End If

        Return intScore

    End Function

    Private Function Randomwall() As Integer

        'RANDOMIZES HEIGHT OF WALLS
        Dim intHolder As Integer

        Randomize()
        intHolder = Int((350 - 50 + 1) * Rnd() + 50)

        Return intHolder

        'redefine x and y
        yTop = intRand
        yBot = intRand + 150

    End Function

    Public Function SendtopY() As Integer

        'SENDS Y VALUE
        Return intRand

    End Function

    Public Sub StopWall()

        'MKAES WALL STOP MOVING
        X = X + 1

    End Sub

End Class
