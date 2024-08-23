Public Class Plateau

    ' Protected variables for grid dimensions
    Protected Property _xcord As Integer ' The x-coordinate to which the grid should extend
    Protected Property _ycord As Integer ' The y-coordinate to which the grid should extend
    Protected grid(,) As String ' Two-dimensional array to represent the grid

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

    ' Method to resize the grid based on the current coordinates
    Private Sub ResizeGrid()
        ' Resize the grid to be large enough to accommodate the given coordinates
        ReDim grid(_ycord, _xcord)
        InitialiseGrid() ' Reinitialize the grid with default values after resizing
    End Sub

    ' Method to initialize the grid with default values
    Public Sub InitialiseGrid()
        For i As Integer = 0 To _ycord
            For j As Integer = 0 To _xcord
                If i = _ycord And j = _xcord Then
                    grid(i, j) = "|R|"
                Else
                    grid(i, j) = "| |" ' Default value for each cell
                End If

            Next
        Next
    End Sub

    ' Method to set a specific cell in the grid
    Public Sub SetCell(x As Integer, y As Integer, value As String)
        If x >= 0 And x <= _xcord And y >= 0 And y <= _ycord Then
            grid(y, x) = value
        Else
            Console.WriteLine("Invalid coordinates!")
        End If
    End Sub

    ' Method to display the grid in the console
    Public Sub DisplayGrid()
        For i As Integer = 0 To _ycord
            For j As Integer = 0 To _xcord
                Console.Write(grid(i, j))
            Next
            Console.WriteLine() ' Move to the next line after each row
        Next
    End Sub

End Class
