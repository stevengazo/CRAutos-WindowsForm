Imports System.Net.Security
Imports System.Linq
Imports System.IO
Imports Objetos
Imports Negocios
Imports System.Threading

Public Class Form1
    Dim NegociosColor As New Negocios.Color
    Dim NegociosEstilo As New Negocios.Estilo
    Dim NegociosMarca As New Negocios.Marca
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Muestra los ultimos 10 años y el proximo año
        Dim año As Integer = DateTime.Today.Year + 1
        For index = (año - 10) To (año)
            cbAno.Items.Add(index)
        Next
        Dim listaColores As New List(Of Objetos.Color)
        listaColores = NegociosColor.ListarColores()
        For Each color As Objetos.Color In listaColores
            cbColores.Items.Add(color.Nombre)
        Next
        Dim listaEstilos As New List(Of Objetos.Estilo)
        listaEstilos = NegociosEstilo.ListarEstilos()
        For Each estilo As Objetos.Estilo In listaEstilos
            cbEstilo.Items.Add(estilo.Nombre)
        Next
        Dim listaMarcas As New List(Of Objetos.Marca)
        listaMarcas = NegociosMarca.ListarMarcas()
        For Each marca As Objetos.Marca In listaMarcas
            cbMarca.Items.Add(marca.Nombre)
        Next

        ' Agregado temporal de datos en el modulo
        'listaAutos.Add(DATA.autoEjemplo)
        'listaAutos.Add(DATA.autoEjemplo1)

        CargarDatos()

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Try
            cbAno.SelectedIndex = -1
            cbMarca.SelectedIndex = -1
            cbTransmision.SelectedIndex = -1
            txtCilindrada.Text = String.Empty
            txtModelo.Text = String.Empty
            txtKilometraje.Text = String.Empty
            cbColores.Text = String.Empty
            cbEstilo.SelectedIndex = -1
            txtPrecio.Text = String.Empty
        Catch ex As Exception
            MessageBox.Show("Error en limpieza: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim marca As String = cbMarca.Text
            Dim estilo As String = cbEstilo.Text
            Dim añotmp As String = cbAno.Text
            Dim color As String = cbColores.Text
            Dim modelo As String = txtModelo.Text
            Dim cilindradatmp As String = txtCilindrada.Text
            Dim preciotmp As String = txtPrecio.Text
            Dim transmision As String = cbTransmision.Text
            Dim kilometrajetmp As String = txtKilometraje.Text
            Dim combustible As String = cbCombustible.Text

            'Conversion de datos
            Dim precio As Double = Double.Parse(preciotmp)
            Dim kilimetraje As Integer = Integer.Parse(kilometrajetmp)
            Dim cilindrada As Integer = Integer.Parse(cilindrada)
            Dim año As Integer = Integer.Parse(añotmp)

            'Asignacion de valores
            Dim tmpAuto As New Auto With {.Cilindrada = cilindrada,
                .Color = color,
                .Combustible = combustible,
                .Estilo = estilo,
                .Kilometraje = kilometrajetmp,
                .Marca = marca,
                .Modelo = modelo,
                .Precio = precio,
                .Transmision = transmision,
                .Año = año
            }
            CargarDatos()
            MessageBox.Show("Vehiculo Agregado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error en Agregar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' Carga los datos en el datagridview en el formulario desde el Module
    ''' </summary>
    Private Sub CargarDatos()
        ' instacia de datatable
        Dim table As New DataTable
        ' definitions of the columns
        table.Columns.Add("Marca")
        table.Columns.Add("Modelo")
        table.Columns.Add("Año")
        table.Columns.Add("Color")
        table.Columns.Add("Estilo")
        table.Columns.Add("Cilindrada")
        table.Columns.Add("Transmision")
        table.Columns.Add("Combustible")
        table.Columns.Add("Kilometraje")
        table.Columns.Add("Precio")

        Dim negociosAutos As New Negocios.Automovil()

        Dim _listaAutos As New List(Of Objetos.Automovil)
        _listaAutos = negociosAutos.ObtenerLista()

        'Verificamos canidad de autos
        If _listaAutos.Count > 0 Then

            ' limpieza de columnas
            dgvListaAutos.Columns.Clear()

            For Each obj As Objetos.Automovil In _listaAutos
                table.Rows.Add(obj.Marca.Nombre, obj.Modelo, obj.Año.ToString(), obj.Color.Nombre, obj.Estilo.Nombre, obj.Cilindrada.ToString(), obj.Transmision.ToString(), obj.Combustible.ToString(), obj.Kilometraje.ToString(), obj.Precio.ToString())
            Next
            dgvListaAutos.DataSource = table
        Else
            ' MessageBox.Show("No hay datos cargados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btbBuscar_Click(sender As Object, e As EventArgs) Handles btbBuscar.Click
        Try
            Dim marcaABuscar As String = txtMarcaBusqueda.Text
            Dim añoABuscar As String = txtAnoBusqueda.Text
            If String.IsNullOrEmpty(marcaABuscar) And String.IsNullOrEmpty(añoABuscar.ToString()) Then
                MessageBox.Show("No hay datos para buscar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim listaTmp As New List(Of Auto)
                If Not String.IsNullOrEmpty(marcaABuscar) And Not String.IsNullOrEmpty(añoABuscar) Then
                    ' no se logro usando linq
                    listaTmp = listaAutos.Where(Function(d) d.Marca = marcaABuscar And d.Año.ToString() = añoABuscar).ToList()

                ElseIf String.IsNullOrEmpty(marcaABuscar) And Not String.IsNullOrEmpty(añoABuscar.ToString()) Then

                    listaTmp = listaAutos.Where(Function(d) d.Año.ToString() = añoABuscar).ToList()

                ElseIf Not String.IsNullOrEmpty(marcaABuscar) And String.IsNullOrEmpty(añoABuscar.ToString()) Then
                    listaTmp = (From carro In DATA.listaAutos Select carro).Where(Function(carro) carro.Marca.ToUpper() = marcaABuscar.ToUpper()).ToList()
                End If
                Dim table As New DataTable
                ' definitions of the columns
                table.Columns.Add("Marca")
                table.Columns.Add("Modelo")
                table.Columns.Add("Año")
                table.Columns.Add("Color")
                table.Columns.Add("Estilo")
                table.Columns.Add("Cilindrada")
                table.Columns.Add("Transmision")
                table.Columns.Add("Combustible")
                table.Columns.Add("Kilometraje")
                table.Columns.Add("Precio")
                'Verificamos canidad de autos
                If listaTmp.Count > 0 Then
                    ' limpieza de columnas
                    dgvListaAutos.Columns.Clear()
                    For Each obj As Auto In listaTmp
                        table.Rows.Add(obj.Marca, obj.Modelo, obj.Año, obj.Color, obj.Estilo, obj.Cilindrada, obj.Transmision, obj.Combustible, obj.Kilometraje, obj.Precio)
                    Next
                    dgvListaAutos.DataSource = table
                    'MessageBox.Show("Busqueda realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No hay coincidencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLimpiarBusqueda_Click(sender As Object, e As EventArgs) Handles btnLimpiarBusqueda.Click
        Try
            txtAnoBusqueda.Text = String.Empty
            txtMarcaBusqueda.Text = String.Empty
            CargarDatos()
        Catch ex As Exception
            MessageBox.Show("Error en LimpiarBusqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub ImportarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarToolStripMenuItem.Click
        Try
            listaAutos.Clear()
            OpenFileDialog1.Title = "Importar datos"
            OpenFileDialog1.Filter = "Archivo de texto plano|*.txt"

            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim url = OpenFileDialog1.FileName
                Dim reader = New StreamReader(url)
                Do While reader.Peek <> -1
                    Dim row = reader.ReadLine()
                    Dim arrayRow = row.Split(";")

                    ' valida cilindrada
                    Dim cilin As Integer
                    Try
                        cilin = Integer.Parse(arrayRow(2))
                    Catch ex As Exception
                        cilin = 0
                    End Try

                    ' valida año
                    Dim año As Integer
                    Try
                        año = Integer.Parse(arrayRow(4))
                    Catch ex As Exception
                        año = 0
                    End Try

                    ' valida precio
                    Dim precio As Integer
                    Try
                        precio = Double.Parse(arrayRow(5))
                    Catch ex As Exception
                        precio = 0
                    End Try

                    ' valida kilometraje
                    Dim kilometraje As Integer
                    Try
                        kilometraje = Integer.Parse(arrayRow(9))
                    Catch ex As Exception
                        kilometraje = 0
                    End Try

                    Dim obj As New Auto
                    obj.Marca = arrayRow(0)
                    obj.Modelo = arrayRow(1)
                    obj.Cilindrada = cilin
                    obj.Estilo = arrayRow(3)
                    obj.Año = año
                    obj.Precio = precio
                    obj.Color = arrayRow(6)
                    obj.Combustible = arrayRow(7)
                    obj.Transmision = arrayRow(8)
                    obj.Kilometraje = kilometraje

                    listaAutos.Add(obj)

                Loop
                reader.Close()
                reader.Dispose()
                CargarDatos()
                MessageBox.Show("El archivo fue cargado exitosamente. URL: " + url, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error en Importar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportarToolStripMenuItem.Click
        Try
            If DATA.listaAutos.Count > 0 Then
                SaveFileDialog1.Title = "Guardar Datos"
                SaveFileDialog1.Filter = "Archivo de texto plano|*.txt"

                If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim url = SaveFileDialog1.FileName
                    Dim row As String

                    Dim writter As New StreamWriter(url)
                    For Each obj As Auto In DATA.listaAutos
                        row = obj.Marca & ";" & obj.Modelo & ";" & obj.Cilindrada & ";" & obj.Estilo & ";" & obj.Año & ";" & obj.Precio & ";" & obj.Color & ";" & obj.Combustible & ";" & obj.Transmision & ";" & obj.Kilometraje
                        writter.WriteLine(row)
                    Next
                    writter.Close()
                    writter.Dispose()
                    MessageBox.Show("El archivo fue creado exitosamente. URL: " + url, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)


                End If
            Else
                MessageBox.Show("La lista esta vacia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error en Exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
