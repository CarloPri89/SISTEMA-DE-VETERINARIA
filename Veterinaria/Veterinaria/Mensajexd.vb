Public Class Mensajexd
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static contar As Integer
        If contar < 100 Then
            contar = contar + 10
            ProgressBar1.Value = contar


        Else
            Timer1.Stop()
            contar = 0
            MenuPrincipal.Show()
            Me.Hide()

        End If
    End Sub
End Class