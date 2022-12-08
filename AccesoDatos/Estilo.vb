Imports Objetos
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging

Public Class Estilo
    Dim conexion As New SqlConnection(GENERALES.DBCRAutos)


    ''' <summary>
    ''' Trae los estilos de la DB
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerEstilos() As List(Of Objetos.Estilo)
        Try
            Dim _dataSet As New DataSet()
            Dim listaEstilos As New List(Of Objetos.Estilo)
            Dim comando As New SqlCommand()
            comando.CommandText = "Select * from Estilo"
            comando.CommandType = CommandType.Text
            comando.Connection = conexion
            'db conexion
            conexion.Open()
            Dim adaptador As New SqlDataAdapter(comando)
            adaptador.Fill(_dataSet, "Estilo")
            conexion.Close()
            For Each row In _dataSet.Tables(0).Rows
                Dim tmp As New Objetos.Estilo()
                tmp.idEstilo = Integer.Parse(row(0))
                tmp.Nombre = row(1)
                listaEstilos.Add(tmp)
            Next
            Return listaEstilos
        Catch ex As Exception
            Return New List(Of Objetos.Estilo)
        End Try
    End Function
End Class
