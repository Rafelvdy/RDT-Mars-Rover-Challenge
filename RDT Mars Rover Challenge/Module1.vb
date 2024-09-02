Module Module1
    ' initialises the grid object 
    Dim myPlateau As New Plateau
    'Arrays to hold the coordinates for each robot
    Dim xcoords(2) As Integer
    Dim ycoords(2) As Integer
    Sub Main()


        ' User enters maximum coordinates of the grid and then the input is passed into the plateau class
        myPlateau.xcord = CheckIntegerInputValid("Please enter the x-coordinate of the plateau: ")
        myPlateau.ycord = CheckIntegerInputValid("Please enter the y-coordinate of the plateau: ")
        Console.WriteLine("Press enter to generate grid....")
        Console.ReadLine()
        'Executes the sub routine inside of plateau so that the grid is displayed
        myPlateau.DisplayGrid()
        Console.WriteLine("Please press enter to continue....")
        Console.ReadLine()

        'Calls first subroutine to get robot 1 properties. The other sub routines are called in an order through the program
        GetRobot1Properties()

    End Sub

    Public Sub GetRobot1Properties()
        Dim myMissionControl As New Mission_Control(myPlateau)
        Dim choice As String
        'ROBOT 1 PROPERTIES
        'User enters the coordinates at which they would like the robot to start at, which is passed into a robot object so that the two robots can have different locations
        Console.WriteLine("Please enter the start coordinates for rover 1")
        xcoords(1) = CheckIntegerInputValid("x: ")
        ycoords(1) = CheckIntegerInputValid("y: ")
        'Creating an instance of the robot with the location chosen
        'There are default values incase the user does not enter anything
        Dim myRobot1 As New Robot(xcoords(1), ycoords(1), 0)
        'Allows the user to choose whether they want to have a different direction, otherwise it will use the default value
        Console.Write("Direction (N/E/S/W): ")
        myRobot1.direction = Console.ReadLine().ToUpper()
        'Dictionary converter converts the character input into a integer value so that the program can cycle through the directions as it turns
        myRobot1.dictionaryConverter()
        'Puts an R onto the grid to symbolise the rover
        myPlateau.SetCell(myRobot1.GetX(), myRobot1.GetY(), "|R|")
        myPlateau.DisplayGrid()

        'ROBOT 1 MOVEMENT OPTIONS
        Console.WriteLine("Would you like to move robot 1? (Y/N)")
        'Displays robot1 properties so that the user can see which R on the grid is which robot
        Console.WriteLine("x: " & myRobot1.GetX & " y: " & myRobot1.GetY & " direction: " & myRobot1.GetDirection())
        choice = Console.ReadLine()
        If choice.ToUpper() = "Y" Then
            'Displays all the controls to the user
            Console.WriteLine("Here are the controls:")
            Console.WriteLine("M - Move foward in the direction faced")
            Console.WriteLine("R - Rotate to the right")
            Console.WriteLine("L - Rotate to the left")
            Console.Write("Please enter the string of letters in order of how you would like the rover to move: ")
            'Passes the string of moves into mission control object so that it can be processed
            myMissionControl.movementInput1 = Console.ReadLine
        ElseIf choice.ToUpper() = "N" Then
            Console.WriteLine("Press enter to continue....")
            Console.ReadLine()

        End If
        GetRobot2Properties(myRobot1, myMissionControl)
    End Sub

    Public Sub GetRobot2Properties(ByVal myRobot1 As Robot, ByVal myMissionControl As Mission_Control)
        Dim choice As String
        'ROBOT 2 PROPERTIES
        'Comments from ROBOT 1 PROPERTIES apply the same but just to robot 2
        Console.WriteLine("Please enter the start coordinates for rover 2")
        xcoords(2) = CheckIntegerInputValid("x: ")
        ycoords(2) = CheckIntegerInputValid("y: ")
        Dim myRobot2 As New Robot(xcoords(2), ycoords(2), 0)
        Console.Write("Direction (N/E/S/W): ")
        myRobot2.direction = Console.ReadLine().ToUpper()
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
        ExecuteRobots(myRobot1, myRobot2, myMissionControl)
    End Sub

    Public Sub ExecuteRobots(ByVal myRobot1 As Robot, ByVal myRobot2 As Robot, ByVal myMissionControl As Mission_Control)
        'Calls the routine to move the robots so that robot 1 moves first and then robot 2 will follow after
        myMissionControl.robotMovement1(myRobot1)
        myMissionControl.RobotMovement2(myRobot2)
        ' Display all robot properties so that the user can see where the robots are facing and also it will allow them to differentiate between the two robots using their coordinates
        Console.WriteLine("Robot 1")
        Console.WriteLine(myRobot1.displayProperties())
        Console.WriteLine("Robot 2")
        Console.WriteLine(myRobot2.displayProperties())
        Console.ReadLine()
    End Sub

    'A function which can be called so that the user is required to keep on entering their input until it is an acceptable data type
    Function CheckIntegerInputValid(Output As String) As Integer
        Dim input As String
        Dim validInteger As Integer
        Do
            Console.Write(Output)
            input = Console.ReadLine()
        Loop Until Integer.TryParse(input, validInteger)
        Return validInteger

    End Function
End Module
