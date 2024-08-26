Module Module1

    Sub Main()
        Dim myPlateau As New Plateau
        Dim run As Boolean = True
        Dim xcoords(4) As Integer
        Dim ycoords(4) As Integer

        'Grid creation
        ' Prompt for user input for the grid dimensions
        Console.Write("Please enter the x-coordinate of the plateau: ")
        myPlateau.xcord = Console.ReadLine()
        Console.Write("Please enter the y-coordinate of the plateau: ")
        myPlateau.ycord = Console.ReadLine()
        ' Wait for user input before proceeding
        Console.WriteLine("Press enter to generate grid....")
        Console.ReadLine()
        myPlateau.DisplayGrid()
        Console.WriteLine("Please press enter to continue....")
        Console.ReadLine()

        'Rover location and movement
        Dim choice As String
        Dim myMissionControl As New Mission_Control(myPlateau)

        'Robot 1 movement choice
        Console.WriteLine("Please enter the start coordinates for rover 1")
        Console.Write("x: ")
        xcoords(1) = Console.ReadLine()
        Console.Write("y: ")
        ycoords(1) = Console.ReadLine()
        Dim myRobot1 As New Robot(xcoords(1), ycoords(1), 0)
        Console.Write("Direction (N/E/S/W): ")
        myRobot1.direction = Console.ReadLine()
        myRobot1.dictionaryConverter()
        myPlateau.SetCell(myRobot1.GetX(), myRobot1.GetY(), "|R|")
        myPlateau.DisplayGrid()

        Console.WriteLine("Would you like to move robot 1? (Y/N)")
        Console.WriteLine("x: " & myRobot1.GetX & " y: " & myRobot1.GetY & " direction: " & myRobot1.GetDirection())
        choice = Console.ReadLine()
        If choice.ToUpper() = "Y" Then

            Console.WriteLine("Here are the controls:")
            Console.WriteLine("M - Move foward in the direction faced")
            Console.WriteLine("R - Rotate to the right")
            Console.WriteLine("L - Rotate to the left")
            Console.Write("Please enter the string of letters in order of how you would like the rover to move: ")
            myMissionControl.movementInput1 = Console.ReadLine
        ElseIf choice.ToUpper() = "N" Then
            Console.WriteLine("Press enter to continue....")
            Console.ReadLine()

        End If


        'Robot 2 movement choice
        Console.WriteLine("Please enter the start coordinates for rover 2")
        Console.Write("x: ")
        xcoords(2) = Console.ReadLine()
        Console.Write("y: ")
        ycoords(2) = Console.ReadLine()
        Dim myRobot2 As New Robot(xcoords(2), ycoords(2), 0)
        Console.Write("Direction (N/E/S/W): ")
        myRobot2.direction = Console.ReadLine()
        myRobot2.dictionaryConverter()

        myPlateau.SetCell(myRobot2.GetX(), myRobot2.GetY(), "|R|")
        myPlateau.DisplayGrid()

        Console.WriteLine("Would you like to move robot 2? (Y/N)")
        Console.WriteLine("x: " & myRobot2.GetX & " y: " & myRobot2.GetY & " direction: " & myRobot2.GetDirection())
        choice = Console.ReadLine()
        If choice.ToUpper() = "Y" Then
            Console.WriteLine("Here are the controls:")
            Console.WriteLine("M - Move foward in the direction faced")
            Console.WriteLine("R - Rotate to the right")
            Console.WriteLine("L - Rotate to the left")
            Console.Write("Please enter the string of letters in order of how you would like the rover to move: ")
            myMissionControl.movementInput2 = Console.ReadLine
        ElseIf choice.ToUpper() = "N" Then
            Console.WriteLine("Press enter to continue....")
            Console.ReadLine()
        End If




        myMissionControl.robotMovement1(myRobot1)
        myMissionControl.RobotMovement2(myRobot2)

        ' Display all robot properties
        Console.WriteLine("Robot 1")
        Console.WriteLine(myRobot1.displayProperties())
        Console.WriteLine("Robot 2")
        Console.WriteLine(myRobot2.displayProperties())
        Console.ReadLine()
    End Sub
End Module
