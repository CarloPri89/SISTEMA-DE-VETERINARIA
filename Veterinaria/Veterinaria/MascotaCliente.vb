Imports System.Data
Imports System.Data.SqlClient
Public Class MascotaCliente
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MenuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim da = New SqlDataAdapter(" select CLIENTE.NOM_CLI as 'Su dueño', mascota.ID_MASC,mascota.NOM_MASC,mascota.ESPECIE,mascota.RAZA,mascota.SEXO from MASCOTA
inner join CLIENTE on CLIENTE.ID_CLI=MASCOTA.id_cli", cn)
        Dim dt = New DataTable
        da.Fill(dt)
        Me.DataGridView1.DataSource = dt

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) 
    End Sub

    Private Sub MascotaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class