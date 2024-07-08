Public Class Form1
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Creating an instance of the next form
        Dim form2 As New Form2

        ' Hiding the current form
        Hide()

        ' Show the next form
        form2.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Exit the application
        Application.Exit()
    End Sub
End Class
