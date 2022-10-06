Imports System.Net.Security
Imports System.Linq

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbMarca.Items.AddRange(DATA.listaMarcas)

        ' Muestra los ultimos 10 años y el proximo año
        Dim año As Integer = DateTime.Today.Year + 1
        For index = (año - 10) To (año)
            cbAno.Items.Add(index)
        Next

        ' Agregado temporal de datos en el modulo
        listaAutos.Add(DATA.autoEjemplo)
        listaAutos.Add(DATA.autoEjemplo1)

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
            txtColor.Text = String.Empty
            txtEstilo.Text = String.Empty
            txtPrecio.Text = String.Empty
        Catch ex As Exception
            MessageBox.Show("Error en limpieza: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim marca As String = cbMarca.Text
            Dim estilo As String = txtEstilo.Text
            Dim añotmp As String = cbAno.Text
            Dim color As String = txtColor.Text
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
            DATA.listaAutos.Add(tmpAuto)
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


        'Verificamos canidad de autos
        If DATA.listaAutos.Count > 0 Then

            ' limpieza de columnas
            dgvListaAutos.Columns.Clear()

            For Each obj As Auto In listaAutos
                table.Rows.Add(obj.Marca, obj.Modelo, obj.Año, obj.Color, obj.Estilo, obj.Cilindrada, obj.Transmision, obj.Combustible, obj.Kilometraje, obj.Precio)
            Next
            dgvListaAutos.DataSource = table

        Else
            MessageBox.Show("No hay datos cargados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                    listaTmp = listaAutos.Where(Function(d) d.Marca.Contains(marcaABuscar) And d.Año.ToString() = añoABuscar).ToList()

                ElseIf String.IsNullOrEmpty(marcaABuscar) And Not String.IsNullOrEmpty(añoABuscar.ToString()) Then

                    listaTmp = listaAutos.Where(Function(d) d.Año.ToString() = añoABuscar).ToList()

                ElseIf Not String.IsNullOrEmpty(marcaABuscar) And String.IsNullOrEmpty(añoABuscar.ToString()) Then

                    listaTmp = (From carro In DATA.listaAutos Select carro).Where(Function(carro) carro.Marca = marcaABuscar).ToList()


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
                    MessageBox.Show("Busqueda realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No hay datos cargados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
End Class
