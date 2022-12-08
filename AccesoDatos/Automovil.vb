Imports Objetos
Imports System.Data.SqlClient
Imports System.Net.Http.Headers

Public Class Automovil
    Dim conexion As New SqlConnection(GENERALES.DBCRAutos)

    Public Function ListarAutos() As List(Of Objetos.Automovil)
        Try
            Dim _dataSet As New DataSet()
            Dim listaAutos As New List(Of Objetos.Automovil)
            Dim comando As New SqlCommand
            comando.CommandText = "SELECT A.*,m.Nombre,E.NombreEstilo, C.Nombre  FROM AutoMovil  AS A LEFT JOIN Marca AS M ON M.idMarca = A.idMarca  LEFT JOIN Estilo AS E ON E.idEstilo = A.idEstilo LEFT JOIN COLOR AS  C ON C.idColor = A.idColor"
            comando.CommandType = CommandType.Text
            comando.Connection = conexion

            ' automoviles
            conexion.Open()
            Dim adapter As New SqlDataAdapter(comando)
            adapter.Fill(_dataSet, "AutoMovil")
            conexion.Close()



            For Each row In _dataSet.Tables(0).Rows
                Dim tmp As New Objetos.Automovil()
                tmp.idAutomovil = Integer.Parse(row(0))
                tmp.Año = Integer.Parse(row(1))
                tmp.Modelo = row(2)
                tmp.Cilindrada = Integer.Parse(row(3))
                tmp.Precio = Double.Parse(row(4))
                tmp.Transmision = row(5)
                tmp.Combustible = Integer.Parse(row(6))
                tmp.Kilometraje = Integer.Parse(row(7))
                tmp.idcolor = Integer.Parse(row(8))
                tmp.idEstilo = Integer.Parse(row(9))
                tmp.idMarca = Integer.Parse(row(10))
                Dim tmpMarca As New Objetos.Marca()
                tmpMarca.idMarca = tmp.idMarca
                tmpMarca.Nombre = row(11)
                tmp.Marca = tmpMarca
                Dim tmpEstilo As New Objetos.Estilo
                tmpEstilo.idEstilo = tmp.idEstilo
                tmpEstilo.Nombre = row(12)
                tmp.Estilo = tmpEstilo
                Dim tmpColor As New Objetos.Color
                tmpColor.idColor = tmp.idcolor
                tmpColor.Nombre = row(13)
                tmp.Color = tmpColor
                listaAutos.Add(tmp)
            Next


            Return listaAutos
        Catch ex As Exception
            Return New List(Of Objetos.Automovil)
        End Try
    End Function
End Class
