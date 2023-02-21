Imports System.Data
Imports System.Data.SqlClient
Public Class Mascota
    Dim strCodigo As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If nombre.Text = "" Then
                MsgBox("Debes ingresar datos necesarios")
                nombre.Focus()
            Else
                Dim XG As New SqlCommand("SP_MASCOTA", cn)
                XG.CommandType = CommandType.StoredProcedure
                XG.Parameters.Add(New SqlParameter("@ID_MASC", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = (id.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@NOM_MASC", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (nombre.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@ESPECIE", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (especie.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@RAZA", SqlDbType.VarChar, 40, ParameterDirection.Input)).Value = (raza.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@SEXO", SqlDbType.VarChar, 1, ParameterDirection.Input)).Value = (sexo.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@ID_CLI", SqlDbType.VarChar, 70, ParameterDirection.Input)).Value = (Label7.Text).ToUpper

                cn.Open()
                XG.ExecuteNonQuery()
                cn.Close()
                MessageBox.Show("Mascota Registrado", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                limpiar()
                GENERACODIGO()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try

    End Sub
    Sub limpiar()
        id.Text = ""
        nombre.Text = ""
        especie.Text = ""
        raza.Text = ""
        sexo.Text = ""
        ComboBox1.Text = ""
        Label7.Text = ""
    End Sub
    Sub GENERACODIGO()
        Dim cmd As New SqlCommand("SELECT MAX(CAST(ID_MASC AS int)) FROM MASCOTA", cn)
        cn.Open()
        strCodigo = cmd.ExecuteScalar
        cn.Close()
        id.Text = Format(Val(strCodigo) + 1, "000000")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        MenuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Mascota_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        cargar_dueño()
        limpiar()
        GENERACODIGO()
    End Sub
    Sub cargar_dueño()
        Try
            Dim DA As New SqlDataAdapter("Select * From cliente", cn)
            Dim DS As New DataSet
            DA.Fill(DS, "cliente")
            ComboBox1.DataSource = DS.Tables("cliente")
            ComboBox1.DisplayMember = ("nom_cli")
            ' cbocate.ValueMember = "nom_des"
            Label7.Text = DS.Tables("cliente").Rows(0)("id_cli")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Focused = True Then
            Label7.Text = ComboBox1.SelectedItem.Row("ID_CLI")
            ' Label1.Text = Producto.SelectedItem.Row("ID_PRO")

        End If
    End Sub
End Class