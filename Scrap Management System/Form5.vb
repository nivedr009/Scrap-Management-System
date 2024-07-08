Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Data.SqlClient

Public Class Form5

    ' SQL connection string
    Dim connectionString As String = "Data Source=DESKTOP-O16HO1G\SQLEXPRESS;Initial Catalog='Scrap Management System';Integrated Security=True;"

    Private Function GenerateNextCollectionIDFromDatabase() As String
        Dim nextCollectionID As String = "C01" ' Default initial value

        Try
            ' SQL query to get the last Collection ID from the database
            Dim queryLastCollectionID As String = "SELECT TOP 1 Collection_ID FROM daily_collection ORDER BY CAST(SUBSTRING(Collection_ID, 2, LEN(Collection_ID)) AS INT) DESC"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(queryLastCollectionID, connection)
                    connection.Open()
                    Dim lastCollectionID As String = Convert.ToString(command.ExecuteScalar())

                    ' If there are records in the database, generate the next Collection ID
                    If Not String.IsNullOrEmpty(lastCollectionID) Then
                        ' Extract the numeric part of the last Collection ID, assuming it starts with a letter
                        Dim numericPart As String = lastCollectionID.Substring(1)
                        ' Convert the numeric part to integer and increment by 1
                        Dim nextNumericPart As Integer = Convert.ToInt32(numericPart) + 1
                        ' Generate the next Collection ID by combining the prefix ("C") and the incremented numeric part
                        nextCollectionID = "C" & nextNumericPart.ToString("D2")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error generating next collection ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return nextCollectionID
    End Function



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Close the current form (Form4) and open the first form (Form3) again
        Dim form3 As New Form3()
        form3.Show()
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set TextBox4 as read-only
        TextBox4.ReadOnly = True

        ' Collection ID to start with "C"
        TextBox1.Text = "C"

        ' Worker ID to start with "W"
        TextBox2.Text = "W"

        ' Set default date for dob
        DateTimePicker1.Value = DateTime.Today

        ' Add Categories to the ComboBox
        ComboBox1.Items.Add("Ferrous Metals")
        ComboBox1.Items.Add("Non-Ferrous Metals")
        ComboBox1.Items.Add("Electronic (E-Scrap)")
        ComboBox1.Items.Add("Automotive Scrap")
        ComboBox1.Items.Add("Appliance Scrap")
        ComboBox1.Items.Add("Plastic Scrap")
        ComboBox1.Items.Add("Paper and Cardboard")
        ComboBox1.Items.Add("Glass Scrap")
        ComboBox1.Items.Add("Rubber Scrap")
        ComboBox1.Items.Add("Textile Scrap")

        'Disable manual entry into comboBox
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim regexCollectionID As New Regex("^C\d+$")


        Dim regexWorkerID As New Regex("^W\d+$")



        ' Collection ID Presence Check
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Collection ID cannot be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        ElseIf Not regexCollectionID.IsMatch(TextBox1.Text) Then
            MessageBox.Show("Invalid Collection ID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        End If

        ' Worker ID Presence Check
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Worker ID cannot be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        ElseIf Not regexWorkerID.IsMatch(TextBox2.Text) Then
            MessageBox.Show("Invalid Worker ID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If

        ' Check if TextBox4 (total amount) is not empty
        If String.IsNullOrEmpty(TextBox4.Text) Then
            MessageBox.Show("Please calculate the total amount before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Check if Collection_ID already exists
        Dim collectionIdExists As Boolean = False
        Dim queryCollectionIdExists As String = "SELECT COUNT(*) FROM daily_collection WHERE Collection_ID = @collectionId"

        Try
            Using connection As New SqlConnection(connectionString)
                Using commandCheckCollectionId As New SqlCommand(queryCollectionIdExists, connection)
                    connection.Open()
                    ' Assuming the Collection_ID is stored in TextBox1.Text
                    commandCheckCollectionId.Parameters.AddWithValue("@collectionId", TextBox1.Text)
                    Dim count As Integer = Convert.ToInt32(commandCheckCollectionId.ExecuteScalar())
                    collectionIdExists = (count > 0)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking Collection ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If collectionIdExists Then
            MessageBox.Show("Collection ID is already taken.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if Worker_ID already exists
        Dim workerIdExists As Boolean = False
        Dim queryWorkerIdExists As String = "SELECT COUNT(*) FROM Worker_table WHERE Worker_ID = @workerId"

        Try
            Using connection As New SqlConnection(connectionString)
                Using commandCheckWorkerId As New SqlCommand(queryWorkerIdExists, connection)
                    connection.Open()
                    ' Use TextBox2.Text to get the Worker_ID
                    commandCheckWorkerId.Parameters.AddWithValue("@workerId", TextBox2.Text)
                    Dim count As Integer = Convert.ToInt32(commandCheckWorkerId.ExecuteScalar())
                    workerIdExists = (count > 0)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking Worker ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If Not workerIdExists Then
            MessageBox.Show("Worker ID does not exist. Please enter a valid Worker ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus() ' Focus on TextBox2
            ' Set TextBox2 as read-only
            TextBox2.ReadOnly = False
            Return
        End If


        ' Insert data into the daily_collection table
        Dim query As String = "INSERT INTO [dbo].[daily_collection] ([Collection_ID], [Worker_ID], [Date_of_collection], [category], [quantity], [amount]) " &
                      "VALUES (@Collection_ID, @Worker_ID, @Date_of_collection, @category, @quantity, @amount)"

        Try
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    ' Add parameters
                    command.Parameters.AddWithValue("@Collection_ID", TextBox1.Text)
                    command.Parameters.AddWithValue("@Worker_ID", TextBox2.Text)
                    command.Parameters.AddWithValue("@Date_of_collection", DateTimePicker1.Value.Date)
                    command.Parameters.AddWithValue("@category", ComboBox1.SelectedItem.ToString())
                    command.Parameters.AddWithValue("@quantity", Convert.ToDecimal(TextBox3.Text)) ' Ensure quantity is a decimal

                    ' Strip "Rs." prefix and convert to decimal
                    Dim amountWithoutPrefix As String = TextBox4.Text.Replace("Rs. ", "")
                    command.Parameters.AddWithValue("@amount", Convert.ToDecimal(amountWithoutPrefix))

                    connection.Open()
                    command.ExecuteNonQuery()

                    MessageBox.Show("Daily collection data inserted successfully", "Confirmation", MessageBoxButtons.OK)
                    ClearInputs()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error inserting collection data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        ' Set TextBox1 as read-only
        TextBox1.ReadOnly = False
        ' Set TextBox2 as read-only
        TextBox2.ReadOnly = False
        ' Set TextBox3 as read-only
        TextBox3.ReadOnly = False
        ComboBox1.Enabled = True
        DateTimePicker1.Enabled = True

    End Sub

    Private Function ValidateInputs() As Boolean ' Frontend validations

        Dim regexCollectionID As New Regex("^C\d+$")


        Dim regexWorkerID As New Regex("^W\d+$")

        ' Get today's date and yesterday's date
        Dim today As Date = Date.Today
        Dim yesterday As Date = today.AddDays(-1)

        ' Collection ID Presence Check
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Collection ID cannot be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Return False
        ElseIf Not regexCollectionID.IsMatch(TextBox1.Text) Then
            MessageBox.Show("Invalid Collection ID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Return False
        End If

        ' Worker ID Presence Check
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Worker ID cannot be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Return False
        ElseIf Not regexWorkerID.IsMatch(TextBox2.Text) Then
            MessageBox.Show("Invalid Worker ID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Return False
        End If

        ' Check if the selected date is today's or yesterday's date
        If DateTimePicker1.Value.Date <> today AndAlso DateTimePicker1.Value.Date <> yesterday Then
            MessageBox.Show("Only todays and yesterdays entry allowed", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker1.Focus()
            Return False
        End If

        ' Check if Category is selected from ComboBox1
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Please select the Category", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Return False
        End If

        ' Checking the Quantity
        If String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("Quantity cannot be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return False
        Else
            Dim quantity As Decimal
            If Not Decimal.TryParse(TextBox3.Text, quantity) Then
                MessageBox.Show("Quantity must be a valid number", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox3.Focus()
                Return False
            ElseIf quantity = 0 OrElse TextBox3.Text.StartsWith("0") Then
                MessageBox.Show("Quantity cannot be zero or start with zero", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox3.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub ClearInputs()
        ' Clear all textboxes
        TextBox1.Text = "C"
        TextBox2.Text = "W"
        DateTimePicker1.Value = DateTime.Today ' Clear DateTimePicker1
        TextBox3.Text = ""
        TextBox4.Text = ""


        ' Reset to default ComboBox1 (Category)
        ComboBox1.SelectedIndex = -1

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Clear all textboxes
        TextBox1.Text = "C"
        TextBox2.Text = "W"
        DateTimePicker1.Value = DateTime.Today ' Clear DateTimePicker1
        TextBox3.Text = ""
        TextBox4.Text = ""


        ' Reset to default ComboBox1 (Category)
        ComboBox1.SelectedIndex = -1

        ' Enable textboxes and comboboxes
        ' Set TextBox1 as read-only
        TextBox1.ReadOnly = False
        ' Set TextBox2 as read-only
        TextBox2.ReadOnly = False
        ' Set TextBox3 as read-only
        TextBox3.ReadOnly = False


        ComboBox1.Enabled = True
        DateTimePicker1.Enabled = True

    End Sub

    Private Sub CalculateAmount()
        Dim unitPrice As Decimal = 0

        For Each item As Object In ComboBox1.Items
            Select Case item.ToString()
                Case "Ferrous Metals"
                    unitPrice = 100 ' Example unit price for Ferrous Metals
                Case "Non-Ferrous Metals"
                    unitPrice = 80 ' Example unit price for Non-Ferrous Metals
                Case "Electronic (E-Scrap)"
                    unitPrice = 60 ' Example unit price for Electronic (E-Scrap)
                Case "Automotive Scrap"
                    unitPrice = 50 ' Example unit price for Automotive Scrap
                Case "Appliance Scrap"
                    unitPrice = 40 ' Example unit price for Appliance Scrap
                Case "Plastic Scrap"
                    unitPrice = 20 ' Example unit price for Plastic Scrap
                Case "Paper and Cardboard"
                    unitPrice = 24 ' Example unit price for Paper and Cardboard
                Case "Glass Scrap"
                    unitPrice = 30 ' Example unit price for Glass Scrap
                Case "Rubber Scrap"
                    unitPrice = 36 ' Example unit price for Rubber Scrap
                Case "Textile Scrap"
                    unitPrice = 44 ' Example unit price for Textile Scrap
            End Select
        Next

        ' Check if quantity is valid
        Dim quantity As Decimal
        If Decimal.TryParse(TextBox3.Text, quantity) AndAlso quantity > 0 Then
            Dim amount As Decimal = unitPrice * quantity
            TextBox4.Text = "Rs. " & amount.ToString() ' Display the calculated amount in TextBox4 with "Rs." prefix

            ' Set TextBox1 as read-only
            TextBox1.ReadOnly = True
            ' Set TextBox2 as read-only
            TextBox2.ReadOnly = True
            ' Set TextBox3 as read-only
            TextBox3.ReadOnly = True
            ' Set TextBox4 as read-only
            TextBox4.ReadOnly = True
            ComboBox1.Enabled = False
            DateTimePicker1.Enabled = False
        Else
            TextBox4.Clear() ' Clear TextBox4 if quantity is not valid
        End If
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Perform frontend validations
        If Not ValidateInputs() Then
            Return
        End If

        ' Perform the calculation and update TextBox4 with the calculated amount
        CalculateAmount()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Generate the next collection ID and display it in TextBox1
        TextBox1.Text = GenerateNextCollectionIDFromDatabase()

        ' Disable TextBox1 to prevent editing
        TextBox1.Enabled = False

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

        ' Reset TextBox4 if quantity is being edited
        TextBox4.Clear()
    End Sub
End Class