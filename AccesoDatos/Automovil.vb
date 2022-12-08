Imports Objetos
Imports System.Data.SqlClient
Imports System.Net.Http.Headers
Imports System.Runtime.InteropServices.WindowsRuntime

Public Class Automovil
    Dim conexion As New SqlConnection(GENERALES.DBCRAutos)



    ''' <summary>
    ''' Busca y elimina un auto de la DB
    ''' </summary>
    ''' <param name="idAuto">identificador del auto</param>
    ''' <returns>0 si no hay errores</returns>
    Public Function BorrarAuto(idAuto As Integer) As Integer
        Try
            Dim _comando As New SqlCommand()
            _comando.CommandText = "[dbo].[EliminarAuto]"
            _comando.CommandType = CommandType.StoredProcedure
            _comando.Connection = conexion
            'son parametros de entrada
            _comando.Parameters.Add("@idAutoMovil", SqlDbType.Int).Value = idAuto
            'agregar los parametros de salida
            _comando.Parameters.Add("@ErrorMessage", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output
            _comando.Parameters.Add("@ErrorCode", SqlDbType.Int).Direction = ParameterDirection.Output

            conexion.Open()
            _comando.ExecuteNonQuery()
            conexion.Close()
            If _comando.Parameters("@ErrorCode").Value = 0 Then
                Return 0
            Else
                Return _comando.Parameters("@ErrorCode").Value
            End If
        Catch ex As Exception
            Return 1
        End Try
    End Function
    Public Function InsertarAuto(auto As Objetos.Automovil) As Integer
        Try
            Dim idAuto As Integer = 0
            Dim _comando As New SqlCommand()
            _comando.CommandText = "[dbo].[AgregarAutomovil]"
            _comando.CommandType = CommandType.StoredProcedure
            _comando.Connection = conexion
            'son parametros de entrada
            _comando.Parameters.Add("@idMarca", SqlDbType.Int).Value = auto.idMarca
            _comando.Parameters.Add("@idEstilo", SqlDbType.Int).Value = auto.idEstilo
            _comando.Parameters.Add("@idColor", SqlDbType.Int).Value = auto.idcolor
            _comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 30).Value = auto.Modelo
            _comando.Parameters.Add("@Año", SqlDbType.Int).Value = auto.Año
            _comando.Parameters.Add("@Cilindrada", SqlDbType.Int).Value = auto.Cilindrada
            _comando.Parameters.Add("@Precio", SqlDbType.Float).Value = auto.Precio
            _comando.Parameters.Add("@Transmision", SqlDbType.VarChar, 30).Value = auto.Transmision
            _comando.Parameters.Add("@Combustible", SqlDbType.VarChar, 15).Value = auto.Combustible
            _comando.Parameters.Add("@Kilometraje", SqlDbType.Int).Value = auto.Kilometraje
            'agregar los parametros de salida
            _comando.Parameters.Add("@ErrorMessage", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output
            _comando.Parameters.Add("@ErrorCode", SqlDbType.Int).Direction = ParameterDirection.Output
            _comando.Parameters.Add("@idAutoMovil", SqlDbType.Int).Direction = ParameterDirection.Output
            conexion.Open()
            _comando.ExecuteNonQuery()
            conexion.Close()
            If _comando.Parameters("@ErrorCode").Value = 0 Then
                Return _comando.Parameters("@idAutoMovil").Value
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function
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
