Public Class Plateau

    ' Protected variables for grid dimensions
    Protected Property _xcord As Integer ' The x-coordinate to which the grid should extendn and will create my horizontal boundary
    Protected Property _ycord As Integer ' The y-coordinate to which the grid should extend and will create my vertical boundary
    Public grid(,) As String ' Two-dimensional array to represent the grid

    ' Constructor to initialize a minimum plateau size if no input
    Public Sub New()
        Me._xcord = 1
        Me._ycord = 1
        ReDim grid(_ycord, _xcord) ' Initialize grid with the default size
        InitialiseGrid() ' Initialize grid with default values
    End Sub

    ' Properties to set and get the x coordinate
    Public Property xcord As Integer
        Get
            Return _xcord
        End Get
        Set(value As Integer)
            _xcord = value
            ResizeGrid() ' Resize the grid when xcord changes
        End Set
    End Property

    ' Properties to set and get the y coordinate
    Public Property ycord As Integer
        Get
            Return _ycord
        End Get
        Set(value As Integer)
            _ycord = value
            ResizeGrid() ' Resize the grid when ycord changes
        End Set
    End Property

    ' This method will resize the grid when it is needed, however it might need optimizing as could create a performance issue
    Private Sub ResizeGrid()
        ' Resize the grid to be large enough to accommodate the given coordinates
        ReDim grid(_ycord, _xcord)
        InitialiseGrid() ' Reinitialize the grid with default values after resizing
    End Sub

    ' Method to initialize the grid with default values
    Public Sub InitialiseGrid()
        For i As Integer = 0 To _ycord
            For j As Integer = 0 To _xcord
                grid(i, j) = "| |" ' Default value for each cell
            Next
        Next
    End Sub

    ' Method to set a specific cell in the grid
    Public Sub SetCell(ByVal xcord As Integer, ByVal ycord As Integer, value As String)
        'If problems arise from multiple rovers, it will most likely be fixed in here
        If checkRoverPresent(xcord, ycord) = True Then
            InitialiseGrid()
            Console.WriteLine()
            Console.WriteLine("Whoops! There's already a rover here. Let's backtrack and try again.")
            Console.WriteLine("Press enter to continue...")
            Console.ReadLine()
            Module1.GetRobot1Properties()

        ElseIf xcord >= 0 And ycord >= 0 And xcord <= _xcord And ycord <= _ycord Then
            grid(ycord, xcord) = value
        Else
            InitialiseGrid()
            Console.WriteLine()
            Console.WriteLine("Those coordinates are out of bounds. Let's try something within the grid! Please restart.")
            Console.WriteLine("Press enter to continue...")
            Console.ReadLine()
            Module1.GetRobot1Properties()
        End If
    End Sub

    ' Method to display the grid in the console
    Public Sub DisplayGrid()
        'Painting the grid from the top
        ' Display the X coordinates along the top
        Console.Write("   ") ' Offset for Y coordinate column
        For j As Integer = 0 To _xcord
            Console.Write(j.ToString("00") & " ")
        Next
        Console.WriteLine() ' Move to the next line after X coordinates

        For i As Integer = _ycord To 0 Step -1
            ' Display the Y coordinate along the left
            Console.Write(i.ToString("00") & " ")
            For j As Integer = 0 To _xcord
                Console.Write(grid(i, j))
            Next
            Console.WriteLine() ' Move to the next line after each row
        Next
    End Sub

    Public Function checkRoverPresent(ByVal x As Integer, ByVal y As Integer) As Boolean
        If grid(x, y) = "|R|" Then
            Return True
        Else
            Return False
        End If


    End Function

End Class
