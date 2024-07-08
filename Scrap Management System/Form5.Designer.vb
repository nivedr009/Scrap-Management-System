<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form5))
        Label1 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        GroupBox1 = New GroupBox()
        TextBox3 = New TextBox()
        TextBox4 = New TextBox()
        ComboBox1 = New ComboBox()
        DateTimePicker1 = New DateTimePicker()
        TextBox2 = New TextBox()
        TextBox1 = New TextBox()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Button4 = New Button()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("SketchFlow Print", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(199, 36)
        Label1.Name = "Label1"
        Label1.Size = New Size(375, 32)
        Label1.TabIndex = 0
        Label1.Text = "Daily Scrap Collection"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(510, 389)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 1
        Button1.Text = "Save"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(407, 389)
        Button2.Name = "Button2"
        Button2.Size = New Size(94, 29)
        Button2.TabIndex = 2
        Button2.Text = "Cancel"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(304, 389)
        Button3.Name = "Button3"
        Button3.Size = New Size(94, 29)
        Button3.TabIndex = 3
        Button3.Text = "Clear"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = SystemColors.ActiveCaption
        GroupBox1.Controls.Add(TextBox3)
        GroupBox1.Controls.Add(TextBox4)
        GroupBox1.Controls.Add(ComboBox1)
        GroupBox1.Controls.Add(DateTimePicker1)
        GroupBox1.Controls.Add(TextBox2)
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Location = New Point(199, 71)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(405, 312)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(151, 212)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(224, 27)
        TextBox3.TabIndex = 19
        ' 
        ' TextBox4
        ' 
        TextBox4.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TextBox4.Location = New Point(151, 258)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(224, 31)
        TextBox4.TabIndex = 18
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(151, 164)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(224, 28)
        ComboBox1.TabIndex = 17
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(151, 116)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(224, 27)
        DateTimePicker1.TabIndex = 16
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(151, 69)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(224, 27)
        TextBox2.TabIndex = 11
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(151, 26)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(224, 27)
        TextBox1.TabIndex = 5
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(15, 261)
        Label7.Name = "Label7"
        Label7.Size = New Size(99, 20)
        Label7.TabIndex = 10
        Label7.Text = "Total Amount"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(15, 215)
        Label6.Name = "Label6"
        Label6.Size = New Size(112, 20)
        Label6.TabIndex = 9
        Label6.Text = "Quantity in Kg's"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(15, 167)
        Label5.Name = "Label5"
        Label5.Size = New Size(69, 20)
        Label5.TabIndex = 8
        Label5.Text = "Category"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(15, 121)
        Label4.Name = "Label4"
        Label4.Size = New Size(130, 20)
        Label4.TabIndex = 7
        Label4.Text = "Date of Collection"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(15, 71)
        Label3.Name = "Label3"
        Label3.Size = New Size(75, 20)
        Label3.TabIndex = 6
        Label3.Text = "Worker ID"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(15, 29)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 20)
        Label2.TabIndex = 5
        Label2.Text = "Collection ID"
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(199, 389)
        Button4.Name = "Button4"
        Button4.Size = New Size(94, 29)
        Button4.TabIndex = 5
        Button4.Text = "Calculate"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Form5
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(800, 450)
        Controls.Add(Button4)
        Controls.Add(GroupBox1)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Name = "Form5"
        Text = "Form5"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Button4 As Button
End Class
