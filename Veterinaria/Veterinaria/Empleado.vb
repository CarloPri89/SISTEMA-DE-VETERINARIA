Imports System.Data
Imports System.Data.SqlClient

Public Class Empleado
    Dim strCodigo As String
    Private Sub Empleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GENERACODIGO()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        MenuPrincipal.Show()
        Me.Hide()
    End Sub
    Sub GENERACODIGO()
        Dim cmd As New SqlCommand("select max(ID_EMP)from EMPLEADO", cn)
        cn.Open()
        strCodigo = cmd.ExecuteScalar
        cn.Close()
        id.Text = Format(Val(strCodigo) + 1, "000000")
    End Sub
    Sub limpiar()
        id.Text = ""
        nombre.Text = ""
        apellido.Text = ""
        sexo.Text = ""
        dni.Text = ""
        direccion.Text = ""
        telefono.Text = ""
        email.Text = ""
        turno.Text = ""
        Me.DateTimePicker1.Text = ""
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If nombre.Text = "" Then
                MsgBox("Debes ingresar datos necesarios")
            Else
                Dim XG As New SqlCommand("SP_EMPLEADO", cn)
                XG.CommandType = CommandType.StoredProcedure
                XG.Parameters.Add(New SqlParameter("@ID_EMP", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (id.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@NOM_EMP", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = (nombre.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@APELLIDOS", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (apellido.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@SEXO", SqlDbType.VarChar, 30, ParameterDirection.Input)).Value = (sexo.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@DNI", SqlDbType.VarChar, 30, ParameterDirection.Input)).Value = (dni.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@DIRECCION", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (direccion.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@TELEFONO", SqlDbType.VarChar, 30, ParameterDirection.Input)).Value = (telefono.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@EMAIL", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (email.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@TURNO", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = (turno.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@FECHA_CONTRATA", SqlDbType.DateTime, ParameterDirection.Input)).Value = (DateTimePicker1.Text).ToUpper

                cn.Open()
                XG.ExecuteNonQuery()
                cn.Close()
                MessageBox.Show("Empleado Registrado", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                limpiar()
                GENERACODIGO()
            End If
        Catch ex As Exception
            Throw
        End Try



    End Sub
End Class
