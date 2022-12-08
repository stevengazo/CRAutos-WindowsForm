Imports Objetos
Imports AccesoDatos

Public Class Automovil
    Dim ConexionAccesoDatos As New AccesoDatos.Automovil

    Public Function AgregarAuto(auto As Objetos.Automovil) As Boolean
        Try
            Dim idAuto As Integer = ConexionAccesoDatos.InsertarAuto(auto)
            If idAuto <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ObtenerLista() As List(Of Objetos.Automovil)
        Try
            Return ConexionAccesoDatos.ListarAutos()
        Catch ex As Exception
            Console.Write(ex.Message)
            Return New List(Of Objetos.Automovil)
        End Try
    End Function

    ''' <summary>
    ''' Pasa un id a la db y lo elimina
    ''' </summary>
    ''' <param name="idauto"></param>
    ''' <returns>false si presenta error, true si lo elimina</returns>
    Public Function BorrarAutomovil(idauto As Integer) As Boolean
        Try
            Dim codigo As Integer = ConexionAccesoDatos.BorrarAuto(idauto)
            If codigo = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Console.Write(ex.Message)
            Return False
        End Try
    End Function
End Class
