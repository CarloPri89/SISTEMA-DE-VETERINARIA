Imports System.Data
Imports System.Data.SqlClient
Public Class Cliente
    Dim strCodigo As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim XG As New SqlCommand("SP_CLIENTE", cn)
            XG.CommandType = CommandType.StoredProcedure
            XG.Parameters.Add(New SqlParameter("@ID_CLI", SqlDbType.VarChar, 70, ParameterDirection.Input)).Value = (id.Text).ToUpper
            XG.Parameters.Add(New SqlParameter("@NOM_CLI", SqlDbType.VarChar, 30, ParameterDirection.Input)).Value = (nombre.Text).ToUpper
            XG.Parameters.Add(New SqlParameter("@APE_CLI", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (apellido.Text).ToUpper
            XG.Parameters.Add(New SqlParameter("@DNI", SqlDbType.VarChar, 30, ParameterDirection.Input)).Value = (dni.Text).ToUpper
            XG.Parameters.Add(New SqlParameter("@SEXO", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (sexo.Text).ToUpper
            XG.Parameters.Add(New SqlParameter("@DIRECCION", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (direccion.Text).ToUpper
            XG.Parameters.Add(New SqlParameter("@TELEFONO", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (telefono.Text).ToUpper

            cn.Open()
            XG.ExecuteNonQuery()
            cn.Close()
            MessageBox.Show("Cliente Registrado", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            limpiar()

        Catch ex As Exception
            Throw
        End Try




    End Sub
    Sub GENERACODIGO()
        Dim cmd As New SqlCommand("select max(SUBSTRING(ID_CLI, 4, 3)) from cliente", cn)
        cn.Open()
        strCodigo = cmd.ExecuteScalar
        cn.Close()
        id.Text = Format(Val(strCodigo) + 1, "CLI000")
    End Sub
    Sub limpiar()
        id.Text = ""
        nombre.Text = ""
        apellido.Text = ""
        dni.Text = ""
        sexo.Text = ""
        direccion.Text = ""
        telefono.Text = ""
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        MenuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub Cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id.Focus()
        GENERACODIGO()

    End Sub
End Class