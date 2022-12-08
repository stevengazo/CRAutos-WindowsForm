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
    Dim NegocioAuto As New Negocios.Automovil

    Dim listaColores As New List(Of Objetos.Color)
    Dim listaMarcas As New List(Of Objetos.Marca)
    Dim listaEstilos As New List(Of Objetos.Estilo)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Muestra los ultimos 10 años y el proximo año
        Dim año As Integer = DateTime.Today.Year + 1
        For index = (año - 10) To (año)
            cbAno.Items.Add(index)
        Next

        listaColores = NegociosColor.ListarColores()
        For Each color As Objetos.Color In listaColores
            cbColores.Items.Add(color.Nombre)
        Next

        listaEstilos = NegociosEstilo.ListarEstilos()
        For Each estilo As Objetos.Estilo In listaEstilos
            cbEstilo.Items.Add(estilo.Nombre)
        Next

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
            Dim auto As New Objetos.Automovil()
            Dim marca As String = cbMarca.Text
            Dim estilo As String = cbEstilo.Text
            Dim color As String = cbColores.Text

            For Each _marca As Objetos.Marca In listaMarcas
                If _marca.Nombre.Equals(marca) Then
                    auto.idMarca = _marca.idMarca
                    auto.Marca = _marca
                    Exit For
                Else
                    auto.idMarca = 0
                End If
            Next

            For Each _color As Objetos.Color In listaColores
                If _color.Nombre.Equals(color) Then
                    auto.idcolor = _color.idColor
                    auto.Color = _color
                    Exit For
                Else
                    auto.idcolor = 0
                End If
            Next
            For Each _estilo As Objetos.Estilo In listaEstilos
                If _estilo.Nombre.Equals(estilo) Then
                    auto.idEstilo = _estilo.idEstilo
                    auto.Estilo = _estilo
                    Exit For
                Else
                    auto.idEstilo = 0
                End If
            Next
            auto.Año = Integer.Parse(cbAno.Text)
            auto.Modelo = txtModelo.Text
            auto.Cilindrada = Integer.Parse(txtCilindrada.Text)
            auto.Precio = Double.Parse(txtPrecio.Text)
            auto.Transmision = cbTransmision.Text
            auto.Kilometraje = Integer.Parse(txtKilometraje.Text)
            auto.Combustible = cbCombustible.Text

            Dim bandera As Boolean = NegocioAuto.AgregarAuto(auto)
            If bandera Then
                CargarDatos()
                MessageBox.Show("Vehiculo Agregado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error en Agregar auto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' Carga los datos en el datagridview en el formulario desde el Module
    ''' </summary>
    Private Sub CargarDatos()
        ' instacia de datatable
        Dim table As New DataTable
        ' definitions of the columns
        table.Columns.Add("id")
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
                table.Rows.Add(obj.idAutomovil, obj.Marca.Nombre, obj.Modelo, obj.Año.ToString(), obj.Color.Nombre, obj.Estilo.Nombre, obj.Cilindrada.ToString(), obj.Transmision.ToString(), obj.Combustible.ToString(), obj.Kilometraje.ToString(), obj.Precio.ToString())
            Next
            dgvListaAutos.DataSource = table

            'agregar un boton por cada fila que exista en la tabla
            Dim btn As New DataGridViewButtonColumn
            btn.HeaderText = "Borrar"
            btn.Text = "Borrar"
            btn.Name = "Borrar"
            btn.UseColumnTextForButtonValue = True

            dgvListaAutos.Columns.Add(btn)


        Else
            ' MessageBox.Show("No hay datos cargados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub



    Private Sub btnLimpiarBusqueda_Click(sender As Object, e As EventArgs)
        Try

            CargarDatos()
        Catch ex As Exception
            MessageBox.Show("Error en LimpiarBusqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub


    Private Sub dgvListaAutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListaAutos.CellContentClick
        If e.ColumnIndex = 11 Then
            Dim row = dgvListaAutos.Rows(e.RowIndex)
            Dim cells = row.Cells
            Dim id = Integer.Parse(cells.Item(0).Value)
            Dim bandera = NegocioAuto.BorrarAutomovil(id)
            If bandera Then
                CargarDatos()
            Else
                MessageBox.Show("Error al borrar auto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
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
