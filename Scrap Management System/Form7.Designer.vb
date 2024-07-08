<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7))
        Label1 = New Label()
        GroupBox1 = New GroupBox()
        DataGridView1 = New DataGridView()
        TextBox4 = New TextBox()
        Label7 = New Label()
        TextBox3 = New TextBox()
        TextBox2 = New TextBox()
        TextBox1 = New TextBox()
        ComboBox2 = New ComboBox()
        ComboBox1 = New ComboBox()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        GroupBox1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("SketchFlow Print", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(429, 32)
        Label1.TabIndex = 0
        Label1.Text = "Monthly Profit Calculation"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = SystemColors.ActiveCaption
        GroupBox1.Controls.Add(DataGridView1)
        GroupBox1.Controls.Add(TextBox4)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(TextBox3)
        GroupBox1.Controls.Add(TextBox2)
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Controls.Add(ComboBox2)
        GroupBox1.Controls.Add(ComboBox1)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Location = New Point(12, 64)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(776, 327)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BackgroundColor = SystemColors.ActiveCaption
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(362, 24)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(408, 287)
        DataGridView1.TabIndex = 16
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(147, 30)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(209, 27)
        TextBox4.TabIndex = 15
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(16, 33)
        Label7.Name = "Label7"
        Label7.Size = New Size(64, 20)
        Label7.TabIndex = 6
        Label7.Text = "Profit ID"
        ' 
        ' TextBox3
        ' 
        TextBox3.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TextBox3.Location = New Point(147, 281)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(209, 30)
        TextBox3.TabIndex = 14
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(147, 233)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(209, 27)
        TextBox2.TabIndex = 6
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(147, 185)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(209, 27)
        TextBox1.TabIndex = 13
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(147, 134)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(209, 28)
        ComboBox2.TabIndex = 12
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(147, 82)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(209, 28)
        ComboBox1.TabIndex = 11
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(16, 284)
        Label6.Name = "Label6"
        Label6.Size = New Size(82, 20)
        Label6.TabIndex = 10
        Label6.Text = "Total Profit"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(16, 236)
        Label5.Name = "Label5"
        Label5.Size = New Size(125, 20)
        Label5.TabIndex = 9
        Label5.Text = "Total Expenditure"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(16, 188)
        Label4.Name = "Label4"
        Label4.Size = New Size(113, 20)
        Label4.TabIndex = 8
        Label4.Text = "Total Collection"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(16, 137)
        Label3.Name = "Label3"
        Label3.Size = New Size(37, 20)
        Label3.TabIndex = 7
        Label3.Text = "Year"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(16, 85)
        Label2.Name = "Label2"
        Label2.Size = New Size(52, 20)
        Label2.TabIndex = 6
        Label2.Text = "Month"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(274, 397)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 2
        Button1.Text = "Save"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(694, 397)
        Button2.Name = "Button2"
        Button2.Size = New Size(94, 29)
        Button2.TabIndex = 3
        Button2.Text = "Cancel"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(12, 397)
        Button3.Name = "Button3"
        Button3.Size = New Size(94, 29)
        Button3.TabIndex = 4
        Button3.Text = "Calculate"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(141, 397)
        Button4.Name = "Button4"
        Button4.Size = New Size(94, 29)
        Button4.TabIndex = 5
        Button4.Text = "Clear"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Form7
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(800, 450)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(GroupBox1)
        Controls.Add(Label1)
        Name = "Form7"
        Text = "Form7"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents DataGridView1 As DataGridView
End Class
