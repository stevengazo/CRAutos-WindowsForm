Imports Objetos
Imports AccesoDatos

Public Class Automovil
    Dim ConexionAccesoDatos As New AccesoDatos.Automovil

    Public Function ObtenerLista() As List(Of Objetos.Automovil)
        Try
            Return ConexionAccesoDatos.ListarAutos()
        Catch ex As Exception
            Console.Write(ex.Message)
            Return New List(Of Objetos.Automovil)
        End Try
    End Function
End Class
