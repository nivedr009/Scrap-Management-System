Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Data.SqlClient

Public Class Form7

    ' SQL connection string
    Dim connectionString As String = "Data Source=DESKTOP-O16HO1G\SQLEXPRESS;Initial Catalog='Scrap Management System';Integrated Security=True;"

    Private Function GenerateNextProfitIDFromDatabase() As String
        Dim nextProfitID As String = "P01" ' Default initial value

        Try
            ' SQL query to get the last Profit ID from the database
            Dim queryLastProfitID As String = "SELECT TOP 1 Profit_ID FROM profit_table ORDER BY CAST(SUBSTRING(Profit_ID, 2, LEN(Profit_ID)) AS INT) DESC"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(queryLastProfitID, connection)
                    connection.Open()
                    Dim lastProfitID As String = Convert.ToString(command.ExecuteScalar())

                    ' If there are records in the database, generate the next Profit ID
                    If Not String.IsNullOrEmpty(lastProfitID) Then
                        ' Extract the numeric part of the last Profit ID
                        Dim numericPart As String = lastProfitID.Substring(1)
                        ' Convert the numeric part to integer and increment by 1
                        Dim nextNumericPart As Integer = Convert.ToInt32(numericPart) + 1
                        ' Generate the next Profit ID by combining the prefix ("P") and the incremented numeric part
                        nextProfitID = "P" & nextNumericPart.ToString("D2")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error generating next profit ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return nextProfitID
    End Function


    Private Function FetchTotalAmountByMonthYear(month As String, year As Integer) As Decimal
        ' Initialize the sum of total amounts
        Dim totalAmount As Decimal = 0

        Try
            ' Convert month name to its corresponding numeric value
            Dim monthNumber As Integer = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month

            ' SQL query to fetch the sum of total amounts for the selected month and year
            Dim query As String = "SELECT SUM(amount) FROM daily_collection WHERE MONTH(Date_of_collection) = @month AND YEAR(Date_of_collection) = @year"

            ' Create a connection to the database
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    ' Add parameters for month and year
                    command.Parameters.AddWithValue("@month", monthNumber)
                    command.Parameters.AddWithValue("@year", year)

                    ' Open the database connection
                    connection.Open()

                    ' Execute the query and get the sum of total amounts
                    Dim result As Object = command.ExecuteScalar()

                    ' Check if the result is not null
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        totalAmount = Convert.ToDecimal(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error while fetching total amount: " & ex.Message)
        End Try

        Return totalAmount
    End Function



    Private Function FetchTotalSalaryByMonthYear(month As String, year As Integer) As Decimal
        ' Initialize the sum of total salaries
        Dim totalSalary As Decimal = 0

        Try
            ' SQL query to fetch the sum of total salaries for the selected month and year
            Dim query As String = "SELECT SUM(total_sal) FROM salary_table WHERE month = @month AND year = @year"

            ' Create a connection to the database
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    ' Add parameters for month and year
                    command.Parameters.AddWithValue("@month", month)
                    command.Parameters.AddWithValue("@year", year)

                    ' Open the database connection
                    connection.Open()

                    ' Execute the query and get the sum of total salaries
                    Dim result As Object = command.ExecuteScalar()

                    ' Check if the result is not null
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        totalSalary = Convert.ToDecimal(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error while fetching total salary: " & ex.Message)
        End Try

        Return totalSalary
    End Function

    Private Sub ComboBoxes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged, ComboBox2.SelectedIndexChanged
        ' Check if both ComboBoxes have selected values
        If ComboBox1.SelectedIndex >= 0 AndAlso ComboBox2.SelectedIndex >= 0 Then
            ' Get the selected month and year
            Dim selectedMonth As String = ComboBox1.SelectedItem.ToString()
            Dim selectedYear As Integer = Convert.ToInt32(ComboBox2.SelectedItem.ToString())

            ' Call the function to fetch the total amount for the selected month and year
            Dim totalCollection As Decimal = FetchTotalAmountByMonthYear(selectedMonth, selectedYear)
            Dim totalSalary As Decimal = FetchTotalSalaryByMonthYear(selectedMonth, selectedYear)

            ' Display the total collection amount in TextBox1
            TextBox1.Text = "Rs " & totalCollection.ToString()

            ' Display the total salary amount in TextBox2
            TextBox2.Text = "Rs " & totalSalary.ToString()
        End If
    End Sub

    Private Function ProfitAlreadyGenerated(month As String, year As Integer) As Boolean
        ' Query to check if profit has already been generated for the same month and year
        Dim query As String = "SELECT COUNT(*) FROM profit_table WHERE [month] = @month AND [year] = @year"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                command.Parameters.AddWithValue("@month", month)
                command.Parameters.AddWithValue("@year", year)

                ' Execute the query and get the count of records
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())

                ' If count is greater than 0, it means profit has already been generated
                Return count > 0
            End Using
        End Using
    End Function


    Private Sub SaveToProfitTable()
        ' Extract data from controls
        Dim profitId As String = TextBox4.Text
        Dim month As String = ComboBox1.SelectedItem.ToString()
        Dim year As Integer = Convert.ToInt32(ComboBox2.SelectedItem.ToString())
        Dim profitAmount As Decimal = Decimal.Parse(TextBox3.Text.Trim().Replace("Rs ", ""), CultureInfo.InvariantCulture)

        ' SQL query to insert data into profit_table
        Dim query As String = "INSERT INTO [dbo].[profit_table] ([Profit_ID], [month], [year], [profit]) VALUES (@Profit_ID, @month, @year, @profit)"

        ' Create connection and command objects
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters
                command.Parameters.AddWithValue("@Profit_ID", profitId)
                command.Parameters.AddWithValue("@month", month)
                command.Parameters.AddWithValue("@year", year)
                command.Parameters.AddWithValue("@profit", profitAmount)

                ' Open connection and execute query
                connection.Open()
                command.ExecuteNonQuery()

                ' Call LoadDataIntoDataGridView to refresh the DataGridView
                LoadDataIntoDataGridView()
            End Using
        End Using
    End Sub

    Private Sub LoadDataIntoDataGridView()
        Try
            ' SQL query to select all data from profit_table
            Dim query As String = "SELECT * FROM profit_table"

            ' Create a connection to the database
            Using connection As New SqlConnection(connectionString)
                Using adapter As New SqlDataAdapter(query, connection)
                    ' Create a DataSet to hold the data
                    Dim dataset As New DataSet()

                    ' Fill the DataSet with data from the database
                    adapter.Fill(dataset)

                    ' Set the DataGridView's DataSource to the DataSet's first table
                    DataGridView1.DataSource = dataset.Tables(0)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data into DataGridView: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Close the current form (Form7) and open the first form (Form3) again
        Dim form3 As New Form3()
        form3.Show()
        Me.Close()
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        ' Profit ID to start with "P"
        TextBox4.Text = "P"
        ' Set TextBox1 as read-only
        TextBox1.ReadOnly = True
        ' Set TextBox2 as read-only
        TextBox2.ReadOnly = True
        ' Set TextBox3 as read-only
        TextBox3.ReadOnly = True

        ' Make the DataGridView uneditable
        DataGridView1.ReadOnly = True

        ' Get the current month
        Dim currentMonth As Integer = DateTime.Now.Month

        ' Populate ComboBox1 with all months
        For month As Integer = 1 To 12
            ' Add the month name to the ComboBox
            ComboBox1.Items.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(month))
        Next

        ' Select Current Year
        Dim currentYear As Integer = DateTime.Now.Year

        ' Add the range of years to ComboBox2 (current year - 1 to current year + 10)
        For year As Integer = currentYear - 1 To currentYear + 10
            ComboBox2.Items.Add(year.ToString())
        Next

        ' Set the default selected index to the current year
        ComboBox2.SelectedIndex = 1 ' Index 1 corresponds to the current year

        'Disable manual entry into comboBox
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList

        ' Call LoadDataIntoDataGridView to refresh the DataGridView
        LoadDataIntoDataGridView()

    End Sub

    Private Sub ClearInputs()
        ' Clear all textboxes
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = "P"


        ' Set the month ComboBox to null
        ComboBox1.SelectedIndex = -1

        ' Set the year ComboBox to the current year
        ComboBox2.SelectedItem = DateTime.Now.Year.ToString()

    End Sub

    Private Function ValidateInputs() As Boolean ' Frontend validations

        Dim regexProfitID As New Regex("^P\d+$")


        ' Worker ID Presence Check
        If String.IsNullOrWhiteSpace(TextBox4.Text) Then
            MessageBox.Show("Profit ID cannot be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox4.Focus()
            Return False
        ElseIf Not regexProfitID.IsMatch(TextBox4.Text) Then
            MessageBox.Show("Invalid Profit ID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox4.Focus()
            Return False
        End If

        ' Check if ComboBox1 is selected
        If ComboBox1.SelectedIndex < 0 Then
            MessageBox.Show("Please select a month.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If


        Return True
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Clear all textboxes
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = "P"

        ' Set the month ComboBox to null
        ComboBox1.SelectedIndex = -1

        ' Set the year ComboBox to the current year
        ComboBox2.SelectedItem = DateTime.Now.Year.ToString()

        ' Enable controls
        TextBox4.ReadOnly = False
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Perform frontend validations
        If Not ValidateInputs() Then
            Return
        End If

        ' Check if TextBox3 (total amount) is not empty
        If String.IsNullOrEmpty(TextBox3.Text) Then
            MessageBox.Show("Please calculate the total Profit before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Check if the Profit ID exists in the Profit table for the same month and year
        Dim month As String = ComboBox1.SelectedItem.ToString()
        Dim year As String = ComboBox2.SelectedItem.ToString()

        If ProfitAlreadyGenerated(month, Convert.ToInt32(year)) Then
            MessageBox.Show("Profit has already been generated for the same month and year.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        ' If all validations pass, proceed with saving
        SaveToProfitTable()

        ' Clear textboxes and reset ComboBoxes
        If MessageBox.Show("Profit Generated and Saved Successfully") Then
            ClearInputs()
        End If

        ' Enable controls
        TextBox4.ReadOnly = False
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        ' Perform frontend validations
        If Not ValidateInputs() Then
            Return
        End If

        ' Check if TextBox1 and TextBox2 are not empty
        If Not String.IsNullOrWhiteSpace(TextBox1.Text) AndAlso Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
            ' Check if both TextBox1 and TextBox2 contain "Rs. 0"
            If TextBox1.Text.Trim() = "Rs 0" AndAlso TextBox2.Text.Trim() = "Rs 0" Then
                MessageBox.Show("Profit cannot be calculated as both Collection and Expenditure values are 'Rs. 0'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Remove the "Rs" prefix and convert the values to decimals
            Dim value1 As Decimal
            Dim value2 As Decimal
            If Decimal.TryParse(TextBox1.Text.Replace("Rs ", ""), value1) AndAlso Decimal.TryParse(TextBox2.Text.Replace("Rs ", ""), value2) Then
                ' Subtract value2 from value1
                Dim result As Decimal = value1 - value2

                ' Display the result in TextBox3 with the "Rs" prefix
                TextBox3.Text = "Rs " & result.ToString()
            Else
                MessageBox.Show("Invalid value format of Collection or Expenditure", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' Disable controls
            TextBox4.ReadOnly = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
        Else
            MessageBox.Show("Error fetching values from table", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

        ' Generate the next profit ID and display it in TextBox1
        TextBox4.Text = GenerateNextProfitIDFromDatabase()

        ' Disable TextBox1 to prevent editing
        TextBox4.Enabled = False

    End Sub
End Class