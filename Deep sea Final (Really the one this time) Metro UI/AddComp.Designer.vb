<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddComp
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ncnametxt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ntrntxt = New System.Windows.Forms.TextBox()
        Me.ncitytxt = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.nemailtxt = New System.Windows.Forms.TextBox()
        Me.nccnslbtn = New System.Windows.Forms.Button()
        Me.ncokbtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nDiscText = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ncnametxt
        '
        Me.ncnametxt.Location = New System.Drawing.Point(25, 40)
        Me.ncnametxt.Name = "ncnametxt"
        Me.ncnametxt.Size = New System.Drawing.Size(277, 21)
        Me.ncnametxt.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 15)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Company name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(164, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 15)
        Me.Label3.TabIndex = 171
        Me.Label3.Text = "TRN number"
        '
        'ntrntxt
        '
        Me.ntrntxt.Location = New System.Drawing.Point(167, 90)
        Me.ntrntxt.MaximumSize = New System.Drawing.Size(363, 20)
        Me.ntrntxt.Name = "ntrntxt"
        Me.ntrntxt.Size = New System.Drawing.Size(203, 21)
        Me.ntrntxt.TabIndex = 3
        '
        'ncitytxt
        '
        Me.ncitytxt.Location = New System.Drawing.Point(25, 90)
        Me.ncitytxt.MaximumSize = New System.Drawing.Size(363, 20)
        Me.ncitytxt.Name = "ncitytxt"
        Me.ncitytxt.Size = New System.Drawing.Size(136, 21)
        Me.ncitytxt.TabIndex = 2
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(22, 126)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(198, 15)
        Me.Label21.TabIndex = 172
        Me.Label21.Text = "E-Mail address (To send statement)"
        '
        'nemailtxt
        '
        Me.nemailtxt.Location = New System.Drawing.Point(23, 144)
        Me.nemailtxt.MaximumSize = New System.Drawing.Size(363, 20)
        Me.nemailtxt.Name = "nemailtxt"
        Me.nemailtxt.Size = New System.Drawing.Size(347, 21)
        Me.nemailtxt.TabIndex = 4
        '
        'nccnslbtn
        '
        Me.nccnslbtn.Location = New System.Drawing.Point(194, 201)
        Me.nccnslbtn.Name = "nccnslbtn"
        Me.nccnslbtn.Size = New System.Drawing.Size(110, 37)
        Me.nccnslbtn.TabIndex = 6
        Me.nccnslbtn.Text = "Cancel"
        Me.nccnslbtn.UseVisualStyleBackColor = True
        '
        'ncokbtn
        '
        Me.ncokbtn.Location = New System.Drawing.Point(78, 201)
        Me.ncokbtn.Name = "ncokbtn"
        Me.ncokbtn.Size = New System.Drawing.Size(110, 37)
        Me.ncokbtn.TabIndex = 5
        Me.ncokbtn.Text = "OK"
        Me.ncokbtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 15)
        Me.Label2.TabIndex = 174
        Me.Label2.Text = "City"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(305, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 15)
        Me.Label4.TabIndex = 176
        Me.Label4.Text = "Discount"
        '
        'nDiscText
        '
        Me.nDiscText.Location = New System.Drawing.Point(308, 41)
        Me.nDiscText.MaximumSize = New System.Drawing.Size(363, 20)
        Me.nDiscText.MaxLength = 2
        Me.nDiscText.Name = "nDiscText"
        Me.nDiscText.Size = New System.Drawing.Size(62, 20)
        Me.nDiscText.TabIndex = 1
        '
        'AddComp
        '
        Me.AcceptButton = Me.ncokbtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 261)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nDiscText)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ncnametxt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ntrntxt)
        Me.Controls.Add(Me.ncitytxt)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.nemailtxt)
        Me.Controls.Add(Me.nccnslbtn)
        Me.Controls.Add(Me.ncokbtn)
        Me.IconOptions.ShowIcon = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddComp"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Company"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ncnametxt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ntrntxt As TextBox
    Friend WithEvents ncitytxt As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents nemailtxt As TextBox
    Friend WithEvents nccnslbtn As Button
    Friend WithEvents ncokbtn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents nDiscText As TextBox
End Class
