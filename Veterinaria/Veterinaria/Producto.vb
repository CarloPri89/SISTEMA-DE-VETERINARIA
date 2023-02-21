Imports System.Data
Imports System.Data.SqlClient
Public Class Producto
    Dim strCodigo As String
    Private Sub Button3_Click(sender As Object, e As EventArgs)
        MenuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            If productos.Text = "" Then
                MsgBox("Debes ingresar datos necesarios")
                productos.Focus()
            Else
                Dim XG As New SqlCommand("SP_PRODUCTO", cn)
                XG.CommandType = CommandType.StoredProcedure
                XG.Parameters.Add(New SqlParameter("@ID_PRO", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = (id.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@TIPO_PRODUCTO_REGISTRADO", SqlDbType.VarChar, 70, ParameterDirection.Input)).Value = (productos.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@CANTIDAD", SqlDbType.Char, 1000, ParameterDirection.Input)).Value = (cantidad.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@PRECIO", SqlDbType.Money, ParameterDirection.Input)).Value = (precio.Text).ToUpper
                XG.Parameters.Add(New SqlParameter("@FECHA_REGISTRO", SqlDbType.DateTime, ParameterDirection.Input)).Value = (DateTimePicker1.Text).ToUpper

                cn.Open()
                XG.ExecuteNonQuery()
                cn.Close()
                MessageBox.Show("Producto Registrado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                limpiar()
                GENERACODIGO()
            End If
        Catch ex As Exception
            Throw
        End Try


    End Sub
    Sub GENERACODIGO()
        Dim cmd As New SqlCommand("select max(ID_PRO)from PRODUCTO", cn)
        cn.Open()
        strCodigo = cmd.ExecuteScalar
        cn.Close()
        id.Text = Format(Val(strCodigo) + 1, "000000")
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        id.Text = ""
        productos.Text = ""
        cantidad.Text = ""
        DateTimePicker1.Text = ""
    End Sub
    Sub limpiar()
        id.Text = ""
        productos.Text = ""
        cantidad.Text = ""
        DateTimePicker1.Text = ""
        precio.Text = ""
        id.Focus()
    End Sub

    Private Sub Producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GENERACODIGO()

    End Sub
End Class