<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Label1 = New Label()
        Button3 = New Button()
        Button1 = New Button()
        PictureBox1 = New PictureBox()
        Label2 = New Label()
        TextBox1 = New TextBox()
        Button2 = New Button()
        Label3 = New Label()
        Button4 = New Button()
        TextBox2 = New TextBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.ActiveCaptionText
        Label1.Font = New Font("SketchFlow Print", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ControlLightLight
        Label1.Location = New Point(338, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(125, 42)
        Label1.TabIndex = 0
        Label1.Text = "Login"
        ' 
        ' Button3
        ' 
        Button3.BackColor = SystemColors.ActiveCaptionText
        Button3.ForeColor = SystemColors.ControlLightLight
        Button3.Location = New Point(395, 193)
        Button3.Name = "Button3"
        Button3.Size = New Size(119, 29)
        Button3.TabIndex = 8
        Button3.Text = "EXIT"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.ActiveCaptionText
        Button1.Font = New Font("Microsoft Sans Serif", 8.25F)
        Button1.ForeColor = SystemColors.ControlLightLight
        Button1.Location = New Point(266, 193)
        Button1.Name = "Button1"
        Button1.Size = New Size(118, 29)
        Button1.TabIndex = 2
        Button1.Text = "LOGIN"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(801, 452)
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Black
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ControlLightLight
        Label2.Location = New Point(46, 63)
        Label2.Name = "Label2"
        Label2.Size = New Size(99, 28)
        Label2.TabIndex = 2
        Label2.Text = "Username"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(46, 94)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(282, 27)
        TextBox1.TabIndex = 4
        ' 
        ' Button2
        ' 
        Button2.BackColor = SystemColors.ActiveCaptionText
        Button2.ForeColor = SystemColors.ControlLightLight
        Button2.Location = New Point(572, 152)
        Button2.Name = "Button2"
        Button2.Size = New Size(119, 29)
        Button2.TabIndex = 7
        Button2.Text = "CANCEL"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.ActiveCaptionText
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ControlLightLight
        Label3.Location = New Point(474, 63)
        Label3.Name = "Label3"
        Label3.Size = New Size(93, 28)
        Label3.TabIndex = 5
        Label3.Text = "Password"
        ' 
        ' Button4
        ' 
        Button4.BackColor = SystemColors.ActiveCaptionText
        Button4.ForeColor = SystemColors.ControlLightLight
        Button4.Location = New Point(131, 152)
        Button4.Name = "Button4"
        Button4.Size = New Size(118, 29)
        Button4.TabIndex = 9
        Button4.Text = "CLEAR"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(474, 94)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(282, 27)
        TextBox2.TabIndex = 6
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button2)
        Controls.Add(Button4)
        Controls.Add(TextBox2)
        Controls.Add(Button3)
        Controls.Add(Label3)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Controls.Add(TextBox1)
        Controls.Add(Label2)
        Controls.Add(PictureBox1)
        Name = "Form2"
        Text = "Form2"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents TextBox2 As TextBox
End Class
