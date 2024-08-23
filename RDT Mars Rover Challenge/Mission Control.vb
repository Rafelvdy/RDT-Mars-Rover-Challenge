Public Class Mission_Control
    Private Plateau As Plateau
    Private Property _movementInput As String
    Private myrobot As Robot

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
        'Split string into individual characters so the program can process each movement
        For i = 1 To Len(_movementInput)
            Dim letter As String = Mid(_movementInput, i, 1)
            If letter.ToUpper = "R" Then
                myRobot.turnRight() 'call turn right method in robot class
            ElseIf letter.ToUpper = "L" Then
                myRobot.turnLeft() 'call turn left method in robot class
            ElseIf letter.ToUpper = "M" Then

            Else
                Console.WriteLine("Invalid Input")
            End If
        Next
    End Sub


End Class
