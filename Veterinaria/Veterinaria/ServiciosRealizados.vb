Imports System.Data
Imports System.Data.SqlClient
Public Class ServiciosRealizados
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MenuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Comando As New SqlDataAdapter("SELECT * FROM SERVICIO", cn)
        Dim ds As New DataSet
        Try
            Comando.Fill(ds, "SERVICIO")
            DataGridView1.DataSource = ds.Tables("SERVICIO")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ' If cn.State = ConnectionState.Open Then cn.Close()
            'cn.Dispose()
            'Comando.Dispose()
            'ds.Dispose()
            cn.Close()
        End Try
    End Sub

    Private Sub ServiciosRealizados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        reportes.Show()

    End Sub
End Class