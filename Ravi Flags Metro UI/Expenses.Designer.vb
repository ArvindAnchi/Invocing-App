<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Expenses
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.aereftxt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.aedtpicker = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.aeclrlbtn = New System.Windows.Forms.Button()
        Me.aeaddbtn = New System.Windows.Forms.Button()
        Me.aeammounttxt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.aecomptxt = New System.Windows.Forms.TextBox()
        Me.ExpDGV = New System.Windows.Forms.DataGridView()
        Me.aetrntxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.FLine9 = New Ravi_flags_Metro_UI.FLine()
        Me.FLine8 = New Ravi_flags_Metro_UI.FLine()
        Me.FLine6 = New Ravi_flags_Metro_UI.FLine()
        Me.FLine5 = New Ravi_flags_Metro_UI.FLine()
        Me.FLine4 = New Ravi_flags_Metro_UI.FLine()
        Me.FLine3 = New Ravi_flags_Metro_UI.FLine()
        Me.FLine2 = New Ravi_flags_Metro_UI.FLine()
        Me.FLine1 = New Ravi_flags_Metro_UI.FLine()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        CType(Me.ExpDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(12, 12)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 15)
        Me.Label20.TabIndex = 209
        Me.Label20.Text = "Supplier"
        '
        'aereftxt
        '
        Me.aereftxt.Location = New System.Drawing.Point(15, 72)
        Me.aereftxt.Name = "aereftxt"
        Me.aereftxt.Size = New System.Drawing.Size(225, 21)
        Me.aereftxt.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 15)
        Me.Label1.TabIndex = 204
        Me.Label1.Text = "Reference Number"
        '
        'aedtpicker
        '
        Me.aedtpicker.CustomFormat = "dd-MMM-yyyy"
        Me.aedtpicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.aedtpicker.Location = New System.Drawing.Point(277, 72)
        Me.aedtpicker.Name = "aedtpicker"
        Me.aedtpicker.Size = New System.Drawing.Size(362, 21)
        Me.aedtpicker.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(274, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 15)
        Me.Label15.TabIndex = 206
        Me.Label15.Text = "Date"
        '
        'aeclrlbtn
        '
        Me.aeclrlbtn.Location = New System.Drawing.Point(378, 105)
        Me.aeclrlbtn.Name = "aeclrlbtn"
        Me.aeclrlbtn.Size = New System.Drawing.Size(73, 36)
        Me.aeclrlbtn.TabIndex = 217
        Me.aeclrlbtn.Text = "Clear"
        Me.aeclrlbtn.UseVisualStyleBackColor = True
        '
        'aeaddbtn
        '
        Me.aeaddbtn.Location = New System.Drawing.Point(457, 105)
        Me.aeaddbtn.Name = "aeaddbtn"
        Me.aeaddbtn.Size = New System.Drawing.Size(92, 36)
        Me.aeaddbtn.TabIndex = 216
        Me.aeaddbtn.Text = "Add"
        Me.aeaddbtn.UseVisualStyleBackColor = True
        '
        'aeammounttxt
        '
        Me.aeammounttxt.Location = New System.Drawing.Point(15, 114)
        Me.aeammounttxt.Name = "aeammounttxt"
        Me.aeammounttxt.Size = New System.Drawing.Size(225, 21)
        Me.aeammounttxt.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 218
        Me.Label2.Text = "Amount"
        '
        'aecomptxt
        '
        Me.aecomptxt.Location = New System.Drawing.Point(15, 30)
        Me.aecomptxt.Name = "aecomptxt"
        Me.aecomptxt.Size = New System.Drawing.Size(225, 21)
        Me.aecomptxt.TabIndex = 0
        '
        'ExpDGV
        '
        Me.ExpDGV.AllowUserToAddRows = False
        Me.ExpDGV.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.ExpDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ExpDGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExpDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ExpDGV.BackgroundColor = System.Drawing.Color.White
        Me.ExpDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ExpDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.ExpDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ExpDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.ExpDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ExpDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.ExpDGV.EnableHeadersVisualStyles = False
        Me.ExpDGV.GridColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ExpDGV.Location = New System.Drawing.Point(12, 158)
        Me.ExpDGV.Name = "ExpDGV"
        Me.ExpDGV.ReadOnly = True
        Me.ExpDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.ExpDGV.RowHeadersVisible = False
        Me.ExpDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ExpDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ExpDGV.Size = New System.Drawing.Size(976, 489)
        Me.ExpDGV.TabIndex = 221
        '
        'aetrntxt
        '
        Me.aetrntxt.Location = New System.Drawing.Point(277, 30)
        Me.aetrntxt.Name = "aetrntxt"
        Me.aetrntxt.Size = New System.Drawing.Size(362, 21)
        Me.aetrntxt.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(274, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 15)
        Me.Label3.TabIndex = 231
        Me.Label3.Text = "TRN Number"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(277, 105)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 36)
        Me.Button1.TabIndex = 232
        Me.Button1.Text = "Export to excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(24, 44)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(190, 21)
        Me.DateTimePicker1.TabIndex = 235
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 15)
        Me.Label4.TabIndex = 236
        Me.Label4.Text = "Start Date"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(24, 86)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(190, 21)
        Me.DateTimePicker2.TabIndex = 237
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 15)
        Me.Label5.TabIndex = 238
        Me.Label5.Text = "End Date"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(657, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(334, 126)
        Me.GroupBox1.TabIndex = 239
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(228, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 92)
        Me.Button2.TabIndex = 240
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 648)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1003, 22)
        Me.StatusStrip1.TabIndex = 240
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'FLine9
        '
        Me.FLine9.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine9.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine9.Appearance.Options.UseBackColor = True
        Me.FLine9.Appearance.Options.UseForeColor = True
        Me.FLine9.Location = New System.Drawing.Point(532, 205)
        Me.FLine9.Name = "FLine9"
        Me.FLine9.Size = New System.Drawing.Size(1, 442)
        Me.FLine9.TabIndex = 234
        '
        'FLine8
        '
        Me.FLine8.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine8.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine8.Appearance.Options.UseBackColor = True
        Me.FLine8.Appearance.Options.UseForeColor = True
        Me.FLine8.Location = New System.Drawing.Point(695, 205)
        Me.FLine8.Name = "FLine8"
        Me.FLine8.Size = New System.Drawing.Size(1, 442)
        Me.FLine8.TabIndex = 233
        '
        'FLine6
        '
        Me.FLine6.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine6.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine6.Appearance.Options.UseBackColor = True
        Me.FLine6.Appearance.Options.UseForeColor = True
        Me.FLine6.Location = New System.Drawing.Point(207, 205)
        Me.FLine6.Name = "FLine6"
        Me.FLine6.Size = New System.Drawing.Size(1, 442)
        Me.FLine6.TabIndex = 229
        '
        'FLine5
        '
        Me.FLine5.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine5.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine5.Appearance.Options.UseBackColor = True
        Me.FLine5.Appearance.Options.UseForeColor = True
        Me.FLine5.Location = New System.Drawing.Point(987, 206)
        Me.FLine5.Name = "FLine5"
        Me.FLine5.Size = New System.Drawing.Size(1, 442)
        Me.FLine5.TabIndex = 227
        '
        'FLine4
        '
        Me.FLine4.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine4.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine4.Appearance.Options.UseBackColor = True
        Me.FLine4.Appearance.Options.UseForeColor = True
        Me.FLine4.Location = New System.Drawing.Point(890, 205)
        Me.FLine4.Name = "FLine4"
        Me.FLine4.Size = New System.Drawing.Size(1, 442)
        Me.FLine4.TabIndex = 226
        '
        'FLine3
        '
        Me.FLine3.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine3.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine3.Appearance.Options.UseBackColor = True
        Me.FLine3.Appearance.Options.UseForeColor = True
        Me.FLine3.Location = New System.Drawing.Point(792, 205)
        Me.FLine3.Name = "FLine3"
        Me.FLine3.Size = New System.Drawing.Size(1, 442)
        Me.FLine3.TabIndex = 225
        '
        'FLine2
        '
        Me.FLine2.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine2.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine2.Appearance.Options.UseBackColor = True
        Me.FLine2.Appearance.Options.UseForeColor = True
        Me.FLine2.Location = New System.Drawing.Point(110, 205)
        Me.FLine2.Name = "FLine2"
        Me.FLine2.Size = New System.Drawing.Size(1, 442)
        Me.FLine2.TabIndex = 224
        '
        'FLine1
        '
        Me.FLine1.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine1.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine1.Appearance.Options.UseBackColor = True
        Me.FLine1.Appearance.Options.UseForeColor = True
        Me.FLine1.Location = New System.Drawing.Point(12, 206)
        Me.FLine1.Name = "FLine1"
        Me.FLine1.Size = New System.Drawing.Size(1, 442)
        Me.FLine1.TabIndex = 223
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(555, 116)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(86, 17)
        Me.CheckBox1.TabIndex = 241
        Me.CheckBox1.Text = "Fill from DGV"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Expenses
        '
        Me.AcceptButton = Me.aeaddbtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 670)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.FLine9)
        Me.Controls.Add(Me.FLine8)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.aetrntxt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.FLine6)
        Me.Controls.Add(Me.FLine5)
        Me.Controls.Add(Me.FLine4)
        Me.Controls.Add(Me.FLine3)
        Me.Controls.Add(Me.FLine2)
        Me.Controls.Add(Me.FLine1)
        Me.Controls.Add(Me.ExpDGV)
        Me.Controls.Add(Me.aecomptxt)
        Me.Controls.Add(Me.aeammounttxt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.aeclrlbtn)
        Me.Controls.Add(Me.aeaddbtn)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.aereftxt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.aedtpicker)
        Me.Controls.Add(Me.Label15)
        Me.IconOptions.ShowIcon = False
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1003, 700)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1003, 700)
        Me.Name = "Expenses"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add expenses"
        CType(Me.ExpDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label20 As Label
    Friend WithEvents aereftxt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents aedtpicker As DateTimePicker
    Friend WithEvents Label15 As Label
    Friend WithEvents aeclrlbtn As Button
    Friend WithEvents aeaddbtn As Button
    Friend WithEvents aeammounttxt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents aecomptxt As TextBox
    Friend WithEvents ExpDGV As DataGridView
    Friend WithEvents FLine1 As FLine
    Friend WithEvents FLine2 As FLine
    Friend WithEvents FLine3 As FLine
    Friend WithEvents FLine4 As FLine
    Friend WithEvents FLine5 As FLine
    Friend WithEvents FLine6 As FLine
    Friend WithEvents aetrntxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents FLine8 As FLine
    Friend WithEvents FLine9 As FLine
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents CheckBox1 As CheckBox
End Class
