Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class Ventas
    Dim strcomando As String
    Dim strCodigo As String
    Dim adapter As SqlDataAdapter
    Dim data As DataSet
    Private Sub Button3_Click(sender As Object, e As EventArgs)
        MenuPrincipal.Show()
        Me.Hide()
    End Sub
    Sub GENERACODIGO()
        Dim cmd As New SqlCommand("select max(ID_VENTAS) from VENTAS", cn)
        cn.Open()

        Try
            strCodigo = cmd.ExecuteScalar
        Catch ex As Exception
            strCodigo = 0
        End Try


        cn.Close()
        NRO.Text = Format(Val(strCodigo) + 1, "000000")
        'fecha.Text = Format(Now, "dd-MM-yyyy")
        fecha.Text = Now

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If producto.Text = "" Or Label1.Text = "" Or Label9.Text = "" Or cantidad.Text = "" Then
                MessageBox.Show("Debes ingresar datos necesarios", "sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                producto.Focus()
            Else
                Dim XG As New SqlCommand("SP_VENTAS", cn)
                XG.CommandType = CommandType.StoredProcedure
                XG.Parameters.Add(New SqlParameter("@ID_VENTAS", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = (NRO.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@ID_EMP", SqlDbType.VarChar, 70, ParameterDirection.Input)).Value = (Label9.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@ID_PRO", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (Label1.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@TIPO_PRODUCTO", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (producto.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@CANTIDAD", SqlDbType.VarChar, 1000, ParameterDirection.Input)).Value = (cantidad.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@PRECIO_SOLES", SqlDbType.Money, ParameterDirection.Input)).Value = (precio.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@HORA_VENTA", SqlDbType.DateTime, ParameterDirection.Input)).Value = (fecha.Text).ToUpper

                cn.Open()
                XG.ExecuteNonQuery()
                cn.Close()
                MessageBox.Show("Venta Registrado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                limpiar()
                GENERACODIGO()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub
    Sub cargar_empleados()
        Try
            Dim DA As New SqlDataAdapter("Select * From empleado", cn)
            Dim DS As New DataSet
            DA.Fill(DS, "empleado")
            emp.DataSource = DS.Tables("empleado")
            emp.DisplayMember = ("NOM_EMP")
            ' cbocate.ValueMember = "nom_des"
            Label9.Text = DS.Tables("empleado").Rows(0)("ID_EMP")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub
    Sub cargar_productos()
        Try
            Dim DA As New SqlDataAdapter("Select * From producto", cn)
            Dim DS As New DataSet
            DA.Fill(DS, "producto")
            producto.DataSource = DS.Tables("producto")
            producto.DisplayMember = ("TIPO_PRODUCTO_REGISTRADO")
            ' cbocate.ValueMember = "nom_des"
            precio.Text = DS.Tables("producto").Rows(0)("PRECIO")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Controlado")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()
        GENERACODIGO()
    End Sub
    Sub limpiar()
        'venta.Text = ""
        emp.Text = ""
        NRO.Text = ""
        producto.Text = ""
        cantidad.Text = ""
        precio.Text = ""
        Label1.Text = ""
        Label9.Text = ""

    End Sub
    Private Sub Ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_empleados()
        cargar_productos()
        limpiar()
        GENERACODIGO()

    End Sub

    Private Sub producto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles producto.SelectedIndexChanged
        If producto.Focused = True Then
            precio.Text = producto.SelectedItem.Row("PRECIO")
            Label1.Text = producto.SelectedItem.Row("ID_PRO")

        End If
    End Sub

    Private Sub emp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles emp.SelectedIndexChanged
        If emp.Focused = True Then
            Label9.Text = emp.SelectedItem.Row("ID_EMP")


        End If
    End Sub
End Class