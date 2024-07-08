Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Data.SqlClient

Public Class Form6

    ' SQL connection string
    Dim connectionString As String = "Data Source=DESKTOP-O16HO1G\SQLEXPRESS;Initial Catalog='Scrap Management System';Integrated Security=True;"

    'Function to fetch role of the Worker
    Private Function FetchRole(workerId As String) As String
        Dim query As String = "SELECT role FROM Worker_table WHERE Worker_ID = @workerId"
        Dim role As String = String.Empty

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@workerId", workerId)
                Try
                    connection.Open()
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        role = Convert.ToString(result)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error while fetching role: " & ex.Message)
                End Try
            End Using
        End Using

        Return role
    End Function


    Private Function WorkerExists(workerId As String) As Boolean
        ' SQL query to check if the worker exists in Worker_table
        Dim query As String = "SELECT COUNT(*) FROM Worker_table WHERE Worker_ID = @Worker_ID"

        ' Create a connection to the database
        Using connection As New SqlConnection(connectionString)
            ' Create a command to execute the query
            Using command As New SqlCommand(query, connection)
                ' Add the Worker_ID parameter to the command
                command.Parameters.AddWithValue("@Worker_ID", workerId)

                Try
                    ' Open the database connection
                    connection.Open()
                    ' Execute the query and get the count of records
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    ' Return True if count is greater than 0, indicating the worker exists
                    Return count > 0
                Catch ex As Exception
                    ' Handle any exceptions that occur during execution
                    MessageBox.Show("Error checking worker existence: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Using
        End Using
    End Function




    'To save to the Salary table
    Private Sub SaveToSalaryTable()
        ' Extract data from controls
        Dim workerId As String = TextBox1.Text
        Dim role As String = TextBox2.Text
        Dim month As String = ComboBox1.SelectedItem.ToString()
        Dim year As Integer = Convert.ToInt32(ComboBox2.SelectedItem.ToString())
        Dim noOfDays As Integer = ComboBox3.SelectedIndex + 1 ' Assuming index starts from 0
        Dim totalSal As Decimal = Decimal.Parse(TextBox3.Text.Trim().Replace("Rs ", ""), CultureInfo.InvariantCulture)

        ' SQL query to insert data into salary_table
        Dim query As String = "INSERT INTO [dbo].[salary_table] ([Worker_ID], [role], [month], [year], [no_of_days], [total_sal]) VALUES (@Worker_ID, @role, @month, @year, @no_of_days, @total_sal)"

        ' Create connection and command objects
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters
                command.Parameters.AddWithValue("@Worker_ID", workerId)
                command.Parameters.AddWithValue("@role", role)
                command.Parameters.AddWithValue("@month", month)
                command.Parameters.AddWithValue("@year", year)
                command.Parameters.AddWithValue("@no_of_days", noOfDays)
                command.Parameters.AddWithValue("@total_sal", totalSal)

                ' Open connection and execute query
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub


    Private Function SalaryAlreadyGenerated(workerId As String, month As String, year As String) As Boolean
        ' Query to check if salary has already been generated for the same worker for the same month and year
        Dim query As String = "SELECT COUNT(*) FROM salary_table WHERE Worker_ID = @workerId AND [month] = @month AND [year] = @year"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                command.Parameters.AddWithValue("@workerId", workerId)
                command.Parameters.AddWithValue("@month", month)
                command.Parameters.AddWithValue("@year", year)

                ' Execute the query and get the count of records
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())

                ' If count is greater than 0, it means salary has already been generated
                Return count > 0
            End Using
        End Using
    End Function


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Close the current form (Form6) and open the first form (Form3) again
        Dim form3 As New Form3()
        form3.Show()
        Me.Close()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set TextBox2 as read-only
        TextBox2.ReadOnly = True

        ' Set TextBox3 as read-only
        TextBox3.ReadOnly = True

        ' Worker ID to start with "W"
        TextBox1.Text = "W"

        ' Get the current month
        Dim currentMonth As Integer = DateTime.Now.Month

        ' Add the range of months to the ComboBox (current month - 1, current month, current month + 1)
        For month As Integer = currentMonth - 1 To currentMonth + 1
            ' Adjust the month to ensure it falls within the range of 1 to 12
            Dim adjustedMonth As Integer = If(month <= 0, month + 12, If(month > 12, month - 12, month))

            ' Add the month name to the ComboBox
            ComboBox1.Items.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(adjustedMonth))
        Next

        ' Set the default selected index to the current month (which is the second item in the list)
        ComboBox1.SelectedIndex = 1

        ' Select Current Year
        Dim currentYear As Integer = DateTime.Now.Year
        ' Add the range of years to the ComboBox (current year - 1, current year, current year + 1)
        For year As Integer = currentYear - 1 To currentYear + 1
            ComboBox2.Items.Add(year.ToString())
        Next
        ' Set the default selected index to the current year
        ComboBox2.SelectedIndex = 1 ' Index 1 corresponds to the current year

        ' Add numbers from 1 to 31 to the no of days worked
        For i As Integer = 1 To 31
            ComboBox3.Items.Add(i.ToString())
        Next
        ' Set the default selected index as 29
        ComboBox3.SelectedIndex = 29 ' Selecting 30 by default

        'Disable manual entry into comboBox
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub ClearInputs()
        ' Clear all textboxes
        TextBox1.Text = "W"
        TextBox2.Text = ""
        TextBox3.Text = ""


        ' Set the month ComboBox to the current month
        ComboBox1.SelectedIndex = 1

        ' Set the year ComboBox to the current year
        ComboBox2.SelectedItem = DateTime.Now.Year.ToString()

        ' Set the default selected index as o
        ComboBox3.SelectedIndex = 29 ' Selecting 30 by default

        ' Enable controls
        TextBox1.ReadOnly = False
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True

    End Sub

    Private Function ValidateInputs() As Boolean ' Frontend validations

        Dim regexWorkerID As New Regex("^W\d+$")

        ' Worker ID Presence Check
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Worker ID cannot be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Return False
        ElseIf Not regexWorkerID.IsMatch(TextBox1.Text) Then
            MessageBox.Show("Invalid Worker ID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Return False
        End If

        'Checking the Role
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Role not fetched", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        ' Define role and their salaries
        Dim salaries As New Dictionary(Of String, Integer) From
        {
            {"Field Worker", 300},
            {"Driver", 400},
            {"Sorter", 300},
            {"Accountant", 500}
        }

        ' Worker ID Presence Check
        Dim regexWorkerID As New Regex("^W\d+$")

        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Worker ID cannot be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        ElseIf Not regexWorkerID.IsMatch(TextBox1.Text) Then
            MessageBox.Show("Invalid Worker ID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        End If

        ' Role Presence Check
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Role not fetched. Worker not Registered", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If

        ' Check if no of days are selected in ComboBox3
        If ComboBox3.SelectedIndex >= 0 Then
            ' Get the number of days from ComboBox3
            Dim days As Integer = ComboBox3.SelectedIndex + 1

            ' Retrieve the corresponding salary based on the selected position
            Dim selectedPosition As String = TextBox2.Text.Trim()

            ' Check if the selected position exists in the salaries dictionary
            If salaries.ContainsKey(selectedPosition) Then
                Dim salaryPerDay As Integer = salaries(selectedPosition) ' Retrieve the daily rate for the selected role
                Dim totalSalary As Integer = salaryPerDay * days ' Calculate the total salary

                ' Display the final salary in TextBox3
                TextBox3.Text = "Rs " & totalSalary.ToString()

                ' Disable controls
                TextBox1.ReadOnly = True
                ComboBox1.Enabled = False
                ComboBox2.Enabled = False
                ComboBox3.Enabled = False
            Else
                MessageBox.Show("Invalid role selected", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox2.Focus()
            End If
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ClearInputs()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Worker ID Presence Check
        Dim regexWorkerID As New Regex("^W\d+$")

        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Worker ID cannot be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        ElseIf Not regexWorkerID.IsMatch(TextBox1.Text) Then
            MessageBox.Show("Invalid Worker ID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        End If

        ' Check if TextBox3 (total amount) is not empty
        If String.IsNullOrEmpty(TextBox3.Text) Then
            MessageBox.Show("Please calculate the total salary before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        ' Check if Worker_ID already exists
        Dim workerIdExists As Boolean = WorkerExists(TextBox1.Text)
        If Not workerIdExists Then
            MessageBox.Show("Worker ID does not exist. Please enter a valid Worker ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus() ' Focus on TextBox1
            ' Set TextBox1 as read-only
            TextBox1.ReadOnly = False
            Exit Sub
        End If


        ' Check if the Worker ID exists in the Salary table for the same month and year
        Dim month As String = ComboBox1.SelectedItem.ToString()
        Dim year As String = ComboBox2.SelectedItem.ToString()

        If SalaryAlreadyGenerated(TextBox1.Text, month, year) Then
            MessageBox.Show("Salary has already been generated for the same worker for the same month and year.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' If all validations pass, proceed with saving
        SaveToSalaryTable()

        ' Clear textboxes and reset ComboBoxes
        If MessageBox.Show("Salary Generated and Saved Successfully") Then
            ClearInputs()
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Only proceed if the TextBox1 contains text and it is different from the default value "W"
        If TextBox1.Text.Trim().Length > "W".Length AndAlso TextBox1.Text.Trim() <> "W" Then
            ' Validate the worker ID format
            Dim workerId As String = TextBox1.Text.Trim()
            Dim regexWorkerID As New Regex("^W\d+$")

            If Not regexWorkerID.IsMatch(workerId) Then
                MessageBox.Show("Invalid Worker ID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.Focus()
                Exit Sub
            Else
                ' If the format is valid, proceed to fetch the role
                Dim role As String = FetchRole(workerId)
                If Not String.IsNullOrEmpty(role) Then
                    ' Set the role in TextBox2
                    TextBox2.Text = role
                Else
                    ' If role is not found, clear TextBox2
                    TextBox2.Text = ""
                End If
            End If
        Else
            ' If TextBox1 is empty or contains the default value "W", clear TextBox2
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class