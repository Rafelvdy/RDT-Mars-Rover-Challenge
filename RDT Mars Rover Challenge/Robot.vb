Public Class Robot
    ' Properties: xcord, ycord, direction facing
    Protected _RXcord As Integer
    Protected _RYcord As Integer
    Protected _direction As Integer
    Private _tempdirection As String
    Private _isFirstMove As Boolean = True ' Flag to check first move
    Dim directionDictionary As New Dictionary(Of Integer, Char)

    Public Sub New(ByVal xcord As Integer, ByVal ycord As Integer, ByVal direction As Integer)
        Me._RXcord = xcord
        Me._RYcord = ycord
        Me._direction = direction
        'Acting as my compass so that when displaying direction it can be displayed as a letter
        directionDictionary.Add(0, "N")
        directionDictionary.Add(1, "E")
        directionDictionary.Add(2, "S")
        directionDictionary.Add(3, "W")
    End Sub

    Public Property direction As String
        Set(value As String)
            _tempdirection = value
        End Set
        Get
            Return _tempdirection
        End Get
    End Property

    Public Sub dictionaryConverter()
        For Each key As Integer In directionDictionary.Keys
            If directionDictionary(key) = _tempdirection Then
                _direction = key
            End If
        Next
    End Sub

    Public Sub turnRight()
        ' Simulates the robot turning right, wrapping the number back to 0 so that it goes back to north after west
        'Imagine placing the numbers at the directions and the robot spinning, it has to loop back round
        _direction = (_direction + 1) Mod 4
    End Sub

    Public Sub turnLeft()
        ' Simulates the robot turning left, wrapping the number back to 0 so that it goes back to north after west
        _direction = (_direction - 1 + 4) Mod 4
    End Sub

    Public Sub moveFoward()
        If _direction = 0 Then
            _RYcord += 1
        ElseIf _direction = 1 Then
            _RXcord += 1
        ElseIf _direction = 2 Then
            _RYcord -= 1
        ElseIf _direction = 3 Then
            _RXcord -= 1
        End If
    End Sub

    Public Function displayProperties() As String
        Return ("x: " & _RXcord & " | y: " & _RYcord & " | Direction: " & directionDictionary.Item(_direction))
    End Function

    ' Getter methods to access the robot's properties
    Public Function GetX() As Integer
        Return _RXcord
    End Function

    Public Function GetY() As Integer
        Return _RYcord
    End Function

    Public Function GetDirection() As Char
        Return directionDictionary.Item(_direction)
    End Function


    ' Method checking it the rover is on its first move or if it has already moved more then onc 
    Public Function IsFirstMove() As Boolean
        Return _isFirstMove
    End Function

    ' Method will flag the rover as first move aslong as the move is the first move
    ' If not here, will Leave a P after every move
    Public Sub SetFirstMove(value As Boolean)
        _isFirstMove = value
    End Sub
End Class