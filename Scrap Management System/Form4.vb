Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Data.SqlClient


Public Class Form4

    ' SQL connection string
    Dim connectionString As String = "Data Source=DESKTOP-O16HO1G\SQLEXPRESS;Initial Catalog='Scrap Management System';Integrated Security=True;"

    Private Function GenerateNextWorkerIDFromDatabase() As String
        Dim nextWorkerID As String = "W01" ' Default value

        Try
            ' SQL query to get the last worker ID from the database
            Dim queryLastWorkerID As String = "SELECT TOP 1 Worker_ID FROM Worker_table ORDER BY CAST(SUBSTRING(Worker_ID, 2, LEN(Worker_ID)) AS INT) DESC"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(queryLastWorkerID, connection)
                    connection.Open()
                    Dim lastWorkerID As String = Convert.ToString(command.ExecuteScalar())

                    ' If there are records in the database, generate the next worker ID
                    If Not String.IsNullOrEmpty(lastWorkerID) Then
                        ' Extract the numeric part of the last worker ID
                        Dim numericPart As String = lastWorkerID.Substring(1)
                        ' Convert the numeric part to integer and increment by 1
                        Dim nextNumericPart As Integer = Convert.ToInt32(numericPart) + 1
                        ' Generate the next worker ID by combining the prefix ("W") and the incremented numeric part
                        nextWorkerID = "W" & nextNumericPart.ToString("D2")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error generating next worker ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return nextWorkerID
    End Function



    'Function to validate whether the phone number is a repeating number upto 6 digits
    Private Function ContainsRepeatingSequence(phoneNumber As String) As Boolean
        ' Remove the country code
        Dim numberWithoutCode As String = phoneNumber.Substring(3)

        ' Check if the remaining digits contain repeating sequences
        For i As Integer = 0 To numberWithoutCode.Length - 1
            Dim currentDigit As Char = numberWithoutCode(i)
            Dim sequenceLength As Integer = 1

            ' Check subsequent digits for repetition
            For j As Integer = i + 1 To numberWithoutCode.Length - 1
                If numberWithoutCode(j) = currentDigit Then
                    sequenceLength += 1
                    If sequenceLength = 6 Then ' A sequence of 6 repeating digits found
                        Return True
                    End If
                Else
                    Exit For
                End If
            Next j
        Next i

        ' No repeating sequences found
        Return False
    End Function

    ' Check if any character, number, or special character is repeated more than once
    Private Function ContainsRepeatedCharacters(input As String) As Boolean
        Dim count As Integer = 1
        For i As Integer = 1 To input.Length - 1
            If input(i) = input(i - 1) Then
                count += 1
                If count > 2 Then
                    Return True
                End If
            Else
                count = 1
            End If
        Next
        Return False
    End Function

    Private Function ValidateInputs() As Boolean ' Frontend validations
        Dim regexWorkerID As New Regex("^W\d+$")


        ' Worker ID Presence Check
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Worker ID cannot be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Return False
        ElseIf Not regexWorkerID.IsMatch(TextBox1.Text) Then
            MessageBox.Show("Invalid WORKER ID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Return False
        End If

        'Name Presence check
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Name cannot be blank.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf Not TextBox2.Text.All(Function(c) Char.IsLetter(c) Or c = " ") Then
            MessageBox.Show("Invalid Name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Return False
        ElseIf ContainsRepeatedCharacters(TextBox2.Text) Then
            MessageBox.Show("Name should not contain repeated characters", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Return False
        End If

        ' Phone Number Presence check
        If String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("Phone number cannot be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return False
        ElseIf TextBox3.Text = "+91" Then
            MessageBox.Show("Please enter phone number ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return False
        ElseIf Not TextBox3.Text.StartsWith("+91") OrElse TextBox3.Text.Length <> 13 OrElse Not TextBox3.Text.Substring(3).All(Function(c) Char.IsDigit(c)) OrElse TextBox3.Text.Substring(3, 1) Like "[0-6]" Then
            MessageBox.Show("Invalid Phone number", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return False
        ElseIf ContainsRepeatingSequence(TextBox3.Text) Then
            MessageBox.Show("Phone number contains a repeating sequence of more than 6 digits", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return False
        End If

        ' House no/name Presence and Format check
        If String.IsNullOrWhiteSpace(TextBox4.Text) Then
            MessageBox.Show("Please enter house/building name or number", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox4.Focus()
            Return False
        ElseIf ContainsRepeatedCharacters(TextBox4.Text) Then
            MessageBox.Show("House/building name or number should not contain repeated characters, numbers, or special characters", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox4.Focus()
            Return False
        End If

        ' Street Presence and Format check
        If String.IsNullOrWhiteSpace(TextBox5.Text) Then
            MessageBox.Show("Please enter street", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox5.Focus()
            Return False
        ElseIf ContainsRepeatedCharacters(TextBox5.Text) Then
            MessageBox.Show("Street should not contain repeated characters, numbers, or special characters", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox5.Focus()
            Return False
        End If

        ' City Presence and Format check
        If String.IsNullOrWhiteSpace(TextBox6.Text) Then
            MessageBox.Show("Please enter the City", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox6.Focus()
            Return False
        ElseIf Not TextBox6.Text.All(Function(c) Char.IsLetter(c) Or c = " ") Then
            MessageBox.Show("Invalid City name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox6.Focus()
            Return False
        ElseIf ContainsRepeatedCharacters(TextBox6.Text) Then
            MessageBox.Show("City should not contain repeated characters, numbers, or special characters", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox6.Focus()
            Return False
        End If

        ' District Presence and Format check
        If String.IsNullOrWhiteSpace(TextBox7.Text) Then
            MessageBox.Show("Please enter the District", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox7.Focus()
            Return False
        ElseIf Not TextBox7.Text.All(Function(c) Char.IsLetter(c) Or c = " ") Then
            MessageBox.Show("Invalid District name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox7.Focus()
            Return False
        ElseIf ContainsRepeatedCharacters(TextBox7.Text) Then
            MessageBox.Show("District should not contain repeated characters, numbers, or special characters", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox7.Focus()
            Return False
        End If

        ' Check if State is selected from ComboBox2
        If ComboBox2.SelectedIndex = -1 Then
            MessageBox.Show("Please select the State", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox2.Focus()
            Return False
        End If

        ' Pincode Presence and Format check
        If String.IsNullOrWhiteSpace(TextBox8.Text) Then
            MessageBox.Show("Please enter the Pincode", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox8.Focus()
            Return False
        ElseIf TextBox8.Text.Length <> 6 OrElse Not TextBox8.Text.All(Function(c) Char.IsDigit(c)) Then
            MessageBox.Show("Invalid Pincode", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox8.Focus()
            Return False
        ElseIf TextBox8.Text.StartsWith("0") Then
            MessageBox.Show("Pincode should not start with '0'", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox8.Focus()
            Return False
        ElseIf TextBox8.Text.GroupBy(Function(c) c).Any(Function(g) g.Count() > 3) Then
            MessageBox.Show("Pincode should not contain a digit repeated more than 3 times", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox8.Focus()
            Return False
        End If

        Return True

    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Clear all textboxes
        TextBox1.Text = "W"
        TextBox2.Text = ""
        TextBox3.Text = "+91"
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""


        ' Reset to default ComboBox1 (Role)
        ComboBox1.SelectedIndex = 0
        ' Clear ComboBox2 (State)
        ComboBox2.SelectedIndex = -1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Perform frontend validations
        If Not ValidateInputs() Then
            Return
        End If

        ' Check if Worker_ID already exists
        Dim workerIdExists As Boolean = False
        Dim queryWorkerIdExists As String = "SELECT COUNT(*) FROM Worker_table WHERE Worker_ID = @workerId"

        Try
            Using connection As New SqlConnection(connectionString)
                Using commandCheckWorkerId As New SqlCommand(queryWorkerIdExists, connection)
                    connection.Open()
                    commandCheckWorkerId.Parameters.AddWithValue("@workerId", TextBox1.Text)
                    Dim count As Integer = Convert.ToInt32(commandCheckWorkerId.ExecuteScalar())
                    workerIdExists = (count > 0)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking Worker ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If workerIdExists Then
            MessageBox.Show("Worker ID is already taken.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Insert data into the Worker_table
        Dim query As String = "INSERT INTO [dbo].[Worker_table] ([Worker_ID], [Worker_name], [phn_no], [house], [street_area], [city], [district], [state], [pincode], [role]) " &
                              "VALUES (@Worker_ID, @Worker_name, @phn_no, @house, @street_area, @city, @district, @state, @pincode, @role)"

        Try
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    ' Add parameters
                    command.Parameters.AddWithValue("@Worker_ID", TextBox1.Text)
                    command.Parameters.AddWithValue("@Worker_name", TextBox2.Text)
                    command.Parameters.AddWithValue("@phn_no", TextBox3.Text)
                    command.Parameters.AddWithValue("@house", TextBox4.Text)
                    command.Parameters.AddWithValue("@street_area", TextBox5.Text)
                    command.Parameters.AddWithValue("@city", TextBox6.Text)
                    command.Parameters.AddWithValue("@district", TextBox7.Text)
                    command.Parameters.AddWithValue("@state", ComboBox2.SelectedItem.ToString())
                    command.Parameters.AddWithValue("@pincode", Convert.ToInt32(TextBox8.Text)) ' Assuming pincode is always a valid integer
                    command.Parameters.AddWithValue("@role", ComboBox1.SelectedItem.ToString())

                    connection.Open()
                    command.ExecuteNonQuery()

                    MessageBox.Show("Worker Registered Successfully", "Confirmation", MessageBoxButtons.OK)
                    ClearInputs()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error inserting data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Close the current form (Form4) and open the first form (Form3) again
        Dim form3 As New Form3()
        form3.Show()
        Me.Close()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Worker ID to start with "W"
        TextBox1.Text = "W"

        ' Set initial text of phone number textbox to "+91"
        TextBox3.Text = "+91"

        ' Add Roles to the ComboBox
        ComboBox1.Items.Add("Field Worker")
        ComboBox1.Items.Add("Driver")
        ComboBox1.Items.Add("Sorter")
        ComboBox1.Items.Add("Accountant")

        ' Set a default selection if needed
        ComboBox1.SelectedIndex = 0

        ' Add states to the ComboBox
        ComboBox2.Items.Add("Andhra Pradesh")
        ComboBox2.Items.Add("Arunachal Pradesh")
        ComboBox2.Items.Add("Assam")
        ComboBox2.Items.Add("Bihar")
        ComboBox2.Items.Add("Chhattisgarh")
        ComboBox2.Items.Add("Goa")
        ComboBox2.Items.Add("Gujarat")
        ComboBox2.Items.Add("Haryana")
        ComboBox2.Items.Add("Himachal Pradesh")
        ComboBox2.Items.Add("Jharkhand")
        ComboBox2.Items.Add("Karnataka")
        ComboBox2.Items.Add("Kerala")
        ComboBox2.Items.Add("Madhya Pradesh")
        ComboBox2.Items.Add("Maharashtra")
        ComboBox2.Items.Add("Manipur")
        ComboBox2.Items.Add("Meghalaya")
        ComboBox2.Items.Add("Mizoram")
        ComboBox2.Items.Add("Nagaland")
        ComboBox2.Items.Add("Odisha")
        ComboBox2.Items.Add("Punjab")
        ComboBox2.Items.Add("Rajasthan")
        ComboBox2.Items.Add("Sikkim")
        ComboBox2.Items.Add("Tamil Nadu")
        ComboBox2.Items.Add("Telangana")
        ComboBox2.Items.Add("Tripura")
        ComboBox2.Items.Add("Uttar Pradesh")
        ComboBox2.Items.Add("Uttarakhand")
        ComboBox2.Items.Add("West Bengal")
        ComboBox2.Items.Add("Andaman and Nicobar Islands")
        ComboBox2.Items.Add("Chandigarh")
        ComboBox2.Items.Add("Dadra and Nagar Haveli")
        ComboBox2.Items.Add("Daman and Diu")
        ComboBox2.Items.Add("Lakshadweep")
        ComboBox2.Items.Add("Delhi")
        ComboBox2.Items.Add("Puducherry")

        'Disable manual entry into comboBox
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList


    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text.Length > 0 Then
            ' Get the current selection start position
            Dim selectionStart As Integer = TextBox2.SelectionStart
            ' Capitalize the first letter
            TextBox2.Text = TextBox2.Text.Substring(0, 1).ToUpper() + TextBox2.Text.Substring(1)
            ' Restore the selection start position
            TextBox2.SelectionStart = selectionStart
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text.Length > 0 Then
            ' Get the current selection start position
            Dim selectionStart As Integer = TextBox5.SelectionStart
            ' Capitalize the first letter
            TextBox5.Text = TextBox5.Text.Substring(0, 1).ToUpper() + TextBox5.Text.Substring(1)
            ' Restore the selection start position
            TextBox5.SelectionStart = selectionStart
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text.Length > 0 Then
            ' Get the current selection start position
            Dim selectionStart As Integer = TextBox6.SelectionStart
            ' Capitalize the first letter
            TextBox6.Text = TextBox6.Text.Substring(0, 1).ToUpper() + TextBox6.Text.Substring(1)
            ' Restore the selection start position
            TextBox6.SelectionStart = selectionStart
        End If
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        If TextBox7.Text.Length > 0 Then
            ' Get the current selection start position
            Dim selectionStart As Integer = TextBox7.SelectionStart
            ' Capitalize the first letter
            TextBox7.Text = TextBox7.Text.Substring(0, 1).ToUpper() + TextBox7.Text.Substring(1)
            ' Restore the selection start position
            TextBox7.SelectionStart = selectionStart
        End If
    End Sub

    Private Sub ClearInputs()
        ' Clear all textboxes
        TextBox1.Text = "W"
        TextBox2.Text = ""
        TextBox3.Text = "+91"
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""


        ' Reset to default ComboBox1 (Role)
        ComboBox1.SelectedIndex = 0
        ' Clear ComboBox2 (State)
        ComboBox2.SelectedIndex = -1

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Generate the next worker ID and display it in TextBox1
        TextBox1.Text = GenerateNextWorkerIDFromDatabase()

        ' Disable TextBox1 to prevent editing
        TextBox1.Enabled = False

    End Sub
End Class