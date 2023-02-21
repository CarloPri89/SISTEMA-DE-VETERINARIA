Imports System.Data
Imports System.Data.SqlClient
Public Class Servicio
    Dim strCodigo As String
    Sub GENERACODIGO()
        Dim cmd As New SqlCommand("select max(ID_SERV) from SERVICIO", cn)
        cn.Open()

        Try
            strCodigo = cmd.ExecuteScalar
            cn.Close()
        Catch ex As Exception
            strCodigo = 0
            cn.Close()
        End Try




        id.Text = Format(Val(strCodigo) + 1, "00000")
            TextBox1.Text = Format(Now, "dd-MM-yyyy")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If emp.Text = "" Or Label1.Text = "" Or cliente.Text = "" Or tipo.Text = "" Then
                MessageBox.Show("Debes ingresar datos necesarios", "sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)

            Else
                Dim XG As New SqlCommand("SP_SERVICIO", cn)
                XG.CommandType = CommandType.StoredProcedure
                XG.Parameters.Add(New SqlParameter("@ID_SERV", SqlDbType.VarChar, 40, ParameterDirection.Input)).Value = (id.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@ID_EMP", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (Label8.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@ID_CLI", SqlDbType.VarChar, 70, ParameterDirection.Input)).Value = (Label9.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@ID_MASC", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = (Label11.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@TIPO_SERV", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (tipo.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@PRECIO_SERV", SqlDbType.Money, ParameterDirection.Input)).Value = (precio.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@FECHA_REGISTRO", SqlDbType.DateTime, ParameterDirection.Input)).Value = (TextBox1.Text).ToUpper

                cn.Open()
                XG.ExecuteNonQuery()
                cn.Close()
                MessageBox.Show("Servicio Registrado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LIMPIAR()
                GENERACODIGO()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LIMPIAR()
        GENERACODIGO()
    End Sub
    Sub LIMPIAR()
        id.Text = ""
        emp.Text = ""
        cliente.Text = ""
        MASCOTA.Text = ""
        tipo.Text = ""
        precio.Text = ""
        Label8.Text = ""
        Label9.Text = ""
        Label11.Text = ""
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs)
        MenuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub Servicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_Cliente()
        ' cargar_MASCOTA()
        cargar_tiposervicio()
        cargar_empleado()

        LIMPIAR()
        GENERACODIGO()
    End Sub
    Sub cargar_tiposervicio()
        Try
            Dim DA As New SqlDataAdapter("Select * From Tipo_Servicio", cn)
            Dim DS As New DataSet
            DA.Fill(DS, "servicio")
            tipo.DataSource = DS.Tables("servicio")
            tipo.DisplayMember = ("Descripcion")
            ' cbocate.ValueMember = "nom_des"
            precio.Text = DS.Tables("servicio").Rows(0)("Precio")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub
    Sub cargar_MASCOTA()
        Try
            Dim DA As New SqlDataAdapter("Select * From mascota where id_cli='" & Label9.Text & "'", cn)
            Dim DS As New DataSet
            DA.Fill(DS, "mascota")
            MASCOTA.DataSource = DS.Tables("mascota")
            MASCOTA.DisplayMember = ("NOM_MASC")
            ' cbocate.ValueMember = "nom_des"
            Label11.Text = DS.Tables("mascota").Rows(0)("ID_MASC")

        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub
    Sub cargar_empleado()
        Try
            Dim DA As New SqlDataAdapter("Select * From empleado", cn)
            Dim DS As New DataSet
            DA.Fill(DS, "empleado")
            emp.DataSource = DS.Tables("empleado")
            emp.DisplayMember = ("NOM_EMP")
            ' cbocate.ValueMember = "nom_des"
            Label8.Text = DS.Tables("empleado").Rows(0)("ID_EMP")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub
    Sub cargar_Cliente()
        Try
            Dim DA As New SqlDataAdapter("Select * From cliente", cn)
            Dim DS As New DataSet
            DA.Fill(DS, "cliente")
            cliente.DataSource = DS.Tables("cliente")
            cliente.DisplayMember = ("nom_cli")
            ' cbocate.ValueMember = "nom_des"
            Label9.Text = DS.Tables("cliente").Rows(0)("ID_CLI")

        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub

    Private Sub tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tipo.SelectedIndexChanged
        If tipo.Focused = True Then
            precio.Text = tipo.SelectedItem.Row("Precio")
            ' Label1.Text = Producto.SelectedItem.Row("ID_PRO")

        End If
    End Sub

    Private Sub emp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles emp.SelectedIndexChanged
        If emp.Focused = True Then
            Label8.Text = emp.SelectedItem.Row("ID_EMP")
            ' Label1.Text = Producto.SelectedItem.Row("ID_PRO")

        End If
    End Sub

    Private Sub cliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cliente.SelectedIndexChanged
        If cliente.Focused = True Then
            Label9.Text = cliente.SelectedItem.Row("ID_CLI")

        End If
        cargar_MASCOTA()
    End Sub

    Private Sub MASCOTA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MASCOTA.SelectedIndexChanged
        If MASCOTA.Focused = True Then
            Label11.Text = MASCOTA.SelectedItem.Row("ID_MASC")


        End If
    End Sub
End Class