Imports Objetos
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging

Public Class Marca
    Dim conexion As New SqlConnection(GENERALES.DBCRAutos)


    ''' <summary>
    ''' Trae los marca de la DB
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerMarcas() As List(Of Objetos.Marca)
        Try
            Dim _dataSet As New DataSet()
            Dim listaMarcas As New List(Of Objetos.Marca)
            Dim comando As New SqlCommand()
            comando.CommandText = "Select * from Marca"
            comando.CommandType = CommandType.Text
            comando.Connection = conexion
            'db conexion
            conexion.Open()
            Dim adaptador As New SqlDataAdapter(comando)
            adaptador.Fill(_dataSet, "Marca")
            conexion.Close()
            For Each row In _dataSet.Tables(0).Rows
                Dim tmp As New Objetos.Marca()
                tmp.idMarca = Integer.Parse(row(0))
                tmp.Nombre = row(1)
                listaMarcas.Add(tmp)
            Next
            Return listaMarcas
        Catch ex As Exception
            Return New List(Of Objetos.Marca)
        End Try
    End Function
End Class
