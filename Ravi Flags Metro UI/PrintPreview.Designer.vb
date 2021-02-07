<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintPreview
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
        Me.TextColorComboBox = New System.Windows.Forms.ComboBox()
        Me.PrintPreviewControl = New System.Windows.Forms.PrintPreviewControl()
        Me.PrintDocument = New System.Drawing.Printing.PrintDocument()
        Me.PageNoLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ZoomSlider = New System.Windows.Forms.TrackBar()
        Me.CopiesTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PrinterComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PrintCanBtn = New System.Windows.Forms.Button()
        Me.PrintBtn = New System.Windows.Forms.Button()
        Me.BlackWhiteCheckBox = New System.Windows.Forms.CheckBox()
        Me.PrintQualityComboBox = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TotalPagesTextBox = New System.Windows.Forms.TextBox()
        Me.TotalPagesLabel = New System.Windows.Forms.Label()
        Me.NextPageButton = New System.Windows.Forms.Button()
        Me.PreviousPageButton = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.ZoomSlider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextColorComboBox
        '
        Me.TextColorComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TextColorComboBox.FormattingEnabled = True
        Me.TextColorComboBox.Items.AddRange(New Object() {"Gray", "DimGray", "Black", "Blue", "Red"})
        Me.TextColorComboBox.Location = New System.Drawing.Point(508, 77)
        Me.TextColorComboBox.Name = "TextColorComboBox"
        Me.TextColorComboBox.Size = New System.Drawing.Size(222, 21)
        Me.TextColorComboBox.TabIndex = 53
        '
        'PrintPreviewControl
        '
        Me.PrintPreviewControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrintPreviewControl.AutoZoom = False
        Me.PrintPreviewControl.BackColor = System.Drawing.Color.White
        Me.PrintPreviewControl.Document = Me.PrintDocument
        Me.PrintPreviewControl.Location = New System.Drawing.Point(25, 10)
        Me.PrintPreviewControl.Name = "PrintPreviewControl"
        Me.PrintPreviewControl.Size = New System.Drawing.Size(375, 544)
        Me.PrintPreviewControl.TabIndex = 40
        Me.PrintPreviewControl.Zoom = 0.44740024183796856R
        '
        'PrintDocument
        '
        '
        'PageNoLabel
        '
        Me.PageNoLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PageNoLabel.AutoSize = True
        Me.PageNoLabel.Location = New System.Drawing.Point(279, 572)
        Me.PageNoLabel.Name = "PageNoLabel"
        Me.PageNoLabel.Size = New System.Drawing.Size(31, 13)
        Me.PageNoLabel.TabIndex = 52
        Me.PageNoLabel.Text = "Page"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 572)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Zoom"
        '
        'ZoomSlider
        '
        Me.ZoomSlider.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ZoomSlider.Location = New System.Drawing.Point(62, 558)
        Me.ZoomSlider.Maximum = 200
        Me.ZoomSlider.Minimum = 1
        Me.ZoomSlider.Name = "ZoomSlider"
        Me.ZoomSlider.Size = New System.Drawing.Size(191, 45)
        Me.ZoomSlider.TabIndex = 49
        Me.ZoomSlider.TickFrequency = 5
        Me.ZoomSlider.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.ZoomSlider.Value = 1
        '
        'CopiesTextBox
        '
        Me.CopiesTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CopiesTextBox.Location = New System.Drawing.Point(508, 154)
        Me.CopiesTextBox.Name = "CopiesTextBox"
        Me.CopiesTextBox.Size = New System.Drawing.Size(73, 21)
        Me.CopiesTextBox.TabIndex = 47
        Me.CopiesTextBox.Text = "1"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(448, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Text color"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(462, 157)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Copies"
        '
        'PrinterComboBox
        '
        Me.PrinterComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrinterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PrinterComboBox.FormattingEnabled = True
        Me.PrinterComboBox.Location = New System.Drawing.Point(508, 25)
        Me.PrinterComboBox.Name = "PrinterComboBox"
        Me.PrinterComboBox.Size = New System.Drawing.Size(222, 21)
        Me.PrinterComboBox.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(465, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Printer"
        '
        'PrintCanBtn
        '
        Me.PrintCanBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrintCanBtn.Location = New System.Drawing.Point(449, 539)
        Me.PrintCanBtn.Name = "PrintCanBtn"
        Me.PrintCanBtn.Size = New System.Drawing.Size(128, 55)
        Me.PrintCanBtn.TabIndex = 42
        Me.PrintCanBtn.Text = "Cancel"
        Me.PrintCanBtn.UseVisualStyleBackColor = True
        '
        'PrintBtn
        '
        Me.PrintBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrintBtn.Location = New System.Drawing.Point(592, 539)
        Me.PrintBtn.Name = "PrintBtn"
        Me.PrintBtn.Size = New System.Drawing.Size(138, 55)
        Me.PrintBtn.TabIndex = 41
        Me.PrintBtn.Text = "Print"
        Me.PrintBtn.UseVisualStyleBackColor = True
        '
        'BlackWhiteCheckBox
        '
        Me.BlackWhiteCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BlackWhiteCheckBox.AutoSize = True
        Me.BlackWhiteCheckBox.Checked = True
        Me.BlackWhiteCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.BlackWhiteCheckBox.Location = New System.Drawing.Point(508, 133)
        Me.BlackWhiteCheckBox.Name = "BlackWhiteCheckBox"
        Me.BlackWhiteCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.BlackWhiteCheckBox.TabIndex = 54
        Me.BlackWhiteCheckBox.UseVisualStyleBackColor = True
        '
        'PrintQualityComboBox
        '
        Me.PrintQualityComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrintQualityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PrintQualityComboBox.FormattingEnabled = True
        Me.PrintQualityComboBox.Location = New System.Drawing.Point(508, 104)
        Me.PrintQualityComboBox.Name = "PrintQualityComboBox"
        Me.PrintQualityComboBox.Size = New System.Drawing.Size(222, 21)
        Me.PrintQualityComboBox.TabIndex = 56
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(460, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Quality"
        '
        'TotalPagesTextBox
        '
        Me.TotalPagesTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TotalPagesTextBox.Location = New System.Drawing.Point(316, 569)
        Me.TotalPagesTextBox.Name = "TotalPagesTextBox"
        Me.TotalPagesTextBox.Size = New System.Drawing.Size(27, 21)
        Me.TotalPagesTextBox.TabIndex = 57
        Me.TotalPagesTextBox.Text = "1"
        '
        'TotalPagesLabel
        '
        Me.TotalPagesLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TotalPagesLabel.AutoSize = True
        Me.TotalPagesLabel.Location = New System.Drawing.Point(345, 572)
        Me.TotalPagesLabel.Name = "TotalPagesLabel"
        Me.TotalPagesLabel.Size = New System.Drawing.Size(0, 13)
        Me.TotalPagesLabel.TabIndex = 52
        '
        'NextPageButton
        '
        Me.NextPageButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NextPageButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.NextPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NextPageButton.Location = New System.Drawing.Point(375, 567)
        Me.NextPageButton.Name = "NextPageButton"
        Me.NextPageButton.Size = New System.Drawing.Size(23, 23)
        Me.NextPageButton.TabIndex = 58
        Me.NextPageButton.Text = ">"
        Me.NextPageButton.UseVisualStyleBackColor = True
        '
        'PreviousPageButton
        '
        Me.PreviousPageButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PreviousPageButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PreviousPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PreviousPageButton.Location = New System.Drawing.Point(250, 567)
        Me.PreviousPageButton.Name = "PreviousPageButton"
        Me.PreviousPageButton.Size = New System.Drawing.Size(23, 23)
        Me.PreviousPageButton.TabIndex = 59
        Me.PreviousPageButton.Text = "<"
        Me.PreviousPageButton.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(650, 49)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(80, 13)
        Me.LinkLabel1.TabIndex = 60
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Printer settings"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(438, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Black/White"
        '
        'PrintPreview
        '
        Me.AcceptButton = Me.PrintBtn
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 605)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.PreviousPageButton)
        Me.Controls.Add(Me.NextPageButton)
        Me.Controls.Add(Me.TotalPagesTextBox)
        Me.Controls.Add(Me.PrintQualityComboBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BlackWhiteCheckBox)
        Me.Controls.Add(Me.TextColorComboBox)
        Me.Controls.Add(Me.PrintPreviewControl)
        Me.Controls.Add(Me.TotalPagesLabel)
        Me.Controls.Add(Me.PageNoLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ZoomSlider)
        Me.Controls.Add(Me.CopiesTextBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PrinterComboBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PrintCanBtn)
        Me.Controls.Add(Me.PrintBtn)
        Me.IconOptions.ShowIcon = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(754, 635)
        Me.Name = "PrintPreview"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Preview"
        CType(Me.ZoomSlider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextColorComboBox As ComboBox
    Friend WithEvents PrintPreviewControl As PrintPreviewControl
    Friend WithEvents PrintDocument As Printing.PrintDocument
    Friend WithEvents PageNoLabel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ZoomSlider As TrackBar
    Friend WithEvents CopiesTextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PrinterComboBox As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PrintCanBtn As Button
    Friend WithEvents PrintBtn As Button
    Friend WithEvents BlackWhiteCheckBox As CheckBox
    Friend WithEvents PrintQualityComboBox As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TotalPagesTextBox As TextBox
    Friend WithEvents TotalPagesLabel As Label
    Friend WithEvents NextPageButton As Button
    Friend WithEvents PreviousPageButton As Button
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label4 As Label
End Class
