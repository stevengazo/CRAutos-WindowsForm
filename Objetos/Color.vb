Public Class Color
    Public idColor As Integer
    Public Nombre As String
    ''' <summary>
    ''' constructor
    ''' </summary>
    ''' <param name="_idColor">id de tipo entero</param>
    ''' <param name="_Nombre">nombre del color</param>
    Public Sub Color(_idColor As Integer, _Nombre As String)
        idColor = _idColor
        Nombre = _Nombre
    End Sub
End Class
