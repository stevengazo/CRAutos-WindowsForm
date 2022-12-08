Imports AccesoDatos
Imports Objetos

Public Class Color
    Dim ObjetoAccesoDatos As New AccesoDatos.Color

    Public Function ListarColores() As List(Of Objetos.Color)
        Try
            Return ObjetoAccesoDatos.ObtenerColores()
        Catch ex As Exception
            Return New List(Of Objetos.Color)
        End Try
    End Function
End Class
