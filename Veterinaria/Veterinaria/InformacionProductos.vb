Imports System.Data
Imports System.Data.SqlClient
Public Class InformacionProductos
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MenuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Comando As New SqlDataAdapter("SELECT * FROM PRODUCTO ", cn)
        Dim ds As New DataSet
        Try
            Comando.Fill(ds, "PRODUCTO")
            DataGridView1.DataSource = ds.Tables("PRODUCTO")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub InformacionProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class