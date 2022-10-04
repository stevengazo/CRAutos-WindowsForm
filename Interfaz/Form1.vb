Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbMarca.Items.AddRange(DATA.listaMarcas)

        ' Muestra los ultimos 10 años y el proximo año
        Dim año As Integer = DateTime.Today.Year + 1
        For index = (año - 10) To (año)
            cbAno.Items.Add(index)
        Next

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
End Class
