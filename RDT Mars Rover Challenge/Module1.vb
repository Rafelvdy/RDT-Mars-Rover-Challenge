Module Module1

    Sub Main()
        Dim myPlateau As New Plateau
        Dim run As Boolean = True


        ' Prompt for user input for the grid dimensions
        Console.Write("Please enter the x-coordinate of the plateau: ")
        myPlateau.xcord = Console.ReadLine()
        Console.Write("Please enter the y-coordinate of the plateau: ")
        myPlateau.ycord = Console.ReadLine()

        'Creates the Robot object which saves the locational properties of the robot
        Dim myRobot As New Robot(myPlateau.xcord, myPlateau.ycord, 0)

        ' Wait for user input before proceeding
        Console.WriteLine("Press enter to generate grid....")
        Console.ReadLine()

        myPlateau.SetCell(myRobot.GetX(), myRobot.GetY(), "|R|")


        While run = True
            ' Display the grid
            myPlateau.DisplayGrid()
            ' Display robot properties
            Console.WriteLine(myRobot.displayProperties())
            Dim choice As String
            Console.WriteLine("Would you like to:")
            Console.WriteLine("1. Move the Rover")
            Console.WriteLine("2. Exit")
            Console.Write(": ")
            choice = Console.ReadLine()

            If choice = 1 Then
                Dim myMissionControl As New Mission_Control(myPlateau)
                Console.WriteLine("Here are the controls:")
                Console.WriteLine("M - Move foward in the direction faced")
                Console.WriteLine("R - Rotate to the right")
                Console.WriteLine("L - Rotate to the left")
                Console.Write("Please enter the string of letters in order of how you would like the rover to move: ")
                myMissionControl.movementInput = Console.ReadLine

                ' calls robot movement method to execute the instructions
                myMissionControl.robotMovement(myRobot)

            ElseIf choice = 2 Then
                run = False
                Console.ReadLine()
            Else
                Console.WriteLine("Please enter a valid input (1 or 2).")
            End If
        End While

    End Sub

End Module
