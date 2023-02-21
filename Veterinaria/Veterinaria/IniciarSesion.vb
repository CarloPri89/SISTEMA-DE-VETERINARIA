Imports System.Runtime.InteropServices
Public Class IniciarSesion
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If usuario.Text = "junior" And contraseña.Text = "123" Then
            MsgBox("BIENVENIDO AL SISTEMA VETERINARIA")
            MenuPrincipal.Show()
            Me.Hide()
        Else
            MsgBox("Datos incorrectos intenta de nuevo")
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub contraseña_TextChanged(sender As Object, e As EventArgs) Handles contraseña.TextChanged
        contraseña.PasswordChar = "*"
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Ayuda.Show()
        Me.Hide()
    End Sub

    Private Sub IniciarSesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtUser_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove

    End Sub

    Private Sub usuario_TextChanged(sender As Object, e As EventArgs) Handles usuario.TextChanged

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)


    End Sub
End Class
