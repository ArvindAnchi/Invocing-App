<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InvoiceForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvoiceForm))
        Me.FluentDesignFormContainer1 = New DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer()
        Me.VatCB = New System.Windows.Forms.CheckBox()
        Me.AutoCompleteLB = New System.Windows.Forms.ListBox()
        Me.FLine9 = New Ravi_flags_Metro_UI.FLine()
        Me.FLine8 = New Ravi_flags_Metro_UI.FLine()
        Me.FLine7 = New Ravi_flags_Metro_UI.FLine()
        Me.FLine6 = New Ravi_flags_Metro_UI.FLine()
        Me.FLine4 = New Ravi_flags_Metro_UI.FLine()
        Me.FLine3 = New Ravi_flags_Metro_UI.FLine()
        Me.FLine2 = New Ravi_flags_Metro_UI.FLine()
        Me.FLine1 = New Ravi_flags_Metro_UI.FLine()
        Me.prclbl = New System.Windows.Forms.Label()
        Me.InvoiceItemsDGV = New System.Windows.Forms.DataGridView()
        Me.SNoClm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descclm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UCLM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyColm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrcClm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TtlClm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prcnos = New System.Windows.Forms.Label()
        Me.TrmCred = New System.Windows.Forms.RadioButton()
        Me.TrmCash = New System.Windows.Forms.RadioButton()
        Me.TermTXT = New System.Windows.Forms.TextBox()
        Me.disctxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cnametxt = New System.Windows.Forms.ComboBox()
        Me.lpotxt = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.trntxt = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.invnotxt = New System.Windows.Forms.TextBox()
        Me.Ordbycb = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.SaveRibBtn = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.NewInvoiceRibBtn = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.SavePDFRibBtn = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.PrintPrevRibBtn = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.ReloadRibBtn = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.SaveCreditRibBtn = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionContentContainer1 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.AccordionControlElement5 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.FluentDesignFormContainer1.SuspendLayout()
        CType(Me.InvoiceItemsDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FluentDesignFormContainer1
        '
        Me.FluentDesignFormContainer1.Appearance.BackColor = System.Drawing.Color.White
        Me.FluentDesignFormContainer1.Appearance.Options.UseBackColor = True
        Me.FluentDesignFormContainer1.AutoScroll = False
        Me.FluentDesignFormContainer1.Controls.Add(Me.VatCB)
        Me.FluentDesignFormContainer1.Controls.Add(Me.AutoCompleteLB)
        Me.FluentDesignFormContainer1.Controls.Add(Me.FLine9)
        Me.FluentDesignFormContainer1.Controls.Add(Me.FLine8)
        Me.FluentDesignFormContainer1.Controls.Add(Me.FLine7)
        Me.FluentDesignFormContainer1.Controls.Add(Me.FLine6)
        Me.FluentDesignFormContainer1.Controls.Add(Me.FLine4)
        Me.FluentDesignFormContainer1.Controls.Add(Me.FLine3)
        Me.FluentDesignFormContainer1.Controls.Add(Me.FLine2)
        Me.FluentDesignFormContainer1.Controls.Add(Me.FLine1)
        Me.FluentDesignFormContainer1.Controls.Add(Me.prclbl)
        Me.FluentDesignFormContainer1.Controls.Add(Me.InvoiceItemsDGV)
        Me.FluentDesignFormContainer1.Controls.Add(Me.prcnos)
        Me.FluentDesignFormContainer1.Controls.Add(Me.TrmCred)
        Me.FluentDesignFormContainer1.Controls.Add(Me.TrmCash)
        Me.FluentDesignFormContainer1.Controls.Add(Me.TermTXT)
        Me.FluentDesignFormContainer1.Controls.Add(Me.disctxt)
        Me.FluentDesignFormContainer1.Controls.Add(Me.Label3)
        Me.FluentDesignFormContainer1.Controls.Add(Me.Label20)
        Me.FluentDesignFormContainer1.Controls.Add(Me.cnametxt)
        Me.FluentDesignFormContainer1.Controls.Add(Me.lpotxt)
        Me.FluentDesignFormContainer1.Controls.Add(Me.Label19)
        Me.FluentDesignFormContainer1.Controls.Add(Me.trntxt)
        Me.FluentDesignFormContainer1.Controls.Add(Me.Label18)
        Me.FluentDesignFormContainer1.Controls.Add(Me.invnotxt)
        Me.FluentDesignFormContainer1.Controls.Add(Me.Ordbycb)
        Me.FluentDesignFormContainer1.Controls.Add(Me.Label1)
        Me.FluentDesignFormContainer1.Controls.Add(Me.DateTimePicker1)
        Me.FluentDesignFormContainer1.Controls.Add(Me.Label21)
        Me.FluentDesignFormContainer1.Controls.Add(Me.Label15)
        Me.FluentDesignFormContainer1.Controls.Add(Me.AccordionControl1)
        Me.FluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FluentDesignFormContainer1.Location = New System.Drawing.Point(0, 0)
        Me.FluentDesignFormContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.FluentDesignFormContainer1.Name = "FluentDesignFormContainer1"
        Me.FluentDesignFormContainer1.Size = New System.Drawing.Size(832, 489)
        Me.FluentDesignFormContainer1.TabIndex = 0
        '
        'VatCB
        '
        Me.VatCB.AutoSize = True
        Me.VatCB.Checked = True
        Me.VatCB.CheckState = System.Windows.Forms.CheckState.Checked
        Me.VatCB.Location = New System.Drawing.Point(196, 140)
        Me.VatCB.Name = "VatCB"
        Me.VatCB.Size = New System.Drawing.Size(45, 17)
        Me.VatCB.TabIndex = 197
        Me.VatCB.Text = "VAT"
        Me.VatCB.UseVisualStyleBackColor = True
        '
        'AutoCompleteLB
        '
        Me.AutoCompleteLB.FormattingEnabled = True
        Me.AutoCompleteLB.Location = New System.Drawing.Point(683, 344)
        Me.AutoCompleteLB.Name = "AutoCompleteLB"
        Me.AutoCompleteLB.Size = New System.Drawing.Size(120, 30)
        Me.AutoCompleteLB.TabIndex = 1
        Me.AutoCompleteLB.Visible = False
        '
        'FLine9
        '
        Me.FLine9.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine9.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine9.Appearance.Options.UseBackColor = True
        Me.FLine9.Appearance.Options.UseForeColor = True
        Me.FLine9.Location = New System.Drawing.Point(570, 207)
        Me.FLine9.Name = "FLine9"
        Me.FLine9.Size = New System.Drawing.Size(1, 273)
        Me.FLine9.TabIndex = 196
        '
        'FLine8
        '
        Me.FLine8.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine8.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine8.Appearance.Options.UseBackColor = True
        Me.FLine8.Appearance.Options.UseForeColor = True
        Me.FLine8.Location = New System.Drawing.Point(490, 207)
        Me.FLine8.Name = "FLine8"
        Me.FLine8.Size = New System.Drawing.Size(1, 273)
        Me.FLine8.TabIndex = 195
        '
        'FLine7
        '
        Me.FLine7.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine7.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine7.Appearance.Options.UseBackColor = True
        Me.FLine7.Appearance.Options.UseForeColor = True
        Me.FLine7.Location = New System.Drawing.Point(409, 207)
        Me.FLine7.Name = "FLine7"
        Me.FLine7.Size = New System.Drawing.Size(1, 273)
        Me.FLine7.TabIndex = 194
        '
        'FLine6
        '
        Me.FLine6.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine6.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine6.Appearance.Options.UseBackColor = True
        Me.FLine6.Appearance.Options.UseForeColor = True
        Me.FLine6.Location = New System.Drawing.Point(329, 207)
        Me.FLine6.Name = "FLine6"
        Me.FLine6.Size = New System.Drawing.Size(1, 273)
        Me.FLine6.TabIndex = 193
        '
        'FLine4
        '
        Me.FLine4.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine4.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine4.Appearance.Options.UseBackColor = True
        Me.FLine4.Appearance.Options.UseForeColor = True
        Me.FLine4.Location = New System.Drawing.Point(62, 207)
        Me.FLine4.Name = "FLine4"
        Me.FLine4.Size = New System.Drawing.Size(1, 273)
        Me.FLine4.TabIndex = 191
        '
        'FLine3
        '
        Me.FLine3.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine3.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine3.Appearance.Options.UseBackColor = True
        Me.FLine3.Appearance.Options.UseForeColor = True
        Me.FLine3.Location = New System.Drawing.Point(8, 479)
        Me.FLine3.Name = "FLine3"
        Me.FLine3.Size = New System.Drawing.Size(643, 1)
        Me.FLine3.TabIndex = 190
        '
        'FLine2
        '
        Me.FLine2.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine2.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine2.Appearance.Options.UseBackColor = True
        Me.FLine2.Appearance.Options.UseForeColor = True
        Me.FLine2.Location = New System.Drawing.Point(650, 207)
        Me.FLine2.Name = "FLine2"
        Me.FLine2.Size = New System.Drawing.Size(1, 273)
        Me.FLine2.TabIndex = 189
        '
        'FLine1
        '
        Me.FLine1.Appearance.BackColor = System.Drawing.Color.Silver
        Me.FLine1.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.FLine1.Appearance.Options.UseBackColor = True
        Me.FLine1.Appearance.Options.UseForeColor = True
        Me.FLine1.Location = New System.Drawing.Point(8, 207)
        Me.FLine1.Name = "FLine1"
        Me.FLine1.Size = New System.Drawing.Size(1, 273)
        Me.FLine1.TabIndex = 187
        '
        'prclbl
        '
        Me.prclbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prclbl.BackColor = System.Drawing.Color.White
        Me.prclbl.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prclbl.ForeColor = System.Drawing.Color.Black
        Me.prclbl.Location = New System.Drawing.Point(657, 394)
        Me.prclbl.Name = "prclbl"
        Me.prclbl.Size = New System.Drawing.Size(77, 86)
        Me.prclbl.TabIndex = 186
        Me.prclbl.Text = "Total:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Discount:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Net Total:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "VAT:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Grand Total:"
        Me.prclbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InvoiceItemsDGV
        '
        Me.InvoiceItemsDGV.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Azure
        Me.InvoiceItemsDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.InvoiceItemsDGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InvoiceItemsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.InvoiceItemsDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.InvoiceItemsDGV.BackgroundColor = System.Drawing.Color.White
        Me.InvoiceItemsDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.InvoiceItemsDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.InvoiceItemsDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.InvoiceItemsDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.InvoiceItemsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.InvoiceItemsDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SNoClm, Me.descclm, Me.UCLM, Me.QtyColm, Me.PrcClm, Me.TtlClm})
        Me.InvoiceItemsDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.InvoiceItemsDGV.EnableHeadersVisualStyles = False
        Me.InvoiceItemsDGV.GridColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.InvoiceItemsDGV.Location = New System.Drawing.Point(8, 172)
        Me.InvoiceItemsDGV.Name = "InvoiceItemsDGV"
        Me.InvoiceItemsDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.InvoiceItemsDGV.RowHeadersVisible = False
        Me.InvoiceItemsDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.InvoiceItemsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.InvoiceItemsDGV.Size = New System.Drawing.Size(643, 308)
        Me.InvoiceItemsDGV.TabIndex = 5
        '
        'SNoClm
        '
        Me.SNoClm.FillWeight = 4.0!
        Me.SNoClm.HeaderText = "S.No"
        Me.SNoClm.Name = "SNoClm"
        Me.SNoClm.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SNoClm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'descclm
        '
        Me.descclm.FillWeight = 20.0!
        Me.descclm.HeaderText = "Description"
        Me.descclm.Name = "descclm"
        Me.descclm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'UCLM
        '
        Me.UCLM.FillWeight = 6.0!
        Me.UCLM.HeaderText = "Unit"
        Me.UCLM.Name = "UCLM"
        Me.UCLM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'QtyColm
        '
        Me.QtyColm.FillWeight = 6.0!
        Me.QtyColm.HeaderText = "Qty"
        Me.QtyColm.Name = "QtyColm"
        Me.QtyColm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'PrcClm
        '
        Me.PrcClm.FillWeight = 6.0!
        Me.PrcClm.HeaderText = "Price"
        Me.PrcClm.Name = "PrcClm"
        Me.PrcClm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TtlClm
        '
        Me.TtlClm.FillWeight = 6.0!
        Me.TtlClm.HeaderText = "Total"
        Me.TtlClm.Name = "TtlClm"
        Me.TtlClm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'prcnos
        '
        Me.prcnos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prcnos.BackColor = System.Drawing.Color.White
        Me.prcnos.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prcnos.ForeColor = System.Drawing.Color.Black
        Me.prcnos.Location = New System.Drawing.Point(733, 394)
        Me.prcnos.Name = "prcnos"
        Me.prcnos.Size = New System.Drawing.Size(80, 86)
        Me.prcnos.TabIndex = 183
        Me.prcnos.Text = "AED 0.00" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AED 0.00" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AED 0.00" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AED 0.00" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AED 0.00"
        Me.prcnos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrmCred
        '
        Me.TrmCred.AutoSize = True
        Me.TrmCred.Checked = True
        Me.TrmCred.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TrmCred.Location = New System.Drawing.Point(64, 139)
        Me.TrmCred.Name = "TrmCred"
        Me.TrmCred.Size = New System.Drawing.Size(59, 19)
        Me.TrmCred.TabIndex = 182
        Me.TrmCred.TabStop = True
        Me.TrmCred.Text = "Credit"
        Me.TrmCred.UseVisualStyleBackColor = True
        '
        'TrmCash
        '
        Me.TrmCash.AutoSize = True
        Me.TrmCash.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TrmCash.Location = New System.Drawing.Point(8, 139)
        Me.TrmCash.Name = "TrmCash"
        Me.TrmCash.Size = New System.Drawing.Size(50, 19)
        Me.TrmCash.TabIndex = 181
        Me.TrmCash.Text = "Cash"
        Me.TrmCash.UseVisualStyleBackColor = True
        '
        'TermTXT
        '
        Me.TermTXT.Location = New System.Drawing.Point(129, 138)
        Me.TermTXT.Name = "TermTXT"
        Me.TermTXT.Size = New System.Drawing.Size(53, 21)
        Me.TermTXT.TabIndex = 174
        Me.TermTXT.Text = "30"
        '
        'disctxt
        '
        Me.disctxt.Location = New System.Drawing.Point(8, 104)
        Me.disctxt.Name = "disctxt"
        Me.disctxt.Size = New System.Drawing.Size(225, 21)
        Me.disctxt.TabIndex = 2
        Me.disctxt.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 15)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = "Discount in %"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(287, 2)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(58, 15)
        Me.Label20.TabIndex = 177
        Me.Label20.Text = "Company"
        '
        'cnametxt
        '
        Me.cnametxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cnametxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cnametxt.FormattingEnabled = True
        Me.cnametxt.Location = New System.Drawing.Point(290, 20)
        Me.cnametxt.MaximumSize = New System.Drawing.Size(363, 0)
        Me.cnametxt.Name = "cnametxt"
        Me.cnametxt.Size = New System.Drawing.Size(361, 21)
        Me.cnametxt.TabIndex = 0
        '
        'lpotxt
        '
        Me.lpotxt.Location = New System.Drawing.Point(290, 104)
        Me.lpotxt.Name = "lpotxt"
        Me.lpotxt.Size = New System.Drawing.Size(361, 21)
        Me.lpotxt.TabIndex = 3
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(287, 128)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 15)
        Me.Label19.TabIndex = 179
        Me.Label19.Text = "TRN Number"
        '
        'trntxt
        '
        Me.trntxt.Location = New System.Drawing.Point(290, 146)
        Me.trntxt.MaximumSize = New System.Drawing.Size(363, 20)
        Me.trntxt.MaxLength = 15
        Me.trntxt.Name = "trntxt"
        Me.trntxt.Size = New System.Drawing.Size(361, 21)
        Me.trntxt.TabIndex = 4
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(287, 86)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(78, 15)
        Me.Label18.TabIndex = 178
        Me.Label18.Text = "LPO Number"
        '
        'invnotxt
        '
        Me.invnotxt.Location = New System.Drawing.Point(8, 20)
        Me.invnotxt.Name = "invnotxt"
        Me.invnotxt.Size = New System.Drawing.Size(225, 21)
        Me.invnotxt.TabIndex = 171
        '
        'Ordbycb
        '
        Me.Ordbycb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Ordbycb.FormattingEnabled = True
        Me.Ordbycb.Location = New System.Drawing.Point(290, 62)
        Me.Ordbycb.Name = "Ordbycb"
        Me.Ordbycb.Size = New System.Drawing.Size(361, 21)
        Me.Ordbycb.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 15)
        Me.Label1.TabIndex = 168
        Me.Label1.Text = "Invoice Number"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(8, 62)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(225, 21)
        Me.DateTimePicker1.TabIndex = 166
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(287, 44)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 15)
        Me.Label21.TabIndex = 169
        Me.Label21.Text = "Order by"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(5, 44)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 15)
        Me.Label15.TabIndex = 170
        Me.Label15.Text = "Date"
        '
        'AccordionControl1
        '
        Me.AccordionControl1.Appearance.AccordionControl.BackColor = System.Drawing.Color.White
        Me.AccordionControl1.Appearance.AccordionControl.BackColor2 = System.Drawing.Color.White
        Me.AccordionControl1.Appearance.AccordionControl.BorderColor = System.Drawing.Color.White
        Me.AccordionControl1.Appearance.AccordionControl.ForeColor = System.Drawing.Color.Black
        Me.AccordionControl1.Appearance.AccordionControl.Options.UseBackColor = True
        Me.AccordionControl1.Appearance.AccordionControl.Options.UseBorderColor = True
        Me.AccordionControl1.Appearance.AccordionControl.Options.UseForeColor = True
        Me.AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.SaveRibBtn, Me.NewInvoiceRibBtn, Me.SavePDFRibBtn, Me.PrintPrevRibBtn, Me.ReloadRibBtn, Me.SaveCreditRibBtn})
        Me.AccordionControl1.Location = New System.Drawing.Point(656, 11)
        Me.AccordionControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.AccordionControl1.Name = "AccordionControl1"
        Me.AccordionControl1.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.AccordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden
        Me.AccordionControl1.SelectElementMode = DevExpress.XtraBars.Navigation.SelectElementMode.MouseDown
        Me.AccordionControl1.Size = New System.Drawing.Size(176, 306)
        Me.AccordionControl1.TabIndex = 1
        '
        'SaveRibBtn
        '
        Me.SaveRibBtn.Appearance.Disabled.BackColor = System.Drawing.Color.DimGray
        Me.SaveRibBtn.Appearance.Disabled.BorderColor = System.Drawing.Color.White
        Me.SaveRibBtn.Appearance.Disabled.ForeColor = System.Drawing.Color.White
        Me.SaveRibBtn.Appearance.Disabled.Options.UseBackColor = True
        Me.SaveRibBtn.Appearance.Disabled.Options.UseBorderColor = True
        Me.SaveRibBtn.Appearance.Disabled.Options.UseForeColor = True
        Me.SaveRibBtn.Appearance.Hovered.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.SaveRibBtn.Appearance.Hovered.Options.UseBackColor = True
        Me.SaveRibBtn.Appearance.Normal.BackColor = System.Drawing.Color.White
        Me.SaveRibBtn.Appearance.Normal.Options.UseBackColor = True
        Me.SaveRibBtn.Appearance.Pressed.BackColor = System.Drawing.Color.Silver
        Me.SaveRibBtn.Appearance.Pressed.BackColor2 = System.Drawing.Color.White
        Me.SaveRibBtn.Appearance.Pressed.BorderColor = System.Drawing.Color.White
        Me.SaveRibBtn.Appearance.Pressed.Options.UseBackColor = True
        Me.SaveRibBtn.Appearance.Pressed.Options.UseBorderColor = True
        Me.SaveRibBtn.Enabled = False
        Me.SaveRibBtn.ImageOptions.SvgImage = Global.Ravi_flags_Metro_UI.My.Resources.Resources.save
        Me.SaveRibBtn.Name = "SaveRibBtn"
        Me.SaveRibBtn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.SaveRibBtn.Text = "Save"
        '
        'NewInvoiceRibBtn
        '
        Me.NewInvoiceRibBtn.Appearance.Hovered.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.NewInvoiceRibBtn.Appearance.Hovered.Options.UseBackColor = True
        Me.NewInvoiceRibBtn.Appearance.Normal.BackColor = System.Drawing.Color.White
        Me.NewInvoiceRibBtn.Appearance.Normal.Options.UseBackColor = True
        Me.NewInvoiceRibBtn.ImageOptions.SvgImage = Global.Ravi_flags_Metro_UI.My.Resources.Resources._new
        Me.NewInvoiceRibBtn.Name = "NewInvoiceRibBtn"
        Me.NewInvoiceRibBtn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.NewInvoiceRibBtn.Text = "New"
        '
        'SavePDFRibBtn
        '
        Me.SavePDFRibBtn.Appearance.Hovered.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.SavePDFRibBtn.Appearance.Hovered.Options.UseBackColor = True
        Me.SavePDFRibBtn.Appearance.Normal.BackColor = System.Drawing.Color.White
        Me.SavePDFRibBtn.Appearance.Normal.BackColor2 = System.Drawing.Color.White
        Me.SavePDFRibBtn.Appearance.Normal.BorderColor = System.Drawing.Color.Black
        Me.SavePDFRibBtn.Appearance.Normal.Options.UseBackColor = True
        Me.SavePDFRibBtn.Appearance.Normal.Options.UseBorderColor = True
        Me.SavePDFRibBtn.Appearance.Pressed.BackColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SavePDFRibBtn.Appearance.Pressed.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SavePDFRibBtn.Appearance.Pressed.Options.UseBackColor = True
        Me.SavePDFRibBtn.Expanded = True
        Me.SavePDFRibBtn.ImageOptions.Image = Global.Ravi_flags_Metro_UI.My.Resources.Resources.addfile_32x32
        Me.SavePDFRibBtn.Name = "SavePDFRibBtn"
        Me.SavePDFRibBtn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.SavePDFRibBtn.Text = "New Invoice (Same company)"
        '
        'PrintPrevRibBtn
        '
        Me.PrintPrevRibBtn.Appearance.Hovered.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.PrintPrevRibBtn.Appearance.Hovered.Options.UseBackColor = True
        Me.PrintPrevRibBtn.Appearance.Normal.BackColor = System.Drawing.Color.White
        Me.PrintPrevRibBtn.Appearance.Normal.Options.UseBackColor = True
        Me.PrintPrevRibBtn.ImageOptions.SvgImage = CType(resources.GetObject("PrintPrevRibBtn.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.PrintPrevRibBtn.Name = "PrintPrevRibBtn"
        Me.PrintPrevRibBtn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.PrintPrevRibBtn.Text = "Print"
        '
        'ReloadRibBtn
        '
        Me.ReloadRibBtn.Appearance.Hovered.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ReloadRibBtn.Appearance.Hovered.Options.UseBackColor = True
        Me.ReloadRibBtn.Appearance.Normal.BackColor = System.Drawing.Color.White
        Me.ReloadRibBtn.Appearance.Normal.Options.UseBackColor = True
        Me.ReloadRibBtn.ImageOptions.Image = Global.Ravi_flags_Metro_UI.My.Resources.Resources.refresh_32x32
        Me.ReloadRibBtn.Name = "ReloadRibBtn"
        Me.ReloadRibBtn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.ReloadRibBtn.Text = "Reload invoice"
        '
        'SaveCreditRibBtn
        '
        Me.SaveCreditRibBtn.Appearance.Hovered.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.SaveCreditRibBtn.Appearance.Hovered.Options.UseBackColor = True
        Me.SaveCreditRibBtn.Appearance.Normal.BackColor = System.Drawing.Color.White
        Me.SaveCreditRibBtn.Appearance.Normal.Options.UseBackColor = True
        Me.SaveCreditRibBtn.ImageOptions.SvgImage = Global.Ravi_flags_Metro_UI.My.Resources.Resources.saveas
        Me.SaveCreditRibBtn.Name = "SaveCreditRibBtn"
        Me.SaveCreditRibBtn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.SaveCreditRibBtn.Text = "Save credit note"
        '
        'AccordionContentContainer1
        '
        Me.AccordionContentContainer1.Name = "AccordionContentContainer1"
        Me.AccordionContentContainer1.Size = New System.Drawing.Size(154, 76)
        Me.AccordionContentContainer1.TabIndex = 1
        '
        'AccordionControlElement5
        '
        Me.AccordionControlElement5.ContentContainer = Me.AccordionContentContainer1
        Me.AccordionControlElement5.Expanded = True
        Me.AccordionControlElement5.Name = "AccordionControlElement5"
        Me.AccordionControlElement5.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement5.Text = "Element5"
        '
        'AccordionControlElement1
        '
        Me.AccordionControlElement1.Appearance.Hovered.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.AccordionControlElement1.Appearance.Hovered.Options.UseBackColor = True
        Me.AccordionControlElement1.Appearance.Normal.BackColor = System.Drawing.Color.White
        Me.AccordionControlElement1.Appearance.Normal.Options.UseBackColor = True
        Me.AccordionControlElement1.ImageOptions.Image = Global.Ravi_flags_Metro_UI.My.Resources.Resources.refresh_32x32
        Me.AccordionControlElement1.Name = "AccordionControlElement1"
        Me.AccordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement1.Text = "Reload invoice"
        '
        'InvoiceForm
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 489)
        Me.Controls.Add(Me.FluentDesignFormContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(832, 519)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(832, 519)
        Me.Name = "InvoiceForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Invoice"
        Me.FluentDesignFormContainer1.ResumeLayout(False)
        Me.FluentDesignFormContainer1.PerformLayout()
        CType(Me.InvoiceItemsDGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FluentDesignFormContainer1 As DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer
    Friend WithEvents InvoiceItemsDGV As DataGridView
    Friend WithEvents prcnos As Label
    Friend WithEvents TrmCred As RadioButton
    Friend WithEvents TrmCash As RadioButton
    Friend WithEvents TermTXT As TextBox
    Friend WithEvents disctxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents cnametxt As ComboBox
    Friend WithEvents lpotxt As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents trntxt As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents invnotxt As TextBox
    Friend WithEvents Ordbycb As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label21 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents prclbl As Label
    Friend WithEvents AccordionContentContainer1 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents AccordionControlElement5 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents FLine1 As FLine
    Friend WithEvents FLine2 As FLine
    Friend WithEvents FLine3 As FLine
    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents SaveRibBtn As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents SavePDFRibBtn As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents PrintPrevRibBtn As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents ReloadRibBtn As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents FLine9 As FLine
    Friend WithEvents FLine8 As FLine
    Friend WithEvents FLine7 As FLine
    Friend WithEvents FLine6 As FLine
    Friend WithEvents FLine4 As FLine
    Friend WithEvents AutoCompleteLB As ListBox
    Friend WithEvents VatCB As CheckBox
    Friend WithEvents SNoClm As DataGridViewTextBoxColumn
    Friend WithEvents descclm As DataGridViewTextBoxColumn
    Friend WithEvents UCLM As DataGridViewTextBoxColumn
    Friend WithEvents QtyColm As DataGridViewTextBoxColumn
    Friend WithEvents PrcClm As DataGridViewTextBoxColumn
    Friend WithEvents TtlClm As DataGridViewTextBoxColumn
    Friend WithEvents AccordionControlElement1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents SaveCreditRibBtn As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents NewInvoiceRibBtn As DevExpress.XtraBars.Navigation.AccordionControlElement
End Class
