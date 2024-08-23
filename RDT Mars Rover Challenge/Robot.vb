Public Class Robot
    'properties: xcord, ycord, direction facing
    Protected _RXcord As Integer
    Protected _RYcord As Integer
    Protected _direction As Integer
    Dim directionDictionary As New Dictionary(Of Integer, Char)

    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal direction As Integer)
        Me._RXcord = x
        Me._RYcord = y
        Me._direction = direction
        directionDictionary.Add(0, "N")
        directionDictionary.Add(1, "E")
        directionDictionary.Add(2, "S")
        directionDictionary.Add(3, "W")
    End Sub

    Public Sub turnRight()
        'Simulates the robot turning right, wrapping the number back to 0 so that it goes back to north after west
        _direction = (_direction + 1) Mod 4
    End Sub

    Public Sub turnLeft()
        'Simulates the robot turning right, wrapping the number back to 0 so that it goes back to north after west
        _direction = (_direction - 1 + 4) Mod 4
    End Sub

    Public Function displayProperties()
        Return ("x: " & _RXcord & " | y: " & _RYcord & " | Direction: " & directionDictionary.Item(_direction))
    End Function
End Class
