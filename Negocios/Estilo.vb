Imports AccesoDatos
Imports Objetos

Public Class Estilo
    Dim ObjetoAccesoDatos As New AccesoDatos.Estilo

    Public Function ListarEstilos() As List(Of Objetos.Estilo)
        Try
            Return ObjetoAccesoDatos.ObtenerEstilos()
        Catch ex As Exception
            Return New List(Of Objetos.Estilo)
        End Try
    End Function
End Class
