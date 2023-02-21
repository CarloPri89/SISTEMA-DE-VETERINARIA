Imports System.Data
Imports System.Data.SqlClient
Public Class InformacionVenta
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MenuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Comando As New SqlDataAdapter("SELECT * FROM VENTAS ", cn)
        Dim ds As New DataSet
        Try
            Comando.Fill(ds, "VENTAS")
            DataGridView1.DataSource = ds.Tables("VENTAS")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            'If cn.State = ConnectionState.Open Then cn.Close()
            'cn.Dispose()
            'Comando.Dispose()
            'ds.Dispose()
            cn.Close()
        End Try
    End Sub

    Private Sub InformacionVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class