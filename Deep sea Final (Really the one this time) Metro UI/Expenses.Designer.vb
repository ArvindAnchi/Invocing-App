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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.FLine7 = New Deep_sea_Final__Really_the_one_this_time__Metro_UI.FLine()
        Me.FLine5 = New Deep_sea_Final__Really_the_one_this_time__Metro_UI.FLine()
        Me.FLine4 = New Deep_sea_Final__Really_the_one_this_time__Metro_UI.FLine()
        Me.FLine3 = New Deep_sea_Final__Really_the_one_this_time__Metro_UI.FLine()
        Me.FLine2 = New Deep_sea_Final__Really_the_one_this_time__Metro_UI.FLine()
        Me.FLine1 = New Deep_sea_Final__Really_the_one_this_time__Metro_UI.FLine()
        CType(Me.ExpDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(274, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(58, 15)
        Me.Label20.TabIndex = 209
        Me.Label20.Text = "Company"
        '
        'aereftxt
        '
        Me.aereftxt.Location = New System.Drawing.Point(15, 27)
        Me.aereftxt.Name = "aereftxt"
        Me.aereftxt.Size = New System.Drawing.Size(225, 21)
        Me.aereftxt.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 15)
        Me.Label1.TabIndex = 204
        Me.Label1.Text = "Reference Number"
        '
        'aedtpicker
        '
        Me.aedtpicker.CustomFormat = "dd-MMM-yyyy"
        Me.aedtpicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.aedtpicker.Location = New System.Drawing.Point(277, 69)
        Me.aedtpicker.Name = "aedtpicker"
        Me.aedtpicker.Size = New System.Drawing.Size(362, 21)
        Me.aedtpicker.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(274, 51)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 15)
        Me.Label15.TabIndex = 206
        Me.Label15.Text = "Date"
        '
        'aeclrlbtn
        '
        Me.aeclrlbtn.Location = New System.Drawing.Point(408, 101)
        Me.aeclrlbtn.Name = "aeclrlbtn"
        Me.aeclrlbtn.Size = New System.Drawing.Size(103, 36)
        Me.aeclrlbtn.TabIndex = 217
        Me.aeclrlbtn.Text = "Clear"
        Me.aeclrlbtn.UseVisualStyleBackColor = True
        '
        'aeaddbtn
        '
        Me.aeaddbtn.Location = New System.Drawing.Point(517, 101)
        Me.aeaddbtn.Name = "aeaddbtn"
        Me.aeaddbtn.Size = New System.Drawing.Size(122, 36)
        Me.aeaddbtn.TabIndex = 216
        Me.aeaddbtn.Text = "Add"
        Me.aeaddbtn.UseVisualStyleBackColor = True
        '
        'aeammounttxt
        '
        Me.aeammounttxt.Location = New System.Drawing.Point(15, 69)
        Me.aeammounttxt.Name = "aeammounttxt"
        Me.aeammounttxt.Size = New System.Drawing.Size(225, 21)
        Me.aeammounttxt.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 218
        Me.Label2.Text = "Amount"
        '
        'aecomptxt
        '
        Me.aecomptxt.Location = New System.Drawing.Point(277, 27)
        Me.aecomptxt.Name = "aecomptxt"
        Me.aecomptxt.Size = New System.Drawing.Size(362, 21)
        Me.aecomptxt.TabIndex = 1
        '
        'ExpDGV
        '
        Me.ExpDGV.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Azure
        Me.ExpDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.ExpDGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExpDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ExpDGV.BackgroundColor = System.Drawing.Color.White
        Me.ExpDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ExpDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.ExpDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ExpDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.ExpDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ExpDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.ExpDGV.EnableHeadersVisualStyles = False
        Me.ExpDGV.GridColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ExpDGV.Location = New System.Drawing.Point(15, 152)
        Me.ExpDGV.Name = "ExpDGV"
        Me.ExpDGV.ReadOnly = True
        Me.ExpDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.ExpDGV.RowHeadersVisible = False
        Me.ExpDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ExpDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ExpDGV.Size = New System.Drawing.Size(624, 231)
        Me.ExpDGV.TabIndex = 221
        '
        'FLine7
        '
        Me.FLine7.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine7.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine7.Appearance.Options.UseBackColor = True
        Me.FLine7.Appearance.Options.UseForeColor = True
        Me.FLine7.Location = New System.Drawing.Point(15, 382)
        Me.FLine7.Name = "FLine7"
        Me.FLine7.Size = New System.Drawing.Size(624, 1)
        Me.FLine7.TabIndex = 228
        '
        'FLine5
        '
        Me.FLine5.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine5.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine5.Appearance.Options.UseBackColor = True
        Me.FLine5.Appearance.Options.UseForeColor = True
        Me.FLine5.Location = New System.Drawing.Point(638, 204)
        Me.FLine5.Name = "FLine5"
        Me.FLine5.Size = New System.Drawing.Size(1, 179)
        Me.FLine5.TabIndex = 227
        '
        'FLine4
        '
        Me.FLine4.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine4.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine4.Appearance.Options.UseBackColor = True
        Me.FLine4.Appearance.Options.UseForeColor = True
        Me.FLine4.Location = New System.Drawing.Point(540, 204)
        Me.FLine4.Name = "FLine4"
        Me.FLine4.Size = New System.Drawing.Size(1, 179)
        Me.FLine4.TabIndex = 226
        '
        'FLine3
        '
        Me.FLine3.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine3.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine3.Appearance.Options.UseBackColor = True
        Me.FLine3.Appearance.Options.UseForeColor = True
        Me.FLine3.Location = New System.Drawing.Point(441, 204)
        Me.FLine3.Name = "FLine3"
        Me.FLine3.Size = New System.Drawing.Size(1, 179)
        Me.FLine3.TabIndex = 225
        '
        'FLine2
        '
        Me.FLine2.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine2.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine2.Appearance.Options.UseBackColor = True
        Me.FLine2.Appearance.Options.UseForeColor = True
        Me.FLine2.Location = New System.Drawing.Point(113, 204)
        Me.FLine2.Name = "FLine2"
        Me.FLine2.Size = New System.Drawing.Size(1, 179)
        Me.FLine2.TabIndex = 224
        '
        'FLine1
        '
        Me.FLine1.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine1.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine1.Appearance.Options.UseBackColor = True
        Me.FLine1.Appearance.Options.UseForeColor = True
        Me.FLine1.Location = New System.Drawing.Point(15, 204)
        Me.FLine1.Name = "FLine1"
        Me.FLine1.Size = New System.Drawing.Size(1, 179)
        Me.FLine1.TabIndex = 223
        '
        'Expenses
        '
        Me.AcceptButton = Me.aeaddbtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 395)
        Me.Controls.Add(Me.FLine7)
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
        Me.Name = "Expenses"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add expenses"
        CType(Me.ExpDGV, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents FLine7 As FLine
End Class
