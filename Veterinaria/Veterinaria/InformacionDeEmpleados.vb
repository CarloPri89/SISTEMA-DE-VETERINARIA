Imports System.Data
Imports System.Data.SqlClient

Public Class InformacionDeEmpleados
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        MenuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub InformacionDeEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim da As New SqlDataAdapter("select*from empleado", cn)
        Dim dt As New DataTable
        da.Fill(dt)
        Me.DataGridView1.DataSource = dt
    End Sub
End Class