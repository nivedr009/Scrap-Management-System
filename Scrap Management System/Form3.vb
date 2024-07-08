Public Class Form3
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ' Close the current form (Form3) and open the first form (Form1) again
        Dim form2 As New Form2()
        form2.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Create an instance of Form2
        Dim form1 As New Form1()

        ' Show Form2
        form1.Show()

        ' Hide the current form
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Close and open employee registration form
        Dim form4 As New Form4()
        form4.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Close and open site registration form
        Dim form5 As New Form5()
        form5.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Close and open site assignment form
        Dim form6 As New Form6()
        form6.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Close and open payment generation form form
        Dim form7 As New Form7()
        form7.Show()
        Me.Close()
    End Sub
End Class