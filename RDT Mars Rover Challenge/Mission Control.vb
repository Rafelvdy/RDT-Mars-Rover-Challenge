Public Class Mission_Control
    Private Plateau As Plateau
    Private Property _movementInput1 As String
    Private Property _movementInput2 As String


    'constructor to initialise mission control with a plateau
    Public Sub New(ByVal Plateau As Plateau)
        Me.Plateau = Plateau
    End Sub

    Public Property movementInput1 As String
        Set(value As String)
            _movementInput1 = value
        End Set
        Get
            Return _movementInput1
        End Get
    End Property

    Public Property movementInput2 As String
        Set(value As String)
            _movementInput2 = value
        End Set
        Get
            Return _movementInput2
        End Get
    End Property

    Public Sub robotMovement1(ByVal myRobot As Robot)
        'Processes movement input 1
        For i = 1 To Len(_movementInput1)
            Dim letter As String = Mid(_movementInput1, i, 1)

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
                Plateau.DisplayGrid()
            Else
                Console.WriteLine("Invalid Input")
            End If
        Next


    End Sub

    Public Sub RobotMovement2(ByVal myRobot As Robot)
        'Processes movement input 2
        For i = 1 To Len(_movementInput2)
            Dim letter As String = Mid(_movementInput2, i, 1)

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
                Plateau.DisplayGrid()
            Else
                Console.WriteLine("Invalid Input")
            End If
        Next
    End Sub



End Class