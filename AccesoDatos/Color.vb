Imports Objetos
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging

Public Class Color
    Dim conexion As New SqlConnection(GENERALES.DBCRAutos)


    ''' <summary>
    ''' Trae los colores de la DB
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerColores() As List(Of Objetos.Color)
        Try
            Dim _dataSet As New DataSet()
            Dim listaColores As New List(Of Objetos.Color)
            Dim comando As New SqlCommand()
            comando.CommandText = "Select * from Color"
            comando.CommandType = CommandType.Text
            comando.Connection = conexion
            'db conexion
            conexion.Open()
            Dim adaptador As New SqlDataAdapter(comando)
            adaptador.Fill(_dataSet, "Color")
            conexion.Close()
            For Each row In _dataSet.Tables(0).Rows
                Dim tmpColor As New Objetos.Color()
                tmpColor.idColor = Integer.Parse(row(0))
                tmpColor.Nombre = row(1)
                listaColores.Add(tmpColor)
            Next
            Return listaColores
        Catch ex As Exception
            Return New List(Of Objetos.Color)
        End Try
    End Function
End Class
