Public Class Form1

    'CREATE GLOBAL VARIABLES
    Dim jump As Boolean = False
    Dim intScore As Integer = 0

    'create graphics engine
    Dim bb As New Bitmap(300, 500)
    Dim gamerunning As Boolean = True
    Dim g As Graphics

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'SET UP
        Show()

        'RUN
        g = Graphics.FromImage(bb)
        g.Clear(Color.DeepSkyBlue)

        'END DRAW
        CreateGraphics.DrawImage(bb, 0, 0)

        'START LOOP
        gameLoop()

    End Sub

    Private Sub gameLoop()

        'MAKE BIRD AND OBSTICLES
        Dim BigBird As New bird
        Dim wall As New Obsticle

        'CONTACT BOOLEAN
        Dim blnContact As Boolean = False
        Dim blnOver As Boolean = False
        Dim intDead As Integer = 0

        'walls x and y values
        Dim intWallX As Integer
        Dim intWallBotY As Integer
        Dim intWallTopY As Integer

        'birds x and y values
        Dim intBirdx As Integer
        Dim intBirdY As Integer

        'GAME LOOP
        Do While gamerunning = True

            'DO OTHER EVENTS
            Application.DoEvents()

            'DRAW BACKGROUND
            g.Clear(Color.DeepSkyBlue)

            'BIRD COMMANDS
            'move 
            If jump Then
                BigBird.Move()
                jump = False
            End If
            intBirdY = BigBird.Update()
            intBirdx = 150
            'draw    
            BigBird.Draw(g)

            'WALL COMMANDS
            'move / get points
            intScore = wall.NewWalls()
            intWallX = wall.update()
            'draw
            wall.Draw(g)
            'update x and y
            intWallX = wall.X
            intWallTopY = wall.SendtopY
            intWallBotY = wall.SendtopY + 150

            'CHECK FOR COLLISIONS
            blnContact = CollisionDetector(intBirdx, intBirdY, intWallX, intWallTopY, intWallBotY)

            'END GAME
            'check for colision
            If blnContact Then
                BigBird.Dead()
                blnOver = True
            End If
            'make bird fall upon death
            If blnOver Then
                wall.StopWall()
                intDead = EndItAll()
                wall.Draw(g)
                BigBird.NoJump()
                BigBird.Update()
                BigBird.Draw(g)
                'show message and end game
                If intDead = 200 Then
                    MessageBox.Show("Game Over:(")
                    End
                End If
            End If

            'REDRAW IMAGE AND SHOW SCORE
            Dim strscore As String = "score: " & intScore
            g.DrawString(strscore, New Font("ariel", 16), New SolidBrush(Color.Red), 100, 100, New StringFormat)
            CreateGraphics.DrawImage(bb, 0, 0)

        Loop

    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        'SPACE = JUMP
        If e.KeyChar = ChrW(Keys.Space) Then
            jump = True
        End If

        'If e.KeyChar = ChrW(Keys.Escape) Then
        '    gamerunning = True
        '    gameLoop()
        'End If

    End Sub

    Private Function CollisionDetector(birdx As Integer, birdy As Integer, wallx As Integer, wally1 As Integer, wally2 As Integer) As Boolean

        'CHECK FOR COLISION
        If birdx + 20 >= wallx And birdx <= wallx + 25 Then
            If birdy < wally1 And birdy >= 0 Then
                Return True

            ElseIf birdy + 20 > wally2 And birdy <= 500 Then
                Return True

            Else Return False
            End If
        End If

        Return False

    End Function

    Private Function EndItAll() As Integer

        Static intDead As Integer = 0

        intDead += 1

        Return intDead

    End Function


End Class
