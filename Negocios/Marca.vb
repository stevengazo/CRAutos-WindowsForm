Imports AccesoDatos
Imports Objetos

Public Class Marca
    Dim ObjetoAccesoDatos As New AccesoDatos.Marca

    Public Function ListarMarcas() As List(Of Objetos.Marca)
        Try
            Return ObjetoAccesoDatos.ObtenerMarcas()
        Catch ex As Exception
            Return New List(Of Objetos.Marca)
        End Try
    End Function
End Class
