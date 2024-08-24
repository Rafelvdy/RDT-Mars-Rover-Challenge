Public Class Mission_Control
    Private Plateau As Plateau
    Private Property _movementInput As String


    'constructor to initialise mission control with a plateau
    Public Sub New(ByVal Plateau As Plateau)
        Me.Plateau = Plateau
    End Sub

    Public Property movementInput As String
        Set(value As String)
            _movementInput = value
        End Set
        Get
            Return _movementInput
        End Get
    End Property

    Public Sub robotMovement(ByVal myRobot As Robot)
        ' Split string into individual characters so the program can process each movement
        For i = 1 To Len(_movementInput)
            Dim letter As String = Mid(_movementInput, i, 1)

            If letter.ToUpper = "R" Then
                myRobot.turnRight() ' Call turn right method in robot class
            ElseIf letter.ToUpper = "L" Then
                myRobot.turnLeft() ' Call turn left method in robot class
            ElseIf letter.ToUpper = "M" Then
                ' Clear the current position of the robot on the grid
                Dim currentX As Integer = myRobot.GetX()
                Dim currentY As Integer = myRobot.GetY()

                ' Move the robot forward
                myRobot.moveFoward()

                ' If it was the first move, leave a 'P' at the original position
                If myRobot.IsFirstMove() Then
                    Plateau.SetCell(currentX, currentY, "|P|")
                    myRobot.SetFirstMove(False) ' Set the flag to False after the first move
                Else
                    Plateau.SetCell(currentX, currentY, "| |")
                End If

                ' Update the robot's new position on the grid
                Plateau.SetCell(myRobot.GetX(), myRobot.GetY(), "|R|")

            Else
                Console.WriteLine("Invalid Input")
            End If
        Next
    End Sub



End Class
